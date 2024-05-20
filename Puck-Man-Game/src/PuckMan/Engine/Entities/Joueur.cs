using Puck_Man_Game.src.PuckMan.Engine.Entities;
using Puck_Man_Game.src.PuckMan.Game;
using Puck_Man_Game.src.PuckMan.Game.Levels;
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

namespace Puck_Man_Game.src.PuckMan.Game.Entities
{
    public class Joueur : Entity
    {
        // Propriétés du joueur
        public int Niveau { get; set; }
        public Labyrinthe Laby;
        // Constructeur
        public Joueur(string nom, int pv, int niveau,int x, int y, Labyrinthe laby) : base(x, y, nom)
        {
            PV = pv;
            Niveau = niveau;
            Laby = laby;
            Vitesse = Labyrinthe.TailleCase;
            Image.Image = Puck_Man_Game.Properties.Resources.joueur;
        }

        public void Deplacer(int deltaX, int deltaY)
        {
            // Vérifie les collisions avec les murs voisins
            Rectangle newBounds = new Rectangle(X+deltaX, Y+deltaY, Image.Width, Image.Height);
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
                    if (newBounds.IntersectsWith(new Rectangle(case1.X, case1.Y, case1.Image.Width, case1.Image.Height)))
                        return; // Le joueur entre en collision avec un mur, on ne le déplace pas
                }
            }

            //déplacement uniquement si aucune collision
            X += deltaX*Vitesse;
            Y += deltaY*Vitesse;
            if (Laby.Entites[X,Y]!= null)
            {
                if (Laby.Entites[X, Y] is Collectable collectable && collectable.Nom == "fragment")
                {
                    collectable.Collecte(Laby.Formulaire);
                }   
                    
                if (Laby.Entites[X, Y] is Adversaire adversaire && adversaire.Nom == "égaré")
                    RecoitDegats(adversaire.Degat);
            }
            Image.Location = new Point(X, Y);
        }

        public void RecoitDegats(int degats)
        {
            PV -= degats;
            Debug.WriteLine(PV);
            Laby.Formulaire.ActualiserAffichagePV();
            if (PV <= 0)
                Mort();
            
        }

        public void Mort()
        {
            Program.ChargerScene(typeof(NouvellePartie), Laby.Formulaire);
        }

        public void JoueurKeyDown(object sender, KeyEventArgs e)
        {
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
            Console.WriteLine($"{Nom} {PV} {X} {Y}");

        }
    }
}
