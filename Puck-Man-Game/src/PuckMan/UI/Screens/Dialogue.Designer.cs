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
            this.LblDialogue.Font = new System.Drawing.Font("Segoe Script", 16.8F);
            this.LblDialogue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LblDialogue.Location = new System.Drawing.Point(193, 78);
            this.LblDialogue.Name = "LblDialogue";
            this.LblDialogue.Size = new System.Drawing.Size(692, 458);
            this.LblDialogue.TabIndex = 1;
            this.LblDialogue.Text = resources.GetString("LblDialogue.Text");
            this.LblDialogue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BtnSuivantDialogue
            // 
            this.BtnSuivantDialogue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSuivantDialogue.Location = new System.Drawing.Point(462, 598);
            this.BtnSuivantDialogue.Name = "BtnSuivantDialogue";
            this.BtnSuivantDialogue.Size = new System.Drawing.Size(178, 46);
            this.BtnSuivantDialogue.TabIndex = 2;
            this.BtnSuivantDialogue.Text = "Suivant";
            this.BtnSuivantDialogue.UseVisualStyleBackColor = true;
            this.BtnSuivantDialogue.Click += new System.EventHandler(this.BtnSuivantDialogue_Click);
            // 
            // Dialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(Program.LargeurFenetre, Program.HauteurFenetre);
            this.MaximumSize = new System.Drawing.Size(Program.LargeurFenetre, Program.HauteurFenetre);
            this.MinimumSize = new System.Drawing.Size(Program.LargeurFenetre, Program.HauteurFenetre);
            this.Controls.Add(this.BtnSuivantDialogue);
            this.Controls.Add(this.LblDialogue);
            this.Name = "Dialogue";
            this.Text = "Dialoguecs";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LblDialogue;
        private System.Windows.Forms.Button BtnSuivantDialogue;
    }
}