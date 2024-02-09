
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrdersDetail
            // 
            this.dgvOrdersDetail.AllowUserToAddRows = false;
            this.dgvOrdersDetail.AllowUserToDeleteRows = false;
            this.dgvOrdersDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdersDetail.Location = new System.Drawing.Point(27, 209);
            this.dgvOrdersDetail.Name = "dgvOrdersDetail";
            this.dgvOrdersDetail.ReadOnly = true;
            this.dgvOrdersDetail.RowHeadersWidth = 51;
            this.dgvOrdersDetail.RowTemplate.Height = 24;
            this.dgvOrdersDetail.Size = new System.Drawing.Size(451, 265);
            this.dgvOrdersDetail.TabIndex = 0;
            // 
            // btnLoadEdiFile
            // 
            this.btnLoadEdiFile.Location = new System.Drawing.Point(27, 145);
            this.btnLoadEdiFile.Name = "btnLoadEdiFile";
            this.btnLoadEdiFile.Size = new System.Drawing.Size(75, 23);
            this.btnLoadEdiFile.TabIndex = 1;
            this.btnLoadEdiFile.Text = "Load";
            this.btnLoadEdiFile.UseVisualStyleBackColor = true;
            this.btnLoadEdiFile.Click += new System.EventHandler(this.btnLoadEdiFile_Click);
            // 
            // frmOrdersProcessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 502);
            this.Controls.Add(this.btnLoadEdiFile);
            this.Controls.Add(this.dgvOrdersDetail);
            this.Name = "frmOrdersProcessor";
            this.Text = "Orders Processor";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrdersDetail;
        private System.Windows.Forms.Button btnLoadEdiFile;
    }
}

