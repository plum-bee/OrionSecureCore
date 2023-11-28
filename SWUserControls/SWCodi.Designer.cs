
namespace SWUserControls
{
    partial class SWCodi
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(271, 32);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(172, 22);
            this.txtDescription.TabIndex = 0;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(207, 32);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(58, 22);
            this.txtCode.TabIndex = 1;
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            // 
            // SWCodi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtDescription);
            this.Name = "SWCodi";
            this.Size = new System.Drawing.Size(573, 111);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtCode;
    }
}
