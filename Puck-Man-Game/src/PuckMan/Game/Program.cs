using Puck_Man_Game.src.PuckMan.Engine.Entities;
using Puck_Man_Game.src.PuckMan.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Puck_Man_Game
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new src.PuckMan.UI.Menu());
        }
    }
}