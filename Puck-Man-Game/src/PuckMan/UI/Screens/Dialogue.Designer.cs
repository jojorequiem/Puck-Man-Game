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
            this.BtnDialogueSuivant = new System.Windows.Forms.Button();
            this.LblTitre = new System.Windows.Forms.Label();
            this.Panel = new System.Windows.Forms.Panel();
            this.FlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnDialogueSuivant
            // 
            this.BtnDialogueSuivant.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BtnDialogueSuivant.Location = new System.Drawing.Point(321, 594);
            this.BtnDialogueSuivant.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnDialogueSuivant.Name = "BtnDialogueSuivant";
            this.BtnDialogueSuivant.Size = new System.Drawing.Size(932, 85);
            this.BtnDialogueSuivant.TabIndex = 2;
            this.BtnDialogueSuivant.Text = "Suivant";
            this.BtnDialogueSuivant.UseVisualStyleBackColor = true;
            this.BtnDialogueSuivant.Click += new System.EventHandler(this.BtnDialogueSuivant_Click);
            // 
            // LblTitre
            // 
            this.LblTitre.AutoSize = true;
            this.LblTitre.BackColor = System.Drawing.Color.Black;
            this.LblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitre.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LblTitre.Location = new System.Drawing.Point(311, 66);
            this.LblTitre.Name = "LblTitre";
            this.LblTitre.Size = new System.Drawing.Size(956, 58);
            this.LblTitre.TabIndex = 10;
            this.LblTitre.Text = "Chapitre 1 : Confrontation avec l’inconnue";
            this.LblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel
            // 
            this.Panel.AutoScroll = true;
            this.Panel.Controls.Add(this.FlowPanel);
            this.Panel.Location = new System.Drawing.Point(284, 145);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(969, 432);
            this.Panel.TabIndex = 11;
            // 
            // FlowPanel
            // 
            this.FlowPanel.AutoSize = true;
            this.FlowPanel.Location = new System.Drawing.Point(26, 3);
            this.FlowPanel.Name = "FlowPanel";
            this.FlowPanel.Size = new System.Drawing.Size(873, 438);
            this.FlowPanel.TabIndex = 0;
            // 
            // Dialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1576, 927);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.LblTitre);
            this.Controls.Add(this.BtnDialogueSuivant);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1594, 974);
            this.MinimumSize = new System.Drawing.Size(1594, 974);
            this.Name = "Dialogue";
            this.Text = "Dialoguecs";
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnDialogueSuivant;
        private System.Windows.Forms.Label LblTitre;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.FlowLayoutPanel FlowPanel;
    }
}