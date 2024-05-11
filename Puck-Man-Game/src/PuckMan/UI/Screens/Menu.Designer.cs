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
            this.btnJouer.Location = new System.Drawing.Point(142, 287);
            this.btnJouer.Name = "btnJouer";
            this.btnJouer.Size = new System.Drawing.Size(725, 85);
            this.btnJouer.TabIndex = 0;
            this.btnJouer.Text = "JOUER";
            this.btnJouer.UseVisualStyleBackColor = true;
            this.btnJouer.Click += new System.EventHandler(this.btnJouer_Click);
            // 
            // lblTitreMenuPrincipal
            // 
            this.lblTitreMenuPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitreMenuPrincipal.Location = new System.Drawing.Point(201, 138);
            this.lblTitreMenuPrincipal.Name = "lblTitreMenuPrincipal";
            this.lblTitreMenuPrincipal.Size = new System.Drawing.Size(604, 116);
            this.lblTitreMenuPrincipal.TabIndex = 9;
            this.lblTitreMenuPrincipal.Text = "PUCK-MAN";
            this.lblTitreMenuPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClassement
            // 
            this.btnClassement.Location = new System.Drawing.Point(142, 392);
            this.btnClassement.Name = "btnClassement";
            this.btnClassement.Size = new System.Drawing.Size(725, 85);
            this.btnClassement.TabIndex = 10;
            this.btnClassement.Text = "CLASSEMENT";
            this.btnClassement.UseVisualStyleBackColor = true;
            // 
            // btnParametres
            // 
            this.btnParametres.Location = new System.Drawing.Point(142, 498);
            this.btnParametres.Name = "btnParametres";
            this.btnParametres.Size = new System.Drawing.Size(354, 85);
            this.btnParametres.TabIndex = 11;
            this.btnParametres.Text = "PARAMETRES";
            this.btnParametres.UseVisualStyleBackColor = true;
            // 
            // btnQuitter
            // 
            this.btnQuitter.Location = new System.Drawing.Point(513, 498);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(354, 85);
            this.btnQuitter.TabIndex = 12;
            this.btnQuitter.Text = "QUITTER";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.btnParametres);
            this.Controls.Add(this.btnClassement);
            this.Controls.Add(this.lblTitreMenuPrincipal);
            this.Controls.Add(this.btnJouer);
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "MainMenuForm";
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