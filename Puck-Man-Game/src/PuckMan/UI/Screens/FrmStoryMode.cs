using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    /// <summary>
    /// Fenêtre pour le mode histoire du jeu.
    /// </summary>
    public partial class FrmStoryMode : FormComponent
    {
        private int lvlGame1; // Niveau de la partie 1
        private int lvlGame2; // Niveau de la partie 2
        private int lvlGame3; // Niveau de la partie 3
        static private readonly string chemin = "src/database/StoryMod.txt"; // Chemin du fichier de sauvegarde des niveaux

        /// <summary>
        /// Constructeur de la classe FrmStoryMode.
        /// Initialise la fenêtre du mode histoire et affiche les boutons appropriés en fonction des niveaux actuels.
        /// </summary>
        public FrmStoryMode() : base()
        {
            InitializeComponent();
            DisplayButtons();
        }

        /// <summary>
        /// Affiche les boutons en fonction des niveaux actuels des parties.
        /// </summary>
        public void DisplayButtons()
        {
            lvlGame1 = GetActualLevel(1);
            lvlGame2 = GetActualLevel(2);
            lvlGame3 = GetActualLevel(3);

            if (lvlGame1 > 0)
                DisplayExistingGameButtons(BtnGame1, BtnDelete1, "CHAPITRE " + lvlGame1);
            else
                DisplayNewGameButtons(BtnGame1, BtnDelete1);

            if (lvlGame2 > 0)
                DisplayExistingGameButtons(BtnGame2, BtnDelete2, "CHAPITRE " + lvlGame2);
            else
                DisplayNewGameButtons(BtnGame2, BtnDelete2);

            if (lvlGame3 > 0)
                DisplayExistingGameButtons(BtnGame3, BtnDelete3, "CHAPITRE " + lvlGame3);
            else
                DisplayNewGameButtons(BtnGame3, BtnDelete3);

            // Si le joueur a complété tous les chapitres disponibles
            if (lvlGame1 > 5)
            {
                DisplayExistingGameButtons(BtnGame1, BtnDelete1, "A SUIVRE ...");
                BtnGame1.Enabled = false;
            }
            if (lvlGame2 > 5)
            {
                DisplayExistingGameButtons(BtnGame2, BtnDelete2, "A SUIVRE ...");
                BtnGame2.Enabled = false;
            }
            if (lvlGame3 > 5)
            {
                DisplayExistingGameButtons(BtnGame3, BtnDelete3, "A SUIVRE ...");
                BtnGame3.Enabled = false;
            }
        }

        /// <summary>
        /// Affiche les boutons pour une partie existante avec son texte spécifié.
        /// </summary>
        private void DisplayExistingGameButtons(Button gameButton, Button deleteButton, string text)
        {
            gameButton.Text = text;
            deleteButton.Enabled = true;
        }

        /// <summary>
        /// Affiche les boutons pour une nouvelle partie.
        /// </summary>
        private void DisplayNewGameButtons(Button gameButton, Button deleteButton)
        {
            gameButton.Text = "NOUVELLE PARTIE";
            deleteButton.Enabled = false;
        }

        /// <summary>
        /// Récupère le niveau actuel de la partie spécifiée.
        /// </summary>
        private int GetActualLevel(int game)
        {
            string[] lines = File.ReadAllLines(chemin, Encoding.UTF8);
            return int.Parse(lines[game - 1]);
        }

        /// <summary>
        /// Modifie le niveau actuel de la partie spécifiée avec la valeur spécifiée.
        /// </summary>
        private void ChangeActualLevel(int game, int value)
        {
            string[] lines = File.ReadAllLines(chemin, Encoding.UTF8);
            lines[game - 1] = value.ToString();
            File.WriteAllLines(chemin, lines, Encoding.UTF8);
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "CHAPITRE 1".
        /// Commence la partie du chapitre 1 ou poursuit si déjà commencée.
        /// </summary>
        private void BtnGame1_Click(object sender, EventArgs e)
        {
            Program.game = 1;
            if (lvlGame1 <= 0)
            {
                ChangeActualLevel(1, 1);
                lvlGame1 = 1;
            }
            Program.FrmDialogue = new FrmDialogue(lvlGame1, false);
            Program.ChangeActiveForm(Program.FrmDialogue, this);
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "CHAPITRE 2".
        /// Commence la partie du chapitre 2 ou poursuit si déjà commencée.
        /// </summary>
        private void BtnGame2_Click(object sender, EventArgs e)
        {
            Program.game = 2;
            if (lvlGame2 <= 0)
            {
                ChangeActualLevel(2, 1);
                lvlGame2 = 1;
            }
            Program.FrmDialogue = new FrmDialogue(lvlGame2, false);
            Program.ChangeActiveForm(Program.FrmDialogue, this);
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "CHAPITRE 3".
        /// Commence la partie du chapitre 3 ou poursuit si déjà commencée.
        /// </summary>
        private void BtnGame3_Click(object sender, EventArgs e)
        {
            Program.game = 3;
            if (lvlGame3 <= 0)
            {
                ChangeActualLevel(3, 1);
                lvlGame3 = 1;
            }
            Program.FrmDialogue = new FrmDialogue(lvlGame3, false);
            Program.ChangeActiveForm(Program.FrmDialogue, this);
        }

        /// <summary>
        /// Demande à l'utilisateur s'il souhaite vraiment supprimer la partie spécifiée.
        /// </summary>
        public bool DemandeSuppressionPartie(Button gameButton, Button deleteButton, int game)
        {
            DialogResult dialogResult = MessageBox.Show("Voulez-vous vraiment supprimer cette partie ?", "Message-Puck-Man", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ChangeActualLevel(game, 0);
                gameButton.Text = "NOUVELLE PARTIE";
                gameButton.Enabled = true;
                deleteButton.Enabled = false;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Supprimer" du chapitre 1.
        /// Supprime la partie du chapitre 1 si confirmé par l'utilisateur.
        /// </summary>
        private void BtnDelete1_Click(object sender, EventArgs e)
        {
            if (DemandeSuppressionPartie(BtnGame1, BtnDelete1, 1))
                lvlGame1 = 0;
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Supprimer" du chapitre 2.
        /// Supprime la partie du chapitre 2 si confirmé par l'utilisateur.
        /// </summary>
        private void BtnDelete2_Click(object sender, EventArgs e)
        {
            if (DemandeSuppressionPartie(BtnGame2, BtnDelete2, 2))
                lvlGame2 = 0;
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Supprimer" du chapitre 3.
        /// Supprime la partie du chapitre 3 si confirmé par l'utilisateur.
        /// </summary>
        private void BtnDelete3_Click(object sender, EventArgs e)
        {
            if (DemandeSuppressionPartie(BtnGame3, BtnDelete3, 3))
                lvlGame3 = 0;
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Retour".
        /// Retourne au menu principal.
        /// </summary>
        private void BtnRetour_Click(object sender, EventArgs e)
        {
            if (Program.FrmPlay == null)
                Program.FrmPlay = new FrmPlay();
            Program.ChangeActiveForm(Program.FrmPlay, this);
        }
    }
}
