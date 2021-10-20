namespace Magic_Game
{
    partial class FactionAddingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddFactionBtn = new System.Windows.Forms.Button();
            this.FactionList = new System.Windows.Forms.ComboBox();
            this.add_all_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add Factions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // AddFactionBtn
            // 
            this.AddFactionBtn.Location = new System.Drawing.Point(105, 141);
            this.AddFactionBtn.Name = "AddFactionBtn";
            this.AddFactionBtn.Size = new System.Drawing.Size(94, 66);
            this.AddFactionBtn.TabIndex = 3;
            this.AddFactionBtn.Text = "Add Faction";
            this.AddFactionBtn.UseVisualStyleBackColor = true;
            this.AddFactionBtn.Click += new System.EventHandler(this.AddFactionBtn_Click);
            // 
            // FactionList
            // 
            this.FactionList.FormattingEnabled = true;
            this.FactionList.Location = new System.Drawing.Point(56, 105);
            this.FactionList.Name = "FactionList";
            this.FactionList.Size = new System.Drawing.Size(200, 21);
            this.FactionList.TabIndex = 5;
            // 
            // add_all_btn
            // 
            this.add_all_btn.Location = new System.Drawing.Point(105, 226);
            this.add_all_btn.Name = "add_all_btn";
            this.add_all_btn.Size = new System.Drawing.Size(94, 23);
            this.add_all_btn.TabIndex = 6;
            this.add_all_btn.Text = "Add All Factions";
            this.add_all_btn.UseVisualStyleBackColor = true;
            this.add_all_btn.Click += new System.EventHandler(this.add_all_btn_Click);
            // 
            // FactionAddingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.add_all_btn);
            this.Controls.Add(this.FactionList);
            this.Controls.Add(this.AddFactionBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FactionAddingForm";
            this.Text = "FactionAddingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddFactionBtn;
        private System.Windows.Forms.ComboBox FactionList;
        private System.Windows.Forms.Button add_all_btn;
    }
}