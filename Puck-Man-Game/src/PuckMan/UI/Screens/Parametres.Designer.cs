namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    partial class Parametres
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
            this.TrackBarSound = new System.Windows.Forms.TrackBar();
            this.TrackBarMusic = new System.Windows.Forms.TrackBar();
            this.lblTitreMenuPrincipal = new System.Windows.Forms.Label();
            this.BtnRetour = new System.Windows.Forms.Button();
            this.LblMainVolume = new System.Windows.Forms.Label();
            this.LblSoundVolume = new System.Windows.Forms.Label();
            this.LblMusicVolume = new System.Windows.Forms.Label();
            this.TrackBarMain = new System.Windows.Forms.TrackBar();
            this.LblMainValue = new System.Windows.Forms.Label();
            this.LblMusicValue = new System.Windows.Forms.Label();
            this.LblSoundValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarSound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarMusic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarMain)).BeginInit();
            this.SuspendLayout();
            // 
            // TrackBarSound
            // 
            this.TrackBarSound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TrackBarSound.LargeChange = 1;
            this.TrackBarSound.Location = new System.Drawing.Point(384, 392);
            this.TrackBarSound.Name = "TrackBarSound";
            this.TrackBarSound.Size = new System.Drawing.Size(511, 53);
            this.TrackBarSound.TabIndex = 2;
            this.TrackBarSound.ValueChanged += new System.EventHandler(this.TrackBarSound_ValueChanged);
            // 
            // TrackBarMusic
            // 
            this.TrackBarMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TrackBarMusic.Location = new System.Drawing.Point(384, 305);
            this.TrackBarMusic.Name = "TrackBarMusic";
            this.TrackBarMusic.Size = new System.Drawing.Size(511, 53);
            this.TrackBarMusic.TabIndex = 1;
            this.TrackBarMusic.ValueChanged += new System.EventHandler(this.TrackBarMusic_ValueChanged);
            // 
            // lblTitreMenuPrincipal
            // 
            this.lblTitreMenuPrincipal.BackColor = System.Drawing.Color.Black;
            this.lblTitreMenuPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitreMenuPrincipal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitreMenuPrincipal.Location = new System.Drawing.Point(125, 52);
            this.lblTitreMenuPrincipal.Name = "lblTitreMenuPrincipal";
            this.lblTitreMenuPrincipal.Size = new System.Drawing.Size(933, 116);
            this.lblTitreMenuPrincipal.TabIndex = 11;
            this.lblTitreMenuPrincipal.Text = "Paramètres";
            this.lblTitreMenuPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnRetour
            // 
            this.BtnRetour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRetour.Location = new System.Drawing.Point(125, 518);
            this.BtnRetour.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnRetour.Name = "BtnRetour";
            this.BtnRetour.Size = new System.Drawing.Size(933, 85);
            this.BtnRetour.TabIndex = 3;
            this.BtnRetour.Text = "RETOUR";
            this.BtnRetour.UseVisualStyleBackColor = true;
            this.BtnRetour.Click += new System.EventHandler(this.BtnRetour_Click);
            // 
            // LblMainVolume
            // 
            this.LblMainVolume.AutoSize = true;
            this.LblMainVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMainVolume.ForeColor = System.Drawing.Color.White;
            this.LblMainVolume.Location = new System.Drawing.Point(136, 214);
            this.LblMainVolume.Name = "LblMainVolume";
            this.LblMainVolume.Size = new System.Drawing.Size(215, 29);
            this.LblMainVolume.TabIndex = 14;
            this.LblMainVolume.Text = "Volume Principale:";
            // 
            // LblSoundVolume
            // 
            this.LblSoundVolume.AutoSize = true;
            this.LblSoundVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSoundVolume.ForeColor = System.Drawing.Color.White;
            this.LblSoundVolume.Location = new System.Drawing.Point(136, 392);
            this.LblSoundVolume.Name = "LblSoundVolume";
            this.LblSoundVolume.Size = new System.Drawing.Size(150, 29);
            this.LblSoundVolume.TabIndex = 15;
            this.LblSoundVolume.Text = "Volume Son:";
            // 
            // LblMusicVolume
            // 
            this.LblMusicVolume.AutoSize = true;
            this.LblMusicVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMusicVolume.ForeColor = System.Drawing.Color.White;
            this.LblMusicVolume.Location = new System.Drawing.Point(136, 305);
            this.LblMusicVolume.Name = "LblMusicVolume";
            this.LblMusicVolume.Size = new System.Drawing.Size(199, 29);
            this.LblMusicVolume.TabIndex = 16;
            this.LblMusicVolume.Text = "Volume Musique:";
            // 
            // TrackBarMain
            // 
            this.TrackBarMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TrackBarMain.Location = new System.Drawing.Point(384, 214);
            this.TrackBarMain.Name = "TrackBarMain";
            this.TrackBarMain.Size = new System.Drawing.Size(511, 53);
            this.TrackBarMain.TabIndex = 0;
            this.TrackBarMain.ValueChanged += new System.EventHandler(this.TrackBarMain_ValueChanged);
            // 
            // LblMainValue
            // 
            this.LblMainValue.AutoSize = true;
            this.LblMainValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMainValue.ForeColor = System.Drawing.Color.White;
            this.LblMainValue.Location = new System.Drawing.Point(947, 214);
            this.LblMainValue.Name = "LblMainValue";
            this.LblMainValue.Size = new System.Drawing.Size(34, 25);
            this.LblMainValue.TabIndex = 17;
            this.LblMainValue.Text = "10";
            // 
            // LblMusicValue
            // 
            this.LblMusicValue.AutoSize = true;
            this.LblMusicValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMusicValue.ForeColor = System.Drawing.Color.White;
            this.LblMusicValue.Location = new System.Drawing.Point(947, 305);
            this.LblMusicValue.Name = "LblMusicValue";
            this.LblMusicValue.Size = new System.Drawing.Size(34, 25);
            this.LblMusicValue.TabIndex = 18;
            this.LblMusicValue.Text = "10";
            // 
            // LblSoundValue
            // 
            this.LblSoundValue.AutoSize = true;
            this.LblSoundValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSoundValue.ForeColor = System.Drawing.Color.White;
            this.LblSoundValue.Location = new System.Drawing.Point(947, 392);
            this.LblSoundValue.Name = "LblSoundValue";
            this.LblSoundValue.Size = new System.Drawing.Size(34, 25);
            this.LblSoundValue.TabIndex = 19;
            this.LblSoundValue.Text = "10";
            // 
            // Parametres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 655);
            this.Controls.Add(this.LblSoundValue);
            this.Controls.Add(this.LblMusicValue);
            this.Controls.Add(this.LblMainValue);
            this.Controls.Add(this.TrackBarMain);
            this.Controls.Add(this.LblMusicVolume);
            this.Controls.Add(this.LblSoundVolume);
            this.Controls.Add(this.LblMainVolume);
            this.Controls.Add(this.BtnRetour);
            this.Controls.Add(this.lblTitreMenuPrincipal);
            this.Controls.Add(this.TrackBarMusic);
            this.Controls.Add(this.TrackBarSound);
            this.MaximumSize = new System.Drawing.Size(1200, 700);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "Parametres";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametres";
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarSound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarMusic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar TrackBarSound;
        private System.Windows.Forms.TrackBar TrackBarMusic;
        private System.Windows.Forms.Label lblTitreMenuPrincipal;
        private System.Windows.Forms.Button BtnRetour;
        private System.Windows.Forms.Label LblMainVolume;
        private System.Windows.Forms.Label LblSoundVolume;
        private System.Windows.Forms.Label LblMusicVolume;
        private System.Windows.Forms.TrackBar TrackBarMain;
        private System.Windows.Forms.Label LblMainValue;
        private System.Windows.Forms.Label LblMusicValue;
        private System.Windows.Forms.Label LblSoundValue;
    }
}