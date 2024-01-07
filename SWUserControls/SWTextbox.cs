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
        public enum SWTextType
        {
            Number,
            Text,
            Code
        }

        public SWTextType TextType { get; set; }
        public bool AllowEmpty { get; set; }
        public bool IsForeignKey { get; set; }
        public string ControlName { get; set; }
        public System.Drawing.Color FocusColor { get; set; } = System.Drawing.Color.Yellow;
        public System.Drawing.Color DefaultColor { get; set; } = System.Drawing.SystemColors.Window;

        private static readonly Regex regexCode = new Regex(@"^[AEIOU][A-Z]{3}[0-9]{2}[13579]$");

        public SWTextbox()
        {
            this.Enter += SWTextbox_Enter;
            this.Leave += SWTextbox_Leave;
        }

        private void SWTextbox_Enter(object sender, EventArgs e)
        {
            this.BackColor = FocusColor;
        }

        private void SWTextbox_Leave(object sender, EventArgs e)
        {
            this.BackColor = DefaultColor;
        }

        private void SWTextbox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!AllowEmpty && string.IsNullOrWhiteSpace(this.Text))
            {
                ShowError("Field cannot be empty.");
                e.Cancel = true;
                return;
            }

            switch (TextType)
            {
                case SWTextType.Text:
                    if (!Regex.IsMatch(this.Text, "^[A-Za-z]+$"))
                    {
                        ShowError("Invalid input for text. Please enter letters only.");
                        e.Cancel = true;
                    }
                    break;
                case SWTextType.Number:
                    if (!Regex.IsMatch(this.Text, "^[0-9]+$"))
                    {
                        ShowError("Invalid input for number. Please enter digits only.");
                        e.Cancel = true;
                    }
                    break;
                case SWTextType.Code:
                    if (!regexCode.IsMatch(this.Text))
                    {
                        ShowError("Invalid input for code. Please enter a valid code.");
                        e.Cancel = true;
                    }
                    break;
            }
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
