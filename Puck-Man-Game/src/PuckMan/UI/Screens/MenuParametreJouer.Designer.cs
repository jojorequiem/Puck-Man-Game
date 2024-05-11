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
            this.SuspendLayout();
            // 
            // btnNouvellePartie
            // 
            this.btnNouvellePartie.Location = new System.Drawing.Point(141, 204);
            this.btnNouvellePartie.Name = "btnNouvellePartie";
            this.btnNouvellePartie.Size = new System.Drawing.Size(725, 85);
            this.btnNouvellePartie.TabIndex = 1;
            this.btnNouvellePartie.Text = "NOUVELLE PARTIE";
            this.btnNouvellePartie.UseVisualStyleBackColor = true;
            // 
            // btnReprendreSauvegarde
            // 
            this.btnReprendreSauvegarde.Location = new System.Drawing.Point(141, 318);
            this.btnReprendreSauvegarde.Name = "btnReprendreSauvegarde";
            this.btnReprendreSauvegarde.Size = new System.Drawing.Size(725, 85);
            this.btnReprendreSauvegarde.TabIndex = 2;
            this.btnReprendreSauvegarde.Text = "REPRENDRE SAUVEGARDE";
            this.btnReprendreSauvegarde.UseVisualStyleBackColor = true;
            // 
            // btnRetour
            // 
            this.btnRetour.Location = new System.Drawing.Point(141, 432);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(725, 85);
            this.btnRetour.TabIndex = 3;
            this.btnRetour.Text = "RETOUR";
            this.btnRetour.UseVisualStyleBackColor = true;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // MenuParametreJouer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.btnReprendreSauvegarde);
            this.Controls.Add(this.btnNouvellePartie);
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "MenuParametreJouer";
            this.Text = "MenuJouer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNouvellePartie;
        private System.Windows.Forms.Button btnReprendreSauvegarde;
        private System.Windows.Forms.Button btnRetour;
    }
}