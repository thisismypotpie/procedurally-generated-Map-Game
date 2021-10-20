namespace Magic_Game
{
    partial class TourneyForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.continueGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MatchButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.continueGameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(666, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // continueGameToolStripMenuItem
            // 
            this.continueGameToolStripMenuItem.Name = "continueGameToolStripMenuItem";
            this.continueGameToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.continueGameToolStripMenuItem.Text = "Continue Game";
            this.continueGameToolStripMenuItem.Click += new System.EventHandler(this.continueGameToolStripMenuItem_Click);
            // 
            // MatchButton
            // 
            this.MatchButton.Location = new System.Drawing.Point(244, 5);
            this.MatchButton.Name = "MatchButton";
            this.MatchButton.Size = new System.Drawing.Size(290, 39);
            this.MatchButton.TabIndex = 1;
            this.MatchButton.Text = "Fight";
            this.MatchButton.UseVisualStyleBackColor = true;
            this.MatchButton.Click += new System.EventHandler(this.MatchButton_Click);
            // 
            // TourneyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(666, 253);
            this.Controls.Add(this.MatchButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TourneyForm";
            this.Text = "TourneyForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem continueGameToolStripMenuItem;
        private System.Windows.Forms.Button MatchButton;
    }
}