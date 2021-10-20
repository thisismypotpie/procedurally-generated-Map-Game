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
    public partial class CityOptions : Form
    {
        private City the_city;
        private bool pushed_army_button;
        private bool pushed_heal_button;
        public CityOptions()
        {
            InitializeComponent();
            the_city = null;
        }

        public CityOptions(ref City input)
        {
            InitializeComponent();
            //the_city = new City(ref input);
            the_city = input;
            City_name_label.Text = the_city.get_name();
            Faction_lbl.Text = the_city.get_owning_faction().get_name();
            Gold_label.Text = "Gold: "+the_city.get_owning_faction().get_gold().ToString();
            Gold_Production_Lbl.Text = "Gold Production: "+input.get_production_level();
            Gold_Production_btn.Text = "Increase Gold Production \n ("+input.get_production_level()*30+"G)";//This line holds the text for the production button.
        }

        public City get_city()
        {
            return the_city;
        }

        public bool get_army_push()
        {
            return pushed_army_button;
        }

        public bool get_heal_push()
        {
            return pushed_heal_button;
        }

        //Creates Army at the specified City.
        private void Create_Army_Btn_Click(object sender, EventArgs e)
        {
            if(the_city.get_owning_faction().get_gold()<20)
            {
                MessageBox.Show("You do not have enough gold to build an army.");
                return;
            }
            for (int i = 0; i < the_city.get_owning_faction().get_Army_Size();i++)
            {
                if(the_city.get_x_location() == the_city.get_owning_faction().get_army(i).get_x_coordinate() && the_city.get_y_locations() == the_city.get_owning_faction().get_army(i).get_y_coordinate())
                {
                    MessageBox.Show("There is currently an army in the city, move that army out of the city before creating a new army.");
                    return;
                }
            }
            pushed_army_button = true;
            this.Close();
        }

        //Heals armies around a city
        private void Heal_Army_Btn_Click(object sender, EventArgs e)
        {
            if(the_city.get_owning_faction().get_gold()<1)
            {
                MessageBox.Show("You do not have enough gold to heal your armies.");
                return;
            }

            pushed_heal_button = true;
            this.Close();
        }

        //Increases the amount of gold that a city produces each turn.
        private void Gold_Production_btn_Click(object sender, EventArgs e)
        {
            int old_production = the_city.get_production_level();
            if(the_city.get_owning_faction().get_gold() < (the_city.get_production_level()*30))
            {
                MessageBox.Show("This faction does not have enough gold to upgrade its city's production level.");
            }
            else
            {
                the_city.get_owning_faction().change_gold_balance(-(the_city.get_production_level()*30));
                the_city.change_production_level(old_production+1);
                the_city.augment_has_moved(1);
                MessageBox.Show("Your city's production level has been increased to: "+the_city.get_production_level().ToString());
                this.Close();
                this.Dispose();
            }
        }
    }
}
