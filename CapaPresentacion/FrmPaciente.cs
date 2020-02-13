using CapaEntity;
using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class FrmPaciente : Form
    {
        public FrmPaciente()
        {
            InitializeComponent();
            this.MostrarDB();
        }
        private int siguientePag = 0;

        private string sexo = "";
       
        private void FrmPaciente_Load(object sender, EventArgs e)
        {
            this.MostrarDB();
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
            this.dataListado.DataSource = NPacientes.mostrar(this.txtBuscarNombre.Text, this.txtBuscarApellido.Text,siguientePag);
            this.ordenarColumnas();
            this.dataListado.AutoResizeColumns();
            int dataTotal = NPacientes.mostrarTotal(this.txtBuscarNombre.Text, this.txtBuscarApellido.Text) / 10;
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
            this.dataListado.Columns["pacienteID"].DisplayIndex = 0;
            this.dataListado.Columns["pacienteID"].HeaderText = "id";
            this.dataListado.Columns["nombre"].DisplayIndex = 1;
            this.dataListado.Columns["nombre"].HeaderText = "Nombre";
            this.dataListado.Columns["apellido"].DisplayIndex = 2;
            this.dataListado.Columns["apellido"].HeaderText = "Apellido";
            this.dataListado.Columns["telefono"].DisplayIndex = 3;
            this.dataListado.Columns["telefono"].HeaderText = "Telefono";
            this.dataListado.Columns["ci"].DisplayIndex = 4;
            this.dataListado.Columns["ci"].HeaderText = "CI";
            this.dataListado.Columns["fechaNacimiento"].DisplayIndex = 5;
            this.dataListado.Columns["fechaNacimiento"].HeaderText = "Fecha_Nacimiento";
            this.dataListado.Columns["direccion"].DisplayIndex = 6;
            this.dataListado.Columns["direccion"].HeaderText = "Direccion";
            this.dataListado.Columns["sexo"].DisplayIndex = 7;
            this.dataListado.Columns["sexo"].HeaderText = "Sexo";
            this.dataListado.Columns["Editar"].DisplayIndex = 8;
            this.dataListado.Columns["Eliminar"].DisplayIndex = 9;
            this.dataListado.Columns["estado"].Visible = false;
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

                    Codigo = Convert.ToString(this.dataListado.CurrentRow.Cells["pacienteID"].Value);
                    EPaciente Obj = new EPaciente();
                    Obj.pacienteID = Convert.ToInt32(Codigo);
                    Rpta = Convert.ToString(NPacientes.delete(Obj));
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
                    this.LimpiarPRegistro();
                    this.txtId.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["pacienteID"].Value);
                    this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
                    this.txtApellido.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellido"].Value);
                    this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
                    this.txtCI.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ci"].Value);
                    this.txtFecha.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["fechaNacimiento"].Value);
                    this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
                    this.sexo = Convert.ToString(this.dataListado.CurrentRow.Cells["sexo"].Value);

                    if (this.sexo == "Masculino")
                    {
                        this.txtM.Checked = true;
                    }
                    else
                    {
                        this.txtF.Checked = true;
                    }

                    this.OcultarPRegistro(false, false);
                    this.lbModificar.Visible = true;
                    this.lbAgregar.Visible = false;

                }
            }
        }
        private void LimpiarPRegistro()
        {
            this.txtId.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtCI.Text = string.Empty;
            this.txtFecha.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtF.Checked = false;
            this.txtM.Checked = false;
            this.sexo = string.Empty;
            this.btnGuardar.Visible = true;
            this.btnActualizar.Visible = false;
            this.LimpiarImgError();
        }
        private void LimpiarImgError()
        {
            this.imgNombre.Visible = false;
            this.imgApellido.Visible = false;
            this.imgSexo.Visible = false;
        }
        private void convertir()
        {
            while (this.txtNombre.Text.Contains("  "))
            {
                this.txtNombre.Text = this.txtNombre.Text.Trim().Replace("  ", " ");
            }
            while (this.txtApellido.Text.Contains("  "))
            {
                this.txtApellido.Text = this.txtApellido.Text.Trim().Replace("  ", " ");
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validacionImgError())
                {
                    this.convertir();
                    EPaciente Obj = new EPaciente();
                    Obj.nombre = this.txtNombre.Text.Trim();
                    Obj.apellido = this.txtApellido.Text.Trim();
                    Obj.telefono = this.txtTelefono.Text.Trim();
                    Obj.ci = this.txtCI.Text.Trim();
                    Obj.fechaNacimiento = Convert.ToDateTime(this.txtFecha.Text);
                    Obj.direccion = this.txtDireccion.Text.Trim();
                    Obj.sexo = this.sexo;
                    NPacientes.save(Obj);
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
            if (this.txtNombre.Text == string.Empty)
            {
                this.imgNombre.Visible = true;
                sw = false;
            }
            if (this.txtApellido.Text == string.Empty)
            {
                this.imgApellido.Visible = true;
                sw = false;
            }
            if (this.sexo == "")
            {
                this.imgSexo.Visible = true;
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

        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validacionImgError())
                {
                    this.convertir();
                    EPaciente Obj = new EPaciente();
                    Obj.pacienteID = Convert.ToInt32(this.txtId.Text);
                    Obj.nombre = this.txtNombre.Text.Trim();
                    Obj.apellido = this.txtApellido.Text.Trim();
                    Obj.telefono = this.txtTelefono.Text.Trim();
                    Obj.ci = this.txtCI.Text.Trim();
                    Obj.fechaNacimiento = Convert.ToDateTime(this.txtFecha.Text);
                    Obj.direccion = this.txtDireccion.Text.Trim();
                    Obj.sexo = this.sexo;
                    NPacientes.update(Obj);
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

        private void TxtBuscarNombre_TextChanged(object sender, EventArgs e)
        {
            this.siguientePag = 0;
            this.MostrarDB();
        }
        private void TxtBuscarApellido_TextChanged(object sender, EventArgs e)
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

        private void TxtM_Click(object sender, EventArgs e)
        {
            this.txtM.Checked = true;
            this.txtF.Checked = false;
            this.sexo = "Masculino";
            this.imgSexo.Visible = false;
        }

        private void TxtF_Click(object sender, EventArgs e)
        {
            this.txtM.Checked = false;
            this.txtF.Checked = true;
            this.sexo = "Femenino";
            this.imgSexo.Visible = false;
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.imgNombre.Visible = false;
        }

        private void TxtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.imgApellido.Visible = false;
        }

        private void BtnImprimirxd_Click(object sender, EventArgs e)
        {
            FrmReportePacientes frm = new FrmReportePacientes();
            frm.ShowDialog();
        }

        private void DataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void IconCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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
            this.siguientePag = NPacientes.mostrarTotal(this.txtBuscarNombre.Text, this.txtBuscarApellido.Text) / 10;
            this.MostrarDB();
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == Convert.ToChar("\b"))
            {               
                if(this.txtTelefono.TextLength>7 && e.KeyChar!=Convert.ToChar("\b"))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
