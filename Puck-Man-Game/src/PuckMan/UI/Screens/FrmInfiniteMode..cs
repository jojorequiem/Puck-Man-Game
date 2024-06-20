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
    /// <summary>
    /// Formulaire pour créer une nouvelle partie dans le jeu.
    /// </summary>
    public partial class FrmInfiniteMode : FormComponent
    {
        public byte difficulty;  // Niveau de difficulté choisi par le joueur

        public FrmInfiniteMode()
        {
            InitializeComponent();
            ReinitialiseDisplay();  // Initialise l'affichage lors de la création de la fenêtre
        }

        /// <summary>
        /// Événement déclenché lorsque le formulaire est affiché à l'écran.
        /// Met le focus sur le champ de saisie du pseudo.
        /// </summary>
        private void FrmCreateNewGame_Shown(object sender, EventArgs e)
        {
            TxtBoxPseudo.Focus();
        }

        /// <summary>
        /// Événement déclenché lorsque l'état de la case à cocher "Difficulté Facile" change.
        /// Désélectionne les autres niveaux de difficulté si "Facile" est sélectionné.
        /// </summary>
        private void ChkDifficulteFacile_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDifficulteFacile.Checked)
                ChkDifficulteDifficile.Checked = ChkDifficulteNormal.Checked = false;
        }

        /// <summary>
        /// Événement déclenché lorsque l'état de la case à cocher "Difficulté Normale" change.
        /// Désélectionne les autres niveaux de difficulté si "Normale" est sélectionné.
        /// </summary>
        private void ChkDifficulteNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDifficulteNormal.Checked)
                ChkDifficulteFacile.Checked = ChkDifficulteDifficile.Checked = false;
        }

        /// <summary>
        /// Événement déclenché lorsque l'état de la case à cocher "Difficulté Difficile" change.
        /// Désélectionne les autres niveaux de difficulté si "Difficile" est sélectionné.
        /// </summary>
        private void ChkDifficulteDifficile_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDifficulteDifficile.Checked)
                ChkDifficulteFacile.Checked = ChkDifficulteNormal.Checked = false;
        }

        /// <summary>
        /// Événement déclenché lorsque le bouton "Sauvegarder" est cliqué.
        /// Vérifie les conditions nécessaires pour sauvegarder le pseudo et la difficulté choisie,
        /// puis initialise et affiche le jeu avec les paramètres sélectionnés.
        /// </summary>
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

        /// <summary>
        /// Réinitialise l'affichage en effaçant les champs de saisie et en réinitialisant les cases à cocher.
        /// </summary>
        private void ReinitialiseDisplay()
        {
            LblAlertPseudo.Text = "";
            TxtBoxPseudo.Text = "";
            LblAlertPartie.Text = "";
            ChkDifficulteFacile.Checked = ChkDifficulteDifficile.Checked = false;
            ChkDifficulteNormal.Checked = true;
            TxtBoxPseudo.Focus();
        }

        /// <summary>
        /// Événement déclenché lorsque le bouton "Retour" est cliqué.
        /// Affiche la fenêtre de jeu si elle n'est pas déjà ouverte.
        /// </summary>
        private void BtnRetour_Click(object sender, EventArgs e)
        {
            if (Program.FrmPlay == null)
                Program.FrmPlay = new FrmPlay();
            Program.ChangeActiveForm(Program.FrmPlay, this);
        }

        /// <summary>
        /// Événement déclenché lorsque le texte du champ de saisie du pseudo change.
        /// Limite la longueur du pseudo à 8 caractères et affiche un message d'erreur si nécessaire.
        /// </summary>
        private void TxtPseudo_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;

            string input = textBox.Text;

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
