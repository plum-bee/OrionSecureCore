using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLibrary;

namespace OrionSecureCore
{
    public partial class RestorePassword : Form
    {
        public RestorePassword()
        {
            InitializeComponent();
            _hashUser = new HashUser();
            _connectionComponent = new SwDatabaseConnection();
        }

        private HashUser _hashUser;
        private SwDatabaseConnection _connectionComponent;
        private string _salt;
        private string _login;

        public string Login
        {
            set { _login = value; }
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string repeatedPassword = txtRepeatedPassword.Text;
            string hashedPassword;
            
            if (string.Equals(password, repeatedPassword))
            {
                _salt = _hashUser.CreateSalt();

                hashedPassword = _hashUser.CreatePassword(password, _salt);

                UpdateSaltInDatabase(_login, _salt);

                UpdatePasswordInDatabase(_login, hashedPassword);

                MessageBox.Show("Password Setted Successfully!");

                this.Close();
                this.Dispose();
            }
        }

        private void UpdateSaltInDatabase(string login, string salt)
        {
            string updateQuery = $"UPDATE Users SET Salt = '{salt}' WHERE Login = '{login}'";

            _connectionComponent.ExecuteSqlNonQuery(updateQuery);
        }

        private void UpdatePasswordInDatabase(string login, string password)
        {
            string updateQuery = $"UPDATE Users SET Password = '{password}' WHERE Login = '{login}'";

            _connectionComponent.ExecuteSqlNonQuery(updateQuery);

        }
    }
}
