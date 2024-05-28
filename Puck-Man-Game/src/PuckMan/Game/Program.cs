using Puck_Man_Game.src.PuckMan.Engine.Entities;
using Puck_Man_Game.src.PuckMan.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Puck_Man_Game
{
    public static class Program
    {
        public static int LargeurFenetre = 1200;
        public static int HauteurFenetre = 700;
        public static Color BackgroundColor = Color.Black;
        public static Color TextColor = Color.White;
        public static Color ButtonColor = Color.Maroon;

        /*
                    this.ClientSize = new System.Drawing.Size(Program.LargeurFenetre, Program.HauteurFenetre);
            this.MaximumSize = new System.Drawing.Size(Program.LargeurFenetre, Program.HauteurFenetre);
         this.MinimumSize = new System.Drawing.Size(Program.LargeurFenetre, Program.HauteurFenetre);
        */

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