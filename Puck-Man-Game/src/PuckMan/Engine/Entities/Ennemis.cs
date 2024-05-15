using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puck_Man_Game.src.PuckMan.Engine.Entities

{
    internal class Ennemis
    {
        public static Adversaire Egare { get; } = new Adversaire(
                id: 1,
                nom: "Égaré Standard",
                classe: "Égaré",
                vitesse: 2,
                sante: 100,
                degatAttaque: 10,
                idItemDrop: 1,
                numeroMatrice: 1
            );
    }


    }
