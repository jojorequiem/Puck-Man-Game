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
    /// Fenêtre affichant le classement des scores.
    /// </summary>
    public partial class FrmScoreRanking : FormComponent
    {
        /// <summary>
        /// Constructeur de la classe FrmScoreRanking.
        /// Initialise la fenêtre du classement des scores.
        /// </summary>
        public FrmScoreRanking()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmScoreRanking_Load);
        }

        /// <summary>
        /// Charge le classement des scores lors du chargement de la fenêtre.
        /// </summary>
        private void FrmScoreRanking_Load(object sender, EventArgs e)
        {
            DisplayClassement();
        }

        /// <summary>
        /// Affiche le classement des scores dans le DataGridView.
        /// </summary>
        public void DisplayClassement()
        {
            // Réinitialiser DgvClassement
            DgvClassement.Rows.Clear();
            DgvClassement.Columns.Clear();

            // Ajouter les colonnes nécessaires
            DgvClassement.ColumnCount = 3;
            DgvClassement.Columns[0].Name = "Pseudo";
            DgvClassement.Columns[1].Name = "Score";
            DgvClassement.Columns[2].Name = "Difficulté";

            // Chemin du fichier contenant le classement
            string filePath = "src/database/ScoreRanking.txt";
            if (File.Exists(filePath))
            {
                // Lire toutes les lignes du fichier
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    // Séparer les parties de la ligne par le délimiteur ";"
                    string[] parts = line.Split(';');
                    if (parts.Length == 3)
                    {
                        // Ajouter les données au DataGridView
                        DgvClassement.Rows.Add(parts[0], parts[1], parts[2]);
                    }
                }
            }

            // Ajuster les colonnes pour remplir l'espace disponible
            DgvClassement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Trier la colonne "Score" en ordre décroissant
            DgvClassement.Sort(DgvClassement.Columns["Score"], ListSortDirection.Descending);
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Retour".
        /// Retourne au menu principal.
        /// </summary>
        private void btnRetour_Click(object sender, EventArgs e)
        {
            if (Program.FrmMenu == null)
                Program.FrmMenu = new FrmMenu();
            Program.ChangeActiveForm(Program.FrmMenu, this);
        }
    }
}
