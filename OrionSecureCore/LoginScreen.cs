﻿using System;
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
            connectionComponent = new SwDatabaseConnection();
            hashUser = new HashUser();
        }

        private const string DEFAULT_PASS = "12345aA";
        private SwDatabaseConnection connectionComponent;
        private HashUser hashUser;
        private string login;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login = txtUserLogin.Text;
            string password = txtPasswordLogin.Text;

            var parameters = new Dictionary<string, string>
            {
                {"Login", login}
            };

            SqlCommand command = connectionComponent.GenerateQuery("Users", parameters);
            DataSet usersDataset = connectionComponent.RetrieveDataUsingQuery(command);
            DataTable usersTable = usersDataset.Tables[0];

            if (usersTable.Rows.Count > 0)
            {
                DataRow userRow = usersTable.Rows[0];
                string storedHash = userRow["Password"].ToString();

                if (IsDefaultPassword(password, storedHash))
                {
                    RestorePassword restorePasswordForm = new RestorePassword();
                    restorePasswordForm.Login = login;
                    restorePasswordForm.ShowDialog();
                }
                else if (IsPasswordValid(password, storedHash))
                {

                    MainScreen mainScreen = new MainScreen();

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
            return storedHash == DEFAULT_PASS && password == DEFAULT_PASS;
        }

        private bool IsPasswordValid(string password, string storedHash)
        {
            string salt = GetSaltFromDatabase(login);
            password = hashUser.ValidatePassword(password, salt);
            return password == storedHash;
        }

        private string GetSaltFromDatabase(string login)
        {
            var parameters = new Dictionary<string, string>
            {
                {"Login", login}
            };

            SqlCommand command = connectionComponent.GenerateQuery("Users", parameters);
            DataSet saltDataset = connectionComponent.RetrieveDataUsingQuery(command);
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
