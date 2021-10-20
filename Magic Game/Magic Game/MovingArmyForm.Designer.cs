namespace Magic_Game
{
    partial class MovingArmyForm
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
            this.North_btn = new System.Windows.Forms.Button();
            this.East_btn = new System.Windows.Forms.Button();
            this.West_btn = new System.Windows.Forms.Button();
            this.South_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Health_lbl = new System.Windows.Forms.Label();
            this.but_boats_btn = new System.Windows.Forms.Button();
            this.Boats_lbl = new System.Windows.Forms.Label();
            this.Buy_exploration_pack_btn = new System.Windows.Forms.Button();
            this.Buy_climbing_gear_btn = new System.Windows.Forms.Button();
            this.gear_lbl = new System.Windows.Forms.Label();
            this.pack_lbl = new System.Windows.Forms.Label();
            this.Moves_left_lbl = new System.Windows.Forms.Label();
            this.GoldProductionLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // North_btn
            // 
            this.North_btn.Location = new System.Drawing.Point(227, 87);
            this.North_btn.Margin = new System.Windows.Forms.Padding(4);
            this.North_btn.Name = "North_btn";
            this.North_btn.Size = new System.Drawing.Size(100, 28);
            this.North_btn.TabIndex = 0;
            this.North_btn.Text = "North";
            this.North_btn.UseVisualStyleBackColor = true;
            this.North_btn.Click += new System.EventHandler(this.North_btn_Click);
            // 
            // East_btn
            // 
            this.East_btn.Location = new System.Drawing.Point(340, 155);
            this.East_btn.Margin = new System.Windows.Forms.Padding(4);
            this.East_btn.Name = "East_btn";
            this.East_btn.Size = new System.Drawing.Size(100, 28);
            this.East_btn.TabIndex = 1;
            this.East_btn.Text = "East";
            this.East_btn.UseVisualStyleBackColor = true;
            this.East_btn.Click += new System.EventHandler(this.East_btn_Click);
            // 
            // West_btn
            // 
            this.West_btn.Location = new System.Drawing.Point(119, 155);
            this.West_btn.Margin = new System.Windows.Forms.Padding(4);
            this.West_btn.Name = "West_btn";
            this.West_btn.Size = new System.Drawing.Size(100, 28);
            this.West_btn.TabIndex = 2;
            this.West_btn.Text = "West";
            this.West_btn.UseVisualStyleBackColor = true;
            this.West_btn.Click += new System.EventHandler(this.West_btn_Click);
            // 
            // South_btn
            // 
            this.South_btn.Location = new System.Drawing.Point(227, 226);
            this.South_btn.Margin = new System.Windows.Forms.Padding(4);
            this.South_btn.Name = "South_btn";
            this.South_btn.Size = new System.Drawing.Size(100, 28);
            this.South_btn.TabIndex = 3;
            this.South_btn.Text = "South";
            this.South_btn.UseVisualStyleBackColor = true;
            this.South_btn.Click += new System.EventHandler(this.South_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Army: ";
            // 
            // Health_lbl
            // 
            this.Health_lbl.AutoSize = true;
            this.Health_lbl.Location = new System.Drawing.Point(9, 73);
            this.Health_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Health_lbl.Name = "Health_lbl";
            this.Health_lbl.Size = new System.Drawing.Size(57, 17);
            this.Health_lbl.TabIndex = 5;
            this.Health_lbl.Text = "Health: ";
            // 
            // but_boats_btn
            // 
            this.but_boats_btn.Location = new System.Drawing.Point(22, 309);
            this.but_boats_btn.Margin = new System.Windows.Forms.Padding(4);
            this.but_boats_btn.Name = "but_boats_btn";
            this.but_boats_btn.Size = new System.Drawing.Size(100, 110);
            this.but_boats_btn.TabIndex = 6;
            this.but_boats_btn.Text = "Buy Boats (10G)";
            this.but_boats_btn.UseVisualStyleBackColor = true;
            this.but_boats_btn.Click += new System.EventHandler(this.but_boats_btn_Click);
            // 
            // Boats_lbl
            // 
            this.Boats_lbl.AutoSize = true;
            this.Boats_lbl.Location = new System.Drawing.Point(13, 155);
            this.Boats_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Boats_lbl.Name = "Boats_lbl";
            this.Boats_lbl.Size = new System.Drawing.Size(48, 17);
            this.Boats_lbl.TabIndex = 7;
            this.Boats_lbl.Text = "Boats:";
            // 
            // Buy_exploration_pack_btn
            // 
            this.Buy_exploration_pack_btn.Location = new System.Drawing.Point(335, 307);
            this.Buy_exploration_pack_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Buy_exploration_pack_btn.Name = "Buy_exploration_pack_btn";
            this.Buy_exploration_pack_btn.Size = new System.Drawing.Size(100, 110);
            this.Buy_exploration_pack_btn.TabIndex = 8;
            this.Buy_exploration_pack_btn.Text = "Buy Exploration Packs(10G)";
            this.Buy_exploration_pack_btn.UseVisualStyleBackColor = true;
            this.Buy_exploration_pack_btn.Click += new System.EventHandler(this.Buy_exploration_pack_btn_Click);
            // 
            // Buy_climbing_gear_btn
            // 
            this.Buy_climbing_gear_btn.Location = new System.Drawing.Point(175, 309);
            this.Buy_climbing_gear_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Buy_climbing_gear_btn.Name = "Buy_climbing_gear_btn";
            this.Buy_climbing_gear_btn.Size = new System.Drawing.Size(100, 110);
            this.Buy_climbing_gear_btn.TabIndex = 9;
            this.Buy_climbing_gear_btn.Text = "Buy Climbing Gear (10G)";
            this.Buy_climbing_gear_btn.UseVisualStyleBackColor = true;
            this.Buy_climbing_gear_btn.Click += new System.EventHandler(this.Buy_climbing_gear_btn_Click);
            // 
            // gear_lbl
            // 
            this.gear_lbl.AutoSize = true;
            this.gear_lbl.Location = new System.Drawing.Point(13, 183);
            this.gear_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gear_lbl.Name = "gear_lbl";
            this.gear_lbl.Size = new System.Drawing.Size(46, 17);
            this.gear_lbl.TabIndex = 10;
            this.gear_lbl.Text = "MTN: ";
            // 
            // pack_lbl
            // 
            this.pack_lbl.AutoSize = true;
            this.pack_lbl.Location = new System.Drawing.Point(9, 210);
            this.pack_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pack_lbl.Name = "pack_lbl";
            this.pack_lbl.Size = new System.Drawing.Size(48, 17);
            this.pack_lbl.TabIndex = 11;
            this.pack_lbl.Text = "FRST:";
            // 
            // Moves_left_lbl
            // 
            this.Moves_left_lbl.AutoSize = true;
            this.Moves_left_lbl.Location = new System.Drawing.Point(9, 98);
            this.Moves_left_lbl.Name = "Moves_left_lbl";
            this.Moves_left_lbl.Size = new System.Drawing.Size(57, 17);
            this.Moves_left_lbl.TabIndex = 12;
            this.Moves_left_lbl.Text = "Moves: ";
            // 
            // GoldProductionLbl
            // 
            this.GoldProductionLbl.AutoSize = true;
            this.GoldProductionLbl.Location = new System.Drawing.Point(12, 125);
            this.GoldProductionLbl.Name = "GoldProductionLbl";
            this.GoldProductionLbl.Size = new System.Drawing.Size(84, 17);
            this.GoldProductionLbl.TabIndex = 14;
            this.GoldProductionLbl.Text = "Production: ";
            // 
            // MovingArmyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(453, 432);
            this.Controls.Add(this.GoldProductionLbl);
            this.Controls.Add(this.Moves_left_lbl);
            this.Controls.Add(this.pack_lbl);
            this.Controls.Add(this.gear_lbl);
            this.Controls.Add(this.Buy_climbing_gear_btn);
            this.Controls.Add(this.Buy_exploration_pack_btn);
            this.Controls.Add(this.Boats_lbl);
            this.Controls.Add(this.but_boats_btn);
            this.Controls.Add(this.Health_lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.South_btn);
            this.Controls.Add(this.West_btn);
            this.Controls.Add(this.East_btn);
            this.Controls.Add(this.North_btn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MovingArmyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MovingArmyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button North_btn;
        private System.Windows.Forms.Button East_btn;
        private System.Windows.Forms.Button West_btn;
        private System.Windows.Forms.Button South_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Health_lbl;
        private System.Windows.Forms.Button but_boats_btn;
        private System.Windows.Forms.Label Boats_lbl;
        private System.Windows.Forms.Button Buy_exploration_pack_btn;
        private System.Windows.Forms.Button Buy_climbing_gear_btn;
        private System.Windows.Forms.Label gear_lbl;
        private System.Windows.Forms.Label pack_lbl;
        private System.Windows.Forms.Label Moves_left_lbl;
        private System.Windows.Forms.Label GoldProductionLbl;
    }
}