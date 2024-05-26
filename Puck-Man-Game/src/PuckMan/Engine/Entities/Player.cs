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

namespace Puck_Man_Game.src.PuckMan.Game.Entities
{
    public class Player : Entity
    {
        // Propriétés du Player
        public int Level { get; set; }
        public Maze MazeMatrix;
        // Constructeur
        public Player(string name, int hp, int level, int x, int y, Maze mazeMatrix) : base(x, y, name)
        {
            HP = hp;
            Level = level;
            MazeMatrix = mazeMatrix;
            EntitySpeed = Maze.cellSize;
            Image.Image = Puck_Man_Game.Properties.Resources.joueur;
        }

        public void MovePlayer(int deltaX, int deltaY)
        {
            // Vérifie les collisions avec les murs
            if (CheckWallCollision(deltaX, deltaY))
                return; // Le joueur entre en collision avec un mur, on ne le déplace pas


            // Déplacement uniquement si aucune collision
            X += deltaX * EntitySpeed;
            Y += deltaY * EntitySpeed;

            // Gestion des interactions avec les entités
            HandleEntityInteractions();

            // Met à jour l'emplacement de l'image
            Image.Location = new Point(X, Y);
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
                    return true; // Le joueur entre en collision avec un mur
            }

            return false; // Pas de collision avec un mur
        }

        private void HandleEntityInteractions()
        {
            if (MazeMatrix.Entities[X, Y] != null)
            {
                if (MazeMatrix.Entities[X, Y] is Collectable collectable && collectable.EntityName == "fragment")
                {
                    collectable.Collecte(MazeMatrix.MazeForm);
                }

                if (MazeMatrix.Entities[X, Y] is Enemy adversaire && adversaire.EntityName == "égaré")
                    DamageReceived(adversaire.Damage);
            }
        }

        public void DamageReceived(int hitDamage)
        {
            HP -= hitDamage;
            Debug.WriteLine(HP);
            MazeMatrix.MazeForm.UpdateHPdisplay();
            if (HP <= 0)
                HandlePlayerDeath();
            
        }

        public void HandlePlayerDeath()
        {
            Program.LoadScene(typeof(NouvellePartie), MazeMatrix.MazeForm);
        }

        public void PlayerKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    MovePlayer(-1, 0); // leftConnection
                    break;
                case Keys.Right:
                    MovePlayer(1, 0); // rightConnection
                    break;
                case Keys.Up:
                    MovePlayer(0, -1); // topConnection
                    break;
                case Keys.Down:
                    MovePlayer(0, 1); // bottomConnection
                    break;
                default:
                    MovePlayer(0, 0);
                    break;
            }
        }
    }
}
