using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Runtime.CompilerServices;

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    /// <summary>
    /// Fenêtre permettant de modifier les paramètres audio du jeu.
    /// </summary>
    public partial class FrmParameters : FormComponent
    {
        public FormComponent FormParent;
        static private string filepath = "src/database/AudioParameters.txt";

        /// <summary>
        /// Constructeur de la classe FrmParameters.
        /// Initialise la fenêtre avec les paramètres audio actuels du jeu.
        /// </summary>
        /// <param name="formParent">Form parent qui a ouvert cette fenêtre.</param>
        public FrmParameters(FormComponent formParent)
        {
            InitializeComponent();
            FormParent = formParent;
            LblMainValue.Text = Program.MainVolume.ToString();
            TrackBarMain.Value = Program.MainVolume;
            LblMusicValue.Text = Program.MusicVolume.ToString();
            TrackBarMusic.Value = Program.MusicVolume;
            LblSoundValue.Text = Program.SoundVolume.ToString();
            TrackBarSound.Value = Program.SoundVolume;
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Retour".
        /// Retourne à la fenêtre parente.
        /// </summary>
        private void BtnRetour_Click(object sender, EventArgs e)
        {
            Program.ChangeActiveForm(FormParent, this);
        }

        /// <summary>
        /// Événement déclenché lors du changement de valeur du TrackBar de volume principal.
        /// Met à jour le volume principal du jeu et sauvegarde le paramètre dans un fichier.
        /// </summary>
        private void TrackBarMain_ValueChanged(object sender, EventArgs e)
        {
            Program.MainVolume = TrackBarMain.Value;
            LblMainValue.Text = TrackBarMain.Value.ToString();
            Program.UpdateVolume();

            string[] lines = File.ReadAllLines(filepath, Encoding.UTF8);
            lines[0] = TrackBarMain.Value.ToString();
            File.WriteAllLines(filepath, lines, Encoding.UTF8);
        }

        /// <summary>
        /// Événement déclenché lors du changement de valeur du TrackBar de volume de la musique.
        /// Met à jour le volume de la musique du jeu et sauvegarde le paramètre dans un fichier.
        /// </summary>
        private void TrackBarMusic_ValueChanged(object sender, EventArgs e)
        {
            Program.MusicVolume = TrackBarMusic.Value;
            LblMusicValue.Text = TrackBarMusic.Value.ToString();
            Program.UpdateVolume();

            string[] lines = File.ReadAllLines(filepath, Encoding.UTF8);
            lines[1] = TrackBarMusic.Value.ToString();
            File.WriteAllLines(filepath, lines, Encoding.UTF8);
        }

        /// <summary>
        /// Événement déclenché lors du changement de valeur du TrackBar de volume des effets sonores.
        /// Met à jour le volume des effets sonores du jeu et sauvegarde le paramètre dans un fichier.
        /// </summary>
        private void TrackBarSound_ValueChanged(object sender, EventArgs e)
        {
            Program.SoundVolume = TrackBarSound.Value;
            LblSoundValue.Text = TrackBarSound.Value.ToString();
            Program.UpdateVolume();

            string[] lines = File.ReadAllLines(filepath, Encoding.UTF8);
            lines[2] = TrackBarSound.Value.ToString();
            File.WriteAllLines(filepath, lines, Encoding.UTF8);
        }
    }
}
