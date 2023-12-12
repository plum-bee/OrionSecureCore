using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrionSecureCore
{
    public partial class RestorePassword : Form
    {
        public RestorePassword()
        {
            InitializeComponent();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string repeatedPassword = txtRepeatedPassword.Text;

            if (string.Equals(password, repeatedPassword))
            {
                pcbCheck.Image = Image.FromFile(@"..\images\check-mark.png");
            }
            else
            {
                pcbCheck.Image = null;
            }
        }
    }
}
