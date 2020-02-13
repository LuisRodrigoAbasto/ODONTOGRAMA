using CapaEntity;
using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{

    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
            this.MostrarDB();
            //
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {

            this.MostrarDB();

        }
        private int siguientePag = 0;

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
            this.dataListado.DataSource = NUsers.mostrar(this.txtBuscarNombre.Text,this.txtBuscarApellido.Text,this.siguientePag);
            this.ordenarColumnas();
            this.dataListado.AutoResizeColumns();
            int dataTotal = NUsers.mostrarTotal(this.txtBuscarNombre.Text,this.txtBuscarApellido.Text) / 10;
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
            this.dataListado.Columns["usuarioID"].DisplayIndex = 0;
            this.dataListado.Columns["usuarioID"].HeaderText = "id";
            this.dataListado.Columns["nombre"].DisplayIndex = 1;
            this.dataListado.Columns["nombre"].HeaderText = "Nombre";
            this.dataListado.Columns["apellido"].DisplayIndex = 2;
            this.dataListado.Columns["apellido"].HeaderText = "Apellido";
            this.dataListado.Columns["tipo"].DisplayIndex = 3;
            this.dataListado.Columns["tipo"].HeaderText = "Tipo";
            this.dataListado.Columns["usuario"].DisplayIndex = 4;
            this.dataListado.Columns["usuario"].HeaderText = "Usuario";
            this.dataListado.Columns["password"].DisplayIndex = 5;
            this.dataListado.Columns["password"].HeaderText = "Password";

            this.dataListado.Columns["Editar"].DisplayIndex = 6;
            this.dataListado.Columns["Eliminar"].DisplayIndex = 7;
            this.dataListado.Columns["estado"].Visible = false;

        }

        private void DataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea Eliminar El Registro", "Sistema de Odontograma", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {

                    string Codigo;
                    string Rpta = "";

                    Codigo = Convert.ToString(this.dataListado.CurrentRow.Cells["usuarioID"].Value);
                    EUsers Obj = new EUsers();
                    Obj.usuarioID = Convert.ToInt32(Codigo);
                    Rpta = Convert.ToString(NUsers.delete(Obj));
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
                    this.LimpiarImgError();
                    this.txtId.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["usuarioID"].Value);
                    this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
                    this.txtApellido.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellido"].Value);
                    this.cbAcceso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo"].Value);
                    this.txtUsuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["usuario"].Value);
                    this.txtPassword.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["password"].Value);


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
            this.cbAcceso.Text = string.Empty;
            this.txtUsuario.Text = string.Empty;
            this.txtPassword.Text = string.Empty;

            this.btnGuardar.Visible = true;
            this.btnActualizar.Visible = false;
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
                if (validacionImgError())
                {
                    this.convertir();
                    EUsers Obj = new EUsers();
                    Obj.nombre = this.txtNombre.Text.Trim();
                    Obj.apellido = this.txtApellido.Text.Trim();
                    Obj.tipo = this.cbAcceso.Text.Trim();
                    Obj.usuario = this.txtUsuario.Text.Trim();
                    Obj.password = this.txtPassword.Text.Trim();

                    NUsers.save(Obj);
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
                if (validacionImgError())
                {
                    this.convertir();
                    EUsers Obj = new EUsers();
                    Obj.usuarioID = Convert.ToInt32(this.txtId.Text);
                    Obj.nombre = this.txtNombre.Text.Trim();
                    Obj.apellido = this.txtApellido.Text.Trim();
                    Obj.tipo = this.cbAcceso.Text.Trim();
                    Obj.usuario = this.txtUsuario.Text.Trim();
                    Obj.password = this.txtPassword.Text.Trim();

                    NUsers.update(Obj);
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
            if (this.cbAcceso.Text == "")
            {
                this.imgAcceso.Visible = true;
                sw = false;
            }
            if (this.txtUsuario.Text == string.Empty)
            {
                this.imgUsuario.Visible = true;
                sw = false;
            }
            if (this.txtPassword.Text == string.Empty)
            {
                this.imgPassword.Visible = true;
                sw = false;
            }
            return sw;
        }
        private void LimpiarImgError()
        {
            this.imgNombre.Visible = false;
            this.imgApellido.Visible = false;
            this.imgAcceso.Visible = false;
            this.imgUsuario.Visible = false;
            this.imgPassword.Visible = false;
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.imgNombre.Visible = false;
        }

        private void TxtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.imgApellido.Visible = false;
        }

        private void CbAcceso_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.imgAcceso.Visible = false;
        }

        private void TxtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.imgUsuario.Visible = false;
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.imgPassword.Visible = false;
        }

        private void BtnIncio_Click(object sender, EventArgs e)
        {
            this.siguientePag = 0;
            this.MostrarDB();
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            this.siguientePag --;
            this.MostrarDB();
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            this.siguientePag++;
            this.MostrarDB();
        }

        private void BtnFin_Click(object sender, EventArgs e)
        {
            this.siguientePag = NUsers.mostrarTotal(this.txtBuscarNombre.Text,this.txtBuscarApellido.Text) / 10;
            this.MostrarDB();
        }

        private void TxtBuscarApellido_TextChanged(object sender, EventArgs e)
        {
            this.siguientePag = 0;
            this.MostrarDB();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.MostrarDB();
        }
    }
}
