namespace CapaPresentacion
{
    partial class FrmReporteAtencionOdontograma
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reporteAtencionOdon = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reporteAtencionOdon
            // 
            this.reporteAtencionOdon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reporteAtencionOdon.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reporte.Odontograma.Atencion.ReporteAtencionOdontograma.rdlc";
            this.reporteAtencionOdon.Location = new System.Drawing.Point(0, 0);
            this.reporteAtencionOdon.Name = "reporteAtencionOdon";
            this.reporteAtencionOdon.ServerReport.BearerToken = null;
            this.reporteAtencionOdon.Size = new System.Drawing.Size(984, 562);
            this.reporteAtencionOdon.TabIndex = 0;
            // 
            // FrmReporteAtencionOdontograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.reporteAtencionOdon);
            this.Name = "FrmReporteAtencionOdontograma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReporteAtencionOdontograma";
            this.Load += new System.EventHandler(this.FrmReporteAtencionOdontograma_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reporteAtencionOdon;
    }
}