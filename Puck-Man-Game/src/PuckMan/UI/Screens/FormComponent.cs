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

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    public class FormComponent : Form
    {
        public FormComponent()
        {
            this.Load += FormComponent_Load;
        }
        private const string fontFilePath = "asset/fonts/fonts_pixel_art.ttf";
        private void FormComponent_Load(object sender, EventArgs e)
        {
            //LoadFont();
            ChangeAllTextColors(this);
            this.ClientSize = new System.Drawing.Size(Program.LargeurFenetre, Program.HauteurFenetre);
            //this.MaximumSize = new System.Drawing.Size(Program.LargeurFenetre, Program.HauteurFenetre);
            this.MinimumSize = new System.Drawing.Size(Program.LargeurFenetre, Program.HauteurFenetre);
            this.BackColor = Program.BackgroundColor;
            this.BackgroundImage = null; /* Properties.Resources.background;*/
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
                    control.ForeColor = Program.TextColor;
                    control.BackColor = Program.ButtonColor;
                }

                if (control.HasChildren)
                {
                    ChangeAllTextColors(control);
                }
            }
        }
    }
}
