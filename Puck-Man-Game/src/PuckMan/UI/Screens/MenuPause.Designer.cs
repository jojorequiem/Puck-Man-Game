namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    partial class MenuPause
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
            this.LblTitrePause = new System.Windows.Forms.Label();
            this.BtnRetour = new System.Windows.Forms.Button();
            this.BtnParametres = new System.Windows.Forms.Button();
            this.BtnQuitter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblTitrePause
            // 
            this.LblTitrePause.BackColor = System.Drawing.Color.Black;
            this.LblTitrePause.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitrePause.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LblTitrePause.Location = new System.Drawing.Point(99, 42);
            this.LblTitrePause.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblTitrePause.Name = "LblTitrePause";
            this.LblTitrePause.Size = new System.Drawing.Size(700, 94);
            this.LblTitrePause.TabIndex = 10;
            this.LblTitrePause.Text = "PAUSE";
            this.LblTitrePause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnRetour
            // 
            this.BtnRetour.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRetour.ForeColor = System.Drawing.Color.Black;
            this.BtnRetour.Location = new System.Drawing.Point(99, 204);
            this.BtnRetour.Margin = new System.Windows.Forms.Padding(2);
            this.BtnRetour.Name = "BtnRetour";
            this.BtnRetour.Size = new System.Drawing.Size(700, 69);
            this.BtnRetour.TabIndex = 11;
            this.BtnRetour.Text = "RETOUR";
            this.BtnRetour.UseVisualStyleBackColor = true;
            this.BtnRetour.Click += new System.EventHandler(this.BtnRetour_Click);
            // 
            // BtnParametres
            // 
            this.BtnParametres.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnParametres.ForeColor = System.Drawing.Color.Black;
            this.BtnParametres.Location = new System.Drawing.Point(99, 313);
            this.BtnParametres.Margin = new System.Windows.Forms.Padding(2);
            this.BtnParametres.Name = "BtnParametres";
            this.BtnParametres.Size = new System.Drawing.Size(700, 69);
            this.BtnParametres.TabIndex = 12;
            this.BtnParametres.Text = "PARAMÈTRES";
            this.BtnParametres.UseVisualStyleBackColor = true;
            this.BtnParametres.Click += new System.EventHandler(this.BtnParametres_Click);
            // 
            // BtnQuitter
            // 
            this.BtnQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuitter.ForeColor = System.Drawing.Color.Black;
            this.BtnQuitter.Location = new System.Drawing.Point(99, 422);
            this.BtnQuitter.Margin = new System.Windows.Forms.Padding(2);
            this.BtnQuitter.Name = "BtnQuitter";
            this.BtnQuitter.Size = new System.Drawing.Size(700, 69);
            this.BtnQuitter.TabIndex = 13;
            this.BtnQuitter.Text = "QUITTER";
            this.BtnQuitter.UseVisualStyleBackColor = true;
            this.BtnQuitter.Click += new System.EventHandler(this.BtnQuitter_Click);
            // 
            // MenuPause
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 560);
            this.Controls.Add(this.BtnQuitter);
            this.Controls.Add(this.BtnParametres);
            this.Controls.Add(this.BtnRetour);
            this.Controls.Add(this.LblTitrePause);
            this.MaximumSize = new System.Drawing.Size(901, 601);
            this.MinimumSize = new System.Drawing.Size(899, 599);
            this.Name = "MenuPause";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuPause";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitrePause;
        private System.Windows.Forms.Button BtnRetour;
        private System.Windows.Forms.Button BtnParametres;
        private System.Windows.Forms.Button BtnQuitter;
    }
}