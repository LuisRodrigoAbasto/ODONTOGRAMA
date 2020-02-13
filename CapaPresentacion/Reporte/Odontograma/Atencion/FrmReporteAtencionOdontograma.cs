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
    public partial class FrmReporteAtencionOdontograma : Form
    {
        public List<EPaciente> paciente = new List<EPaciente>();
        public List<EUsers> odontologo = new List<EUsers>();
        public List<EUsers> empleado = new List<EUsers>();

        private int iDAtencion;
        private string numeroLiteral;
        public FrmReporteAtencionOdontograma()
        {
            InitializeComponent();
        }

        private string imagenUrl = Application.StartupPath + "\\Pictures\\odontograma.png";
        public int IDAtencion { get => iDAtencion; set => iDAtencion = value; }
        public string NumeroLiteral { get => numeroLiteral; set => numeroLiteral = value; }

        private static List<EAtencion> mostarAtencion(int ID)
        {
             List<EAtencion> atencion = new List<EAtencion>();
            NAtencion mostrar = new NAtencion();
            atencion.Add(mostrar.mostrarAtencionID(ID));
            return atencion;

         }
        
        private void FrmReporteAtencionOdontograma_Load(object sender, EventArgs e)
        {
            this.reporteAtencionOdon.LocalReport.DataSources.Clear();
            this.reporteAtencionOdon.LocalReport.DataSources.Add(new ReportDataSource("DataSetDetalle", NAtencion_detalle.detalleAtencion(IDAtencion)));
            this.reporteAtencionOdon.LocalReport.DataSources.Add(new ReportDataSource("DataSetPaciente", this.paciente));
            this.reporteAtencionOdon.LocalReport.DataSources.Add(new ReportDataSource("DataSetOdontologo", this.odontologo));
            this.reporteAtencionOdon.LocalReport.DataSources.Add(new ReportDataSource("DataSetEmpleado", this.empleado));
            this.reporteAtencionOdon.LocalReport.DataSources.Add(new ReportDataSource("DataSetAtencion", mostarAtencion(IDAtencion)));


            FileInfo file = new FileInfo(this.imagenUrl);
            ReportParameter numero = new ReportParameter("numeroLiteral", this.NumeroLiteral);
            ReportParameter pImageUrl = new ReportParameter("imagenUrl", new Uri(this.imagenUrl).AbsoluteUri);
            this.reporteAtencionOdon.LocalReport.EnableExternalImages = true;
            this.reporteAtencionOdon.LocalReport.SetParameters(new ReportParameter[] { numero, pImageUrl });


            this.reporteAtencionOdon.RefreshReport();
        }
    }
}
