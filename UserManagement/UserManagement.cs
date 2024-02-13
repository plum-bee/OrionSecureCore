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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;
using System.Data.SqlClient;

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
            MyTable.Columns["idUserRank"].Visible = false;
            MyTable.Columns["idUserCategory"].Visible = false;
            MyTable.Columns["Photo"].Visible = false;
            MyTable.Columns["idPlanet"].Visible = false;
            MyTable.Columns["idSpecie"].Visible = false;
            MyTable.Columns["Salt"].Visible = false;
            MyTable.Columns["Password"].Visible = false;
            MyTable.Columns["CodeUser"].HeaderText = "Code";
            MyTable.Columns["UserName"].HeaderText = "Username";
            MyTable.Columns["DescPlanet"].HeaderText = "Planet";
            MyTable.Columns["DescSpecie"].HeaderText = "Specie";
            MyTable.Columns["DescCategory"].HeaderText = "Category";
            MyTable.Columns["DescRank"].HeaderText = "Rank";
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                // Load the report
                var report = "UsersReport.rpt";
                var reportDocument = new ReportDocument();
                reportDocument.Load(report);

                // Show the report
                var reportViewerForm = new Form();
                var crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                crystalReportViewer.Dock = DockStyle.Fill;
                reportViewerForm.Controls.Add(crystalReportViewer);

                crystalReportViewer.ReportSource = reportDocument;
                reportViewerForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying report: {ex.Message}");
            }
        }
    }
}
