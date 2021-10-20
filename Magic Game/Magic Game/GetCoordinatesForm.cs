using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Magic_Game
{
    //Form class that gets information when adding a new city to the map.
    public partial class GetCoordinatesForm : Form
    {
        int get_x = -1;//user inputted x coordinate.
        int get_y = -1;//user inputted y coordinate.
        int wid = 0;//width of the map.  Used in exceptions handling.
        int hei = 0;//height of the map.  Used in exception handling.
        String City_name;//user intputted name of the city.

        //Defualt constructor.
        public GetCoordinatesForm()
        {
            InitializeComponent();
        }

        //Non-default constructor.
        public GetCoordinatesForm(int width, int height, ref Faction turn)
        {
            InitializeComponent();
            wid = width;
            hei = height;
            gold_lbl.Text = "Gold: " + turn.get_gold();
            Turnlbl.Text = "Turn: " + turn.get_name();
        }

        //returns the user inputted x position of the city.
        public int get_city_x()
        {
            return get_x;
        }

        //returns the user inputted y position of the city.
        public int get_city_y()
        {
            return get_y;
        }

        //returns the user inputted name of the city.
        public String get_name()
        {
            return City_name;
        }

        //This functionns triggers when the ok button is pushed.  It checks to make sure all fields are valid before proceeding.
        private void Ok_button_Click(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(X_coord.Text, out get_x);
                int.TryParse(Y_coord.Text, out get_y);
                City_name = NameOfCity.Text;
                if(get_x > wid || get_y > hei|| get_x <=0 ||get_y <= 0||City_name.Length==0)
                {
                    throw new System.Exception();
                }
                get_x--;
                get_y--;
                this.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Something went wrong, please be sure to put only positive numbers within the coordinates of the map.","Input Error",MessageBoxButtons.OK);
            }
        }

    }
}
