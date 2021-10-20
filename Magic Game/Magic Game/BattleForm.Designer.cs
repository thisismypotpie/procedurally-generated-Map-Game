namespace Magic_Game
{
    partial class BattleForm
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
            this.TeamNameOneLbl = new System.Windows.Forms.Label();
            this.TeamNameTwoLbl = new System.Windows.Forms.Label();
            this.TeamTwoVictoryBtn = new System.Windows.Forms.Button();
            this.TeamOneVictoryBtn = new System.Windows.Forms.Button();
            this.TeamOneHealthLbl = new System.Windows.Forms.Label();
            this.TeamTwoHealthLbl = new System.Windows.Forms.Label();
            this.TeamTwoHealhRemainingBx = new System.Windows.Forms.TextBox();
            this.TeamOneHealthRemainingBx = new System.Windows.Forms.TextBox();
            this.VS_label = new System.Windows.Forms.Label();
            this.Draw_btn = new System.Windows.Forms.Button();
            this.Everyone_died_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TeamNameOneLbl
            // 
            this.TeamNameOneLbl.AutoSize = true;
            this.TeamNameOneLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeamNameOneLbl.Location = new System.Drawing.Point(19, 54);
            this.TeamNameOneLbl.Name = "TeamNameOneLbl";
            this.TeamNameOneLbl.Size = new System.Drawing.Size(60, 24);
            this.TeamNameOneLbl.TabIndex = 0;
            this.TeamNameOneLbl.Text = "label1";
            // 
            // TeamNameTwoLbl
            // 
            this.TeamNameTwoLbl.AutoSize = true;
            this.TeamNameTwoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeamNameTwoLbl.Location = new System.Drawing.Point(365, 54);
            this.TeamNameTwoLbl.Name = "TeamNameTwoLbl";
            this.TeamNameTwoLbl.Size = new System.Drawing.Size(60, 24);
            this.TeamNameTwoLbl.TabIndex = 1;
            this.TeamNameTwoLbl.Text = "label2";
            // 
            // TeamTwoVictoryBtn
            // 
            this.TeamTwoVictoryBtn.AutoSize = true;
            this.TeamTwoVictoryBtn.Location = new System.Drawing.Point(412, 198);
            this.TeamTwoVictoryBtn.Name = "TeamTwoVictoryBtn";
            this.TeamTwoVictoryBtn.Size = new System.Drawing.Size(75, 23);
            this.TeamTwoVictoryBtn.TabIndex = 2;
            this.TeamTwoVictoryBtn.Text = "button1";
            this.TeamTwoVictoryBtn.UseVisualStyleBackColor = true;
            this.TeamTwoVictoryBtn.Click += new System.EventHandler(this.TeamTwoVictoryBtn_Click);
            // 
            // TeamOneVictoryBtn
            // 
            this.TeamOneVictoryBtn.AutoSize = true;
            this.TeamOneVictoryBtn.Location = new System.Drawing.Point(24, 198);
            this.TeamOneVictoryBtn.Name = "TeamOneVictoryBtn";
            this.TeamOneVictoryBtn.Size = new System.Drawing.Size(75, 23);
            this.TeamOneVictoryBtn.TabIndex = 3;
            this.TeamOneVictoryBtn.Text = "button2";
            this.TeamOneVictoryBtn.UseVisualStyleBackColor = true;
            this.TeamOneVictoryBtn.Click += new System.EventHandler(this.TeamOneVictoryBtn_Click);
            // 
            // TeamOneHealthLbl
            // 
            this.TeamOneHealthLbl.AutoSize = true;
            this.TeamOneHealthLbl.Location = new System.Drawing.Point(44, 130);
            this.TeamOneHealthLbl.Name = "TeamOneHealthLbl";
            this.TeamOneHealthLbl.Size = new System.Drawing.Size(35, 13);
            this.TeamOneHealthLbl.TabIndex = 4;
            this.TeamOneHealthLbl.Text = "label3";
            // 
            // TeamTwoHealthLbl
            // 
            this.TeamTwoHealthLbl.AutoSize = true;
            this.TeamTwoHealthLbl.Location = new System.Drawing.Point(430, 130);
            this.TeamTwoHealthLbl.Name = "TeamTwoHealthLbl";
            this.TeamTwoHealthLbl.Size = new System.Drawing.Size(35, 13);
            this.TeamTwoHealthLbl.TabIndex = 5;
            this.TeamTwoHealthLbl.Text = "label4";
            // 
            // TeamTwoHealhRemainingBx
            // 
            this.TeamTwoHealhRemainingBx.Location = new System.Drawing.Point(412, 172);
            this.TeamTwoHealhRemainingBx.Name = "TeamTwoHealhRemainingBx";
            this.TeamTwoHealhRemainingBx.Size = new System.Drawing.Size(100, 20);
            this.TeamTwoHealhRemainingBx.TabIndex = 6;
            // 
            // TeamOneHealthRemainingBx
            // 
            this.TeamOneHealthRemainingBx.Location = new System.Drawing.Point(24, 172);
            this.TeamOneHealthRemainingBx.Name = "TeamOneHealthRemainingBx";
            this.TeamOneHealthRemainingBx.Size = new System.Drawing.Size(100, 20);
            this.TeamOneHealthRemainingBx.TabIndex = 7;
            // 
            // VS_label
            // 
            this.VS_label.AutoSize = true;
            this.VS_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VS_label.Location = new System.Drawing.Point(235, 97);
            this.VS_label.Name = "VS_label";
            this.VS_label.Size = new System.Drawing.Size(67, 37);
            this.VS_label.TabIndex = 8;
            this.VS_label.Text = "Vs.";
            // 
            // Draw_btn
            // 
            this.Draw_btn.Location = new System.Drawing.Point(227, 172);
            this.Draw_btn.Name = "Draw_btn";
            this.Draw_btn.Size = new System.Drawing.Size(75, 23);
            this.Draw_btn.TabIndex = 9;
            this.Draw_btn.Text = "Draw";
            this.Draw_btn.UseVisualStyleBackColor = true;
            this.Draw_btn.Click += new System.EventHandler(this.Draw_btn_Click);
            // 
            // Everyone_died_btn
            // 
            this.Everyone_died_btn.Location = new System.Drawing.Point(227, 215);
            this.Everyone_died_btn.Name = "Everyone_died_btn";
            this.Everyone_died_btn.Size = new System.Drawing.Size(75, 34);
            this.Everyone_died_btn.TabIndex = 10;
            this.Everyone_died_btn.Text = "No Survivors";
            this.Everyone_died_btn.UseVisualStyleBackColor = true;
            this.Everyone_died_btn.Click += new System.EventHandler(this.Everyone_died_btn_Click);
            // 
            // BattleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(559, 261);
            this.Controls.Add(this.Everyone_died_btn);
            this.Controls.Add(this.Draw_btn);
            this.Controls.Add(this.VS_label);
            this.Controls.Add(this.TeamOneHealthRemainingBx);
            this.Controls.Add(this.TeamTwoHealhRemainingBx);
            this.Controls.Add(this.TeamTwoHealthLbl);
            this.Controls.Add(this.TeamOneHealthLbl);
            this.Controls.Add(this.TeamOneVictoryBtn);
            this.Controls.Add(this.TeamTwoVictoryBtn);
            this.Controls.Add(this.TeamNameTwoLbl);
            this.Controls.Add(this.TeamNameOneLbl);
            this.Name = "BattleForm";
            this.Text = "BattleForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TeamNameOneLbl;
        private System.Windows.Forms.Label TeamNameTwoLbl;
        private System.Windows.Forms.Button TeamTwoVictoryBtn;
        private System.Windows.Forms.Button TeamOneVictoryBtn;
        private System.Windows.Forms.Label TeamOneHealthLbl;
        private System.Windows.Forms.Label TeamTwoHealthLbl;
        private System.Windows.Forms.TextBox TeamTwoHealhRemainingBx;
        private System.Windows.Forms.TextBox TeamOneHealthRemainingBx;
        private System.Windows.Forms.Label VS_label;
        private System.Windows.Forms.Button Draw_btn;
        private System.Windows.Forms.Button Everyone_died_btn;
    }
}