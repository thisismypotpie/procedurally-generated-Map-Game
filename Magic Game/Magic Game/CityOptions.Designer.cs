namespace Magic_Game
{
    partial class CityOptions
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
            this.City_name_label = new System.Windows.Forms.Label();
            this.Create_Army_Btn = new System.Windows.Forms.Button();
            this.Heal_Army_Btn = new System.Windows.Forms.Button();
            this.Gold_label = new System.Windows.Forms.Label();
            this.Faction_lbl = new System.Windows.Forms.Label();
            this.Gold_Production_btn = new System.Windows.Forms.Button();
            this.Gold_Production_Lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // City_name_label
            // 
            this.City_name_label.AutoSize = true;
            this.City_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.City_name_label.Location = new System.Drawing.Point(103, 60);
            this.City_name_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.City_name_label.Name = "City_name_label";
            this.City_name_label.Size = new System.Drawing.Size(159, 31);
            this.City_name_label.TabIndex = 0;
            this.City_name_label.Text = "City Name:";
            this.City_name_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Create_Army_Btn
            // 
            this.Create_Army_Btn.Location = new System.Drawing.Point(13, 213);
            this.Create_Army_Btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Create_Army_Btn.Name = "Create_Army_Btn";
            this.Create_Army_Btn.Size = new System.Drawing.Size(131, 66);
            this.Create_Army_Btn.TabIndex = 1;
            this.Create_Army_Btn.Text = "Create Army (20G)";
            this.Create_Army_Btn.UseVisualStyleBackColor = true;
            this.Create_Army_Btn.Click += new System.EventHandler(this.Create_Army_Btn_Click);
            // 
            // Heal_Army_Btn
            // 
            this.Heal_Army_Btn.Location = new System.Drawing.Point(289, 213);
            this.Heal_Army_Btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Heal_Army_Btn.Name = "Heal_Army_Btn";
            this.Heal_Army_Btn.Size = new System.Drawing.Size(133, 66);
            this.Heal_Army_Btn.TabIndex = 2;
            this.Heal_Army_Btn.Text = "Heal_Army (1G)";
            this.Heal_Army_Btn.UseVisualStyleBackColor = true;
            this.Heal_Army_Btn.Click += new System.EventHandler(this.Heal_Army_Btn_Click);
            // 
            // Gold_label
            // 
            this.Gold_label.AutoSize = true;
            this.Gold_label.Location = new System.Drawing.Point(152, 138);
            this.Gold_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Gold_label.Name = "Gold_label";
            this.Gold_label.Size = new System.Drawing.Size(42, 17);
            this.Gold_label.TabIndex = 3;
            this.Gold_label.Text = "Gold:";
            this.Gold_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Faction_lbl
            // 
            this.Faction_lbl.AutoSize = true;
            this.Faction_lbl.Location = new System.Drawing.Point(152, 103);
            this.Faction_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Faction_lbl.Name = "Faction_lbl";
            this.Faction_lbl.Size = new System.Drawing.Size(69, 17);
            this.Faction_lbl.TabIndex = 4;
            this.Faction_lbl.Text = "Facction: ";
            // 
            // Gold_Production_btn
            // 
            this.Gold_Production_btn.Location = new System.Drawing.Point(151, 213);
            this.Gold_Production_btn.Name = "Gold_Production_btn";
            this.Gold_Production_btn.Size = new System.Drawing.Size(131, 66);
            this.Gold_Production_btn.TabIndex = 5;
            this.Gold_Production_btn.Text = "Increase Gold Production";
            this.Gold_Production_btn.UseVisualStyleBackColor = true;
            this.Gold_Production_btn.Click += new System.EventHandler(this.Gold_Production_btn_Click);
            // 
            // Gold_Production_Lbl
            // 
            this.Gold_Production_Lbl.AutoSize = true;
            this.Gold_Production_Lbl.Location = new System.Drawing.Point(152, 172);
            this.Gold_Production_Lbl.Name = "Gold_Production_Lbl";
            this.Gold_Production_Lbl.Size = new System.Drawing.Size(118, 17);
            this.Gold_Production_Lbl.TabIndex = 6;
            this.Gold_Production_Lbl.Text = "Gold Production: ";
            // 
            // CityOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 307);
            this.Controls.Add(this.Gold_Production_Lbl);
            this.Controls.Add(this.Gold_Production_btn);
            this.Controls.Add(this.Faction_lbl);
            this.Controls.Add(this.Gold_label);
            this.Controls.Add(this.Heal_Army_Btn);
            this.Controls.Add(this.Create_Army_Btn);
            this.Controls.Add(this.City_name_label);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CityOptions";
            this.Text = "CityOptions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label City_name_label;
        private System.Windows.Forms.Button Create_Army_Btn;
        private System.Windows.Forms.Button Heal_Army_Btn;
        private System.Windows.Forms.Label Gold_label;
        private System.Windows.Forms.Label Faction_lbl;
        private System.Windows.Forms.Button Gold_Production_btn;
        private System.Windows.Forms.Label Gold_Production_Lbl;
    }
}