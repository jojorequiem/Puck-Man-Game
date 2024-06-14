namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    partial class FrmClassement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClassement));
            this.BtnRetour = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.LblTitreClassement = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnRetour
            // 
            this.BtnRetour.Location = new System.Drawing.Point(132, 519);
            this.BtnRetour.Name = "BtnRetour";
            this.BtnRetour.Size = new System.Drawing.Size(933, 85);
            this.BtnRetour.TabIndex = 4;
            this.BtnRetour.Text = "RETOUR";
            this.BtnRetour.UseVisualStyleBackColor = true;
            this.BtnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(132, 206);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(933, 24);
            this.comboBox1.TabIndex = 6;
            // 
            // LblTitreClassement
            // 
            this.LblTitreClassement.BackColor = System.Drawing.Color.Black;
            this.LblTitreClassement.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitreClassement.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LblTitreClassement.Location = new System.Drawing.Point(132, 52);
            this.LblTitreClassement.Name = "LblTitreClassement";
            this.LblTitreClassement.Size = new System.Drawing.Size(933, 116);
            this.LblTitreClassement.TabIndex = 10;
            this.LblTitreClassement.Text = "CLASSEMENT";
            this.LblTitreClassement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmClassement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.LblTitreClassement);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BtnRetour);
            this.MaximumSize = new System.Drawing.Size(1200, 700);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "FrmClassement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Classement";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnRetour;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label LblTitreClassement;
    }
}