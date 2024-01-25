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
            _connectionComponent = new SwDatabaseConnection();
            _hashUser = new HashUser();
        }

        private const string DefaultPass = "12345aA";
        private SwDatabaseConnection _connectionComponent;
        private HashUser _hashUser;
        private string _login;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _login = txtUserLogin.Text;
            string password = txtPasswordLogin.Text;

            Dictionary<string, string> fieldValues = new Dictionary<string, string>
                {
                   {"Login", _login}
                };

            SqlCommand command = _connectionComponent.GenerateQuery("Users", fieldValues);
            DataSet usersDataset = _connectionComponent.RetrieveDataUsingQuery(command);

            DataTable usersTable = usersDataset.Tables[0];

            if (usersTable.Rows.Count > 0)
            {
                DataRow userRow = usersTable.Rows[0];
                string storedHash = userRow["Password"].ToString();

                if (IsDefaultPassword(password, storedHash))
                {
                    RestorePassword restorePasswordForm = new RestorePassword();
                    restorePasswordForm.Login = _login;
                    restorePasswordForm.ShowDialog();
                }
                else if (IsPasswordValid(password, storedHash))
                {
                    MainScreenCopy mainScreen = new MainScreenCopy();

                    this.Hide();

                    mainScreen.Show();
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
            return storedHash == DefaultPass && password == DefaultPass;
        }

        private bool IsPasswordValid(string password, string storedHash)
        {
            string salt = GetSaltFromDatabase(_login);
            password = _hashUser.ValidatePassword(password, salt);
            return password == storedHash;
        }

        private string GetSaltFromDatabase(string login)
        {
            string query = $"SELECT Salt FROM Users WHERE Login = '{login}'";

            DataSet saltDataset = _connectionComponent.RetrieveDataUsingQuery(query);

            DataTable saltTable = saltDataset.Tables[0];

            if (saltTable.Rows.Count > 0)
            {
                DataRow userRow = saltTable.Rows[0];
                return userRow["Salt"].ToString();
            }

            return null;
        }

        private void ShowLoginFailedMessage()
        {
            MessageBox.Show("Login Failed, Try Again Please.");
        }


    }
}
