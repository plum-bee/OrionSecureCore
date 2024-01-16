using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLibrary;

namespace DataAccess
{
    public class DBConnection : DatabaseConnection
    {

    }

    public partial class BaseForm : Form
    {
        protected readonly DBConnection dbConnection;
        private DataSet _dataSet;
        private bool _isNew;
        private string _tableToLoad;
        private string _query;

        public BaseForm()
        {
            InitializeComponent();
            dbConnection = new DBConnection();
        }

        public void SetTableName(string tableName)
        {
            _tableToLoad = tableName;
        }

        public void SetQuery(string query)
        {
            _query = query;
        }

        private void FetchData()
        {
            _dataSet = new DataSet();
            _dataSet = dbConnection.RetrieveAllDataFromTable(_tableToLoad);
            dgvTable.DataSource = _dataSet.Tables[0];

            BindTextBoxesToData();
            CustomizeDataGridView();
        }

        private void BindTextBoxesToData()
        {
            foreach (TextBox textBox in this.Controls.OfType<TextBox>())
            {
                textBox.DataBindings.Clear();
                textBox.DataBindings.Add("Text", _dataSet.Tables[0], textBox.Tag.ToString());
                textBox.Validated += OnTextBoxValidate;
            }
        }

        private void OnTextBoxValidate(object sender, EventArgs e)
        {
            ((TextBox)sender).DataBindings[0].BindingManagerBase.EndCurrentEdit();
        }

        private void UpdateTable()
        {
            if (_isNew)
            {
                InsertNewRowFromTextBoxes();
            }


            dbConnection.UpdateData(_query, _dataSet);

            FetchData();
            _isNew = false;
        }

        private void InsertNewRowFromTextBoxes()
        {
            DataRow dataRow = _dataSet.Tables[0].NewRow();

            foreach (TextBox textBox in this.Controls.OfType<TextBox>())
            {
                dataRow[textBox.Tag.ToString()] = textBox.Text;
            }

            _dataSet.Tables[0].Rows.Add(dataRow);
        }

        private void ClearTextBoxes()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.DataBindings.Clear();
                    textBox.Clear();
                    textBox.Validated -= OnTextBoxValidate;
                }
            }
        }

        protected virtual void CustomizeDataGridView()
        {

        }

        protected DataGridView MyTable
        {
            get { return dgvTable; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _isNew = true;
            ClearTextBoxes();
        }

        private void btnImportData_Click(object sender, EventArgs e)
        {
            FetchData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }
    }
}
