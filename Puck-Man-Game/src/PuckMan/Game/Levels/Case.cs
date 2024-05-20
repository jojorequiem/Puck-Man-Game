using Puck_Man_Game.src.PuckMan.Engine.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puck_Man_Game.src.PuckMan.Game.Levels
{
    public class Case : Entity
    {
        public bool Solide { get; set; }

        //liaison avec le voisins
        public bool haut, bas, droite, gauche;

        public Case(int x, int y, string nom) : base(x, y, nom)
        {
            Solide = true;
            Image.Location = new Point(x, y);
            Image.BackColor = Color.Transparent;
            Image.SizeMode = PictureBoxSizeMode.StretchImage;
            Image.Size = new Size(Labyrinthe.TailleCase, Labyrinthe.TailleCase);
        }

        public void ActualiserImage()
        {
            if (Solide)
                Image.Image = Puck_Man_Game.Properties.Resources.mur;
            else
                Image.Image = Puck_Man_Game.Properties.Resources.vide;
        }
    }
}
