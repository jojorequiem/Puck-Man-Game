using Puck_Man_Game.src.PuckMan.UI.Screens;
using System;

namespace Puck_Man_Game.src.PuckMan.Engine.Entities
{
    public class Enemy : Entity
    {
        public string EnemyClass { get; set; }
        public int Damage { get; set; }

        public Enemy(string name, int x, int y) : base(x, y, name)
        {
            Image.Image = Puck_Man_Game.Properties.Resources.égaré;
            if (name == "égaré")
                Damage = 1;
        }
    }
}