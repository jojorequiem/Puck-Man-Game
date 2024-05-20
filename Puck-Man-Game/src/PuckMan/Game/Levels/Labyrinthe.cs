using Puck_Man_Game.src.PuckMan.Engine.Entities;
using Puck_Man_Game.src.PuckMan.UI.Screens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puck_Man_Game.src.PuckMan.Game.Levels
{
    public class Labyrinthe
    {
        private static Random random = new Random();
        public static int TailleCase = 32;
        //on effectue des pas de 2 en 2 car on ne veut intéragir que avec les sommets, pas avec les liaisons
        public static int pas = TailleCase * 2;
        public Case[,] Lab { get; set; }
        public Case[,] Visités { get; set; }
        public Entity[,] Entites { get; set; }
        public int Largeur;
        public int Hauteur;
        public int StartX;
        public int StartY;
        public int NbrFragmentGenere;
        public int NbrAdversaires;
        public NouvellePartie Formulaire;

        public int ObtenirCoordonneeValide(int deb, int fin)
        {
            //une coordonnée est valide si elle est impair et entre deb et fin
            int coordonnée = random.Next(deb, fin);

            // Si le nombre aléatoire est pair, on l'incrémente de 1 pour le rendre impair
            if (coordonnée % 2 == 0)
            {
                coordonnée++;
            }
            return coordonnée;
        }

        public int ObtenirCoordoneeLiaison(int sommet, int voisin)
        {
            int liaison;
            if (voisin > sommet)
                liaison = sommet + TailleCase;
            else if (voisin < sommet)
                liaison = sommet - TailleCase;
            else
                liaison = sommet;
            return liaison;
        }

        //return voisin du dessus, du dessous, à droite, à gauche
        public Case Haut(int x, int y, int pas)
        {
            if (y - pas >= 0)
                return Lab[x / TailleCase, (y - pas) / TailleCase];
            return null;
        }

        public Case Bas(int x, int y, int pas)
        {
            if (y + pas < Hauteur * TailleCase)
                return Lab[x / TailleCase, (y + pas) / TailleCase];
            return null;
        }

        public Case Gauche(int x, int y, int pas)
        {
            if (x - pas >= 0)
                return Lab[(x - pas) / TailleCase, y / TailleCase];
            return null;
        }

        public Case Droite(int x, int y, int pas)
        {
            if (x + pas < Largeur * TailleCase)
                return Lab[(x + pas) / TailleCase, y / TailleCase];
            return null;
        }

        public bool EstSolide(Case sommet)
        {
            if (sommet != null)
                return sommet.Solide;
            return false;
        }

        public void GenerationStructureLabyrinthe()
        {
            for (int x = 0; x < Largeur; x++)
            {
                for (int y = 0; y < Hauteur; y++)
                {

                    //"case" est un mot clé en C# (switch case)
                    Case maCase = new Case(x * TailleCase, y * TailleCase, "case");
                    Lab[x, y] = maCase;

                    //on génére une bordure de mur solide sur les côtés
                    //et un semi quadrillage
                    if ((x == 0 || x == Largeur - 1 || y == 0 || y == Hauteur - 1)
                        || ((x + y) % 2 == 0 && x % 2 == 0))
                    {
                        maCase.Image.Image = Puck_Man_Game.Properties.Resources.mur;
                        maCase.Solide = true;
                    }
                    else if ((x + y) % 2 == 0 && x % 2 != 0)
                    {
                        maCase.Image.Image = Puck_Man_Game.Properties.Resources.vide;
                        maCase.Solide = false;
                    }

                    //remplit 80% des liaisons avec des murs
                    else if (random.NextDouble() < 0.8)
                    {
                        Lab[x, y].Solide = true;
                        Lab[x, y].Image.Image = Puck_Man_Game.Properties.Resources.mur;

                    }
                    else
                    {
                        Lab[x, y].Solide = false;
                        Lab[x, y].Image.Image = Puck_Man_Game.Properties.Resources.vide;
                    }
                }
            }
        }
        public void GenerationAleatoire()
        {
            for (int x = 0; x < Largeur; x++)
            {
                for (int y = 0; y < Hauteur; y++)
                {
                    if ((x != 0 && y != 0 && x != Largeur - 1 && y != Hauteur - 1)
                        && ((x + y) % 2 != 0))
                    {
                        if (random.NextDouble() < 0.5)
                            Lab[x, y].Image.Image = Puck_Man_Game.Properties.Resources.mur;
                        else
                            Lab[x, y].Image.Image = Puck_Man_Game.Properties.Resources.porte;
                    }
                }
            }
        }

        public void GenerationAvancee()
        {
            Visités = new Case[Largeur * TailleCase, Hauteur * TailleCase];

            int startX = ObtenirCoordonneeValide(1, Largeur - 1);
            int startY = ObtenirCoordonneeValide(1, Hauteur - 1);
            Case sommet = Lab[startX, startY];

            StartX = startX;
            StartY = startY;

            // Marquer la case de départ comme visitée
            Visités[startX * TailleCase, startY * TailleCase] = sommet;

            // Créer une pile pour stocker les cases à explorer
            Stack<Case> pile = new Stack<Case>();
            pile.Push(sommet);

            // Tant que la pile n'est pas vide
            while (pile.Count > 0)
            {
                // Recuperer un sommet
                sommet = pile.Peek();

                List<Case> voisinsNonVisites = new List<Case>();

                Case haut = Haut(sommet.X, sommet.Y, pas);
                Case bas = Bas(sommet.X, sommet.Y, pas);
                Case gauche = Gauche(sommet.X, sommet.Y, pas);
                Case droite = Droite(sommet.X, sommet.Y, pas);

                //on ajoute les voisins valides non visités
                if (haut != null && Visités[haut.X, (haut.Y)] == null)
                    voisinsNonVisites.Add(haut);
                if (bas != null && Visités[bas.X, bas.Y] == null)
                    voisinsNonVisites.Add(bas);
                if (gauche != null && Visités[gauche.X, gauche.Y] == null)
                    voisinsNonVisites.Add(gauche);
                if (droite != null && Visités[droite.X, droite.Y] == null)
                    voisinsNonVisites.Add(droite);

                // Si la case actuelle a des voisins non visités
                if (voisinsNonVisites.Count > 0)
                {
                    //Choisit un voisin aléatoire non visité
                    Case voisin = voisinsNonVisites[random.Next(0, voisinsNonVisites.Count)];

                    //coordonnées de la liason entre le sommet et son voisin
                    int liaison_x = ObtenirCoordoneeLiaison(sommet.X, voisin.X);
                    int liaison_y = ObtenirCoordoneeLiaison(sommet.Y, voisin.Y); ;

                    //on crée un chemin entre le sommet et son voisin
                    Lab[liaison_x / TailleCase, liaison_y / TailleCase].Solide = false;
                    Lab[liaison_x / TailleCase, liaison_y / TailleCase].Image.Image = Puck_Man_Game.Properties.Resources.vide;

                    //on marque le voisin comme visité
                    Visités[voisin.X, voisin.Y] = voisin;

                    //on met le voisin dans la pile pour exploration future
                    pile.Push(voisin);
                }
                else
                {
                    pile.Pop(); //si le sommet n'a plus de voisin a exploré, on le depile
                }
            }
        }

        public void AffichageLabyrinthe()
        {
            string matrice = "";
            for (int y = 0; y < Hauteur; y++)
            {
                for (int x = 0; x < Largeur; x++)
                {
                    RetirerMurIsoles(x, y);
                    if (Lab[x, y].Solide == true)
                        matrice += "X ";
                    else
                        matrice += ". ";

                    //on ajoute les cases au formulaire (sinon aucun affichage)
                    Formulaire.Controls.Add(Lab[x, y].Image);
                }
                matrice += "\n";
            }
            Debug.Write(matrice);
        }

        public void GenerationEntite(Type type, string nom, int nbr)
        {
            while (nbr > 0)
            {
                int x = ObtenirCoordonneeValide(1, Largeur - 1);
                int y = ObtenirCoordonneeValide(1, Hauteur - 1);
                //s'il n'y a pas déjà quelquechose à l'endroit prévu
                if (Entites[x * TailleCase, y * TailleCase] is null)
                {
                    Entity instance = (Entity)Activator.CreateInstance(type, nom, x * TailleCase, y * TailleCase);
                    Formulaire.Controls.Add(instance.Image);
                    instance.Image.BringToFront();
                    nbr -= 1;
                    Entites[x * TailleCase, y * TailleCase] = instance;
                }
            }
        }
        public void RetirerMurIsoles(int x, int y)
        {
            if (x % 2 == 0 && y % 2 == 0)
            {
                if (!EstSolide(Haut(x * TailleCase, y * TailleCase, TailleCase)) &&
                    !EstSolide(Bas(x * TailleCase, y * TailleCase, TailleCase)) &&
                    !EstSolide(Gauche(x * TailleCase, y * TailleCase, TailleCase)) &&
                    !EstSolide(Droite(x * TailleCase, y * TailleCase, TailleCase)))
                {
                    Lab[x, y].Solide = false;
                    Lab[x, y].Image.Image = Puck_Man_Game.Properties.Resources.coeur;
                }
            }
        }

        public Labyrinthe(NouvellePartie formulaire, int largeur, int hauteur)
        {
            Formulaire = formulaire;
            Largeur = largeur;
            Hauteur = hauteur;
            Lab = new Case[Largeur, hauteur];
            Entites = new Entity[largeur * TailleCase, hauteur * TailleCase];
            NbrFragmentGenere = 1;
            NbrAdversaires = 7;

            GenerationStructureLabyrinthe();
            //GenerationAleatoire();
            GenerationAvancee();
            AffichageLabyrinthe();
        }
    }
}
