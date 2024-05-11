using Puck_Man_Game.src.PuckMan.UI.Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puck_Man_Game.src.PuckMan.UI
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void btnJouer_Click(object sender, EventArgs e)
        {
            MenuParametreJouer menuParametreJouer = new MenuParametreJouer();
            menuParametreJouer.StartPosition = FormStartPosition.Manual;
            menuParametreJouer.Location = this.Location;
            menuParametreJouer.Show();
            this.Hide(); // Masquer la fenêtre actuelle
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}