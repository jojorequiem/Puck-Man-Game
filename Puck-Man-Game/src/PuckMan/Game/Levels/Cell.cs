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
    public class Cell : Entity
    {
        public bool IsWall { get; set; }
        
        //liaison avec le voisins
        public bool topConnection, bottomConnection, rightConnection, leftConnection;
        public Cell(int x, int y, string name) : base(x, y, name)
        {
            IsWall = true;
            Image.Location = new Point(x, y);
            Image.BackColor = Color.Transparent;
            Image.SizeMode = PictureBoxSizeMode.StretchImage;
            Image.Size = new Size(Maze.cellSize, Maze.cellSize);
        }
    }
}
