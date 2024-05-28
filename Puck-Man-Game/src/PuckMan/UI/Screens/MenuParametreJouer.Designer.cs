namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    partial class MenuParametreJouer
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
            this.btnNouvellePartie = new System.Windows.Forms.Button();
            this.btnReprendreSauvegarde = new System.Windows.Forms.Button();
            this.btnRetour = new System.Windows.Forms.Button();
            this.lblTitreMenuPrincipal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNouvellePartie
            // 
            this.btnNouvellePartie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnNouvellePartie.Location = new System.Drawing.Point(250, 265);
            this.btnNouvellePartie.Margin = new System.Windows.Forms.Padding(2);
            this.btnNouvellePartie.Name = "btnNouvellePartie";
            this.btnNouvellePartie.Size = new System.Drawing.Size(700, 69);
            this.btnNouvellePartie.TabIndex = 1;
            this.btnNouvellePartie.Text = "NOUVELLE PARTIE";
            this.btnNouvellePartie.UseVisualStyleBackColor = true;
            this.btnNouvellePartie.Click += new System.EventHandler(this.btnNouvellePartie_Click);
            // 
            // btnReprendreSauvegarde
            // 
            this.btnReprendreSauvegarde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnReprendreSauvegarde.Location = new System.Drawing.Point(250, 374);
            this.btnReprendreSauvegarde.Margin = new System.Windows.Forms.Padding(2);
            this.btnReprendreSauvegarde.Name = "btnReprendreSauvegarde";
            this.btnReprendreSauvegarde.Size = new System.Drawing.Size(700, 69);
            this.btnReprendreSauvegarde.TabIndex = 2;
            this.btnReprendreSauvegarde.Text = "REPRENDRE SAUVEGARDE";
            this.btnReprendreSauvegarde.UseVisualStyleBackColor = true;
            // 
            // btnRetour
            // 
            this.btnRetour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnRetour.Location = new System.Drawing.Point(250, 483);
            this.btnRetour.Margin = new System.Windows.Forms.Padding(2);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(700, 69);
            this.btnRetour.TabIndex = 3;
            this.btnRetour.Text = "RETOUR";
            this.btnRetour.UseVisualStyleBackColor = true;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // lblTitreMenuPrincipal
            // 
            this.lblTitreMenuPrincipal.BackColor = System.Drawing.Color.Black;
            this.lblTitreMenuPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitreMenuPrincipal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitreMenuPrincipal.Location = new System.Drawing.Point(250, 104);
            this.lblTitreMenuPrincipal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitreMenuPrincipal.Name = "lblTitreMenuPrincipal";
            this.lblTitreMenuPrincipal.Size = new System.Drawing.Size(700, 94);
            this.lblTitreMenuPrincipal.TabIndex = 10;
            this.lblTitreMenuPrincipal.Text = "Jouer";
            this.lblTitreMenuPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuParametreJouer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.lblTitreMenuPrincipal);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.btnReprendreSauvegarde);
            this.Controls.Add(this.btnNouvellePartie);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "MenuParametreJouer";
            this.Text = "MenuJouer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNouvellePartie;
        private System.Windows.Forms.Button btnReprendreSauvegarde;
        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.Label lblTitreMenuPrincipal;
    }
}