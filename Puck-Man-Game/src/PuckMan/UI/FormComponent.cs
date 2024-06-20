using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    /// <summary>
    /// Classe de base pour toutes les fenêtres du jeu.
    /// </summary>
    public class FormComponent : Form
    {
        // HashSet pour les noms des labels exclus
        private readonly HashSet<string> excludedLabels = new HashSet<string> { "LblChoixDifficulte" };

        /// <summary>
        /// Constructeur de la classe FormComponent.
        /// Initialise les propriétés communes à toutes les fenêtres du jeu.
        /// </summary>
        public FormComponent()
        {
            AutoScaleMode = AutoScaleMode.None; // Désactive le redimensionnement automatique des contrôles
            this.Load += FormComponent_Load; // Associe l'événement Load à la méthode FormComponent_Load
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormComponent_FormClosing); // Associe l'événement FormClosing à la méthode FormComponent_FormClosing
        }

        /// <summary>
        /// Événement déclenché lors du chargement de la fenêtre.
        /// Configure l'apparence et les propriétés communes à toutes les fenêtres du jeu.
        /// </summary>
        private void FormComponent_Load(object sender, EventArgs e)
        {
            AutoScaleMode = AutoScaleMode.None; // Désactive le redimensionnement automatique des contrôles

            ChangeAllTextColors(this); // Applique les couleurs de texte et d'arrière-plan à tous les contrôles enfants
            this.Icon = Puck_Man_Game.Properties.Resources.iconGame; // Définit l'icône de la fenêtre à partir des ressources de l'application
            this.MaximizeBox = false; // Désactive le bouton de maximisation de la fenêtre

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle; // Définit le style de bordure de la fenêtre à Fixe
            if (this is FrmNewGame)
            {
                this.BackgroundImage = Puck_Man_Game.Properties.Resources.bgCell3; // Définit l'image de fond spécifique pour FrmNewGame
                this.BackgroundImageLayout = ImageLayout.Tile;
            }
            else
            {
                this.BackgroundImage = Puck_Man_Game.Properties.Resources.laboratoirePuck; // Définit l'image de fond générale pour les autres fenêtres
                this.BackgroundImageLayout = ImageLayout.Stretch; 
            }

            this.MinimumSize = new Size(Program.WindowWidth, Program.WindowHeight); // Définit la taille minimale de la fenêtre
            this.MaximumSize = new Size(Program.WindowWidth, Program.WindowHeight); // Définit la taille maximale de la fenêtre
            this.ClientSize = new Size(Program.WindowWidth, Program.WindowHeight); // Définit la taille client de la fenêtre
        }

        /// <summary>
        /// Change les couleurs du texte et de l'arrière-plan pour tous les contrôles enfants du contrôle parent spécifié.
        /// </summary>
        private void ChangeAllTextColors(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Label || control is TextBox || control is CheckBox || control is RadioButton)
                {
                    control.ForeColor = Program.TextColor; // Définit la couleur du texte
                    control.BackColor = Program.BackgroundColor; // Définit la couleur d'arrière-plan
                }

                if (control is CheckBox)
                    control.Click += MyCheckBox_Click; // Associe l'événement Click des cases à cocher à la méthode MyCheckBox_Click

                if (control is GroupBox)
                {
                    control.BackColor = Color.Transparent; // Rend le fond du GroupBox transparent
                    control.ForeColor = Color.White; // Définit la couleur du texte à blanc
                }

                if (control is Label)
                    control.BackColor = Color.Transparent; // Rend le fond du Label transparent

                if (control is CheckBox)
                    control.BackColor = Color.Transparent; // Rend le fond des cases à cocher transparent

                if (control is Button button)
                {
                    button.Font = new System.Drawing.Font("Minecraft", 12, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Définit la police du bouton
                    button.Font = new Font(control.Font.FontFamily, 16); 
                    button.MouseEnter += MyButton_MouseEnter;
                    button.MouseLeave += MyButton_MouseLeave;
                    button.GotFocus += MyButton_GotFocus;
                    button.LostFocus += MyButton_LostFocus;
                    button.Click += MyButton_Click; 
                    button.ForeColor = Program.TextColor;
                    button.BackColor = Color.Transparent; 
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.MouseDownBackColor = Color.Black; // Définit la couleur de fond lorsqu'on appuie sur le bouton
                    button.FlatAppearance.MouseOverBackColor = Color.Black; // Définit la couleur de fond lors du survol du bouton
                }

                if (control.HasChildren)
                    ChangeAllTextColors(control); // Répète le processus pour tous les contrôles enfants récursivement
            }
        }

        /// <summary>
        /// Événement déclenché lors du survol de la souris sur un bouton.
        /// Change les couleurs du bouton lors du survol.
        /// </summary>
        private void MyButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.Black; 
                button.ForeColor = Program.TextColor; 
            }
        }

        /// <summary>
        /// Événement déclenché lorsque la souris quitte un bouton.
        /// Restaure les couleurs initiales du bouton.
        /// </summary>
        private void MyButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.Transparent;
                button.ForeColor = Program.TextColor; 
            }
        }

        /// <summary>
        /// Événement déclenché lorsqu'un bouton obtient le focus.
        /// Change les couleurs du bouton lorsqu'il est en focus.
        /// </summary>
        private void MyButton_GotFocus(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.BackColor = Color.Black;
                button.ForeColor = Color.White;
            }
        }

        /// <summary>
        /// Événement déclenché lorsque le focus est perdu sur un bouton.
        /// Restaure les couleurs initiales du bouton si la souris n'est pas sur le bouton.
        /// </summary>
        private void MyButton_LostFocus(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null && !button.ClientRectangle.Contains(button.PointToClient(Control.MousePosition)))
            {
                button.BackColor = Color.Transparent;
                button.ForeColor = Program.TextColor; 
            }
        }

        /// <summary>
        /// Événement déclenché lors du clic sur un bouton.
        /// Joue un son et ajuste les couleurs du bouton.
        /// </summary>
        private void MyButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.BackColor = Color.Transparent; 
                button.ForeColor = Program.TextColor; 
            }
            Program.PlaySound("assets/audio/Click.wav"); // Joue un son lors du clic sur le bouton
        }

        /// <summary>
        /// Événement déclenché lors du clic sur une case à cocher.
        /// Joue un son.
        /// </summary>
        private void MyCheckBox_Click(object sender, EventArgs e)
        {
            Program.PlaySound("assets/audio/Click.wav"); // Joue un son lors du clic sur la case à cocher
        }

        static private bool isClosed = false;

        /// <summary>
        /// Événement déclenché lors de la fermeture de la fenêtre.
        /// Demande à l'utilisateur s'il souhaite vraiment quitter le jeu.
        /// </summary>
        public void FormComponent_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isClosed) return; // Vérifie si la fenêtre est déjà en cours de fermeture
            // Affiche une boîte de dialogue demandant confirmation pour quitter le jeu
            if (MessageBox.Show("Voulez-vous vraiment quitter ?", "Message Puck-Man", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true; // Annule la fermeture de la fenêtre si l'utilisateur choisit Non
            else
            {
                isClosed = true; 
                Application.Exit(); 
            }
        }

        /// <summary>
        /// Initialise les composants de la fenêtre.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(950, 600); 
            this.Name = "FormComponent"; 
            this.ResumeLayout(false);
        }
    }
}
