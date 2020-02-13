namespace CapaPresentacion
{
    partial class FrmReporteOdontograma
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
            this.reporteOdontograma = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reporteOdontograma
            // 
            this.reporteOdontograma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reporteOdontograma.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reporte.Odontograma.Odontograma.ReporteOdontograma.rdlc";
            this.reporteOdontograma.Location = new System.Drawing.Point(0, 0);
            this.reporteOdontograma.Name = "reporteOdontograma";
            this.reporteOdontograma.ServerReport.BearerToken = null;
            this.reporteOdontograma.Size = new System.Drawing.Size(984, 562);
            this.reporteOdontograma.TabIndex = 0;
            // 
            // FrmReporteOdontograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.reporteOdontograma);
            this.Name = "FrmReporteOdontograma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReporteOdontograma";
            this.Load += new System.EventHandler(this.FrmReporteOdontograma_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reporteOdontograma;
    }
}