using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CapaEntity;
using CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace CapaPresentacion
{
    public partial class FrmReporteOdontograma : Form
    {
        private int detalleID;
        public List<EPaciente> paciente = new List<EPaciente>();
        public List<EOdontograma> Odontograma = new List<EOdontograma>();

        public int DetalleID { get => detalleID; set => detalleID = value; }
        public string NumeroLiteral { get => numeroLiteral; set => numeroLiteral = value; }

        private string numeroLiteral;
        public FrmReporteOdontograma()
        {
            InitializeComponent();
        }

        private string imagenUrl = Application.StartupPath + "\\Pictures\\odontograma.png";
        private void FrmReporteOdontograma_Load(object sender, EventArgs e)
        {
            this.reporteOdontograma.LocalReport.DataSources.Clear();

            this.reporteOdontograma.LocalReport.DataSources.Add(new ReportDataSource("DataSetDetalle",NOdontograma_detalle.OdontogramaDetalle(DetalleID)));
            this.reporteOdontograma.LocalReport.DataSources.Add(new ReportDataSource("DataSetPaciente", this.paciente));
            this.reporteOdontograma.LocalReport.DataSources.Add(new ReportDataSource("DataSetOdontograma", this.Odontograma));

            FileInfo file = new FileInfo(this.imagenUrl);
            ReportParameter numero = new ReportParameter("numeroLiteral",this.NumeroLiteral);
            ReportParameter pImageUrl = new ReportParameter("imagenUrl", new Uri(this.imagenUrl).AbsoluteUri);
            this.reporteOdontograma.LocalReport.EnableExternalImages = true;
            this.reporteOdontograma.LocalReport.SetParameters(new ReportParameter[] { numero,pImageUrl });

            this.reporteOdontograma.RefreshReport();        
        }
    }
}
