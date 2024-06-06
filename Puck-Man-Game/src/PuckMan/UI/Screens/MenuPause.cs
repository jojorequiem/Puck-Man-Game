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
    public partial class MenuPause : FormComponent
    {
        public Form FormParent;
        public MenuPause(Form formParent)
        {
            InitializeComponent();
            FormParent = formParent;
        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            DisplayForm(new Menu(), this);
        }

        private void BtnParametres_Click(object sender, EventArgs e)
        {
            DisplayForm(new Parametres(this), this);
        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            Close();
            FormParent.Show();
        }
    }
}
