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
using System.Diagnostics;
using src.PuckMan.Game.Levels;

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    public partial class FrmDeath : FormComponent
    {
        public int NiveauActuel;
        public FrmDeath(string pseudo, int niveauActuel, int difficulte)
        {
            InitializeComponent();
            LblValeurScore.Text = Program.scoreJoueur.ToString();
            Program.PlayMusic("assets/audio/musiqueMort.mp3");
            
            NiveauActuel = niveauActuel;
            if (NiveauActuel > 0)
            {
                LblScore.Hide();
                LblValeurScore.Hide();
                PcbScore.Hide();
                BtnNouvellePartie.Text = "REJOUER";
            }
            
            if (difficulte > 0) // mode infini
            {
                string filepath = "src/database/classement.txt";
                string[] lines = File.ReadAllLines(filepath, Encoding.UTF8);

                string nomDifficulte = "Hardcore";
                switch (difficulte)
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
                    lines[lines.Length - 1] += "\n" + pseudo + ";" + Program.scoreJoueur.ToString() + ";" + nomDifficulte;
                else
                    lines = new string[] { pseudo + ";" + Program.scoreJoueur.ToString() + ";" + nomDifficulte };

                File.WriteAllLines(filepath, lines, Encoding.UTF8);
            }
        }

        private void BtnNouvellePartie_Click(object sender, EventArgs e)
        {
            if (NiveauActuel > 0) {
                Program.FrmNouvellePartie = new FrmNouvellePartie(0, true, NiveauActuel, "");
                Program.ChangeActiveForm(Program.FrmNouvellePartie, this);
            }
            else
            {
                if (Program.FrmCreateNewGame == null)
                    Program.FrmCreateNewGame = new FrmCreateNewGame();
                Program.ChangeActiveForm(Program.FrmCreateNewGame, this);
            }
            CloseForm();
        }

        private void CloseForm()
        {   
            //pour éviter de probleme de demander à l'utilisateur s'il veut quitter
            this.FormClosing -= this.FormComponent_FormClosing;
            this.Close();
            this.Dispose();
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            if (Program.FrmMenu == null)
                Program.FrmMenu = new FrmMenu();
            Program.ChangeActiveForm(Program.FrmMenu, this);
            CloseForm();
        }

       
    }
}
