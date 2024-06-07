using Puck_Man_Game.src.PuckMan.UI.Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puck_Man_Game.src.PuckMan.UI
{
    public partial class Menu : FormComponent
    {
        public Menu() : base()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.background;
        }

        private void BtnParametres_Click(object sender, EventArgs e)
        {
            if (Program.Parametres == null)
                Program.Parametres = new Parametres(this);
            Program.ChangeActiveForm(Program.Parametres, this);
        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnJouer_Click(object sender, EventArgs e)
        {
            if (Program.MenuParametreJouer == null)
                Program.MenuParametreJouer = new MenuParametreJouer();
            Program.ChangeActiveForm(Program.MenuParametreJouer, this);
        }
    }
}