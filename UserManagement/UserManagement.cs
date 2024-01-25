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
    public partial class UserManagement : BaseFormFk
    {
        public UserManagement()
        {
            InitializeComponent();
            SetTableName("USERS");
            SetQuery("SELECT * FROM USERS");

            AddForeignKeyMapping("PLANETS", "idPlanet", "DescPlanet");
            AddForeignKeyMapping("SPECIES", "idSpecie", "DescSpecie");
            AddForeignKeyMapping("USERCATEGORIES", "idUserCategory", "DescCategory");
            AddForeignKeyMapping("USERRANKs", "idUserRank", "DescRank");
        }

        protected override void CustomizeDataGridView()
        {
            base.CustomizeDataGridView();

            MyTable.Columns["idUser"].Visible = false;
            MyTable.Columns["Login"].Visible = false;
            MyTable.Columns["CodeUser"].HeaderText = "Code";
            MyTable.Columns["UserName"].HeaderText = "Username";
            MyTable.Columns["idUserRank"].Visible = false;
            MyTable.Columns["idUserCategory"].Visible = false;
            MyTable.Columns["Photo"].Visible = false;
            MyTable.Columns["idPlanet"].Visible = false;
            MyTable.Columns["idSpecie"].Visible = false;
            MyTable.Columns["Salt"].Visible = false;
            MyTable.Columns["Password"].Visible = false;
        }
    }
}
