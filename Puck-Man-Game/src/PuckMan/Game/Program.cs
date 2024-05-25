using Puck_Man_Game.src.PuckMan.Engine.Entities;
using Puck_Man_Game.src.PuckMan.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Puck_Man_Game
{
    public static class Program
    {
        public static int LargeurFenetre = 1100;
        public static int HauteurFenetre = 787;
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

        static public void LoadScene(Type type, Form formulaire)
        {
            // Ferme la forme actuelle et crée une nouvelle instance
            Form instance = (Form)Activator.CreateInstance(type);
            instance.StartPosition = FormStartPosition.Manual;
            instance.Location = formulaire.Location;
            instance.Show();
            formulaire.Close(); // Ferme la forme actuelle
        }

    }
}