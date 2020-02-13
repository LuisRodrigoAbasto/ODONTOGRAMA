using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntity;
using CapaNegocio;


namespace CapaPresentacion
{
    public partial class FrmBuscarPaciente : Form
    {
        


        public FrmBuscarPaciente()
        {
            InitializeComponent();
        }
        private int siguientePag = 0;


        private void MostrarDB()
        {
            this.dataListado.DataSource = NPacientes.mostrar(this.txtBuscarNombre.Text,this.txtBuscarApellido.Text,siguientePag);
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
        }

        private void FrmBuscarPaciente_Load(object sender, EventArgs e)
        {
            this.MostrarDB();
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

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.MostrarDB();
        }
        private void ordenarColumnas()
        {
            //this.dataListado.Columns["pacienteID"].DisplayIndex = 0;
            this.dataListado.Columns["pacienteID"].HeaderText = "id";
            //this.dataListado.Columns["nombre"].DisplayIndex = 1;
            this.dataListado.Columns["nombre"].HeaderText = "Nombre";
            //this.dataListado.Columns["apellido"].DisplayIndex = 2;
            this.dataListado.Columns["apellido"].HeaderText = "Apellido";
            //this.dataListado.Columns["telefono"].DisplayIndex = 3;
            this.dataListado.Columns["telefono"].HeaderText = "Telefono";
            //this.dataListado.Columns["ci"].DisplayIndex = 4;
            this.dataListado.Columns["ci"].HeaderText = "CI";
            //this.dataListado.Columns["fechaNacimiento"].DisplayIndex = 5;
            this.dataListado.Columns["fechaNacimiento"].HeaderText = "Fecha_Nacimiento";
            //this.dataListado.Columns["direccion"].DisplayIndex = 6;
            this.dataListado.Columns["direccion"].HeaderText = "Direccion";
            //this.dataListado.Columns["sexo"].DisplayIndex = 7;
            this.dataListado.Columns["sexo"].HeaderText = "Sexo";
           
            this.dataListado.Columns["estado"].Visible = false;
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
    }
}
