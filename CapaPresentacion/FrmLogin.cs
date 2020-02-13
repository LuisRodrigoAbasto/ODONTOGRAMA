using CapaEntity;
using CapaNegocio;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void TxtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "USUARIO")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void TxtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void TxtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void TxtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = false;

            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void PictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnAcceder_Click(object sender, EventArgs e)
        {
            this.loguear();
        }
        private void loguear()
        {
            try
            {
                if (this.txtUser.Text != "USUARIO")
                {
                    if (this.txtPass.Text != "CONTRASEÑA")
                    {
                        

                         EUsers user = new EUsers();
                        NUsers log = new NUsers();

                        user.usuario = this.txtUser.Text;
                        user.password = this.txtPass.Text;
                       user = log.login(user);
                        if (user.usuarioID > 0)
                        {
                            FrmMenu mainMenu = new FrmMenu(user);                           
                            mainMenu.Show();
                            this.Hide();
                            txtPass.Clear();
                            txtUser.Focus();                      
                            mainMenu.FormClosed += logout;
                        }
                        else
                        {                            
                            throw new Exception("El Usuario que Ingresaste no coinciden con ninguna Cuenta");                            
                        }


                    }

                    else msgError("Ingrese Ingrese su Contraseña");

                }
                else msgError("Ingrese su Nombre de Usuario");
            }
            catch (Exception ex)
            {
                msgError(ex.Message);
                this.txtPass.Text = string.Empty;
            }
        }
        private void msgError(string msg)
        {
            lbErrorMessagge.Text = "        " + msg;
            lbErrorMessagge.Visible = true;
        }

        private void TxtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.lbErrorMessagge.Visible = false;
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.loguear();
            }
        }

        private void TxtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.lbErrorMessagge.Visible = false;
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.loguear();
            }
        }

        private void logout(object sender, FormClosedEventArgs e)
        {

            txtPass.Text = "CONTRASEÑA";
            txtPass.UseSystemPasswordChar = false;
            txtUser.Text = "USUARIO";
            // txtPass.Clear();
            //  txtUser.Clear();
            lbErrorMessagge.Visible = false;
            this.Show();
            //  txtUser.Focus();
        }
    }
}
