using Puck_Man_Game.src.PuckMan.UI.Screens;
using System;

namespace Puck_Man_Game.src.PuckMan.Engine.Entities
{
    public class Adversaire : Entity
    {
        public string Classe { get; set; }
        public int Degat { get; set; }

        public Adversaire(string nom, int x, int y) : base(x, y, nom)
        {
            Image.Image = Puck_Man_Game.Properties.Resources.égaré;
            if (nom == "égaré")
                Degat = 1;
        }
    }
}