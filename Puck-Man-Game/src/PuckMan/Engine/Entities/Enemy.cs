using Puck_Man_Game.src.PuckMan.Game.Entities;
using Puck_Man_Game.src.PuckMan.Game.Levels;
using src.PuckMan.Game.Levels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Puck_Man_Game.src.PuckMan.Engine.Entities
{
    public abstract class Enemy : Entity
    {
        public string EnemyClass { get; set; }
        public int Damage { get; set; }
        public Maze Maze { get; set; }

        public Timer moveEnemyTimer;
        public Point previousDirection;
        private readonly Dictionary<Enemy, DateTime> lastAttackTime = new Dictionary<Enemy, DateTime>();
        private readonly TimeSpan attackCooldown = TimeSpan.FromSeconds(10);
        private bool isFacingRight = true;
        public Enemy(string name, int x, int y, Maze maze) : base(x, y, name)
        {
            lastAttackTime[this] = DateTime.MinValue;
            HP = 3;
            Maze = maze;
            EntitySpeed = Maze.cellSize;
            Image.BringToFront();

            moveEnemyTimer = new Timer
            {
                Interval = 1000
            };
            moveEnemyTimer.Tick += MoveEnemyTimer_Tick;
            previousDirection = new Point(0, 0);
            moveEnemyTimer.Start();
        }

        public void Move()
        {
            List<Point> possibleMoves = new List<Point>();
            foreach (Point direction in GetPossibleDirections())
            {
                if (!CheckWallCollision(direction.X * Maze.cellSize, direction.Y * Maze.cellSize))
                    possibleMoves.Add(direction);
            }

            bool dontMove = false;
            if (possibleMoves.Count > 0)
            {
                // Exclure la direction opposée à la précédente pour éviter les allers-retours
                Point oppositePreviousDirection = new Point(-previousDirection.X, -previousDirection.Y);
                possibleMoves.Remove(oppositePreviousDirection);

                // Si après avoir exclu la direction opposée, il n'y a plus de mouvements possibles
                if (possibleMoves.Count == 0)
                    possibleMoves.Add(oppositePreviousDirection); // Réajouter la direction opposée

                Random random = new Random();
                Point selectedMove = possibleMoves[random.Next(possibleMoves.Count)];
                // Chercher une case qui n'est pas déjà occupée
                while (possibleMoves.Count > 0 && (Maze.Entities[X + selectedMove.X * Maze.cellSize, Y + selectedMove.Y * Maze.cellSize] != null))
                {
                    var targetEntity = Maze.Entities[X + selectedMove.X * Maze.cellSize, Y + selectedMove.Y * Maze.cellSize];
                    if (targetEntity is Player player &&
                        (!lastAttackTime.ContainsKey(this) || DateTime.Now - lastAttackTime[this] > attackCooldown))
                    {
                        player.DamageReceived(Damage);
                        dontMove = true;
                        lastAttackTime[this] = DateTime.Now;
                    }
                    possibleMoves.Remove(selectedMove);
                    if (possibleMoves.Count > 0)
                        selectedMove = possibleMoves[random.Next(possibleMoves.Count)];
                }

                // Si après avoir exclu la direction opposée, il n'y a plus de mouvements possibles
                if (possibleMoves.Count == 0)
                    selectedMove = oppositePreviousDirection; // Réajouter la direction opposée

                if (!dontMove && Maze.Entities[X + selectedMove.X * Maze.cellSize, Y + selectedMove.Y * Maze.cellSize] == null)
                {
                    MoveEnemy(selectedMove.X * Maze.cellSize, selectedMove.Y * Maze.cellSize);
                    previousDirection = selectedMove;
                }
            }
        }





        public void MoveEnemyTimer_Tick(object sender, EventArgs e)
        {
            Move();
        }
        protected List<Point> GetPossibleDirections()
        {
            return new List<Point>
            {
                new Point(0, -1), // Haut
                new Point(0, 1),  // Bas
                new Point(-1, 0), // Gauche
                new Point(1, 0)   // Droite
            };
        }

        protected void MoveEnemy(int deltaX, int deltaY)
        {
            if (!CheckWallCollision(deltaX, deltaY))
            {
                Maze.Entities[X, Y] = null;
                X += deltaX;
                Y += deltaY;
                Image.Location = new Point(X, Y);

                if (deltaX > 0 && !isFacingRight)
                {
                    Image.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    isFacingRight = true;
                }
                else if (deltaX < 0 && isFacingRight)
                {
                    Image.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    isFacingRight = false;
                }

                Maze.Entities[X, Y] = this;
            }
        }

        public bool CheckWallCollision(int deltaX, int deltaY)
        {
            Rectangle newBounds = new Rectangle(X + deltaX, Y + deltaY, Image.Width, Image.Height);
            List<Cell> neighbors = Maze.GetNeighborCells(X, Y);
            foreach (Cell cell in neighbors)
            {
                if (cell.IsWall && newBounds.IntersectsWith(new Rectangle(cell.X, cell.Y, cell.Image.Width, cell.Image.Height)))
                    return true;
            }
            return false;
        }
    }

    public class BerserkerEnemy : Enemy
    {
        private new Point previousDirection;
        private readonly Dictionary<Enemy, DateTime> lastAttackTime;
        private readonly TimeSpan attackCooldown;

        public BerserkerEnemy(int x, int y, Maze maze) : base("Égaré Confus", x, y, maze)
        {
            Damage = 3;
            Image.Image = Puck_Man_Game.Properties.Resources.spectrl;
            moveEnemyTimer = new Timer { Interval = 450 
            };
            moveEnemyTimer.Tick += MoveEnemyTimer_Tick;
            moveEnemyTimer.Start();
            previousDirection = new Point(0, 0);
            lastAttackTime = new Dictionary<Enemy, DateTime>();
            attackCooldown = TimeSpan.FromSeconds(2);
        }
    }

    public class ConfusedEnemy : Enemy
    {
        private new Point previousDirection;
        private readonly Dictionary<Enemy, DateTime> lastAttackTime;
        private readonly TimeSpan attackCooldown;
        public ConfusedEnemy(int x, int y, Maze maze) : base("Égaré Confus", x, y, maze)
        {
            Damage = 1;
            Image.Image = Puck_Man_Game.Properties.Resources.egare;
            moveEnemyTimer = new Timer { Interval = 300 };
            moveEnemyTimer.Tick += MoveEnemyTimer_Tick;
            moveEnemyTimer.Start();
            previousDirection = new Point(0, 0);
            lastAttackTime = new Dictionary<Enemy, DateTime>();
            attackCooldown = TimeSpan.FromSeconds(2);
        }
    }

}