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

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    /// <summary>
    /// Fenêtre affichée après avoir terminé un niveau, permettant de passer au niveau suivant ou de retourner au menu principal.
    /// </summary>
    public partial class FrmNextLevel : FormComponent
    {
        private string Pseudo;
        private byte Difficulty;

        /// <summary>
        /// Constructeur de la classe FrmNextLevel.
        /// Initialise la fenêtre avec le pseudo du joueur et le niveau de difficulté.
        /// </summary>
        /// <param name="pseudo">Pseudo du joueur.</param>
        /// <param name="difficulty">Niveau de difficulté.</param>
        public FrmNextLevel(string pseudo, byte difficulty)
        {
            InitializeComponent();
            Pseudo = pseudo;
            Difficulty = difficulty;
        }

        /// <summary>
        /// Événement déclenché lorsque la fenêtre de niveau suivant est affichée.
        /// Met le focus sur le bouton "Niveau Suivant".
        /// </summary>
        private void FrmNiveauSuivant_Shown(object sender, EventArgs e)
        {
            BtnNiveauSuivant.Focus();
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Niveau Suivant".
        /// Démarre une nouvelle partie avec les paramètres actuels de difficulté et pseudo.
        /// </summary>
        private void BtnNiveauSuivant_Click(object sender, EventArgs e)
        {
            Program.FrmNewGame = new FrmNewGame(Difficulty, false, 0, Pseudo);
            Program.ChangeActiveForm(Program.FrmNewGame, this);
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Retour au Menu".
        /// Retourne au menu principal et sauvegarde le score si le mode infini est activé.
        /// </summary>
        private void BtnRetourMenu_Click(object sender, EventArgs e)
        {
            if (Difficulty > 0) // mode infini (sauvegarder dans le classement)
            {
                string filepath = "src/database/ScoreRanking.txt";
                string[] lines = File.ReadAllLines(filepath, Encoding.UTF8);

                string nomDifficulte = "histoire";
                switch (Difficulty)
                {
                    case 1:
                        nomDifficulte = "Facile";
                        break;
                    case 2:
                        nomDifficulte = "Moyen";
                        break;
                    case 3:
                        nomDifficulte = "Difficile";
                        break;
                }

                if (lines.Length > 0)
                    lines[lines.Length - 1] += "\n" + Pseudo + ";" + Program.score.ToString() + ";" + nomDifficulte;
                else
                    lines = new string[] { Pseudo + ";" + Program.score.ToString() + ";" + nomDifficulte };

                File.WriteAllLines(filepath, lines, Encoding.UTF8);
            }

            Program.ChangeActiveForm(Program.FrmMenu, this);
        }

    }
}
