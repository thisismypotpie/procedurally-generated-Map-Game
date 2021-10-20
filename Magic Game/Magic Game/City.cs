using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Game
{
    //This class contains all of the information on a city in the game.
   public class City
    {
        private String name;//name of the city.
        private int x_coordinate_position;//x position of the city on the map.
        private int y_coordinate_position;//y position of the city on the map.
        private Faction Owned_by;//The faction this city is owned by.
        private bool has_moved;//Determines if any of the city options have been used this turn.
        private int production_level;
     
       #region Constructors
        //Default constuctor 
        public City()
        {
            name = null;
            x_coordinate_position = 0;
            y_coordinate_position = 0;
            Owned_by = new Faction();
            has_moved = false;
            production_level = 1;
        }

       //Non-defualt constructor
       public City(int location_x,int location_y, String city_name, bool new_moved,int prod_level)
        {
            name = city_name;
            x_coordinate_position = location_x;
            y_coordinate_position = location_y;
            Owned_by = null;
            has_moved = new_moved;
            production_level = prod_level;
        }
       //Non-default constructor
       public City(int location_x,int location_y, String city_name,ref Faction owner, bool new_moved, int prod_level)
       {
           name = city_name;
           x_coordinate_position = location_x;
           y_coordinate_position = location_y;
           //Owned_by = new Faction(ref owner);
           Owned_by = owner;
           has_moved = new_moved;
            production_level = prod_level;
       }
       //Copy constructor
       public City(ref City input)
       {
           this.name = input.name;
           this.x_coordinate_position = input.x_coordinate_position;
           this.y_coordinate_position = input.y_coordinate_position;
           //this.Owned_by = new Faction(ref input.Owned_by);
           Owned_by = input.get_owning_faction();
           this.has_moved = input.has_moved;
            this.production_level = input.production_level;
       }
        #endregion
       #region getters

       public int get_x_location()
       {
           return x_coordinate_position;
       }

       public int get_y_locations()
       {
           return y_coordinate_position;
       }

       public String get_name()
       {
           return name;
       }

       public Faction get_owning_faction()
       {
           return Owned_by;
       }

       public bool get_has_moved()
       {
           return has_moved;
       }

       public int get_production_level()
        {
            return production_level;
        }
       #endregion
       #region setters

       public void augment_has_moved(int to_change)
       {
           if(to_change == 1)
           {
               has_moved = true;
           }
           else
           {
               has_moved = false;
           }
       }

       public void change_owning_faction(ref Faction to_change)
       {
           Owned_by = to_change;
       }

       public void change_production_level(int new_level)
        {
            production_level = new_level;
        }
    }
       #endregion
}


