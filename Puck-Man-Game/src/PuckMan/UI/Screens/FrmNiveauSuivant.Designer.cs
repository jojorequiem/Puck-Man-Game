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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnRetourMenu
            // 
            this.BtnRetourMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRetourMenu.Location = new System.Drawing.Point(81, 490);
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
            this.BtnNiveauSuivant.Location = new System.Drawing.Point(475, 490);
            this.BtnNiveauSuivant.Margin = new System.Windows.Forms.Padding(2);
            this.BtnNiveauSuivant.Name = "BtnNiveauSuivant";
            this.BtnNiveauSuivant.Size = new System.Drawing.Size(335, 69);
            this.BtnNiveauSuivant.TabIndex = 1;
            this.BtnNiveauSuivant.Text = "Niveau suivant";
            this.BtnNiveauSuivant.UseVisualStyleBackColor = true;
            this.BtnNiveauSuivant.Click += new System.EventHandler(this.BtnNiveauSuivant_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(195, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(543, 87);
            this.label1.TabIndex = 2;
            this.label1.Text = "Niveau suivant";
            // 
            // FrmNiveauSuivant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(882, 605);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnNiveauSuivant);
            this.Controls.Add(this.BtnRetourMenu);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(900, 650);
            this.Name = "FrmNiveauSuivant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NiveauSuivant";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRetourMenu;
        private System.Windows.Forms.Button BtnNiveauSuivant;
        private System.Windows.Forms.Label label1;
    }
}