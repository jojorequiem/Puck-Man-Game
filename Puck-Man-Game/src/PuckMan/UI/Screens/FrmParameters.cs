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
    public partial class FrmParameters : FormComponent
    {
        public FormComponent FormParent;
        static private string filepath = "src/database/AudioParameters.txt";
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

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            Program.ChangeActiveForm(FormParent, this);
        }

        private void TrackBarMain_ValueChanged(object sender, EventArgs e)
        {
            Program.MainVolume = TrackBarMain.Value;
            LblMainValue.Text = TrackBarMain.Value.ToString();
            Program.UpdateVolume();
            
            string[] lines = File.ReadAllLines(filepath, Encoding.UTF8);
            lines[0] = TrackBarMain.Value.ToString();
            File.WriteAllLines(filepath, lines, Encoding.UTF8);
        }

        private void TrackBarMusic_ValueChanged(object sender, EventArgs e)
        {
            Program.MusicVolume = TrackBarMusic.Value;
            LblMusicValue.Text = TrackBarMusic.Value.ToString();
            Program.UpdateVolume();

            string[] lines = File.ReadAllLines(filepath, Encoding.UTF8);
            lines[1] = TrackBarMain.Value.ToString();
            File.WriteAllLines(filepath, lines, Encoding.UTF8);
        }

        private void TrackBarSound_ValueChanged(object sender, EventArgs e)
        {
            Program.SoundVolume = TrackBarSound.Value;
            LblSoundValue.Text = TrackBarSound.Value.ToString();
            Program.UpdateVolume();

            string[] lines = File.ReadAllLines(filepath, Encoding.UTF8);
            lines[2] = TrackBarMain.Value.ToString();
            File.WriteAllLines(filepath, lines, Encoding.UTF8);
        }
    }
}
