﻿using Puck_Man_Game.assets.fonts;

namespace Puck_Man_Game.src.PuckMan.UI

{
    partial class FrmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.BtnJouer = new System.Windows.Forms.Button();
            this.LblTitreMenuPrincipal = new System.Windows.Forms.Label();
            this.BtnParametres = new System.Windows.Forms.Button();
            this.BtnQuitter = new System.Windows.Forms.Button();
            this.BtnClassement = new System.Windows.Forms.Button();
            this.BtnAPropos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnJouer
            // 
            this.BtnJouer.BackColor = System.Drawing.Color.White;
            this.BtnJouer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnJouer.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnJouer.ForeColor = System.Drawing.Color.Black;
            this.BtnJouer.Location = new System.Drawing.Point(192, 244);
            this.BtnJouer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnJouer.Name = "BtnJouer";
            this.BtnJouer.Size = new System.Drawing.Size(498, 67);
            this.BtnJouer.TabIndex = 0;
            this.BtnJouer.Text = "JOUER";
            this.BtnJouer.UseVisualStyleBackColor = false;
            this.BtnJouer.Click += new System.EventHandler(this.BtnJouer_Click);
            // 
            // LblTitreMenuPrincipal
            // 
            this.LblTitreMenuPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.LblTitreMenuPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitreMenuPrincipal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LblTitreMenuPrincipal.Location = new System.Drawing.Point(169, 52);
            this.LblTitreMenuPrincipal.Name = "LblTitreMenuPrincipal";
            this.LblTitreMenuPrincipal.Size = new System.Drawing.Size(544, 98);
            this.LblTitreMenuPrincipal.TabIndex = 9;
            this.LblTitreMenuPrincipal.Text = "PUCK-MAN";
            this.LblTitreMenuPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnParametres
            // 
            this.BtnParametres.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnParametres.ForeColor = System.Drawing.Color.Black;
            this.BtnParametres.Location = new System.Drawing.Point(192, 334);
            this.BtnParametres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnParametres.Name = "BtnParametres";
            this.BtnParametres.Size = new System.Drawing.Size(498, 67);
            this.BtnParametres.TabIndex = 1;
            this.BtnParametres.Text = "PARAMETRES";
            this.BtnParametres.UseVisualStyleBackColor = true;
            this.BtnParametres.Click += new System.EventHandler(this.BtnParametres_Click);
            // 
            // BtnQuitter
            // 
            this.BtnQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuitter.Location = new System.Drawing.Point(455, 424);
            this.BtnQuitter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnQuitter.Name = "BtnQuitter";
            this.BtnQuitter.Size = new System.Drawing.Size(235, 67);
            this.BtnQuitter.TabIndex = 3;
            this.BtnQuitter.Text = "QUITTER";
            this.BtnQuitter.UseVisualStyleBackColor = true;
            this.BtnQuitter.Click += new System.EventHandler(this.BtnQuitter_Click);
            // 
            // BtnClassement
            // 
            this.BtnClassement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClassement.Location = new System.Drawing.Point(192, 424);
            this.BtnClassement.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnClassement.Name = "BtnClassement";
            this.BtnClassement.Size = new System.Drawing.Size(236, 67);
            this.BtnClassement.TabIndex = 2;
            this.BtnClassement.Text = "CLASSEMENT";
            this.BtnClassement.UseVisualStyleBackColor = true;
            this.BtnClassement.Click += new System.EventHandler(this.BtnClassement_Click);
            // 
            // BtnAPropos
            // 
            this.BtnAPropos.Location = new System.Drawing.Point(710, 449);
            this.BtnAPropos.Name = "BtnAPropos";
            this.BtnAPropos.Size = new System.Drawing.Size(42, 42);
            this.BtnAPropos.TabIndex = 4;
            this.BtnAPropos.Text = "?";
            this.BtnAPropos.UseVisualStyleBackColor = true;
            this.BtnAPropos.Click += new System.EventHandler(this.BtnAPropos_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(882, 603);
            this.Controls.Add(this.BtnAPropos);
            this.Controls.Add(this.LblTitreMenuPrincipal);
            this.Controls.Add(this.BtnClassement);
            this.Controls.Add(this.BtnQuitter);
            this.Controls.Add(this.BtnParametres);
            this.Controls.Add(this.BtnJouer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(900, 650);
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puck-Man";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnJouer;
        private System.Windows.Forms.Label LblTitreMenuPrincipal;
        private System.Windows.Forms.Button BtnParametres;
        private System.Windows.Forms.Button BtnQuitter;
        private System.Windows.Forms.Button BtnClassement;
        private System.Windows.Forms.Button BtnAPropos;
    }
}