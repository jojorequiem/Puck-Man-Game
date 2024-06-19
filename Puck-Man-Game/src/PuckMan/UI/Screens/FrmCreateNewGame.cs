using Puck_Man_Game.src.PuckMan.Engine;
using Puck_Man_Game.src.PuckMan.Game.Entities;
using src.PuckMan.Game.Levels;
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
    public partial class FrmCreateNewGame : FormComponent
    {
        public byte difficulte;
        public FrmCreateNewGame()
        {
            InitializeComponent();
        }
    

        private void ChkDifficulteFacile_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDifficulteFacile.Checked)
            {
                ChkDifficulteDifficile.Checked = ChkDifficulteNormal.Checked = false;
            }
        }

        private void ChkDifficulteNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDifficulteNormal.Checked)
            {
                ChkDifficulteFacile.Checked = ChkDifficulteDifficile.Checked = false;
            }
        }

        private void ChkDifficulteDifficile_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDifficulteDifficile.Checked)
            {
                ChkDifficulteFacile.Checked = ChkDifficulteNormal.Checked = false;
            }
        }

        private void BtnSauvegarder_Click(object sender, EventArgs e)
        {
            bool difficulteChoisie = ChkDifficulteFacile.Checked || ChkDifficulteNormal.Checked || ChkDifficulteDifficile.Checked;
            if (!difficulteChoisie)
            {
                LblAlertPartie.Text = "Vous devez sélectionner une difficulté.";
                LblAlertPartie.ForeColor = Color.Red;
                return;
            }

            LblAlertPartie.Text = "";
            {
            if (Program.FrmNouvellePartie != null)
                {
                    //pour éviter de probleme de demander à l'utilisateur s'il veut quitter
                    Program.FrmNouvellePartie.FormClosing -= Program.FrmNouvellePartie.FormComponent_FormClosing;

                    Program.FrmNouvellePartie.Close();
                    Program.FrmNouvellePartie.Dispose();
                }
                if (ChkDifficulteFacile.Checked)
                {
                    difficulte = 1;
                }
                else if (ChkDifficulteNormal.Checked)
                {
                    difficulte = 2;
                }
                else if (ChkDifficulteDifficile.Checked)
                {
                    difficulte = 3;
                }
 
                    Program.FrmNouvellePartie = new FrmNouvellePartie(difficulte, false, 0);
                Program.ChangeActiveForm(Program.FrmNouvellePartie, this);
            }

        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            if (Program.FrmPlay == null)
                Program.FrmPlay = new FrmPlay();
            Program.ChangeActiveForm(Program.FrmPlay, this);
        }
    }
}