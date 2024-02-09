
namespace OrionSecureCore
{
    partial class MainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.tmr1 = new System.Windows.Forms.Timer(this.components);
            this.btnMenu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlOrders = new SWUserControls.FormLauncher();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlUsers = new SWUserControls.FormLauncher();
            this.pnlSpecies = new SWUserControls.FormLauncher();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmr1
            // 
            this.tmr1.Tick += new System.EventHandler(this.tmr1_Tick);
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.BlueViolet;
            this.btnMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMenu.Image")));
            this.btnMenu.Location = new System.Drawing.Point(9, 9);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(38, 40);
            this.btnMenu.TabIndex = 2;
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BlueViolet;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1352, 52);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1162, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(45)))), ((int)(((byte)(145)))));
            this.pnlMenu.Controls.Add(this.pnlOrders);
            this.pnlMenu.Controls.Add(this.pnlUsers);
            this.pnlMenu.Controls.Add(this.pnlSpecies);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 52);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(327, 716);
            this.pnlMenu.TabIndex = 4;
            // 
            // pnlOrders
            // 
            this.pnlOrders.Classe = "FactoriesManagement";
            this.pnlOrders.Descripcio = "Default";
            this.pnlOrders.DisplayPanel = this.panel3;
            this.pnlOrders.Form = "frmFactoriesManagement";
            this.pnlOrders.Location = new System.Drawing.Point(0, 466);
            this.pnlOrders.Name = "pnlOrders";
            this.pnlOrders.PictureBoxImage = null;
            this.pnlOrders.Size = new System.Drawing.Size(426, 180);
            this.pnlOrders.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(16)))), ((int)(((byte)(51)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(327, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1025, 716);
            this.panel3.TabIndex = 5;
            // 
            // pnlUsers
            // 
            this.pnlUsers.Classe = "UserManagement";
            this.pnlUsers.Descripcio = "Users";
            this.pnlUsers.DisplayPanel = this.panel3;
            this.pnlUsers.Form = "UserManagement";
            this.pnlUsers.Location = new System.Drawing.Point(0, 266);
            this.pnlUsers.Name = "pnlUsers";
            this.pnlUsers.PictureBoxImage = ((System.Drawing.Image)(resources.GetObject("pnlUsers.PictureBoxImage")));
            this.pnlUsers.Size = new System.Drawing.Size(321, 194);
            this.pnlUsers.TabIndex = 3;
            // 
            // pnlSpecies
            // 
            this.pnlSpecies.Classe = "SpeciesManagement";
            this.pnlSpecies.Descripcio = "Species";
            this.pnlSpecies.DisplayPanel = this.panel3;
            this.pnlSpecies.Form = "SpeciesManagement";
            this.pnlSpecies.Location = new System.Drawing.Point(0, 78);
            this.pnlSpecies.Name = "pnlSpecies";
            this.pnlSpecies.PictureBoxImage = ((System.Drawing.Image)(resources.GetObject("pnlSpecies.PictureBoxImage")));
            this.pnlSpecies.Size = new System.Drawing.Size(321, 194);
            this.pnlSpecies.TabIndex = 2;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1352, 768);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 50);
            this.Name = "MainScreen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmr1;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel panel3;
        private SWUserControls.FormLauncher pnlUsers;
        private SWUserControls.FormLauncher pnlSpecies;
        private System.Windows.Forms.PictureBox pictureBox1;
        private SWUserControls.FormLauncher pnlOrders;
    }
}

