namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    partial class FrmDeath
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeath));
            this.PctDeathLogo = new System.Windows.Forms.PictureBox();
            this.LblTitreMort = new System.Windows.Forms.Label();
            this.LblScore = new System.Windows.Forms.Label();
            this.LblValeurScore = new System.Windows.Forms.Label();
            this.BtnNouvellePartie = new System.Windows.Forms.Button();
            this.BtnMenu = new System.Windows.Forms.Button();
            this.PcbScore = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PctDeathLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PcbScore)).BeginInit();
            this.SuspendLayout();
            // 
            // PctDeathLogo
            // 
            this.PctDeathLogo.BackColor = System.Drawing.Color.Transparent;
            this.PctDeathLogo.BackgroundImage = global::Puck_Man_Game.Properties.Resources.mort;
            this.PctDeathLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PctDeathLogo.Location = new System.Drawing.Point(367, 139);
            this.PctDeathLogo.Name = "PctDeathLogo";
            this.PctDeathLogo.Size = new System.Drawing.Size(152, 152);
            this.PctDeathLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PctDeathLogo.TabIndex = 1;
            this.PctDeathLogo.TabStop = false;
            // 
            // LblTitreMort
            // 
            this.LblTitreMort.BackColor = System.Drawing.Color.Black;
            this.LblTitreMort.Font = new System.Drawing.Font("Microsoft Sans Serif", 48.20869F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitreMort.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LblTitreMort.Location = new System.Drawing.Point(91, 42);
            this.LblTitreMort.Name = "LblTitreMort";
            this.LblTitreMort.Size = new System.Drawing.Size(700, 94);
            this.LblTitreMort.TabIndex = 12;
            this.LblTitreMort.Text = "MORT";
            this.LblTitreMort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblScore
            // 
            this.LblScore.AutoSize = true;
            this.LblScore.BackColor = System.Drawing.Color.Transparent;
            this.LblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.03478F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblScore.ForeColor = System.Drawing.Color.White;
            this.LblScore.Location = new System.Drawing.Point(402, 322);
            this.LblScore.Name = "LblScore";
            this.LblScore.Size = new System.Drawing.Size(121, 39);
            this.LblScore.TabIndex = 13;
            this.LblScore.Text = "Score ";
            // 
            // LblValeurScore
            // 
            this.LblValeurScore.AutoSize = true;
            this.LblValeurScore.BackColor = System.Drawing.Color.Transparent;
            this.LblValeurScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.03478F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValeurScore.ForeColor = System.Drawing.Color.White;
            this.LblValeurScore.Location = new System.Drawing.Point(519, 322);
            this.LblValeurScore.Name = "LblValeurScore";
            this.LblValeurScore.Size = new System.Drawing.Size(37, 39);
            this.LblValeurScore.TabIndex = 14;
            this.LblValeurScore.Text = "0";
            // 
            // BtnNouvellePartie
            // 
            this.BtnNouvellePartie.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BtnNouvellePartie.Location = new System.Drawing.Point(458, 422);
            this.BtnNouvellePartie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnNouvellePartie.Name = "BtnNouvellePartie";
            this.BtnNouvellePartie.Size = new System.Drawing.Size(334, 69);
            this.BtnNouvellePartie.TabIndex = 15;
            this.BtnNouvellePartie.Text = "NOUVELLE PARTIE";
            this.BtnNouvellePartie.UseVisualStyleBackColor = true;
            this.BtnNouvellePartie.Click += new System.EventHandler(this.BtnNouvellePartie_Click);
            // 
            // BtnMenu
            // 
            this.BtnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BtnMenu.Location = new System.Drawing.Point(91, 422);
            this.BtnMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnMenu.Name = "BtnMenu";
            this.BtnMenu.Size = new System.Drawing.Size(334, 69);
            this.BtnMenu.TabIndex = 16;
            this.BtnMenu.Text = "MENU";
            this.BtnMenu.UseVisualStyleBackColor = true;
            this.BtnMenu.Click += new System.EventHandler(this.BtnMenu_Click);
            // 
            // PcbScore
            // 
            this.PcbScore.BackColor = System.Drawing.Color.Transparent;
            this.PcbScore.Image = global::Puck_Man_Game.Properties.Resources.score;
            this.PcbScore.InitialImage = ((System.Drawing.Image)(resources.GetObject("PcbScore.InitialImage")));
            this.PcbScore.Location = new System.Drawing.Point(330, 297);
            this.PcbScore.Name = "PcbScore";
            this.PcbScore.Size = new System.Drawing.Size(80, 80);
            this.PcbScore.TabIndex = 17;
            this.PcbScore.TabStop = false;
            // 
            // FrmDeath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(883, 604);
            this.Controls.Add(this.PcbScore);
            this.Controls.Add(this.BtnMenu);
            this.Controls.Add(this.BtnNouvellePartie);
            this.Controls.Add(this.LblValeurScore);
            this.Controls.Add(this.LblScore);
            this.Controls.Add(this.LblTitreMort);
            this.Controls.Add(this.PctDeathLogo);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(901, 651);
            this.MinimumSize = new System.Drawing.Size(899, 649);
            this.Name = "FrmDeath";
            this.Text = "FrmDeath";
            ((System.ComponentModel.ISupportInitialize)(this.PctDeathLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PcbScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PctDeathLogo;
        private System.Windows.Forms.Label LblTitreMort;
        private System.Windows.Forms.Label LblScore;
        private System.Windows.Forms.Label LblValeurScore;
        private System.Windows.Forms.Button BtnNouvellePartie;
        private System.Windows.Forms.Button BtnMenu;
        private System.Windows.Forms.PictureBox PcbScore;
    }
}