using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    public partial class FrmModeHistoire : FormComponent
    {
        private int lvlGame1;
        private int lvlGame2;
        private int lvlGame3;
        static private readonly string chemin = "src/database/modeHistoire.txt";
        public FrmModeHistoire() : base()
        {
            InitializeComponent();
            DisplayButtons();
        }

        public void DisplayButtons()
        {
            lvlGame1 = GetActualLevel(1);
            lvlGame2 = GetActualLevel(2);
            lvlGame3 = GetActualLevel(3);


            if (lvlGame1 > 0)
                AfficherBoutonsPartieExistante(BtnGame1, BtnDelete1, "CHAPITRE " + lvlGame1);
            else
                AfficherBoutonsPartieSupprimer(BtnGame1, BtnDelete1);

            if (lvlGame2 > 0)
                AfficherBoutonsPartieExistante(BtnGame2, BtnDelete2, "CHAPITRE " + lvlGame2);
            else
                AfficherBoutonsPartieSupprimer(BtnGame2, BtnDelete2);

            if (lvlGame3 > 0)
                AfficherBoutonsPartieExistante(BtnGame3, BtnDelete3, "CHAPITRE " + lvlGame3);
            else
                AfficherBoutonsPartieSupprimer(BtnGame3, BtnDelete3);

            // si le joueur a complété tout les chapitres
            if (lvlGame1 > 5)
            {
                AfficherBoutonsPartieExistante(BtnGame1, BtnDelete1, "A SUIVRE ...");
                BtnGame1.Enabled = false;
            }
            if (lvlGame2 > 5)
            {
                AfficherBoutonsPartieExistante(BtnGame2, BtnDelete2, "A SUIVRE ...");
                BtnGame2.Enabled = false;
            }
            if (lvlGame3 > 5)
            {
                AfficherBoutonsPartieExistante(BtnGame3, BtnDelete3, "A SUIVRE ...");
                BtnGame3.Enabled = false;
            }
        }


        private void AfficherBoutonsPartieExistante(Button boutonPartie, Button boutonSupprimer, string text)
        {
            boutonPartie.Text = text;
            boutonSupprimer.Enabled = true;
        }

        private void AfficherBoutonsPartieSupprimer(Button boutonPartie, Button boutonSupprimer)
        {
            boutonPartie.Text = "NOUVELLE PARTIE";
            boutonSupprimer.Enabled = false;
        }

        private int GetActualLevel(int game)
        {
            //renvoit le niveau actuel de la partie game (partie 1, 2 ou 3)
            string[] lines = File.ReadAllLines(chemin, Encoding.UTF8);
            return int.Parse(lines[game - 1]);
        }

        private void ChangeActualLevel(int game, int value)
        {
            string[] lines = File.ReadAllLines(chemin, Encoding.UTF8);
            lines[game - 1] = (value).ToString();
            File.WriteAllLines(chemin, lines, Encoding.UTF8);
        }

        private void BtnGame1_Click(object sender, EventArgs e)
        {
            Program.game = 1;
            if (lvlGame1 <= 0)
            {
                ChangeActualLevel(1, 1);
                lvlGame1 = 1;
            }
            Program.FrmDialogue = new FrmDialogue(lvlGame1, false);
            Program.ChangeActiveForm(Program.FrmDialogue, this);
        }
        private void BtnGame2_Click(object sender, EventArgs e)
        {
            Program.game = 2;
            if (lvlGame2 <= 0)
            {
                ChangeActualLevel(2, 1);
                lvlGame2 = 1;
            }
            Program.FrmDialogue = new FrmDialogue(lvlGame2, false);
            Program.ChangeActiveForm(Program.FrmDialogue, this);
        }

        private void BtnGame3_Click(object sender, EventArgs e)
        {
            Program.game = 3;
            if (lvlGame3 <= 0)
            {
                ChangeActualLevel(3, 1);
                lvlGame3 = 1;
            }
            Program.FrmDialogue = new FrmDialogue(lvlGame3, false);
            Program.ChangeActiveForm(Program.FrmDialogue, this);
        }
        public bool DemandeSuppresionPartie(Button boutonPartie, Button boutonSupprimer, int game)
        {
            DialogResult dialogResult = MessageBox.Show("Voulez-vous vraiment supprimer cette partie ?", "Message-Puck-Man", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ChangeActualLevel(game, 0);
                boutonPartie.Text = "NOUVELLE PARTIE";
                boutonPartie.Enabled = true;
                boutonSupprimer.Enabled = false;
                return true;
            }
            return false;
        }

        private void BtnDelete1_Click(object sender, EventArgs e)
        {
            if (DemandeSuppresionPartie(BtnGame1, BtnDelete1, 1))
                lvlGame1 = 0;
        }

        private void BtnDelete2_Click(object sender, EventArgs e)
        {
            if (DemandeSuppresionPartie(BtnGame2, BtnDelete2, 2))
                lvlGame2 = 0;
        }
        private void BtnDelete3_Click(object sender, EventArgs e)
        {
            if (DemandeSuppresionPartie(BtnGame3, BtnDelete3, 3))
                lvlGame3 = 0;
        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            if (Program.FrmPlay == null)
                Program.FrmPlay = new FrmPlay();
            Program.ChangeActiveForm(Program.FrmPlay, this);
        } 

    }
}
