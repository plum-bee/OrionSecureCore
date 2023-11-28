using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWUserControls
{
    public partial class SWCodi : UserControl
    {
        public SWCodi()
        {
            InitializeComponent();
        }

        private string _tableName;
        private string _codeName;
        private string _descriptionName;
        private string _idName;
        private string _formCS;
        private string _classCS;
        private string _controlID;
        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        public string CodeName
        {
            get { return _codeName; }
            set { _codeName = value; }
        }

        public string DescriptionName
        {
            get { return _descriptionName; }
            set { _descriptionName = value; }
        }

        public string IdName
        {
            get { return _idName; }
            set { _idName = value; }
        }

        public string FormCS
        {
            get { return _formCS; }
            set { _formCS = value; }
        }

        public string ClassCS
        {
            get { return _classCS; }
            set { _classCS = value; }
        }

        public string ControlID
        {
            get { return _controlID; }
            set { _controlID = value; }
        }

    }
}
