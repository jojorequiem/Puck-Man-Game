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
    public partial class FrmNiveauSuivant : FormComponent
    {
        public FrmNiveauSuivant()
        {
            InitializeComponent();
        }

        private void BtnNiveauSuivant_Click(object sender, EventArgs e)
        {
            Program.FrmNouvellePartie = new FrmNouvellePartie(0, false, 0);
            Program.ChangeActiveForm(Program.FrmNouvellePartie, this);
        }

        private void BtnRetourMenu_Click(object sender, EventArgs e)
        {
            Program.ChangeActiveForm(Program.FrmMenu, this);
        }
    }
}
