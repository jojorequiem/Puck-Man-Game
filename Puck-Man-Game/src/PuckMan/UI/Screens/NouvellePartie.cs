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
    public partial class NouvellePartie : Form
    {
        public bool ModeHistoire;
        static public Player P1 { get; set; }
        public NouvellePartie()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.DoubleBuffered = true;
            this.KeyDown += (sender, e) => P1.PlayerKeyDown(sender, e);

            ModeHistoire = true;

            Maze instanceMaze = new Maze(this, 21, 19);
            P1 = new Player("Dodonut", 3, 1, instanceMaze.startX * Maze.cellSize, instanceMaze.startY * Maze.cellSize, instanceMaze);
            instanceMaze.Entities[instanceMaze.startX * Maze.cellSize,instanceMaze.startY * Maze.cellSize] = P1;
            instanceMaze.GenerateEntities(typeof(Collectable), "fragment", instanceMaze.numGeneratedFragments);
            instanceMaze.GenerateEntities(typeof(Enemy), "égaré", instanceMaze.numberOfOpponents);
            LblFragmentCollecte.Text = "0";
            LblFragmentGenere.Text = instanceMaze.numGeneratedFragments.ToString();

            this.Controls.Add(P1.Image);
            P1.Image.BringToFront();
            UpdateHPdisplay();
        }

        public void UpdateHPdisplay()
        {
            LblPV.Text = P1.HP.ToString();
        }

        public void FragmentCollecte()
        {
            LblFragmentCollecte.Text = (int.Parse(LblFragmentCollecte.Text) + 1).ToString();
            if (int.Parse(LblFragmentCollecte.Text) >= P1.MazeMatrix.numGeneratedFragments)
                NiveauSuivant();
        }

        public void NiveauSuivant()
        {
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
