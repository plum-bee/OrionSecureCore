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

namespace UserManagement
{
    public partial class UserManagement : BaseForm
    {
        public UserManagement()
        {
            InitializeComponent();
            SetTableName("USERS");
            SetQuery("SELECT * FROM USERS");
        }
    }
}
