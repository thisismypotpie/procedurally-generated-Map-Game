namespace Magic_Game
{
    partial class LoadForm
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
            this.LandsLoadingLabel = new System.Windows.Forms.Label();
            this.progressBarLands = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // LandsLoadingLabel
            // 
            this.LandsLoadingLabel.AutoSize = true;
            this.LandsLoadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LandsLoadingLabel.Location = new System.Drawing.Point(4, 35);
            this.LandsLoadingLabel.Name = "LandsLoadingLabel";
            this.LandsLoadingLabel.Size = new System.Drawing.Size(278, 42);
            this.LandsLoadingLabel.TabIndex = 1;
            this.LandsLoadingLabel.Text = "Lands Loading";
            // 
            // progressBarLands
            // 
            this.progressBarLands.Location = new System.Drawing.Point(11, 121);
            this.progressBarLands.Name = "progressBarLands";
            this.progressBarLands.Size = new System.Drawing.Size(261, 23);
            this.progressBarLands.Step = 1;
            this.progressBarLands.TabIndex = 2;
            // 
            // LoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.progressBarLands);
            this.Controls.Add(this.LandsLoadingLabel);
            this.Name = "LoadForm";
            this.Text = "LoadForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LandsLoadingLabel;
        private System.Windows.Forms.ProgressBar progressBarLands;
    }
}