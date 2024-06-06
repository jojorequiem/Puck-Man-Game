using Puck_Man_Game.assets.fonts;

namespace Puck_Man_Game.src.PuckMan.UI

{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.BtnJouer = new System.Windows.Forms.Button();
            this.LblTitreMenuPrincipal = new System.Windows.Forms.Label();
            this.BtnParametres = new System.Windows.Forms.Button();
            this.BtnQuitter = new System.Windows.Forms.Button();
            this.BtnCredits = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnJouer
            // 
            this.BtnJouer.BackColor = System.Drawing.Color.Transparent;
            this.BtnJouer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnJouer.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnJouer.ForeColor = System.Drawing.Color.Black;
            this.BtnJouer.Location = new System.Drawing.Point(99, 204);
            this.BtnJouer.Margin = new System.Windows.Forms.Padding(2);
            this.BtnJouer.Name = "BtnJouer";
            this.BtnJouer.Size = new System.Drawing.Size(700, 69);
            this.BtnJouer.TabIndex = 0;
            this.BtnJouer.Text = "JOUER";
            this.BtnJouer.UseVisualStyleBackColor = false;
            this.BtnJouer.Click += new System.EventHandler(this.BtnJouer_Click);
            // 
            // LblTitreMenuPrincipal
            // 
            this.LblTitreMenuPrincipal.BackColor = System.Drawing.Color.Black;
            this.LblTitreMenuPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitreMenuPrincipal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LblTitreMenuPrincipal.Location = new System.Drawing.Point(99, 42);
            this.LblTitreMenuPrincipal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblTitreMenuPrincipal.Name = "LblTitreMenuPrincipal";
            this.LblTitreMenuPrincipal.Size = new System.Drawing.Size(700, 94);
            this.LblTitreMenuPrincipal.TabIndex = 9;
            this.LblTitreMenuPrincipal.Text = "PUCK-MAN";
            this.LblTitreMenuPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnParametres
            // 
            this.BtnParametres.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnParametres.ForeColor = System.Drawing.Color.Black;
            this.BtnParametres.Location = new System.Drawing.Point(99, 313);
            this.BtnParametres.Margin = new System.Windows.Forms.Padding(2);
            this.BtnParametres.Name = "BtnParametres";
            this.BtnParametres.Size = new System.Drawing.Size(700, 69);
            this.BtnParametres.TabIndex = 1;
            this.BtnParametres.Text = "PARAMETRES";
            this.BtnParametres.UseVisualStyleBackColor = true;
            this.BtnParametres.Click += new System.EventHandler(this.BtnParametres_Click);
            // 
            // BtnQuitter
            // 
            this.BtnQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuitter.Location = new System.Drawing.Point(466, 422);
            this.BtnQuitter.Margin = new System.Windows.Forms.Padding(2);
            this.BtnQuitter.Name = "BtnQuitter";
            this.BtnQuitter.Size = new System.Drawing.Size(334, 69);
            this.BtnQuitter.TabIndex = 3;
            this.BtnQuitter.Text = "QUITTER";
            this.BtnQuitter.UseVisualStyleBackColor = true;
            this.BtnQuitter.Click += new System.EventHandler(this.BtnQuitter_Click);
            // 
            // BtnCredits
            // 
            this.BtnCredits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCredits.Location = new System.Drawing.Point(99, 422);
            this.BtnCredits.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCredits.Name = "BtnCredits";
            this.BtnCredits.Size = new System.Drawing.Size(334, 69);
            this.BtnCredits.TabIndex = 2;
            this.BtnCredits.Text = "CREDITS";
            this.BtnCredits.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(888, 537);
            this.Controls.Add(this.BtnCredits);
            this.Controls.Add(this.BtnQuitter);
            this.Controls.Add(this.BtnParametres);
            this.Controls.Add(this.LblTitreMenuPrincipal);
            this.Controls.Add(this.BtnJouer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(904, 576);
            this.MinimumSize = new System.Drawing.Size(904, 576);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puck-Man";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnJouer;
        private System.Windows.Forms.Label LblTitreMenuPrincipal;
        private System.Windows.Forms.Button BtnParametres;
        private System.Windows.Forms.Button BtnQuitter;
        private System.Windows.Forms.Button BtnCredits;
    }
}