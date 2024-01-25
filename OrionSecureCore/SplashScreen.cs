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
    public partial class SplashScreen : Form
    {

        public SplashScreen()
        {
            InitializeComponent();
        }

        int _count = 0;
        private void tmrSplash_Tick(object sender, EventArgs e)
        {

            _count++;
            if (_count > 2)
            {
                tmrSplash.Enabled = false;
                LoginScreen lgn = new LoginScreen();
                lgn.Show();
                this.Hide();

            }
            else
            {
                pgbSplash.Value += 50;
            }
        }
    }
}
