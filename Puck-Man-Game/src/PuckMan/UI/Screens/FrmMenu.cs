using Puck_Man_Game.src.PuckMan.UI.Screens;
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

namespace Puck_Man_Game.src.PuckMan.UI
{
    public partial class FrmMenu : FormComponent
    {
        public FrmMenu() : base()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.background;
        }

        private void BtnParametres_Click(object sender, EventArgs e)
        {
            if (Program.FrmParametres == null)
                Program.FrmParametres = new FrmParametres(this);
            Program.ChangeActiveForm(Program.FrmParametres, this);
        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnJouer_Click(object sender, EventArgs e)
        {
            if (Program.FrmPlay == null)
                Program.FrmPlay = new FrmPlay();
            Program.ChangeActiveForm(Program.FrmPlay, this);
        }

        private void BtnAPropos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Puck-Man est un projet de fin d'année développé par des étudiants en informatique à l'IUT d'Amiens (UPJV 2024). Il a été réalisé en utilisant WinForms en C#. Les membres de l'équipe sont Jonathan Le, Paul Maillard, Attoumani Rafed, Benziane Zakarya, et Zhou Loïc.\n\nNous vous remerçions d'avoir lancé Puck-Man.", "A propos");
        }

        private void BtnClassement_Click(object sender, EventArgs e)
        {
            if (Program.FrmClassement == null)
                Program.FrmClassement = new FrmClassement();
            Program.ChangeActiveForm(Program.FrmClassement, this);
        }

        private void PcbTitle_Click(object sender, EventArgs e)
        {

        }
    }
}