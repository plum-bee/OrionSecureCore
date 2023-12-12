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
            hashUser = new HashUser();
        }

        private string login;
        private string password;
        private const string DEFAULT_PASS = "12345aA";
        private SWDatabaseConnection connectionComponent;
        private HashUser hashUser;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login = txtUserLogin.Text;
            password = txtPasswordLogin.Text;

            string query = $"SELECT * FROM Users WHERE Login = '{login}'";

            DataSet usersDataset = connectionComponent.RetrieveDataUsingQuery(query);

            DataTable usersTable = usersDataset.Tables[0];

            if (usersTable.Rows.Count > 0)
            {
                DataRow userRow = usersTable.Rows[0];
                string storedHash = userRow["HashCode"].ToString();

                if (storedHash == DEFAULT_PASS)
                {

                    
                } else
                {
                    password = hashUser.validatePassword(password);
                    if (password == storedHash)
                    {
                        MessageBox.Show("Login successfull");
                    }
                }

            }
            else
            {
                MessageBox.Show("Login Failed, Try Again Please.");
            }




        }

    }
}
