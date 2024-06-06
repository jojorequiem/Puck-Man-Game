using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    public class FormComponent : Form
    {
        public FormComponent()
        {
            this.Load += FormComponent_Load;
        }
        private void FormComponent_Load(object sender, EventArgs e)
        {
            ChangeAllTextColors(this);
            this.BackColor = Program.BackgroundColor;
            this.BackgroundImage = Puck_Man_Game.Properties.Resources.background21;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(Program.LargeurFenetre - 1, Program.HauteurFenetre - 1);
            this.MaximumSize = new Size(Program.LargeurFenetre + 1, Program.HauteurFenetre + 1);
            this.ClientSize = new Size(Program.LargeurFenetre, Program.HauteurFenetre);
            Debug.WriteLine("TAILLE FENETRE : " + ClientSize.ToString());
        }

        private void ChangeAllTextColors(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Label || control is TextBox || control is CheckBox || control is RadioButton)
                {
                    control.ForeColor = Program.TextColor;
                    control.BackColor = Program.BackgroundColor;
                }

                if (control is Label) 
                    control.BackColor = Color.Transparent;

                if (control is Button)
                {
                    control.Font = new Font(control.Font.FontFamily, 16);
                    control.ForeColor = Program.TextColor;
                    control.BackColor = Program.ButtonColor;
                }

                if (control.HasChildren)
                {
                    ChangeAllTextColors(control);
                }
            }
        }

        public void DisplayForm(FormComponent form, FormComponent previousForm)
        {
            form.Location = previousForm.Location;
            form.Show();
            previousForm.Hide();
        }
    }
}
