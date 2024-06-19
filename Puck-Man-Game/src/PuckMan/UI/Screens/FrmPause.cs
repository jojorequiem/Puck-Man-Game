using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    public partial class FrmPause : FormComponent
    {
        public Form FormParent;
        public FrmPause(Form formParent)
        {
            InitializeComponent();
            this.KeyPreview = true;
            FormParent = formParent;
        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
                ParentForm.Dispose();
            Program.ChangeActiveForm(Program.FrmMenu, this);
        }

        private void BtnParametres_Click(object sender, EventArgs e)
        {
            if (Program.FrmParametres == null)
                Program.FrmParametres = new FrmParametres(this);
            Program.ChangeActiveForm(Program.FrmParametres, this);
        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            GoBackToPreviousForm();
        }
        
        public void GoBackToPreviousForm()
        {
            Program.ChangeActiveForm(FormParent, this);
        }

        private void FrmPause_KeyUp(object sender, KeyEventArgs e)
        {
            GoBackToPreviousForm();
        }
    }
}
