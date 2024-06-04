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
            //LoadFont();
            ChangeAllTextColors(this);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.BackColor = Program.BackgroundColor;
            if (this.GetType() == typeof(NouvellePartie))
                this.BackgroundImage = Properties.Resources.background;
            this.StartPosition = FormStartPosition.CenterScreen;
            SetFormSize();
        }
        private void SetFormSize()
        {
            this.ClientSize = new Size(Program.LargeurFenetre, Program.HauteurFenetre);
            this.MinimumSize = new Size(Program.LargeurFenetre - 1, Program.HauteurFenetre - 1);
            this.MaximumSize = new Size(Program.LargeurFenetre + 1, Program.HauteurFenetre + 1);
            this.ClientSize = new Size(Program.LargeurFenetre, Program.HauteurFenetre);
            Debug.WriteLine(ClientSize.ToString());
        }
        private void LoadFont()
        {
            PrivateFontCollection privateFontCollection = new PrivateFontCollection();
            using (Stream fontStream = typeof(FormComponent).Assembly.GetManifestResourceStream("Puck-Man-Game.assets.fonts.fonts_pixel_art.ttf"))
            {
                if (fontStream != null)
                {
                    Debug.WriteLine("SUUUUUU");
                    byte[] fontdata = new byte[fontStream.Length];
                    fontStream.Read(fontdata, 0, (int)fontStream.Length);
                    fontStream.Close();

                    IntPtr fontPtr = Marshal.AllocCoTaskMem(fontdata.Length);
                    Marshal.Copy(fontdata, 0, fontPtr, fontdata.Length);

                    privateFontCollection.AddMemoryFont(fontPtr, fontdata.Length);

                    Marshal.FreeCoTaskMem(fontPtr);
                }
            }

            if (privateFontCollection.Families.Length > 0)
            {
                Font font = new Font(privateFontCollection.Families[0], 12); // 12 est la taille de la police
                this.Font = font;
                Debug.WriteLine("font loaded");
            }
            else
            {
                Debug.WriteLine("font not loaded");
            }
                
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
            form.StartPosition = FormStartPosition.Manual;
            form.Location = previousForm.Location;
            form.Show();
            previousForm.Hide();
        }
    }
}
