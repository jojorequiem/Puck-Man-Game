using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    public partial class FrmDeath : FormComponent
    {
        public FrmDeath(string pseudo)
        {
            InitializeComponent();
            LblValeurScore.Text = Program.scoreJoueur.ToString();

            Program.PlayMusic("assets/audio/musiqueMort.mp3");

            string filepath = "src/database/classement.txt";
            string[] lines = File.ReadAllLines(filepath, Encoding.UTF8);

            Debug.WriteLine("pseudo : " + pseudo);
            Debug.WriteLine("score : " + Program.scoreJoueur);
            Debug.WriteLine("lignes : ");
            foreach (string line in lines)
                Debug.WriteLine(line);

            if (lines.Length > 0)
                lines[lines.Length - 1] += "\n" + pseudo + ";" + Program.scoreJoueur.ToString();
            else
                lines = new string[] { pseudo + ";" + Program.scoreJoueur.ToString()};

            Debug.WriteLine("lignes corrigées : ");
            foreach (string line in lines)
                Debug.WriteLine(line);

            File.WriteAllLines(filepath, lines, Encoding.UTF8);
        }

        private void BtnNouvellePartie_Click(object sender, EventArgs e)
        {
            if (Program.FrmCreateNewGame == null)
                Program.FrmCreateNewGame = new FrmCreateNewGame();
            Program.ChangeActiveForm(Program.FrmCreateNewGame, this);
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            if (Program.FrmMenu == null)
                Program.FrmMenu = new FrmMenu();
            Program.ChangeActiveForm(Program.FrmMenu, this);
        }
    }
}
