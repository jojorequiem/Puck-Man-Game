namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    partial class FrmNiveauSuivant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNiveauSuivant));
            this.BtnRetourMenu = new System.Windows.Forms.Button();
            this.BtnNiveauSuivant = new System.Windows.Forms.Button();
            this.LblTitre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnRetourMenu
            // 
            this.BtnRetourMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRetourMenu.Location = new System.Drawing.Point(91, 422);
            this.BtnRetourMenu.Margin = new System.Windows.Forms.Padding(2);
            this.BtnRetourMenu.Name = "BtnRetourMenu";
            this.BtnRetourMenu.Size = new System.Drawing.Size(335, 69);
            this.BtnRetourMenu.TabIndex = 0;
            this.BtnRetourMenu.Text = "Menu";
            this.BtnRetourMenu.UseVisualStyleBackColor = true;
            this.BtnRetourMenu.Click += new System.EventHandler(this.BtnRetourMenu_Click);
            // 
            // BtnNiveauSuivant
            // 
            this.BtnNiveauSuivant.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNiveauSuivant.Location = new System.Drawing.Point(475, 422);
            this.BtnNiveauSuivant.Margin = new System.Windows.Forms.Padding(2);
            this.BtnNiveauSuivant.Name = "BtnNiveauSuivant";
            this.BtnNiveauSuivant.Size = new System.Drawing.Size(335, 69);
            this.BtnNiveauSuivant.TabIndex = 1;
            this.BtnNiveauSuivant.Text = "Niveau suivant";
            this.BtnNiveauSuivant.UseVisualStyleBackColor = true;
            this.BtnNiveauSuivant.Click += new System.EventHandler(this.BtnNiveauSuivant_Click);
            // 
            // LblTitre
            // 
            this.LblTitre.Font = new System.Drawing.Font("Minecraft", 48.20869F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitre.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LblTitre.Location = new System.Drawing.Point(91, 42);
            this.LblTitre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblTitre.Name = "LblTitre";
            this.LblTitre.Size = new System.Drawing.Size(700, 94);
            this.LblTitre.TabIndex = 2;
            this.LblTitre.Text = "Niveau suivant";
            this.LblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmNiveauSuivant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(882, 604);
            this.Controls.Add(this.LblTitre);
            this.Controls.Add(this.BtnNiveauSuivant);
            this.Controls.Add(this.BtnRetourMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(900, 650);
            this.MinimumSize = new System.Drawing.Size(899, 649);
            this.Name = "FrmNiveauSuivant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NiveauSuivant";
            this.Shown += new System.EventHandler(this.FrmNiveauSuivant_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnRetourMenu;
        private System.Windows.Forms.Button BtnNiveauSuivant;
        private System.Windows.Forms.Label LblTitre;
    }
}