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

        private string classe;
        private string form;
        private string descripcio = "Default";

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
            get { return classe; }
            set { classe = value; }
        }

        public string Form
        {
            get { return form; }
            set { form = value; }
        }

        public string Descripcio
        {
            get { return descripcio; }
            set { descripcio = value; }
        }

        public FormLauncher()
        {
            InitializeComponent();
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

                        form.Show();
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
    }
}
