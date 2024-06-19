using Puck_Man_Game.src.PuckMan.Game.Levels;
using Puck_Man_Game.src.PuckMan.UI.Screens;
using src.PuckMan.Game.Levels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puck_Man_Game.src.PuckMan.Engine.Entities
{
    /// <summary>
    /// Représente une entité dans le jeu, avec des propriétés de position,
    /// de nom, d'identifiant, de points de vie et d'image.
    /// </summary>
    public class Entity
    {
        // Propriétés publiques pour la position X et Y de l'entité
        public int X { get; set; }
        public int Y { get; set; }

        // Propriétés publiques pour le nom et l'identifiant de l'entité
        public string EntityName { get; set; }
        public string Id { get; set; }

        // Propriété publique pour les points de vie de l'entité
        public int HP { get; set; }

        // Propriété publique pour l'image de l'entité
        public PictureBox Image { get; set; }

        // Vitesse de l'entité
        public int EntitySpeed;

        /// <summary>
        /// Initialise une nouvelle instance de la classe Entity avec les coordonnées spécifiées et le nom.
        /// </summary>
        /// <param name="x">Position X initiale de l'entité.</param>
        /// <param name="y">Position Y initiale de l'entité.</param>
        /// <param name="name">Nom de l'entité.</param>
        public Entity(int x, int y, string name)
        {
            X = x;
            Y = y;
            EntityName = name;

            // Initialisation de l'image de l'entité
            Image = new PictureBox
            {
                Location = new Point(X, Y), // Position initiale de l'image
                SizeMode = PictureBoxSizeMode.StretchImage, // Mode d'affichage de l'image
                Size = new Size(Maze.cellSize, Maze.cellSize), // Taille de l'image
                BackColor = Color.Transparent // Fond transparent pour l'image
            };
        }
    }
}
