﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            FormParent = formParent;
        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {
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
            Program.ChangeActiveForm(FormParent, this);
        }
    }
}