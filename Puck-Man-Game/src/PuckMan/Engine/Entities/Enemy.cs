using Puck_Man_Game.src.PuckMan.Game.Levels;
using Puck_Man_Game.src.PuckMan.UI.Screens;
using src.PuckMan.Game.Levels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Puck_Man_Game.src.PuckMan.Engine.Entities
{
    public class Enemy : Entity
    {
        public string EnemyClass { get; set; }
        public int Damage { get; set; }
        public Maze Maze { get; set; }

        private readonly Timer moveEnemyTimer;
        private Point previousDirection;

        public Enemy(string name, int hp, int x, int y, Maze maze) : base(x, y, name)
        {
            HP = hp;
            Maze = maze;
            EntitySpeed = Maze.cellSize;
            Image.Image = Puck_Man_Game.Properties.Resources.joueur;

            moveEnemyTimer = new Timer
            {
                Interval = 180
            };
            moveEnemyTimer.Tick += MoveEnemyTimer_Tick;

            previousDirection = new Point(0, 0);

            moveEnemyTimer.Start();

            switch (name)
            {
                case "égaré":
                    Damage = 1;
                    Image.Image = Puck_Man_Game.Properties.Resources.égaré;
                    break;
                default:
                    break;
            }
        }

        private void MoveEnemyTimer_Tick(object sender, EventArgs e)
        {
            List<Point> possibleMoves = new List<Point>();

            foreach (Point direction in GetPossibleDirections())
            {
                int deltaX = direction.X * Maze.cellSize;
                int deltaY = direction.Y * Maze.cellSize;

                if (!CheckWallCollision(deltaX, deltaY))
                {
                    possibleMoves.Add(direction);
                }
            }

            if (possibleMoves.Count > 0)
            {
                // Exclure la direction opposée à la précédente pour éviter les allers-retours
                Point oppositePreviousDirection = new Point(-previousDirection.X, -previousDirection.Y);
                possibleMoves.Remove(oppositePreviousDirection);

                // Si après avoir exclu la direction opposée, il n'y a plus de mouvements possibles
                if (possibleMoves.Count == 0)
                {
                    possibleMoves.Add(oppositePreviousDirection); // Réajouter la direction opposée
                }

                Random random = new Random();
                Point selectedMove = possibleMoves[random.Next(possibleMoves.Count)];

                MoveEnemy(selectedMove.X * Maze.cellSize, selectedMove.Y * Maze.cellSize );
                previousDirection = selectedMove;
            }
        }

        private List<Point> GetPossibleDirections()
        {
            return new List<Point>
            {
                new Point(0, -1), // Haut
                new Point(0, 1),  // Bas
                new Point(-1, 0), // Gauche
                new Point(1, 0)   // Droite
            };
        }

        private void MoveEnemy(int deltaX, int deltaY)
        {
            if (!CheckWallCollision(deltaX, deltaY))
            {
                X += deltaX;
                Y += deltaY;
                Image.Location = new Point(X, Y);
            }
        }

        private bool CheckWallCollision(int deltaX, int deltaY)
        {
            Rectangle newBounds = new Rectangle(X + deltaX, Y + deltaY, Image.Width, Image.Height);
            List<Cell> neighbors = GetNeighborCells();
            foreach (Cell cell in neighbors)
            {
                if (cell.IsWall && newBounds.IntersectsWith(new Rectangle(cell.X, cell.Y, cell.Image.Width, cell.Image.Height)))
                {
                    return true;
                }
            }
            return false;
        }

        private List<Cell> GetNeighborCells()
        {
            List<Cell> neighbors = new List<Cell>();
            Cell top = Maze.Top(X, Y, Maze.cellSize);
            Cell bottom = Maze.Bottom(X, Y, Maze.cellSize);
            Cell left = Maze.Left(X, Y, Maze.cellSize);
            Cell right = Maze.Right(X, Y, Maze.cellSize);
            if (top != null) neighbors.Add(top);
            if (bottom != null) neighbors.Add(bottom);
            if (left != null) neighbors.Add(left);
            if (right != null) neighbors.Add(right);
            return neighbors;
        }
    }
}
