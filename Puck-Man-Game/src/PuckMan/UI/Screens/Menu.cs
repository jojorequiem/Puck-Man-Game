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
    public partial class Menu : FormComponent
    {
        public Menu() : base()
        {
            InitializeComponent();
        }

        private void btnJouer_Click(object sender, EventArgs e)
        {
            DisplayForm(new MenuParametreJouer(), this);
        }

        private void btnClassement_Click(object sender, EventArgs e)
        {
            DisplayForm(new Classement(), this);
        }

        private void btnParametres_Click(object sender, EventArgs e)
        {
            DisplayForm(new Parametres(), this);
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}