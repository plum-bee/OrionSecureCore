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
    public partial class UserManagement : BaseFormFK
    {
        public UserManagement()
        {
            InitializeComponent();
            SetTableName("USERS");
            SetQuery("SELECT * FROM USERS");
        }

        protected override void CustomizeDataGridView()
        {
            base.CustomizeDataGridView();

            MyTable.Columns["idUser"].Visible = false;
            MyTable.Columns["CodeUser"].HeaderText = "Code";
            MyTable.Columns["UserName"].HeaderText = "Username";
            MyTable.Columns["idUserRank"].HeaderText = "Rank";
            MyTable.Columns["idUserCategory"].HeaderText = "Category";
            MyTable.Columns["Photo"].Visible = false;
            MyTable.Columns["idPlanet"].HeaderText = "Planet";
            MyTable.Columns["idSpecie"].HeaderText = "Specie";
            MyTable.Columns["Salt"].Visible = false;
            MyTable.Columns["Password"].Visible = false;
        }
    }
}
