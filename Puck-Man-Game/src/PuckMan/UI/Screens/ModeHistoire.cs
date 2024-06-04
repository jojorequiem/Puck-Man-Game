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
    public partial class ModeHistoire : FormComponent
    {
        public int niveauPartie1;
        public int niveauPartie2;
        public int niveauPartie3;
        public ModeHistoire() : base()
        {
            InitializeComponent();
            niveauPartie1 = GetActualLevel(1);
            niveauPartie2 = GetActualLevel(2);
            niveauPartie3 = GetActualLevel(3);

            if (niveauPartie1 > 0)
                AfficherBoutonsPartieExistante(BtnGame1, BtnDelete1, "CHAPITRE " + niveauPartie1);
            else
                AfficherBoutonsPartieSupprimer(BtnGame1, BtnDelete1);

            if (niveauPartie2 > 0)
                AfficherBoutonsPartieExistante(BtnGame2, BtnDelete2, "CHAPITRE " + niveauPartie2);
            else
                AfficherBoutonsPartieSupprimer(BtnGame2, BtnDelete2);

            if (niveauPartie3 > 0)
                AfficherBoutonsPartieExistante(BtnGame3, BtnDelete3, "CHAPITRE " + niveauPartie3);
            else
                AfficherBoutonsPartieSupprimer(BtnGame3, BtnDelete3);
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
            string[] lines = File.ReadAllLines("src/PuckMan/Game/Levels/modeHistoire.txt", Encoding.UTF8);
            return int.Parse(lines[game - 1]);
        }
        private void BtnGame1_Click(object sender, EventArgs e)
        {
            if (niveauPartie1>0)
                DisplayForm(new NouvellePartie(true, niveauPartie1), this);
            else
                DisplayForm(new Dialogue(), this);
        }
        private void BtnGame2_Click(object sender, EventArgs e)
        {
            if (niveauPartie2 > 0)
                DisplayForm(new NouvellePartie(true, niveauPartie2), this);
            else
                DisplayForm(new Dialogue(), this);
        }

        private void BtnGame3_Click(object sender, EventArgs e)
        {
            if (niveauPartie3 > 0)
                DisplayForm(new NouvellePartie(true, niveauPartie3), this);
            else
            {
                DisplayForm(new Dialogue(), this);

            }
        }


        public void DemandeSuppresionPartie(Button boutonPartie)
        {
            DialogResult dialogResult = MessageBox.Show("Voulez-vous vraiment supprimer cette partie ?", "Message-Puck-Man", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                boutonPartie.Text = "NOUVELLE PARTIE";
            }
        }

        private void BtnDelete1_Click(object sender, EventArgs e)
        {
            DemandeSuppresionPartie(BtnGame1);
        }

        private void BtnDelete2_Click(object sender, EventArgs e)
        {
            DemandeSuppresionPartie(BtnGame2);
        }
        private void BtnDelete3_Click(object sender, EventArgs e)
        {
            DemandeSuppresionPartie(BtnGame3);
        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            DisplayForm(new MenuParametreJouer(), this);
        } 

    }
}
