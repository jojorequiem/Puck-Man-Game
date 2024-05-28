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
    public partial class Dialogue : FormComponent
    {
        public Dialogue() : base() // Déplacez base() après InitializeComponent()
        {
            InitializeComponent();
        }

        private void BtnSuivantDialogue_Click(object sender, EventArgs e)
        {
            Program.LoadScene(typeof(NiveauSuivant), this);
        }
    }
}
