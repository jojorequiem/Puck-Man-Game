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
        private string pseudo;
        public FrmCreateNewGame()
        {
            InitializeComponent();
        }

        private void TxtPseudo_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;

            string input = textBox.Text;

            if (input.Length > 20)
            {
                input = input.Substring(0, 20);
                textBox.Text = input;
                textBox.SelectionStart = input.Length;
                LblAlertPseudo.Text = "Le pseudo ne peut pas dépasser 15 caractères.";
                LblAlertPseudo.ForeColor = Color.Red;
            }
            else
            {
                LblAlertPseudo.Text = "";
            }
            pseudo = input;
        }

        private void ChkModeHistoire_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkModeHistoire.Checked)
            {
                ChkModeInfini.Checked = false;
            }
        }

        private void ChkModeInfini_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkModeInfini.Checked)
            {
                ChkModeHistoire.Checked = false;
            }
        }

        private void ChkDifficulteFacile_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDifficulteFacile.Checked)
            {
                ChkDifficulteDifficile.Checked = ChkDifficulteNormal.Checked = false;
            }
        }

        private void ChkDifficulteNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDifficulteNormal.Checked)
            {
                ChkDifficulteFacile.Checked = ChkDifficulteDifficile.Checked = false;
            }
        }

        private void ChkDifficulteDifficile_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDifficulteDifficile.Checked)
            {
                ChkDifficulteFacile.Checked = ChkDifficulteNormal.Checked = false;
            }
        }

        private void BtnSauvegarder_Click(object sender, EventArgs e)
        {
            bool entreePseudo = !string.IsNullOrEmpty(TxtPseudo.Text) && TxtPseudo.Text.Length > 0;
            bool difficulteChoisie = ChkDifficulteFacile.Checked || ChkDifficulteNormal.Checked || ChkDifficulteDifficile.Checked;
            bool modeChoisi = ChkModeHistoire.Checked || ChkModeInfini.Checked;
            if (!entreePseudo)
            {
                LblAlertPartie.Text = "Vous devez entrer un pseudo.";
                LblAlertPartie.ForeColor = Color.Red;
                return;
            }
            if (!modeChoisi && !difficulteChoisie)
            {
                LblAlertPartie.Text = "Vous devez sélectionner un mode de jeu et une difficulté.";
                LblAlertPartie.ForeColor = Color.Red;
                return;
            }
            else if (!modeChoisi)
            {
                LblAlertPartie.Text = "Vous devez sélectionner un mode de jeu.";
                LblAlertPartie.ForeColor = Color.Red;
                return;
            }
            else if (!difficulteChoisie)
            {
                LblAlertPartie.Text = "Vous devez sélectionner une difficulté.";
                LblAlertPartie.ForeColor = Color.Red;
                return;
            }

            LblAlertPartie.Text = ""; // Clear the alert message if everything is okay
        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            if (Program.FrmPlay == null)
                Program.FrmPlay = new FrmPlay();
            Program.ChangeActiveForm(Program.FrmPlay, this);
        }
    }
}