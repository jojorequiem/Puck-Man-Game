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
    public partial class FrmClassement : FormComponent
    {
        public FrmClassement()
        {
            InitializeComponent();

        }
        private void btnRetour_Click(object sender, EventArgs e)
        {
            if (Program.FrmMenu == null)
                Program.FrmMenu = new FrmMenu();
            Program.ChangeActiveForm(Program.FrmMenu, this);
        }
    }
}