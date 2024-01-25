using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace SWUserControls
{
    public partial class FormLauncher : UserControl
    {

        private string _classe;
        private string _form;
        private string _descripcio = "Default";
        private Panel _displayPanel;

        public Panel DisplayPanel
        {
            get { return _displayPanel; }
            set { _displayPanel = value; }
        }
        public Image PictureBoxImage
        {
            get { return ptrIcon.Image; }
            set { 
                ptrIcon.Image = value;
                ptrIcon.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        public string Classe
        {
            get { return _classe; }
            set { _classe = value; }
        }

        public string Form
        {
            get { return _form; }
            set { _form = value; }
        }

        public string Descripcio
        {
            get { return _descripcio; }
            set { _descripcio = value; }
        }

        public FormLauncher()
        {
            InitializeComponent();
        }

        private void pnlColor_Paint(object sender, PaintEventArgs e)
        {
            Color col = Color.White;
            ButtonBorderStyle bbs = ButtonBorderStyle.Solid;
            int grosor = 1; 

            ControlPaint.DrawBorder(e.Graphics, pnlLauncher.ClientRectangle, col, grosor, bbs, col, grosor, bbs, col, grosor, bbs, col, grosor, bbs);
        }


        private void btnLauncher_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Classe) && !string.IsNullOrWhiteSpace(Form))
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(Classe + ".dll");

                    Type formType = assembly.GetType(Classe + "." + Form);

                    if (formType != null && formType.IsSubclassOf(typeof(Form)))
                    {
                        Form form = (Form)Activator.CreateInstance(formType);
                        form.Text = Descripcio;

                        if (DisplayPanel != null)
                        {
                            DisplayPanel.Controls.Clear(); 
                            form.TopLevel = false;
                            form.FormBorderStyle = FormBorderStyle.FixedSingle;
                            form.Dock = DockStyle.Fill;
                            DisplayPanel.Controls.Add(form);
                            form.BringToFront();
                            form.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Formulario no encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir el formulario: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Classe o Form no definidos.");
            }
        }

        private void FormLauncher_Load(object sender, EventArgs e)
        {
            lblDesc.Text = Descripcio;
            ptrIcon.Image = PictureBoxImage;
        }

        private void ptrIcon_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Classe) && !string.IsNullOrWhiteSpace(Form))
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(Classe + ".dll");

                    Type formType = assembly.GetType(Classe + "." + Form);

                    if (formType != null && formType.IsSubclassOf(typeof(Form)))
                    {
                        Form form = (Form)Activator.CreateInstance(formType);
                        form.Text = Descripcio;

                        if (DisplayPanel != null)
                        {
                            DisplayPanel.Controls.Clear();
                            form.TopLevel = false;
                            form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                            form.Dock = DockStyle.Fill;
                            DisplayPanel.Controls.Add(form);
                            form.BringToFront();
                            form.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Formulario no encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir el formulario: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Classe o Form no definidos.");
            }
        }
    }
}
