using Puck_Man_Game.assets.fonts;

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
            this.BtnParametres = new System.Windows.Forms.Button();
            this.BtnQuitter = new System.Windows.Forms.Button();
            this.BtnClassement = new System.Windows.Forms.Button();
            this.BtnAPropos = new System.Windows.Forms.Button();
            this.PcbTitle = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PcbTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnJouer
            // 
            this.BtnJouer.BackColor = System.Drawing.Color.White;
            this.BtnJouer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnJouer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BtnJouer.ForeColor = System.Drawing.Color.Black;
            this.BtnJouer.Location = new System.Drawing.Point(91, 204);
            this.BtnJouer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnJouer.Name = "BtnJouer";
            this.BtnJouer.Size = new System.Drawing.Size(700, 69);
            this.BtnJouer.TabIndex = 0;
            this.BtnJouer.Text = "JOUER";
            this.BtnJouer.UseVisualStyleBackColor = false;
            this.BtnJouer.Click += new System.EventHandler(this.BtnJouer_Click);
            // 
            // BtnParametres
            // 
            this.BtnParametres.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BtnParametres.ForeColor = System.Drawing.Color.Black;
            this.BtnParametres.Location = new System.Drawing.Point(91, 313);
            this.BtnParametres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnParametres.Name = "BtnParametres";
            this.BtnParametres.Size = new System.Drawing.Size(700, 69);
            this.BtnParametres.TabIndex = 1;
            this.BtnParametres.Text = "PARAMETRES";
            this.BtnParametres.UseVisualStyleBackColor = true;
            this.BtnParametres.Click += new System.EventHandler(this.BtnParametres_Click);
            // 
            // BtnQuitter
            // 
            this.BtnQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BtnQuitter.Location = new System.Drawing.Point(458, 422);
            this.BtnQuitter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnQuitter.Name = "BtnQuitter";
            this.BtnQuitter.Size = new System.Drawing.Size(334, 69);
            this.BtnQuitter.TabIndex = 3;
            this.BtnQuitter.Text = "QUITTER";
            this.BtnQuitter.UseVisualStyleBackColor = true;
            this.BtnQuitter.Click += new System.EventHandler(this.BtnQuitter_Click);
            // 
            // BtnClassement
            // 
            this.BtnClassement.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BtnClassement.Location = new System.Drawing.Point(91, 422);
            this.BtnClassement.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnClassement.Name = "BtnClassement";
            this.BtnClassement.Size = new System.Drawing.Size(334, 69);
            this.BtnClassement.TabIndex = 2;
            this.BtnClassement.Text = "CLASSEMENT";
            this.BtnClassement.UseVisualStyleBackColor = true;
            this.BtnClassement.Click += new System.EventHandler(this.BtnClassement_Click);
            // 
            // BtnAPropos
            // 
            this.BtnAPropos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BtnAPropos.Location = new System.Drawing.Point(812, 449);
            this.BtnAPropos.Name = "BtnAPropos";
            this.BtnAPropos.Size = new System.Drawing.Size(42, 42);
            this.BtnAPropos.TabIndex = 4;
            this.BtnAPropos.Text = "?";
            this.BtnAPropos.UseVisualStyleBackColor = true;
            this.BtnAPropos.Click += new System.EventHandler(this.BtnAPropos_Click);
            // 
            // PcbTitle
            // 
            this.PcbTitle.BackColor = System.Drawing.Color.Transparent;
            this.PcbTitle.BackgroundImage = global::Puck_Man_Game.Properties.Resources.title;
            this.PcbTitle.Location = new System.Drawing.Point(192, -59);
            this.PcbTitle.Name = "PcbTitle";
            this.PcbTitle.Size = new System.Drawing.Size(498, 220);
            this.PcbTitle.TabIndex = 5;
            this.PcbTitle.TabStop = false;
            // 
            // FrmMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(882, 605);
            this.Controls.Add(this.PcbTitle);
            this.Controls.Add(this.BtnAPropos);
            this.Controls.Add(this.BtnClassement);
            this.Controls.Add(this.BtnQuitter);
            this.Controls.Add(this.BtnParametres);
            this.Controls.Add(this.BtnJouer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(901, 651);
            this.MinimumSize = new System.Drawing.Size(899, 649);
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puck-Man";
            ((System.ComponentModel.ISupportInitialize)(this.PcbTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnJouer;
        private System.Windows.Forms.Button BtnParametres;
        private System.Windows.Forms.Button BtnQuitter;
        private System.Windows.Forms.Button BtnClassement;
        private System.Windows.Forms.Button BtnAPropos;
        private System.Windows.Forms.PictureBox PcbTitle;
    }
}