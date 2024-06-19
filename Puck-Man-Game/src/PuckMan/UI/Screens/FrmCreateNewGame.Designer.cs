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
            this.button1 = new System.Windows.Forms.Button();
            this.BtnRetour = new System.Windows.Forms.Button();
            this.BtnNouvellePartie = new System.Windows.Forms.Button();
            this.GrpPartie = new System.Windows.Forms.GroupBox();
            this.LblAlertPartie = new System.Windows.Forms.Label();
            this.ChkDifficulteNormal = new System.Windows.Forms.CheckBox();
            this.ChkDifficulteDifficile = new System.Windows.Forms.CheckBox();
            this.ChkDifficulteFacile = new System.Windows.Forms.CheckBox();
            this.LblChoixDifficulte = new System.Windows.Forms.Label();
            this.lblTitreMenuPrincipal = new System.Windows.Forms.Label();
            this.GrpPartie.SuspendLayout();
            this.SuspendLayout();
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
            // BtnNouvellePartie
            // 
            this.BtnNouvellePartie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.13913F);
            this.BtnNouvellePartie.Location = new System.Drawing.Point(27, 478);
            this.BtnNouvellePartie.Name = "BtnNouvellePartie";
            this.BtnNouvellePartie.Size = new System.Drawing.Size(558, 53);
            this.BtnNouvellePartie.TabIndex = 2;
            this.BtnNouvellePartie.Text = "NOUVELLE PARTIE";
            this.BtnNouvellePartie.UseVisualStyleBackColor = true;
            this.BtnNouvellePartie.Click += new System.EventHandler(this.BtnSauvegarder_Click);
            // 
            // GrpPartie
            // 
            this.GrpPartie.Controls.Add(this.LblAlertPartie);
            this.GrpPartie.Controls.Add(this.ChkDifficulteNormal);
            this.GrpPartie.Controls.Add(this.ChkDifficulteDifficile);
            this.GrpPartie.Controls.Add(this.ChkDifficulteFacile);
            this.GrpPartie.Controls.Add(this.LblChoixDifficulte);
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
            this.ChkDifficulteNormal.BackColor = System.Drawing.Color.Transparent;
            this.ChkDifficulteNormal.Checked = true;
            this.ChkDifficulteNormal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkDifficulteNormal.Font = new System.Drawing.Font("Minecraft", 13.77391F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkDifficulteNormal.Location = new System.Drawing.Point(452, 111);
            this.ChkDifficulteNormal.Name = "ChkDifficulteNormal";
            this.ChkDifficulteNormal.Size = new System.Drawing.Size(112, 27);
            this.ChkDifficulteNormal.TabIndex = 6;
            this.ChkDifficulteNormal.Text = "Normal";
            this.ChkDifficulteNormal.UseVisualStyleBackColor = false;
            this.ChkDifficulteNormal.CheckedChanged += new System.EventHandler(this.ChkDifficulteNormal_CheckedChanged);
            // 
            // ChkDifficulteDifficile
            // 
            this.ChkDifficulteDifficile.AutoSize = true;
            this.ChkDifficulteDifficile.BackColor = System.Drawing.Color.Transparent;
            this.ChkDifficulteDifficile.Font = new System.Drawing.Font("Minecraft", 13.77391F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkDifficulteDifficile.Location = new System.Drawing.Point(626, 111);
            this.ChkDifficulteDifficile.Name = "ChkDifficulteDifficile";
            this.ChkDifficulteDifficile.Size = new System.Drawing.Size(119, 27);
            this.ChkDifficulteDifficile.TabIndex = 5;
            this.ChkDifficulteDifficile.Text = "Difficile";
            this.ChkDifficulteDifficile.UseVisualStyleBackColor = false;
            this.ChkDifficulteDifficile.CheckedChanged += new System.EventHandler(this.ChkDifficulteDifficile_CheckedChanged);
            // 
            // ChkDifficulteFacile
            // 
            this.ChkDifficulteFacile.AutoSize = true;
            this.ChkDifficulteFacile.BackColor = System.Drawing.Color.Transparent;
            this.ChkDifficulteFacile.Font = new System.Drawing.Font("Minecraft", 13.77391F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkDifficulteFacile.Location = new System.Drawing.Point(287, 111);
            this.ChkDifficulteFacile.Name = "ChkDifficulteFacile";
            this.ChkDifficulteFacile.Size = new System.Drawing.Size(97, 27);
            this.ChkDifficulteFacile.TabIndex = 4;
            this.ChkDifficulteFacile.Text = "Facile";
            this.ChkDifficulteFacile.UseVisualStyleBackColor = false;
            this.ChkDifficulteFacile.CheckedChanged += new System.EventHandler(this.ChkDifficulteFacile_CheckedChanged);
            // 
            // LblChoixDifficulte
            // 
            this.LblChoixDifficulte.AutoSize = true;
            this.LblChoixDifficulte.Font = new System.Drawing.Font("Minecraft", 13.77391F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblChoixDifficulte.Location = new System.Drawing.Point(17, 112);
            this.LblChoixDifficulte.Name = "LblChoixDifficulte";
            this.LblChoixDifficulte.Size = new System.Drawing.Size(241, 23);
            this.LblChoixDifficulte.TabIndex = 3;
            this.LblChoixDifficulte.Text = "CHOIX DIFFICULTE";
            // 
            // lblTitreMenuPrincipal
            // 
            this.lblTitreMenuPrincipal.BackColor = System.Drawing.Color.Black;
            this.lblTitreMenuPrincipal.Font = new System.Drawing.Font("Minecraft", 48.20869F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitreMenuPrincipal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitreMenuPrincipal.Location = new System.Drawing.Point(91, 43);
            this.lblTitreMenuPrincipal.Name = "lblTitreMenuPrincipal";
            this.lblTitreMenuPrincipal.Size = new System.Drawing.Size(700, 88);
            this.lblTitreMenuPrincipal.TabIndex = 12;
            this.lblTitreMenuPrincipal.Text = "MODE INFINI";
            this.lblTitreMenuPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmCreateNewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(882, 605);
            this.Controls.Add(this.lblTitreMenuPrincipal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnRetour);
            this.Controls.Add(this.BtnNouvellePartie);
            this.Controls.Add(this.GrpPartie);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(900, 650);
            this.MinimumSize = new System.Drawing.Size(899, 649);
            this.Name = "FrmCreateNewGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNewGame";
            this.GrpPartie.ResumeLayout(false);
            this.GrpPartie.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox GrpPartie;
        private System.Windows.Forms.Button BtnNouvellePartie;
        private System.Windows.Forms.Button BtnRetour;
        private System.Windows.Forms.CheckBox ChkDifficulteNormal;
        private System.Windows.Forms.CheckBox ChkDifficulteDifficile;
        private System.Windows.Forms.CheckBox ChkDifficulteFacile;
        private System.Windows.Forms.Label LblChoixDifficulte;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LblAlertPartie;
        private System.Windows.Forms.Label lblTitreMenuPrincipal;
    }
}