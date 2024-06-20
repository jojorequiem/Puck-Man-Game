using System;
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
using src.PuckMan.Game.Levels;

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    /// <summary>
    /// Fenêtre affichée lorsque le joueur perd dans le jeu, gérant les actions après la défaite.
    /// </summary>
    public partial class FrmDeath : FormComponent
    {
        public int Level;  // Niveau actuel où le joueur est décédé

        /// <summary>
        /// Constructeur de la classe FrmDeath.
        /// Initialise la fenêtre de mort en affichant le score du joueur et en jouant la musique de mort.
        /// Enregistre le score dans le classement si le jeu est en mode infini.
        /// </summary>
        /// <param name="pseudo">Le pseudo du joueur.</param>
        /// <param name="level">Le niveau actuel.</param>
        /// <param name="difficulty">Le niveau de difficulté du jeu (0 pour le mode histoire, >0 pour le mode infini).</param>
        public FrmDeath(string pseudo, int level, int difficulty)
        {
            InitializeComponent();
            LblValeurScore.Text = Program.score.ToString();
            Program.PlayMusic("assets/audio/DeathMusic.mp3");

            Level = level;
            if (Level > 0)
            {
                LblScore.Hide();
                LblValeurScore.Hide();
                PcbScore.Hide();
                BtnNouvellePartie.Text = "RECOMMENCER";
            }

            if (difficulty > 0) // mode infini
            {
                string filepath = "src/database/ScoreRanking.txt";
                string[] lines = File.ReadAllLines(filepath, Encoding.UTF8);

                string difficultyName = "Hardcore";
                switch (difficulty)
                {
                    case 1:
                        difficultyName = "Facile";
                        break;
                    case 2:
                        difficultyName = "Moyen";
                        break;
                    case 3:
                        difficultyName = "Difficile";
                        break;
                }
                if (lines.Length > 0)
                    lines[lines.Length - 1] += "\n" + pseudo + ";" + Program.score.ToString() + ";" + difficultyName;
                else
                    lines = new string[] { pseudo + ";" + Program.score.ToString() + ";" + difficultyName };

                File.WriteAllLines(filepath, lines, Encoding.UTF8);
            }
        }

        /// <summary>
        /// Événement déclenché lorsque le bouton "Nouvelle Partie" est cliqué.
        /// Redirige vers le formulaire de création d'une nouvelle partie ou de rejouer au niveau actuel.
        /// </summary>
        private void BtnNouvellePartie_Click(object sender, EventArgs e)
        {
            if (Level > 0)
            {
                Program.FrmNewGame = new FrmNewGame(0, true, Level, "");
                Program.ChangeActiveForm(Program.FrmNewGame, this);
            }
            else
            {
                if (Program.FrmInfiniteMode == null)
                    Program.FrmInfiniteMode = new FrmInfiniteMode();
                Program.ChangeActiveForm(Program.FrmInfiniteMode, this);
            }
            CloseForm();  // Ferme le formulaire de mort
        }

        /// <summary>
        /// Ferme proprement le formulaire actuel en supprimant les événements de fermeture et en libérant les ressources.
        /// </summary>
        private void CloseForm()
        {
            this.FormClosing -= this.FormComponent_FormClosing;
            this.Close();
            this.Dispose();
        }

        /// <summary>
        /// Événement déclenché lorsque le bouton "Menu" est cliqué.
        /// Redirige vers le menu principal du jeu.
        /// </summary>
        private void BtnMenu_Click(object sender, EventArgs e)
        {
            if (Program.FrmMenu == null)
                Program.FrmMenu = new FrmMenu();
            Program.ChangeActiveForm(Program.FrmMenu, this);
            CloseForm();  // Ferme le formulaire de mort
        }
    }
}
