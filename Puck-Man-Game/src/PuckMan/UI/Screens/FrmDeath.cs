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
        public int Level;
        public FrmDeath(string pseudo, int level, int difficulty)
        {
            InitializeComponent();
            LblValeurScore.Text = Program.score.ToString();
            Program.PlayMusic("assets/audio/DeathMusic.mp3");

            Level = level;
            if (Level > 0)
            {
                LblScore.Hide();
                LblValeurScore.Hide();
                PcbScore.Hide();
                BtnNouvellePartie.Text = "REJOUER";
            }
            
            if (difficulty > 0) // mode infini
            {
                string filepath = "src/database/ScoreRanking.txt";
                string[] lines = File.ReadAllLines(filepath, Encoding.UTF8);

                string difficultyName = "Hardcore";
                switch (difficulty)
                {
                    case 1:
                        difficultyName = "Facile";
                        break;
                    case 2:
                        difficultyName = "Moyen";
                        break;
                    case 3:
                        difficultyName = "Difficile";
                        break;
                }
                if (lines.Length > 0)
                    lines[lines.Length - 1] += "\n" + pseudo + ";" + Program.score.ToString() + ";" + difficultyName;
                else
                    lines = new string[] { pseudo + ";" + Program.score.ToString() + ";" + difficultyName };

                File.WriteAllLines(filepath, lines, Encoding.UTF8);
            }
        }

        private void BtnNouvellePartie_Click(object sender, EventArgs e)
        {
            if (Level > 0) {
                Program.FrmNewGame = new FrmNewGame(0, true, Level, "");
                Program.ChangeActiveForm(Program.FrmNewGame, this);
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
