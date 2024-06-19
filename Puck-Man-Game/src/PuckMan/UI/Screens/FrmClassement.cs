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
using System.Diagnostics;

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    public partial class FrmClassement : FormComponent
    {
        public FrmClassement()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmClassement_Load);
        }

        private void FrmClassement_Load(object sender, EventArgs e)
        {
            DisplayClassement();
        }
    
        public void DisplayClassement()
        {
            // Réinitialiser DgvClassement
            DgvClassement.Rows.Clear();
            DgvClassement.Columns.Clear();

            // Afficher les données
            DgvClassement.ColumnCount = 2;
            DgvClassement.Columns[0].Name = "Pseudo";
            DgvClassement.Columns[1].Name = "Score";
            

            string filePath = "src/database/classement.txt";
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    if (line.Contains(";"))
                    {
                        string[] parts = line.Split(';');
                        if (parts.Length == 2)
                            DgvClassement.Rows.Add(parts[0], parts[1]);
                    }
                }
            }
            // Ajuster les colonnes pour remplir l'espace disponible
            DgvClassement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Trier la colonne "Score" en ordre décroissant
            DgvClassement.Sort(DgvClassement.Columns["Score"], ListSortDirection.Descending);
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            if (Program.FrmMenu == null)
                Program.FrmMenu = new FrmMenu();
            Program.ChangeActiveForm(Program.FrmMenu, this);
        }

    }
}
