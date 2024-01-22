using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DataAccess
{
    public partial class BaseFormFK : BaseForm
    {
        private DataSet _speciesDataSet;
        private DataSet _planetsDataSet;
        private DataSet _adaptedDataSet;

        public BaseFormFK() : base()
        {
            _speciesDataSet = new DataSet();
            _planetsDataSet = new DataSet();
            _adaptedDataSet = new DataSet();
        }

        protected override void FetchData()
        {
            _dataSet = new DataSet();
            _dataSet = dbConnection.RetrieveAllDataFromTable(_tableToLoad);
            MyTable.DataSource = _dataSet.Tables[0];

            _speciesDataSet = dbConnection.RetrieveAllDataFromTable("SPECIES");
            _planetsDataSet = dbConnection.RetrieveAllDataFromTable("PLANETS");

            UpdateDataSetForeignKey();
            BindDataToFields();
        }


        private void UpdateDataSetForeignKey()
        {
            if (_adaptedDataSet.Tables.Count > 0)
            {
                _adaptedDataSet.Tables.Clear();
            }

            DataTable copyTable = _dataSet.Tables[0].Clone();

            copyTable.Columns["idSpecie"].DataType = typeof(string);
            copyTable.Columns["idPlanet"].DataType = typeof(string);

            foreach (DataRow originalRow in _dataSet.Tables[0].Rows)
            {
                DataRow newRow = copyTable.NewRow();
                foreach (DataColumn column in _dataSet.Tables[0].Columns)
                {
                    if (column.ColumnName != "idSpecie" && column.ColumnName != "idPlanet")
                    {
                        newRow[column.ColumnName] = originalRow[column];
                    }
                }

                newRow["idSpecie"] = GetColumnValue(_speciesDataSet, originalRow, "idSpecie", "DescSpecie");
                newRow["idPlanet"] = GetColumnValue(_planetsDataSet, originalRow, "idPlanet", "DescPlanet");

                copyTable.Rows.Add(newRow);
            }

            _adaptedDataSet.Tables.Add(copyTable);
            MyTable.DataSource = _adaptedDataSet.Tables[0];
        }

        protected override void BindDataToFields()
        {
            foreach (TextBox textBox in this.Controls.OfType<TextBox>())
            {
                if (textBox.Tag != null)
                {
                    textBox.DataBindings.Clear();
                    textBox.DataBindings.Add("Text", _adaptedDataSet.Tables[0], textBox.Tag.ToString());
                    textBox.Validated += OnTextBoxValidate;
                }
            }
        }

        private string GetColumnValue(DataSet lookupDataSet, DataRow row, string idColumn, string columnValue)
        {
            if (row[idColumn] != DBNull.Value)
            {
                DataRow[] foundRows = lookupDataSet.Tables[0].Select($"{idColumn} = {row[idColumn]}");
                if (foundRows.Length > 0)
                {
                    return foundRows[0][columnValue].ToString();
                }
            }
            return "Unknown";
        }
    }
}
