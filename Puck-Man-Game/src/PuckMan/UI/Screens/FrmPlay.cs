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
    public partial class FrmPlay : FormComponent
    {
        public FrmPlay()
        {
            InitializeComponent();
        }

        private void BtnModeInfini_Click(object sender, EventArgs e)
        {
            if (Program.FrmCreateNewGame == null)
                Program.FrmCreateNewGame = new FrmCreateNewGame();
            Program.ChangeActiveForm(Program.FrmCreateNewGame, this);
        }

    
        private void BtnRetour_Click(object sender, EventArgs e)
        {
            if (Program.FrmMenu == null)
                Program.FrmMenu = new FrmMenu();
            Program.ChangeActiveForm(Program.FrmMenu, this);
        }

        private void BtnModeHistoire_Click(object sender, EventArgs e)
        {
            if (Program.FrmModeHistoire == null)
                Program.FrmModeHistoire = new FrmModeHistoire();
            Program.ChangeActiveForm(Program.FrmModeHistoire, this);
        }
    }
}
