﻿using System;
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
    public partial class FrmJouer : FormComponent
    {
        
        public FrmJouer() : base()
        {
            InitializeComponent();
        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            if (Program.FrmMenu == null)
                Program.FrmMenu = new FrmMenu();
            Program.ChangeActiveForm(Program.FrmMenu, this);
        }

        private void BtnNouvellePartie_Click(object sender, EventArgs e)
        {
            if (Program.FrmModeHistoire == null)
                Program.FrmModeHistoire = new FrmModeHistoire();
            Program.ChangeActiveForm(Program.FrmModeHistoire, this);
        }

        private void BtnModeInfini_Click(object sender, EventArgs e)
        {
            if (Program.FrmNouvellePartie != null)
            {
                //pour éviter de probleme de demander à l'utilisateur s'il veut quitter
                Program.FrmNouvellePartie.FormClosing -= Program.FrmNouvellePartie.FormComponent_FormClosing;
                
                Program.FrmNouvellePartie.Close();
                Program.FrmNouvellePartie.Dispose();
            }
            Program.FrmNouvellePartie = new FrmNouvellePartie(false, 0);
            Program.ChangeActiveForm(Program.FrmNouvellePartie, this);
        }
    }
}
