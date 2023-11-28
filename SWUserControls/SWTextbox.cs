using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SWUserControls
{


    public class SWTextbox : TextBox
    {
        private SWTextType textType;
        private bool allowEmpty;
        private bool isForeignKey;
        private string controlName;

        private static Regex regexStarWars = new Regex(@"^[BCDFGHJKLMNPQRSTVWXYZ]{4}-[0-9]{3}/[13579][AEIOU]$");
        public enum SWTextType
        {
            Number,
            Text,
            Code
        }

        public SWTextType TextType
        {
            get { return textType; }
            set { textType = value; }
        }

        public bool AllowEmpty
        {
            get { return allowEmpty; }
            set { allowEmpty = value; }
        }

        public bool IsForeignKey
        {
            get { return isForeignKey; }
            set { isForeignKey = value; }
        }

        public string ControlName
        {
            get { return controlName; }
            set { controlName = value; }
        }

        public SWTextbox()
        {
            this.Enter += SWTextbox_Enter;
            this.Leave += SWTextbox_Leave;
            InitializeComponent();
        }

        private void SWTextbox_Enter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Yellow;
        }

        private void SWTextbox_Leave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.SystemColors.Window;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SWTextbox
            // 
            this.Validating += new System.ComponentModel.CancelEventHandler(this.SWTextbox_Validating);
            this.ResumeLayout(false);

        }

        public void SetText()
        {
            Form frm = this.FindForm();
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl.Name == controlName)
                {
                    ctrl.Text = this.Text;
                }

            }
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message);
        }

        private void SWTextbox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isForeignKey)
            {
                if (!string.IsNullOrEmpty(Text))
                {
                    if (textType == SWTextType.Text && !Regex.IsMatch(Text, "^[A-Za-z]+$"))
                    {
                        ShowError("Invalid input for text. Please enter letters only.");
                        e.Cancel = true;
                    }
                    else if (textType == SWTextType.Number && !Regex.IsMatch(Text, "^[0-9]+$"))
                    {
                        ShowError("Invalid input for numbers. Please enter digits only.");
                        e.Cancel = true;
                    }
                    else if (textType == SWTextType.Code && !regexStarWars.IsMatch(Text))
                    {
                        ShowError("Invalid input for code. Please enter a valid code.");
                        e.Cancel = true;
                    }
                    else
                    {
                        SetText();
                    }
                }
            }
        }


    }

}
