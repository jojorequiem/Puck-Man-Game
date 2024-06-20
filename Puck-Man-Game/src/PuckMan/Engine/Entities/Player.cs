using Puck_Man_Game.src.PuckMan.Engine.Entities;
using Puck_Man_Game.src.PuckMan.Game;
using Puck_Man_Game.src.PuckMan.Game.Levels;
using Puck_Man_Game.src.PuckMan.UI.Screens;
using src.PuckMan.Game.Levels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using static System.Net.Mime.MediaTypeNames;

namespace Puck_Man_Game.src.PuckMan.Game.Entities
{
    /// <summary>
    /// Classe représentant un joueur dans le jeu.
    /// </summary>
    public class Player : Entity
    {
        public Maze Maze;
        public bool isDead;

        // Gérer le déplacement continu
        public bool deplacementContinuActive = false;
        public readonly Timer moveTimer;
        private int moveDeltaX;
        private int moveDeltaY;
        private int lastValidDeltaX;
        private int lastValidDeltaY;
        private int tickSpeed = 180;
        public string Pseudo { get; set; }

        // Images du joueur pour les quatre directions
        public System.Drawing.Image ImageUp { get; set; }
        public System.Drawing.Image ImageDown { get; set; }
        public System.Drawing.Image ImageLeft { get; set; }
        public System.Drawing.Image ImageRight { get; set; }
        public System.Drawing.Image ImageIdle { get; set; } // Image du joueur à l'arrêt

        public int maxHP;
        private bool Disposed = false;

        /// <summary>
        /// Initialise une nouvelle instance de la classe Player.
        /// </summary>
        /// <param name="name">Nom du joueur.</param>
        /// <param name="hp">Points de vie du joueur.</param>
        /// <param name="x">Position X initiale du joueur.</param>
        /// <param name="y">Position Y initiale du joueur.</param>
        /// <param name="maze">Labyrinthe dans lequel le joueur se trouve.</param>
        public Player(string name, int hp, int x, int y, Maze maze) : base(x, y, name)
        {
            isDead = false;
            HP = hp;
            maxHP = hp;
            Maze = maze;
            EntitySpeed = Maze.cellSize;
            moveTimer = new Timer
            {
                Interval = tickSpeed
            };
            moveTimer.Tick += MoveTimer_Tick;

            // Initialiser les directions
            moveDeltaX = 0;
            moveDeltaY = 0;
            lastValidDeltaX = 0;
            lastValidDeltaY = 0;
            LoadDefaultImages();
        }

        /// <summary>
        /// Destructeur pour libérer les ressources.
        /// </summary>
        ~Player()
        {
            Dispose();
        }

        /// <summary>
        /// Libère les ressources utilisées par le joueur.
        /// </summary>
        public void Dispose()
        {
            if (!Disposed)
            {
                Disposed = true;
                isDead = true;
                if (Maze != null)
                {
                    Maze.MazeForm.Dispose();
                    Maze.MazeForm.Close();
                    Maze = null;
                }
                moveTimer.Dispose();
                GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Gestion du déplacement du joueur à chaque tick du timer.
        /// </summary>
        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            if (Disposed) return;

            // Gestion des interactions avec les entités
            HandleEnemyInteractions();
            HandleEntityInteractions();

            if (moveDeltaX != 0 || moveDeltaY != 0)
                MovePlayer(moveDeltaX, moveDeltaY);
            else if (lastValidDeltaX != 0 || lastValidDeltaY != 0)
                MovePlayer(lastValidDeltaX, lastValidDeltaY);
        }

        /// <summary>
        /// Charge les images par défaut pour les différentes directions du joueur.
        /// </summary>
        private void LoadDefaultImages()
        {
            ImageUp = Puck_Man_Game.Properties.Resources.topGif128;
            ImageDown = Puck_Man_Game.Properties.Resources.bottomGif128;
            ImageLeft = Puck_Man_Game.Properties.Resources.leftGif128;
            ImageRight = Puck_Man_Game.Properties.Resources.rightGif128;
            ImageIdle = Puck_Man_Game.Properties.Resources.bottomGif128;
            Image.Image = Puck_Man_Game.Properties.Resources.standardGif128; // Initialisation avec l'image droite
        }

        /// <summary>
        /// Met à jour l'image du joueur en fonction de la direction du déplacement.
        /// </summary>
        /// <param name="deltaX">Direction sur l'axe X.</param>
        /// <param name="deltaY">Direction sur l'axe Y.</param>
        private void UpdateSkin(int deltaX, int deltaY)
        {
            if (deltaX == -1)
                Image.Image = ImageLeft;
            else if (deltaX == 1)
                Image.Image = ImageRight;
            else if (deltaY == -1)
                Image.Image = ImageUp;
            else if (deltaY == 1)
                Image.Image = ImageDown;
        }

        /// <summary>
        /// Déplace le joueur de la quantité spécifiée en X et Y.
        /// </summary>
        /// <param name="deltaX">Quantité de déplacement en X.</param>
        /// <param name="deltaY">Quantité de déplacement en Y.</param>
        /// <returns>True si le déplacement est effectué, sinon False.</returns>
        public bool MovePlayer(int deltaX, int deltaY)
        {
            // Vérifie les collisions avec les murs
            if (CheckWallCollision(deltaX, deltaY))
            {
                moveDeltaX = 0;
                moveDeltaY = 0;
                Image.Image = ImageIdle;
                return false; // Le joueur entre en collision avec un mur, on ne le déplace pas
            }

            // Déplacement uniquement si aucune collision
            Maze.Entities[X, Y] = null;
            X += deltaX * EntitySpeed;
            Y += deltaY * EntitySpeed;
            Maze.Entities[X, Y] = this;
            lastValidDeltaX = deltaX;
            lastValidDeltaY = deltaY;

            // Met à jour l'affichage
            Image.Location = new Point(X, Y);
            UpdateSkin(deltaX, deltaY);
            return true;
        }

        /// <summary>
        /// Vérifie s'il y a une collision avec un mur à la position spécifiée.
        /// </summary>
        /// <param name="deltaX">Quantité de déplacement en X.</param>
        /// <param name="deltaY">Quantité de déplacement en Y.</param>
        /// <returns>True si collision avec un mur, sinon False.</returns>
        private bool CheckWallCollision(int deltaX, int deltaY)
        {
            Rectangle newBounds = new Rectangle(X + deltaX, Y + deltaY, Image.Width, Image.Height);
            List<Cell> neighbors = Maze.GetNeighborCells(X, Y);
            foreach (Cell myCell in neighbors)
            {
                if (myCell.IsWall && newBounds.IntersectsWith(new Rectangle(myCell.X, myCell.Y, myCell.Image.Width, myCell.Image.Height)))
                    return true; // Le joueur entre en collision avec un mur
            }

            return false; // Pas de collision avec un mur
        }

        /// <summary>
        /// Gère les interactions avec les ennemis.
        /// </summary>
        private void HandleEnemyInteractions()
        {
            if (Disposed) return;
            foreach (Enemy adversaire in Maze.EnemyList)
            {
                Rectangle newBounds = new Rectangle(X, Y, Image.Width, Image.Height);
                if (newBounds.IntersectsWith(new Rectangle(adversaire.X, adversaire.Y, adversaire.Image.Width, adversaire.Image.Height)))
                    DamageReceived(adversaire.Damage);
            }
        }

        /// <summary>
        /// Gère les interactions avec les entités statiques.
        /// </summary>
        private void HandleEntityInteractions()
        {
            if (Disposed) return;
            if (X >= 0 && X < Maze.StaticEntities.GetLength(0) && Y >= 0 && Y < Maze.StaticEntities.GetLength(1))
                Maze.StaticEntities[X, Y]?.Collecte(Maze.MazeForm);
        }

        /// <summary>
        /// Gère la réception de dégâts par le joueur.
        /// </summary>
        /// <param name="hitDamage">Quantité de dégâts reçus.</param>
        public void DamageReceived(int hitDamage)
        {
            if (Disposed) return;
            HP -= hitDamage;
            Maze.MazeForm.UpdateHPdisplay();
            if (HP <= 0)
                HandlePlayerDeath();
            Program.PlaySound("assets/audio/TakeDamage.wav");
        }

        /// <summary>
        /// Soigne le joueur.
        /// </summary>
        /// <param name="healValue">Quantité de points de vie à ajouter.</param>
        public void Heal(int healValue)
        {
            if (Disposed) return;
            if (HP + healValue > maxHP)
                HP = maxHP;
            else
                HP += healValue;
            Maze.MazeForm.UpdateHPdisplay();
            Program.PlaySound("assets/audio/Heal.wav");
        }

        /// <summary>
        /// Gère la mort du joueur.
        /// </summary>
        public void HandlePlayerDeath()
        {
            if (!Disposed)
            {
                Disposed = true;
                if (Maze.MazeForm.StoryMod)
                {
                    Program.FrmDeath = new FrmDeath(Maze.MazeForm.Pseudo, Maze.MazeForm.Level, Maze.MazeForm.Difficulty);
                }
                else
                {
                    Program.FrmDeath = new FrmDeath(Maze.MazeForm.Pseudo, 0, Maze.MazeForm.Difficulty);
                }
                Program.ChangeActiveForm(Program.FrmDeath, Maze.MazeForm);
                Dispose();
            }
        }

        /// <summary>
        /// Gère les événements de pression des touches pour le déplacement du joueur.
        /// </summary>
        /// <param name="sender">Objet source de l'événement.</param>
        /// <param name="e">Arguments de l'événement de pression des touches.</param>
        public void PlayerKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    moveDeltaX = -1;
                    moveDeltaY = 0;
                    break;
                case Keys.Right:
                    moveDeltaX = 1;
                    moveDeltaY = 0;
                    break;
                case Keys.Up:
                    moveDeltaX = 0;
                    moveDeltaY = -1;
                    break;
                case Keys.Down:
                    moveDeltaX = 0;
                    moveDeltaY = 1;
                    break;
                default:
                    return;
            }
            if (!moveTimer.Enabled)
            {
                deplacementContinuActive = true;
                moveTimer.Start(); // Démarre le déplacement continu
            }
        }

        /// <summary>
        /// Gère les événements de relâchement des touches pour mettre en pause le jeu.
        /// </summary>
        /// <param name="sender">Objet source de l'événement.</param>
        /// <param name="e">Arguments de l'événement de relâchement des touches.</param>
        public void PlayerKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                // mettre en pause le joueur et les ennemis
                if (moveTimer.Enabled)
                    moveTimer.Stop();
                foreach (Enemy enemy in Maze.EnemyList)
                    enemy.moveEnemyTimer.Stop();

                if (Program.FrmPause == null)
                    Program.FrmPause = new FrmPause(Maze.MazeForm);
                Program.FrmPause.FormParent = Maze.MazeForm;
                Program.ChangeActiveForm(Program.FrmPause, Maze.MazeForm);
            }
        }
    }
}
