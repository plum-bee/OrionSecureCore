
namespace OrionSecureCore
{
    partial class MainScreenCopy
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
            this.components = new System.ComponentModel.Container();
            this.tmr1 = new System.Windows.Forms.Timer(this.components);
            this.btnMenu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.formLauncher1 = new SWUserControls.FormLauncher();
            this.frmlSpecies = new SWUserControls.FormLauncher();
            this.panel1.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmr1
            // 
            this.tmr1.Tick += new System.EventHandler(this.tmr1_Tick);
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(0, 0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(57, 38);
            this.btnMenu.TabIndex = 2;
            this.btnMenu.Text = "btnMenu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1352, 100);
            this.panel1.TabIndex = 3;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.formLauncher1);
            this.pnlMenu.Controls.Add(this.frmlSpecies);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 100);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(295, 668);
            this.pnlMenu.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(295, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1057, 668);
            this.panel3.TabIndex = 5;
            // 
            // formLauncher1
            // 
            this.formLauncher1.Classe = "SpeciesManagement";
            this.formLauncher1.Descripcio = "Users";
            this.formLauncher1.DisplayPanel = this.panel3;
            this.formLauncher1.Form = "SpeciesManagement";
            this.formLauncher1.Location = new System.Drawing.Point(0, 195);
            this.formLauncher1.Name = "formLauncher1";
            this.formLauncher1.PictureBoxImage = null;
            this.formLauncher1.Size = new System.Drawing.Size(456, 194);
            this.formLauncher1.TabIndex = 3;
            // 
            // frmlSpecies
            // 
            this.frmlSpecies.Classe = "SpeciesManagement";
            this.frmlSpecies.Descripcio = "Species";
            this.frmlSpecies.DisplayPanel = this.panel3;
            this.frmlSpecies.Form = "SpeciesManagement";
            this.frmlSpecies.Location = new System.Drawing.Point(0, 21);
            this.frmlSpecies.Name = "frmlSpecies";
            this.frmlSpecies.PictureBoxImage = null;
            this.frmlSpecies.Size = new System.Drawing.Size(456, 194);
            this.frmlSpecies.TabIndex = 2;
            // 
            // MainScreenCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1352, 768);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 50);
            this.Name = "MainScreenCopy";
            this.panel1.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmr1;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel panel3;
        private SWUserControls.FormLauncher formLauncher1;
        private SWUserControls.FormLauncher frmlSpecies;
    }
}

