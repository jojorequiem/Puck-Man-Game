namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    partial class FrmPlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlay));
            this.BtnNouvellePartie = new System.Windows.Forms.Button();
            this.BtnRetour = new System.Windows.Forms.Button();
            this.BtnReprendreSauvegarde = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnNouvellePartie
            // 
            this.BtnNouvellePartie.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNouvellePartie.ForeColor = System.Drawing.Color.Black;
            this.BtnNouvellePartie.Location = new System.Drawing.Point(91, 161);
            this.BtnNouvellePartie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnNouvellePartie.Name = "BtnNouvellePartie";
            this.BtnNouvellePartie.Size = new System.Drawing.Size(700, 69);
            this.BtnNouvellePartie.TabIndex = 12;
            this.BtnNouvellePartie.Text = "NOUVELLE PARTIE";
            this.BtnNouvellePartie.UseVisualStyleBackColor = true;
            this.BtnNouvellePartie.Click += new System.EventHandler(this.BtnNouvellePartie_Click);
            // 
            // BtnRetour
            // 
            this.BtnRetour.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRetour.ForeColor = System.Drawing.Color.Black;
            this.BtnRetour.Location = new System.Drawing.Point(91, 373);
            this.BtnRetour.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnRetour.Name = "BtnRetour";
            this.BtnRetour.Size = new System.Drawing.Size(700, 69);
            this.BtnRetour.TabIndex = 13;
            this.BtnRetour.Text = "RETOUR";
            this.BtnRetour.UseVisualStyleBackColor = true;
            this.BtnRetour.Click += new System.EventHandler(this.BtnRetour_Click);
            // 
            // BtnReprendreSauvegarde
            // 
            this.BtnReprendreSauvegarde.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReprendreSauvegarde.ForeColor = System.Drawing.Color.Black;
            this.BtnReprendreSauvegarde.Location = new System.Drawing.Point(91, 267);
            this.BtnReprendreSauvegarde.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnReprendreSauvegarde.Name = "BtnReprendreSauvegarde";
            this.BtnReprendreSauvegarde.Size = new System.Drawing.Size(700, 69);
            this.BtnReprendreSauvegarde.TabIndex = 14;
            this.BtnReprendreSauvegarde.Text = "REPRENDRE PARTIE";
            this.BtnReprendreSauvegarde.UseVisualStyleBackColor = true;
            this.BtnReprendreSauvegarde.Click += new System.EventHandler(this.BtnReprendreSauvegarde_Click);
            // 
            // FrmPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(883, 604);
            this.Controls.Add(this.BtnReprendreSauvegarde);
            this.Controls.Add(this.BtnRetour);
            this.Controls.Add(this.BtnNouvellePartie);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(901, 651);
            this.MinimumSize = new System.Drawing.Size(899, 649);
            this.Name = "FrmPlay";
            this.Text = "FrmPlay";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnNouvellePartie;
        private System.Windows.Forms.Button BtnRetour;
        private System.Windows.Forms.Button BtnReprendreSauvegarde;
    }
} 