
namespace SWUserControls
{
    partial class FormLauncher
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlLauncher = new System.Windows.Forms.Panel();
            this.ptrIcon = new System.Windows.Forms.PictureBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.pnlLauncher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptrIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLauncher
            // 
            this.pnlLauncher.BackColor = System.Drawing.Color.DarkOrchid;
            this.pnlLauncher.Controls.Add(this.lblDesc);
            this.pnlLauncher.Controls.Add(this.ptrIcon);
            this.pnlLauncher.Location = new System.Drawing.Point(129, 54);
            this.pnlLauncher.Name = "pnlLauncher";
            this.pnlLauncher.Size = new System.Drawing.Size(523, 264);
            this.pnlLauncher.TabIndex = 0;
            this.pnlLauncher.Click += new System.EventHandler(this.btnLauncher_Click);
            // 
            // ptrIcon
            // 
            this.ptrIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptrIcon.Location = new System.Drawing.Point(16, 17);
            this.ptrIcon.Name = "ptrIcon";
            this.ptrIcon.Size = new System.Drawing.Size(186, 102);
            this.ptrIcon.TabIndex = 0;
            this.ptrIcon.TabStop = false;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(356, 215);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(92, 29);
            this.lblDesc.TabIndex = 1;
            this.lblDesc.Text = "default";
            // 
            // FormLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlLauncher);
            this.Name = "FormLauncher";
            this.Size = new System.Drawing.Size(765, 395);
            this.Load += new System.EventHandler(this.FormLauncher_Load);
            this.pnlLauncher.ResumeLayout(false);
            this.pnlLauncher.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptrIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLauncher;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.PictureBox ptrIcon;
    }
}
