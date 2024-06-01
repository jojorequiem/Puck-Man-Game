using System;
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
        private int yPosition = 0;
        private int nbrLine;
        private string Chapitre;
        private bool dialogueFini;

        public Dialogue() : base()
        {
            InitializeComponent();
            dialogueFini = false;
            Chapitre = "chapitre1_p2.txt";
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
                MaximumSize = new Size(630, 0), // Largeur maximale, hauteur automatique
                Font = new Font(FontFamily.GenericSansSerif, 16),
                ForeColor = Program.TextColor,
                BackColor = Program.BackgroundColor,
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
                Program.LoadScene(typeof(NouvellePartie), this);
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
    }
}