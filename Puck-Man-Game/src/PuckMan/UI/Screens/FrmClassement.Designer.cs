namespace Puck_Man_Game.src.PuckMan.UI.Screens
{
    partial class FrmScoreRanking
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.BtnRetour.TabIndex = 1;
            this.BtnRetour.Text = "RETOUR";
            this.BtnRetour.UseVisualStyleBackColor = true;
            this.BtnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // LblTitreClassement
            // 
            this.LblTitreClassement.BackColor = System.Drawing.Color.Black;
            this.LblTitreClassement.Font = new System.Drawing.Font("Minecraft", 48.20869F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.DgvClassement.AllowUserToAddRows = false;
            this.DgvClassement.AllowUserToDeleteRows = false;
            this.DgvClassement.AllowUserToOrderColumns = true;
            this.DgvClassement.AllowUserToResizeColumns = false;
            this.DgvClassement.AllowUserToResizeRows = false;
            this.DgvClassement.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Minecraft", 11.89565F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvClassement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvClassement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Minecraft", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvClassement.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvClassement.GridColor = System.Drawing.Color.White;
            this.DgvClassement.Location = new System.Drawing.Point(92, 160);
            this.DgvClassement.Name = "DgvClassement";
            this.DgvClassement.ReadOnly = true;
            this.DgvClassement.RowHeadersWidth = 51;
            this.DgvClassement.RowTemplate.Height = 24;
            this.DgvClassement.Size = new System.Drawing.Size(700, 233);
            this.DgvClassement.TabIndex = 0;
            // 
            // FrmScoreRanking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(882, 604);
            this.Controls.Add(this.DgvClassement);
            this.Controls.Add(this.LblTitreClassement);
            this.Controls.Add(this.BtnRetour);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 650);
            this.MinimumSize = new System.Drawing.Size(899, 649);
            this.Name = "FrmScoreRanking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puck-Man - Classement";
            ((System.ComponentModel.ISupportInitialize)(this.DgvClassement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnRetour;
        private System.Windows.Forms.Label LblTitreClassement;
        private System.Windows.Forms.DataGridView DgvClassement;
    }
}