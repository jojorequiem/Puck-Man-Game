using Puck_Man_Game.src.PuckMan.Game.Levels;
using Puck_Man_Game.src.PuckMan.UI.Screens;
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
        public string Nom { get; set; }
        public string Id { get; set; }
        public int PV { get; set; }
        public PictureBox Image { get; set; }

        public int Vitesse;
        public Entity(int x, int y, string nom)
        {
            X = x;
            Y = y;
            Nom = nom;
            Image = new PictureBox
            {
                Location = new Point(X, Y),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(Labyrinthe.TailleCase, Labyrinthe.TailleCase),
            };
        }
    }
}
