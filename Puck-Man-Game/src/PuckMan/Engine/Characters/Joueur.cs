using Puck_Man_Game.src.PuckMan.UI.Screens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puck_Man_Game.src.PuckMan.Game.Characters
{
    public class Joueur
    {
        // Propriétés du joueur
        public string Nom { get; set; }
        public int PointsDeVie { get; set; }
        public int Niveau { get; set; }
        public PictureBox Skin { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Speed;

        // Constructeur
        public Joueur(string nom, int pointsDeVie, int niveau,int x, int y)
        {
            Nom = nom;
            PointsDeVie = pointsDeVie;
            Niveau = niveau;
            X = x;
            Y = y;
            Speed = 16;
            Skin = new PictureBox();
            Skin.Image = Puck_Man_Game.Properties.Resources.joueur;
            Skin.BackColor = Color.Transparent;

            Skin.SizeMode = PictureBoxSizeMode.StretchImage;
            Skin.Size = new Size(Labyrinthe.TailleCase, Labyrinthe.TailleCase);
            Skin.Location = new Point(X, Y);
        }
        public void Deplacer(int deltaX, int deltaY)
        {
            Debug.WriteLine("Deplacement");
            X += deltaX*Speed;
            Y += deltaY*Speed;
            Skin.Location = new Point(X, Y);
        }

        // Méthode pour attaquer un adversaire
        public void getInfo()
        {
            Console.WriteLine($"{Nom} {PointsDeVie} {Niveau} {X} {Y}");

        }

    }
}
