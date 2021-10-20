namespace Magic_Game
{
    partial class Form1
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
            this.Form1NewGameButton = new System.Windows.Forms.Button();
            this.Form1ContinueGameButton = new System.Windows.Forms.Button();
            this.Form1Title = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TourneyModeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Form1NewGameButton
            // 
            this.Form1NewGameButton.Location = new System.Drawing.Point(244, 121);
            this.Form1NewGameButton.Margin = new System.Windows.Forms.Padding(4);
            this.Form1NewGameButton.Name = "Form1NewGameButton";
            this.Form1NewGameButton.Size = new System.Drawing.Size(235, 113);
            this.Form1NewGameButton.TabIndex = 0;
            this.Form1NewGameButton.Text = "New Game";
            this.Form1NewGameButton.UseVisualStyleBackColor = true;
            this.Form1NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // Form1ContinueGameButton
            // 
            this.Form1ContinueGameButton.Location = new System.Drawing.Point(244, 241);
            this.Form1ContinueGameButton.Margin = new System.Windows.Forms.Padding(4);
            this.Form1ContinueGameButton.Name = "Form1ContinueGameButton";
            this.Form1ContinueGameButton.Size = new System.Drawing.Size(235, 108);
            this.Form1ContinueGameButton.TabIndex = 1;
            this.Form1ContinueGameButton.Text = "Continue Game";
            this.Form1ContinueGameButton.UseVisualStyleBackColor = true;
            this.Form1ContinueGameButton.Click += new System.EventHandler(this.Form1ContinueGameButton_Click);
            // 
            // Form1Title
            // 
            this.Form1Title.AutoSize = true;
            this.Form1Title.BackColor = System.Drawing.Color.Transparent;
            this.Form1Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Form1Title.Location = new System.Drawing.Point(137, 11);
            this.Form1Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Form1Title.Name = "Form1Title";
            this.Form1Title.Size = new System.Drawing.Size(427, 91);
            this.Form1Title.TabIndex = 2;
            this.Form1Title.Text = "Magic Map";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(275, 357);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 65);
            this.button1.TabIndex = 3;
            this.button1.Text = "Faction Records";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TourneyModeBtn
            // 
            this.TourneyModeBtn.Location = new System.Drawing.Point(604, 357);
            this.TourneyModeBtn.Name = "TourneyModeBtn";
            this.TourneyModeBtn.Size = new System.Drawing.Size(105, 79);
            this.TourneyModeBtn.TabIndex = 4;
            this.TourneyModeBtn.Text = "Tournament Mode";
            this.TourneyModeBtn.UseVisualStyleBackColor = true;
            this.TourneyModeBtn.Click += new System.EventHandler(this.TourneyModeBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Magic_Game.Properties.Resources.form1background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(795, 491);
            this.Controls.Add(this.TourneyModeBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Form1Title);
            this.Controls.Add(this.Form1ContinueGameButton);
            this.Controls.Add(this.Form1NewGameButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Magic Map Tracker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Form1NewGameButton;
        private System.Windows.Forms.Button Form1ContinueGameButton;
        private System.Windows.Forms.Label Form1Title;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button TourneyModeBtn;
    }
}

