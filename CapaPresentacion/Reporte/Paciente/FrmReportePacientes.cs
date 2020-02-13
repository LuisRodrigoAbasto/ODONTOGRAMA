using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

using CapaEntity;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmReportePacientes : Form
    {
      
        public List<EPaciente> paciente = new List<EPaciente>();

        public FrmReportePacientes()
        {
            InitializeComponent();
        }

        private void FrmReportePacientes_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1",NPacientes.mostrarTodo()));

            this.reportViewer1.RefreshReport();


            this.reportViewer1.RefreshReport();
        }
    }
}
