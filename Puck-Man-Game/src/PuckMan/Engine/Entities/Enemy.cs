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

        public Maze MazeMatrix;

        private readonly Timer moveEnemyTimer;
        private int moveDeltaX;
        private int moveDeltaY;
        public Enemy(string name, int hp, int x, int y, Maze mazeMatrix) : base(x, y, name)
        {
            HP = hp;
            MazeMatrix = mazeMatrix;
            EntitySpeed = Maze.cellSize;
            Image.Image = Puck_Man_Game.Properties.Resources.joueur;
            moveEnemyTimer = new Timer
            {
                Interval = 200
            };
            moveEnemyTimer.Tick += MoveEnemyTimer_Tick;

            moveDeltaX = 0;
            moveDeltaY = 0;

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
                Random random = new Random();
                Point randomMove = possibleMoves[random.Next(possibleMoves.Count)];

                MoveEnemy(randomMove.X * Maze.cellSize, randomMove.Y * Maze.cellSize);
            }
        }

        private List<Point> GetPossibleDirections()
        {
            List<Point> directions = new List<Point>();

            directions.Add(new Point(0, -1)); // Haut
            directions.Add(new Point(0, 1));  // Bas
            directions.Add(new Point(-1, 0)); // Gauche
            directions.Add(new Point(1, 0));  // Droite

            return directions;
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
            List<Cell> neighbors = new List<Cell>();
            Cell topConnection = MazeMatrix.Top(X, Y, Maze.cellSize);
            Cell bottomConnection = MazeMatrix.Bottom(X, Y, Maze.cellSize);
            Cell leftConnection = MazeMatrix.Left(X, Y, Maze.cellSize);
            Cell rightConnection = MazeMatrix.Right(X, Y, Maze.cellSize);

            if (topConnection != null)
                neighbors.Add(topConnection);
            if (bottomConnection != null)
                neighbors.Add(bottomConnection);
            if (leftConnection != null)
                neighbors.Add(leftConnection);
            if (rightConnection != null)
                neighbors.Add(rightConnection);

            foreach (Cell myCell in neighbors)
            {
                if (myCell.IsWall && newBounds.IntersectsWith(new Rectangle(myCell.X, myCell.Y, myCell.Image.Width, myCell.Image.Height)))
                    return true;
            }

            return false;
        }
    }
}