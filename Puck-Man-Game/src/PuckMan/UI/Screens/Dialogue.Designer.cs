namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    partial class Dialogue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialogue));
            this.LblDialogue = new System.Windows.Forms.Label();
            this.BtnSuivantDialogue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblDialogue
            // 
            this.LblDialogue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.LblDialogue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LblDialogue.Location = new System.Drawing.Point(314, 114);
            this.LblDialogue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblDialogue.Name = "LblDialogue";
            this.LblDialogue.Size = new System.Drawing.Size(519, 372);
            this.LblDialogue.TabIndex = 1;
            this.LblDialogue.Text = resources.GetString("LblDialogue.Text");
            this.LblDialogue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BtnSuivantDialogue
            // 
            this.BtnSuivantDialogue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BtnSuivantDialogue.Location = new System.Drawing.Point(395, 476);
            this.BtnSuivantDialogue.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSuivantDialogue.Name = "BtnSuivantDialogue";
            this.BtnSuivantDialogue.Size = new System.Drawing.Size(335, 69);
            this.BtnSuivantDialogue.TabIndex = 2;
            this.BtnSuivantDialogue.Text = "Suivant";
            this.BtnSuivantDialogue.UseVisualStyleBackColor = true;
            this.BtnSuivantDialogue.Click += new System.EventHandler(this.BtnSuivantDialogue_Click);
            // 
            // Dialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.BtnSuivantDialogue);
            this.Controls.Add(this.LblDialogue);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1200, 800);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "Dialogue";
            this.Text = "Dialoguecs";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LblDialogue;
        private System.Windows.Forms.Button BtnSuivantDialogue;
    }
}