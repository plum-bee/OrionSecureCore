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
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUserLogin.Text;
            string password = txtPasswordLogin.Text;

            // Check the hardcoded credentials
            if (user == "lumizor" && password == "lumizor")
            {
                // Hide the login form
                this.Hide();

                // Show the main app form
                MainScreen mainForm = new MainScreen();
                mainForm.Show(); 


            }
            else
            {
                MessageBox.Show("Invalid credentials. Please try again.");
                txtPasswordLogin.Clear();
            }
        }

    }
}
