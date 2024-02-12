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
        private string _description = "Default";
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
        public string FormClass
        {
            get { return _classe; }
            set { _classe = value; }
        }

        public string Form
        {
            get { return _form; }
            set { _form = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public FormLauncher()
        {
            InitializeComponent();
        }

        private void LaunchForm()
        {
            if (!string.IsNullOrWhiteSpace(FormClass) && !string.IsNullOrWhiteSpace(Form))
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(FormClass + ".dll");

                    Type formType = assembly.GetType(FormClass + "." + Form);

                    if (formType != null && formType.IsSubclassOf(typeof(Form)))
                    {
                        Form form = (Form)Activator.CreateInstance(formType);
                        form.Text = Description;

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
                        MessageBox.Show("Form not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to open form: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Class and/or Form not defined.");
            }
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
            LaunchForm();
        }   

        private void FormLauncher_Load(object sender, EventArgs e)
        {
            lblDesc.Text = Description;
            ptrIcon.Image = PictureBoxImage;
        }

        private void ptrIcon_Click(object sender, EventArgs e)
        {
            LaunchForm();
        }
    }
}
