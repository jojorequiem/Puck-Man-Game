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
    public partial class NouvellePartie : FormComponent
    {
        public bool ModeHistoire;
        public int NiveauActuel;
        public Player P1 { get; set; }
      
        public NouvellePartie(bool modeHistoire, int niveauActuel) : base()
        {
            InitializeComponent();
            this.KeyDown += (sender, e) => P1.PlayerKeyDown(sender, e);
            this.KeyUp += (sender, e) => P1.PlayerKeyUp(sender, e);
            ModeHistoire = modeHistoire;
            NiveauActuel = niveauActuel;
            
            Maze maze = new Maze(this, Program.MazeWidth, Program.MazeHeight);
            P1 = new Player("joueur", 3, 1, maze.startX * Maze.cellSize, maze.startY * Maze.cellSize, maze);
            maze.Entities[maze.startX * Maze.cellSize, maze.startY * Maze.cellSize] = P1;
            maze.DisplayMazeMatrix();

            if (ModeHistoire)
            {
                this.BackgroundImage = Properties.Resources.background;
                Program.PlayMusic("assets/audio/musiqueModeHistoire.mp3");
            }
            else
            {
                //this.BackgroundImageLayout = ImageLayout.Stretch;
                //this.BackgroundImage = Properties.Resources.background3;
                //maze.GenerateCollectable("fragment", maze.numGeneratedFragments, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
                Program.PlayMusic("assets/audio/musiqueModeInfini.mp3");
                //maze.GenerateCollectable("fragment", maze.numGeneratedFragments, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
                ////maze.GenerateCollectable("potion degat", 1, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
               // maze.GenerateCollectable("portail teleportation", 1, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
                //maze.GenerateEnemy("égaré", 1, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
                maze.DisplayMazeMatrix();
            }
            LblFragmentGenere.Text = maze.numGeneratedFragments.ToString();
            this.Controls.Add(P1.Image);
            P1.Image.BringToFront();
            UpdateHPdisplay();
        }

        /*
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            if (this.BackgroundImage != null)
                e.Graphics.DrawImage(this.BackgroundImage, this.ClientRectangle);
            base.OnPaint(e);
        }*/

        public void Destructeur()
        {
            P1.Maze.EnemyList.Clear();
            P1.Maze.FragmentList.Clear();
            P1.Maze.MazeForm.Dispose();
            for (int x = 0; x < P1.Maze.width; x++)
            {
                for (int y = 0; y < P1.Maze.height; y++)
                    P1.Maze.Entities[x, y] = null;
            }
            Dispose();
        }

        public void UpdateHPdisplay()
        {
            LblPV.Text = P1.HP.ToString();
        }
        public void UpdateFragmentdisplay()
        {
            LblFragmentCollecte.Text = P1.Maze.FragmentList.Count().ToString();
        }
        public void NiveauSuivant()
        {
            Program.PlayMusic("assets/audio/finishLevel.wav");
            Destructeur();
            P1.isDead = true;
            if (ModeHistoire) {
                if (Program.Dialogue == null)
                {
                    Program.Dialogue.Close();
                    Program.Dialogue.Dispose();
                }
                Program.Dialogue = new Dialogue(NiveauActuel, true);
                Program.ChangeActiveForm(Program.Dialogue, this);
            }
            else
            {
                if (Program.NiveauSuivant == null)
                    Program.NiveauSuivant = new NiveauSuivant();
                Program.ChangeActiveForm(Program.NiveauSuivant, this);
            }
        }
    }
}
