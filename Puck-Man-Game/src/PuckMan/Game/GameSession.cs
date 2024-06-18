using System;
using System.Windows.Forms;
using Puck_Man_Game.src.PuckMan.Engine.Entities;
using Puck_Man_Game.src.PuckMan.Game;
using Puck_Man_Game.src.PuckMan.Game.Entities;
using Puck_Man_Game.src.PuckMan.Game.Levels;
using Puck_Man_Game.src.PuckMan.UI.Screens;
using src.PuckMan.Game.Levels;

namespace Puck_Man_Game.src.PuckMan.Engine
{
    public class GameSession
    {
        private FrmNouvellePartie gameForm;
        private bool ModeHistoire;
        private int NiveauActuel;
        private string pseudo;
        private string niveauDifficulte;
        private bool modeHistoire;
        private Maze maze;
        static public Player P1 { get; private set; }

        public GameSession(FrmNouvellePartie form, string pseudo, string niveauDifficulte, bool modeHistoire, int niveauActuel)
        {
            gameForm = form;
            this.pseudo = pseudo;
            this.niveauDifficulte = niveauDifficulte;
            this.modeHistoire = modeHistoire;
            NiveauActuel = niveauActuel;
            InitializeGame();
        }

        private void InitializeGame()
        {
            gameForm.KeyDown += (sender, e) => P1.PlayerKeyDown(sender, e);
            gameForm.KeyUp += (sender, e) => P1.PlayerKeyUp(sender, e);

            maze = new Maze(gameForm, Program.MazeWidth, Program.MazeHeight);
            P1 = new Player("joueur", 3, maze.startX * Maze.cellSize, maze.startY * Maze.cellSize, maze);
            maze.Entities[maze.startX * Maze.cellSize, maze.startY * Maze.cellSize] = P1;

            if (ModeHistoire)
            {
                gameForm.BackgroundImage = Properties.Resources.background;
                Program.PlayMusic("assets/audio/musiqueModeHistoire.mp3");
            }
            else
            {
                gameForm.BackgroundImageLayout = ImageLayout.Stretch;
                gameForm.BackgroundImage = Properties.Resources.background2;
                Program.PlayMusic("assets/audio/musiqueModeInfini.mp3");
                maze.GenerateCollectable("fragment", 1, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
                maze.GenerateCollectable("fragment degat", 1, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
                maze.GenerateCollectable("portail teleportation", 4, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
                maze.GenerateCollectable("soin", 1, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
                maze.GenerateEnemy("égaré", 1, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
            }

            UpdateUI();
        }

        private void UpdateUI()
        {
            var lblFragmentGenere = gameForm.Controls["LblFragmentGenere"] as Label;
            if (lblFragmentGenere != null)
            {
                lblFragmentGenere.Text = maze.FragmentList.Count.ToString();
            }

            gameForm.Controls.Add(P1.Image);
            P1.Image.BringToFront();
            UpdateHPdisplay();
        }

        public void DestructGame()
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
            }

        public void UpdateHPdisplay()
        {
            if (P1 != null)
            {
                var lblPV = gameForm.Controls["LblPV"] as Label;
                if (lblPV != null)
                    lblPV.Text = P1.HP.ToString();
            }
        }

        public void UpdateFragmentdisplay()
        {
            if (P1 != null)
            {
                var lblFragmentCollecte = gameForm.Controls["LblFragmentCollecte"] as Label;
                if (lblFragmentCollecte != null)
                    lblFragmentCollecte.Text = P1.Maze.FragmentList.Count.ToString();
            }
        }
    }
}
