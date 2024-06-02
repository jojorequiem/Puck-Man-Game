using Puck_Man_Game.src.PuckMan.Engine.Entities;
using Puck_Man_Game.src.PuckMan.Game.Entities;
using Puck_Man_Game.src.PuckMan.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
namespace Puck_Man_Game
{
    public static class Program
    {
        public static int LargeurFenetre = 1200;
        public static int HauteurFenetre = 700;
        public static Color BackgroundColor = Color.Black;
        public static Color TextColor = Color.White;
        public static Color ButtonColor = Color.DarkGray;

        private static WindowsMediaPlayer music;
        public static int VolumePrincipale;
        public static int VolumeSon;
        public static int VolumeMusique;

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //devra être chargé depuis le fichier de sauvegarde
            VolumePrincipale = 10;
            VolumeSon = 10;
            VolumeMusique = 10;
            PlayMusic("assets/audio/musiqueMenu.mp3");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new src.PuckMan.UI.Menu());
            //Application.Run(new src.PuckMan.UI.Screens.Dialogue());
        }

        static public void UpdateVolume()
        {
            music.settings.volume = VolumeMusique * VolumePrincipale;
        }

        static public void PlaySound(string path)
        {
            WindowsMediaPlayer sound = new WindowsMediaPlayer
            {
                URL = path
            };
            sound.settings.volume = VolumeSon * VolumePrincipale;
            sound.controls.play();
        }

        static public void PlayMusic(string path)
        {
           if (music != null)
                music.close();
            music = new WindowsMediaPlayer{
                URL = path
            };
            
            music.settings.volume = VolumePrincipale * 10;
            music.controls.play();
        }

        static public void LoadScene(Type type, Form formulaire)
        {
            // Ferme la forme actuelle et crée une nouvelle instance
            formulaire.Close(); // Ferme le form actuelle
            Form instance = (Form)Activator.CreateInstance(type);
            instance.StartPosition = FormStartPosition.Manual;
            instance.Location = formulaire.Location;
            instance.Show(); 
        }
    }
}