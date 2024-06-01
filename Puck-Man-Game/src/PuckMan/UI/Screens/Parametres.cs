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

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    public partial class Parametres : FormComponent
    {
        public Parametres()
        {
            InitializeComponent();
            LblMainValue.Text = Program.VolumePrincipale.ToString();
            TrackBarMain.Value = Program.VolumePrincipale;
            LblMusicValue.Text = Program.VolumeMusique.ToString();
            TrackBarMusic.Value = Program.VolumeMusique;
            LblSoundValue.Text = Program.VolumeSon.ToString();
            TrackBarSound.Value = Program.VolumeSon;
        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            DisplayForm(new Menu(), this);
        }

        private void TrackBarMain_ValueChanged(object sender, EventArgs e)
        {
            Program.VolumePrincipale = TrackBarMain.Value;
            LblMainValue.Text = TrackBarMain.Value.ToString();
            Program.UpdateVolume();
        }

        private void TrackBarMusic_ValueChanged(object sender, EventArgs e)
        {
            Program.VolumeMusique = TrackBarMusic.Value;
            LblMusicValue.Text = TrackBarMusic.Value.ToString();
            Program.UpdateVolume();
        }

        private void TrackBarSound_ValueChanged(object sender, EventArgs e)
        {
            Program.VolumeSon = TrackBarSound.Value;
            LblSoundValue.Text = TrackBarSound.Value.ToString();
            Program.UpdateVolume();
        }
    }
}
