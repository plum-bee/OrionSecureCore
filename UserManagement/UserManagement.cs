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
using DataAccess;

namespace UserManagement
{
    public partial class UserManagement : BaseForm
    {
        public UserManagement()
        {
            InitializeComponent();
            SetTableName("USERS");
            SetQuery("SELECT * FROM USERS");

            FetchForeignData();
        }

        protected override void CustomizeDataGridView()
        {
            base.CustomizeDataGridView();

           // MyTable.Columns["idSpecie"].Visible = false;
           // MyTable.Columns["CodeSpecie"].HeaderText = "Codi";
           // MyTable.Columns["DescSpecie"].HeaderText = "Descripcio";
        }

        private void FetchForeignData()
        {
            cmbSpecies.DataSource = dbConnection.RetrieveAllDataFromTable("Species").Tables[0];
            cmbSpecies.DisplayMember = "DescSpecie";
            cmbSpecies.ValueMember = "idSpecie";
                       
        }
    }
}
