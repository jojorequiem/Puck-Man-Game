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
    public class Entity
    {
        // Propriétés
        public int X { get; set; }
        public int Y { get; set; }
        public string EntityName { get; set; }
        public string Id { get; set; }
        public int HP { get; set; }
        public PictureBox Image { get; set; }

        public int EntitySpeed;
        public Entity(int x, int y, string name)
        {
            X = x;
            Y = y;
            EntityName = name;
            Image = new PictureBox
            {
                Location = new Point(X, Y),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(Maze.cellSize, Maze.cellSize),
                BackColor = Color.Transparent
            };
        }
    }
}
