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
        public bool partie1;
        public bool partie2;
        public bool partie3;
        public ModeHistoire() : base()
        {
            InitializeComponent();
            partie1 = true;
            partie2 = true;
            partie3 = false;

            if (partie1)
                AfficherBoutonsPartieExistante(BtnGame1, BtnDelete1);
            else
                AfficherBoutonsPartieSupprimer(BtnGame1, BtnDelete1);

            if (partie2)
                AfficherBoutonsPartieExistante(BtnGame2, BtnDelete2);
            else
                AfficherBoutonsPartieSupprimer(BtnGame2, BtnDelete2);

            if (partie3)
                AfficherBoutonsPartieExistante(BtnGame3, BtnDelete3);
            else
                AfficherBoutonsPartieSupprimer(BtnGame3, BtnDelete3);
        }

        private void AfficherBoutonsPartieExistante(Button boutonPartie, Button boutonSupprimer)
        {
            boutonPartie.Text = "Chapitre ..";
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
            DisplayForm(new NouvellePartie(true, GetActualLevel(1)), this);
        }
        private void BtnGame2_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(GetActualLevel(2));
        }

        private void BtnGame3_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(GetActualLevel(3));
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
