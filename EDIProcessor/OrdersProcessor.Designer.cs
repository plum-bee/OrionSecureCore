
namespace EDIProcessor
{
    partial class frmOrdersProcessor
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
            this.dgvOrdersDetail = new System.Windows.Forms.DataGridView();
            this.btnLoadEdiFile = new System.Windows.Forms.Button();
            this.rprtViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrdersDetail
            // 
            this.dgvOrdersDetail.AllowUserToAddRows = false;
            this.dgvOrdersDetail.AllowUserToDeleteRows = false;
            this.dgvOrdersDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdersDetail.Location = new System.Drawing.Point(14, 62);
            this.dgvOrdersDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvOrdersDetail.Name = "dgvOrdersDetail";
            this.dgvOrdersDetail.ReadOnly = true;
            this.dgvOrdersDetail.RowHeadersWidth = 51;
            this.dgvOrdersDetail.RowTemplate.Height = 24;
            this.dgvOrdersDetail.Size = new System.Drawing.Size(720, 761);
            this.dgvOrdersDetail.TabIndex = 0;
            // 
            // btnLoadEdiFile
            // 
            this.btnLoadEdiFile.Location = new System.Drawing.Point(14, 13);
            this.btnLoadEdiFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoadEdiFile.Name = "btnLoadEdiFile";
            this.btnLoadEdiFile.Size = new System.Drawing.Size(84, 29);
            this.btnLoadEdiFile.TabIndex = 1;
            this.btnLoadEdiFile.Text = "Load";
            this.btnLoadEdiFile.UseVisualStyleBackColor = true;
            this.btnLoadEdiFile.Click += new System.EventHandler(this.btnLoadEdiFile_Click);
            // 
            // rprtViewer
            // 
            this.rprtViewer.ActiveViewIndex = -1;
            this.rprtViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rprtViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.rprtViewer.Location = new System.Drawing.Point(754, 62);
            this.rprtViewer.Name = "rprtViewer";
            this.rprtViewer.Size = new System.Drawing.Size(989, 762);
            this.rprtViewer.TabIndex = 7;
            this.rprtViewer.Load += new System.EventHandler(this.rprtViewer_Load);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(121, 13);
            this.btnReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(84, 29);
            this.btnReport.TabIndex = 8;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // frmOrdersProcessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1755, 836);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.rprtViewer);
            this.Controls.Add(this.btnLoadEdiFile);
            this.Controls.Add(this.dgvOrdersDetail);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmOrdersProcessor";
            this.Text = "Orders Processor";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrdersDetail;
        private System.Windows.Forms.Button btnLoadEdiFile;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer rprtViewer;
        private System.Windows.Forms.Button btnReport;
    }
}

