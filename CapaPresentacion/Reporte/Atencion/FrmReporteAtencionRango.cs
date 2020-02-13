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
    public partial class FrmReporteAtencionRango : Form
    {
        private DateTime _fecha1;
        private DateTime _fecha2;

        public DateTime fecha1
        {
            get { return _fecha1; }
            set { _fecha1 = value; }
        }

        public DateTime fecha2
        {
            get { return _fecha2; }
            set { _fecha2 = value; }
        }



        public FrmReporteAtencionRango( )
        {
            InitializeComponent();
        }

        private void FrmReporteCitaRango_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetAtencion", NAtencion.mostrarReporteAtencionRango(fecha1,fecha2)));
            this.reportViewer1.RefreshReport();
        }
    }
}
