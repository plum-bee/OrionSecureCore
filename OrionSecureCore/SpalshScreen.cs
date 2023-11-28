﻿using System;
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
    public partial class SplashScreen : Form
    {

        public SplashScreen()
        {
            InitializeComponent();
        }

        int count = 0;
        private void tmrSplash_Tick(object sender, EventArgs e)
        {

            count++;
            if (count > 5)
            {
                tmrSplash.Enabled = false;
                LoginScreen lgn = new LoginScreen();
                lgn.Show();
                this.Hide();

            }
            else
            {
                pgbSplash.Value += 20;
            }
        }
    }
}