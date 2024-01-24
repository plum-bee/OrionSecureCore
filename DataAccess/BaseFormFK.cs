using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DataAccess
{
    public class ForeignKeyInfo
    {
        public string ForeignKeyColumn { get; }
        public string DisplayColumn { get; }
        public DataTable ForeignKeyData { get; }

        public ForeignKeyInfo(string foreignKeyColumn, string displayColumn, DataTable foreignKeyData)
        {
            ForeignKeyColumn = foreignKeyColumn;
            DisplayColumn = displayColumn;
            ForeignKeyData = foreignKeyData;
        }
    }

    public partial class BaseFormFK : BaseForm
    {
        private Dictionary<string, ForeignKeyInfo> _foreignKeys;

        public BaseFormFK() : base()
        {
            _foreignKeys = new Dictionary<string, ForeignKeyInfo>();
        }

        public void AddForeignKeyMapping(string tableName, string foreignKeyColumn, string displayColumn)
        {
            if (!_foreignKeys.ContainsKey(foreignKeyColumn))
            {
                try
                {
                    var dataSet = dbConnection.RetrieveAllDataFromTable(tableName);
                    _foreignKeys.Add(foreignKeyColumn, new ForeignKeyInfo(foreignKeyColumn, displayColumn, dataSet.Tables[0]));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        protected override void FetchData()
        {
            base.FetchData();
            BindAllForeignKeyComboBoxes();
        }

        private void BindAllForeignKeyComboBoxes()
        {
            foreach (ComboBox comboBox in this.Controls.OfType<ComboBox>())
            {
                if (comboBox.Tag != null && _foreignKeys.ContainsKey(comboBox.Tag.ToString()))
                {
                    BindComboBox(comboBox, _foreignKeys[comboBox.Tag.ToString()]);
                }
            }
        }

        private void BindComboBox(ComboBox comboBox, ForeignKeyInfo fkInfo)
        {
            comboBox.DataSource = fkInfo.ForeignKeyData;
            comboBox.DisplayMember = fkInfo.DisplayColumn;
            comboBox.ValueMember = fkInfo.ForeignKeyColumn;
            comboBox.DataBindings.Clear();
            comboBox.DataBindings.Add("SelectedValue", _dataSet.Tables[0], fkInfo.ForeignKeyColumn, true, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
