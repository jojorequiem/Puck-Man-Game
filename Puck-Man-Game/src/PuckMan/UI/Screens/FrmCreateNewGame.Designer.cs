namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    partial class FrmCreateNewGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCreateNewGame));
            this.GrpPseudo = new System.Windows.Forms.GroupBox();
            this.LblAlertPseudo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtPseudo = new System.Windows.Forms.TextBox();
            this.GrpPartie = new System.Windows.Forms.GroupBox();
            this.LblAlertPartie = new System.Windows.Forms.Label();
            this.ChkDifficulteNormal = new System.Windows.Forms.CheckBox();
            this.ChkDifficulteDifficile = new System.Windows.Forms.CheckBox();
            this.ChkDifficulteFacile = new System.Windows.Forms.CheckBox();
            this.LblChoixDifficulte = new System.Windows.Forms.Label();
            this.LblChoixMode = new System.Windows.Forms.Label();
            this.ChkModeInfini = new System.Windows.Forms.CheckBox();
            this.ChkModeHistoire = new System.Windows.Forms.CheckBox();
            this.BtnSauvegarder = new System.Windows.Forms.Button();
            this.BtnRetour = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.GrpPseudo.SuspendLayout();
            this.GrpPartie.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpPseudo
            // 
            this.GrpPseudo.Controls.Add(this.LblAlertPseudo);
            this.GrpPseudo.Controls.Add(this.label1);
            this.GrpPseudo.Controls.Add(this.TxtPseudo);
            this.GrpPseudo.Location = new System.Drawing.Point(27, 24);
            this.GrpPseudo.Name = "GrpPseudo";
            this.GrpPseudo.Size = new System.Drawing.Size(385, 115);
            this.GrpPseudo.TabIndex = 0;
            this.GrpPseudo.TabStop = false;
            this.GrpPseudo.Text = "Pseudo";
            // 
            // LblAlertPseudo
            // 
            this.LblAlertPseudo.AutoSize = true;
            this.LblAlertPseudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.13913F);
            this.LblAlertPseudo.Location = new System.Drawing.Point(6, 85);
            this.LblAlertPseudo.Name = "LblAlertPseudo";
            this.LblAlertPseudo.Size = new System.Drawing.Size(39, 20);
            this.LblAlertPseudo.TabIndex = 8;
            this.LblAlertPseudo.Text = "      ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 7;
            // 
            // TxtPseudo
            // 
            this.TxtPseudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.13913F);
            this.TxtPseudo.Location = new System.Drawing.Point(15, 44);
            this.TxtPseudo.Name = "TxtPseudo";
            this.TxtPseudo.Size = new System.Drawing.Size(350, 29);
            this.TxtPseudo.TabIndex = 0;
            this.TxtPseudo.TextChanged += new System.EventHandler(this.TxtPseudo_TextChanged);
            // 
            // GrpPartie
            // 
            this.GrpPartie.Controls.Add(this.LblAlertPartie);
            this.GrpPartie.Controls.Add(this.ChkDifficulteNormal);
            this.GrpPartie.Controls.Add(this.ChkDifficulteDifficile);
            this.GrpPartie.Controls.Add(this.ChkDifficulteFacile);
            this.GrpPartie.Controls.Add(this.LblChoixDifficulte);
            this.GrpPartie.Controls.Add(this.LblChoixMode);
            this.GrpPartie.Controls.Add(this.ChkModeInfini);
            this.GrpPartie.Controls.Add(this.ChkModeHistoire);
            this.GrpPartie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpPartie.Location = new System.Drawing.Point(27, 171);
            this.GrpPartie.Name = "GrpPartie";
            this.GrpPartie.Size = new System.Drawing.Size(822, 266);
            this.GrpPartie.TabIndex = 1;
            this.GrpPartie.TabStop = false;
            this.GrpPartie.Text = "Partie";
            // 
            // LblAlertPartie
            // 
            this.LblAlertPartie.AutoSize = true;
            this.LblAlertPartie.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.13913F);
            this.LblAlertPartie.ForeColor = System.Drawing.Color.Red;
            this.LblAlertPartie.Location = new System.Drawing.Point(51, 225);
            this.LblAlertPartie.Name = "LblAlertPartie";
            this.LblAlertPartie.Size = new System.Drawing.Size(48, 25);
            this.LblAlertPartie.TabIndex = 9;
            this.LblAlertPartie.Text = "      ";
            // 
            // ChkDifficulteNormal
            // 
            this.ChkDifficulteNormal.AutoSize = true;
            this.ChkDifficulteNormal.Checked = true;
            this.ChkDifficulteNormal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkDifficulteNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.13913F);
            this.ChkDifficulteNormal.Location = new System.Drawing.Point(450, 159);
            this.ChkDifficulteNormal.Name = "ChkDifficulteNormal";
            this.ChkDifficulteNormal.Size = new System.Drawing.Size(111, 33);
            this.ChkDifficulteNormal.TabIndex = 6;
            this.ChkDifficulteNormal.Text = "Normal";
            this.ChkDifficulteNormal.UseVisualStyleBackColor = true;
            this.ChkDifficulteNormal.CheckedChanged += new System.EventHandler(this.ChkDifficulteNormal_CheckedChanged);
            // 
            // ChkDifficulteDifficile
            // 
            this.ChkDifficulteDifficile.AutoSize = true;
            this.ChkDifficulteDifficile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.13913F);
            this.ChkDifficulteDifficile.Location = new System.Drawing.Point(626, 159);
            this.ChkDifficulteDifficile.Name = "ChkDifficulteDifficile";
            this.ChkDifficulteDifficile.Size = new System.Drawing.Size(115, 33);
            this.ChkDifficulteDifficile.TabIndex = 5;
            this.ChkDifficulteDifficile.Text = "Histoire";
            this.ChkDifficulteDifficile.UseVisualStyleBackColor = true;
            this.ChkDifficulteDifficile.CheckedChanged += new System.EventHandler(this.ChkDifficulteDifficile_CheckedChanged);
            // 
            // ChkDifficulteFacile
            // 
            this.ChkDifficulteFacile.AutoSize = true;
            this.ChkDifficulteFacile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.13913F);
            this.ChkDifficulteFacile.Location = new System.Drawing.Point(287, 159);
            this.ChkDifficulteFacile.Name = "ChkDifficulteFacile";
            this.ChkDifficulteFacile.Size = new System.Drawing.Size(98, 33);
            this.ChkDifficulteFacile.TabIndex = 4;
            this.ChkDifficulteFacile.Text = "Facile";
            this.ChkDifficulteFacile.UseVisualStyleBackColor = true;
            this.ChkDifficulteFacile.CheckedChanged += new System.EventHandler(this.ChkDifficulteFacile_CheckedChanged);
            // 
            // LblChoixDifficulte
            // 
            this.LblChoixDifficulte.AutoSize = true;
            this.LblChoixDifficulte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.13913F);
            this.LblChoixDifficulte.Location = new System.Drawing.Point(50, 159);
            this.LblChoixDifficulte.Name = "LblChoixDifficulte";
            this.LblChoixDifficulte.Size = new System.Drawing.Size(169, 29);
            this.LblChoixDifficulte.TabIndex = 3;
            this.LblChoixDifficulte.Text = "Choix difficulté";
            // 
            // LblChoixMode
            // 
            this.LblChoixMode.AutoSize = true;
            this.LblChoixMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.13913F);
            this.LblChoixMode.Location = new System.Drawing.Point(50, 49);
            this.LblChoixMode.Name = "LblChoixMode";
            this.LblChoixMode.Size = new System.Drawing.Size(175, 29);
            this.LblChoixMode.TabIndex = 2;
            this.LblChoixMode.Text = "Choix du mode";
            // 
            // ChkModeInfini
            // 
            this.ChkModeInfini.AutoSize = true;
            this.ChkModeInfini.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.13913F);
            this.ChkModeInfini.Location = new System.Drawing.Point(542, 45);
            this.ChkModeInfini.Name = "ChkModeInfini";
            this.ChkModeInfini.Size = new System.Drawing.Size(82, 33);
            this.ChkModeInfini.TabIndex = 1;
            this.ChkModeInfini.Text = "Infini";
            this.ChkModeInfini.UseVisualStyleBackColor = true;
            this.ChkModeInfini.CheckedChanged += new System.EventHandler(this.ChkModeInfini_CheckedChanged);
            // 
            // ChkModeHistoire
            // 
            this.ChkModeHistoire.AutoSize = true;
            this.ChkModeHistoire.Checked = true;
            this.ChkModeHistoire.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkModeHistoire.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.13913F);
            this.ChkModeHistoire.Location = new System.Drawing.Point(339, 45);
            this.ChkModeHistoire.Name = "ChkModeHistoire";
            this.ChkModeHistoire.Size = new System.Drawing.Size(115, 33);
            this.ChkModeHistoire.TabIndex = 0;
            this.ChkModeHistoire.Text = "Histoire";
            this.ChkModeHistoire.UseVisualStyleBackColor = true;
            this.ChkModeHistoire.CheckedChanged += new System.EventHandler(this.ChkModeHistoire_CheckedChanged);
            // 
            // BtnSauvegarder
            // 
            this.BtnSauvegarder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.13913F);
            this.BtnSauvegarder.Location = new System.Drawing.Point(27, 478);
            this.BtnSauvegarder.Name = "BtnSauvegarder";
            this.BtnSauvegarder.Size = new System.Drawing.Size(558, 53);
            this.BtnSauvegarder.TabIndex = 2;
            this.BtnSauvegarder.Text = "CREER UNE PARTIE";
            this.BtnSauvegarder.UseVisualStyleBackColor = true;
            this.BtnSauvegarder.Click += new System.EventHandler(this.BtnSauvegarder_Click);
            // 
            // BtnRetour
            // 
            this.BtnRetour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.13913F);
            this.BtnRetour.Location = new System.Drawing.Point(608, 478);
            this.BtnRetour.Name = "BtnRetour";
            this.BtnRetour.Size = new System.Drawing.Size(241, 53);
            this.BtnRetour.TabIndex = 3;
            this.BtnRetour.Text = "RETOUR";
            this.BtnRetour.UseVisualStyleBackColor = true;
            this.BtnRetour.Click += new System.EventHandler(this.BtnRetour_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.13913F);
            this.button1.Location = new System.Drawing.Point(811, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FrmCreateNewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(882, 605);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnRetour);
            this.Controls.Add(this.BtnSauvegarder);
            this.Controls.Add(this.GrpPartie);
            this.Controls.Add(this.GrpPseudo);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(900, 650);
            this.MinimumSize = new System.Drawing.Size(899, 649);
            this.Name = "FrmCreateNewGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNewGame";
            this.GrpPseudo.ResumeLayout(false);
            this.GrpPseudo.PerformLayout();
            this.GrpPartie.ResumeLayout(false);
            this.GrpPartie.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpPseudo;
        private System.Windows.Forms.TextBox TxtPseudo;
        private System.Windows.Forms.GroupBox GrpPartie;
        private System.Windows.Forms.Button BtnSauvegarder;
        private System.Windows.Forms.Button BtnRetour;
        private System.Windows.Forms.CheckBox ChkDifficulteNormal;
        private System.Windows.Forms.CheckBox ChkDifficulteDifficile;
        private System.Windows.Forms.CheckBox ChkDifficulteFacile;
        private System.Windows.Forms.Label LblChoixDifficulte;
        private System.Windows.Forms.Label LblChoixMode;
        private System.Windows.Forms.CheckBox ChkModeInfini;
        private System.Windows.Forms.CheckBox ChkModeHistoire;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblAlertPseudo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LblAlertPartie;
    }
}