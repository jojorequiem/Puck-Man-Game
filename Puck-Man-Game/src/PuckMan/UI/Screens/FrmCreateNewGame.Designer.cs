﻿namespace Puck_Man_Game.src.PuckMan.UI.Screens
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
            this.BtnRetour = new System.Windows.Forms.Button();
            this.BtnNouvellePartie = new System.Windows.Forms.Button();
            this.GrpPartie = new System.Windows.Forms.GroupBox();
            this.LblAlertPseudo = new System.Windows.Forms.Label();
            this.TxtBoxPseudo = new System.Windows.Forms.TextBox();
            this.LblAlertPartie = new System.Windows.Forms.Label();
            this.ChkDifficulteNormal = new System.Windows.Forms.CheckBox();
            this.ChkDifficulteDifficile = new System.Windows.Forms.CheckBox();
            this.ChkDifficulteFacile = new System.Windows.Forms.CheckBox();
            this.LblChoixDifficulte = new System.Windows.Forms.Label();
            this.lblTitreMenuPrincipal = new System.Windows.Forms.Label();
            this.GrpPartie.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnRetour
            // 
            this.BtnRetour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.13913F);
            this.BtnRetour.Location = new System.Drawing.Point(458, 422);
            this.BtnRetour.Name = "BtnRetour";
            this.BtnRetour.Size = new System.Drawing.Size(334, 69);
            this.BtnRetour.TabIndex = 3;
            this.BtnRetour.Text = "RETOUR";
            this.BtnRetour.UseVisualStyleBackColor = true;
            this.BtnRetour.Click += new System.EventHandler(this.BtnRetour_Click);
            // 
            // BtnNouvellePartie
            // 
            this.BtnNouvellePartie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.13913F);
            this.BtnNouvellePartie.Location = new System.Drawing.Point(91, 422);
            this.BtnNouvellePartie.Name = "BtnNouvellePartie";
            this.BtnNouvellePartie.Size = new System.Drawing.Size(334, 69);
            this.BtnNouvellePartie.TabIndex = 2;
            this.BtnNouvellePartie.Text = "NOUVELLE PARTIE";
            this.BtnNouvellePartie.UseVisualStyleBackColor = true;
            this.BtnNouvellePartie.Click += new System.EventHandler(this.BtnSauvegarder_Click);
            // 
            // GrpPartie
            // 
            this.GrpPartie.Controls.Add(this.LblAlertPseudo);
            this.GrpPartie.Controls.Add(this.TxtBoxPseudo);
            this.GrpPartie.Controls.Add(this.LblAlertPartie);
            this.GrpPartie.Controls.Add(this.ChkDifficulteNormal);
            this.GrpPartie.Controls.Add(this.ChkDifficulteDifficile);
            this.GrpPartie.Controls.Add(this.ChkDifficulteFacile);
            this.GrpPartie.Controls.Add(this.LblChoixDifficulte);
            this.GrpPartie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpPartie.Location = new System.Drawing.Point(92, 170);
            this.GrpPartie.Name = "GrpPartie";
            this.GrpPartie.Size = new System.Drawing.Size(700, 234);
            this.GrpPartie.TabIndex = 1;
            this.GrpPartie.TabStop = false;
            this.GrpPartie.Text = "Partie";
            // 
            // LblAlertPseudo
            // 
            this.LblAlertPseudo.AutoSize = true;
            this.LblAlertPseudo.Location = new System.Drawing.Point(19, 95);
            this.LblAlertPseudo.Name = "LblAlertPseudo";
            this.LblAlertPseudo.Size = new System.Drawing.Size(23, 17);
            this.LblAlertPseudo.TabIndex = 11;
            this.LblAlertPseudo.Text = "   ";
            // 
            // TxtBoxPseudo
            // 
            this.TxtBoxPseudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBoxPseudo.Location = new System.Drawing.Point(22, 47);
            this.TxtBoxPseudo.Name = "TxtBoxPseudo";
            this.TxtBoxPseudo.Size = new System.Drawing.Size(372, 32);
            this.TxtBoxPseudo.TabIndex = 10;
            this.TxtBoxPseudo.TextChanged += new System.EventHandler(this.TxtPseudo_TextChanged);
            // 
            // LblAlertPartie
            // 
            this.LblAlertPartie.AutoSize = true;
            this.LblAlertPartie.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.13913F);
            this.LblAlertPartie.ForeColor = System.Drawing.Color.Red;
            this.LblAlertPartie.Location = new System.Drawing.Point(51, 225);
            this.LblAlertPartie.Name = "LblAlertPartie";
            this.LblAlertPartie.Size = new System.Drawing.Size(48, 26);
            this.LblAlertPartie.TabIndex = 9;
            this.LblAlertPartie.Text = "      ";
            // 
            // ChkDifficulteNormal
            // 
            this.ChkDifficulteNormal.AutoSize = true;
            this.ChkDifficulteNormal.BackColor = System.Drawing.Color.Transparent;
            this.ChkDifficulteNormal.Checked = true;
            this.ChkDifficulteNormal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkDifficulteNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.77391F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkDifficulteNormal.Location = new System.Drawing.Point(400, 145);
            this.ChkDifficulteNormal.Name = "ChkDifficulteNormal";
            this.ChkDifficulteNormal.Size = new System.Drawing.Size(120, 33);
            this.ChkDifficulteNormal.TabIndex = 6;
            this.ChkDifficulteNormal.Text = "Normal";
            this.ChkDifficulteNormal.UseVisualStyleBackColor = false;
            this.ChkDifficulteNormal.CheckedChanged += new System.EventHandler(this.ChkDifficulteNormal_CheckedChanged);
            // 
            // ChkDifficulteDifficile
            // 
            this.ChkDifficulteDifficile.AutoSize = true;
            this.ChkDifficulteDifficile.BackColor = System.Drawing.Color.Transparent;
            this.ChkDifficulteDifficile.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.77391F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkDifficulteDifficile.Location = new System.Drawing.Point(535, 145);
            this.ChkDifficulteDifficile.Name = "ChkDifficulteDifficile";
            this.ChkDifficulteDifficile.Size = new System.Drawing.Size(123, 33);
            this.ChkDifficulteDifficile.TabIndex = 5;
            this.ChkDifficulteDifficile.Text = "Difficile";
            this.ChkDifficulteDifficile.UseVisualStyleBackColor = false;
            this.ChkDifficulteDifficile.CheckedChanged += new System.EventHandler(this.ChkDifficulteDifficile_CheckedChanged);
            // 
            // ChkDifficulteFacile
            // 
            this.ChkDifficulteFacile.AutoSize = true;
            this.ChkDifficulteFacile.BackColor = System.Drawing.Color.Transparent;
            this.ChkDifficulteFacile.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.77391F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkDifficulteFacile.Location = new System.Drawing.Point(287, 145);
            this.ChkDifficulteFacile.Name = "ChkDifficulteFacile";
            this.ChkDifficulteFacile.Size = new System.Drawing.Size(107, 33);
            this.ChkDifficulteFacile.TabIndex = 4;
            this.ChkDifficulteFacile.Text = "Facile";
            this.ChkDifficulteFacile.UseVisualStyleBackColor = false;
            this.ChkDifficulteFacile.CheckedChanged += new System.EventHandler(this.ChkDifficulteFacile_CheckedChanged);
            // 
            // LblChoixDifficulte
            // 
            this.LblChoixDifficulte.AutoSize = true;
            this.LblChoixDifficulte.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.77391F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblChoixDifficulte.Location = new System.Drawing.Point(17, 146);
            this.LblChoixDifficulte.Name = "LblChoixDifficulte";
            this.LblChoixDifficulte.Size = new System.Drawing.Size(249, 29);
            this.LblChoixDifficulte.TabIndex = 3;
            this.LblChoixDifficulte.Text = "CHOIX DIFFICULTE";
            // 
            // lblTitreMenuPrincipal
            // 
            this.lblTitreMenuPrincipal.BackColor = System.Drawing.Color.Black;
            this.lblTitreMenuPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 48.20869F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitreMenuPrincipal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitreMenuPrincipal.Location = new System.Drawing.Point(91, 42);
            this.lblTitreMenuPrincipal.Name = "lblTitreMenuPrincipal";
            this.lblTitreMenuPrincipal.Size = new System.Drawing.Size(700, 94);
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
            this.ClientSize = new System.Drawing.Size(882, 603);
            this.Controls.Add(this.lblTitreMenuPrincipal);
            this.Controls.Add(this.BtnRetour);
            this.Controls.Add(this.BtnNouvellePartie);
            this.Controls.Add(this.GrpPartie);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
        private System.Windows.Forms.Label LblAlertPartie;
        private System.Windows.Forms.Label lblTitreMenuPrincipal;
        private System.Windows.Forms.TextBox TxtBoxPseudo;
        private System.Windows.Forms.Label LblAlertPseudo;
    }
}