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
    public partial class SwCodi : UserControl
    {
        public SwCodi()
        {
            InitializeComponent();
        }

        private string _tableName;
        private string _codeName;
        private string _descriptionName;
        private string _idName;
        private string _formCs;
        private string _classCs;
        private string _controlId;
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

        public string FormCs
        {
            get { return _formCs; }
            set { _formCs = value; }
        }

        public string ClassCs
        {
            get { return _classCs; }
            set { _classCs = value; }
        }

        public string ControlId
        {
            get { return _controlId; }
            set { _controlId = value; }
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            ValidateCode();
        }

        public void ValidateCode()
        {

        }
    }
}
