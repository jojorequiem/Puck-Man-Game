using Puck_Man_Game.src.PuckMan.Engine.Entities;
using Puck_Man_Game.src.PuckMan.Game;
using Puck_Man_Game.src.PuckMan.Game.Entities;
using Puck_Man_Game.src.PuckMan.Game.Levels;
using Puck_Man_Game.src.PuckMan.UI.Screens;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    public partial class NouvellePartie : Form
    {
        public bool ModeHistoire;
        static public Joueur J1 { get; set; }
        public NouvellePartie()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.DoubleBuffered = true;
            this.KeyDown += (sender, e) => J1.JoueurKeyDown(sender, e);

            ModeHistoire = true;

            Labyrinthe instanceLaby = new Labyrinthe(this, 21, 19);
            J1 = new Joueur("Dodonut", 3, 1, instanceLaby.StartX * Labyrinthe.TailleCase, instanceLaby.StartY * Labyrinthe.TailleCase, instanceLaby);
            instanceLaby.Entites[instanceLaby.StartX * Labyrinthe.TailleCase,instanceLaby.StartY * Labyrinthe.TailleCase] = J1;
            instanceLaby.GenerationEntite(typeof(Collectable), "fragment", instanceLaby.NbrFragmentGenere);
            instanceLaby.GenerationEntite(typeof(Adversaire), "égaré", instanceLaby.NbrAdversaires);
            LblFragmentCollecte.Text = "0";
            LblFragmentGenere.Text = instanceLaby.NbrFragmentGenere.ToString();

            this.Controls.Add(J1.Image);
            J1.Image.BringToFront();
            ActualiserAffichagePV();
        }

        public void ActualiserAffichagePV()
        {
            LblPV.Text = J1.PV.ToString();
        }

        public void FragmentCollecte()
        {
            LblFragmentCollecte.Text = (int.Parse(LblFragmentCollecte.Text) + 1).ToString();
            if (int.Parse(LblFragmentCollecte.Text) >= J1.Laby.NbrFragmentGenere)
                NiveauSuivant();
        }

        public void NiveauSuivant()
        {
            if (ModeHistoire) {
                Program.ChargerScene(typeof(Dialogue), this);
            }
            else
            {
                Program.ChargerScene(typeof(NiveauSuivant), this);
            }
        }
    }
}
