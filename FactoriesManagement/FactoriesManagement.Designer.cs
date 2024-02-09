
namespace FactoriesManagement
{
    partial class frmFactoriesManagement
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
            this.dgvFactories = new System.Windows.Forms.DataGridView();
            this.swTextboxDesc = new SWUserControls.SwTextbox();
            this.swTextboxCode = new SWUserControls.SwTextbox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactories)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFactories
            // 
            this.dgvFactories.AllowUserToAddRows = false;
            this.dgvFactories.AllowUserToDeleteRows = false;
            this.dgvFactories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFactories.Location = new System.Drawing.Point(12, 166);
            this.dgvFactories.Name = "dgvFactories";
            this.dgvFactories.ReadOnly = true;
            this.dgvFactories.RowHeadersWidth = 51;
            this.dgvFactories.RowTemplate.Height = 24;
            this.dgvFactories.Size = new System.Drawing.Size(1013, 299);
            this.dgvFactories.TabIndex = 0;
            // 
            // swTextboxDesc
            // 
            this.swTextboxDesc.AllowEmpty = false;
            this.swTextboxDesc.ControlName = null;
            this.swTextboxDesc.DefaultColor = System.Drawing.SystemColors.Window;
            this.swTextboxDesc.FocusColor = System.Drawing.Color.Yellow;
            this.swTextboxDesc.IsForeignKey = false;
            this.swTextboxDesc.Location = new System.Drawing.Point(186, 12);
            this.swTextboxDesc.Name = "swTextboxDesc";
            this.swTextboxDesc.Size = new System.Drawing.Size(100, 22);
            this.swTextboxDesc.TabIndex = 2;
            this.swTextboxDesc.Tag = "DescFactory";
            this.swTextboxDesc.TextType = SWUserControls.SwTextbox.SwTextType.Text;
            // 
            // swTextboxCode
            // 
            this.swTextboxCode.AllowEmpty = false;
            this.swTextboxCode.ControlName = null;
            this.swTextboxCode.DefaultColor = System.Drawing.SystemColors.Window;
            this.swTextboxCode.FocusColor = System.Drawing.Color.Yellow;
            this.swTextboxCode.IsForeignKey = false;
            this.swTextboxCode.Location = new System.Drawing.Point(13, 13);
            this.swTextboxCode.Name = "swTextboxCode";
            this.swTextboxCode.Size = new System.Drawing.Size(100, 22);
            this.swTextboxCode.TabIndex = 1;
            this.swTextboxCode.Tag = "codeFactory";
            this.swTextboxCode.TextType = SWUserControls.SwTextbox.SwTextType.Text;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(950, 137);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(13, 137);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(110, 137);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmFactoriesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 477);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.swTextboxDesc);
            this.Controls.Add(this.swTextboxCode);
            this.Controls.Add(this.dgvFactories);
            this.Name = "frmFactoriesManagement";
            this.Text = "Factories Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFactories;
        private SWUserControls.SwTextbox swTextboxCode;
        private SWUserControls.SwTextbox swTextboxDesc;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
    }
}

