﻿
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
            this.tmr1 = new System.Windows.Forms.Timer(this.components);
            this.btnMenu = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.formLauncher1 = new SWUserControls.FormLauncher();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmr1
            // 
            this.tmr1.Tick += new System.EventHandler(this.tmr1_Tick);
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(3, -1);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(57, 38);
            this.btnMenu.TabIndex = 2;
            this.btnMenu.Text = "btnMenu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.formLauncher1);
            this.pnlMenu.Location = new System.Drawing.Point(-5, 63);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(254, 452);
            this.pnlMenu.TabIndex = 3;
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Location = new System.Drawing.Point(255, 12);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(950, 535);
            this.pnlMainContent.TabIndex = 4;
            // 
            // formLauncher1
            // 
            this.formLauncher1.Classe = "SpeciesManagement.exe";
            this.formLauncher1.Descripcio = "Species";
            this.formLauncher1.Form = "SpeciesManagement";
            this.formLauncher1.Location = new System.Drawing.Point(5, 61);
            this.formLauncher1.Name = "formLauncher1";
            this.formLauncher1.PictureBoxImage = null;
            this.formLauncher1.Size = new System.Drawing.Size(426, 194);
            this.formLauncher1.TabIndex = 0;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1217, 768);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.btnMenu);
            this.Location = new System.Drawing.Point(0, 50);
            this.Name = "MainScreen";
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmr1;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlMainContent;
        private SWUserControls.FormLauncher formLauncher1;
    }
}

