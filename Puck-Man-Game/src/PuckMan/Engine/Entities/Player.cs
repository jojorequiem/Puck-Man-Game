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
    public class Player : Entity
    {
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
        private bool Disposed = false;
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
        ~Player()  //destructeur
        {
            Debug.WriteLine("DESTRUCTEUR JOUEUR");
            Dispose();
        }
        public void Dispose()
        {
            
            if (!Disposed)
            {
                Debug.WriteLine("DISPOSE JOUEUR");
                Disposed = true;
                isDead = true;
                Maze = null;
                moveTimer.Dispose();
                GC.SuppressFinalize(this);    
            }
            else
                Debug.WriteLine("JOUEUR DEJA DISPOSED");
        }

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
        private void LoadDefaultImages()
        {
            ImageUp = Puck_Man_Game.Properties.Resources.topGif128;
            ImageDown = Puck_Man_Game.Properties.Resources.bottomGif128;
            ImageLeft = Puck_Man_Game.Properties.Resources.leftGif128;
            ImageRight = Puck_Man_Game.Properties.Resources.rightGif128;
            ImageIdle = Puck_Man_Game.Properties.Resources.bottomGif128;
            Image.Image = Puck_Man_Game.Properties.Resources.standardGif128; // Initialisation avec l'image droite
        }
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

            Maze.Entities[X, Y] = null;
            // Déplacement uniquement si aucune collision
            X += deltaX * EntitySpeed;
            Y += deltaY * EntitySpeed ;
            Maze.Entities[X, Y] = this;
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
            if (Disposed) return;
            foreach (Enemy adversaire in Maze.EnemyList)
            {
                Rectangle newBounds = new Rectangle(X, Y, Image.Width, Image.Height);
                if (newBounds.IntersectsWith(new Rectangle(adversaire.X, adversaire.Y, adversaire.Image.Width, adversaire.Image.Height)))
                    DamageReceived(adversaire.Damage);
            }
        }

        private void HandleEntityInteractions()
        {
            if (Disposed) return;
            if (X >= 0 && X < Maze.StaticEntities.GetLength(0) && Y >= 0 && Y < Maze.StaticEntities.GetLength(1))
                Maze.StaticEntities[X, Y]?.Collecte(Maze.MazeForm);
        }

        public void DamageReceived(int hitDamage)
        {
            if (Disposed)
                Console.WriteLine("FILS DE PUTE");
            if (Disposed) return;
            HP -= hitDamage;
            Maze.MazeForm.UpdateHPdisplay();
            if (HP <= 0)
                HandlePlayerDeath();
            Program.PlaySound("assets/audio/takeDamage.wav");
        }

        public void Heal(int healValue)
        {
            if (Disposed) return;
            if (HP + healValue > maxHP)
                HP = maxHP;
            else
                HP += healValue;
            Maze.MazeForm.UpdateHPdisplay();
        }

        public void HandlePlayerDeath()
        {
            if (Disposed)
                Console.WriteLine("ERREUR LE JOUEUR EST DEJA MORT"); //(pour le debugage) ce message ne doit jamais apparaitre
            if (!Disposed)
            {
                Dispose();
                Disposed = true;
                Program.FrmNouvellePartie = new FrmNouvellePartie(Maze.MazeForm.ModeHistoire, Maze.MazeForm.NiveauActuel);
                Program.ChangeActiveForm(Program.FrmNouvellePartie, Maze.MazeForm);
                Maze.MazeForm.Dispose();
                Maze.MazeForm.Close();
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
                moveTimer.Start(); // Démarre le déplacement continu
        }

        public void PlayerKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (Program.FrmPause == null)
                    Program.FrmPause = new FrmPause(Maze.MazeForm);
                Program.ChangeActiveForm(Program.FrmPause, Maze.MazeForm);
            }
        }
    }
}
