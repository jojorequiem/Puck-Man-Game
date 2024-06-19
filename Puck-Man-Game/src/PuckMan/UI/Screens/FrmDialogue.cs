using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    public partial class FrmDialogue : FormComponent
    {
        private int nbrLine;
        private string Chapitre;
        private bool dialogueFini;
        private int NiveauActuel;
        public bool NiveauFini;
        public FrmDialogue(int niveauActuel, bool niveauFini) : base()
        {
            string filepath = "src/database/modeHistoire.txt";

            InitializeComponent();
            NiveauActuel = niveauActuel;
            NiveauFini = niveauFini;
            dialogueFini = false;
            if (!NiveauFini)
                Chapitre = "chapitre" + niveauActuel+"_p1.txt";
            else
            {
                Chapitre = "chapitre" + niveauActuel + "_p2.txt";

                //si le niveau est fini, on incrémente le niveau actuel de 1
                string[] lines = File.ReadAllLines(filepath, Encoding.UTF8);
                lines[Program.game - 1] = (NiveauActuel + 1).ToString();
                NiveauActuel += 1;
                File.WriteAllLines(filepath, lines, Encoding.UTF8);
            }

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
                Suivant();
            else
            {
                string filePath = "assets/dialogue/" + Chapitre;
                if (File.Exists(filePath))
                {
                    Debug.WriteLine(filePath + "ouvert");
                    nbrLine++;
                    string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
                    if (nbrLine + 1 > lines.Count())
                    {
                        BtnDialogueSuivant.Text = "Fin";
                        dialogueFini = true;
                    }
                    GenererDialogue(lines[nbrLine - 1]);
                }
            }
        }

        private void BtnSkip_Click(object sender, EventArgs e)
        {
            Suivant();
        }

        private void Suivant()
        {
            if (NiveauFini)
            {
                //pour éviter de probleme de demander à l'utilisateur s'il veut quitter
                Program.FrmDialogue.FormClosing -= Program.FrmDialogue.FormComponent_FormClosing;

                this.Dispose();
                this.Close();
                Program.FrmDialogue = new FrmDialogue(NiveauActuel, false);
                Program.ChangeActiveForm(Program.FrmDialogue, this);
            }
            else
            {
                if (Program.FrmNouvellePartie != null)
                {
                    //pour éviter de probleme de demander à l'utilisateur s'il veut quitter
                    Program.FrmNouvellePartie.FormClosing -= Program.FrmNouvellePartie.FormComponent_FormClosing;

                    Program.FrmNouvellePartie.Close();
                    Program.FrmNouvellePartie.Dispose();
                }
                Program.FrmNouvellePartie = new FrmNouvellePartie(0, true, NiveauActuel);
                Program.ChangeActiveForm(Program.FrmNouvellePartie, this);
            }
        }

    }
}