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
        protected DataSet _dataSet;
        private bool _isNew;
        protected string _tableToLoad;
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

        protected void SetQuery(string query)
        {
            _query = query;
        }

        protected virtual void FetchData()
        {
            _dataSet = new DataSet();
            _dataSet = dbConnection.RetrieveAllDataFromTable(_tableToLoad);
            dgvTable.DataSource = _dataSet.Tables[0];

            BindDataToFields();
            CustomizeDataGridView();
        }

        protected virtual void BindDataToFields()
        {
            foreach (TextBox textBox in this.Controls.OfType<TextBox>())
            {
                if (textBox.Tag != null)
                {
                    textBox.DataBindings.Clear();
                    textBox.DataBindings.Add("Text", _dataSet.Tables[0], textBox.Tag.ToString());
                    textBox.Validated += OnTextBoxValidate;
                }
            }
        }

        protected void OnTextBoxValidate(object sender, EventArgs e)
        {
            ((TextBox)sender).DataBindings[0].BindingManagerBase.EndCurrentEdit();
        }

        protected virtual void UpdateTable()
        {
            if (_isNew)
            {
                InsertRowFromFields();
            }


            dbConnection.UpdateData(_query, _dataSet);

            FetchData();
            _isNew = false;
        }

        private void InsertRowFromFields()
        {
            DataRow dataRow = _dataSet.Tables[0].NewRow();

            foreach (TextBox textBox in this.Controls.OfType<TextBox>())
            {
                dataRow[textBox.Tag.ToString()] = textBox.Text;
            }

            _dataSet.Tables[0].Rows.Add(dataRow);
        }

        private void ClearFields()
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
            ClearFields();
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
