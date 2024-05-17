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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{

    public partial class NouvellePartie : Form
    {
        public NouvellePartie()
        {
            //new Labyrinthe(this, 31, 23);
            new Labyrinthe(this, 3, 3);
            InitializeComponent();
        }

        private void NouvellePartie_Load(object sender, EventArgs e)
        {

        }

        private void NouvellePartie_KeyDown(object sender, KeyEventArgs e)
        {
            Labyrinthe.J1.getInfo();
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Labyrinthe.J1.Deplacer(-1, 0); // Déplacer à gauche
                    break;
                case Keys.Right:
                    Labyrinthe.J1.Deplacer(1, 0); // Déplacer à droite
                    break;
                case Keys.Up:
                    Labyrinthe.J1.Deplacer(0, -1); // Déplacer vers le haut
                    break;
                case Keys.Down:
                    Labyrinthe.J1.Deplacer(0, 1); // Déplacer vers le bas
                    break;
            }
        }
    }
    public class Case
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Solide { get; set; }
        public PictureBox Fond { get; set; }
        //public PictureBox devant;

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

        public void Actualiser_image()
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
        public Form Formulaire;
        static public Joueur J1 { get; set; } // Property to access J1

        public int Obtenir_coordonnée_valide(int deb, int fin)
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

        public int Obtenir_coordonée_liaison(int sommet, int voisin)
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
        public Case Haut(Case sommet, int pas)
        {
            if (sommet.Y - pas > 0)
                return Lab[sommet.X / TailleCase, (sommet.Y - pas) / TailleCase];
            return null;
        }

        public Case Bas(Case sommet, int pas)
        {
            if (sommet.Y + pas < Hauteur * TailleCase)
                return Lab[sommet.X / TailleCase, (sommet.Y + pas) / TailleCase];
            return null;
        }

        public Case Gauche(Case sommet, int pas)
        {
            if (sommet.X - pas > 0)
                return Lab[(sommet.X - pas) / TailleCase, sommet.Y / TailleCase];
            return null;
        }

        public Case Droite(Case sommet, int pas)
        {
            if (sommet.X + pas < Largeur * TailleCase)
                return Lab[(sommet.X + pas) / TailleCase, sommet.Y / TailleCase];
            return null;
        }

        public bool EstSolide(Case sommet)
        {
            if (sommet != null)
                return sommet.Solide;
            return false;
        }

        public void GénérationStructureLabyrinthe()
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

        public void GénérationAléatoire()
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

        public void GénérationAvancée()
        {
            Visités = new Case[Largeur * TailleCase, Hauteur * TailleCase];

            int startX = Obtenir_coordonnée_valide(1, Largeur - 1);
            int startY = Obtenir_coordonnée_valide(1, Hauteur - 1);
            Case sommet = Lab[startX, startY];
            sommet.Fond.Image = Puck_Man_Game.Properties.Resources.vide;
            J1 = new Joueur("Dodonut The Wild", 3, 1, startX*TailleCase, startY* TailleCase);
            Formulaire.Controls.Add(J1.Skin);

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

                Case haut = Haut(sommet, pas);
                Case bas = Bas(sommet, pas);
                Case gauche = Gauche(sommet, pas);
                Case droite = Droite(sommet, pas);

                //on ajoute les voisins valides non visités

                // Voisin du haut 
                if (haut != null && Visités[haut.X, (haut.Y)] == null)
                    voisinsNonVisites.Add(Lab[haut.X / TailleCase, haut.Y / TailleCase]);
                // Voisin du bas 
                if (bas != null && Visités[bas.X, bas.Y] == null)
                    voisinsNonVisites.Add(Lab[bas.X / TailleCase, bas.Y / TailleCase]);
                // Voisin de gauche
                if (gauche != null && Visités[gauche.X, gauche.Y] == null)
                    voisinsNonVisites.Add(Lab[gauche.X / TailleCase, gauche.Y / TailleCase]);
                // Voisin de droite
                if (droite != null && Visités[droite.X, droite.Y] == null)
                    voisinsNonVisites.Add(Lab[droite.X / TailleCase, droite.Y / TailleCase]);

                // Si la case actuelle a des voisins non visités
                if (voisinsNonVisites.Count > 0)
                {
                    //Choisit un voisin aléatoire non visité
                    Case voisin = voisinsNonVisites[random.Next(0, voisinsNonVisites.Count)];

                    //coordonnées de la liason entre le sommet et son voisin
                    int liaison_x = Obtenir_coordonée_liaison(sommet.X, voisin.X);
                    int liaison_y = Obtenir_coordonée_liaison(sommet.Y, voisin.Y); ;

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
                        if (!EstSolide(Haut(Lab[x, y], TailleCase)) &&
                            !EstSolide(Bas(Lab[x, y], TailleCase)) &&
                            !EstSolide(Gauche(Lab[x, y], TailleCase)) &&
                            !EstSolide(Droite(Lab[x, y], TailleCase)))
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

            GénérationStructureLabyrinthe();
            //GénérationAléatoire();
            GénérationAvancée();
        }
    }
}
