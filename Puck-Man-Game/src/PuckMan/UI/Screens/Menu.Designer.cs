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
            this.btnJouer = new System.Windows.Forms.Button();
            this.lblTitreMenuPrincipal = new System.Windows.Forms.Label();
            this.btnClassement = new System.Windows.Forms.Button();
            this.btnParametres = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnJouer
            // 
            this.btnJouer.BackColor = System.Drawing.Color.IndianRed;
            this.btnJouer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJouer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnJouer.Location = new System.Drawing.Point(250, 265);
            this.btnJouer.Margin = new System.Windows.Forms.Padding(2);
            this.btnJouer.Name = "btnJouer";
            this.btnJouer.Size = new System.Drawing.Size(700, 69);
            this.btnJouer.TabIndex = 0;
            this.btnJouer.Text = "JOUER";
            this.btnJouer.UseVisualStyleBackColor = false;
            this.btnJouer.Click += new System.EventHandler(this.btnJouer_Click);
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
            this.lblTitreMenuPrincipal.TabIndex = 9;
            this.lblTitreMenuPrincipal.Text = "PUCK-MAN";
            this.lblTitreMenuPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClassement
            // 
            this.btnClassement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClassement.Location = new System.Drawing.Point(250, 374);
            this.btnClassement.Margin = new System.Windows.Forms.Padding(2);
            this.btnClassement.Name = "btnClassement";
            this.btnClassement.Size = new System.Drawing.Size(700, 69);
            this.btnClassement.TabIndex = 10;
            this.btnClassement.Text = "CLASSEMENT";
            this.btnClassement.UseVisualStyleBackColor = true;
            this.btnClassement.Click += new System.EventHandler(this.btnClassement_Click);
            // 
            // btnParametres
            // 
            this.btnParametres.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParametres.Location = new System.Drawing.Point(250, 483);
            this.btnParametres.Margin = new System.Windows.Forms.Padding(2);
            this.btnParametres.Name = "btnParametres";
            this.btnParametres.Size = new System.Drawing.Size(335, 69);
            this.btnParametres.TabIndex = 11;
            this.btnParametres.Text = "PARAMETRES";
            this.btnParametres.UseVisualStyleBackColor = true;
            this.btnParametres.Click += new System.EventHandler(this.btnParametres_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitter.Location = new System.Drawing.Point(615, 483);
            this.btnQuitter.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(335, 69);
            this.btnQuitter.TabIndex = 12;
            this.btnQuitter.Text = "QUITTER";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.btnParametres);
            this.Controls.Add(this.btnClassement);
            this.Controls.Add(this.lblTitreMenuPrincipal);
            this.Controls.Add(this.btnJouer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "Menu";
            this.Text = "Puck-Man";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnJouer;
        private System.Windows.Forms.Label lblTitreMenuPrincipal;
        private System.Windows.Forms.Button btnClassement;
        private System.Windows.Forms.Button btnParametres;
        private System.Windows.Forms.Button btnQuitter;
    }
}