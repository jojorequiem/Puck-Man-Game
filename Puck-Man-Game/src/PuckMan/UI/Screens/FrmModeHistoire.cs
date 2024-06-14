﻿using System;
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

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    public partial class FrmModeHistoire : FormComponent
    {
        public int niveauPartie1;
        public int niveauPartie2;
        public int niveauPartie3;

        public FrmModeHistoire() : base()
        {
            InitializeComponent();
            niveauPartie1 = GetActualLevel(1);
            niveauPartie2 = GetActualLevel(2);
            niveauPartie3 = GetActualLevel(3);  

            if (niveauPartie1 > 0)
                AfficherBoutonsPartieExistante(BtnGame1, BtnDelete1, "CHAPITRE " + niveauPartie1);
            else
                AfficherBoutonsPartieSupprimer(BtnGame1, BtnDelete1);

            if (niveauPartie2 > 0)
                AfficherBoutonsPartieExistante(BtnGame2, BtnDelete2, "CHAPITRE " + niveauPartie2);
            else
                AfficherBoutonsPartieSupprimer(BtnGame2, BtnDelete2);

            if (niveauPartie3 > 0)
                AfficherBoutonsPartieExistante(BtnGame3, BtnDelete3, "CHAPITRE " + niveauPartie3);
            else
                AfficherBoutonsPartieSupprimer(BtnGame3, BtnDelete3);
        }

        private void AfficherBoutonsPartieExistante(Button boutonPartie, Button boutonSupprimer, string text)
        {
            boutonPartie.Text = text;
            boutonSupprimer.Enabled = true;
        }

        private void AfficherBoutonsPartieSupprimer(Button boutonPartie, Button boutonSupprimer)
        {
            boutonPartie.Text = "NOUVELLE PARTIE";
            boutonSupprimer.Enabled = false;
        }

        private int GetActualLevel(int game)
        {
            //renvoit le niveau actuel de la partie game (partie 1, 2 ou 3)
            string[] lines = File.ReadAllLines("src/PuckMan/Game/Levels/modeHistoire.txt", Encoding.UTF8);
            Debug.WriteLine(lines[game - 1]);
            return int.Parse(lines[game - 1]);
        }

        private void ChangeActualLevel(int game, int value)
        {
            string[] lines = File.ReadAllLines("src/PuckMan/Game/Levels/modeHistoire.txt", Encoding.UTF8);
            lines[game - 1] = (value).ToString();
            for(int i = 0; i < lines.Length; i++)
            {
                Debug.WriteLine(lines[i]);
            }
            Debug.WriteLine("");
            File.WriteAllLines("src/PuckMan/Game/Levels/modeHistoire.txt", lines, Encoding.UTF8);
        }

        private void BtnGame1_Click(object sender, EventArgs e)
        {
            Program.game = 1;
            if (niveauPartie1 <= 0)
            {
                ChangeActualLevel(1, 1);
                niveauPartie1 = 1;
            }
            if (Program.FrmDialogue == null)
                Program.FrmDialogue = new FrmDialogue(niveauPartie1, false);
            Program.ChangeActiveForm(Program.FrmDialogue, this);
        }
        private void BtnGame2_Click(object sender, EventArgs e)
        {
            Program.game = 2;
            if (niveauPartie2 <= 0)
            {
                ChangeActualLevel(2, 1);
                niveauPartie2 = 1;
            }
                
            if (Program.FrmDialogue == null)
                Program.FrmDialogue = new FrmDialogue(niveauPartie2, false);
            Program.ChangeActiveForm(Program.FrmDialogue, this);
        }

        private void BtnGame3_Click(object sender, EventArgs e)
        {
            Program.game = 3;
            if (niveauPartie3 <= 0)
            {
                ChangeActualLevel(3, 1);
                niveauPartie3 = 1;
            }
            if (Program.FrmDialogue == null)
                Program.FrmDialogue = new FrmDialogue(niveauPartie3, false);
            Program.ChangeActiveForm(Program.FrmDialogue, this);
        }
        public bool DemandeSuppresionPartie(Button boutonPartie, Button boutonSupprimer, int game)
        {
            DialogResult dialogResult = MessageBox.Show("Voulez-vous vraiment supprimer cette partie ?", "Message-Puck-Man", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ChangeActualLevel(game, 0);
                boutonPartie.Text = "NOUVELLE PARTIE";
                boutonSupprimer.Enabled = false;
                return true;
            }
            return false;
        }

        private void BtnDelete1_Click(object sender, EventArgs e)
        {
            if (DemandeSuppresionPartie(BtnGame1, BtnDelete1, 1))
                niveauPartie1 = 0;
        }

        private void BtnDelete2_Click(object sender, EventArgs e)
        {
            if (DemandeSuppresionPartie(BtnGame2, BtnDelete2, 2))
                niveauPartie2 = 0;
        }
        private void BtnDelete3_Click(object sender, EventArgs e)
        {
            if (DemandeSuppresionPartie(BtnGame3, BtnDelete3, 3))
                niveauPartie3 = 0;
        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            if (Program.FrmJouer == null)
                Program.FrmJouer = new FrmJouer();
            Program.ChangeActiveForm(Program.FrmJouer, this);
        } 

    }
}