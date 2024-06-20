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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    /// <summary>
    /// Fenêtre de création d'une nouvelle partie dans le jeu Puck-Man.
    /// Permet de démarrer un nouveau jeu avec des paramètres de difficulté et des personnalisations.
    /// </summary>
    public partial class FrmNewGame : FormComponent
    {
        public bool StoryMod;
        public int Level;
        public Player P1 { get; set; }
        public int nbrGeneratedFragment;
        public string Pseudo = "";
        public byte Difficulty;
       
        /// <summary>
        /// Constructeur de la classe FrmNewGame.
        /// Initialise une nouvelle partie avec les paramètres spécifiés.
        /// </summary>
        /// <param name="difficulty">Niveau de difficulté de la partie.</param>
        /// <param name="storyMod">Indicateur si le mode histoire est activé.</param>
        /// <param name="level">Niveau actuel du jeu.</param>
        /// <param name="pseudo">Pseudo du joueur.</param>
        public FrmNewGame(byte difficulty, bool storyMod, int level, string pseudo) : base()
        {
            InitializeComponent();
            this.KeyDown += (sender, e) => P1.PlayerKeyDown(sender, e);
            this.KeyUp += (sender, e) => P1.PlayerKeyUp(sender, e);
            StoryMod = storyMod;
            Level = level;
            Difficulty = difficulty;
            LblPseudo.Text = pseudo;
            Pseudo = pseudo;

            Maze maze = new Maze(this, Program.MazeWidth, Program.MazeHeight);
            int nbrHp = (StoryMod) ? 3 : 4 - Difficulty;
            P1 = new Player("joueur", nbrHp, maze.startX * Maze.cellSize, maze.startY * Maze.cellSize, maze);
            maze.Entities[maze.startX * Maze.cellSize, maze.startY * Maze.cellSize] = P1;

            if (StoryMod)
            {
                Program.PlayMusic("assets/audio/MusicLevel" + Level + ".mp3");
                LblScore.Hide();
                PctBoxScore.Hide();
            }
            else
            {
                Random random = new Random();

                string[] musicList = { "InfiniteMode", "Level1", "Level2", "Level3", "Level4", "Level5" };
                Program.PlayMusic("assets/audio/Music" + musicList[random.Next(0, musicList.Length)] + ".mp3");

                //choisir le nombre d'entités en fonction de la difficulté
                int nbrEgare = 0;
                int nbrStandard = 0;
                int nbrBerserker = 0; 
                int nbrFragment = 0;
                int nbrFragmentDegat = random.Next(2);
                if (Difficulty == 1)
                {
                    nbrStandard = 1;
                    nbrEgare = 1 + random.Next(2);
                    nbrFragment = 10 + random.Next(2);
                }
                else if (Difficulty == 2)
                {
                    nbrEgare = 1 + random.Next(2);
                    nbrStandard = 1 + random.Next(2);
                    nbrBerserker = random.Next(2);
                    nbrFragment = 12 + random.Next(2); ;
                    nbrFragmentDegat += 1;
                }
                else if (Difficulty == 3)
                {
                    nbrEgare = 2 + random.Next(2);
                    nbrStandard = 1 + random.Next(2);
                    nbrBerserker = 1 + random.Next(2);
                    nbrFragment = 15 + random.Next(3);
                    nbrFragmentDegat += 2;
                }

                //généré les entités
                maze.GenerateEnemy("égaré berserker", nbrBerserker, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
                //maze.GenerateEnemy("égaré standard", nbrStandard, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
                maze.GenerateEnemy("égaré", nbrEgare, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
                maze.GenerateCollectable("soin", Difficulty, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
                maze.GenerateCollectable("fragment", nbrFragment, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
                maze.GenerateCollectable("fragment degat", nbrFragmentDegat, maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
                maze.GenerateCollectable("portail teleportation", random.Next(3), maze.GetValidCoordinates(1, maze.width - 1), maze.GetValidCoordinates(1, maze.height - 1));
            }

            nbrGeneratedFragment = maze.FragmentList.Count();
            Debug.Write("nbrGeneratedFragment" + nbrGeneratedFragment);
            this.Controls.Add(P1.Image);
            P1.Image.BringToFront();
            LblFragmentGenere.Text = nbrGeneratedFragment.ToString();
            UpdateFragmentdisplay();
            UpdateScoredisplay();
            UpdateHPdisplay();
        }

        /// <summary>
        /// Méthode de nettoyage des ressources et de fin de partie.
        /// Arrête les timers des ennemis, efface les entités statiques et nettoie la mémoire.
        /// </summary>
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

        /// <summary>
        /// Met à jour l'affichage des points de vie du joueur.
        /// </summary>
        public void UpdateHPdisplay()
        {
            if (P1 != null)
                LblPV.Text = P1.HP.ToString();
        }

        /// <summary>
        /// Met à jour l'affichage des fragments collectés par le joueur.
        /// </summary>
        public void UpdateFragmentdisplay()
        {
            if (P1 != null)
                LblFragmentCollecte.Text = (nbrGeneratedFragment - P1.Maze.FragmentList.Count()).ToString();
        }

        /// <summary>
        /// Met à jour l'affichage du score actuel du joueur.
        /// </summary>
        public void UpdateScoredisplay()
        {
            LblScore.Text = Program.score.ToString();
        }

        /// <summary>
        /// Méthode appelée pour passer au niveau suivant après la fin d'un niveau.
        /// Effectue le nettoyage des ressources et ouvre la fenêtre appropriée en fonction du mode de jeu.
        /// </summary>
        public void NiveauSuivant()
        {
            Destructeur();
            if (StoryMod)
            {
                if (Program.FrmDialogue == null)
                {
                    Program.FrmDialogue.Close();
                    Program.FrmDialogue.Dispose();
                }
                Program.FrmDialogue = new FrmDialogue(Level, true);
                Program.ChangeActiveForm(Program.FrmDialogue, this);
            }
            else
            {
                if (Program.FrmNextLevel == null)
                    Program.FrmNextLevel = new FrmNextLevel(Pseudo, Difficulty);
                Program.ChangeActiveForm(Program.FrmNextLevel, this);
            }
        }

    }
}
