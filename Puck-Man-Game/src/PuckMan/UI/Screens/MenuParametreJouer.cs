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
    public partial class MenuParametreJouer : FormComponent
    {
        
        public MenuParametreJouer() : base()
        {
            InitializeComponent();
        }

        private Point savedLocation; // Variable pour stocker la position de la fenêtre


        private void btnRetour_Click(object sender, EventArgs e)
        {
            savedLocation = this.Location; // Enregistrer la position actuelle de la fenêtre
            this.Hide(); // Masquer la fenêtre actuelle
            Menu mainMenuForm = new Menu();
            mainMenuForm.StartPosition = FormStartPosition.Manual; // Définir le démarrage de la nouvelle fenêtre à manuel
            mainMenuForm.Location = savedLocation; // Définir la position de la nouvelle fenêtre à la position enregistrée
            mainMenuForm.Show(); // Afficher MainMenuForm à nouveau
        }

        private void btnNouvellePartie_Click(object sender, EventArgs e)
        {
            NouvellePartie menuNouvellePartie = new NouvellePartie();
            menuNouvellePartie.StartPosition = FormStartPosition.Manual;
            menuNouvellePartie.Location = this.Location;
            menuNouvellePartie.Show();
            this.Hide(); // Masquer la fenêtre actuelle
        }
    }
}
