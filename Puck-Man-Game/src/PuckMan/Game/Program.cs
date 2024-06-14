using Puck_Man_Game.src.PuckMan.Engine.Entities;
using Puck_Man_Game.src.PuckMan.Game.Entities;
using Puck_Man_Game.src.PuckMan.UI;
using Puck_Man_Game.src.PuckMan.UI.Screens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
namespace Puck_Man_Game
{
    public static class Program
    {
        public static int LargeurFenetre = 900;
        public static int HauteurFenetre = 650;
        public static int MazeWidth = 17;
        public static int MazeHeight = 15;

        public static Color BackgroundColor = Color.Black;
        public static Color TextColor = Color.White;
        public static Color ButtonColor = Color.SkyBlue;

        private static WindowsMediaPlayer music;
        public static int VolumePrincipale;
        public static int VolumeSon;
        public static int VolumeMusique;

        public static FrmClassement FrmClassement = null;
        public static FrmDialogue FrmDialogue = null;
        public static FrmMenu FrmMenu = null;
        public static FrmJouer FrmJouer = null;
        public static FrmPause FrmPause = null;
        public static FrmModeHistoire FrmModeHistoire = null;
        public static FrmNiveauSuivant FrmNiveauSuivant = null;
        public static FrmNouvellePartie FrmNouvellePartie = null;
        public static FrmParametres FrmParametres = null;

        public static int game;


        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            VolumePrincipale = 0;
            VolumeSon = 0;
            VolumeMusique = 0;
            PlayMusic("assets/audio/musiqueMenu.mp3");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmMenu = new src.PuckMan.UI.FrmMenu();
            Application.Run(FrmMenu);

            //Application.Run(new src.PuckMan.UI.Screens.ModeHistoire());
            //Application.Run(new src.PuckMan.UI.Screens.Dialogue());

            //var rootDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            //var databaseDirectory = Path.Combine(rootDirectory, "Puck-Man-Game", "src", "database");
            //var filePath = Path.Combine(databaseDirectory, "example.csv");
            //var csvManager = new CsvFileManager(filePath);
            //var records = new List<CsvRecord>
            //{
            //    new CsvRecord { Id = 1, NomSauvegarde = "Partie 1", NiveauActuel = 10, ModeJeu = "Mode A", Difficulte = "Facile", Score = 1000, MatriceLabyrinthe = "matrix1", PseudoJoueur = "Joueur1", NombreVies = 3, NombreCoeurs = 5 },
            //    new CsvRecord { Id = 2, NomSauvegarde = "Partie 2", NiveauActuel = 5, ModeJeu = "Mode B", Difficulte = "Moyen", Score = 800, MatriceLabyrinthe = "matrix2", PseudoJoueur = "Joueur2", NombreVies = 2, NombreCoeurs = 3 }
            //};
            //csvManager.WriteRecords(records);

            ////csvManager.ResetFile();
            //Console.WriteLine("Fichier réinitialisé.");
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
        static public void ChangeActiveForm(Form formulaire, Form parent)
        {
            formulaire.StartPosition = FormStartPosition.Manual;
            formulaire.Location = parent.Location;
            formulaire.Show();
            parent.Hide();
            var openForms = Application.OpenForms.Cast<Form>().ToList();
            Console.WriteLine($"Number of open forms: {openForms.Count}");
            foreach (var form in openForms)
                Console.WriteLine($"Form name: {form.Name}");
            Console.WriteLine();
        }

    }
}