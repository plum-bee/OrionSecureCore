using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OrionSecureCore
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
            connectionComponent = new SWDatabaseConnection();
        }

        private string login;
        private string password;

        private SWDatabaseConnection connectionComponent;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login = txtUserLogin.Text;
            password = txtPasswordLogin.Text;

            string query = "SELECT * FROM Users WHERE Login = 'guti'";
            SqlParameter[] parameters = {
                new SqlParameter("@Login", SqlDbType.VarChar) { Value = login }
            };

            DataSet usersDataset = connectionComponent.RetrieveDataUsingQuery(query);

            DataTable usersTable = usersDataset.Tables[0];

            if (usersTable.Rows.Count > 0)
            {
                MessageBox.Show("Login successful");
            }
            else
            {
                // No user with the entered login found
                MessageBox.Show("Login failed. User not found");
            }




        }

    }
}
