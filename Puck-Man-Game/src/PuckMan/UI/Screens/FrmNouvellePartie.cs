using Puck_Man_Game.src.PuckMan.Engine.Entities;
using Puck_Man_Game.src.PuckMan.Game;
using Puck_Man_Game.src.PuckMan.Game.Entities;
using Puck_Man_Game.src.PuckMan.Game.Levels;
using Puck_Man_Game.src.PuckMan.UI.Screens;
using src.PuckMan.Game.Levels;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
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
    public partial class FrmNouvellePartie : FormComponent
    {
        public bool ModeHistoire;
        public int NiveauActuel;
        public Player P1 { get; set; }
        public int nbrFragmentGenere;
        public FrmNouvellePartie(byte difficulte, bool modeHistoire, int niveauActuel) : base()
        {
            this.ClientSize = new Size(Program.LargeurFenetre, Program.HauteurFenetre);
            InitializeComponent();
            this.ClientSize = new Size(Program.LargeurFenetre, Program.HauteurFenetre);

            this.KeyDown += (sender, e) => P1.PlayerKeyDown(sender, e);
            this.KeyUp += (sender, e) => P1.PlayerKeyUp(sender, e);
            ModeHistoire = modeHistoire;
            NiveauActuel = niveauActuel;

            Maze maze = new Maze(this, Program.MazeWidth, Program.MazeHeight);
            P1 = new Player("joueur", 3, maze.startX * Maze.cellSize, maze.startY * Maze.cellSize, maze);
            maze.Entities[maze.startX * Maze.cellSize, maze.startY * Maze.cellSize] = P1;

            if (ModeHistoire)
            {
                this.BackgroundImage = Properties.Resources.background;
                Program.PlayMusic("assets/audio/musiqueNiveau" + NiveauActuel + ".mp3");
            }

            else
            {
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.BackgroundImage = Properties.Resources.background2;
                Program.PlayMusic("assets/audio/musiqueModeInfini.mp3");
                maze.GenerateCollectable("fragment", 1, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
                maze.GenerateCollectable("fragment degat", 0, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
                maze.GenerateCollectable("portail teleportation", 0, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
                maze.GenerateCollectable("soin", 1, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
                maze.GenerateEnemy("égaré", 1, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
                maze.GenerateEnemy("égaré berserker", 0, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));

            }

            nbrFragmentGenere = maze.FragmentList.Count();
            LblFragmentGenere.Text = nbrFragmentGenere.ToString();
            this.Controls.Add(P1.Image);
            P1.Image.BringToFront();
            UpdateHPdisplay();
            maze.DisplayMazeMatrix();
        }

        public void Destructeur()
        {
            foreach (Enemy enemy in P1.Maze.EnemyList)
            {
                if (enemy != null)
                    enemy.moveEnemyTimer.Stop();
            }
            P1.Maze.EnemyList.Clear();
            foreach (Collectable collectable in P1.Maze.StaticEntities)
            {
                if (collectable != null)
                    collectable.DejaCollecte = true;
            }
            P1.Maze.StaticEntities = null;
            P1.Maze.FragmentList.Clear();
            P1.Maze.MazeForm.Dispose();

            P1.moveTimer.Stop();
            P1 = null;
            Dispose();
        }

        public void UpdateHPdisplay()
        {
            if (P1 != null)
                LblPV.Text = P1.HP.ToString();
        }
        public void UpdateFragmentdisplay()
        {
            if (P1 != null)
                LblFragmentCollecte.Text = (nbrFragmentGenere - P1.Maze.FragmentList.Count()).ToString();
        }

        public void NiveauSuivant()
        {

            Destructeur();
            if (ModeHistoire)
            {
                if (Program.FrmDialogue == null)
                {
                    Program.FrmDialogue.Close();
                    Program.FrmDialogue.Dispose();
                }
                Program.FrmDialogue = new FrmDialogue(NiveauActuel, true);
                Program.ChangeActiveForm(Program.FrmDialogue, this);
            }
            else
            {
                Program.PlaySound("assets/audio/finishLevel.wav");
                if (Program.FrmNiveauSuivant == null)
                    Program.FrmNiveauSuivant = new FrmNiveauSuivant();
                Program.ChangeActiveForm(Program.FrmNiveauSuivant, this);
            }
        }

    }
}
