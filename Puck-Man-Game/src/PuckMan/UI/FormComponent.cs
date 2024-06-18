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
            AutoScaleMode = AutoScaleMode.None;
            this.Load += FormComponent_Load;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormComponent_FormClosing);
        }
        private void FormComponent_Load(object sender, EventArgs e)
        {
            AutoScaleMode = AutoScaleMode.None;
            ChangeAllTextColors(this);
            if (this is FrmNouvellePartie)
            {
                this.BackgroundImage = Puck_Man_Game.Properties.Resources.background;
                this.BackgroundImageLayout = ImageLayout.Tile;
            }
            else
            {
                this.BackgroundImage = Puck_Man_Game.Properties.Resources.background2;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }

            //this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(Program.LargeurFenetre - 1, Program.HauteurFenetre - 1);
            this.MaximumSize = new Size(Program.LargeurFenetre + 1, Program.HauteurFenetre +1);
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

                if (control is Button button)
                {
                    button.MouseEnter += MyButton_MouseEnter;
                    button.MouseLeave += MyButton_MouseLeave;
                    button.GotFocus += MyButton_GotFocus;
                    button.LostFocus += MyButton_LostFocus;
                    button.Click += MyButton_Click;
                    button.Font = new Font(control.Font.FontFamily, 16);
                    button.ForeColor = Program.TextColor;
                    button.BackColor = Color.Transparent;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.MouseDownBackColor = Color.Black;
                    button.FlatAppearance.MouseOverBackColor = Color.Black;
                }

                if (control.HasChildren)
                    ChangeAllTextColors(control);
            }
        }

        private void MyButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.Black;
                button.ForeColor = Program.TextColor;
            }
        }

        private void MyButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.Transparent;
                button.ForeColor = Program.TextColor;
            }
        }

        private void MyButton_GotFocus(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.BackColor = Color.Black;
                button.ForeColor = Color.White;
            }
        }

        private void MyButton_LostFocus(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null && !button.ClientRectangle.Contains(button.PointToClient(Control.MousePosition)))
            {
                button.BackColor = Color.Transparent;
                button.ForeColor = Program.TextColor;
            }
        }

        private void MyButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.BackColor = Color.Transparent;
                button.ForeColor = Program.TextColor;
            }
            Program.PlaySound("assets/audio/click.wav");
        }

        static private bool isClosed = false;
        public void FormComponent_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isClosed) return;
            if (MessageBox.Show("Voulez-vous vraiment quitter?", "Message Puck-Man", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
            else
            {
                isClosed = true;
                Application.Exit();
            }
                
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Name = "FormComponent";
            this.ResumeLayout(false);
        }
    }
}
