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
        private int LineNbr;
        private string Chapter;
        private bool DialogueFinished;
        private int Level;
        public bool LevelFinished;
        public FrmDialogue(int level, bool levelIsFinished) : base()
        {
            string filepath = "src/database/modeHistoire.txt";

            InitializeComponent();
            Level = level;
            LevelFinished = levelIsFinished;
            DialogueFinished = false;
            if (!LevelFinished)
                Chapter = "chapitre" + Level + "_p1.txt";
            else
            {
                Chapter = "chapitre" + Level + "_p2.txt";

                //si le niveau est fini, on incrémente le niveau actuel de 1
                string[] lines = File.ReadAllLines(filepath, Encoding.UTF8);
                lines[Program.game - 1] = (Level + 1).ToString();
                Level += 1;
                File.WriteAllLines(filepath, lines, Encoding.UTF8);

            }

            LineNbr = 1;
            string filePath = "assets/dialogue/" + Chapter;
            if (File.Exists(filePath))
            {
                LineNbr++;
                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
                
                //affiche le titre et le premier dialogue
                LblTitre.Text = lines[0];
                GenererDialogue(lines[1]);
            }

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
                Font = new System.Drawing.Font("Minecraft", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
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
            if (DialogueFinished)
                Suivant();
            else
            {
                string filePath = "assets/dialogue/" + Chapter;
                if (File.Exists(filePath))
                {
                    LineNbr++;
                    string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
                    if (LineNbr + 1 > lines.Count())
                    {
                        BtnDialogueSuivant.Text = "Fin";
                        DialogueFinished = true;
                    }
                    GenererDialogue(lines[LineNbr - 1]);
                }
            }
        }

        private void BtnSkip_Click(object sender, EventArgs e)
        {
            Suivant();
        }

        private void Suivant()
        {
            if (LevelFinished)
            {
                //pour éviter de probleme de demander à l'utilisateur s'il veut quitter
                Program.FrmDialogue.FormClosing -= Program.FrmDialogue.FormComponent_FormClosing;
                this.Dispose();
                this.Close();

                if (Level > 5)
                    Program.ChangeActiveForm(Program.FrmMenu, this);
                else
                {
                    Program.FrmDialogue = new FrmDialogue(Level, false);
                    Program.ChangeActiveForm(Program.FrmDialogue, this);
                }
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
                Program.FrmNouvellePartie = new FrmNouvellePartie(0, true, Level, "");
                Program.ChangeActiveForm(Program.FrmNouvellePartie, this);
            }
        }

    }
}