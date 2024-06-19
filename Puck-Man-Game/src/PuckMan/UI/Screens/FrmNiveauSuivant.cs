using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            if (DifficulteJeu > 0) // mode infini (sauvegarder dans le classement)
            {
                string filepath = "src/database/classement.txt";
                string[] lines = File.ReadAllLines(filepath, Encoding.UTF8);

                string nomDifficulte = "histoire";
                switch (DifficulteJeu)
                {
                    case 1:
                        nomDifficulte = "Facile";
                        break;
                    case 2:
                        nomDifficulte = "Moyen";
                        break;
                    case 3:
                        nomDifficulte = "Difficile";
                        break;
                }

                if (lines.Length > 0)
                    lines[lines.Length - 1] += "\n" + PseudoJoueur + ";" + Program.scoreJoueur.ToString() + ";" + nomDifficulte;
                else
                    lines = new string[] { PseudoJoueur + ";" + Program.scoreJoueur.ToString() + ";" + nomDifficulte };

                File.WriteAllLines(filepath, lines, Encoding.UTF8);
            }

        Program.ChangeActiveForm(Program.FrmMenu, this);
        }

    }
}
