using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace OrionSecureCore
{
    public partial class MainScreen : Form
    {
        private bool _pnlOpen = false;

        public MainScreen()
        {

            InitializeComponent();

            pnlMenu.Width = 75;
            tmrSplash.Interval = 30; 
            tmrSplash.Tick += tmr1_Tick;
            
        }

        private void pnlColor_Paint(object sender, PaintEventArgs e)
        {
            Color col = Color.White;
            ButtonBorderStyle bbs = ButtonBorderStyle.Solid;
            int grosor = 1;

            ControlPaint.DrawBorder(e.Graphics, pnlFTP.ClientRectangle, col, grosor, bbs, col, grosor, bbs, col, grosor, bbs, col, grosor, bbs);
        }
        private void tmr1_Tick(object sender, EventArgs e)
        {
            if (_pnlOpen)
            {
                pnlMenu.Width -= 10;
                if (pnlMenu.Width <= 75)
                {
                    tmrSplash.Stop();
                    _pnlOpen = false;
                }
            }
            else
            {
                pnlMenu.Width += 10;
                if (pnlMenu.Width >= 250)
                {
                    tmrSplash.Stop();
                    _pnlOpen = true;
                }
            }
        }

        private void btnFTP_Click(object sender, EventArgs e)
        {
            string executablePath = "FTPDownload.exe";


            if (System.IO.File.Exists(executablePath))
            {
                try
                {
                    Process.Start(executablePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to start. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"The console file '{executablePath}' was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnMenu_Click(object sender, EventArgs e)
        {
            tmrSplash.Start();
        }

    }
}
