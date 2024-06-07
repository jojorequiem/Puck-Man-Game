﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    public partial class Dialogue : FormComponent
    {
        private int nbrLine;
        private string Chapitre;
        private bool dialogueFini;
        private int NiveauActuel;
        private bool NiveauFini;
        public Dialogue(int niveauActuel, bool niveauFini) : base()
        {
            InitializeComponent();
            NiveauActuel = niveauActuel;
            NiveauFini = niveauFini;
            Program.PlayMusic("assets/audio/musiqueDialogue.mp3");
            dialogueFini = false;
            if (!NiveauFini)
                Chapitre = "chapitre" + niveauActuel+"_p1.txt";
            else
                Chapitre = "chapitre" + niveauActuel + "_p2.txt";
            nbrLine = 1;
            string filePath = "assets/dialogue/" + Chapitre;
            if (File.Exists(filePath))
            {
                nbrLine++;
                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
                //affiche le titre et le premier dialogue
                LblTitre.Text = lines[0];
                GenererDialogue(lines[1]);
            }
            else { Debug.WriteLine(filePath + "was not found"); }

            FlowPanel.FlowDirection = FlowDirection.TopDown;
            FlowPanel.WrapContents = false;
            FlowPanel.Padding = new Padding(10);
        }

        public void GenererDialogue(string dialogue)
        {
            Label label = new Label
            {
                Text = dialogue,
                AutoSize = true,
                MaximumSize = new Size(500, 0), // Largeur maximale, hauteur automatique
                Font = new Font(FontFamily.GenericSansSerif, 16),
                ForeColor = Program.TextColor,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 0, 0, 15) // Ajouter une marge pour l'espacement
            };
            FlowPanel.Controls.Add(label);
            
            //scroll automatiquement pour le confort de l'utilisateur
            Panel.VerticalScroll.Value = Panel.VerticalScroll.Maximum;
            Panel.PerformLayout();
        }

        private void BtnDialogueSuivant_Click(object sender, EventArgs e)
        {
            if (dialogueFini)
            {
                if (NiveauFini)
                {
                    string[] lines = File.ReadAllLines("src/PuckMan/Game/Levels/modeHistoire.txt", Encoding.UTF8);
                    lines[Program.game - 1] = (NiveauActuel + 1).ToString();
                    File.WriteAllLines("src/PuckMan/Game/Levels/modeHistoire.txt", lines, Encoding.UTF8);
                }

                if (Program.NouvellePartie != null)
                {
                    Program.NouvellePartie.Close();
                    Program.NouvellePartie.Dispose();
                }
                Program.NouvellePartie = new NouvellePartie(true, NiveauActuel + 1);
                Program.ChangeActiveForm(Program.NouvellePartie, this);


                // DisplayForm(new NouvellePartie(true, NiveauActuel + 1), this);
            }
            else
            {
                string filePath = "assets/dialogue/" + Chapitre;
                if (File.Exists(filePath))
                {
                    nbrLine++;
                    string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
                    if (nbrLine + 1 > lines.Count())
                    {
                        BtnDialogueSuivant.Text = "Fin";
                        BtnDialogueSuivant.ForeColor = Color.Black;
                        dialogueFini = true;
                    }
                    GenererDialogue(lines[nbrLine - 1]);
                }
            }
        }

        private void BtnSkip_Click(object sender, EventArgs e)
        {
            DisplayForm(new NouvellePartie(true, NiveauActuel + 1), this);
        }
    }
}