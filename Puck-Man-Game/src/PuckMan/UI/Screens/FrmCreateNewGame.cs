using Puck_Man_Game.src.PuckMan.Engine;
using Puck_Man_Game.src.PuckMan.Game.Entities;
using src.PuckMan.Game.Levels;
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
    public partial class FrmCreateNewGame : FormComponent
    {
        public byte difficulty;
        public FrmCreateNewGame()
        {
            InitializeComponent();
            ReinitialiseDisplay();
        }

        private void FrmCreateNewGame_Shown(object sender, EventArgs e)
        {
            TxtBoxPseudo.Focus();
        }

        private void ChkDifficulteFacile_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDifficulteFacile.Checked)
                ChkDifficulteDifficile.Checked = ChkDifficulteNormal.Checked = false;
        }

        private void ChkDifficulteNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDifficulteNormal.Checked)
                ChkDifficulteFacile.Checked = ChkDifficulteDifficile.Checked = false;
        }

        private void ChkDifficulteDifficile_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDifficulteDifficile.Checked)
                ChkDifficulteFacile.Checked = ChkDifficulteNormal.Checked = false;
        }

        private void BtnSauvegarder_Click(object sender, EventArgs e)
        {
            bool enterPseudo = !string.IsNullOrEmpty(TxtBoxPseudo.Text) && TxtBoxPseudo.Text.Length > 0;
            bool ChoosedDifficulty = ChkDifficulteFacile.Checked || ChkDifficulteNormal.Checked || ChkDifficulteDifficile.Checked;
            bool willReturn = false;

            if (TxtBoxPseudo.Text.Contains(";"))
            {
                LblAlertPseudo.Text = "Votre pseudo ne peut pas contenir de point virgule.";
                LblAlertPseudo.ForeColor = Color.Red;
                willReturn = true;
            }
            if (!enterPseudo)
            {
                LblAlertPseudo.Text = "Vous devez entrer un pseudo.";
                LblAlertPseudo.ForeColor = Color.Red;
                willReturn = true;
            }

            if (!ChoosedDifficulty)
            {
                LblAlertPartie.Text = "Vous devez sélectionner une difficulté.";
                LblAlertPartie.ForeColor = Color.Red;
                willReturn = true;
            }
            if (willReturn) return;

           
            LblAlertPartie.Text = "";
            {
                if (Program.FrmNewGame != null)
                {
                    //pour éviter de probleme de demander à l'utilisateur s'il veut quitter
                    Program.FrmNewGame.FormClosing -= Program.FrmNewGame.FormComponent_FormClosing;

                    Program.FrmNewGame.Close();
                    Program.FrmNewGame.Dispose();
                }
                if (ChkDifficulteFacile.Checked)
                    difficulty = 1;
                else if (ChkDifficulteNormal.Checked)
                    difficulty = 2;
                else if (ChkDifficulteDifficile.Checked)
                    difficulty = 3;

                Program.FrmNewGame = new FrmNewGame(difficulty, false, 0, TxtBoxPseudo.Text);
                Program.score = 0;
                ReinitialiseDisplay();
                Program.ChangeActiveForm(Program.FrmNewGame, this);
            }
        }
        private void ReinitialiseDisplay()
        {
            LblAlertPseudo.Text = "";
            TxtBoxPseudo.Text = "";
            LblAlertPartie.Text = "";
            ChkDifficulteFacile.Checked = ChkDifficulteDifficile.Checked = false;
            ChkDifficulteNormal.Checked = true;
            TxtBoxPseudo.Focus();
        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            if (Program.FrmPlay == null)
                Program.FrmPlay = new FrmPlay();
            Program.ChangeActiveForm(Program.FrmPlay, this);
        }


        private void TxtPseudo_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;

            string input = textBox.Text;

            // Vérifier si le pseudo dépasse 8 caractères
            if (input.Length > 8)
            {
                input = input.Substring(0, 8);
                textBox.Text = input;
                textBox.SelectionStart = input.Length;
                LblAlertPseudo.Text = "Le pseudo ne peut pas dépasser 8 caractères.";
                LblAlertPseudo.ForeColor = Color.Red;
            }
            else
            {
                LblAlertPseudo.Text = "";
            }
        }
    }
}