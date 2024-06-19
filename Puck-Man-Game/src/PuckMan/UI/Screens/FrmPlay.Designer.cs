namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    partial class FrmPlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlay));
            this.BtnModeHistoire = new System.Windows.Forms.Button();
            this.BtnRetour = new System.Windows.Forms.Button();
            this.BtnModeInfini = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnModeHistoire
            // 
            this.BtnModeHistoire.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModeHistoire.ForeColor = System.Drawing.Color.Black;
            this.BtnModeHistoire.Location = new System.Drawing.Point(91, 267);
            this.BtnModeHistoire.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnModeHistoire.Name = "BtnModeHistoire";
            this.BtnModeHistoire.Size = new System.Drawing.Size(700, 69);
            this.BtnModeHistoire.TabIndex = 14;
            this.BtnModeHistoire.Text = "MODE HISTOIRE";
            this.BtnModeHistoire.UseVisualStyleBackColor = true;
            this.BtnModeHistoire.Click += new System.EventHandler(this.BtnModeHistoire_Click);
            // 
            // BtnRetour
            // 
            this.BtnRetour.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRetour.ForeColor = System.Drawing.Color.Black;
            this.BtnRetour.Location = new System.Drawing.Point(91, 373);
            this.BtnRetour.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnRetour.Name = "BtnRetour";
            this.BtnRetour.Size = new System.Drawing.Size(700, 69);
            this.BtnRetour.TabIndex = 13;
            this.BtnRetour.Text = "RETOUR";
            this.BtnRetour.UseVisualStyleBackColor = true;
            this.BtnRetour.Click += new System.EventHandler(this.BtnRetour_Click);
            // 
            // BtnModeInfini
            // 
            this.BtnModeInfini.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModeInfini.ForeColor = System.Drawing.Color.Black;
            this.BtnModeInfini.Location = new System.Drawing.Point(91, 161);
            this.BtnModeInfini.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnModeInfini.Name = "BtnModeInfini";
            this.BtnModeInfini.Size = new System.Drawing.Size(700, 69);
            this.BtnModeInfini.TabIndex = 12;
            this.BtnModeInfini.Text = "MODE INFINI";
            this.BtnModeInfini.UseVisualStyleBackColor = true;
            this.BtnModeInfini.Click += new System.EventHandler(this.BtnModeInfini_Click);
            // 
            // FrmPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(883, 604);
            this.Controls.Add(this.BtnModeHistoire);
            this.Controls.Add(this.BtnRetour);
            this.Controls.Add(this.BtnModeInfini);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(901, 651);
            this.MinimumSize = new System.Drawing.Size(899, 649);
            this.Name = "FrmPlay";
            this.Text = "FrmPlay";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnModeInfini;
        private System.Windows.Forms.Button BtnRetour;
        private System.Windows.Forms.Button BtnModeHistoire;
    }
} 