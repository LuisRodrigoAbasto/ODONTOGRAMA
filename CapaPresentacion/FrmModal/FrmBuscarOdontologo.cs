using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmBuscarOdontologo : Form
    {
        public FrmBuscarOdontologo()
        {
            InitializeComponent();
            this.MostrarDB();
        }
        private int siguientePag = 0;

        private void FrmBuscarOdontologo_Load(object sender, EventArgs e)
        {
            this.MostrarDB();
        }
        private void MostrarDB()
        {
            this.dataListado.DataSource = NUsers.mostrarOdontologo(this.txtNombre.Text, this.txtApellido.Text, this.siguientePag);
            this.ordenarColumnas();
            this.dataListado.AutoResizeColumns();

            int dataTotal = NUsers.mostrarTotal(this.txtNombre.Text, this.txtApellido.Text) / 10;
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

        private void ordenarColumnas()
        {
            //this.dataListado.Columns["usuarioID"].DisplayIndex = 0;
            this.dataListado.Columns["usuarioID"].HeaderText = "id";
            //this.dataListado.Columns["nombre"].DisplayIndex = 1;
            this.dataListado.Columns["nombre"].HeaderText = "Nombre";
            //this.dataListado.Columns["apellido"].DisplayIndex = 2;
            this.dataListado.Columns["apellido"].HeaderText = "Apellido";
            //this.dataListado.Columns["tipo"].DisplayIndex = 3;
            this.dataListado.Columns["tipo"].HeaderText = "Tipo";
            //this.dataListado.Columns["usuario"].DisplayIndex = 4;
            this.dataListado.Columns["usuario"].HeaderText = "Usuario";
            //this.dataListado.Columns["password"].DisplayIndex = 5;
            this.dataListado.Columns["password"].HeaderText = "Password";

           
            this.dataListado.Columns["estado"].Visible = false;

        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.siguientePag = 0;
            this.MostrarDB();
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
            this.siguientePag = NUsers.mostrarTotal(this.txtNombre.Text, this.txtApellido.Text) / 10;
            this.MostrarDB();
        }

        private void TxtApellido_TextChanged(object sender, EventArgs e)
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
