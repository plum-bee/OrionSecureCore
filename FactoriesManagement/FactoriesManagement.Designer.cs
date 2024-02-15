
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactories)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFactories
            // 
            this.dgvFactories.AllowUserToAddRows = false;
            this.dgvFactories.AllowUserToDeleteRows = false;
            this.dgvFactories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFactories.Location = new System.Drawing.Point(14, 208);
            this.dgvFactories.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvFactories.Name = "dgvFactories";
            this.dgvFactories.ReadOnly = true;
            this.dgvFactories.RowHeadersWidth = 51;
            this.dgvFactories.RowTemplate.Height = 24;
            this.dgvFactories.Size = new System.Drawing.Size(1140, 374);
            this.dgvFactories.TabIndex = 0;
            // 
            // swTextboxDesc
            // 
            this.swTextboxDesc.AllowEmpty = false;
            this.swTextboxDesc.ControlName = null;
            this.swTextboxDesc.DefaultColor = System.Drawing.SystemColors.Window;
            this.swTextboxDesc.FocusColor = System.Drawing.Color.Yellow;
            this.swTextboxDesc.IsForeignKey = false;
            this.swTextboxDesc.Location = new System.Drawing.Point(239, 47);
            this.swTextboxDesc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.swTextboxDesc.Name = "swTextboxDesc";
            this.swTextboxDesc.Size = new System.Drawing.Size(243, 26);
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
            this.swTextboxCode.Location = new System.Drawing.Point(15, 47);
            this.swTextboxCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.swTextboxCode.Name = "swTextboxCode";
            this.swTextboxCode.Size = new System.Drawing.Size(151, 26);
            this.swTextboxCode.TabIndex = 1;
            this.swTextboxCode.Tag = "codeFactory";
            this.swTextboxCode.TextType = SWUserControls.SwTextbox.SwTextType.Text;
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Fira Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(1069, 160);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 40);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnAdd
            // 
            this.btnLoad.Font = new System.Drawing.Font("Fira Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(15, 160);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnLoad.Font = new System.Drawing.Font("Fira Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(124, 160);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 40);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Description";
            // 
            // frmFactoriesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 596);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.swTextboxDesc);
            this.Controls.Add(this.swTextboxCode);
            this.Controls.Add(this.dgvFactories);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

