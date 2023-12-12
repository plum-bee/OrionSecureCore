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

        private const string DEFAULT_PASS = "12345aA";
        private SWDatabaseConnection connectionComponent;
        private HashUser hashUser;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtUserLogin.Text;
            string password = txtPasswordLogin.Text;

            string query = $"SELECT * FROM Users WHERE Login = '{login}'";

            DataSet usersDataset = connectionComponent.RetrieveDataUsingQuery(query);

            DataTable usersTable = usersDataset.Tables[0];

            if (usersTable.Rows.Count > 0)
            {
                DataRow userRow = usersTable.Rows[0];
                string storedHash = userRow["HashCode"].ToString();

                if (IsDefaultPassword(password, storedHash))
                {
                    RestorePassword restorePasswordForm = new RestorePassword();
                    restorePasswordForm.ShowDialog();
                }
                else if (IsPasswordValid(password, storedHash))
                {
                    MessageBox.Show("Login successful");
                }
                else
                {
                    ShowLoginFailedMessage();
                }
            }
            else
            {
                ShowLoginFailedMessage();
            }
        }

        private bool IsDefaultPassword(string password, string storedHash)
        {
            return storedHash == DEFAULT_PASS && password == DEFAULT_PASS;
        }

        private bool IsPasswordValid(string password, string storedHash)
        {
            password = hashUser.validatePassword(password);
            return password == storedHash;
        }

        private void ShowLoginFailedMessage()
        {
            MessageBox.Show("Login Failed, Try Again Please.");
        }


    }
}
