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
    public static class Program
    {
        public static int WindowWidth = 900;
        public static int WindowHeight = 650;
        public static int MazeWidth = 17;
        public static int MazeHeight = 15;

        public static Color BackgroundColor = Color.Black;
        public static Color TextColor = Color.White;
        public static Color ButtonColor = Color.SkyBlue;

        private static WindowsMediaPlayer music;
        public static int MainVolume;
        public static int SoundVolume;
        public static int MusicVolume;
        public static string LastMusicPlayed = "";
        static public string menuMusicFilepath = "assets/audio/MenuMusic.mp3";
        static public string transitionMusicFilepath = "assets/audio/TransitionMusic.mp3";

        public static FrmScoreRanking FrmScoreRanking = null;
        public static FrmDeath FrmDeath = null;
        public static FrmDialogue FrmDialogue = null;
        public static FrmMenu FrmMenu = null;
        public static FrmCreateNewGame FrmCreateNewGame = null;
        public static FrmPlay FrmPlay = null;
        public static FrmPause FrmPause = null;
        public static FrmStoryMode FrmStoryMode = null;
        public static FrmNextLevel FrmNextLevel = null;
        public static FrmNewGame FrmNewGame = null;
        public static FrmParameters FrmParameters = null;

        public static int game;
        public static int score = 0;

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] lines = File.ReadAllLines("src/database/AudioParameters.txt", Encoding.UTF8);
            MainVolume = int.Parse(lines[0]);
            SoundVolume = int.Parse(lines[1]);
            MusicVolume = int.Parse(lines[2]);

            PlayMusic(menuMusicFilepath);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmMenu = new src.PuckMan.UI.FrmMenu();
            Application.Run(FrmMenu);

        }

        static public void UpdateVolume()
        {
            music.settings.volume = MusicVolume * MainVolume;
        }

        static public void PlaySound(string path)
        {
            WindowsMediaPlayer sound = new WindowsMediaPlayer
            {
                URL = path
            };
            sound.settings.volume = SoundVolume * MainVolume;
            sound.controls.play();
        }

        static public void PlayMusic(string path)
        {
            LastMusicPlayed = path;
            if (music != null)
                music.close();
            music = new WindowsMediaPlayer{
                URL = path
            };
            music.settings.setMode("loop", true);
            music.settings.volume = MainVolume * 10;
            music.controls.play();
        }
        static public void ChangeActiveForm(Form formulaire, Form parent)
        {
            formulaire.StartPosition = FormStartPosition.Manual;
            formulaire.Location = parent.Location;
            formulaire.Show();
            parent.Hide();

            //on joue la musique du thème menu si on retourne dans le menu et si elle n'est pas déjà joué
            if (formulaire is FrmMenu && menuMusicFilepath != LastMusicPlayed)
                PlayMusic(menuMusicFilepath);

            
            // actualiser l'affichage des formulaires
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
                //mettre en pause le joueur et les ennemis
                if (frmNouvellePartie.P1.deplacementContinuActive)
                    frmNouvellePartie.P1.moveTimer.Start();
                foreach (Enemy enemy in frmNouvellePartie.P1.Maze.EnemyList)
                    enemy.moveEnemyTimer.Start();
            }

            var openForms = Application.OpenForms.Cast<Form>().ToList();
            Console.WriteLine($"Formulaires ouverts : {openForms.Count}");
            foreach (var form in openForms)
                Console.WriteLine($"Nom : {form.Name}");
            Console.WriteLine();
        }
    }
}