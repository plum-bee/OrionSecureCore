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
            SetTableName("Species");
            SetQuery("Select * from Species");
        }
    }
}
