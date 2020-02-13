using CapaEntity;
using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace CapaPresentacion
{
    public partial class FrmParte : Form
    {
        public FrmParte()
        {
            InitializeComponent();
        }

        private void FrmTipo_Load(object sender, EventArgs e)
        {
            this.MostrarDB();
        }
        private void MostrarDB()
        {
            this.dataListado.DataSource = NParte.mostrar(this.txtBuscar.Text);
            //this.dataListado.AutoResizeRows();
            this.ordenarColumnas();
            this.dataListado.AutoResizeColumns();

            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void ordenarColumnas()
        {
            this.dataListado.Columns["parteID"].DisplayIndex = 0;
            this.dataListado.Columns["parteID"].HeaderText = "id";
            this.dataListado.Columns["nombre"].DisplayIndex = 1;
            this.dataListado.Columns["nombre"].HeaderText = "Nombre";


            this.dataListado.Columns["Editar"].DisplayIndex = 2;
            this.dataListado.Columns["Eliminar"].DisplayIndex = 3;
            //this.dataListado.Columns["Odontograma_detalle"].Visible = false;
        }


        private void MensajeOk(String mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void LimpiarPRegistro()
        {
            this.txtId.Text = string.Empty;
            this.txtNombre.Text = string.Empty;

            this.btnGuardar.Visible = true;
            this.btnActualizar.Visible = false;
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

                    Codigo = Convert.ToString(this.dataListado.CurrentRow.Cells["parteID"].Value);
                    EParte Obj = new EParte();
                    Obj.parteID = Convert.ToInt32(Codigo);
                    Rpta = Convert.ToString(NParte.delete(Obj));
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
                if (e.ColumnIndex == dataListado.Columns["Editar"].Index)
                {
                    this.txtId.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["parteID"].Value);
                    this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);


                    this.OcultarPRegistro(false, false);
                    this.lbModificar.Visible = true;
                    this.lbAgregar.Visible = false;

                }
            }
        }

        private void convertir()
        {
            while (this.txtNombre.Text.Contains("  "))
            {
                this.txtNombre.Text = this.txtNombre.Text.Trim().Replace("  ", " ");
            }

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.convertir();

                EParte Obj = new EParte();
                Obj.nombre = this.txtNombre.Text.Trim();

                NParte.save(Obj);
                this.LimpiarPRegistro();
                this.MostrarDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema de Odontograma Guardar");
            }

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.OcultarPRegistro(false, true);
            this.LimpiarPRegistro();
            this.lbModificar.Visible = false;
            this.lbAgregar.Visible = true;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validacionImgError())
                {
                    this.convertir();

                    EParte Obj = new EParte();
                    Obj.parteID = Convert.ToInt32(this.txtId.Text);
                    Obj.nombre = this.txtNombre.Text.Trim();

                    NParte.update(Obj);
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.OcultarPRegistro(true, true);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.OcultarPRegistro(true, true);
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarPRegistro();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.MostrarDB();
        }
        private bool validacionImgError()
        {
            bool sw = true;

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
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.imgNombre.Visible = false;
        }
    }
}
