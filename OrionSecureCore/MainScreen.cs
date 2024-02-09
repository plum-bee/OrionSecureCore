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
            tmr1.Interval = 30;
            tmr1.Tick += tmr1_Tick;
            
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
                    tmr1.Stop();
                    _pnlOpen = false;
                }
            }
            else
            {
                pnlMenu.Width += 10;
                if (pnlMenu.Width >= 250)
                {
                    tmr1.Stop();
                    _pnlOpen = true;
                }
            }
        }

        private void btnFTP_Click(object sender, EventArgs e)
        {
            Process.Start("FTPDownload.exe", "arguments");
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            tmr1.Start();
        }

    }
}
