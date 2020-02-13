using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new FrmLogin());
            //Application.Run(new FrmPrueba());
            //Application.Run(new FrmUsuario());

            //Application.Run(new FrmMenu());
            //Application.Run(new FrmOdontograma());
            //Application.Run(new FrmUsuario());
            // Application.Run(new FrmAgenda());
            // Application.Run(new FrmCita());
            //Application.Run(new FrmTratamiento());

            //Application.Run(new Form1());
        }
    }
}
