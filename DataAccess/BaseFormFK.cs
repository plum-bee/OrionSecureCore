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

    public partial class BaseFormFk : BaseForm
    {
        protected readonly Dictionary<string, ForeignKeyInfo> _foreignKeys = new Dictionary<string, ForeignKeyInfo>();

        public void AddForeignKeyMapping(string tableName, string foreignKeyColumn, string displayColumn)
        {
            if (_foreignKeys.ContainsKey(foreignKeyColumn)) return;
            try
            {
                var dataSet = DbConnection.RetrieveAllDataFromTable(tableName);
                _foreignKeys.Add(foreignKeyColumn, new ForeignKeyInfo(foreignKeyColumn, displayColumn, dataSet.Tables[0]));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected override void FetchData()
        {
            base.FetchData();
            BindAllForeignKeyComboBoxes();
            FillDisplayColumns();
        }


        private void BindAllForeignKeyComboBoxes()
        {
            foreach (var comboBox in this.Controls.OfType<ComboBox>())
            {
                if (comboBox.Tag != null && _foreignKeys.ContainsKey(comboBox.Tag.ToString()))
                {
                    BindComboBox(comboBox, _foreignKeys[comboBox.Tag.ToString()]);
                }
            }
        }

        protected override void InsertRowFromFields()
        {
            var dataRow = DataSet.Tables[0].NewRow();

            foreach (Control control in this.Controls)
            {
                switch (control)
                {
                    case TextBox textBox when textBox.Tag != null:
                        dataRow[textBox.Tag.ToString()] = textBox.Text;
                        break;
                    case ComboBox comboBox when comboBox.Tag != null:
                        {
                            var selectedValue = comboBox.SelectedValue;
                            if (selectedValue != null)
                            {
                                dataRow[comboBox.Tag.ToString()] = selectedValue;
                            }
                            else
                            {
                                dataRow[comboBox.Tag.ToString()] = "Unknown";
                            }

                            break;
                        }
                }
            }

            DataSet.Tables[0].Rows.Add(dataRow);
        }


        private void BindComboBox(ComboBox comboBox, ForeignKeyInfo fkInfo)
        {
            comboBox.DataSource = fkInfo.ForeignKeyData;
            comboBox.DisplayMember = fkInfo.DisplayColumn;
            comboBox.ValueMember = fkInfo.ForeignKeyColumn;

            comboBox.DataBindings.Clear();
            var binding = new Binding("SelectedValue", DataSet.Tables[0], fkInfo.ForeignKeyColumn, true, DataSourceUpdateMode.OnPropertyChanged);
            comboBox.DataBindings.Add(binding);

            comboBox.SelectedIndexChanged += (sender, args) =>
            {
                comboBox.DataBindings["SelectedValue"]?.BindingManagerBase.EndCurrentEdit();
            };
        }

        protected override void CustomizeDataGridView()
        {
            base.CustomizeDataGridView();

            foreach (var fkMapping in _foreignKeys)
            {
                string columnName = fkMapping.Value.DisplayColumn;
                if (!MyTable.Columns.Contains(columnName))
                {
                    AddVirtualColumn(fkMapping.Value);
                }
            }
        }

        private void AddVirtualColumn(ForeignKeyInfo fkInfo)
        {
            DataGridViewTextBoxColumn virtualColumn = new DataGridViewTextBoxColumn
            {
                Name = fkInfo.DisplayColumn,
                HeaderText = fkInfo.DisplayColumn,
                ReadOnly = true
            };

            MyTable.Columns.Add(virtualColumn);
        }



        private void FillDisplayColumns()
        {
            foreach (DataGridViewRow row in MyTable.Rows)
            {
                if (row.IsNewRow) continue;

                foreach (var fkMapping in _foreignKeys)
                {
                    var fkValue = row.Cells[fkMapping.Key].Value;

                    if (fkValue == DBNull.Value)
                    {
                        row.Cells[fkMapping.Value.DisplayColumn].Value = string.Empty;
                        continue;
                    }

                    if (fkValue != null)
                    {
                        var displayData = fkMapping.Value.ForeignKeyData
                            .AsEnumerable()
                            .FirstOrDefault(dr => dr.Field<int>(fkMapping.Key) == Convert.ToInt32(fkValue))?[fkMapping.Value.DisplayColumn]?.ToString();

                        row.Cells[fkMapping.Value.DisplayColumn].Value = displayData;
                    }
                    else
                    {
                        row.Cells[fkMapping.Value.DisplayColumn].Value = "Unknown";
                    }
                }
            }
        }
    }
}
