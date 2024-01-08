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
    public partial class MainScreen : Form
    {
        private bool pnlOpen = false;

        public MainScreen()
        {

            InitializeComponent();

            // Configura el panel y el timer
            pnlMenu.Width = 0;
            pnlMenu.Height = this.Height;
            pnlMenu.Dock = DockStyle.Left;
            this.Controls.Add(pnlMenu);

            tmr1.Interval = 33; // Cambia esto para ajustar la velocidad de la animación
            tmr1.Tick += tmr1_Tick;
        }

        private void tmr1_Tick(object sender, EventArgs e)
        {
            if (pnlOpen)
            {
                
                pnlMenu.Width -= 10;
                if (pnlMenu.Width <= 0)
                {
                    tmr1.Stop();
                    pnlOpen = false;
                }
            }
            else
            {
                
                pnlMenu.Width += 10;
                if (pnlMenu.Width >= 200)
                {
                    tmr1.Stop();
                    pnlOpen = true;
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            tmr1.Start();
        }
    }
}
