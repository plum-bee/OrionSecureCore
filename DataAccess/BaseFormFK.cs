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
    public partial class BaseFormFK : BaseForm
    {
        public class TableData
        {
            public string TableName { get; set; }
            public int ForeignKeyId { get; set; }
            public string DisplayColumn { get; set; }
        }

        protected override void FetchData()
        {
            base.FetchData();

     
            DataSet fkDataSet = new DataSet();
            fkDataSet = DBConnection.RetrieveAllDataFromTable(_fkTableToLoad);

           
            comboBoxSpecies.DataSource = fkDataSet.Tables[0];
            comboBoxSpecies.DisplayMember = "DescSpecie"; 
            comboBoxSpecies.ValueMember = "idSpecie"; 

   
            comboBoxSpecies.DataBindings.Add("SelectedValue", _dataSet.Tables[0], "idSpecie");
        }
    }
}