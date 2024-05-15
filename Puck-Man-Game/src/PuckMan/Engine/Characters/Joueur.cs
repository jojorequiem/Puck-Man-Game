using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puck_Man_Game.src.PuckMan.Game.Characters
{
    internal class Joueur
    {
        // Propriétés du joueur
        public string Nom { get; set; }
        public int PointsDeVie { get; set; }
        public int Niveau { get; set; }

        // Constructeur
        public Joueur(string nom, int pointsDeVie, int niveau)
        {
            Nom = nom;
            PointsDeVie = pointsDeVie;
            Niveau = niveau;
        }

        // Méthode pour attaquer un adversaire
        public void getInfo()
        {
            Console.WriteLine($"{Nom} {PointsDeVie} {Niveau}");

        }

    }
}
