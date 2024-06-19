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
        private string PseudoJoueur;
        private byte DifficulteJeu;
        public FrmNiveauSuivant(string pseudo, byte difficulte)
        {
            InitializeComponent();
            PseudoJoueur = pseudo;
            DifficulteJeu = difficulte; 
        }

        //JONATHAN HELP
        private void FrmNiveauSuivant_Shown(object sender, EventArgs e)
        {
            BtnNiveauSuivant.Focus();
        }

        private void BtnNiveauSuivant_Click(object sender, EventArgs e)
        {
            Program.FrmNouvellePartie = new FrmNouvellePartie(DifficulteJeu, false, 0, PseudoJoueur);
            Program.ChangeActiveForm(Program.FrmNouvellePartie, this);
        }

        private void BtnRetourMenu_Click(object sender, EventArgs e)
        {
            Program.ChangeActiveForm(Program.FrmMenu, this);
        }

    }
}
