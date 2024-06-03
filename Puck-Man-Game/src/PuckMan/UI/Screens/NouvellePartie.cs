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
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.DoubleBuffered = true;
            this.KeyDown += (sender, e) => P1.PlayerKeyDown(sender, e);
            this.KeyUp += (sender, e) => P1.PlayerKeyUp(sender, e);
            ModeHistoire = modeHistoire;
            NiveauActuel = niveauActuel;

            //Maze instanceMaze = new Maze(this, 25, 15);
            Maze instanceMaze = new Maze(this, 7, 5);
            P1 = new Player("joueur", 3, 1, instanceMaze.startX * Maze.cellSize, instanceMaze.startY * Maze.cellSize, instanceMaze);
            instanceMaze.Entities[instanceMaze.startX * Maze.cellSize,instanceMaze.startY * Maze.cellSize] = P1;

            if (ModeHistoire)
                Program.PlayMusic("assets/audio/musiqueModeHistoire.mp3");
            else
            {
                Program.PlayMusic("assets/audio/musiqueModeInfini.mp3");
                instanceMaze.GenerateCollectable("fragment", instanceMaze.numGeneratedFragments);
                //instanceMaze.GenerateCollectable("potion degat", 1);
                instanceMaze.GenerateCollectable("portail teleportation", 1);
                instanceMaze.GenerateEnemy("égaré", instanceMaze.numberOfOpponents);
                instanceMaze.DisplayMazeMatrix();
            }
            LblFragmentCollecte.Text = "0";
            LblFragmentGenere.Text = instanceMaze.numGeneratedFragments.ToString();

            this.Controls.Add(P1.Image);
            P1.Image.BringToFront();
            UpdateHPdisplay();
        }

        public void Destructeur()
        {
            P1.Maze.EnemyList.Clear();
            P1.Maze.FragmentList.Clear();
            P1.Maze.MazeForm.Dispose();
            for (int x = 0; x < P1.Maze.width; x++)
            {
                for (int y = 0; y < P1.Maze.height; y++)
                {
                    P1.Maze.Entities[x, y] = null;
                }
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
            Debug.WriteLine("NIVEAU SUIVANT");
            Destructeur();
            P1.isDead = true;
            if (ModeHistoire) {
                Program.LoadScene(typeof(Dialogue), this);
                
            }
            else
            {
                Program.LoadScene(typeof(NiveauSuivant), this);
            }
        }
    }
}
