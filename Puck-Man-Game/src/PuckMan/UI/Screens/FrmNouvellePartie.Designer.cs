﻿namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    partial class FrmNouvellePartie
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LblPV
            // 
            this.LblPV.AutoSize = true;
            this.LblPV.BackColor = System.Drawing.Color.Transparent;
            this.LblPV.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPV.ForeColor = System.Drawing.Color.Transparent;
            this.LblPV.Location = new System.Drawing.Point(784, 37);
            this.LblPV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblPV.Name = "LblPV";
            this.LblPV.Size = new System.Drawing.Size(26, 29);
            this.LblPV.TabIndex = 0;
            this.LblPV.Text = "3";
            // 
            // LblFragmentCollecte
            // 
            this.LblFragmentCollecte.AutoSize = true;
            this.LblFragmentCollecte.BackColor = System.Drawing.Color.Transparent;
            this.LblFragmentCollecte.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFragmentCollecte.ForeColor = System.Drawing.Color.Transparent;
            this.LblFragmentCollecte.Location = new System.Drawing.Point(786, 126);
            this.LblFragmentCollecte.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LblFragmentCollecte.Name = "LblFragmentCollecte";
            this.LblFragmentCollecte.Size = new System.Drawing.Size(26, 29);
            this.LblFragmentCollecte.TabIndex = 1;
            this.LblFragmentCollecte.Text = "0";
            // 
            // LblFragmentGenere
            // 
            this.LblFragmentGenere.AutoSize = true;
            this.LblFragmentGenere.BackColor = System.Drawing.Color.Transparent;
            this.LblFragmentGenere.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFragmentGenere.ForeColor = System.Drawing.Color.Transparent;
            this.LblFragmentGenere.Location = new System.Drawing.Point(844, 126);
            this.LblFragmentGenere.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LblFragmentGenere.Name = "LblFragmentGenere";
            this.LblFragmentGenere.Size = new System.Drawing.Size(26, 29);
            this.LblFragmentGenere.TabIndex = 2;
            this.LblFragmentGenere.Text = "4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(820, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "/";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Puck_Man_Game.Properties.Resources.fragment;
            this.pictureBox2.Location = new System.Drawing.Point(716, 104);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Puck_Man_Game.Properties.Resources.hp;
            this.pictureBox1.Location = new System.Drawing.Point(716, 24);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // FrmNouvellePartie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.BackgroundImage = global::Puck_Man_Game.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(882, 603);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblFragmentGenere);
            this.Controls.Add(this.LblFragmentCollecte);
            this.Controls.Add(this.LblPV);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(900, 650);
            this.Name = "FrmNouvellePartie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puck Man";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblPV;
        private System.Windows.Forms.Label LblFragmentCollecte;
        private System.Windows.Forms.Label LblFragmentGenere;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}