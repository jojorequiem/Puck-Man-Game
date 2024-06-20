using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    /// <summary>
    /// Fenêtre principale du jeu avec les options de jeu.
    /// </summary>
    public partial class FrmPlay : FormComponent
    {
        /// <summary>
        /// Constructeur de la classe FrmPlay.
        /// Initialise la fenêtre principale du jeu.
        /// </summary>
        public FrmPlay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Mode Infini".
        /// Ouvre la fenêtre de création de nouvelle partie en mode infini.
        /// </summary>
        private void BtnModeInfini_Click(object sender, EventArgs e)
        {
            if (Program.FrmCreateNewGame == null)
                Program.FrmCreateNewGame = new FrmCreateNewGame();
            Program.ChangeActiveForm(Program.FrmCreateNewGame, this);
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Retour".
        /// Retourne au menu principal.
        /// </summary>
        private void BtnRetour_Click(object sender, EventArgs e)
        {
            if (Program.FrmMenu == null)
                Program.FrmMenu = new FrmMenu();
            Program.ChangeActiveForm(Program.FrmMenu, this);
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Mode Histoire".
        /// Ouvre la fenêtre du mode histoire.
        /// </summary>
        private void BtnModeHistoire_Click(object sender, EventArgs e)
        {
            if (Program.FrmStoryMode == null)
                Program.FrmStoryMode = new FrmStoryMode();
            Program.ChangeActiveForm(Program.FrmStoryMode, this);
        }
    }
}
