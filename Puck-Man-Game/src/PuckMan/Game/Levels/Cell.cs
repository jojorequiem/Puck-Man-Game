using Puck_Man_Game.src.PuckMan.Engine.Entities;
using src.PuckMan.Game.Levels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puck_Man_Game.src.PuckMan.Game.Levels
{
    /// <summary>
    /// Classe représentant une cellule dans le labyrinthe.
    /// </summary>
    public class Cell : Entity
    {
        /// <summary>
        /// Indique si la cellule est un mur.
        /// </summary>
        public bool IsWall { get; set; }

        // Liaison avec les cellules voisines
        public bool topConnection, bottomConnection, rightConnection, leftConnection;

        /// <summary>
        /// Initialise une nouvelle instance de la classe Cell.
        /// </summary>
        /// <param name="x">Position X de la cellule.</param>
        /// <param name="y">Position Y de la cellule.</param>
        /// <param name="name">Nom de la cellule.</param>
        public Cell(int x, int y, string name) : base(x, y, name)
        {
            IsWall = true;
            Image.Location = new Point(x, y); // Positionne l'image de la cellule
            Image.BackColor = Color.Transparent; // Définit le fond de l'image comme transparent
            Image.SizeMode = PictureBoxSizeMode.StretchImage; // Permet d'étirer l'image pour remplir la cellule
            Image.Size = new Size(Maze.cellSize, Maze.cellSize); // Définit la taille de l'image en fonction de la taille de la cellule
        }
    }
}
