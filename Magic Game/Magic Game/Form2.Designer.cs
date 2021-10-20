namespace Magic_Game
{
    partial class Form2
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
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listCitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listFactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridOnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endTurnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turn_tracker_lbl = new System.Windows.Forms.Label();
            this.listArmiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.addCityToolStripMenuItem,
            this.listCitiesToolStripMenuItem,
            this.addFactionToolStripMenuItem,
            this.listFactionsToolStripMenuItem,
            this.gridOnToolStripMenuItem,
            this.listArmiesToolStripMenuItem,
            this.endTurnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1579, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.optionsToolStripMenuItem.Text = "Save Game";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // addCityToolStripMenuItem
            // 
            this.addCityToolStripMenuItem.Name = "addCityToolStripMenuItem";
            this.addCityToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.addCityToolStripMenuItem.Text = " Buy City(100G)";
            this.addCityToolStripMenuItem.Click += new System.EventHandler(this.addCityToolStripMenuItem_Click);
            // 
            // listCitiesToolStripMenuItem
            // 
            this.listCitiesToolStripMenuItem.Name = "listCitiesToolStripMenuItem";
            this.listCitiesToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.listCitiesToolStripMenuItem.Text = "List Cities";
            this.listCitiesToolStripMenuItem.Click += new System.EventHandler(this.listCitiesToolStripMenuItem_Click);
            // 
            // addFactionToolStripMenuItem
            // 
            this.addFactionToolStripMenuItem.Name = "addFactionToolStripMenuItem";
            this.addFactionToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.addFactionToolStripMenuItem.Text = "Add Faction";
            this.addFactionToolStripMenuItem.Click += new System.EventHandler(this.addFactionToolStripMenuItem_Click);
            // 
            // listFactionsToolStripMenuItem
            // 
            this.listFactionsToolStripMenuItem.Name = "listFactionsToolStripMenuItem";
            this.listFactionsToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.listFactionsToolStripMenuItem.Text = "List Factions";
            this.listFactionsToolStripMenuItem.Click += new System.EventHandler(this.listFactionsToolStripMenuItem_Click);
            // 
            // gridOnToolStripMenuItem
            // 
            this.gridOnToolStripMenuItem.Name = "gridOnToolStripMenuItem";
            this.gridOnToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.gridOnToolStripMenuItem.Text = "Grid On";
            this.gridOnToolStripMenuItem.Click += new System.EventHandler(this.gridOnToolStripMenuItem_Click);
            // 
            // endTurnToolStripMenuItem
            // 
            this.endTurnToolStripMenuItem.Name = "endTurnToolStripMenuItem";
            this.endTurnToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.endTurnToolStripMenuItem.Text = "End Turn";
            this.endTurnToolStripMenuItem.Click += new System.EventHandler(this.endTurnToolStripMenuItem_Click);
            // 
            // turn_tracker_lbl
            // 
            this.turn_tracker_lbl.AutoSize = true;
            this.turn_tracker_lbl.Location = new System.Drawing.Point(891, 9);
            this.turn_tracker_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.turn_tracker_lbl.Name = "turn_tracker_lbl";
            this.turn_tracker_lbl.Size = new System.Drawing.Size(83, 17);
            this.turn_tracker_lbl.TabIndex = 1;
            this.turn_tracker_lbl.Text = "No Factions";
            // 
            // listArmiesToolStripMenuItem
            // 
            this.listArmiesToolStripMenuItem.Name = "listArmiesToolStripMenuItem";
            this.listArmiesToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.listArmiesToolStripMenuItem.Text = "List Armies";
            this.listArmiesToolStripMenuItem.Click += new System.EventHandler(this.listArmiesToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1579, 562);
            this.Controls.Add(this.turn_tracker_lbl);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form2";
            this.Text = "Map";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.btnExitProgram_Click);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listCitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listFactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridOnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endTurnToolStripMenuItem;
        private System.Windows.Forms.Label turn_tracker_lbl;
        private System.Windows.Forms.ToolStripMenuItem listArmiesToolStripMenuItem;
    }
}