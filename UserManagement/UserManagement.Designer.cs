
namespace UserManagement
{
    partial class UserManagement
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
            this.txtCodeUser = new System.Windows.Forms.TextBox();
            this.cmbSpecies = new System.Windows.Forms.ComboBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.cmbRank = new System.Windows.Forms.ComboBox();
            this.cmbPlanet = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtCodeUser
            // 
            this.txtCodeUser.Location = new System.Drawing.Point(12, 12);
            this.txtCodeUser.Name = "txtCodeUser";
            this.txtCodeUser.Size = new System.Drawing.Size(228, 22);
            this.txtCodeUser.TabIndex = 11;
            this.txtCodeUser.Tag = "CodeUser";
            // 
            // cmbSpecies
            // 
            this.cmbSpecies.FormattingEnabled = true;
            this.cmbSpecies.Location = new System.Drawing.Point(501, 12);
            this.cmbSpecies.Name = "cmbSpecies";
            this.cmbSpecies.Size = new System.Drawing.Size(121, 24);
            this.cmbSpecies.TabIndex = 12;
            this.cmbSpecies.Tag = "idSpecie";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(12, 55);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(228, 22);
            this.txtUsername.TabIndex = 13;
            this.txtUsername.Tag = "UserName";
            // 
            // cmbRank
            // 
            this.cmbRank.FormattingEnabled = true;
            this.cmbRank.Location = new System.Drawing.Point(501, 53);
            this.cmbRank.Name = "cmbRank";
            this.cmbRank.Size = new System.Drawing.Size(121, 24);
            this.cmbRank.TabIndex = 14;
            this.cmbRank.Tag = "idUserRank";
            // 
            // cmbPlanet
            // 
            this.cmbPlanet.FormattingEnabled = true;
            this.cmbPlanet.Location = new System.Drawing.Point(501, 98);
            this.cmbPlanet.Name = "cmbPlanet";
            this.cmbPlanet.Size = new System.Drawing.Size(121, 24);
            this.cmbPlanet.TabIndex = 15;
            this.cmbPlanet.Tag = "idPlanet";
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(501, 149);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 24);
            this.cmbCategory.TabIndex = 16;
            this.cmbCategory.Tag = "idUserCategory";
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 680);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbPlanet);
            this.Controls.Add(this.cmbRank);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.cmbSpecies);
            this.Controls.Add(this.txtCodeUser);
            this.Name = "UserManagement";
            this.Text = "User Management";
            this.Controls.SetChildIndex(this.txtCodeUser, 0);
            this.Controls.SetChildIndex(this.cmbSpecies, 0);
            this.Controls.SetChildIndex(this.txtUsername, 0);
            this.Controls.SetChildIndex(this.cmbRank, 0);
            this.Controls.SetChildIndex(this.cmbPlanet, 0);
            this.Controls.SetChildIndex(this.cmbCategory, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodeUser;
        private System.Windows.Forms.ComboBox cmbSpecies;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.ComboBox cmbRank;
        private System.Windows.Forms.ComboBox cmbPlanet;
        private System.Windows.Forms.ComboBox cmbCategory;
    }
}