namespace Magic_Game
{
    partial class LoadChooseForm
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
            this.GameThreeBtn = new System.Windows.Forms.Button();
            this.GameOneBtn = new System.Windows.Forms.Button();
            this.GameTwoBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GameThreeBtn
            // 
            this.GameThreeBtn.Location = new System.Drawing.Point(12, 185);
            this.GameThreeBtn.Name = "GameThreeBtn";
            this.GameThreeBtn.Size = new System.Drawing.Size(260, 64);
            this.GameThreeBtn.TabIndex = 2;
            this.GameThreeBtn.Text = "Game Three";
            this.GameThreeBtn.UseVisualStyleBackColor = true;
            this.GameThreeBtn.Click += new System.EventHandler(this.GameThreeBtn_Click);
            // 
            // GameOneBtn
            // 
            this.GameOneBtn.Location = new System.Drawing.Point(12, 12);
            this.GameOneBtn.Name = "GameOneBtn";
            this.GameOneBtn.Size = new System.Drawing.Size(260, 64);
            this.GameOneBtn.TabIndex = 3;
            this.GameOneBtn.Text = "Game One";
            this.GameOneBtn.UseVisualStyleBackColor = true;
            this.GameOneBtn.Click += new System.EventHandler(this.GameOneBtn_Click);
            // 
            // GameTwoBtn
            // 
            this.GameTwoBtn.Location = new System.Drawing.Point(12, 100);
            this.GameTwoBtn.Name = "GameTwoBtn";
            this.GameTwoBtn.Size = new System.Drawing.Size(260, 64);
            this.GameTwoBtn.TabIndex = 4;
            this.GameTwoBtn.Text = "Game Two";
            this.GameTwoBtn.UseVisualStyleBackColor = true;
            this.GameTwoBtn.Click += new System.EventHandler(this.GameTwoBtn_Click);
            // 
            // LoadChooseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.GameTwoBtn);
            this.Controls.Add(this.GameOneBtn);
            this.Controls.Add(this.GameThreeBtn);
            this.Name = "LoadChooseForm";
            this.Text = "Choose a Save File";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GameThreeBtn;
        private System.Windows.Forms.Button GameOneBtn;
        private System.Windows.Forms.Button GameTwoBtn;

    }
}