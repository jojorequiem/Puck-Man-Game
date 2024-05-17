using Puck_Man_Game.src.PuckMan.Game.Characters;
using Puck_Man_Game.src.PuckMan.UI.Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{

    public partial class NouvellePartie : Form
    {
        static public Joueur J1 { get; set; }

        public NouvellePartie()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.KeyDown += (sender, e) => J1.JoueurKeyDown(sender, e);
            /*Panel gamePanel = new Panel
            {
                Location = new Point(0, 0),
                Size = this.ClientSize,
                BackColor = Color.Transparent
                
            };*/
            Labyrinthe instanceLaby = new Labyrinthe(this, 23, 19);

            J1 = new Joueur("Dodonut", 3, 1, instanceLaby.StartX * Labyrinthe.TailleCase, instanceLaby.StartY * Labyrinthe.TailleCase);
            J1.Laby = instanceLaby;
            J1.Skin.BringToFront();
            this.Controls.Add(J1.Skin);
            J1.Skin.BringToFront();
            //Controls.Add(gamePanel);
        }

        private void NouvellePartie_Load(object sender, EventArgs e)
        {

        }
    }
    public class Case
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Solide { get; set; }
        public PictureBox Fond { get; set; }

        //liaison avec le voisins
        public bool haut, bas, droite, gauche;

        public Case(int x, int y)
        {
            X = x;
            Y = y;
            Solide = true;
            Fond = new PictureBox();
            Fond.Location = new Point(x, y);
            Fond.BackColor = Color.Transparent;

            Fond.SizeMode = PictureBoxSizeMode.StretchImage;
            Fond.Size = new Size(Labyrinthe.TailleCase, Labyrinthe.TailleCase);
        }

        public void ActualiserImage()
        {
            if (Solide)
                Fond.Image = Puck_Man_Game.Properties.Resources.mur;
            else
                Fond.Image = Puck_Man_Game.Properties.Resources.vide;
        }
    }

    public class Labyrinthe
    {
        private static Random random = new Random();
        public static int TailleCase = 32;
        //on effectue des pas de 2 en 2 car on ne veut intéragir que avec les sommets, pas avec les liaisons
        public static int pas = TailleCase * 2;
        public Case[,] Lab { get; set; }
        public Case[,] Visités { get; set; }

        public int Largeur;
        public int Hauteur;
        public int StartX;
        public int StartY;
        public Form Formulaire;

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
            if (y - pas > 0)
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
            if (x - pas > 0)
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
                    Case maCase = new Case(x * TailleCase, y * TailleCase);
                    Lab[x, y] = maCase;

                    //on génére une bordure de mur solide sur les côtés
                    //et un semi quadrillage
                    if ((x == 0 || x == Largeur - 1 || y == 0 || y == Hauteur - 1)
                        || ((x + y) % 2 == 0 && x % 2 == 0))
                    {
                        maCase.Fond.Image = Puck_Man_Game.Properties.Resources.mur;
                        maCase.Solide = true;
                    }
                    else if ((x + y) % 2 == 0 && x % 2 != 0)
                    {
                        maCase.Fond.Image = Puck_Man_Game.Properties.Resources.vide;
                        maCase.Solide = false;
                    }

                    //remplit 80% des liaisons avec des murs
                    else if (random.NextDouble() < 0.8)
                    {
                        Lab[x, y].Solide = true;
                        Lab[x, y].Fond.Image = Puck_Man_Game.Properties.Resources.mur;

                    }
                    else
                    {
                        Lab[x, y].Solide = false;
                        Lab[x, y].Fond.Image = Puck_Man_Game.Properties.Resources.vide;
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
                            Lab[x, y].Fond.Image = Puck_Man_Game.Properties.Resources.mur;
                        else
                            Lab[x, y].Fond.Image = Puck_Man_Game.Properties.Resources.porte;
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

            sommet.Fond.Image = Puck_Man_Game.Properties.Resources.égaré;
            sommet.Solide = false;

            
            //NouvellePartie.gamePanel.Controls.Add(NouvellePartie.J1.Skin);

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
                    Lab[liaison_x / TailleCase, liaison_y / TailleCase].Fond.Image = Puck_Man_Game.Properties.Resources.vide;

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


            //ajout de fragments de souvenirs (collectables)
            /*
            int nbr_fragments = 5;
            while (nbr_fragments > 0)
            {
                int x = Obtenir_coordonnée_valide(1, Largeur - 1);
                int y = Obtenir_coordonnée_valide(1, Hauteur - 1);

                if (Lab[x, y].Fond.Image != Puck_Man_Game.Properties.Resources.joueur)
                {
                    Lab[x, y].Fond.Image = Puck_Man_Game.Properties.Resources.fragment;
                    nbr_fragments -= 1;
                }
            }*/

            //faire une fonction public void génération(type, nombre) basé sur cette structure

            /*
            int nbr_ennemies = 5;
            while (nbr_ennemies > 0)
            {
                int x = Obtenir_coordonnée_valide(1, Largeur - 1);
                int y = Obtenir_coordonnée_valide(1, Hauteur - 1);

                if (Lab[x, y].Fond.Image != Puck_Man_Game.Properties.Resources.joueur)
                {
                    Lab[x, y].Fond.Image = Puck_Man_Game.Properties.Resources.égaré;
                    nbr_ennemies -= 1;
                }
            }
            */

            string matrice = "";

            //ajout des liaisons
            for (int y = 0; y < Hauteur; y++)
            {
                for (int x = 0; x < Largeur; x++)
                {
                    //on remplace les murs isolés
                    if (false && (x % 2 == 0 && y % 2 == 0))
                    {
                        if (!EstSolide(Haut(x * TailleCase, y * TailleCase, TailleCase)) &&
                            !EstSolide(Bas(x * TailleCase, y * TailleCase, TailleCase)) &&
                            !EstSolide(Gauche(x * TailleCase, y * TailleCase, TailleCase)) &&
                            !EstSolide(Droite(x * TailleCase, y * TailleCase, TailleCase)))
                        {

                            /*
                            Case voisin;
                            double rand = random.NextDouble();
                            if (rand < 0.25)
                                voisin = Haut(Lab[x, y], TailleCase);
                            else if (rand < 0.5)
                                voisin = Bas(Lab[x, y], TailleCase);
                            else if (rand < 0.75)
                                voisin = Gauche(Lab[x, y], TailleCase);
                            else
                                voisin = Droite(Lab[x, y], TailleCase);


                            voisin.solide = true;
                        voisin.fond.Image = Properties.Resources.mur;*/

                            Lab[x, y].Solide = false;
                            Lab[x, y].Fond.Image = Puck_Man_Game.Properties.Resources.vide;

                        }
                    }

                    if (Lab[x, y].Solide == true)
                    {
                        matrice += "1 ";
                    }
                    else
                    {
                        matrice += "0 ";
                    }


                    //on ajoute les cases au formulaire (sinon aucun affichage)
                    Formulaire.Controls.Add(Lab[x, y].Fond);
                }
                matrice += "\n";
            }
            //Debug.Write(matrice);
        }

        public Labyrinthe(Form formulaire, int largeur, int hauteur)
        {
            Formulaire = formulaire;
            Largeur = largeur;
            Hauteur = hauteur;
            Lab = new Case[Largeur, hauteur];

            GenerationStructureLabyrinthe();
            //GenerationAléatoire();
            GenerationAvancee();
        }
    }
}
