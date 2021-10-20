using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //I am putting this here to use the picture box object.

namespace Magic_Game
{
    //Land class will be each land tile on the form 2 map.
    public class Land
    {
       // private PictureBox land_image;//what each land looks like.
        private bool has_city;//checks to see if there is a city at this current location.
        private int land_ID;//With this int 1=water, 2=mountain, 3=plains, 4=swamp
        private bool is_occupied;//change this datatype to a team once the team object is created.

        //Default constructor.
        public Land()
        {
            //land_image = null;
            land_ID = 0;
            has_city = false;
            is_occupied = false;
        }

        //Non default constuctor that 
        public Land(int type)
        {
            land_ID = 0;
            if(type == 1)
            {
               // land_image.Image = Properties.Resources.water;
                land_ID = 1;
            }
            else if(type == 2)
            {
                //land_image.Image = Properties.Resources.Moutain;
                land_ID = 2;
            }
            else if(type == 3)
            {
               // land_image.Image = Properties.Resources.Plains;
                land_ID = 3;
            }
            else if(type == 4)
            {
               // land_image.Image = Properties.Resources.Forest;
                land_ID = 4;
            }
            else
            {
                MessageBox.Show("Error, unknow land type, replacing with plains.\n Land ID: "+ land_ID,"Land Type Error",MessageBoxButtons.OK);
               // land_image.Image = Properties.Resources.Plains;
                land_ID = 3;
            }
            has_city = false;
            is_occupied = false;
        }

        //Copy constructor
        public Land(ref Land input_Land)
        {
                if(input_Land == null)
                {
                    MessageBox.Show("input land is null","",MessageBoxButtons.OK);
                }
                this.land_ID = input_Land.land_ID;
                this.is_occupied = input_Land.is_occupied;
                this.has_city = input_Land.has_city;
                //this.land_image = input_Land.land_image;//I have a concern that will will only create a shallow copy.    
        }

        //returns land ID.
        public int get_land_ID()
        {
            return land_ID;
        }

        public void change_land_ID(int to_change)
        {
            if(to_change <1 || to_change > 4)
            {
                MessageBox.Show("The land ID you want to change this land to does not exist.");
                return;
            }
            land_ID = to_change;
        }

    }
}
