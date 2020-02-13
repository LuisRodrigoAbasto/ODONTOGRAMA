using CapaEntity;
using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class FrmAtencion : Form
    {
        private FrmBuscarPaciente Buscarusuario_NV;
       private FrmBuscarOdontologo BuscarOdontologo_NV;

        EUsers empleado;

      //  public int empleadoID = 0;
      //  public string nombreEmpleado = "";
       

        public FrmAtencion(EUsers users)
        {
            InitializeComponent();

            this.MostrarDB();
            
          //  this.llenarComboUsuario();
           empleado = users;
         
        }
        private int siguientePag = 0;

        private string tipo = "";

        private void FrmCita_Load(object sender, EventArgs e)
        {
            this.MostrarDB();
            this.txtEmpleado.Text = empleado.nombre +' '+ empleado.apellido;
            
        }

        private void MensajeOk(String mensaje)
        {
            MessageBox.Show(mensaje, "Odontograma", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Odontograma", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MostrarDB()
        {
            this.dataListado.DataSource = NAtencion.mostrar(this.siguientePag);
            this.ordenarColumnas();
            this.dataListado.AutoResizeColumns();
            int dataTotal = NAtencion.mostrarTotal() / 5;
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

            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void ordenarColumnas()
        {
            this.dataListado.Columns["atencionID"].DisplayIndex = 0;
            this.dataListado.Columns["atencionID"].HeaderText = "ID";
            this.dataListado.Columns["fecha"].DisplayIndex = 1;
            this.dataListado.Columns["fecha"].HeaderText = "Fecha";
            this.dataListado.Columns["hora"].DisplayIndex = 2;
            this.dataListado.Columns["hora"].HeaderText = "Hora";
            this.dataListado.Columns["importe"].DisplayIndex = 3;
            this.dataListado.Columns["importe"].HeaderText = "Importe";
            this.dataListado.Columns["Paciente"].DisplayIndex = 4;
            this.dataListado.Columns["Odontologo"].DisplayIndex = 5;
            this.dataListado.Columns["Empleado"].DisplayIndex = 6;
            this.dataListado.Columns["tipo"].DisplayIndex = 7;
            this.dataListado.Columns["tipo"].HeaderText = "Tipo";
            this.dataListado.Columns["descripcion"].DisplayIndex = 8;
            this.dataListado.Columns["descripcion"].HeaderText = "Descripcion";

            this.dataListado.Columns["Editar"].DisplayIndex = 9;
            this.dataListado.Columns["Eliminar"].DisplayIndex =10;
            this.dataListado.Columns["estado"].Visible = false;
            this.dataListado.Columns["pacienteID"].Visible = false;
            this.dataListado.Columns["odontologoID"].Visible = false;
            this.dataListado.Columns["empleadoID"].Visible = false;
        }

        private void DataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea Eliminar El Registro", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {

                    string Codigo;
                    string Rpta = "";

                    Codigo = Convert.ToString(this.dataListado.CurrentRow.Cells["atencionID"].Value);
                    EAtencion Obj = new EAtencion();
                    Obj.atencionID = Convert.ToInt32(Codigo);
                    Rpta = Convert.ToString(NAtencion.delete(Obj));
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
           
                if (e.ColumnIndex == dataListado.Columns["Editar"].Index)
                {
                    this.LimpiarPRegistro();
                    this.txtId.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["atencionID"].Value);
                    this.txtidpaciente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["pacienteID"].Value);
                    this.txtIdOdontologo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["odontologoID"].Value);
                this.txtpaciente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["paciente"].Value);
                this.txtOdontologo.Text= Convert.ToString(this.dataListado.CurrentRow.Cells["odontologo"].Value);
                this.txtEmpleado.Text= Convert.ToString(this.dataListado.CurrentRow.Cells["empleado"].Value);
                    this.txtHora.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["hora"].Value);
                                
                   this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);
                    this.txtImporte.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["importe"].Value);
                    this.tipo = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo"].Value);
                if (this.tipo == "consulta")
                {
                    this.chConsulta.Checked = true;
                }
                else
                {
                    this.chTratamiento.Checked = true;
                }

                ///LOCA


                this.OcultarPRegistro(false, false);
                    this.lbModificar.Visible = true;
                    this.lbAgregar.Visible = false;

                this.txtidpaciente.Visible = false;
                this.txtIdOdontologo.Visible = false;


            }

            if (e.ColumnIndex == dataListado.Columns["imprimir"].Index)
            {
               

            }
        }

        private void LimpiarPRegistro()
        {
            this.txtId.Text = string.Empty;
            this.txtpaciente.Text = string.Empty;
            this.txtOdontologo.Text = string.Empty;
            this.txtHora.Text = string.Empty;
            this.txtImporte.Text = string.Empty;
            this.chConsulta.Checked = false;
            this.chTratamiento.Checked = false;
            this.tipo = string.Empty;
            this.txtDescripcion.Text = string.Empty;

            this.btnGuardar.Visible = true;
            this.btnActualizar.Visible = false;
            this.LimpiarImgError();
        }

        private void LimpiarImgError()
        {
            this.imgPaciente.Visible = false;
            this.imgAgenda.Visible = false;
            this.imgTipo.Visible = false;

        }

        private void convertir()
        {
            while (this.txtDescripcion.Text.Contains("  "))
            {
                this.txtDescripcion.Text = this.txtDescripcion.Text.Trim().Replace("  ", " ");
            }

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validacionImgError())
                {
                    this.convertir();
                    EAtencion Obj = new EAtencion();

                    Obj.pacienteID = Convert.ToInt32(this.txtidpaciente.Text);
                    Obj.odontologoID = Convert.ToInt32(this.txtIdOdontologo.Text);
                    Obj.empleadoID = empleado.usuarioID;
                 
                    Obj.hora = this.txtHora.Value.TimeOfDay;
                    Obj.importe = Convert.ToDecimal(this.txtImporte.Text);
                    Obj.descripcion = this.txtDescripcion.Text.Trim();
                    Obj.tipo = this.tipo;

                    NAtencion.save(Obj);
                    this.LimpiarPRegistro();
                    this.MostrarDB();
                }
                else
                {
                    throw new Exception("Datos Obligatorios");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema de Registro");
            }
        }

        private bool validacionImgError()
        {
            bool sw = true;
            if (this.txtpaciente.Text == string.Empty)
            {
                this.imgPaciente.Visible = true;
                sw = false;
            }
            if (this.txtOdontologo.Text == string.Empty)
            {
                this.imgAgenda.Visible = true;
                sw = false;
            }
            if (this.txtImporte.Text == string.Empty)
            {
                this.imgImporte.Visible = true;
                sw = false;
            }
            if (this.tipo == "")
           {
                this.imgTipo.Visible = true;
                sw = false;
            }

            return sw;
        }

        private void OcultarPRegistro(bool cerrar, bool nuevo)
        {
            if (cerrar)
            {
                this.pRegistro.Visible = false;
                this.pListado.Location = new Point(15, 12);
                this.btnNuevo.Enabled = true;
            }
            else
            {
                this.pRegistro.Visible = true;
                this.pListado.Location = new Point(310, 12);
                this.btnNuevo.Enabled = false;
            }
            if (nuevo)
            {
                this.btnGuardar.Visible = true;
                this.btnActualizar.Visible = false;
            }
            else
            {
                this.btnGuardar.Visible = false;
                this.btnActualizar.Visible = true;
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.OcultarPRegistro(false, true);
            this.LimpiarPRegistro();

            this.lbModificar.Visible = false;
            this.lbAgregar.Visible = true;

            this.txtidpaciente.Visible = false;
            this.txtIdOdontologo.Visible = false;

        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validacionImgError())
                {
                    this.convertir();
                    EAtencion Obj = new EAtencion();
                    Obj.atencionID = Convert.ToInt32(this.txtId.Text);
                    Obj.pacienteID = Convert.ToInt32(this.txtidpaciente.Text);
                    Obj.odontologoID = Convert.ToInt32(this.txtIdOdontologo.Text);
                    Obj.empleadoID = empleado.usuarioID;

                    Obj.hora = this.txtHora.Value.TimeOfDay;
                    Obj.importe = Convert.ToDecimal(this.txtImporte.Text);
                    Obj.descripcion = this.txtDescripcion.Text.Trim();
                    Obj.tipo = this.tipo;
                    NAtencion.update(Obj);
                    this.MostrarDB();
                    this.LimpiarPRegistro();
                }
                else
                {
                    throw new Exception("Datos Obligatorios");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema Odontograma");
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.siguientePag = 0;
            this.MostrarDB();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.OcultarPRegistro(true, true);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.OcultarPRegistro(true, true);
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarPRegistro();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.MostrarDB();
        }

       


    /*    private void llenarComboUsuario()

        {
            this.cbmUsuario.DropDownList.Columns.Clear();
            this.cbmUsuario.DropDownList.Columns.Add("usuarioID").Width = 50;
            this.cbmUsuario.DropDownList.Columns.Add("nombre").Width = 100;
            this.cbmUsuario.DropDownList.Columns.Add("apellido").Width = 100;
            this.cbmUsuario.DropDownList.Columns.Add("tipo").Width = 100;
            this.cbmUsuario.DropDownList.Columns["usuarioID"].Caption = "ID";
            this.cbmUsuario.DropDownList.Columns["nombre"].Caption = "Nombre";
            this.cbmUsuario.DropDownList.Columns["apellido"].Caption = "Apellido";
            this.cbmUsuario.DropDownList.Columns["tipo"].Caption = "Tipo";
            this.cbmUsuario.DisplayMember = "nombre";
            this.cbmUsuario.ValueMember = "usuarioID";

            this.cbmUsuario.DataSource = NUsers.mostrar(this.cbmUsuario.Text);
            this.cbmUsuario.Refresh();
        }*/

        private void BtnExPaciente_Click(object sender, EventArgs e)
        {
            Buscarusuario_NV = new FrmBuscarPaciente();
            Buscarusuario_NV.dataListado.CellContentClick += DataListado_CellMouseDoubleClick;
            Buscarusuario_NV.ShowDialog();


        }
       

        private void DataListado_CellMouseDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                    txtidpaciente.Text = dgv[0, e.RowIndex].Value.ToString().Trim();
                    txtpaciente.Text = dgv[1, e.RowIndex].Value.ToString().Trim() + " " + dgv[2, e.RowIndex].Value.ToString().Trim();

                    Buscarusuario_NV.Close();
                }
            }

        }

       

        private void BntImprimir_Click(object sender, EventArgs e)
        {          
        }

        private void BtnSelecOdontologo_Click(object sender, EventArgs e)
        {

            BuscarOdontologo_NV = new FrmBuscarOdontologo();
            BuscarOdontologo_NV.dataListado.CellContentClick += DataListadoOdontologo_CellMouseDoubleClick;
            BuscarOdontologo_NV.ShowDialog();
        }

        private void DataListadoOdontologo_CellMouseDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                    txtIdOdontologo.Text = dgv[0, e.RowIndex].Value.ToString().Trim();
                    txtOdontologo.Text = dgv[1, e.RowIndex].Value.ToString().Trim() + " " + dgv[2, e.RowIndex].Value.ToString().Trim();

                    BuscarOdontologo_NV.Close();
                }
            }
        }

        private void BtnIncio_Click(object sender, EventArgs e)
        {
            this.siguientePag = 0;
            this.MostrarDB();
        }

        private void BtnFin_Click(object sender, EventArgs e)
        {
            this.siguientePag = NAtencion.mostrarTotal() / 10;
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

        private void ChConsulta_Click(object sender, EventArgs e)
        {
            this.chConsulta.Checked = true;
            this.chTratamiento.Checked = false;
            this.tipo = "consulta";
            this.imgTipo.Visible = false;
        }

        private void ChTratamiento_Click(object sender, EventArgs e)
        {
            this.chConsulta.Checked = false;
            this.chTratamiento.Checked = true;
            this.tipo = "tratamiento";
            this.imgTipo.Visible = false;
        }

        private void BtnImprimirR_Click(object sender, EventArgs e)
        {
            FrmReporteAtencionRango frm = new FrmReporteAtencionRango();
            frm.fecha1 = this.txtFechaInicio.Value;
            frm.fecha2 = this.txtFechaFinal.Value;
            frm.ShowDialog();

        }

        private void TxtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar==Convert.ToChar(",") || e.KeyChar == Convert.ToChar("\b"))
            {
                this.lbErrorMessagge.Visible = false;
                this.labMensaje.Visible = false;
                e.Handled = false;


                e.Handled = false;
            }
            else {
                this.lbErrorMessagge.Visible = true;
                this.labMensaje.Visible = true;

                e.Handled=true;
            }            
        }
    }
}
