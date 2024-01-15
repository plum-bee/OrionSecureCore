
namespace SpeciesManagement
{
    partial class SpeciesManagement
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
            this.txtCodi = new System.Windows.Forms.TextBox();
            this.txtDescripcio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCodi
            // 
            this.txtCodi.Location = new System.Drawing.Point(22, 139);
            this.txtCodi.Name = "txtCodi";
            this.txtCodi.Size = new System.Drawing.Size(129, 22);
            this.txtCodi.TabIndex = 11;
            this.txtCodi.Tag = "CodeSpecie";
            // 
            // txtDescripcio
            // 
            this.txtDescripcio.Location = new System.Drawing.Point(212, 139);
            this.txtDescripcio.Name = "txtDescripcio";
            this.txtDescripcio.Size = new System.Drawing.Size(129, 22);
            this.txtDescripcio.TabIndex = 12;
            this.txtDescripcio.Tag = "DescSpecie";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Codi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Descripció";
            // 
            // SpeciesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescripcio);
            this.Controls.Add(this.txtCodi);
            this.Name = "SpeciesManagement";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.txtCodi, 0);
            this.Controls.SetChildIndex(this.txtDescripcio, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodi;
        private System.Windows.Forms.TextBox txtDescripcio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

