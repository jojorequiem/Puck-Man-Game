using System;

namespace Puck_Man_Game.src.PuckMan.Engine.Entities
{
    internal class Adversaire
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public string Classe { get; set; }
        public int Vitesse { get; set; }
        public int Sante { get; set; }
        public int DegatAttaque { get; set; }
        public int IdItemDrop { get; set; }
        public int NumeroMatrice { get; set; }

        public Adversaire(int id, string nom, string classe, int vitesse, int sante, int degatAttaque, int idItemDrop, int numeroMatrice)
        {
            Id = id;
            Nom = nom;
            Classe = classe;
            Vitesse = vitesse;
            Sante = sante;
            DegatAttaque = degatAttaque;
            IdItemDrop = idItemDrop;
            NumeroMatrice = numeroMatrice;
        }

        public void AfficherDetails()
        {
            Console.WriteLine($"Nom : {Nom}");
            Console.WriteLine($"Classe : {Classe}");
            Console.WriteLine($"Vitesse : {Vitesse}");
            Console.WriteLine($"Santé : {Sante}");
            Console.WriteLine($"Dégât d'attaque : {DegatAttaque}");
            Console.WriteLine($"ID de l'item drop : {IdItemDrop}");
            Console.WriteLine($"Numéro de matrice : {NumeroMatrice}");
        }
    }

}