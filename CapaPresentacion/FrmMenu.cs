using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using CapaEntity;

namespace CapaPresentacion
{
    public partial class FrmMenu : Form 

    {
        public EUsers empleado;

        public bool sw = true;

        public FrmMenu(EUsers users)
        {
            InitializeComponent();
            AbirFormularioPanel(new FrmHome());
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToLongDateString();
            empleado = users;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);



        private void BtnSlide_Click(object sender, EventArgs e)
        {
            //if (MenuVertical.Width == 250)
            this.deslizar();
        }
        private void deslizar()
        {
            if (this.sw)
            {
                this.MenuVertical.Width = 70;
                this.sw = false;
            }
            else
            {
                this.MenuVertical.Width = 210;
                this.sw = true;
            }
        }
        private void IconMaximizar_Click(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
            //this.WindowState = FormWindowState.Maximized;
            iconRestaurar.Visible = true;
            iconMaximizar.Visible = false;
        }

        private void IconCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IconRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.iconRestaurar.Visible = false;
            this.iconMaximizar.Visible = true;

        }

        private void IconMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AbirFormularioPanel(object FormHijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = FormHijo as Form;

            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void BtnPaciente_Click(object sender, EventArgs e)
        {
            AbirFormularioPanel(new FrmPaciente());


        }

        private void Button3_Click(object sender, EventArgs e)
        {
            AbirFormularioPanel(new FrmDiente());

        }

        private void BtnDiagnostico_Click(object sender, EventArgs e)
        {
            AbirFormularioPanel(new FrmTratamiento());
        }

        private void BtnTipo_Click(object sender, EventArgs e)
        {
            AbirFormularioPanel(new FrmParte());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            //this.WindowState = FormWindowState.Maximized;
            ////this.WindowState = FormWindowState.Maximized;
            //iconRestaurar.Visible = true;
            //iconMaximizar.Visible = false;

            //this.sw = true;
            //this.deslizar();
            AbirFormularioPanel(new FrmOdontograma(empleado));
            //this.sw = false;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AbirFormularioPanel(new FrmUsuario());
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            AbirFormularioPanel(new FrmHome());
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            AbirFormularioPanel(new FrmAtencion(this.empleado));
        }

        private void BtnAgenda_Click(object sender, EventArgs e)
        {
            AbirFormularioPanel(new FrmUsuario());
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            this.GestionUsuario();
            this.IconMaximizar_Click(sender, e);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void BtnCerrarSeccion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de cerrar la aplicación?", "Warning",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }
        private void GestionUsuario()
        {
            if (empleado.tipo == "Administrador")
            {
                this.MenUsuario.Enabled = true;
                this.btnTipo.Enabled = true;
                this.btnOdontologo.Enabled = true;
                this.btnDiagnostico.Enabled = true;
                this.MenDiente.Enabled = true;
                this.MenOdontograma.Enabled = true;
                this.btnAtencion.Enabled = true;
                this.btnPaciente.Enabled = true;
            }
            else if (empleado.tipo == "Secretaria")
            {
                this.MenUsuario.Enabled = false;
                this.btnTipo.Enabled = false;
                this.btnOdontologo.Enabled = true;
                this.btnDiagnostico.Enabled = false;
                this.MenDiente.Enabled = false;
                this.MenOdontograma.Enabled = true;
                this.btnAtencion.Enabled = true;
                this.btnPaciente.Enabled = true;

            }
            else if (empleado.tipo == "Odontologo")
            {
                this.MenUsuario.Enabled = false;
                this.btnTipo.Enabled = false;
                this.btnOdontologo.Enabled = true;
                this.btnDiagnostico.Enabled = false;
                this.MenDiente.Enabled = false;
                this.MenOdontograma.Enabled = true;
                this.btnAtencion.Enabled = true;
                this.btnPaciente.Enabled = true;

            }
            this.txtNombre.Text = empleado.nombre + " " + empleado.apellido;
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            AbirFormularioPanel(new FrmReportes());
        }
    }
}
