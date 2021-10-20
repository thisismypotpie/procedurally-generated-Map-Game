using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magic_Game
{
    public partial class MovingArmyForm : Form
    {
        Army to_use;
        String faction;
        int direction_changed;
        int width;
        int hieght;
        bool boat_buy;
        bool gear_buy;
        bool packs_buy;

     public MovingArmyForm()
        {
            InitializeComponent();
            label1.Text = " " + faction + " Army moves:";
            Health_lbl.Text = " Health: ";
            Boats_lbl.Text = " Water: no travel";
            Moves_left_lbl.Text = "Remaining moves this turn: ";
            to_use = null;
            faction = "";
            width = 0;
            Height = 0;
            direction_changed = 0 ;
            boat_buy = false;
            gear_buy = false;
            packs_buy = false;
        }

        public MovingArmyForm(ref Army input, String faction_name, int w, int h)
        {
            InitializeComponent();
            to_use = input;    
            faction = faction_name;
            width = w;
            Height = h;
            Moves_left_lbl.Text = "Remaining moves this turn: "+ input.get_moves_left().ToString();
            label1.Text = faction + " Army "+ to_use.get_army_number()+" Moves: ";
            Health_lbl.Text = "Health: " + to_use.get_health() + "/20"; 

            direction_changed = 0;
            if(input.get_has_boats()==true)
            {
                Boats_lbl.Text = "Water: Yes";
            }
            else
            {
                Boats_lbl.Text = "Water: No";
            }
            if(input.get_has_gear()==true)
            {
                gear_lbl.Text = "Mountains: Yes";
            }
            else
            {
                gear_lbl.Text = "Mountains: No";
            }
            if(input.get_has_packs()==true)
            {
                pack_lbl.Text = "Forests: Yes";
            }
            else
            {
                pack_lbl.Text = "Forests: No";
            }
            boat_buy = false;
            gear_buy = false;
            packs_buy = false;
        }

        public int get_direction_changed()
        {
            return direction_changed;
        }

        public bool get_boat_buy()
        {
            return boat_buy;
        }

        public bool get_gear_buy()
        {
            return gear_buy;
        }

        public bool get_pack_buy()
        {
            return packs_buy;
        }

        private void North_btn_Click(object sender, EventArgs e)
        {
           if(to_use.get_y_coordinate()-1<0)
           {
               MessageBox.Show("The army cannot move off of the map.");
           }
           else
           {
               
               direction_changed = 1;
               this.Close();
           }
        }

        private void East_btn_Click(object sender, EventArgs e)
        {
            if (to_use.get_x_coordinate()+1 > (width-1))
            {
                MessageBox.Show("The army cannot move off of the map.");
            }
            else
            {
                
                direction_changed = 2;
                this.Close();

            }
        }

        private void South_btn_Click(object sender, EventArgs e)
        {
            if (to_use.get_y_coordinate() + 1 > (Height-1))
            {
                MessageBox.Show("The army cannot move off of the map.");
            }
            else
            {
                
                direction_changed = 3;
                this.Close();

            }
        }

        private void West_btn_Click(object sender, EventArgs e)
        {
            if (to_use.get_x_coordinate() - 1 < 0)
            {
                MessageBox.Show("The army cannot move off of the map.");
            }
            else
            {
                direction_changed = 4;
                this.Close();

            }
        }

        private void but_boats_btn_Click(object sender, EventArgs e)
        {
            boat_buy = true;
            this.Close();
        }

        private void Buy_climbing_gear_btn_Click(object sender, EventArgs e)
        {
            gear_buy = true;
            this.Close();
        }

        private void Buy_exploration_pack_btn_Click(object sender, EventArgs e)
        {
            packs_buy = true;
            this.Close();
        }

        //Binds arrow keys to do the same thing as pushing the directional buttons.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                direction_changed = 1;
                this.Close();
                return true;
            }
            else if(keyData == Keys.Right)
            {
                direction_changed = 2;
                this.Close();
                return true;
            }
            else if(keyData == Keys.Down)
            {
                direction_changed = 3;
                this.Close();
                return true;
            }
            else if(keyData == Keys.Left)
            {
                direction_changed = 4;
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
