using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    /// <summary>
    /// Fenêtre de dialogue affichant les textes de l'histoire du jeu par chapitre.
    /// Gère l'affichage séquentiel des dialogues et les transitions entre les niveaux.
    /// </summary>
    public partial class FrmDialogue : FormComponent
    {
        private int LineNbr;           // Numéro de ligne actuelle dans le fichier de dialogue
        private string Chapter;        // Fichier de dialogue actuel
        private bool DialogueFinished; // Indicateur de fin de dialogue
        private int Level;             // Niveau actuel du jeu
        public bool LevelFinished;     // Indique si le niveau est terminé

        /// <summary>
        /// Constructeur de la classe FrmDialogue.
        /// Initialise la fenêtre de dialogue en fonction du niveau et de l'état du jeu.
        /// Charge le fichier de dialogue correspondant au chapitre en cours.
        /// </summary>
        /// <param name="level">Niveau actuel du jeu.</param>
        /// <param name="levelIsFinished">Indique si le niveau est terminé.</param>
        public FrmDialogue(int level, bool levelIsFinished) : base()
        {
            string filepath = "src/database/StoryMod.txt";

            InitializeComponent();
            Level = level;
            LevelFinished = levelIsFinished;
            DialogueFinished = false;
            if (!LevelFinished)
                Chapter = "chapitre" + Level + "_p1.txt";
            else
            {
                Chapter = "chapitre" + Level + "_p2.txt";

                // Si le niveau est fini, on incrémente le niveau actuel de 1 dans le fichier de progression
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

                // Affiche le titre et le premier dialogue
                LblTitre.Text = lines[0];
                GenererDialogue(lines[1]);
            }

            FlowPanel.FlowDirection = FlowDirection.TopDown;
            FlowPanel.WrapContents = false;
            FlowPanel.Padding = new Padding(10);
        }

        /// <summary>
        /// Génère un contrôle Label affichant un dialogue dans le panneau FlowPanel.
        /// </summary>
        /// <param name="dialogue">Texte du dialogue à afficher.</param>
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

            // Scroll automatiquement pour le confort de l'utilisateur
            Panel.VerticalScroll.Value = Panel.VerticalScroll.Maximum;
            Panel.PerformLayout();
        }

        /// <summary>
        /// Événement déclenché lorsque le bouton "Dialogue Suivant" est cliqué.
        /// Affiche le prochain dialogue dans le fichier si disponible, sinon termine le dialogue.
        /// </summary>
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

        /// <summary>
        /// Événement déclenché lorsque le bouton "Passer" est cliqué.
        /// Passe au dialogue suivant immédiatement.
        /// </summary>
        private void BtnSkip_Click(object sender, EventArgs e)
        {
            Suivant();
        }

        /// <summary>
        /// Méthode privée qui gère l'action à effectuer une fois le dialogue terminé.
        /// Selon l'état du jeu, redirige vers le menu principal ou commence une nouvelle partie.
        /// </summary>
        private void Suivant()
        {
            if (LevelFinished)
            {
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
                if (Program.FrmNewGame != null)
                {
                    Program.FrmNewGame.FormClosing -= Program.FrmNewGame.FormComponent_FormClosing;
                    Program.FrmNewGame.Close();
                    Program.FrmNewGame.Dispose();
                }
                Program.FrmNewGame = new FrmNewGame(0, true, Level, "");
                Program.ChangeActiveForm(Program.FrmNewGame, this);
            }
        }
    }
}
