using CapaEntity;
using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmTratamiento : Form
    {
        public FrmTratamiento()
        {
            InitializeComponent();
            this.MostrarDB();
        }
        private int siguientePag = 0;

        private void FrmDiagnostico_Load(object sender, EventArgs e)
        {
            this.MostrarDB();
            this.comboColor();
        }

        private void MostrarDB()
        {
            this.dataListado.DataSource = NTratamiento.mostrar(this.txtBuscar.Text, siguientePag);
         ///   this.dataListado.AutoResizeRows();
            this.ordenarColumnas();
            this.dataListado.AutoResizeColumns();
            int dataTotal = NTratamiento.mostrarTotal(this.txtBuscar.Text) / 10;
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
            this.dataListado.Columns["tratamientoID"].DisplayIndex = 0;
            this.dataListado.Columns["tratamientoID"].HeaderText = "id";
            this.dataListado.Columns["nombre"].DisplayIndex = 1;
            this.dataListado.Columns["nombre"].HeaderText = "Nombre";
            this.dataListado.Columns["color"].DisplayIndex = 2;
            this.dataListado.Columns["color"].HeaderText = "Color";
            this.dataListado.Columns["tipo"].DisplayIndex = 3;
            this.dataListado.Columns["tipo"].HeaderText = "Tipo";

            this.dataListado.Columns["precio"].DisplayIndex = 4;
            this.dataListado.Columns["precio"].HeaderText = "Precio";       

            this.dataListado.Columns["Editar"].DisplayIndex = 5;
            this.dataListado.Columns["Eliminar"].DisplayIndex = 6;
            //this.dataListado.Columns["Odontograma_detalle"].Visible = false;
            this.dataListado.Columns["estado"].Visible = false;
        //    this.dataListado.Columns["precio"].Visible = false;
        }

        private void MensajeOk(String mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    Codigo = Convert.ToString(this.dataListado.CurrentRow.Cells["tratamientoID"].Value);
                    ETratamiento Obj = new ETratamiento();
                    Obj.tratamientoID = Convert.ToInt32(Codigo);
                    Rpta = Convert.ToString(NTratamiento.delete(Obj));
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
                    this.txtId.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tratamientoID"].Value);
                    this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
                    this.txtColor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["color"].Value);
                    string tipo = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo"].Value);
                    if (tipo == "Diagnostico")
                    {
                        this.rbDiagnostico.Checked = true;
                    }
                    else
                    {
                        this.rbProcedimiento.Checked = true;
                    }
                    this.txtPrecio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["precio"].Value);
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
            this.txtColor.Text = string.Empty;           
            this.txtPrecio.Text = "0";
            this.btnGuardar.Visible = true;
            this.btnActualizar.Visible = false;
            this.rbDiagnostico.Checked = false;
            this.rbProcedimiento.Checked = false;
        }

        private void convertir()
        {
            while (this.txtNombre.Text.Contains("  "))
            {
                this.txtNombre.Text = this.txtNombre.Text.Trim().Replace("  ", " ");
            }
            while (this.txtColor.Text.Contains("  "))
            {
                this.txtColor.Text = this.txtColor.Text.Trim().Replace("  ", " ");
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
            if (this.txtColor.Text == string.Empty)
            {
                this.imgColor.Visible = true;
                sw = false;
            }

            return sw;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validacionImgError())
                {
                    this.convertir();

                    ETratamiento Obj = new ETratamiento();
                    Obj.nombre = this.txtNombre.Text.Trim();
                    Obj.color = this.txtColor.Text.Trim();
                    if (rbDiagnostico.Checked == true)
                    {
                        Obj.tipo = "DIAGNOSTICO";
                        this.txtPrecio.Text = "0";
                    }
                    else
                    {

                        Obj.tipo = "PROCEDIMIENTO";
                    }
                    Obj.precio = Convert.ToDecimal(this.txtPrecio.Text);
                    NTratamiento.save(Obj);

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
                MessageBox.Show(ex.Message, "Sistema de Odontograma");
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
            this.comboColor();
            this.lbModificar.Visible = false;
            this.lbAgregar.Visible = true;
            this.pColor.Visible = false;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validacionImgError())
                {
                    this.convertir();

                    ETratamiento Obj = new ETratamiento();
                    Obj.tratamientoID = Convert.ToInt32(this.txtId.Text);
                    Obj.nombre = this.txtNombre.Text.Trim();
                    Obj.color = this.txtColor.Text.Trim();

                    if (rbDiagnostico.Checked == true)
                    {
                        Obj.tipo = "DIAGNOSTICO";
                    }
                    else
                    {

                        Obj.tipo = "PROCEDIMIENTO";
                    }
                    Obj.precio = Convert.ToDecimal(this.txtPrecio.Text);
                    NTratamiento.update(Obj);

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

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.siguientePag = 0;
            this.MostrarDB();
        }

        private void comboColor()
        {
            this.txtColor.Items.Clear();
            string[] colores = Enum.GetNames(typeof(System.Drawing.KnownColor));
            this.txtColor.Items.AddRange(colores);            
        }
        private void TxtColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                string texto = this.txtColor.Items[e.Index].ToString();
                Brush borde = new SolidBrush(e.ForeColor);
                Color color = Color.FromName(texto);
                Brush pincel = new SolidBrush(color);
                Pen boli = new Pen(e.ForeColor);

                e.Graphics.DrawRectangle(boli, new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + 2, 50, e.Bounds.Height - 4));
                e.Graphics.FillRectangle(pincel, new Rectangle(e.Bounds.Left + 3, e.Bounds.Top + 3, 48, e.Bounds.Height - 6));
                e.Graphics.DrawString(texto, e.Font, borde, e.Bounds.Left + 65, e.Bounds.Top + 2);

                e.DrawFocusRectangle();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TxtColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pColor.BackColor = Color.FromName(this.txtColor.Text);
            this.pColor.Visible = true;
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.imgNombre.Visible = false;
        }

        private void TxtColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.imgColor.Visible = false;
        }
        private void LimpiarImgError()
        {
            this.imgNombre.Visible = false;
            this.imgColor.Visible = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //FrmReporteTratamiento frm = new FrmReporteTratamiento();
            ////frm.ShowDialog();
            //this.txtColor.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void RbDiagnostico_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbDiagnostico.Checked == true)
            {
                this.txtPrecio.Visible = false;
                this.lblPrecio.Visible = false;
            }           
        }

        private void RbProcedimiento_CheckedChanged(object sender, EventArgs e)
        {
            if(this.rbProcedimiento.Checked==true)
            {
                this.txtPrecio.Visible = true;
                this.lblPrecio.Visible = true;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.MostrarDB();
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
            this.siguientePag = NTratamiento.mostrarTotal(this.txtBuscar.Text) / 10;
            this.MostrarDB();
        }

        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == Convert.ToChar(",") || e.KeyChar == Convert.ToChar("\b"))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }
    }
}
