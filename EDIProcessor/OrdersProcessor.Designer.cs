
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
            this.swTextbox5 = new SWUserControls.SwTextbox();
            this.swTextbox4 = new SWUserControls.SwTextbox();
            this.swTextbox3 = new SWUserControls.SwTextbox();
            this.swTextbox2 = new SWUserControls.SwTextbox();
            this.swTextboxCode = new SWUserControls.SwTextbox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrdersDetail
            // 
            this.dgvOrdersDetail.AllowUserToAddRows = false;
            this.dgvOrdersDetail.AllowUserToDeleteRows = false;
            this.dgvOrdersDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdersDetail.Location = new System.Drawing.Point(14, 261);
            this.dgvOrdersDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvOrdersDetail.Name = "dgvOrdersDetail";
            this.dgvOrdersDetail.ReadOnly = true;
            this.dgvOrdersDetail.RowHeadersWidth = 51;
            this.dgvOrdersDetail.RowTemplate.Height = 24;
            this.dgvOrdersDetail.Size = new System.Drawing.Size(1030, 331);
            this.dgvOrdersDetail.TabIndex = 0;
            // 
            // btnLoadEdiFile
            // 
            this.btnLoadEdiFile.Location = new System.Drawing.Point(960, 225);
            this.btnLoadEdiFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoadEdiFile.Name = "btnLoadEdiFile";
            this.btnLoadEdiFile.Size = new System.Drawing.Size(84, 29);
            this.btnLoadEdiFile.TabIndex = 1;
            this.btnLoadEdiFile.Text = "Load";
            this.btnLoadEdiFile.UseVisualStyleBackColor = true;
            this.btnLoadEdiFile.Click += new System.EventHandler(this.btnLoadEdiFile_Click);
            // 
            // swTextbox5
            // 
            this.swTextbox5.AllowEmpty = false;
            this.swTextbox5.ControlName = null;
            this.swTextbox5.DefaultColor = System.Drawing.SystemColors.Window;
            this.swTextbox5.FocusColor = System.Drawing.Color.Yellow;
            this.swTextbox5.IsForeignKey = false;
            this.swTextbox5.Location = new System.Drawing.Point(395, 194);
            this.swTextbox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.swTextbox5.Name = "swTextbox5";
            this.swTextbox5.Size = new System.Drawing.Size(112, 26);
            this.swTextbox5.TabIndex = 6;
            this.swTextbox5.Tag = "Area";
            this.swTextbox5.TextType = SWUserControls.SwTextbox.SwTextType.Number;
            // 
            // swTextbox4
            // 
            this.swTextbox4.AllowEmpty = false;
            this.swTextbox4.ControlName = null;
            this.swTextbox4.DefaultColor = System.Drawing.SystemColors.Window;
            this.swTextbox4.FocusColor = System.Drawing.Color.Yellow;
            this.swTextbox4.IsForeignKey = false;
            this.swTextbox4.Location = new System.Drawing.Point(521, 35);
            this.swTextbox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.swTextbox4.Name = "swTextbox4";
            this.swTextbox4.Size = new System.Drawing.Size(112, 26);
            this.swTextbox4.TabIndex = 5;
            this.swTextbox4.Tag = "Agency";
            this.swTextbox4.TextType = SWUserControls.SwTextbox.SwTextType.Number;
            // 
            // swTextbox3
            // 
            this.swTextbox3.AllowEmpty = false;
            this.swTextbox3.ControlName = null;
            this.swTextbox3.DefaultColor = System.Drawing.SystemColors.Window;
            this.swTextbox3.FocusColor = System.Drawing.Color.Yellow;
            this.swTextbox3.IsForeignKey = false;
            this.swTextbox3.Location = new System.Drawing.Point(359, 48);
            this.swTextbox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.swTextbox3.Name = "swTextbox3";
            this.swTextbox3.Size = new System.Drawing.Size(112, 26);
            this.swTextbox3.TabIndex = 4;
            this.swTextbox3.Tag = "Factory";
            this.swTextbox3.TextType = SWUserControls.SwTextbox.SwTextType.Number;
            // 
            // swTextbox2
            // 
            this.swTextbox2.AllowEmpty = false;
            this.swTextbox2.ControlName = null;
            this.swTextbox2.DefaultColor = System.Drawing.SystemColors.Window;
            this.swTextbox2.FocusColor = System.Drawing.Color.Yellow;
            this.swTextbox2.IsForeignKey = false;
            this.swTextbox2.Location = new System.Drawing.Point(200, 48);
            this.swTextbox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.swTextbox2.Name = "swTextbox2";
            this.swTextbox2.Size = new System.Drawing.Size(112, 26);
            this.swTextbox2.TabIndex = 3;
            this.swTextbox2.Tag = "Date";
            this.swTextbox2.TextType = SWUserControls.SwTextbox.SwTextType.Number;
            // 
            // swTextboxCode
            // 
            this.swTextboxCode.AllowEmpty = false;
            this.swTextboxCode.ControlName = null;
            this.swTextboxCode.DefaultColor = System.Drawing.SystemColors.Window;
            this.swTextboxCode.FocusColor = System.Drawing.Color.Yellow;
            this.swTextboxCode.IsForeignKey = false;
            this.swTextboxCode.Location = new System.Drawing.Point(35, 35);
            this.swTextboxCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.swTextboxCode.Name = "swTextboxCode";
            this.swTextboxCode.Size = new System.Drawing.Size(112, 26);
            this.swTextboxCode.TabIndex = 2;
            this.swTextboxCode.Tag = "Code";
            this.swTextboxCode.TextType = SWUserControls.SwTextbox.SwTextType.Text;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(153, -4);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(680, 634);
            this.crystalReportViewer1.TabIndex = 7;
            // 
            // frmOrdersProcessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 628);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.swTextbox5);
            this.Controls.Add(this.swTextbox4);
            this.Controls.Add(this.swTextbox3);
            this.Controls.Add(this.swTextbox2);
            this.Controls.Add(this.swTextboxCode);
            this.Controls.Add(this.btnLoadEdiFile);
            this.Controls.Add(this.dgvOrdersDetail);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmOrdersProcessor";
            this.Text = "Orders Processor";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrdersDetail;
        private System.Windows.Forms.Button btnLoadEdiFile;
        private SWUserControls.SwTextbox swTextboxCode;
        private SWUserControls.SwTextbox swTextbox2;
        private SWUserControls.SwTextbox swTextbox3;
        private SWUserControls.SwTextbox swTextbox4;
        private SWUserControls.SwTextbox swTextbox5;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}

