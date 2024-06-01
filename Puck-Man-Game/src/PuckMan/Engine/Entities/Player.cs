﻿using Puck_Man_Game.src.PuckMan.Engine.Entities;
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
using static System.Net.Mime.MediaTypeNames;


namespace Puck_Man_Game.src.PuckMan.Game.Entities
{
    public class Player : Entity
    {
        // Propriétés du Player
        public int Level { get; set; }
        public Maze Maze;
        public bool isDead;

        // Timer pour gérer le déplacemet continu
        private readonly Timer moveTimer;
        private int moveDeltaX;
        private int moveDeltaY;
        private int lastValidDeltaX;
        private int lastValidDeltaY;
        private int tickSpeed = 180;

        // Images du joueur pour les quatre direction
        public System.Drawing.Image ImageUp { get; set; }
        public System.Drawing.Image ImageDown { get; set; }
        public System.Drawing.Image ImageLeft { get; set; }
        public System.Drawing.Image ImageRight { get; set; }
        public System.Drawing.Image ImageIdle { get; set; } // Image du joueur à l'arrêt

        public int maxHP;
        // Constructeur
        public Player(string name, int hp, int level, int x, int y, Maze maze) : base(x, y, name)
        {
            isDead = false;
            HP = hp;
            maxHP = hp;
            Level = level;
            Maze = maze;
            EntitySpeed = Maze.cellSize;
            Image.Image = Puck_Man_Game.Properties.Resources.joueur;
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

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            // Gestion des interactions avec les entités
            HandleEnemyInteractions();
            HandleEntityInteractions();
            if (moveDeltaX != 0 || moveDeltaY != 0)
            {
                MovePlayer(moveDeltaX, moveDeltaY);
            }
            else if (lastValidDeltaX != 0 || lastValidDeltaY != 0)
            {
                MovePlayer(lastValidDeltaX, lastValidDeltaY);
            }
        }

        private void LoadDefaultImages()
        {
            ImageUp = Puck_Man_Game.Properties.Resources.topGif128;
            ImageDown = Puck_Man_Game.Properties.Resources.bottomGif128;
            ImageLeft = Puck_Man_Game.Properties.Resources.leftGif128;
            ImageRight = Puck_Man_Game.Properties.Resources.rightGif128;
            ImageIdle = Puck_Man_Game.Properties.Resources.bottomGif128;
            Image.Image = ImageIdle; // Initialisation avec l'image droite
        }
        private void UpdateSkin(int deltaX, int deltaY)
        {
            if (deltaX == -1)
            {
                Image.Image = ImageLeft;
            }
            else if (deltaX == 1)
            {
                Image.Image = ImageRight;
            }
            else if (deltaY == -1)
            {
                Image.Image = ImageUp;
            }
            else if (deltaY == 1)
            {
                Image.Image = ImageDown;
            }
        }
        public bool MovePlayer(int deltaX, int deltaY)
        {
            // Vérifie les collisions avec les murs
            if (CheckWallCollision(deltaX, deltaY))
            {
                Maze.Entities[X, Y] = null;
                moveDeltaX = 0;
                moveDeltaY = 0;
                Image.Image = ImageIdle;
                Maze.Entities[X, Y] = this;
                return false; // Le joueur entre en collision avec un mur, on ne le déplace pas
            }
                
            // Déplacement uniquement si aucune collision
            X += deltaX * EntitySpeed;
            Y += deltaY * EntitySpeed ;

            lastValidDeltaX = deltaX;
            lastValidDeltaY = deltaY;

            // Met à jour l'affichage
            Image.Location = new Point(X, Y);
            UpdateSkin(deltaX, deltaY);
            return true;
        }
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
        private void HandleEnemyInteractions()
        {
            foreach (Enemy adversaire in Maze.EnemyList)
            {
                Rectangle newBounds = new Rectangle(X, Y, Image.Width, Image.Height);
                if (newBounds.IntersectsWith(new Rectangle(adversaire.X, adversaire.Y, adversaire.Image.Width, adversaire.Image.Height)))
                    DamageReceived(adversaire.Damage);
            }
        }

        private void HandleEntityInteractions()
        {
            if (Maze.Entities[X, Y] != null)
            {
                if (Maze.Entities[X, Y] is Collectable collectable)
                {
                    collectable.Collecte(Maze.MazeForm);
                }
            }
        }

        public void DamageReceived(int hitDamage)
        {
            HP -= hitDamage;
            Maze.MazeForm.UpdateHPdisplay();
            if (HP <= 0)
                HandlePlayerDeath();
        }

        public void Heal(int healValue)
        {
            if (HP + healValue > maxHP)
                HP = maxHP;
            else
                HP += healValue;
            Debug.WriteLine(HP);
            Maze.MazeForm.UpdateHPdisplay();
        }

        public void HandlePlayerDeath()
        {
            if (!isDead)
            {
                isDead = true;
                Program.LoadScene(typeof(NouvellePartie), Maze.MazeForm);
            }
        }

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
                moveTimer.Start(); // Démarre le déplacement continu
            }
        }

        public void PlayerKeyUp(object sender, KeyEventArgs e)
        {
            // Ne rien faire ici car le joueur continue à se déplacer jusqu'à une collision
        }
    }
}
