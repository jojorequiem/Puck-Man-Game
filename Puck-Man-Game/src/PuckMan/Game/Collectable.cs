 using Puck_Man_Game.src.PuckMan.Engine.Entities;
using Puck_Man_Game.src.PuckMan.UI.Screens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Puck_Man_Game.src.PuckMan.Game
{
    public class Collectable : Entity
    {
        public bool DejaCollecte;
        public Collectable(string name, int x, int y) : base(x, y, name)
        {
            DejaCollecte = false;
            if (EntityName == "fragment")
                Image.Image = Puck_Man_Game.Properties.Resources.fragment;
            if (EntityName == "égaré")
                Image.Image = Puck_Man_Game.Properties.Resources.égaré;

        }
        public void Collecte(NouvellePartie Formulaire)
        {
            if (!DejaCollecte){
                DejaCollecte=true;
                Image.Hide();
                if (EntityName == "fragment")
                    Formulaire.FragmentCollecte();
                else
                    Console.WriteLine("Erreur dans collectable");

            }
        }
    }

}
