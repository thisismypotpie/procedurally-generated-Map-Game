namespace Magic_Game
{
    partial class RoundFightForm
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
            this.TeamTwoBtn = new System.Windows.Forms.Button();
            this.TeamOneBtn = new System.Windows.Forms.Button();
            this.whoWonLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TeamTwoBtn
            // 
            this.TeamTwoBtn.Location = new System.Drawing.Point(284, 150);
            this.TeamTwoBtn.Name = "TeamTwoBtn";
            this.TeamTwoBtn.Size = new System.Drawing.Size(217, 122);
            this.TeamTwoBtn.TabIndex = 0;
            this.TeamTwoBtn.Text = "button1";
            this.TeamTwoBtn.UseVisualStyleBackColor = true;
            this.TeamTwoBtn.Click += new System.EventHandler(this.TeamTwoBtn_Click);
            // 
            // TeamOneBtn
            // 
            this.TeamOneBtn.Location = new System.Drawing.Point(12, 150);
            this.TeamOneBtn.Name = "TeamOneBtn";
            this.TeamOneBtn.Size = new System.Drawing.Size(217, 122);
            this.TeamOneBtn.TabIndex = 1;
            this.TeamOneBtn.Text = "button2";
            this.TeamOneBtn.UseVisualStyleBackColor = true;
            this.TeamOneBtn.Click += new System.EventHandler(this.TeamOneBtn_Click);
            // 
            // whoWonLbl
            // 
            this.whoWonLbl.AutoSize = true;
            this.whoWonLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.whoWonLbl.Location = new System.Drawing.Point(52, 49);
            this.whoWonLbl.Name = "whoWonLbl";
            this.whoWonLbl.Size = new System.Drawing.Size(402, 44);
            this.whoWonLbl.TabIndex = 2;
            this.whoWonLbl.Text = "Who wins this round?";
            // 
            // RoundFightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 284);
            this.Controls.Add(this.whoWonLbl);
            this.Controls.Add(this.TeamOneBtn);
            this.Controls.Add(this.TeamTwoBtn);
            this.Name = "RoundFightForm";
            this.Text = "RoundFightForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TeamTwoBtn;
        private System.Windows.Forms.Button TeamOneBtn;
        private System.Windows.Forms.Label whoWonLbl;
    }
}