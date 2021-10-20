namespace Magic_Game
{
    partial class GetCoordinatesForm
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
            this.X_coord = new System.Windows.Forms.TextBox();
            this.Y_coord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Ok_button = new System.Windows.Forms.Button();
            this.NameOfCity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gold_lbl = new System.Windows.Forms.Label();
            this.Turnlbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "At Which Coordinates would you like to add your city?";
            // 
            // X_coord
            // 
            this.X_coord.Location = new System.Drawing.Point(73, 108);
            this.X_coord.Name = "X_coord";
            this.X_coord.Size = new System.Drawing.Size(100, 20);
            this.X_coord.TabIndex = 1;
            // 
            // Y_coord
            // 
            this.Y_coord.Location = new System.Drawing.Point(233, 108);
            this.Y_coord.Name = "Y_coord";
            this.Y_coord.Size = new System.Drawing.Size(100, 20);
            this.Y_coord.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Y:";
            // 
            // Ok_button
            // 
            this.Ok_button.Location = new System.Drawing.Point(164, 147);
            this.Ok_button.Name = "Ok_button";
            this.Ok_button.Size = new System.Drawing.Size(75, 23);
            this.Ok_button.TabIndex = 5;
            this.Ok_button.Text = "OK";
            this.Ok_button.UseVisualStyleBackColor = true;
            this.Ok_button.Click += new System.EventHandler(this.Ok_button_Click);
            // 
            // NameOfCity
            // 
            this.NameOfCity.Location = new System.Drawing.Point(151, 66);
            this.NameOfCity.Name = "NameOfCity";
            this.NameOfCity.Size = new System.Drawing.Size(100, 20);
            this.NameOfCity.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Name:";
            // 
            // gold_lbl
            // 
            this.gold_lbl.AutoSize = true;
            this.gold_lbl.Location = new System.Drawing.Point(59, 154);
            this.gold_lbl.Name = "gold_lbl";
            this.gold_lbl.Size = new System.Drawing.Size(35, 13);
            this.gold_lbl.TabIndex = 8;
            this.gold_lbl.Text = "Gold: ";
            // 
            // Turnlbl
            // 
            this.Turnlbl.AutoSize = true;
            this.Turnlbl.Location = new System.Drawing.Point(263, 152);
            this.Turnlbl.Name = "Turnlbl";
            this.Turnlbl.Size = new System.Drawing.Size(35, 13);
            this.Turnlbl.TabIndex = 9;
            this.Turnlbl.Text = "Turn: ";
            // 
            // GetCoordinatesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 190);
            this.Controls.Add(this.Turnlbl);
            this.Controls.Add(this.gold_lbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NameOfCity);
            this.Controls.Add(this.Ok_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Y_coord);
            this.Controls.Add(this.X_coord);
            this.Controls.Add(this.label1);
            this.Name = "GetCoordinatesForm";
            this.Text = "GetCoordinatesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox X_coord;
        private System.Windows.Forms.TextBox Y_coord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Ok_button;
        private System.Windows.Forms.TextBox NameOfCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label gold_lbl;
        private System.Windows.Forms.Label Turnlbl;
    }
}