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
    public class DbConnection : DatabaseConnection
    {

    }

    public partial class BaseForm : Form
    {
        protected readonly DbConnection DbConnection;
        protected DataSet DataSet;
        private bool _isNew;
        protected string TableToLoad;
        private string _query;

        public BaseForm()
        {
            InitializeComponent();
            DbConnection = new DbConnection();
        }

        public void SetTableName(string tableName)
        {
            TableToLoad = tableName;
        }

        protected void SetQuery(string query)
        {
            _query = query;
        }

        protected virtual void FetchData()
        {
            DataSet = new DataSet();
            DataSet = DbConnection.RetrieveAllDataFromTable(TableToLoad);
            MyTable.DataSource = DataSet.Tables[0];

            BindDataToFields();
            CustomizeDataGridView();
        }

        protected virtual void BindDataToFields()
        {
            foreach (var textBox in this.Controls.OfType<TextBox>())
            {
                if (textBox.Tag == null) continue;
                textBox.DataBindings.Clear();
                textBox.DataBindings.Add("Text", DataSet.Tables[0], textBox.Tag.ToString());
                textBox.Validated += OnTextBoxValidate;
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


            DbConnection.UpdateData(_query, DataSet);

            FetchData();
            _isNew = false;
        }

        protected virtual void InsertRowFromFields()
        {
            var dataRow = DataSet.Tables[0].NewRow();

            foreach (var textBox in this.Controls.OfType<TextBox>())
            {
                dataRow[textBox.Tag.ToString()] = textBox.Text;
            }

            DataSet.Tables[0].Rows.Add(dataRow);
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

        protected virtual void CustomizeDataGridView()
        {

        }

        protected DataGridView MyTable { get; private set; }

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
