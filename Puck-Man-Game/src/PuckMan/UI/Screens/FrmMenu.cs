using Puck_Man_Game.src.PuckMan.UI.Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puck_Man_Game.src.PuckMan.UI
{
    /// <summary>
    /// Fenêtre principale du menu du jeu Puck-Man.
    /// Permet de naviguer vers différentes fonctionnalités du jeu telles que jouer, ajuster les paramètres, afficher le classement et les informations sur le jeu.
    /// </summary>
    public partial class FrmMenu : FormComponent
    {
        /// <summary>
        /// Constructeur par défaut de la classe FrmMenu.
        /// Initialise les composants graphiques de la fenêtre.
        /// </summary>
        public FrmMenu() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Événement déclenché lorsque le bouton "Paramètres" est cliqué.
        /// Ouvre la fenêtre des paramètres du jeu.
        /// </summary>
        private void BtnParametres_Click(object sender, EventArgs e)
        {
            if (Program.FrmParameters == null)
                Program.FrmParameters = new FrmParameters(this);
            Program.ChangeActiveForm(Program.FrmParameters, this);
        }

        /// <summary>
        /// Événement déclenché lorsque le bouton "Quitter" est cliqué.
        /// Quitte l'application.
        /// </summary>
        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Événement déclenché lorsque le bouton "Jouer" est cliqué.
        /// Lance la fenêtre de jeu.
        /// </summary>
        private void BtnJouer_Click(object sender, EventArgs e)
        {
            if (Program.FrmPlay == null)
                Program.FrmPlay = new FrmPlay();
            Program.ChangeActiveForm(Program.FrmPlay, this);
        }

        /// <summary>
        /// Événement déclenché lorsque le bouton "À Propos" est cliqué.
        /// Affiche une boîte de message avec les informations sur le jeu.
        /// </summary>
        private void BtnAPropos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Puck-Man est un projet de fin d'année développé par des étudiants en informatique à l'IUT d'Amiens (UPJV 2023-2024). Réalisé avec WinForms en C#, " +
                "il a été conçu par Jonathan Le, Paul Maillard, Attoumani Rafed, Benziane Zakarya, et Zhou Loïc.\n\nNous vous remercions d'avoir découvert Puck-Man !", "À propos");
        }

        /// <summary>
        /// Événement déclenché lorsque le bouton "Classement" est cliqué.
        /// Affiche la fenêtre de classement des scores.
        /// </summary>
        private void BtnClassement_Click(object sender, EventArgs e)
        {
            if (Program.FrmScoreRanking == null)
                Program.FrmScoreRanking = new FrmScoreRanking();
            Program.ChangeActiveForm(Program.FrmScoreRanking, this);
        }
    }
}
