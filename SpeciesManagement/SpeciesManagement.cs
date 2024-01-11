using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;

namespace SpeciesManagement
{
    public partial class SpeciesManagement : BaseForm
    {
        public SpeciesManagement()
        {
            InitializeComponent();
            SetTableName("SPECIES");
            SetQuery("SELECT * FROM SPECIES");
        }

        protected override void CustomizeDataGridView()
        {
            base.CustomizeDataGridView();

            MyTable.Columns["idSpecie"].Visible = false;
            MyTable.Columns["CodeSpecie"].HeaderText = "Codi";
            MyTable.Columns["DescSpecie"].HeaderText = "Descripcio";
        }
    }
}
