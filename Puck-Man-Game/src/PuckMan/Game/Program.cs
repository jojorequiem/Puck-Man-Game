using Puck_Man_Game.src.PuckMan.Engine.Entities;
using Puck_Man_Game.src.PuckMan.Game.Entities;
using Puck_Man_Game.src.PuckMan.UI;
using Puck_Man_Game.src.PuckMan.UI.Screens;
using src.PuckMan.Game.Levels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
namespace Puck_Man_Game
{
    /// <summary>
    /// Classe principale du programme Puck Man, gérant le point d'entrée et la logique globale du jeu.
    /// </summary>
    public static class Program
    {
 
        public static int WindowWidth = 900;    // Largeur de la fenêtre principale du jeu.
        public static int WindowHeight = 650;   // Hauteur de la fenêtre principale du jeu.
        public static int MazeWidth = 17;       // Largeur du labyrinthe du jeu.
        public static int MazeHeight = 15;      // Hauteur du labyrinthe du jeu.


        public static Color BackgroundColor = Color.Black;  // Couleur de l'arrière-plan de l'interface utilisateur.

        public static Color TextColor = Color.White;        // Couleur du texte de l'interface utilisateur.

        public static Color ButtonColor = Color.SkyBlue;    // Couleur des boutons de l'interface utilisateur.

        private static WindowsMediaPlayer music;            // Lecteur Windows Media Player pour la musique de fond

        public static int MainVolume; // Volume principal de l'application.

        public static int SoundVolume; // Volume des effets sonores.

        public static int MusicVolume; // Volume de la musique.

        public static string LastMusicPlayed = ""; // Dernière musique jouée.

        static public string menuMusicFilepath = "assets/audio/MenuMusic.mp3";         // Chemin du fichier audio de la musique du menu
        static public string transitionMusicFilepath = "assets/audio/TransitionMusic.mp3"; // Chemin du fichier audio de transition

        public static FrmScoreRanking FrmScoreRanking = null;        // Fenêtre de classement des scores
        public static FrmDeath FrmDeath = null;                      // Fenêtre de fin de jeu (décès du joueur)
        public static FrmDialogue FrmDialogue = null;                // Fenêtre de dialogue
        public static FrmMenu FrmMenu = null;                        // Fenêtre principale du menu
        public static FrmCreateNewGame FrmCreateNewGame = null;      // Fenêtre de création d'une nouvelle partie
        public static FrmPlay FrmPlay = null;                        // Fenêtre de jeu en cours
        public static FrmPause FrmPause = null;                      // Fenêtre de pause
        public static FrmStoryMode FrmStoryMode = null;              // Fenêtre de mode histoire
        public static FrmNextLevel FrmNextLevel = null;              // Fenêtre de passage au niveau suivant
        public static FrmNewGame FrmNewGame = null;                  // Fenêtre de nouvelle partie
        public static FrmParameters FrmParameters = null;            // Fenêtre de paramètres

        public static int game;      // Statut du jeu (non utilisé dans ce code)
        public static int score = 0; // Score actuel du joueur

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] lines = File.ReadAllLines("src/database/AudioParameters.txt", Encoding.UTF8);
            MainVolume = int.Parse(lines[0]);       // Charge le volume principal depuis le fichier de paramètres
            SoundVolume = int.Parse(lines[1]);      
            MusicVolume = int.Parse(lines[2]);      

            PlayMusic(menuMusicFilepath);           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmMenu = new src.PuckMan.UI.FrmMenu(); 
            Application.Run(FrmMenu);               // Lance l'application avec la fenêtre du menu
        }

        /// <summary>
        /// Met à jour le volume de la musique en cours.
        /// </summary>
        static public void UpdateVolume()
        {
            music.settings.volume = MusicVolume * MainVolume;   // Met à jour le volume de la musique
        }

        /// <summary>
        /// Joue un effet sonore à partir du chemin spécifié.
        /// </summary>
        /// <param name="path">Chemin du fichier sonore à jouer.</param>
        static public void PlaySound(string path)
        {
            WindowsMediaPlayer sound = new WindowsMediaPlayer
            {
                URL = path
            };
            sound.settings.volume = SoundVolume * MainVolume;    // Applique le volume des effets sonores
            sound.controls.play();                              // Joue le son
        }

        /// <summary>
        /// Joue de la musique à partir du chemin spécifié.
        /// </summary>
        /// <param name="path">Chemin du fichier musical à jouer.</param>
        static public void PlayMusic(string path)
        {
            LastMusicPlayed = path;
            if (music != null)
                music.close();                                  // Ferme le lecteur musical précédent si nécessaire

            music = new WindowsMediaPlayer
            {
                URL = path
            };
            music.settings.setMode("loop", true);                // Configure la lecture en boucle
            music.settings.volume = MainVolume * 10;             // Applique le volume de la musique
            music.controls.play();                              
        }

        /// <summary>
        /// Change le formulaire actif dans l'application.
        /// </summary>
        /// <param name="formulaire">Formulaire à afficher.</param>
        /// <param name="parent">Formulaire parent à masquer.</param>
        static public void ChangeActiveForm(Form formulaire, Form parent)
        {
            formulaire.StartPosition = FormStartPosition.Manual; 
            formulaire.Location = parent.Location;               // Positionne le formulaire à la même position que le parent
            formulaire.Show();                                   
            parent.Hide();                                       

            // Joue la musique du menu si on revient au menu et si elle n'est pas déjà jouée
            if (formulaire is FrmMenu && menuMusicFilepath != LastMusicPlayed)
                PlayMusic(menuMusicFilepath);

            // Actualise l'affichage des formulaires selon le type de formulaire affiché
            if (formulaire is FrmDialogue && !(parent is FrmDialogue))
                PlayMusic(transitionMusicFilepath);              

            if (formulaire is FrmNextLevel)
                PlayMusic("assets/audio/TransitionMusic.mp3");   

            if (formulaire is FrmScoreRanking frmClassement)
                frmClassement.DisplayClassement();               

            if (formulaire is FrmStoryMode frmModeHistoire)
                frmModeHistoire.DisplayButtons();                

            if (formulaire is FrmNewGame frmNouvellePartie && parent is FrmPause)
            {
                // Met en pause le joueur et les ennemis
                if (frmNouvellePartie.P1.deplacementContinuActive)
                    frmNouvellePartie.P1.moveTimer.Start();      

                foreach (Enemy enemy in frmNouvellePartie.P1.Maze.EnemyList)
                    enemy.moveEnemyTimer.Start();                
            }

            var openForms = Application.OpenForms.Cast<Form>().ToList();
            Console.WriteLine($"Formulaires ouverts : {openForms.Count}");  // Affiche le nombre de formulaires ouverts
            foreach (var form in openForms)
                Console.WriteLine($"Nom : {form.Name}");                   // Affiche le nom de chaque formulaire ouvert
            Console.WriteLine();
        }
    }
}