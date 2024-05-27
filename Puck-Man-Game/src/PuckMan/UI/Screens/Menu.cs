﻿using Puck_Man_Game.src.PuckMan.UI.Screens;
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
    public partial class Menu : Form
    {
        public Menu()
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

        private void btnClassement_Click(object sender, EventArgs e)
        {
            Classement classementMenu = new Classement();
            classementMenu.StartPosition = FormStartPosition.Manual;
            classementMenu.Location = this.Location;
            classementMenu.Show();
            this.Hide(); // Masquer la fenêtre actuelle
        }

        private void btnParametres_Click(object sender, EventArgs e)
        {
            Parametres parametreMenu = new Parametres();
            parametreMenu.StartPosition = FormStartPosition.Manual;
            parametreMenu.Location = this.Location;
            parametreMenu.Show();
            this.Hide(); // Masquer la fenêtre actuelle
        }
    }

}