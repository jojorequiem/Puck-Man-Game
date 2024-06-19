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
        public FrmDeath(string pseudo, int niveauActuel)
        {
            InitializeComponent();
            LblValeurScore.Text = Program.scoreJoueur.ToString();
            Program.PlayMusic("assets/audio/musiqueMort.mp3");

            if (niveauActuel > 0)
            {
                LblScore.Hide();
                LblValeurScore.Hide();
                PcbScore.Hide();
                BtnNouvellePartie.Text = "REJOUER";
            }

            NiveauActuel = niveauActuel;

            string filepath = "src/database/classement.txt";
            string[] lines = File.ReadAllLines(filepath, Encoding.UTF8);

            if (lines.Length > 0)
                lines[lines.Length - 1] += "\n" + pseudo + ";" + Program.scoreJoueur.ToString();
            else
                lines = new string[] { pseudo + ";" + Program.scoreJoueur.ToString() };

            File.WriteAllLines(filepath, lines, Encoding.UTF8);
            NiveauActuel = niveauActuel;
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
            this.Dispose();
            this.Close();
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
