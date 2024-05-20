namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    partial class NouvellePartie
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
            this.LblPV = new System.Windows.Forms.Label();
            this.LblFragmentCollecte = new System.Windows.Forms.Label();
            this.LblFragmentGenere = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblPV
            // 
            this.LblPV.AutoSize = true;
            this.LblPV.Location = new System.Drawing.Point(922, 9);
            this.LblPV.Name = "LblPV";
            this.LblPV.Size = new System.Drawing.Size(25, 16);
            this.LblPV.TabIndex = 0;
            this.LblPV.Text = "PV";
            // 
            // LblFragmentCollecte
            // 
            this.LblFragmentCollecte.AutoSize = true;
            this.LblFragmentCollecte.Location = new System.Drawing.Point(922, 46);
            this.LblFragmentCollecte.Name = "LblFragmentCollecte";
            this.LblFragmentCollecte.Size = new System.Drawing.Size(14, 16);
            this.LblFragmentCollecte.TabIndex = 1;
            this.LblFragmentCollecte.Text = "0";
            // 
            // LblFragmentGenere
            // 
            this.LblFragmentGenere.AutoSize = true;
            this.LblFragmentGenere.Location = new System.Drawing.Point(959, 46);
            this.LblFragmentGenere.Name = "LblFragmentGenere";
            this.LblFragmentGenere.Size = new System.Drawing.Size(14, 16);
            this.LblFragmentGenere.TabIndex = 2;
            this.LblFragmentGenere.Text = "4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(942, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "/";
            // 
            // NouvellePartie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblFragmentGenere);
            this.Controls.Add(this.LblFragmentCollecte);
            this.Controls.Add(this.LblPV);
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "NouvellePartie";
            this.Text = "NouvellePartie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblPV;
        private System.Windows.Forms.Label LblFragmentCollecte;
        private System.Windows.Forms.Label LblFragmentGenere;
        private System.Windows.Forms.Label label1;
    }
}