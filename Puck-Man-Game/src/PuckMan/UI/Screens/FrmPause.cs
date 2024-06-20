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
    /// Fenêtre de pause du jeu.
    /// </summary>
    public partial class FrmPause : FormComponent
    {
        public Form FormParent;

        /// <summary>
        /// Constructeur de la classe FrmPause.
        /// Initialise la fenêtre de pause avec son formulaire parent.
        /// </summary>
        /// <param name="formParent">Formulaire parent qui a ouvert cette fenêtre de pause.</param>
        public FrmPause(Form formParent)
        {
            InitializeComponent();
            FormParent = formParent;
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Quitter".
        /// Ferme la fenêtre parente si elle existe et retourne au menu principal.
        /// </summary>
        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
                ParentForm.Dispose();
            Program.ChangeActiveForm(Program.FrmMenu, this);
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Paramètres".
        /// Ouvre la fenêtre des paramètres si elle n'existe pas déjà et la rend active.
        /// </summary>
        private void BtnParametres_Click(object sender, EventArgs e)
        {
            if (Program.FrmParameters == null)
                Program.FrmParameters = new FrmParameters(this);
            Program.ChangeActiveForm(Program.FrmParameters, this);
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Retour".
        /// Retourne à la fenêtre parente sans fermer le jeu.
        /// </summary>
        private void BtnRetour_Click(object sender, EventArgs e)
        {
            Program.ChangeActiveForm(FormParent, this);
        }
    }
}
