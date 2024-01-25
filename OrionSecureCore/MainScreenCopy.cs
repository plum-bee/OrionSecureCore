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
    public partial class MainScreenCopy : Form
    {
        private bool _pnlOpen = false;

        public MainScreenCopy()
        {

            InitializeComponent();

            pnlMenu.Width = 75;
            tmr1.Interval = 30; // Cambia esto para ajustar la velocidad de la animación
            tmr1.Tick += tmr1_Tick;
            
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
                if (pnlMenu.Width >= 200)
                {
                    tmr1.Stop();
                    _pnlOpen = true;
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            tmr1.Start();
        }

    }
}
