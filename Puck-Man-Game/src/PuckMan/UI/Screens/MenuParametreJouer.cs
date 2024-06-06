using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    public partial class MenuParametreJouer : FormComponent
    {
        
        public MenuParametreJouer() : base()
        {
            InitializeComponent();
        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            if (Program.Menu == null)
                Program.Menu = new Menu();
            Program.ChangeActiveForm(Program.Menu, this);
        }

        private void BtnNouvellePartie_Click(object sender, EventArgs e)
        {
            if (Program.ModeHistoire == null)
                Program.ModeHistoire = new ModeHistoire();
            Program.ChangeActiveForm(Program.ModeHistoire, this);
        }

        private void BtnModeInfini_Click(object sender, EventArgs e)
        {
            if (Program.NouvellePartie == null)
                Program.NouvellePartie = new NouvellePartie(false, 0);
            Program.ChangeActiveForm(Program.ModeHistoire, this);
            //DisplayForm(new NouvellePartie(false, 0), this);
        }
    }
}
