﻿using Puck_Man_Game.src.PuckMan.Engine;
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
        public byte difficulte;
        public FrmCreateNewGame()
        {
            InitializeComponent();
            ReinitialiseDisplay();
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
            bool entreePseudo = !string.IsNullOrEmpty(TxtBoxPseudo.Text) && TxtBoxPseudo.Text.Length > 0;
            if (!entreePseudo)
            {
                LblAlertPartie.Text = "Vous devez entrer un pseudo.";
                LblAlertPartie.ForeColor = Color.Red;
                return;
            }

            bool difficulteChoisie = ChkDifficulteFacile.Checked || ChkDifficulteNormal.Checked || ChkDifficulteDifficile.Checked;
            if (!difficulteChoisie)
            {
                LblAlertPartie.Text = "Vous devez sélectionner une difficulté.";
                LblAlertPartie.ForeColor = Color.Red;
                return;
                
            }

            LblAlertPartie.Text = "";
            {
            if (Program.FrmNouvellePartie != null)
                {
                    //pour éviter de probleme de demander à l'utilisateur s'il veut quitter
                    Program.FrmNouvellePartie.FormClosing -= Program.FrmNouvellePartie.FormComponent_FormClosing;

                    Program.FrmNouvellePartie.Close();
                    Program.FrmNouvellePartie.Dispose();
                }
                if (ChkDifficulteFacile.Checked)
                    difficulte = 1;
                else if (ChkDifficulteNormal.Checked)
                    difficulte = 2;
                else if (ChkDifficulteDifficile.Checked)
                    difficulte = 3;

                Program.FrmNouvellePartie = new FrmNouvellePartie(difficulte, false, 0, TxtBoxPseudo.Text);
                Program.scoreJoueur = 0;
                ReinitialiseDisplay();
                Program.ChangeActiveForm(Program.FrmNouvellePartie, this);
            }
        }
        private void ReinitialiseDisplay()
        {
            LblAlertPseudo.Text = "";
            TxtBoxPseudo.Text = "";
            LblAlertPartie.Text = "";
            ChkDifficulteFacile.Checked = ChkDifficulteDifficile.Checked = false;
            ChkDifficulteNormal.Checked = true;
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
            if (input.Length > 20)
            {
                input = input.Substring(0, 20);
                textBox.Text = input;
                textBox.SelectionStart = input.Length;
                LblAlertPseudo.Text = "Le pseudo ne peut pas dépasser 15 caractères.";
                LblAlertPseudo.ForeColor = Color.Red;
            }
            else
                LblAlertPseudo.Text = "";
        }
    }
}