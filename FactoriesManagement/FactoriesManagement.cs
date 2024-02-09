using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactoriesManagement
{
    public partial class frmFactoriesManagement : Form
    {
        private FactoriesEntities db = new FactoriesEntities();
        private List<Factory> factories;
        private Boolean isNew = false;

        public frmFactoriesManagement()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                factories = (from f in db.Factories
                    select f).ToList();

                dgvFactories.DataSource = factories;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}");
            }
        }

        protected virtual void BindDataToFields()
        {
            foreach (var textBox in this.Controls.OfType<TextBox>())
            {
                if (textBox.Tag == null) continue;
                textBox.DataBindings.Clear();
                textBox.DataBindings.Add("Text", factories, textBox.Tag.ToString());
                textBox.Validated += OnTextBoxValidate;
            }
        }

        protected void OnTextBoxValidate(object sender, EventArgs e)
        {
            ((TextBox)sender).DataBindings[0].BindingManagerBase.EndCurrentEdit();
        }

        protected virtual void CustomizeDataGridView()
        {
            dgvFactories.Columns["idFactory"].Visible = false;
            dgvFactories.Columns["codeFactory"].HeaderText = "Code";
            dgvFactories.Columns["DescFactory"].HeaderText = "Description";
        }

        private void ClearFields()
        {
            foreach (Control control in this.Controls)
            {
                if (!(control is TextBox textBox)) continue;
                textBox.DataBindings.Clear();
                textBox.Clear();
                textBox.Validated -= OnTextBoxValidate;
            }
        }

        private void UpdateTable()
        {
            if (isNew)
            {
                Factory newFactory = new Factory
                {
                    codeFactory = swTextboxCode.Text,
                    DescFactory = swTextboxDesc.Text
                };
                db.Factories.Add(newFactory);
            }

            db.SaveChanges();
            isNew = false; 
            LoadData(); 
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            BindDataToFields();
            CustomizeDataGridView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearFields();
            isNew = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }
    }
}
