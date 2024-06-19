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
        private string Pseudo;
        private byte Difficulty;
        public FrmNiveauSuivant(string pseudo, byte difficulty)
        {
            InitializeComponent();
            Pseudo = pseudo;
            Difficulty = difficulty; 
        }

        private void FrmNiveauSuivant_Shown(object sender, EventArgs e)
        {
            BtnNiveauSuivant.Focus();
        }

        private void BtnNiveauSuivant_Click(object sender, EventArgs e)
        {
            Program.FrmNouvellePartie = new FrmNouvellePartie(Difficulty, false, 0, Pseudo);
            Program.ChangeActiveForm(Program.FrmNouvellePartie, this);
        }

        private void BtnRetourMenu_Click(object sender, EventArgs e)
        {
            if (Difficulty > 0) // mode infini (sauvegarder dans le classement)
            {
                string filepath = "src/database/classement.txt";
                string[] lines = File.ReadAllLines(filepath, Encoding.UTF8);

                string nomDifficulte = "histoire";
                switch (Difficulty)
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
                    lines[lines.Length - 1] += "\n" + Pseudo + ";" + Program.score.ToString() + ";" + nomDifficulte;
                else
                    lines = new string[] { Pseudo+ ";" + Program.score.ToString() + ";" + nomDifficulte };

                File.WriteAllLines(filepath, lines, Encoding.UTF8);
            }

        Program.ChangeActiveForm(Program.FrmMenu, this);
        }

    }
}
