using CapaEntity;
using CapaNegocio;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmDiente : Form
    {
        public FrmDiente()
        {
            InitializeComponent();

            this.MostrarDB();
        }
        private int siguientePag = 0;

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validacionImgError())
                {
                    this.convertir();
                    EDiente Obj = new EDiente();
                    Obj.dienteID = Convert.ToInt32(this.txtId.Text);
                    Obj.nombre = this.txtNombre.Text.Trim();
                    NDiente.save(Obj);
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
                MessageBox.Show(ex.Message, "Sistema de Odontograma Guardar");
            }

        }

        private void FrmDiente_Load(object sender, EventArgs e)
        {
            this.MostrarDB();
        }
        private void MensajeOk(String mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MostrarDB()
        {
            
            this.dataListado.DataSource = NDiente.mostrar(this.txtBuscar.Text,siguientePag);
            this.ordenarColumnas();
            this.dataListado.AutoResizeColumns();
            int dataTotal = NDiente.mostrarTotal(this.txtBuscar.Text)/10;
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

            this.lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void ordenarColumnas()
        {
            this.dataListado.Columns["dienteID"].DisplayIndex = 0;
            this.dataListado.Columns["dienteID"].HeaderText = "id";
            this.dataListado.Columns["nombre"].DisplayIndex = 1;
            this.dataListado.Columns["nombre"].HeaderText = "Nombre";

            this.dataListado.Columns["Editar"].DisplayIndex = 2;
            //this.dataListado.Columns["Odontograma_detalle"].Visible = false;
        }

        private void DataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {         
            if (e.ColumnIndex == dataListado.Columns["Editar"].Index)
            {
                this.LimpiarImgError();
                this.txtId.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["dienteID"].Value);
                this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);

                this.OcultarPRegistro(false, false);
                this.lbModificar.Visible = true;
                this.lbNuevo.Visible = false;
            }
        }

        private void LimpiarPRegistro()
        {
            this.LimpiarImgError();
            this.txtId.Text = string.Empty;
            this.txtNombre.Text = string.Empty;

            this.btnGuardar.Visible = true;
            this.btnActualizar.Visible = false;
        }

        private void convertir()
        {
            while (this.txtNombre.Text.Contains("  "))
            {
                this.txtNombre.Text = this.txtNombre.Text.Trim().Replace("  ", " ");
            }
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
            this.lbNuevo.Visible = true;

        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validacionImgError())
                {
                    this.convertir();
                    EDiente Obj = new EDiente();
                    Obj.dienteID = Convert.ToInt32(this.txtId.Text);
                    Obj.nombre = this.txtNombre.Text.Trim();
                    NDiente.update(Obj);
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
                MessageBox.Show(ex.Message, "Sistema Odontograma");
            }

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
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

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.siguientePag = 0;
            this.MostrarDB();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarPRegistro();
        }

        private void TxtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.imgID.Visible = false;
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.imgNombre.Visible = false;
        }
        private bool validacionImgError()
        {
            bool sw = true;
            if (this.txtId.Text == string.Empty)
            {
                this.imgID.Visible = true;
                sw = false;
            }
            if (this.txtNombre.Text == string.Empty)
            {
                this.imgNombre.Visible = true;
                sw = false;
            }

            return sw;
        }
        private void LimpiarImgError()
        {
            this.imgNombre.Visible = false;
            this.imgID.Visible = false;
        }

        private void BtnImprimri_Click(object sender, EventArgs e)
        {
            //FrmReporteDiente frm = new FrmReporteDiente();
            //frm.ShowDialog();
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            this.siguientePag++;
            this.MostrarDB();
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {            
                this.siguientePag--;
                this.MostrarDB();
        }

        private void BtnIncio_Click(object sender, EventArgs e)
        {
            this.siguientePag = 0;
            this.MostrarDB();
        }

        private void BtnFin_Click(object sender, EventArgs e)
        {
            this.siguientePag = NDiente.mostrarTotal(this.txtBuscar.Text)/10;
            this.MostrarDB();
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
