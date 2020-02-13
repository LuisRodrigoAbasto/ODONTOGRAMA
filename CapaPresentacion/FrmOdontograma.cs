using CapaEntity;
using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace CapaPresentacion
{
    public partial class FrmOdontograma : Form
    {
        private EUsers empleado;
        private bool atencionImpresion = false;
        private int atencionIDMostrar = 0;
        public FrmOdontograma(EUsers users)
        {
            InitializeComponent();
            empleado = users;
        }
        private int siguientePag = 0;
        private FrmBuscarPaciente Buscarusuario_NV;
        private FrmBuscarOdontologo FrmOdontologo;
        private bool imprimir = false;
        //private EPaciente paciente;

        private PictureBox[] UDiente = new PictureBox[52];
        private Label[] NroDiente = new Label[52];
        private PictureBox[,] imgDiente = new PictureBox[52, 5];

        private PictureBox[] UDienteP = new PictureBox[52];
        private PictureBox[,] imgDienteP = new PictureBox[52, 5];
        private Label[] NroDienteP = new Label[52];
        private DataGridView tablaDetalle;
        //private ToolTip[] ttMensajeNro = new ToolTip[52];
        //private ToolTip[] ttMensajeNombre = new ToolTip[52];
        private ToolTip ttMensajeNro = new ToolTip();
        private int vector = 0;
        private int vectorP = 0;
        private string colorFrm = "Transparent";
        private string colorFrmP = "Transparent";
        private string parteMedio;
        private string parteArriba;
        private string parteDerecha;
        private string parteAbajo;
        private string parteIzquierda;
        private string colorTransparente = "Transparent";
        private string colorActivo = "ActiveCaption";
        private void FrmOdontograma_Load(object sender, EventArgs e)
        {
            this.cargarTodo();
        }
        private void cargarTodo()
        {
            this.parteNombre();
            this.MostrarDB();
            this.cargarComboDiagnostico();
            this.cargarDienteInicial();
            //this.cargarDienteProc();
            this.cargarComboProcedimiento();
            this.usuarioPrioridad();
        }
        private void usuarioPrioridad()
        {
            if(this.empleado.tipo=="Odontologo")
            {
                this.pOdontologo.Visible = false;
            }
            else
            {
                this.pOdontologo.Visible = true;
            }
        }
        private void parteNombre()
        {
            this.parteMedio = NParte.mostrarNombre(1);
            this.parteArriba = NParte.mostrarNombre(2);
            this.parteDerecha = NParte.mostrarNombre(3);
            this.parteAbajo = NParte.mostrarNombre(4);
            this.parteIzquierda = NParte.mostrarNombre(5);

            this.lblMedio.Text = this.parteMedio;
            this.lblArriba.Text = this.parteArriba;
            this.lblDerecha.Text = this.parteDerecha;
            this.lblAbajo.Text = this.parteAbajo;
            this.lblIzquierda.Text = this.parteIzquierda;

            this.lblMedioP.Text = this.parteMedio;
            this.lblArribaP.Text = this.parteArriba;
            this.lblDerechaP.Text = this.parteDerecha;
            this.lblAbajoP.Text = this.parteAbajo;
            this.lblIzquierdaP.Text = this.parteIzquierda;
        }
        private void MensajeOk(String mensaje)
        {
            MessageBox.Show(mensaje, "ODONTOGRAMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "ODONTOGRAMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.MostrarDB();
        }
        private void TxtBuscarN_TextChanged(object sender, EventArgs e)
        {
            this.siguientePag = 0;
            this.MostrarDB();
        }
        private void TxtBuscarA_TextChanged(object sender, EventArgs e)
        {
            this.siguientePag = 0;
            this.MostrarDB();
        }
        private void MostrarDB()
        {
            this.dataListado.DataSource = NOdontograma.mostrar(this.txtBuscarN.Text, this.txtBuscarA.Text, this.siguientePag);
            this.ocultarDataListado();
            this.dataListado.AutoResizeColumns();
            //this.dataListado.Columns["odontogramaID"].SortMode = DataGridViewColumnSortMode.NotSortable;
            //this.dataListado.Sort(this.dataListado.Columns["odontogramaID"],);

            int dataTotal = NOdontograma.mostrarTotal(this.txtBuscarN.Text, this.txtBuscarA.Text) / 10;

            if (dataTotal == 0)
            {
                this.btnIncio.Enabled = false;
                this.btnAtras.Enabled = false;
                this.btnFin.Enabled = false;
                this.btnSiguiente.Enabled = false;
            }
            else
            {
                if (dataTotal == siguientePag)
                {
                    this.btnIncio.Enabled = true;
                    this.btnAtras.Enabled = true;
                    this.btnFin.Enabled = false;
                    this.btnSiguiente.Enabled = false;
                }
                else
                {
                    if (Convert.ToInt32(this.siguientePag) > 0)
                    {
                        this.btnAtras.Enabled = true;
                        this.btnIncio.Enabled = true;
                        this.btnFin.Enabled = true;
                        this.btnSiguiente.Enabled = true;
                    }
                    else
                    {
                        this.btnIncio.Enabled = false;
                        this.btnAtras.Enabled = false;
                        this.btnFin.Enabled = true;
                        this.btnSiguiente.Enabled = true;
                    }
                }
            }            
        }         
     
        private void ocultarDataListado()
        {
            this.dataListado.Columns["odontogramaID"].HeaderText = "ID";
            this.dataListado.Columns["estado"].Visible = false;
        }
        private void DataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
                {
                    DialogResult Opcion;
                    Opcion = MessageBox.Show("Realmente desea Eliminar El Registro", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (Opcion == DialogResult.OK)
                    {

                        string Codigo;
                        string Rpta = "";

                        Codigo = Convert.ToString(this.dataListado.CurrentRow.Cells["odontogramaID"].Value);
                        EOdontograma Obj = new EOdontograma();
                        Obj.odontogramaID = Convert.ToInt32(Codigo);
                        Rpta = Convert.ToString(NOdontograma.delete(Obj));
                        if (Rpta.Equals("OK"))
                        {
                            this.MensajeOk("Se ELimino Correctamente el Registro");
                        }
                        else
                        {
                            this.MensajeError(Rpta);
                        }

                        this.MostrarDB();

                    }
                }
                else
                {                    
                    if (e.ColumnIndex == dataListado.Columns["detalleOdon"].Index)
                    {
                            int ID = Convert.ToInt32(this.dataListado.CurrentRow.Cells["odontogramaID"].Value);
                            this.mostrarOdontograma(ID,false);
                            this.panelOdontologoImpresion.Visible = false;
                            this.pRegistroP.Visible = false;
                            this.literalImporte.Text = NConvertir.enletras(Convert.ToString(this.dataListado.CurrentRow.Cells["montoTotal"].Value));
                            NPacientes cliente = new NPacientes();
                            this.pacienteObjetoImpresion(cliente.mostraPacienteOdontograma(ID));
                            this.atencionImpresion = false;
                            this.imprimir = true;
                    }
                    else
                    {
                        if (e.ColumnIndex == dataListado.Columns["tratamientoOdontograma"].Index)
                        {
                            if (Convert.ToString(this.dataListado["Tratamiento", e.RowIndex].Value) == "CONTINUAR")
                            {
                                int num= Convert.ToInt32(this.dataListado.CurrentRow.Cells["odontogramaID"].Value);
                                NPacientes cliente = new NPacientes();
                                this.btnContinuar.Visible = true;
                                this.btnActualizarAtencion.Visible = false;
                                this.pacienteObjetoDatos(cliente.mostraPacienteOdontograma(num));
                                this.mostrarOdontograma(num,false);
                                this.mostrarTodoCliente();
                                this.mostrarDataAtencion(num);
                                this.btnGuardar.Enabled = false;
                                this.tcOdontograma.SelectedIndex = 3;
                            }
                            else
                            {
                                MessageBox.Show("EL TRATAMIENTO HA SIDO TERMINADO","ODONTOGRAMA");
                            }
                        }                        
                    }
                }
            }
        }
        private void mostrarOdontograma(int IDOdon, bool suave)
        {
            this.Controls.Remove(this.tablaDetalle);
            this.tablaDetalle = new DataGridView();
            this.tablaDetalle.Visible = false;
            if (suave)
            {
                this.limpiezaSuave();
            }
            else
            {
                this.limpiezaTotal();
            }


            
            this.Controls.Add(this.tablaDetalle);
            this.tablaDetalle.DataSource = NOdontograma_detalle.OdontogramaDetalle(IDOdon);

            this.colorearOdontogramaInicial();
            
            this.dataRegistro.AutoResizeColumns();
            this.txtIdO.Text = Convert.ToString(IDOdon);
        }
        private void colorearOdontogramaInicial()
        {
            for (int i = 0; i < Convert.ToInt32(this.tablaDetalle.RowCount); i++)
                {
                int diente1 = Convert.ToInt32(this.tablaDetalle["dienteID", i].Value);
                int parte2 = Convert.ToInt32(this.tablaDetalle["parteID", i].Value) - 1;
                string colorearD = Convert.ToString(this.tablaDetalle["colorD", i].Value);
                string colorearP = Convert.ToString(this.tablaDetalle["colorP", i].Value);
                int existe = Convert.ToInt32(this.tablaDetalle["estado", i].Value);
                int v = Convert.ToInt32(this.tablaDetalle["vector",i].Value);

                this.imgDiente[v, parte2].BackColor = Color.FromName(colorearD);
                int j = this.dataRegistro.RowCount;
                this.dataRegistro.Rows.Add();
                this.dataRegistro["nro", j].Value = v;
                this.dataRegistro["dienteID", j].Value = Convert.ToString(diente1);
                this.dataRegistro["parteID", j].Value = Convert.ToString(this.tablaDetalle["parteID", i].Value);                            
                this.dataRegistro["parte", j].Value = Convert.ToString(this.tablaDetalle["parte", i].Value);
                this.dataRegistro["diagnosticoID", j].Value = Convert.ToString(this.tablaDetalle["diagnosticoID", i].Value);
                this.dataRegistro["diagnostico", j].Value = Convert.ToString(this.tablaDetalle["diagnostico", i].Value);
                this.dataRegistro["procedimientoID", j].Value = Convert.ToString(this.tablaDetalle["procedimientoID", i].Value);
                this.dataRegistro["procedimiento", j].Value = Convert.ToString(this.tablaDetalle["procedimiento", i].Value);
                this.dataRegistro["precio", j].Value = Convert.ToString(this.tablaDetalle["precio", i].Value);
                this.dataRegistro["realizado", j].Value = Convert.ToString(this.tablaDetalle["realizado", i].Value);
                            
                this.imgDiente[v, parte2].Tag = Convert.ToString(this.tablaDetalle["diagnostico", i].Value);

                this.imgDienteP[v, parte2].BackColor = Color.FromName(colorearP);
                this.imgDienteP[v, parte2].Tag = Convert.ToString(this.tablaDetalle["procedimiento", i].Value);
                this.imgDienteP[v, parte2].AccessibleName = Convert.ToString(this.tablaDetalle["realizado", i].Value);
                this.imgDiente[v, parte2].AccessibleName = Convert.ToString(i);
                this.UDienteP[v].Enabled = true;
                this.UDienteP[v].BackColor = Color.FromName(this.colorActivo);
                this.imgDienteP[v, parte2].Enabled = true;
                this.cambiarImagenDiente(v, parte2);
                this.tablaDetalle["estado", i].Value = 2;
                this.cargarImgBienProc(v);                                    
            }
        }

        private void limpiarUserControl()
        {
            this.pDienteInicial.Controls.Clear();
            this.pDienteProc.Controls.Clear();
            this.dataRegistro.Rows.Clear();
            this.txtDiagnostico.Text = string.Empty;
            this.txtProcedimiento.Text = string.Empty;

            this.vector = 0;
            this.lblNroDiente.Text = "0";
            this.btnCentroFrm.BackColor = Color.FromName(this.colorTransparente);
            this.btnArribaFrm.BackColor = Color.FromName(this.colorTransparente);
            this.btnDerechaFrm.BackColor = Color.FromName(this.colorTransparente);
            this.btnAbajoFrm.BackColor = Color.FromName(this.colorTransparente);
            this.btnIzquierdaFrm.BackColor = Color.FromName(this.colorTransparente);

            this.chkMayor.Checked = false;
            this.chkMenor.Checked = false;
            this.chkPermanente.Checked = false;
            this.ttMensajeNro.RemoveAll();
            this.txtImporte.Text = string.Empty;
            this.txtIdO.Text = string.Empty;
            this.txtDescripcionC.Text = string.Empty;

            this.limpiarIndex();
        }
        private void limpiarIndex()
        {
            this.vector = 0;
            this.lblNroDiente.Text = "0";
            this.btnCentroFrm.BackColor = Color.FromName(this.colorTransparente);
            this.btnArribaFrm.BackColor = Color.FromName(this.colorTransparente);
            this.btnDerechaFrm.BackColor = Color.FromName(this.colorTransparente);
            this.btnAbajoFrm.BackColor = Color.FromName(this.colorTransparente);
            this.btnIzquierdaFrm.BackColor = Color.FromName(this.colorTransparente);

            this.txtImgCentro.Text = string.Empty;
            this.txtImgArriba.Text = string.Empty;
            this.txtImgDerecha.Text = string.Empty;
            this.txtImgAbajo.Text = string.Empty;
            this.txtImgIzquierda.Text = string.Empty;
            this.chkMarcarTodo.Checked = false;

            this.vectorP = 0;
            this.lblNroDienteP.Text = "0";

            this.btnCentroFrmP.BackColor = Color.FromName(this.colorTransparente);
            this.btnArribaFrmP.BackColor = Color.FromName(this.colorTransparente);
            this.btnDerechaFrmP.BackColor = Color.FromName(this.colorTransparente);
            this.btnAbajoFrmP.BackColor = Color.FromName(this.colorTransparente);
            this.btnIzquierdaFrmP.BackColor = Color.FromName(this.colorTransparente);

            this.txtImgCentroP.Text = string.Empty;
            this.txtImgArribaP.Text = string.Empty;
            this.txtImgDerechaP.Text = string.Empty;
            this.txtImgAbajoP.Text = string.Empty;
            this.txtImgIzquierdaP.Text = string.Empty;

            this.chkMarcarTodoP.Checked = false;
            this.chkTodoSI.Checked = false;

            this.chkCentroPSI.Checked = false;
            this.chkArribaPSI.Checked = false;
            this.chkDerechaPSI.Checked = false;
            this.chkAbajoPSI.Checked = false;
            this.chkIzquierdaPSI.Checked = false;
        }
        private void botonesGuardar(bool sw)
        {
            if(sw)
            {
                this.btnGuardar.Enabled = true;
                this.btnContinuar.Enabled = false;
                
            }
            else
            {
                this.btnGuardar.Enabled = false;
                this.btnContinuar.Enabled = true;
            }
            this.btnActualizarAtencion.Visible = false;
            this.panelImpresion.Visible = false;
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.limpiezaTotal();
            this.botonesGuardar(true);
            this.tcOdontograma.SelectedIndex = 1;
        }
        private void limpiezaTotal()
        {
            this.limpiarUserControl();
            this.cargarDienteInicial();
            this.cargarComboDiagnostico();
            this.cargarComboProcedimiento();
            //this.limpiarDatosCliente();
            //this.limpiarDatosOdontologo();
            this.pRegistroP.Visible = true;
            this.panelImpresion.Visible = false;
            this.dataClienteAtencion.Visible = false;
            this.dataClienteOdon.Visible = false;
            this.imprimir = false;
        }
        private void limpiezaSuave()
        {
            this.limpiarUserControl();
            this.cargarDienteInicial();

        }
        private void cargarDienteInicial()
        {
            this.vector = 0;
            this.vectorP = 0;
            bool sumar = false;
            int x = 0;
            int y = 24;
            int xx = 0;
            int yy = 0;
            int nro = 18;
            for (int i = 0; i < 52; i++)
            {
                if (i == 8)
                {
                    x = x + 100;
                    xx = xx + 100;
                    sumar = true;
                    nro = 21;
                }

                if (i == 16)
                {
                    x = 165;
                    y = 100;
                    xx = 165;
                    yy = 80;
                    sumar = false;
                    nro = 55;
                }
                if (i == 21)
                {
                    x = x + 100;
                    xx = xx + 100;
                    sumar = true;
                    nro = 61;
                }
                if (i == 26)
                {
                    x = 165;
                    y = 180;
                    xx = 165;
                    yy = 160;
                    sumar = false;
                    nro = 85;
                }

                if (i == 31)
                {
                    x = x + 100;
                    xx = xx + 100;
                    sumar = true;
                    nro = 71;
                }
                if (i == 36)
                {
                    x = 0;
                    y = 260;
                    xx = 0;
                    yy = 240;
                    sumar = false;
                    nro = 48;
                }
                if (i == 44)
                {
                    x = x + 100;
                    xx = xx + 100;
                    sumar = true;
                    nro = 31;
                }

                this.UDiente[i] = new PictureBox();
                this.NroDiente[i] = new Label();

                this.UDiente[i].Size = new Size(55, 55);
                this.UDiente[i].Top = 5 + y;
                this.UDiente[i].Left = 100 + x;
                this.UDiente[i].BackColor = Color.FromName(this.colorTransparente);
                this.UDiente[i].Visible = true;
                this.UDiente[i].Enabled = false;

                this.NroDiente[i].Size = new Size(20, 15);
                this.NroDiente[i].Top = 10 + yy;
                this.NroDiente[i].Left = 117 + xx;
                this.NroDiente[i].Text = Convert.ToString(nro);
                string nombreNumero = Convert.ToString(NDiente.mostrarNro(nro));
                this.NroDiente[i].AccessibleName = nombreNumero;

                this.ttMensajeNro.SetToolTip(this.NroDiente[i], "Diente " + nro);
                this.ttMensajeNro.SetToolTip(this.UDiente[i], nombreNumero);

                this.crearImagenUserInicial(i);


                /////////////////////////////////////////////
                this.pDienteInicial.Controls.Add(NroDiente[i]);
                this.pDienteInicial.Controls.Add(UDiente[i]);


                this.UDienteP[i] = new PictureBox();
                this.NroDienteP[i] = new Label();

                this.UDienteP[i].Size = new Size(55, 55);
                this.UDienteP[i].Top = 5 + y;
                this.UDienteP[i].Left = 100 + x;
                this.UDienteP[i].BackColor = Color.FromName(this.colorTransparente);
                this.UDienteP[i].Visible = true;
                this.UDienteP[i].Enabled = false;

                this.NroDienteP[i].Size = new Size(20, 15);
                this.NroDienteP[i].Top = 10 + yy;
                this.NroDienteP[i].Left = 117 + xx;
                this.NroDienteP[i].Text = Convert.ToString(nro);
                this.NroDienteP[i].AccessibleName = nombreNumero;
                this.pDienteProc.Controls.Add(NroDienteP[i]);
                this.pDienteProc.Controls.Add(UDienteP[i]);
                this.ttMensajeNro.SetToolTip(this.NroDienteP[i], "Diente " + nro);
                this.ttMensajeNro.SetToolTip(this.UDienteP[i], nombreNumero);
                this.crearImagenUserProc(i);


                if (sumar)
                {
                    nro++;
                }
                else
                {
                    nro--;
                }

                x = x + 55;
                xx = xx + 55;
            }
            this.mensajeTooltipInicial();
            this.mensajeTooltipVectorInicial();

            this.mensajeTooltipProc();
            this.mensajeTooltipVectorProc();
        }
        private void crearImagenUserInicial(int i)
        {

            this.imgDiente[i, 0] = new PictureBox();
            this.imgDiente[i, 0].Location = new Point(15, 15);
            this.imgDiente[i, 0].Size = new Size(25, 25); ;
            this.imgDiente[i, 0].Image = Properties.Resources.central;
            //this.imgDiente[i, 0].ImageLayout = ImageLayout.Zoom;
            this.imgDiente[i, 0].BorderStyle = BorderStyle.FixedSingle;
            this.imgDiente[i, 0].SizeMode = PictureBoxSizeMode.Zoom;
            this.imgDiente[i, 0].BackColor = Color.FromName(this.colorTransparente);
            this.imgDiente[i, 0].AccessibleDescription = Convert.ToString(0);
            this.imgDiente[i, 0].AccessibleName = Convert.ToString(-1);
            this.imgDiente[i, 0].Name = Convert.ToString(i);
            this.imgDiente[i, 0].Enabled = true;
            //this.imgDiente[i, 0].Click += new EventHandler(imgDienteInicial_Click);
            this.imgDiente[i, 0].MouseUp += new MouseEventHandler(imgDienteInicial_Click);
            this.UDiente[i].Controls.Add(this.imgDiente[i, 0]);

            this.imgDiente[i, 1] = new PictureBox();
            this.imgDiente[i, 1].Location = new Point(15, 2);
            this.imgDiente[i, 1].Size = new Size(25, 15);
            this.imgDiente[i, 1].Image = Properties.Resources.arriba;
            //this.imgDiente[i, 1].ImageLayout = ImageLayout.Zoom;
            this.imgDiente[i, 1].BorderStyle = BorderStyle.FixedSingle;
            this.imgDiente[i, 1].SizeMode = PictureBoxSizeMode.Zoom;
            this.imgDiente[i, 1].BackColor = Color.FromName(this.colorTransparente);
            this.imgDiente[i, 1].AccessibleDescription = Convert.ToString(1);
            this.imgDiente[i, 1].AccessibleName = Convert.ToString(-1);
            this.imgDiente[i, 1].Name = Convert.ToString(i);
            this.imgDiente[i, 1].Enabled = true;
            //this.imgDiente[i, 1].Click += new EventHandler(imgDienteInicial_Click);
            this.imgDiente[i, 1].MouseUp += new MouseEventHandler(imgDienteInicial_Click);
            this.UDiente[i].Controls.Add(this.imgDiente[i, 1]);

            this.imgDiente[i, 2] = new PictureBox();
            this.imgDiente[i, 2].Location = new Point(38, 12);
            this.imgDiente[i, 2].Size = new Size(15, 32); ;
            this.imgDiente[i, 2].Image = Properties.Resources.derecha;
            //this.imgDiente[i, 2].ImageLayout = ImageLayout.Zoom;
            this.imgDiente[i, 2].BorderStyle = BorderStyle.FixedSingle;
            this.imgDiente[i, 2].SizeMode = PictureBoxSizeMode.Zoom;
            this.imgDiente[i, 2].BackColor = Color.FromName(this.colorTransparente);
            this.imgDiente[i, 2].AccessibleDescription = Convert.ToString(2);
            this.imgDiente[i, 2].AccessibleName = Convert.ToString(-1);
            this.imgDiente[i, 2].Name = Convert.ToString(i);
            this.imgDiente[i, 2].Enabled = true;
            //this.imgDiente[i, 2].Click += new EventHandler(imgDienteInicial_Click);
            this.imgDiente[i, 2].MouseUp += new MouseEventHandler(imgDienteInicial_Click);
            this.UDiente[i].Controls.Add(this.imgDiente[i, 2]);

            this.imgDiente[i, 3] = new PictureBox();
            this.imgDiente[i, 3].Location = new Point(15, 38);
            this.imgDiente[i, 3].Size = new Size(25, 15); ;
            this.imgDiente[i, 3].Image = Properties.Resources.abajo;
            //this.imgDiente[i, 3].ImageLayout = ImageLayout.Zoom;
            this.imgDiente[i, 3].BorderStyle = BorderStyle.FixedSingle;
            this.imgDiente[i, 3].SizeMode = PictureBoxSizeMode.Zoom;
            this.imgDiente[i, 3].BackColor = Color.FromName(this.colorTransparente);
            this.imgDiente[i, 3].AccessibleDescription = Convert.ToString(3);
            this.imgDiente[i, 3].AccessibleName = Convert.ToString(-1);
            this.imgDiente[i, 3].Name = Convert.ToString(i);
            this.imgDiente[i, 3].Enabled = true;
            //this.imgDiente[i, 3].Click += new EventHandler(imgDienteInicial_Click);
            this.imgDiente[i, 3].MouseUp += new MouseEventHandler(imgDienteInicial_Click);
            this.UDiente[i].Controls.Add(this.imgDiente[i, 3]);

            this.imgDiente[i, 4] = new PictureBox();
            this.imgDiente[i, 4].Location = new Point(2, 12);
            this.imgDiente[i, 4].Size = new Size(15, 32); ;
            this.imgDiente[i, 4].Image = Properties.Resources.izquierda;
            //this.imgDiente[i, 4].ImageLayout = ImageLayout.Zoom;
            this.imgDiente[i, 4].BorderStyle = BorderStyle.FixedSingle;
            this.imgDiente[i, 4].SizeMode = PictureBoxSizeMode.Zoom;
            this.imgDiente[i, 4].BackColor = Color.FromName(this.colorTransparente);
            this.imgDiente[i, 4].AccessibleDescription = Convert.ToString(4);
            this.imgDiente[i, 4].AccessibleName = Convert.ToString(-1);
            this.imgDiente[i, 4].Name = Convert.ToString(i);
            this.imgDiente[i, 4].Enabled = true;
            //this.imgDiente[i, 4].Click += new EventHandler(imgDienteInicial_Click);
            this.imgDiente[i, 4].MouseUp += new MouseEventHandler(imgDienteInicial_Click);
            this.UDiente[i].Controls.Add(this.imgDiente[i, 4]);


        }
        private void mensajeTooltipVectorInicial()
        {
            for (int i = 0; i < 52; i++)
            {
                this.ttMensajeNro.SetToolTip(imgDiente[i, 0], this.parteMedio);
                this.ttMensajeNro.SetToolTip(imgDiente[i, 1], this.parteArriba);
                this.ttMensajeNro.SetToolTip(imgDiente[i, 2], this.parteDerecha);
                this.ttMensajeNro.SetToolTip(imgDiente[i, 3], this.parteAbajo);
                this.ttMensajeNro.SetToolTip(imgDiente[i, 4], this.parteIzquierda);
            }
        }
        private void mensajeTooltipInicial()
        {
            this.ttMensajeNro.SetToolTip(this.btnCentroFrm, this.parteMedio);
            this.ttMensajeNro.SetToolTip(this.btnArribaFrm, this.parteArriba);
            this.ttMensajeNro.SetToolTip(this.btnDerechaFrm, this.parteDerecha);
            this.ttMensajeNro.SetToolTip(this.btnAbajoFrm, this.parteAbajo);
            this.ttMensajeNro.SetToolTip(this.btnIzquierdaFrm, this.parteIzquierda);
        }
        private void imgDienteInicial_Click(object sender, MouseEventArgs e)
        {
            if (!this.imprimir)
            {
                int i = 0; int j = 0; int x = 0; int xc = 0;
                PictureBox eventos = sender as PictureBox;
                xc = Convert.ToInt32(eventos.Name);
                try
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        i = Convert.ToInt32(this.lblNroDiente.Text);
                        j = Convert.ToInt32(this.NroDiente[xc].Text);
                        x = Convert.ToInt32(eventos.AccessibleDescription);

                        string colors = Convert.ToString(imgDiente[xc, x].BackColor.Name);
                        if (this.txtDiagnostico.Text == string.Empty)
                        {
                            throw new Exception("Seleccione Un tratamiento");
                        }
                        if (this.colorFrm == colors)
                        {
                            this.imgDiente[xc, x].BackColor = Color.FromName(this.colorTransparente);
                            this.limpiarTextoDiagnostico(xc, x);
                            this.cambiarImagenDiente(xc, x);
                            this.imgDienteP[xc, x].BackColor = Color.FromName(this.colorTransparente);
                        }
                        else
                        {
                            eventos.BackColor = Color.FromName(this.colorFrm);
                            this.imgDiente[xc, x].Tag = this.txtDiagnostico.Text;
                            this.cambiarImagenDiente(xc, x);
                        }
                        if (i == j)
                        {
                            if (x == 0)
                            {
                                this.btnCentroFrm.BackColor = Color.FromName(eventos.BackColor.Name);
                            }
                            if (x == 1)
                            {
                                this.btnArribaFrm.BackColor = Color.FromName(eventos.BackColor.Name);
                            }
                            if (x == 2)
                            {
                                this.btnDerechaFrm.BackColor = Color.FromName(eventos.BackColor.Name);
                            }
                            if (x == 3)
                            {
                                this.btnAbajoFrm.BackColor = Color.FromName(eventos.BackColor.Name);
                            }
                            if (x == 4)
                            {
                                this.btnIzquierdaFrm.BackColor = Color.FromName(eventos.BackColor.Name);
                            }
                        }
                        else
                        {
                            this.btnCentroFrm.BackColor = Color.FromName(imgDiente[xc, 0].BackColor.Name);
                            this.btnArribaFrm.BackColor = Color.FromName(imgDiente[xc, 1].BackColor.Name);
                            this.btnDerechaFrm.BackColor = Color.FromName(imgDiente[xc, 2].BackColor.Name);
                            this.btnAbajoFrm.BackColor = Color.FromName(imgDiente[xc, 3].BackColor.Name);
                            this.btnIzquierdaFrm.BackColor = Color.FromName(imgDiente[xc, 4].BackColor.Name);
                        }
                        if (vector != xc)
                        {
                            this.UDiente[xc].BackColor = Color.FromName(this.colorActivo);
                            this.UDiente[vector].BackColor = Color.FromName(this.colorTransparente);
                            

                        }
                        this.vector = xc;

                        this.limpiarDataRegistro(xc, x);
                        this.lblNroDiente.Text = Convert.ToString(this.NroDiente[xc].Text);
                        this.lblMensaje.Visible = false;
                        this.dataRegistro.AutoResizeColumns();
                        this.mostrarColorProc(xc);

                        this.chkMarcarTodo.Checked = false;
                        
                    }
                    else
                    {
                        throw new Exception("");
                    }
                }
                catch (Exception ex)
                {
                    this.lblMensaje.Text = ex.Message;
                    this.lblMensaje.Visible = true;
                    this.dataRegistro.AutoResizeColumns();
                    if (vector != xc)
                    {
                        this.UDiente[xc].BackColor = Color.FromName(this.colorActivo);
                        this.UDiente[vector].BackColor = Color.FromName(this.colorTransparente);

                    }
                    this.btnCentroFrm.BackColor = Color.FromName(imgDiente[xc, 0].BackColor.Name);
                    this.btnArribaFrm.BackColor = Color.FromName(imgDiente[xc, 1].BackColor.Name);
                    this.btnDerechaFrm.BackColor = Color.FromName(imgDiente[xc, 2].BackColor.Name);
                    this.btnAbajoFrm.BackColor = Color.FromName(imgDiente[xc, 3].BackColor.Name);
                    this.btnIzquierdaFrm.BackColor = Color.FromName(imgDiente[xc, 4].BackColor.Name);
                    this.vector = xc;
                    this.lblNroDiente.Text = Convert.ToString(this.NroDiente[xc].Text);
                    this.cambiarImagenDiente(xc, x);

                    this.chkMarcarTodo.Checked = false;
                }
                this.mostrarTextoDiagnostico(xc);
            }
        }
        private void limpiarTextoDiagnostico(int i, int j)
        {
            this.imgDiente[i, j].Tag = string.Empty;
            this.imgDienteP[i, j].Tag = string.Empty;
        }
        private void mostrarTextoDiagnostico(int i)
        {
            this.txtImgCentro.Text = Convert.ToString(this.imgDiente[i, 0].Tag);
            this.txtImgArriba.Text = Convert.ToString(this.imgDiente[i, 1].Tag);
            this.txtImgDerecha.Text = Convert.ToString(this.imgDiente[i, 2].Tag);
            this.txtImgAbajo.Text = Convert.ToString(this.imgDiente[i, 3].Tag);
            this.txtImgIzquierda.Text = Convert.ToString(this.imgDiente[i, 4].Tag);
        }
        private void mostrarColorProc(int i)
        {

            if (this.imgDiente[i, 0].BackColor.Name == this.colorTransparente && this.imgDiente[i, 1].BackColor.Name == this.colorTransparente
                && this.imgDiente[i, 2].BackColor.Name == this.colorTransparente && this.imgDiente[i, 3].BackColor.Name == this.colorTransparente
                && this.imgDiente[i, 4].BackColor.Name == this.colorTransparente)
            {
                this.UDienteP[i].BackColor = Color.FromName(this.colorTransparente);
                this.UDienteP[i].Enabled = false;
            }
            else
            {
                this.UDienteP[i].BackColor = Color.FromName(this.colorActivo);
                this.UDienteP[i].Enabled = true;
            }
        }
        private void limpiarDataRegistro(int v,int e)
        {

            if (this.imgDiente[v, e].AccessibleName == "-1" )
            {
                int c = Convert.ToInt32(this.dataRegistro.RowCount);
                this.dataRegistro.Rows.Add();
                this.dataRegistro["nro", c].Value = Convert.ToInt32(this.imgDiente[v, e].Name);
                this.dataRegistro["parteID", c].Value = Convert.ToInt32(imgDiente[v, e].AccessibleDescription) + 1;
                this.dataRegistro["dienteID", c].Value = Convert.ToInt32(this.NroDiente[v].Text);
                this.dataRegistro["diagnosticoID", c].Value = this.txtDiagnostico.Value;
                string letra = "";
                if (e == 0)
                {
                    letra = this.parteMedio;
                }
                else
                {
                    if (e == 1)
                    {
                        letra = this.parteArriba;
                    }
                    else
                    {
                        if (e == 2)
                        {
                            letra = this.parteDerecha;
                        }
                        else
                        {
                            if (e == 3)
                            {
                                letra = this.parteAbajo;
                            }
                            else
                            {
                                letra = this.parteIzquierda;
                            }
                        }
                    }
                }
                this.dataRegistro["parte", c].Value = Convert.ToString(letra);
                this.dataRegistro["diagnostico", c].Value = Convert.ToString(this.txtDiagnostico.Text);
                this.imgDiente[v, e].AccessibleName = Convert.ToString(c);
            }
            else
            {
                if (this.imgDiente[v, e].BackColor.Name == this.colorTransparente)
                {
                    this.dataRegistro.Rows[Convert.ToInt32(this.imgDiente[v, e].AccessibleName)].Visible = false; ;
                    this.imgDiente[v, e].AccessibleName = Convert.ToString(-1);
                }
                else
                {
                    int data = Convert.ToInt32(this.imgDiente[v, e].AccessibleName);
                    this.dataRegistro["nro", data].Value = Convert.ToInt32(this.imgDiente[v, e].Name);
                    this.dataRegistro["parteID", data].Value = Convert.ToInt32(imgDiente[v, e].AccessibleDescription) + 1;
                    this.dataRegistro["dienteID", data].Value = Convert.ToInt32(this.NroDiente[v].Text);
                    this.dataRegistro["diagnosticoID", data].Value = this.txtDiagnostico.Value;
                    string letra = "";
                    if (e == 0)
                    {
                        letra = this.parteMedio;
                    }
                    else
                    {
                        if (e == 1)
                        {
                            letra = this.parteArriba;
                        }
                        else
                        {
                            if (e == 2)
                            {
                                letra = this.parteDerecha;
                            }
                            else
                            {
                                if (e == 3)
                                {
                                    letra = this.parteAbajo;
                                }
                                else
                                {
                                    letra = this.parteIzquierda;
                                }
                            }
                        }
                    }
                    this.dataRegistro["parte", data].Value = Convert.ToString(letra);
                    this.dataRegistro["diagnostico", data].Value = Convert.ToString(this.txtDiagnostico.Text);
                    this.dataRegistro["realizado", data].Value = string.Empty;
                    this.dataRegistro["procedimientoID", data].Value = string.Empty;
                    this.dataRegistro["procedimiento", data].Value = string.Empty;
                    this.dataRegistro["precio", data].Value = string.Empty;
                    this.imgDienteP[v, e].Tag = string.Empty;
                }
            }
            this.imgDienteP[v, e].AccessibleName = Convert.ToString("NO");
            this.imgDienteP[v, e].BackColor = Color.FromName(this.colorTransparente);
        }

        private void ColorDienteFrm(int diente)
        {
            try
            {
                if (this.lblNroDiente.Text == "0")
                {
                    throw new Exception("Seleccione Un Diente");
                }
                if (this.txtDiagnostico.Text == string.Empty)
                {
                    throw new Exception("Seleccione Un tratamiento");
                }
                this.cambiarColorDiente(diente);
                
                this.limpiarDataRegistro(vector,diente);
                this.cambiarImagenDiente(vector, diente);
                this.mostrarColorProc(vector);
                this.lblMensaje.Visible = false;
                this.dataRegistro.AutoResizeColumns();
                this.chkMarcarTodo.Checked = false;
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
                this.lblMensaje.Visible = true;
                this.dataRegistro.AutoResizeColumns();
            }
        }

        private void cambiarImagenDiente(int j, int diente)
        {
            if (this.imgDiente[j, diente].BackColor.Name == this.colorTransparente)
            {

                if (diente == 0)
                {
                    this.imgDienteP[j, diente].Image = Properties.Resources.central;
                }


                if (diente == 1)
                {
                    this.imgDienteP[j, diente].Image = Properties.Resources.arriba;
                }

                if (diente == 2)
                {
                    this.imgDienteP[j, diente].Image = Properties.Resources.derecha;
                }

                if (diente == 3)
                {
                    this.imgDienteP[j, diente].Image = Properties.Resources.abajo;
                }

                if (diente == 4)
                {
                    this.imgDienteP[j, diente].Image = Properties.Resources.izquierda;
                }

                this.imgDienteP[j, diente].Enabled = false;

            }
            else
            {


                if (diente == 0)
                {
                    this.imgDienteP[j, diente].Image = Properties.Resources.centroRayado;
                }

                if (diente == 1)
                {
                    this.imgDienteP[j, diente].Image = Properties.Resources.arribaRayado;
                }

                if (diente == 2)
                {
                    this.imgDienteP[j, diente].Image = Properties.Resources.derechaRayado;
                }

                if (diente == 3)
                {
                    this.imgDienteP[j, diente].Image = Properties.Resources.abajoRayado;
                }

                if (diente == 4)
                {
                    this.imgDienteP[j, diente].Image = Properties.Resources.izquierdaRayado;

                }
                this.imgDienteP[j, diente].Enabled = true;
            }
        }
        private void cambiarColorDiente(int diente)
        {
            bool sw = false;          
            if (diente == 0)
            {
                if (this.btnCentroFrm.BackColor.Name == this.colorFrm)
                {
                    this.imgDiente[vector, 0].BackColor = Color.FromName(this.colorTransparente);
                    this.btnCentroFrm.BackColor = Color.FromName(this.colorTransparente);
                    this.txtImgCentro.Text = string.Empty;
                    sw = true;
                }
                else
                {
                    this.imgDiente[vector, 0].BackColor = Color.FromName(this.colorFrm);
                    this.btnCentroFrm.BackColor = Color.FromName(this.colorFrm);
                    this.txtImgCentro.Text = this.txtDiagnostico.Text;
                }
            }
            // es el diente de arriba
            if (diente == 1)
            {
                if (this.btnArribaFrm.BackColor.Name == this.colorFrm)
                {
                    this.imgDiente[vector, 1].BackColor = Color.FromName(this.colorTransparente);
                    this.btnArribaFrm.BackColor = Color.FromName(this.colorTransparente);
                    this.txtImgArriba.Text = string.Empty;
                    sw = true;
                }
                else
                {
                    this.imgDiente[vector, 1].BackColor = Color.FromName(this.colorFrm);
                    this.btnArribaFrm.BackColor = Color.FromName(this.colorFrm);
                    this.txtImgArriba.Text = this.txtDiagnostico.Text;
                }
            }
            if (diente == 2)
            {
                if (this.btnDerechaFrm.BackColor.Name == this.colorFrm)
                {
                    this.imgDiente[vector, 2].BackColor = Color.FromName(this.colorTransparente);
                    this.btnDerechaFrm.BackColor = Color.FromName(this.colorTransparente);
                    this.txtImgDerecha.Text = string.Empty;
                    sw = true;
                }
                else
                {
                    this.imgDiente[vector, 2].BackColor = Color.FromName(this.colorFrm);
                    this.btnDerechaFrm.BackColor = Color.FromName(this.colorFrm);
                    this.txtImgDerecha.Text = this.txtDiagnostico.Text;
                }
            }
            if (diente == 3)
            {
                if (this.btnAbajoFrm.BackColor.Name == this.colorFrm)
                {
                    this.imgDiente[vector, 3].BackColor = Color.FromName(this.colorTransparente);
                    this.btnAbajoFrm.BackColor = Color.FromName(this.colorTransparente);
                    this.txtImgAbajo.Text = string.Empty;
                    sw = true;
                }
                else
                {
                    this.imgDiente[vector, 3].BackColor = Color.FromName(this.colorFrm);
                    this.btnAbajoFrm.BackColor = Color.FromName(this.colorFrm);
                    this.txtImgAbajo.Text = this.txtDiagnostico.Text;
                }
            }
            if (diente == 4)
            {
                if (this.btnIzquierdaFrm.BackColor.Name == this.colorFrm)
                {
                    this.imgDiente[vector, 4].BackColor = Color.FromName(this.colorTransparente);
                    this.btnIzquierdaFrm.BackColor = Color.FromName(this.colorTransparente);
                    this.txtImgIzquierda.Text = string.Empty;
                    sw = true;
                }
                else
                {
                    this.imgDiente[vector, 4].BackColor = Color.FromName(this.colorFrm);
                    this.btnIzquierdaFrm.BackColor = Color.FromName(this.colorFrm);
                    this.txtImgIzquierda.Text = this.txtDiagnostico.Text;
                }
            }
            if (sw)
            {
                this.limpiarTextoDiagnostico(this.vector, diente);
                this.imgDienteP[vector, diente].BackColor = Color.FromName(this.colorTransparente);
            }
            else
            {
                this.imgDiente[this.vector, diente].Tag = this.txtDiagnostico.Text;
            }
        }
        public void mostrarNroDiente(int valor)
        {
            this.lblNroDiente.Text = Convert.ToString(valor);
        }

        private void BtnCentroFrm_Click(object sender, EventArgs e)
        {
            this.ColorDienteFrm(0);

        }

        private void BtnArribaFrm_Click(object sender, EventArgs e)
        {
            this.ColorDienteFrm(1);
        }

        private void BtnDerechaFrm_Click(object sender, EventArgs e)
        {
            this.ColorDienteFrm(2);
        }

        private void BtnAbajoFrm_Click(object sender, EventArgs e)
        {
            this.ColorDienteFrm(3);
        }

        private void BtnIzquierdaFrm_Click(object sender, EventArgs e)
        {
            this.ColorDienteFrm(4);
        }
        private void ChkMarcarTodo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.lblNroDiente.Text == "0")
                {
                    throw new Exception("Seleccione Un Diente");
                }
                if (this.chkMarcarTodo.Checked == true)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (this.imgDiente[this.vector, i].BackColor.Name == this.colorTransparente || this.imgDiente[this.vector, i].BackColor.Name!=this.pColor.BackColor.Name)
                        {
                            this.ColorDienteFrm(i);
                        }
                    }
                    this.chkMarcarTodo.Checked = true;
                }
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
                this.chkMarcarTodo.Checked = false;
            }
        }
        private void cargarComboDiagnostico()
        {

            this.txtDiagnostico.DropDownList.Columns.Clear();
            this.txtDiagnostico.DropDownList.Columns.Add("tratamientoID").Width = 80;
            this.txtDiagnostico.DropDownList.Columns.Add("nombre").Width = 200;
            this.txtDiagnostico.DropDownList.Columns["tratamientoID"].Caption = "ID";
            this.txtDiagnostico.DropDownList.Columns["nombre"].Caption = "Nombre";
            this.txtDiagnostico.DisplayMember = "color";
            this.colorFrm = this.txtDiagnostico.Text;
            this.txtDiagnostico.DisplayMember = "nombre";
            this.txtDiagnostico.ValueMember = "tratamientoID";

            this.txtDiagnostico.DataSource = NTratamiento.mostrarTipo(this.txtDiagnostico.Text,"diagnostico");
            this.txtDiagnostico.Refresh();
            this.pColor.BackColor = Color.FromName(this.colorFrm);

        }

        private void TxtTratamiento_ValueChanged(object sender, EventArgs e)
        {
            this.cargarComboDiagnostico();
        }

        private void ChkMenor_Click(object sender, EventArgs e)
        {
            this.chkPermanente.Checked = false;
            for (int i = 0; i < 52; i++)
            {
                if (i >= 16 && i < 36)
                {
                    this.UDiente[i].Enabled = true;
                    this.UDiente[i].BackColor = Color.FromName(this.colorTransparente);
                }
                else
                {
                    this.UDiente[i].Enabled = false;
                    this.UDiente[i].BackColor = Color.FromName("DimGray");
                }

            }
        }

        private void ChkMayor_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 52; i++)
            {
                if (i < 16 || i >= 36)
                {
                    this.UDiente[i].Enabled = true;
                    this.UDiente[i].BackColor = Color.FromName(this.colorTransparente);
                }
                else
                {
                    this.UDiente[i].Enabled = false;
                    this.UDiente[i].BackColor = Color.FromName("DimGray");
                }

            }
        }

        private void ChkPermanente_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 52; i++)
            {
                if (i < 3 || i > 12 && i <= 38 || i > 48)
                {
                    this.UDiente[i].Enabled = true;
                    this.UDiente[i].BackColor = Color.FromName(this.colorTransparente);

                }
                else
                {
                    this.UDiente[i].Enabled = false;
                    this.UDiente[i].BackColor = Color.FromName("DimGray");
                }
            }
        }
        private void validarGuardar()
        {
            if (this.dataRegistro.RowCount < 1)
            {
                this.tcOdontograma.SelectedIndex = 2;
                throw new Exception("No tiene Ningun Diagnostico");
            }
            if (this.txtClienteID.Text== string.Empty)
            {
                this.tcOdontograma.SelectedIndex = 1;
                this.imgClienteError.Visible = true;
                throw new Exception("Selecione el Cliente");
            }
            if (empleado.tipo == "Odontologo")
            {
                this.txtOdontologoID.Text=Convert.ToString(empleado.usuarioID);                
            }
            if (this.txtOdontologoID.Text == string.Empty)
            {
                this.tcOdontograma.SelectedIndex = 1;
                this.imgOdontologoError.Visible = true;
                throw new Exception("Selecione el Odontologo");
            }
            if (this.txtImporte.Text == string.Empty || this.txtImporte.Text=="0")
            {
                this.tcOdontograma.SelectedIndex = 1;
                this.imgPrecioC.Visible = true;
                throw new Exception("Debe Importar Por el Tratamiento");
            }
            if (Convert.ToDecimal(this.txtImporte.Text) != Convert.ToDecimal(this.labelTotal.Text)) 
            {
                this.tcOdontograma.SelectedIndex = 1;
                this.imgPrecioC.Visible = true;
                throw new Exception("El Importe De Ser De Acuerdo Al Tratamiento Realizado");
            }
            for (int i=0; i < this.dataRegistro.RowCount; i++)
            {
                string dato = Convert.ToString(this.dataRegistro["precio", i].Value);
                if (dato == string.Empty && this.dataRegistro["precio", i].Visible==true)
                {
                    this.tcOdontograma.SelectedIndex = 3;
                    throw new Exception("Le Falta Marcar Procedimientos a los Diagnosticos");
                }
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                
                this.validarGuardar();
                if (Convert.ToDecimal(this.labelTotal.Text) != Convert.ToDecimal(this.txtImporte.Text))
                {
                    throw new Exception("Tiene que Cancelar el Monto que se Hizo el Tratamiento");
                }
                EOdontograma O = new EOdontograma();
                O.montoTotal = Convert.ToDecimal(this.txtMonto.Text);

                EAtencion atencion = new EAtencion();
                atencion.importe = Convert.ToDecimal(this.txtImporte.Text);
                atencion.descripcion = this.txtDescripcionC.Text;

                EUsers odontologo = new EUsers();
                NUsers datosOdontologo = new NUsers();
                odontologo = datosOdontologo.mostrarUserID(Convert.ToInt32(this.txtOdontologoID.Text));

                NPacientes npaciente = new NPacientes();
                EPaciente epaciente = new EPaciente();
                epaciente = npaciente.mostraDatos(Convert.ToInt32(this.txtClienteID.Text));

                DataTable dtDetalle = new DataTable("odontograma_detalle");
                dtDetalle.Columns.Add("dienteID", System.Type.GetType("System.Int32"));
                dtDetalle.Columns.Add("parteID", System.Type.GetType("System.Int32"));
                dtDetalle.Columns.Add("diagnosticoID", System.Type.GetType("System.Int32"));
                dtDetalle.Columns.Add("procedimientoID", System.Type.GetType("System.Int32"));
                dtDetalle.Columns.Add("realizado", System.Type.GetType("System.String"));

                int terminar = 0;
                for (int i = 0; i < this.dataRegistro.RowCount; i++)
                {
                    if (this.dataRegistro.Rows[i].Visible == true)
                    {
                        DataRow row = dtDetalle.NewRow();
                        row["dienteID"] = Convert.ToInt32(this.dataRegistro["dienteID", i].Value);
                        row["parteID"] = Convert.ToInt32(this.dataRegistro["parteID", i].Value);
                        row["diagnosticoID"] = Convert.ToInt32(this.dataRegistro["diagnosticoID", i].Value);
                        row["procedimientoID"] = Convert.ToInt32(this.dataRegistro["procedimientoID", i].Value);
                        row["realizado"] = Convert.ToString(this.dataRegistro["realizado", i].Value);
                        if(Convert.ToString(this.dataRegistro["realizado", i].Value)=="NO")
                            {
                            terminar++;
                            }
                        dtDetalle.Rows.Add(row);
                    }
                }
                if (terminar == 0)
                {
                    O.tratamiento = "TERMINADO";
                }
                else
                {
                    O.tratamiento = "CONTINUAR";
                }


                this.atencionIDMostrar = Convert.ToInt32(NOdontograma.save(O, dtDetalle,atencion,epaciente,odontologo,this.empleado));
                this.pacienteObjetoImpresion(epaciente);
                this.txtAtencionID.Text = Convert.ToString(atencionIDMostrar);
                this.literalImporte.Text = NConvertir.enletras(this.txtImporte.Text);
                
                this.odontologoObjetoImpresion(odontologo);
                this.mostrarAtencion(this.atencionIDMostrar);
                this.atencionImpresion = true;
                this.tcOdontograma.SelectedIndex = 3;
                this.atencionImpresion = true;
                this.MostrarDB();
                this.imprimir = true;
            }
            catch (Exception ex)
            {
                //    this.lblMensaje.Text = ex.Message;
                //    this.lblMensaje.Visible = true;
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
       
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiezaTotal();
            this.panelImpresion.Visible = false;
            this.pRegistroP.Visible = true;
            
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validarGuardar();
                if (Convert.ToDecimal(this.labelTotal.Text) != Convert.ToDecimal(this.txtImporte.Text))
                {
                    throw new Exception("Tiene que Cancelar el Monto que se Hizo el Tratamiento");
                }

                EOdontograma O = new EOdontograma();
                O.odontogramaID = Convert.ToInt32(this.txtIdO.Text);
                O.montoTotal = Convert.ToDecimal(this.txtMonto.Text);

                EAtencion atencion = new EAtencion();
                atencion.importe = Convert.ToDecimal(this.txtImporte.Text);
                atencion.descripcion = this.txtDescripcionC.Text;
                EUsers odontologo = new EUsers();
               
                if (empleado.tipo == "ODONTOLOGO")
                {
                    odontologo = empleado;
                }
                else
                {
                     odontologo.usuarioID = Convert.ToInt32(txtOdontologoID.Text);
                }
                NPacientes npaciente = new NPacientes();
                EPaciente epaciente = new EPaciente();
                epaciente = npaciente.mostraDatos(Convert.ToInt32(this.txtClienteID.Text));

                DataTable dtDetalle = new DataTable("odontograma_detalle");
                dtDetalle.Columns.Add("dienteID", System.Type.GetType("System.Int32"));
                dtDetalle.Columns.Add("parteID", System.Type.GetType("System.Int32"));
                dtDetalle.Columns.Add("diagnosticoID", System.Type.GetType("System.Int32"));
                dtDetalle.Columns.Add("procedimientoID", System.Type.GetType("System.Int32"));
                dtDetalle.Columns.Add("realizado", System.Type.GetType("System.String"));
                int terminar = 0;
                for (int i = 0; i < this.dataRegistro.RowCount; i++)
                {
                    if (this.dataRegistro.Rows[i].Visible == true)
                    {
                        DataRow row = dtDetalle.NewRow();
                        row["dienteID"] = Convert.ToInt32(this.dataRegistro["dienteID", i].Value);
                        row["parteID"] = Convert.ToInt32(this.dataRegistro["parteID", i].Value);
                        row["diagnosticoID"] = Convert.ToInt32(this.dataRegistro["diagnosticoID", i].Value);
                        row["procedimientoID"] = Convert.ToInt32(this.dataRegistro["procedimientoID", i].Value);
                        row["realizado"] = Convert.ToString(this.dataRegistro["realizado", i].Value);
                        if (Convert.ToString(this.dataRegistro["realizado", i].Value) == "NO")
                        {
                            terminar++;
                        }
                        dtDetalle.Rows.Add(row);
                    }
                }

                if (terminar == 0)
                {
                    O.tratamiento = "TERMINADO";
                }
                else
                {
                    O.tratamiento = "CONTINUAR";
                }

                this.atencionIDMostrar = Convert.ToInt32(NOdontograma.update(O, dtDetalle,atencion,epaciente,odontologo,empleado));
                this.literalImporte.Text = NConvertir.enletras(this.txtImporte.Text);
                this.pacienteObjetoImpresion(epaciente);
                this.txtAtencionID.Text = Convert.ToString(atencionIDMostrar);
                this.odontologoObjetoImpresion(odontologo);
                this.mostrarAtencion(this.atencionIDMostrar);

                this.atencionImpresion = true;
                this.tcOdontograma.SelectedIndex = 3;
                this.atencionImpresion = true;
                this.imprimir = true;
            }
            catch (Exception ex)
            {
                //this.lblMensaje.Text = ex.Message;
                //this.lblMensaje.Visible = true;
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        //private void cargarDienteProc()
        //{
        //    this.vectorP = 0;
        //    bool sumar = false;
        //    int x = 0;
        //    int y = 24;
        //    int xx = 0;
        //    int yy = 0;
        //    int nro = 18;
        //    for (int i = 0; i < 52; i++)
        //    {
        //        if (i == 8)
        //        {
        //            x = x + 100;
        //            xx = xx + 100;
        //            sumar = true;
        //            nro = 21;
        //        }

        //        if (i == 16)
        //        {
        //            x = 165;
        //            y = 100;
        //            xx = 165;
        //            yy = 80;
        //            sumar = false;
        //            nro = 55;
        //        }
        //        if (i == 21)
        //        {
        //            x = x + 100;
        //            xx = xx + 100;
        //            sumar = true;
        //            nro = 61;
        //        }
        //        if (i == 26)
        //        {
        //            x = 165;
        //            y = 180;
        //            xx = 165;
        //            yy = 160;
        //            sumar = false;
        //            nro = 85;
        //        }

        //        if (i == 31)
        //        {
        //            x = x + 100;
        //            xx = xx + 100;
        //            sumar = true;
        //            nro = 71;
        //        }
        //        if (i == 36)
        //        {
        //            x = 0;
        //            y = 260;
        //            xx = 0;
        //            yy = 240;
        //            sumar = false;
        //            nro = 48;
        //        }
        //        if (i == 44)
        //        {
        //            x = x + 100;
        //            xx = xx + 100;
        //            sumar = true;
        //            nro = 31;
        //        }

        //        this.UDienteP[i] = new PictureBox();
        //        this.NroDienteP[i] = new Label();

        //        this.UDienteP[i].Size = new Size(55, 55);
        //        this.UDienteP[i].Top = 5 + y;
        //        this.UDienteP[i].Left = 100 + x;
        //        this.UDienteP[i].BackColor = Color.FromName(this.colorTransparente);
        //        this.UDienteP[i].Visible = true;
        //        this.UDienteP[i].Enabled = false;

        //        this.NroDienteP[i].Size = new Size(20, 15);
        //        this.NroDienteP[i].Top = 10 + yy;
        //        this.NroDienteP[i].Left = 117 + xx;
        //        this.NroDienteP[i].Text = Convert.ToString(nro);
        //        string nombreNumero = Convert.ToString(NDiente.mostrarNro(nro));
        //        this.NroDienteP[i].AccessibleName = nombreNumero;
        //        this.pDienteProc.Controls.Add(NroDienteP[i]);
        //        this.pDienteProc.Controls.Add(UDienteP[i]);
        //        this.ttMensajeNro.SetToolTip(this.NroDienteP[i], "Diente " + nro);
        //        this.ttMensajeNro.SetToolTip(this.UDienteP[i], nombreNumero);



        //        this.crearImagenUserProc(i);

        //        if (sumar)
        //        {
        //            nro++;
        //        }
        //        else
        //        {
        //            nro--;
        //        }

        //        x = x + 55;
        //        xx = xx + 55;
        //    }
        //    this.mensajeTooltipProc();
        //    this.mensajeTooltipVectorProc();
        //}
        private void crearImagenUserProc(int i)
        {

            this.imgDienteP[i, 0] = new PictureBox();
            this.imgDienteP[i, 0].Location = new Point(15, 15);
            this.imgDienteP[i, 0].Size = new Size(25, 25); ;
            //this.imgDienteP[i, 0].Image = Properties.Resources.central;
            //this.imgDienteP[i, 0].ImageLayout = ImageLayout.Zoom;
            this.imgDienteP[i, 0].Image = Properties.Resources.central;
            this.imgDienteP[i, 0].SizeMode = PictureBoxSizeMode.Zoom;
            this.imgDienteP[i, 0].BorderStyle = BorderStyle.FixedSingle;
            this.imgDienteP[i, 0].BackColor = Color.FromName(this.colorTransparente);
            this.imgDienteP[i, 0].AccessibleDescription = Convert.ToString(0);
            this.imgDienteP[i, 0].AccessibleName = Convert.ToString("NO");
            this.imgDienteP[i, 0].Name = Convert.ToString(i);
            this.imgDienteP[i, 0].Enabled = false;
            //this.imgDienteP[i, 0].Click += new EventHandler(imgDienteProc_Click);
            this.imgDienteP[i, 0].MouseUp += new MouseEventHandler(imgDienteProc_Click);
            this.UDienteP[i].Controls.Add(this.imgDienteP[i, 0]);

            this.imgDienteP[i, 1] = new PictureBox();
            this.imgDienteP[i, 1].Location = new Point(15, 2);
            this.imgDienteP[i, 1].Size = new Size(25, 15);
            //this.imgDienteP[i, 1].Image = Properties.Resources.arriba;
            //this.imgDienteP[i, 1].ImageLayout = ImageLayout.Zoom;
            this.imgDienteP[i, 1].Image = Properties.Resources.arriba;
            this.imgDienteP[i, 1].SizeMode = PictureBoxSizeMode.Zoom;
            this.imgDienteP[i, 1].BorderStyle = BorderStyle.FixedSingle;
            this.imgDienteP[i, 1].BackColor = Color.FromName(this.colorTransparente);
            this.imgDienteP[i, 1].AccessibleDescription = Convert.ToString(1);
            this.imgDienteP[i, 1].AccessibleName = Convert.ToString("NO");
            this.imgDienteP[i, 1].Name = Convert.ToString(i);
            this.imgDienteP[i, 1].Enabled = false;
            //this.imgDienteP[i, 1].Click += new EventHandler(imgDienteProc_Click);
            this.imgDienteP[i, 1].MouseUp += new MouseEventHandler(imgDienteProc_Click);
            this.UDienteP[i].Controls.Add(this.imgDienteP[i, 1]);

            this.imgDienteP[i, 2] = new PictureBox();
            this.imgDienteP[i, 2].Location = new Point(38, 12);
            this.imgDienteP[i, 2].Size = new Size(15, 32); ;
            //this.imgDienteP[i, 2].Image = Properties.Resources.derecha;
            //this.imgDienteP[i, 2].ImageLayout = ImageLayout.Zoom;
            this.imgDienteP[i, 2].Image = Properties.Resources.derecha;
            this.imgDienteP[i, 2].SizeMode = PictureBoxSizeMode.Zoom;
            this.imgDienteP[i, 2].BorderStyle = BorderStyle.FixedSingle;
            this.imgDienteP[i, 2].BackColor = Color.FromName(this.colorTransparente);
            this.imgDienteP[i, 2].AccessibleDescription = Convert.ToString(2);
            this.imgDienteP[i, 2].AccessibleName = Convert.ToString("NO");
            this.imgDienteP[i, 2].Name = Convert.ToString(i);
            this.imgDienteP[i, 2].Enabled = false;
            //this.imgDienteP[i, 2].Click += new EventHandler(imgDienteProc_Click);
            this.imgDienteP[i, 2].MouseUp += new MouseEventHandler(imgDienteProc_Click);
            this.UDienteP[i].Controls.Add(this.imgDienteP[i, 2]);

            this.imgDienteP[i, 3] = new PictureBox();
            this.imgDienteP[i, 3].Location = new Point(15, 38);
            this.imgDienteP[i, 3].Size = new Size(25, 15); ;
            //this.imgDienteP[i, 3].Image = Properties.Resources.abajo;
            //this.imgDienteP[i, 3].ImageLayout = ImageLayout.Zoom;
            this.imgDienteP[i, 3].Image = Properties.Resources.abajo;
            this.imgDienteP[i, 3].SizeMode = PictureBoxSizeMode.Zoom;
            this.imgDienteP[i, 3].BorderStyle = BorderStyle.FixedSingle;
            this.imgDienteP[i, 3].BackColor = Color.FromName(this.colorTransparente);
            this.imgDienteP[i, 3].AccessibleDescription = Convert.ToString(3);
            this.imgDienteP[i, 3].AccessibleName = Convert.ToString("NO");
            this.imgDienteP[i, 3].Name = Convert.ToString(i);
            this.imgDienteP[i, 3].Enabled = false;
            //this.imgDienteP[i, 3].Click += new EventHandler(imgDienteProc_Click);
            this.imgDienteP[i, 3].MouseUp += new MouseEventHandler(imgDienteProc_Click);
            this.UDienteP[i].Controls.Add(this.imgDienteP[i, 3]);

            this.imgDienteP[i, 4] = new PictureBox();
            this.imgDienteP[i, 4].Location = new Point(2, 12);
            this.imgDienteP[i, 4].Size = new Size(15, 32); ;
            //this.imgDienteP[i, 4].Image = Properties.Resources.izquierda;
            //this.imgDienteP[i, 4].ImageLayout = ImageLayout.Zoom;
            this.imgDienteP[i, 4].Image = Properties.Resources.izquierda;
            this.imgDienteP[i, 4].SizeMode = PictureBoxSizeMode.Zoom;
            this.imgDienteP[i, 4].BorderStyle = BorderStyle.FixedSingle;
            this.imgDienteP[i, 4].BackColor = Color.FromName(this.colorTransparente);
            this.imgDienteP[i, 4].AccessibleDescription = Convert.ToString(4);
            this.imgDienteP[i, 4].AccessibleName = Convert.ToString("NO");
            this.imgDienteP[i, 4].Name = Convert.ToString(i);
            this.imgDienteP[i, 4].Enabled = false;
            //this.imgDienteP[i, 4].Click += new EventHandler(imgDienteProc_Click);
            this.imgDienteP[i, 4].MouseUp += new MouseEventHandler(imgDienteProc_Click);
            this.UDienteP[i].Controls.Add(this.imgDienteP[i, 4]);


        }
        private void mensajeTooltipVectorProc()
        {
            for (int i = 0; i < 52; i++)
            {
                this.ttMensajeNro.SetToolTip(imgDienteP[i, 0], this.parteMedio);
                this.ttMensajeNro.SetToolTip(imgDienteP[i, 1], this.parteArriba);
                this.ttMensajeNro.SetToolTip(imgDienteP[i, 2], this.parteDerecha);
                this.ttMensajeNro.SetToolTip(imgDienteP[i, 3], this.parteAbajo);
                this.ttMensajeNro.SetToolTip(imgDienteP[i, 4], this.parteIzquierda);
            }
        }
        private void mensajeTooltipProc()
        {
            this.ttMensajeNro.SetToolTip(this.btnCentroFrmP, this.parteMedio);
            this.ttMensajeNro.SetToolTip(this.btnArribaFrmP, this.parteArriba);
            this.ttMensajeNro.SetToolTip(this.btnDerechaFrmP, this.parteDerecha);
            this.ttMensajeNro.SetToolTip(this.btnAbajoFrmP, this.parteAbajo);
            this.ttMensajeNro.SetToolTip(this.btnIzquierdaFrmP, this.parteIzquierda);
        }
        private void imgDienteProc_Click(object sender, MouseEventArgs e)
        {
            if (!this.imprimir)
            {
                int i = 0; int j = 0; int x = 0; int xc = 0;
                PictureBox eventos = sender as PictureBox;
                xc = Convert.ToInt32(eventos.Name);
                if (this.lblNroDienteP.Text == "0")
                {
                    this.lblNroDienteP.Text = Convert.ToString(this.NroDienteP[xc].Text);
                }
                try
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {


                        i = Convert.ToInt32(this.lblNroDienteP.Text);
                        j = Convert.ToInt32(this.NroDienteP[xc].Text);
                        x = Convert.ToInt32(eventos.AccessibleDescription);



                        string colors = Convert.ToString(imgDienteP[xc, x].BackColor.Name);
                        if (this.txtProcedimiento.Text == string.Empty)
                        {
                            throw new Exception("Seleccione Un tratamiento");
                        }

                        if (this.colorFrmP == colors)
                        {
                            this.imgDienteP[xc, x].BackColor = Color.FromName(this.colorTransparente);
                            this.limpiarTextoProcedimiento(xc, x);
                        }
                        else
                        {
                            eventos.BackColor = Color.FromName(this.colorFrmP);
                            this.imgDienteP[xc, x].Tag = this.txtProcedimiento.Text;
                            this.agregarDataRegistroP(xc, x);
                        }
                        if (i == j)
                        {
                            if (x == 0)
                            {
                                this.btnCentroFrmP.BackColor = Color.FromName(eventos.BackColor.Name);
                            }
                            if (x == 1)
                            {
                                this.btnArribaFrmP.BackColor = Color.FromName(eventos.BackColor.Name);
                            }
                            if (x == 2)
                            {
                                this.btnDerechaFrmP.BackColor = Color.FromName(eventos.BackColor.Name);
                            }
                            if (x == 3)
                            {
                                this.btnAbajoFrmP.BackColor = Color.FromName(eventos.BackColor.Name);
                            }
                            if (x == 4)
                            {
                                this.btnIzquierdaFrmP.BackColor = Color.FromName(eventos.BackColor.Name);
                            }
                        }
                        else
                        {
                            this.btnCentroFrmP.BackColor = Color.FromName(this.imgDienteP[xc, 0].BackColor.Name);
                            this.btnArribaFrmP.BackColor = Color.FromName(this.imgDienteP[xc, 1].BackColor.Name);
                            this.btnDerechaFrmP.BackColor = Color.FromName(this.imgDienteP[xc, 2].BackColor.Name);
                            this.btnAbajoFrmP.BackColor = Color.FromName(this.imgDienteP[xc, 3].BackColor.Name);
                            this.btnIzquierdaFrmP.BackColor = Color.FromName(this.imgDienteP[xc, 4].BackColor.Name);
                            this.activarEnableProc(xc);
                        }
                        if (this.vectorP != xc)
                        {
                            if (this.lblNroDienteP.Text != "0")
                            {
                                if (this.UDienteP[vectorP].Enabled == true)
                                {
                                    this.UDienteP[vectorP].BackColor = Color.FromName(this.colorActivo);
                                }
                            }
                            this.UDienteP[xc].BackColor = Color.FromName("Gray");
                        }
                        this.vectorP = xc;
                        this.lblNroDienteP.Text = Convert.ToString(this.NroDienteP[xc].Text);

                        this.lblMensajeP.Visible = false;
                        this.dataRegistro.AutoResizeColumns();
                        this.chkMarcarTodoP.Checked = false;
                        this.chkTodoSI.Checked = false;
                        this.cargarChkImg(xc);
                        //this.cambiarColorDienteP(xc, x);
                        this.cargarBotonesImg(xc);
                        this.cargarImgBienProc(xc);
                        this.mostrarTextoProcedimiento(xc);
                    }
                    else
                    {
                        throw new Exception("");
                    }
                }

                catch (Exception ex)
                {
                    this.lblMensajeP.Text = ex.Message;
                    this.lblMensajeP.Visible = true;
                    this.dataRegistro.AutoResizeColumns();

                    if (this.vectorP != xc)
                    {
                        if (this.lblNroDienteP.Text != "0")
                        {
                            if (this.UDienteP[vectorP].Enabled == true)
                            {
                                this.UDienteP[vectorP].BackColor = Color.FromName(this.colorActivo);
                            }
                        }
                        this.UDienteP[xc].BackColor = Color.FromName("Gray");
                    }
                    this.vectorP = xc;
                    this.lblNroDienteP.Text = Convert.ToString(this.NroDienteP[xc].Text);
                    this.mostrarTextoProcedimiento(xc);

                    this.btnCentroFrmP.BackColor = Color.FromName(this.imgDienteP[xc, 0].BackColor.Name);
                    this.btnArribaFrmP.BackColor = Color.FromName(this.imgDienteP[xc, 1].BackColor.Name);
                    this.btnDerechaFrmP.BackColor = Color.FromName(this.imgDienteP[xc, 2].BackColor.Name);
                    this.btnAbajoFrmP.BackColor = Color.FromName(this.imgDienteP[xc, 3].BackColor.Name);
                    this.btnIzquierdaFrmP.BackColor = Color.FromName(this.imgDienteP[xc, 4].BackColor.Name);
                    this.activarEnableProc(xc);
                    this.cargarBotonesImg(xc);
                    this.cargarChkImg(xc);
                    this.chkMarcarTodoP.Checked = false;
                    this.chkTodoSI.Checked = false;
                }
            }
        }
        private void cargarBotonesImg(int j)
        {

            if (this.imgDienteP[j, 0].Enabled == true)
            {
                if (Convert.ToString(this.imgDienteP[j, 0].AccessibleName) == "SI")
                {
                    this.btnCentroFrmP.Image = Properties.Resources.centroBien;
                }
                else
                {
                    this.btnCentroFrmP.Image = Properties.Resources.centroRayado;
                }
            }
            else
            {                
                this.btnCentroFrmP.Image = Properties.Resources.central;
            }

            if (this.imgDienteP[j, 1].Enabled == true)
            {
                if (Convert.ToString(this.imgDienteP[j, 1].AccessibleName) == "SI")
                {
                    this.btnArribaFrmP.Image = Properties.Resources.arribaBien;
                }
                else
                {
                    this.btnArribaFrmP.Image = Properties.Resources.arribaRayado;
                }
            }
            else
            {
                this.btnArribaFrmP.Image = Properties.Resources.arriba;
            }

            if (this.imgDienteP[j, 2].Enabled == true)
            {
                if (Convert.ToString(this.imgDienteP[j, 2].AccessibleName) == "SI")
                {
                    this.btnDerechaFrmP.Image = Properties.Resources.derechaBien;
                }
                else
                {
                    this.btnDerechaFrmP.Image = Properties.Resources.derechaRayado;
                }
            }
            else
            {
                this.btnDerechaFrmP.Image = Properties.Resources.derecha;
            }

            if (this.imgDienteP[j, 3].Enabled == true)
            {
                if (Convert.ToString(this.imgDienteP[j, 3].AccessibleName) == "SI")
                {
                    this.btnAbajoFrmP.Image = Properties.Resources.abajoBien;
                }
                else
                {
                    this.btnAbajoFrmP.Image = Properties.Resources.abajoRayado;
                }
            }
            else
            {
                this.btnAbajoFrmP.Image = Properties.Resources.abajo;
            }

            if (this.imgDienteP[j, 4].Enabled == true)
            {
                if (Convert.ToString(this.imgDienteP[j, 4].AccessibleName) == "SI")
                {
                    this.btnIzquierdaFrmP.Image = Properties.Resources.izquierdaBien;
                }
                else
                {
                    this.btnIzquierdaFrmP.Image = Properties.Resources.izquierdaRayado;
                }
            }
            else
            {
                this.btnIzquierdaFrmP.Image = Properties.Resources.izquierda;
            }
        }

        private void cargarChkImg(int j)
        {            
           if (Convert.ToString(this.imgDienteP[j, 0].Tag) !=string.Empty)
           {
              this.chkCentroPSI.Enabled = true;
                  if (Convert.ToString(this.imgDienteP[j, 0].AccessibleName) == "SI")
                  {
                        this.chkCentroPSI.Checked = true;
                  }
                 else
                    {
                        this.chkCentroPSI.Checked = false;
                    }
            }
                else
                {
                this.chkCentroPSI.Enabled = false;
            }
            

            if (Convert.ToString(this.imgDienteP[j, 1].Tag) != string.Empty)
            {
                this.chkArribaPSI.Enabled = true;
                if (Convert.ToString(this.imgDienteP[j, 1].AccessibleName) == "SI")
                {
                    this.chkArribaPSI.Checked = true;
                }
                else
                {
                    this.chkArribaPSI.Checked = false;
                }
            }
            else
            {
                this.chkArribaPSI.Enabled = false;
            }

            if (Convert.ToString(this.imgDienteP[j, 2].Tag) != string.Empty)
            {
                this.chkDerechaPSI.Enabled = true;
                if (Convert.ToString(this.imgDienteP[j, 2].AccessibleName) == "SI")
                {
                    this.chkDerechaPSI.Checked = true;
                }
                else
                {
                    this.chkDerechaPSI.Checked = false; ;
                }
            }
            else
            {
                this.chkDerechaPSI.Enabled = false;
            }

            if (Convert.ToString(this.imgDienteP[j, 3].Tag) != string.Empty)
            {
                this.chkAbajoPSI.Enabled = true;
                if (Convert.ToString(this.imgDienteP[j, 3].AccessibleName) == "SI")
                {
                    this.chkAbajoPSI.Checked = true;
                }
                else
                {
                    this.chkAbajoPSI.Checked = false;
                }
            }
            else
            {
                this.chkAbajoPSI.Enabled = false;
            }

            if (Convert.ToString(this.imgDienteP[j, 4].Tag) != string.Empty)
            {
                this.chkIzquierdaPSI.Enabled = true;
                if (Convert.ToString(this.imgDienteP[j, 4].AccessibleName) == "SI")
                {
                    this.chkIzquierdaPSI.Checked = true;
                }
                else
                {
                    this.chkIzquierdaPSI.Checked = false;
                }
            }
            else
            {
                this.chkIzquierdaPSI.Enabled = false;
            }
        }
        private void activarEnableProc(int xc)
        {
            if (this.imgDienteP[xc, 0].Enabled == true)
            {
                this.btnCentroFrmP.Enabled = true;
            }
            else
            {
                this.btnCentroFrmP.Enabled = false;
            }

            if (this.imgDienteP[xc, 1].Enabled == true)
            {
                this.btnArribaFrmP.Enabled = true;
            }
            else
            {
                this.btnArribaFrmP.Enabled = false;
            }

            if (this.imgDienteP[xc, 2].Enabled == true)
            {
                this.btnDerechaFrmP.Enabled = true;
            }
            else
            {
                this.btnDerechaFrmP.Enabled = false;
            }

            if (this.imgDienteP[xc, 3].Enabled == true)
            {
                this.btnAbajoFrmP.Enabled = true;
            }
            else
            {
                this.btnAbajoFrmP.Enabled = false;
            }

            if (this.imgDienteP[xc, 4].Enabled == true)
            {
                this.btnIzquierdaFrmP.Enabled = true;
            }
            else
            {
                this.btnIzquierdaFrmP.Enabled = false;
            }
        }
        private void limpiarTextoProcedimiento(int i, int j)
        {
            int fila = Convert.ToInt32(this.imgDiente[i, j].AccessibleName);
            this.dataRegistro["procedimientoID", fila].Value = string.Empty;
            this.dataRegistro["procedimiento", fila].Value = string.Empty;
            this.dataRegistro["realizado", fila].Value = string.Empty;
            this.dataRegistro["precio", fila].Value = string.Empty;
            this.imgDienteP[i, j].Tag = string.Empty;
            this.imgDienteP[i, j].AccessibleName = "NO";
        }
        private void mostrarTextoProcedimiento(int i)
        {
            this.txtImgCentroP.Text = Convert.ToString(this.imgDiente[i, 0].Tag)+"  " + Convert.ToString(this.imgDienteP[i, 0].Tag);
            this.txtImgArribaP.Text = Convert.ToString(this.imgDiente[i, 1].Tag) + "  " + Convert.ToString(this.imgDienteP[i, 1].Tag);
            this.txtImgDerechaP.Text = Convert.ToString(this.imgDiente[i, 2].Tag) + "  " + Convert.ToString(this.imgDienteP[i, 2].Tag);
            this.txtImgAbajoP.Text = Convert.ToString(this.imgDiente[i, 3].Tag) + "  " + Convert.ToString(this.imgDienteP[i, 3].Tag);
            this.txtImgIzquierdaP.Text = Convert.ToString(this.imgDiente[i, 4].Tag) + "  " + Convert.ToString(this.imgDienteP[i, 4].Tag);
            this.cambiarRealizado(i);
            
        }
        private void cambiarRealizado(int i)
        {
            if (this.imgDienteP[i, 0].BackColor.Name != this.colorTransparente)
            {
                this.chkCentroPSI.Enabled = true;

                if (Convert.ToString(this.imgDienteP[i, 0].AccessibleName) == "SI")
                {                   
                    this.chkCentroPSI.Checked = true;                             
                }
                else
                {                   
                    this.chkCentroPSI.Checked = false;                   
                }
            }
            else
            {
                this.chkCentroPSI.Enabled = false;
                this.chkCentroPSI.Checked = false;
            }
            if (this.imgDienteP[i, 1].BackColor.Name != this.colorTransparente)
            {
                this.chkArribaPSI.Enabled = true;

                if (Convert.ToString(this.imgDienteP[i, 1].AccessibleName) == "SI")
                {
                    this.chkArribaPSI.Checked = true;
                }
                else
                {
                    this.chkArribaPSI.Checked = false;
                }
            }
            else
            {
                this.chkArribaPSI.Enabled = false;
                this.chkArribaPSI.Checked = false;
            }

            if (this.imgDienteP[i, 2].BackColor.Name != this.colorTransparente)
            {
                this.chkDerechaPSI.Enabled = true;
                
                if (Convert.ToString(this.imgDienteP[i, 2].AccessibleName) == "SI")
                {
                    this.chkDerechaPSI.Checked = true;                   
                }
                else
                {
                    this.chkDerechaPSI.Checked = false;                   
                }
            }
            else
            {
                this.chkDerechaPSI.Enabled = false;              
                this.chkDerechaPSI.Checked = false;
            }                      
               
            if(this.imgDienteP[i, 3].BackColor.Name != this.colorTransparente)
            {
                this.chkAbajoPSI.Enabled = true;
                if (Convert.ToString(this.imgDienteP[i, 3].AccessibleName) == "SI")
                {
                    this.chkAbajoPSI.Checked = true;                   
                }
                else
                {
                    this.chkAbajoPSI.Checked = false;
                }
            }
            else
            {
                this.chkAbajoPSI.Enabled = false;
                this.chkAbajoPSI.Checked = false;
            }           
               
            if(this.imgDienteP[i, 4].BackColor.Name != this.colorTransparente)
            {
                this.chkIzquierdaPSI.Enabled = true;
                if (Convert.ToString(this.imgDienteP[i, 4].AccessibleName) == "SI")
                {
                    this.chkIzquierdaPSI.Checked = true;
                }
                else
                {
                    this.chkIzquierdaPSI.Checked = false;
                }
            }
            else
            {
                this.chkIzquierdaPSI.Enabled = false;
                this.chkIzquierdaPSI.Checked = false;
            }
        }


        private void agregarDataRegistroP(int v,int e)
        {
            int fila = Convert.ToInt32(this.imgDiente[v, e].AccessibleName);

            this.dataRegistro["procedimientoID", fila].Value = this.txtProcedimiento.Value;
            this.dataRegistro["procedimiento", fila].Value = this.txtProcedimiento.Text;
            this.dataRegistro["realizado", fila].Value = this.imgDienteP[v, e].AccessibleName;
            this.dataRegistro["precio", fila].Value = this.txtPrecioP.Text;
        }

        private void ColorDienteFrmP(int diente)
        {
            try
            {
                
                if (this.lblNroDienteP.Text == "0" || this.imgDienteP[vectorP, diente].Enabled == false)
                {
                    this.btnCentroFrmP.BackColor = Color.FromName(this.imgDienteP[vectorP, 0].BackColor.Name);
                    this.btnArribaFrmP.BackColor = Color.FromName(this.imgDienteP[vectorP, 1].BackColor.Name);
                    this.btnDerechaFrmP.BackColor = Color.FromName(this.imgDienteP[vectorP, 2].BackColor.Name);
                    this.btnAbajoFrmP.BackColor = Color.FromName(this.imgDienteP[vectorP, 3].BackColor.Name);
                    this.btnIzquierdaFrmP.BackColor = Color.FromName(this.imgDienteP[vectorP, 4].BackColor.Name);
                    this.imgDienteP[vectorP, 0].Tag = string.Empty;
                    this.imgDienteP[vectorP, 1].Tag = string.Empty;
                    this.imgDienteP[vectorP, 2].Tag = string.Empty;
                    this.imgDienteP[vectorP, 3].Tag = string.Empty;
                    this.imgDienteP[vectorP, 4].Tag = string.Empty;

                    this.txtImgCentroP.Text = string.Empty;
                    this.txtImgArribaP.Text = string.Empty;
                    this.txtImgDerechaP.Text = string.Empty;
                    this.txtImgAbajoP.Text = string.Empty;
                    this.txtImgIzquierdaP.Text = string.Empty;

                    this.activarEnableProc(vectorP);
                    this.cargarBotonesImg(vectorP);
                    this.cargarChkImg(vectorP);

                    throw new Exception("Seleccione Un Diente");
                }
                if (this.txtProcedimiento.Text == string.Empty)
                {
                    throw new Exception("Seleccione Un tratamiento");
                }
                
                this.cambiarColorDienteP(this.vectorP,diente);
                
                this.lblMensajeP.Visible = false;
                this.dataRegistro.AutoResizeColumns();
                //this.chkMarcarTodoP.Checked = false;
                this.chkTodoSI.Checked = false;
                this.mostrarTextoProcedimiento(this.vectorP);
                this.cargarBotonesImg(vectorP);
                this.cargarChkImg(vectorP);
                this.cargarImgBienProc(vectorP);
            }
            catch (Exception ex)
            {
                this.lblMensajeP.Text = ex.Message;
                this.lblMensajeP.Visible = true;
                this.dataRegistro.AutoResizeColumns();
            }
        }

        private void cambiarColorDienteP(int v,int diente)
        {
            bool sw = false;
            if (diente == 0)
            {
                if (this.imgDienteP[v, 0].BackColor.Name == this.colorFrmP)
                {
                    this.imgDienteP[v, 0].BackColor = Color.FromName(this.colorTransparente);
                    this.btnCentroFrmP.BackColor = Color.FromName(this.colorTransparente);
                    sw = true;
                    this.chkCentroPSI.Enabled = false;
                }
                else
                {
                    this.imgDienteP[v, 0].BackColor = Color.FromName(this.colorFrmP);
                    this.btnCentroFrmP.BackColor = Color.FromName(this.colorFrmP);
                    this.chkCentroPSI.Enabled = true;
                }
            }
            // es el diente de arriba
            if (diente == 1)
            {
                if (this.imgDienteP[v, 1].BackColor.Name == this.colorFrmP)
                {
                    this.imgDienteP[v, 1].BackColor = Color.FromName(this.colorTransparente);
                    this.btnArribaFrmP.BackColor = Color.FromName(this.colorTransparente);
                    sw = true;
                    this.chkArribaPSI.Enabled = false;
                }
                else
                {
                    this.imgDienteP[v, 1].BackColor = Color.FromName(this.colorFrmP);
                    this.btnArribaFrmP.BackColor = Color.FromName(this.colorFrmP);
                    this.chkArribaPSI.Enabled = true;
                }
            }
            if (diente == 2)
            {
                if (this.imgDienteP[v, 2].BackColor.Name == this.colorFrmP)
                {
                    this.imgDienteP[v, 2].BackColor = Color.FromName(this.colorTransparente);
                    this.btnDerechaFrmP.BackColor = Color.FromName(this.colorTransparente);
                    sw = true;
                    this.chkDerechaPSI.Enabled = false;
                }
                else
                {
                    this.imgDienteP[v, 2].BackColor = Color.FromName(this.colorFrmP);
                    this.btnDerechaFrmP.BackColor = Color.FromName(this.colorFrmP);
                    this.chkDerechaPSI.Enabled = true;
                }
            }
            if (diente == 3)
            {
                if (this.imgDienteP[v, 3].BackColor.Name == this.colorFrmP)
                {
                    this.imgDienteP[v, 3].BackColor = Color.FromName(this.colorTransparente);
                    this.btnAbajoFrmP.BackColor = Color.FromName(this.colorTransparente);
                    sw = true;
                    this.chkAbajoPSI.Enabled = false;
                }
                else
                {
                    this.imgDienteP[v, 3].BackColor = Color.FromName(this.colorFrmP);
                    this.btnAbajoFrmP.BackColor = Color.FromName(this.colorFrmP);
                    this.chkAbajoPSI.Enabled = true;
                }
            }
            if (diente == 4)
            {
                if (this.imgDienteP[v, 4].BackColor.Name == this.colorFrmP)
                {
                    this.imgDienteP[v, 4].BackColor = Color.FromName(this.colorTransparente);
                    this.btnIzquierdaFrmP.BackColor = Color.FromName(this.colorTransparente);
                    sw = true;
                    this.chkIzquierdaPSI.Enabled = false;
                }
                else
                {
                    this.imgDienteP[v, 4].BackColor = Color.FromName(this.colorFrmP);
                    this.btnIzquierdaFrmP.BackColor = Color.FromName(this.colorFrmP);
                    this.chkIzquierdaPSI.Enabled = true;
                }
                
            }
            if (sw)
            {
                this.limpiarTextoProcedimiento(v, diente);                
            }
            else
            {
                this.agregarDataRegistroP(v, diente);
                this.imgDienteP[v, diente].Tag = this.txtProcedimiento.Text;
            }
            
            
        }
        public void mostrarNroDienteP(int valor)
        {
            this.lblNroDienteP.Text = Convert.ToString(valor);
        }

        private void TxtProcedimiento_ValueChanged(object sender, EventArgs e)
        {
            this.cargarComboProcedimiento();
        }
        private void cargarComboProcedimiento()
        {
            this.txtProcedimiento.DropDownList.Columns.Clear();
            this.txtProcedimiento.DropDownList.Columns.Add("tratamientoID").Width = 80;
            this.txtProcedimiento.DropDownList.Columns.Add("nombre").Width = 250;
            this.txtProcedimiento.DropDownList.Columns.Add("Precio").Width = 100;

            this.txtProcedimiento.DropDownList.Columns["tratamientoID"].Caption = "ID"; 
            this.txtProcedimiento.DropDownList.Columns["nombre"].Caption = "Nombre";
            this.txtProcedimiento.DropDownList.Columns["precio"].Caption = "Precio";
            this.txtProcedimiento.DisplayMember = "precio";
            this.txtPrecioP.Text = Convert.ToString(this.txtProcedimiento.Text);
            this.txtProcedimiento.DisplayMember = "color";
            this.colorFrmP = this.txtProcedimiento.Text;
            this.txtProcedimiento.DisplayMember = "nombre";
            this.txtProcedimiento.ValueMember = "tratamientoID";

            this.txtProcedimiento.DataSource = NTratamiento.mostrarTipo(this.txtProcedimiento.Text,"procedimiento");
            this.txtProcedimiento.Refresh();
            this.pColorP.BackColor = Color.FromName(this.colorFrmP);
        }

        private void BtnCentroFrmP_Click(object sender, EventArgs e)
        {
            this.ColorDienteFrmP(0);
        }

        private void BtnArribaFrmP_Click(object sender, EventArgs e)
        {
            this.ColorDienteFrmP(1);
        }

        private void BtnDerechaFrmP_Click(object sender, EventArgs e)
        {
            this.ColorDienteFrmP(2);
        }

        private void BtnAbajoFrmP_Click(object sender, EventArgs e)
        {
            this.ColorDienteFrmP(3);
        }

        private void BtnIzquierdaFrmP_Click(object sender, EventArgs e)
        {
            this.ColorDienteFrmP(4);
        }

        private void ChkMarcarTodoP_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.lblNroDienteP.Text == "0")
                {
                    throw new Exception("Seleccione Un Diente");
                }
                if (this.chkMarcarTodoP.Checked == true)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (this.imgDienteP[this.vectorP, i].BackColor.Name == this.colorTransparente ||
                            this.imgDienteP[this.vectorP, i].BackColor.Name != this.pColorP.BackColor.Name)
                        {
                           if (this.imgDienteP[this.vectorP, i].Enabled == true)
                            {                            
                                this.ColorDienteFrmP(i);
                            }
                            
                        }
                    }
                    this.chkMarcarTodoP.Checked = true;
                }
            }
            catch (Exception ex)
            {
                this.lblMensajeP.Text = ex.Message;
                this.chkMarcarTodoP.Checked = false;
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (this.lblNroDienteP.Text != "0")
            {
                this.UDienteP[vectorP].BackColor = Color.FromName(this.colorActivo);
            }
            this.tcOdontograma.SelectedIndex = 3;
            System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Pictures");
            //SaveFileDialog guardar = new SaveFileDialog();

            //Thread.Sleep(2000);
            Graphics gr = this.CreateGraphics();
            // Tamaño de lo que queremos copiar
            Size fSize= new Size();
            fSize.Width = 1050;
            fSize.Height = 320;
            // Creamos el bitmap con el área que vamos a capturar
            // En este caso, con el tamaño del formulario actual
            Bitmap bm = new Bitmap(fSize.Width, fSize.Height, gr);
            // Un objeto Graphics a partir del bitmap
            Graphics gr2 = Graphics.FromImage(bm);
            // Copiar el área de la pantalla que ocupa el formulario
            gr2.CopyFromScreen(300,110,0,0, fSize);
            //guardar.Filter = "Imagen | .png";
           
            bm.Save(Application.StartupPath+"\\Pictures\\odontograma.png", ImageFormat.Png);
            if (this.atencionImpresion)
            {
                this.enviarReporteAtencion(Convert.ToInt32(this.txtAtencionID.Text),Convert.ToInt32(this.labelIDO.Text),Convert.ToInt32(this.labelIDC.Text),this.empleado.usuarioID);
            }
            else
            {
                this.enviarReporte(Convert.ToInt32(this.txtIdO.Text));
            }
            
        }
        private void mostrarAtencion(int IDAtencion)
        {
            this.Controls.Remove(this.tablaDetalle);
            this.tablaDetalle = new DataGridView();
            this.limpiarUserControl();
            this.cargarDienteInicial();

            this.tablaDetalle.Visible = false;
            this.Controls.Add(this.tablaDetalle);
            this.tablaDetalle.DataSource = NAtencion_detalle.detalleAtencion(IDAtencion);

            this.colorearOdontogramaInicial();
            this.dataRegistro.AutoResizeColumns();
            this.txtAtencionID.Text = Convert.ToString(IDAtencion);
        }

        private void enviarReporte(int ID)
        {
            FrmReporteOdontograma frm = new FrmReporteOdontograma();
            NOdontograma NO = new NOdontograma();
            NPacientes P = new NPacientes();
            frm.DetalleID = ID;
            frm.NumeroLiteral = this.literalImporte.Text;
            frm.Odontograma.Add(NO.mostrarID(ID));
            frm.paciente.Add(P.mostraPacienteOdontograma(ID));
            frm.Show();
        }         
        
        private void limpiarDatosCliente()
        {
            this.txtClienteID.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtCI.Text = string.Empty;
            this.txtFechaNacimiento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtSexo.Text = string.Empty;
            this.txtEdad.Text = string.Empty;
            //this.dataClienteAtencion.Rows.Clear();
            //this.dataClienteOdon.Rows.Clear();
        } 
        private void limpiarDatosOdontologo()
        {
            this.txtOdontologoID.Text = string.Empty;
            this.txtNombreOdontologo.Text = string.Empty;
        }
        private void mostrarTodoCliente()
        {
            try
            {
                this.lblAtencionError.Visible = false;
                this.imgClienteError.Visible = false;
                if (this.txtClienteID.Text == string.Empty)
                {
                    throw new Exception("Seleccione Un Paciente");
                }
                this.mostrarDBCliente();
               
                this.lblAtencionError.Visible = false;
            }
            catch (Exception ex)
            {
                this.lblAtencionError.Text = ex.Message;
                this.lblAtencionError.Visible = true;

            }
        }
        private void mostrarDBCliente()
        {
            
            this.dataClienteOdon.DataSource = NOdontograma.mostrarCliente(Convert.ToInt32(this.txtClienteID.Text));
            this.dataClienteOdon.Columns["odontogramaID"].HeaderText = "ID";
            this.dataClienteOdon.Columns["Paciente"].Visible = false;
            this.dataClienteOdon.Columns["estado"].Visible = false;
            this.dataClienteOdon.Visible = true;

            this.dataClienteOdon.AutoResizeColumns();
            
        }

        private void sumarTotalP()
        {
            decimal suma = 0;
            decimal totalPaga = 0;
            for(int i=0; i<this.dataRegistro.RowCount; i++)
            {
                string precio = Convert.ToString(this.dataRegistro["precio", i].Value);
                if (precio != string.Empty && this.dataRegistro.Rows[i].Visible == true)
                {
                    suma = Convert.ToDecimal(precio) + suma;
                    if (Convert.ToString(this.dataRegistro["realizado", i].Value) == "SI")
                    {
                        totalPaga = Convert.ToDecimal(precio) + totalPaga;
                    }
                }
            }
            this.txtMonto.Text = Convert.ToString(suma);
            this.labelTotal.Text = Convert.ToString(totalPaga - Convert.ToDecimal(this.txtMontoDataAtencion.Text));
            if (this.txtAtencionID.Text != string.Empty)
            {
                EAtencion Ate = new EAtencion();
                NAtencion atencion = new NAtencion();
                Ate = atencion.mostrarAtencionID(Convert.ToInt32(this.txtAtencionID.Text));
                this.labelTotal.Text = Convert.ToString(Convert.ToDecimal(this.labelTotal.Text) + Convert.ToDecimal(Ate.importe));
            }
            
        }
        private void mostrarDataAtencion(int ID)
        {
            this.dataClienteAtencion.DataSource = NAtencion.mostrarOdontogramaAtencion(ID);
            this.dataClienteAtencion.Columns["atencionID"].HeaderText = "ID";
            this.dataClienteAtencion.Columns["fecha"].HeaderText = "Fecha";
            this.dataClienteAtencion.Columns["hora"].HeaderText = "Hora";
            this.dataClienteAtencion.Columns["importe"].HeaderText = "Importe";
            this.dataClienteAtencion.Columns["descripcion"].Visible=false;
            this.dataClienteAtencion.Columns["odontologoID"].Visible = false;
            this.dataClienteAtencion.Columns["empleadoID"].Visible = false;
            this.dataClienteAtencion.Columns["pacienteID"].Visible = false;
            this.dataClienteAtencion.Columns["Paciente"].Visible = false;
            this.dataClienteAtencion.Columns["Empleado"].Visible = false;
            this.dataClienteAtencion.Columns["Odontologo"].Visible = false;
            this.dataClienteAtencion.Columns["estado"].Visible = false;
            this.dataClienteAtencion.Columns["tipo"].Visible = false;
            this.dataClienteAtencion.Visible = true;
            this.dataClienteAtencion.AutoResizeColumns();
            this.montoTotalDataAtencion();
        }
        private void DataClienteOdon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int ID = Convert.ToInt32(this.dataClienteOdon.CurrentRow.Cells["odontogramaID"].Value);
                if (e.ColumnIndex == this.dataClienteOdon.Columns["informacion"].Index)
                {

                    this.mostrarOdontograma(ID, true);
                    this.literalImporte.Text = NConvertir.enletras(Convert.ToString(this.dataClienteOdon.CurrentRow.Cells["montoTotal"].Value));
                    this.panelOdontologoImpresion.Visible = false;
                    this.pRegistroP.Visible = false;
                    NPacientes cliente = new NPacientes();
                    this.pacienteObjetoImpresion(cliente.mostraPacienteOdontograma(ID));
                    this.atencionImpresion = false;
                    this.imprimir = true;
                }
                else
                {
                    if (e.ColumnIndex == this.dataClienteOdon.Columns["ver_atencion"].Index)
                    {
                        this.mostrarDataAtencion(ID);
                    }
                    else
                    { 
                            if (e.ColumnIndex == dataClienteOdon.Columns["tratamientoCliente"].Index)
                            {
                                if (Convert.ToString(this.dataClienteOdon["tratamiento", e.RowIndex].Value) == "CONTINUAR")
                                {
                                int num = Convert.ToInt32(this.dataClienteOdon.CurrentRow.Cells["odontogramaID"].Value);
                                this.btnContinuar.Visible = true;
                                this.btnActualizarAtencion.Visible = false;
                                this.btnGuardar.Enabled = false;
                                this.mostrarOdontograma(num, false);
                                this.mostrarDataAtencion(num);

                                this.tcOdontograma.SelectedIndex = 3;
                            }
                                else
                                {
                                    MessageBox.Show("EL TRATAMIENTO HA SIDO TERMINADO", "ODONTOGRAMA");
                                }
                            }
                    }
                }
            }

        }
       private void montoTotalDataAtencion()
        {
            decimal suma = 0;
            for(int i = 0; i < this.dataClienteAtencion.RowCount; i++)
            {
               
                    suma = Convert.ToDecimal(this.dataClienteAtencion["importe", i].Value) + suma;
                
            }
            this.txtMontoDataAtencion.Text = Convert.ToString(suma);
        }

        private void ChkCentroPSI_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (Convert.ToInt32(this.imgDiente[vectorP, 0].AccessibleName) != -1)
            {
                if (this.chkCentroPSI.Checked == true)
                {
                    this.imgDienteP[vectorP, 0].AccessibleName = "SI";
                }
                else
                {
                    this.imgDienteP[vectorP, 0].AccessibleName = "NO";
                    this.chkTodoSI.Checked = false;
                }
                this.dataRegistro["realizado", Convert.ToInt32(this.imgDiente[vectorP, 0].AccessibleName)].Value = this.imgDienteP[vectorP, 0].AccessibleName;
                this.cambiarRealizado(vectorP);
                this.cargarBotonesImg(vectorP);
                this.cargarImgBienProc(vectorP);
                
            }
        }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch(Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

            }
}

        private void ChkArribaPSI_CheckedChanged(object sender, EventArgs e)
        {
            try
            { 
                if (this.chkArribaPSI.Checked == true)
                {
                    this.imgDienteP[vectorP, 1].AccessibleName = "SI";
                }
                else
                {
                this.imgDienteP[vectorP, 1].AccessibleName = "NO";
                this.chkTodoSI.Checked = false;
                }
                this.dataRegistro["realizado", Convert.ToInt32(this.imgDiente[vectorP, 1].AccessibleName)].Value = this.imgDienteP[vectorP, 1].AccessibleName;
                this.cambiarRealizado(vectorP);
                this.cargarBotonesImg(vectorP);
                this.cargarImgBienProc(vectorP);
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch(Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

            }

}

        private void ChkDerechaPSI_CheckedChanged(object sender, EventArgs e)
        {
            try { 
            if (this.chkDerechaPSI.Checked == true)
            {
                this.imgDienteP[vectorP, 2].AccessibleName = "SI";
            }
            else
            {
                this.imgDienteP[vectorP, 2].AccessibleName = "NO";
                this.chkTodoSI.Checked = false;

            }
            this.dataRegistro["realizado", Convert.ToInt32(this.imgDiente[vectorP, 2].AccessibleName)].Value = this.imgDienteP[vectorP, 2].AccessibleName;
            this.cambiarRealizado(vectorP);
            this.cargarBotonesImg(vectorP);
            this.cargarImgBienProc(vectorP);
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch(Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

            }
}

        private void ChkAbajoPSI_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkAbajoPSI.Checked == true)
            {
                this.imgDienteP[vectorP, 3].AccessibleName = "SI";
            }
            else
            {
                this.imgDienteP[vectorP, 3].AccessibleName = "NO";
                this.chkTodoSI.Checked = false;
            }
            this.dataRegistro["realizado", Convert.ToInt32(this.imgDiente[vectorP, 3].AccessibleName)].Value = this.imgDienteP[vectorP, 3].AccessibleName;
            this.cambiarRealizado(vectorP);
            this.cargarBotonesImg(vectorP);
            this.cargarImgBienProc(vectorP);
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

            }
        }

        private void ChkIzquierdaPSI_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (this.chkIzquierdaPSI.Checked == true)
                {
                    this.imgDienteP[vectorP, 4].AccessibleName = "SI";
                }
                else
                {
                    this.imgDienteP[vectorP, 4].AccessibleName = "NO";
                    this.chkTodoSI.Checked = false;
                }
                this.dataRegistro["realizado", Convert.ToInt32(this.imgDiente[vectorP, 4].AccessibleName)].Value = this.imgDienteP[vectorP, 4].AccessibleName;
                this.cambiarRealizado(vectorP);
                this.cargarBotonesImg(vectorP);
                this.cargarImgBienProc(vectorP);
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch(Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

            }
        }
        private void cargarImgBienProc(int vec)
        {
            if (this.imgDienteP[vec, 0].Enabled == true)
            { 
                if (this.imgDienteP[vec, 0].AccessibleName == "SI")
                {
                    this.imgDienteP[vec, 0].Image = Properties.Resources.centroBien;
                }
                else
                {
                    this.imgDienteP[vec, 0].Image = Properties.Resources.centroRayado;
                }
            }


            if (this.imgDienteP[vec, 1].Enabled == true)
            {
                if (this.imgDienteP[vec, 1].AccessibleName == "SI")
                {
                    this.imgDienteP[vec, 1].Image = Properties.Resources.arribaBien;
                }
                else
                {
                    this.imgDienteP[vec, 1].Image = Properties.Resources.arribaRayado;
                }
            }
            if (this.imgDienteP[vec, 2].Enabled == true)
            {
                if (this.imgDienteP[vec, 2].AccessibleName == "SI")
                {
                    this.imgDienteP[vec, 2].Image = Properties.Resources.derechaBien;
                }
                else
                {
                    this.imgDienteP[vec, 2].Image = Properties.Resources.derechaRayado;
                }
            }
            if (this.imgDienteP[vec, 3].Enabled == true)
            {
                if (this.imgDienteP[vec, 3].AccessibleName == "SI")
                {
                    this.imgDienteP[vec, 3].Image = Properties.Resources.abajoBien;
                }
                else
                {
                    this.imgDienteP[vec, 3].Image = Properties.Resources.abajoRayado;
                }
            }
            if (this.imgDienteP[vec, 4].Enabled == true)
            {
                if (this.imgDienteP[vec, 4].AccessibleName == "SI")
                {
                    this.imgDienteP[vec, 4].Image = Properties.Resources.izquierdaBien;
                }
                else
                {
                    this.imgDienteP[vec, 4].Image = Properties.Resources.izquierdaRayado;
                }
            }
        }
        
        private void ChkTodoSI_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.lblNroDienteP.Text == "0")
                {
                    throw new Exception("Seleccione Un Diente");
                }
                if (this.chkTodoSI.Checked == true)
                {
                    int fila = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (this.imgDienteP[vectorP,i].BackColor.Name!=this.colorTransparente)
                        {
                            this.imgDienteP[vectorP, i].AccessibleName = "SI";
                            fila = Convert.ToInt32(this.imgDiente[vectorP, i].AccessibleName);
                            this.dataRegistro["realizado", fila].Value = "SI";
                        }
                    }
                    this.cambiarRealizado(vectorP);
                    this.cargarBotonesImg(vectorP);
                    this.cargarImgBienProc(vectorP);
                    this.chkTodoSI.Checked = true;
                }
            }
            catch (Exception ex)
            {
                this.lblMensajeP.Text = ex.Message;
                this.chkTodoSI.Checked =false;
            }           
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            Buscarusuario_NV = new FrmBuscarPaciente();
            Buscarusuario_NV.dataListado.CellContentClick += DataListadoCliente_CellMouseDoubleClick;
            Buscarusuario_NV.ShowDialog();
        }
        private void DataListadoCliente_CellMouseDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridView dgv = (DataGridView)sender;
                    int pacienteID = Convert.ToInt32(dgv["pacienteID", e.RowIndex].Value);
                    NPacientes nPacientes = new NPacientes();
                    this.pacienteObjetoDatos(nPacientes.mostraDatos(pacienteID));

                    this.Buscarusuario_NV.Close();
                    this.mostrarTodoCliente();
                }
            }
        }
        private void pacienteObjetoDatos(EPaciente paciente)
        {
            this.txtClienteID.Text = Convert.ToString(paciente.pacienteID);
            this.txtNombre.Text = paciente.nombre +" "+paciente.apellido;
            this.txtDireccion.Text = paciente.direccion;
            this.txtSexo.Text = paciente.sexo;
            this.txtFechaNacimiento.Value = Convert.ToDateTime(paciente.fechaNacimiento);
            this.txtTelefono.Text = paciente.telefono;
            this.txtCI.Text = paciente.ci;
            this.txtEdad.Text = Convert.ToString(DateTime.Now.Year - Convert.ToDateTime(txtFechaNacimiento.Value).Year);
        }
        private void pacienteObjetoImpresion(EPaciente paciente)
        {
            this.tcOdontograma.SelectedIndex = 3;
            this.pRegistroP.Visible = false;
            this.panelClienteImprimesion.Visible = true;
            this.panelImpresion.Visible = true;
            this.labelIDC.Text = Convert.ToString(paciente.pacienteID);
            this.labelNombreC.Text = paciente.nombre;
            this.labelApellidoC.Text = paciente.apellido;
            this.labelDireccionC.Text = paciente.direccion;
            this.labelSexoC.Text = paciente.sexo;
            this.labelFechaC.Text = Convert.ToString(paciente.fechaNacimiento);
            this.labelTelefonoC.Text = paciente.telefono;
            this.labelCIC.Text = paciente.ci;
            this.labelEdadC.Text = Convert.ToString(DateTime.Now.Year - paciente.fechaNacimiento.Value.Year)+" AÑOS";
        }
        private void odontologoObjetoImpresion(EUsers odontologo)
        {
            this.panelOdontologoImpresion.Visible = true;
            this.labelIDO.Text = Convert.ToString(odontologo.usuarioID);
            this.labelNombreO.Text = odontologo.nombre;
            this.labelApellidoO.Text = odontologo.apellido;
        }
        private void odontologObjeto(EUsers odontologo)
        {
            this.txtOdontologoID.Text = Convert.ToString(odontologo.usuarioID);
            this.txtNombreOdontologo.Text = odontologo.nombre+" "+ odontologo.apellido;
        }

        private void BtnBuscarOdontologo_Click(object sender, EventArgs e)
        {
            FrmOdontologo = new FrmBuscarOdontologo();
            FrmOdontologo.dataListado.CellContentClick += DataListadoOdontologo_CellMouseDoubleClick;
            FrmOdontologo.ShowDialog();
        }
        private void DataListadoOdontologo_CellMouseDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridView dgv = (DataGridView)sender;
                    this.txtOdontologoID.Text = Convert.ToString(dgv["usuarioID", e.RowIndex].Value);
                    EUsers odontologo = new EUsers();
                    NUsers user = new NUsers();
                    odontologo = user.mostrarUserID(Convert.ToInt32(this.txtOdontologoID.Text));
                    //this.txtOdontologoID.Text = Convert.ToString(odontologo.usuarioID);
                    this.txtNombreOdontologo.Text = odontologo.nombre + " " + odontologo.apellido;
                    this.imgOdontologoError.Visible = false;
                    FrmOdontologo.Close();
                }
            }
        }

        private void BtnSumarTotal_Click(object sender, EventArgs e)
        {
            this.sumarTotalP();
            this.labelMontoTotalLiteral.Text = NConvertir.enletras(this.txtMonto.Text);
        }
        private void botonEditar()
        {
            this.btnGuardar.Enabled = false;
            this.btnContinuar.Visible = false;
            this.btnActualizarAtencion.Visible = true;
            this.imprimir = false;
        }

        private void DataClienteAtencion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                if (e.ColumnIndex == dataClienteAtencion.Columns["detalle"].Index)
                {
                    int atencionID = Convert.ToInt32(this.dataClienteAtencion.CurrentRow.Cells["atencionID"].Value);
                    int odontologoID = Convert.ToInt32(this.dataClienteAtencion.CurrentRow.Cells["odontologoID"].Value);
                    int pacienteID = Convert.ToInt32(this.dataClienteAtencion.CurrentRow.Cells["pacienteID"].Value);
                    int IDO = NOdontograma.mostrarAtencionID(atencionID);
                    this.literalImporte.Text = NConvertir.enletras(Convert.ToString(this.dataClienteAtencion.CurrentRow.Cells["importe"].Value));
                    this.mostrarAtencion(atencionID);
                    this.panelOdontologoImpresion.Visible = false;
                    this.pRegistroP.Visible = false;
                    NPacientes cliente = new NPacientes();
                    NUsers user= new NUsers();
                    this.pacienteObjetoImpresion(cliente.mostraDatos(pacienteID));
                    this.odontologoObjetoImpresion(user.mostrarUserID(odontologoID));
                    this.atencionImpresion = true;
                    this.txtIdO.Text = Convert.ToString(IDO);
                    this.imprimir = true;

                }
                else
                {
                    if (e.ColumnIndex == dataClienteAtencion.Columns["editar"].Index)
                    {
                        int num = Convert.ToInt32(this.dataClienteAtencion.CurrentRow.Cells["atencionID"].Value);
                        int odontologoID = Convert.ToInt32(this.dataClienteAtencion.CurrentRow.Cells["odontologoID"].Value);
                        NUsers users = new NUsers();
                        this.txtImporte.Text = Convert.ToString(this.dataClienteAtencion["importe", e.RowIndex].Value);
                        this.odontologObjeto(users.mostrarUserID(odontologoID));
                        this.txtAtencionID.Text = Convert.ToString(num);
                        int IDO = NOdontograma.mostrarAtencionID(num);
                        NPacientes cliente = new NPacientes();
                        this.pacienteObjetoDatos(cliente.mostraPacienteOdontograma(IDO));
                        this.mostrarOdontograma(IDO,true);
                        this.panelImpresion.Visible = false;
                        this.pRegistroP.Visible = true;
                        this.pDienteProc.Visible = true;
                        this.tcOdontograma.SelectedIndex = 2;
                        this.botonEditar();                        
                    }

                }
                
            }
        }
        private void enviarReporteAtencion(int IDAtencion, int IDOdontologo, int IDPaciente, int IDEmpleado)
        {
            FrmReporteAtencionOdontograma frm = new FrmReporteAtencionOdontograma();
            NOdontograma NO = new NOdontograma();
            NPacientes P = new NPacientes();
            NUsers usuario = new NUsers();
            frm.IDAtencion = IDAtencion;
            frm.NumeroLiteral = this.literalImporte.Text;
            frm.odontologo.Add(usuario.mostrarUserID(IDOdontologo));
            frm.paciente.Add(P.mostraDatos(IDPaciente));
            frm.empleado.Add(usuario.mostrarUserID(IDEmpleado));
            frm.Show();
        }

        private void TxtAbono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.labelImporteLiteral.Text = NConvertir.enletras(this.txtImporte.Text);
            }
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == Convert.ToChar(",") || e.KeyChar == Convert.ToChar("\b"))
            {
                this.imgPrecioC.Visible = false;
               
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void BtnIncio_Click(object sender, EventArgs e)
        {
            this.siguientePag = 0;
            this.MostrarDB();
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            this.siguientePag--;
            this.MostrarDB();
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            this.siguientePag++;
            this.MostrarDB();
        }

        private void BtnFin_Click(object sender, EventArgs e)
        {
            this.siguientePag = NOdontograma.mostrarTotal(this.txtBuscarN.Text,this.txtBuscarA.Text) / 10;
            this.MostrarDB();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.botonesGuardar(false);
            this.limpiezaTotal();
        }

        private void TcOdontograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lblNroDiente.Text != "0")
            {
                this.UDiente[vector].BackColor = Color.FromName(this.colorTransparente);

                this.btnCentroFrm.Image = Properties.Resources.central;
                this.btnArribaFrm.Image = Properties.Resources.arriba;
                this.btnDerechaFrm.Image = Properties.Resources.derecha;
                this.btnAbajoFrm.Image = Properties.Resources.abajo;
                this.btnIzquierdaFrm.Image = Properties.Resources.izquierda;
            }
            if (this.lblNroDienteP.Text != "0")
            {
                this.btnCentroFrmP.Image = Properties.Resources.central;            
                this.btnArribaFrmP.Image = Properties.Resources.arriba;
                this.btnDerechaFrmP.Image = Properties.Resources.derecha;            
                this.btnAbajoFrmP.Image = Properties.Resources.abajo;         
                this.btnIzquierdaFrmP.Image = Properties.Resources.izquierda;
            
                this.UDienteP[vectorP].BackColor = Color.FromName(this.colorActivo);
            }
            this.limpiarIndex();
        }

        private void BtnActualizarAtencion_Click(object sender, EventArgs e)
        {
            try
            {
                this.validarGuardar();

                EOdontograma O = new EOdontograma();
                O.odontogramaID = Convert.ToInt32(this.txtIdO.Text);
                O.montoTotal = Convert.ToDecimal(this.txtMonto.Text);

                EAtencion atencion = new EAtencion();
                atencion.atencionID = Convert.ToInt32(this.txtAtencionID.Text);
                atencion.importe = Convert.ToDecimal(this.txtImporte.Text);
                atencion.descripcion = this.txtDescripcionC.Text;
                EUsers odontologo = new EUsers();

                if (empleado.tipo == "ODONTOLOGO")
                {
                    odontologo = empleado;
                }
                else
                {
                    odontologo.usuarioID = Convert.ToInt32(txtOdontologoID.Text);
                }
                NPacientes npaciente = new NPacientes();
                EPaciente epaciente = new EPaciente();
                epaciente = npaciente.mostraDatos(Convert.ToInt32(this.txtClienteID.Text));

                DataTable dtDetalle = new DataTable("odontograma_detalle");
                dtDetalle.Columns.Add("dienteID", System.Type.GetType("System.Int32"));
                dtDetalle.Columns.Add("parteID", System.Type.GetType("System.Int32"));
                dtDetalle.Columns.Add("diagnosticoID", System.Type.GetType("System.Int32"));
                dtDetalle.Columns.Add("procedimientoID", System.Type.GetType("System.Int32"));
                dtDetalle.Columns.Add("realizado", System.Type.GetType("System.String"));
                int terminar = 0;
                for (int i = 0; i < this.dataRegistro.RowCount; i++)
                {
                    if (this.dataRegistro.Rows[i].Visible == true)
                    {
                        DataRow row = dtDetalle.NewRow();
                        row["dienteID"] = Convert.ToInt32(this.dataRegistro["dienteID", i].Value);
                        row["parteID"] = Convert.ToInt32(this.dataRegistro["parteID", i].Value);
                        row["diagnosticoID"] = Convert.ToInt32(this.dataRegistro["diagnosticoID", i].Value);
                        row["procedimientoID"] = Convert.ToInt32(this.dataRegistro["procedimientoID", i].Value);
                        row["realizado"] = Convert.ToString(this.dataRegistro["realizado", i].Value);
                        if (Convert.ToString(this.dataRegistro["realizado", i].Value) == "NO")
                        {
                            terminar++;
                        }
                        dtDetalle.Rows.Add(row);
                    }
                }

                if (terminar == 0)
                {
                    O.tratamiento = "TERMINADO";
                }
                else
                {
                    O.tratamiento = "CONTINUAR";
                }

                this.atencionIDMostrar = Convert.ToInt32(NOdontograma.updateAtencion(O, dtDetalle, atencion, epaciente, odontologo, empleado));
                this.literalImporte.Text = NConvertir.enletras(this.txtImporte.Text);
                this.pacienteObjetoImpresion(epaciente);
                this.txtAtencionID.Text = Convert.ToString(atencionIDMostrar);
                this.odontologoObjetoImpresion(odontologo);
                this.mostrarAtencion(this.atencionIDMostrar);

                this.atencionImpresion = true;
                this.tcOdontograma.SelectedIndex = 3;
                this.atencionImpresion = true;
                this.imprimir = true;
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
                this.lblMensaje.Visible = true;
            }
        }

        private void TxtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.labelMontoTotalLiteral.Text = NConvertir.enletras(this.txtMonto.Text);
            }
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == Convert.ToChar(",") || e.KeyChar == Convert.ToChar("\b"))
            {
                e.Handled = false;
            }
        }
    }
}
