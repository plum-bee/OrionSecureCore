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
            hashUser = new HashUser();
            connectionComponent = new SWDatabaseConnection();
        }

        private HashUser hashUser;
        private SWDatabaseConnection connectionComponent;
        private string salt;
        private string login;

        public string Login
        {
            set { login = value; }
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
                salt = hashUser.CreateSalt();

                hashedPassword = hashUser.CreatePassword(password, salt);

                UpdateSaltInDatabase(login, salt);

                UpdatePasswordInDatabase(login, hashedPassword);

                MessageBox.Show("Password Setted Successfully!");

                this.Close();
                this.Dispose();
            }
        }

        private void UpdateSaltInDatabase(string login, string salt)
        {
            string updateQuery = $"UPDATE Users SET Salt = '{salt}' WHERE Login = '{login}'";

            connectionComponent.ExecuteSqlNonQuery(updateQuery);
        }

        private void UpdatePasswordInDatabase(string login, string password)
        {
            string updateQuery = $"UPDATE Users SET Password = '{password}' WHERE Login = '{login}'";

            connectionComponent.ExecuteSqlNonQuery(updateQuery);

        }
    }
}
