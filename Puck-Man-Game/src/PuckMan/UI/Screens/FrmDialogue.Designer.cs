namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    partial class FrmDialogue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDialogue));
            this.BtnDialogueSuivant = new System.Windows.Forms.Button();
            this.LblTitre = new System.Windows.Forms.Label();
            this.Panel = new System.Windows.Forms.Panel();
            this.FlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnSkip = new System.Windows.Forms.Button();
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnDialogueSuivant
            // 
            this.BtnDialogueSuivant.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BtnDialogueSuivant.Location = new System.Drawing.Point(458, 500);
            this.BtnDialogueSuivant.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnDialogueSuivant.Name = "BtnDialogueSuivant";
            this.BtnDialogueSuivant.Size = new System.Drawing.Size(334, 69);
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
            this.LblTitre.Location = new System.Drawing.Point(91, 42);
            this.LblTitre.Name = "LblTitre";
            this.LblTitre.Size = new System.Drawing.Size(956, 58);
            this.LblTitre.TabIndex = 10;
            this.LblTitre.Text = "Chapitre 1 : Confrontation avec l’inconnue";
            this.LblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel
            // 
            this.Panel.AutoScroll = true;
            this.Panel.BackColor = System.Drawing.Color.White;
            this.Panel.Controls.Add(this.FlowPanel);
            this.Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.Panel.Location = new System.Drawing.Point(91, 97);
            this.Panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(701, 375);
            this.Panel.TabIndex = 11;
            // 
            // FlowPanel
            // 
            this.FlowPanel.AutoSize = true;
            this.FlowPanel.BackColor = System.Drawing.Color.Black;
            this.FlowPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FlowPanel.Location = new System.Drawing.Point(20, 20);
            this.FlowPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FlowPanel.Name = "FlowPanel";
            this.FlowPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FlowPanel.Size = new System.Drawing.Size(656, 339);
            this.FlowPanel.TabIndex = 0;
            // 
            // BtnSkip
            // 
            this.BtnSkip.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BtnSkip.Location = new System.Drawing.Point(91, 500);
            this.BtnSkip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSkip.Name = "BtnSkip";
            this.BtnSkip.Size = new System.Drawing.Size(334, 69);
            this.BtnSkip.TabIndex = 12;
            this.BtnSkip.Text = "Passer";
            this.BtnSkip.UseVisualStyleBackColor = true;
            this.BtnSkip.Click += new System.EventHandler(this.BtnSkip_Click);
            // 
            // FrmDialogue
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(882, 603);
            this.Controls.Add(this.BtnSkip);
            this.Controls.Add(this.LblTitre);
            this.Controls.Add(this.BtnDialogueSuivant);
            this.Controls.Add(this.Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(900, 650);
            this.MinimumSize = new System.Drawing.Size(899, 649);
            this.Name = "FrmDialogue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Button BtnSkip;
    }
}