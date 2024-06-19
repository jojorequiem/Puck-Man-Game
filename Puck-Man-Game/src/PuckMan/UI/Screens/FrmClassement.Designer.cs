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
            this.LblTitreClassement = new System.Windows.Forms.Label();
            this.DgvClassement = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClassement)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnRetour
            // 
            this.BtnRetour.Location = new System.Drawing.Point(92, 422);
            this.BtnRetour.Name = "BtnRetour";
            this.BtnRetour.Size = new System.Drawing.Size(700, 69);
            this.BtnRetour.TabIndex = 4;
            this.BtnRetour.Text = "RETOUR";
            this.BtnRetour.UseVisualStyleBackColor = true;
            this.BtnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // LblTitreClassement
            // 
            this.LblTitreClassement.BackColor = System.Drawing.Color.Black;
            this.LblTitreClassement.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitreClassement.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LblTitreClassement.Location = new System.Drawing.Point(92, 42);
            this.LblTitreClassement.Name = "LblTitreClassement";
            this.LblTitreClassement.Size = new System.Drawing.Size(700, 94);
            this.LblTitreClassement.TabIndex = 10;
            this.LblTitreClassement.Text = "CLASSEMENT";
            this.LblTitreClassement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvClassement
            // 
            this.DgvClassement.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DgvClassement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvClassement.Location = new System.Drawing.Point(92, 180);
            this.DgvClassement.Name = "DgvClassement";
            this.DgvClassement.RowHeadersWidth = 51;
            this.DgvClassement.RowTemplate.Height = 24;
            this.DgvClassement.Size = new System.Drawing.Size(700, 220);
            this.DgvClassement.TabIndex = 11;
            // 
            // FrmClassement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(882, 603);
            this.Controls.Add(this.DgvClassement);
            this.Controls.Add(this.LblTitreClassement);
            this.Controls.Add(this.BtnRetour);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(900, 650);
            this.MinimumSize = new System.Drawing.Size(899, 649);
            this.Name = "FrmClassement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Classement";
            ((System.ComponentModel.ISupportInitialize)(this.DgvClassement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnRetour;
        private System.Windows.Forms.Label LblTitreClassement;
        private System.Windows.Forms.DataGridView DgvClassement;
    }
}