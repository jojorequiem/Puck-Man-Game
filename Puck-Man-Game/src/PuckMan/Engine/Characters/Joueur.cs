using Puck_Man_Game.src.PuckMan.UI.Screens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
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
        public Labyrinthe Laby;
        // Constructeur
        public Joueur(string nom, int pointsDeVie, int niveau,int x, int y)
        {
            Nom = nom;
            PointsDeVie = pointsDeVie;
            Niveau = niveau;
            X = x;
            Y = y;
            Speed = Labyrinthe.TailleCase;
            
            Skin = new PictureBox
            {
                Location = new Point(X, Y),
                //BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(Labyrinthe.TailleCase, Labyrinthe.TailleCase),
                Visible = true,
                Image = Puck_Man_Game.Properties.Resources.joueur
            };
            //SetAlphaImage();
        }

        private void SetAlphaImage()
        {
            var resourceImage = Puck_Man_Game.Properties.Resources.joueur; // Chargez votre ressource d'image
            var bmp = new Bitmap(resourceImage);
            Skin.Image = bmp;
        }

        public void Deplacer(int deltaX, int deltaY)
        {
            // Vérifie les collisions avec les murs voisins
            Rectangle newBounds = new Rectangle(X+deltaX, Y+deltaY, Skin.Width, Skin.Height);
            List<Case> voisins = new List<Case>();
            Case haut = Laby.Haut(X, Y, Labyrinthe.TailleCase);
            Case bas = Laby.Bas(X, Y, Labyrinthe.TailleCase);
            Case gauche = Laby.Gauche(X, Y, Labyrinthe.TailleCase);
            Case droite = Laby.Droite(X, Y, Labyrinthe.TailleCase);

            if (haut != null)
                voisins.Add(haut);
            if (bas != null)
                voisins.Add(bas);
            if (gauche != null)
                voisins.Add(gauche);
            if (droite != null)
                voisins.Add(droite);

            for (int i = 0; i<= voisins.Count-1; i++)
            {
                Case case1 = voisins[i];
                if (case1.Solide)
                {
                    Rectangle mur = new Rectangle(case1.X, case1.Y, case1.Fond.Width, case1.Fond.Height);
                    if (newBounds.IntersectsWith(mur))
                    {
                        Debug.WriteLine("Collision");
                        // Le joueur entre en collision avec un mur, on ne le déplace pas
                        return;
                    }
                }

            }

            //déplacement uniquement si aucune collision
            X += deltaX*Speed;
            Y += deltaY*Speed;
            Skin.Location = new Point(X, Y);
        }

        public void JoueurKeyDown(object sender, KeyEventArgs e)
        {
            GetInfo();
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Deplacer(-1, 0); // gauche
                    break;
                case Keys.Right:
                    Deplacer(1, 0); // droite
                    break;
                case Keys.Up:
                    Deplacer(0, -1); // haut
                    break;
                case Keys.Down:
                    Deplacer(0, 1); // bas
                    break;
                default:
                    Deplacer(0, 0);
                    break;
            }
        }

        public void GetInfo()
        {
            Console.WriteLine($"{Nom} {PointsDeVie} {X} {Y}");

        }
    }
}
