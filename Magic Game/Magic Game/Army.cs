using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Game
{
    //This class will be an army for each of the factions.  It will be resembled in form2 as a sigil.
    public class Army
    {
        private int health;//Health of an army, maxes out at 20.
        private int x_coordinate;//x coordinate of an army.
        private int y_coordinate;//y coordinate of an army.
        private int faction_ID;//ID of the faction that owns this army.
        private int army_number;//Designated army number for each particular army.
        private bool has_boats;//determines if this army can go across water.
        private bool has_gear;//determines if this army can cross mountains.
        private bool has_packs;//determines if this army can cross forests.
       // private bool has_moved;//determines if this army has moved for this turn.
        private int moves_left;//determines how many moves an army has left.

        #region constructors
        //Default constructor for the army class.
        public Army()
        {
            health = 20;
            x_coordinate = 0;
            y_coordinate = 0;
            faction_ID = 0;
            army_number = 0;
            has_boats = false;
            has_gear = false;
            has_packs = false;
            moves_left = 3;
        }

        //Common constructor for this class.
        public Army(int new_health, int new_x, int new_y, int new_faction_ID, int new_number, bool new_boats, bool new_gear, bool new_packs, int new_moved)
        {
            health = new_health;
            x_coordinate = new_x;
            y_coordinate = new_y;
            faction_ID = new_faction_ID;
            army_number = new_number;
            has_boats = new_boats;
            has_gear = new_gear;
            has_packs = new_packs;
            moves_left = new_moved;

        }
        //Copy constructor for this class.
        public Army(ref Army to_copy)
        {
            this.health = to_copy.health;
            this.x_coordinate = to_copy.x_coordinate;
            this.y_coordinate = to_copy.y_coordinate;
            this.faction_ID = to_copy.faction_ID;
            this.army_number = to_copy.army_number;
            this.has_boats = to_copy.has_boats;
            this.has_packs = to_copy.has_packs;
            this.has_gear = to_copy.has_gear;
            this.moves_left = to_copy.moves_left;

        }
        #endregion

        #region getters
        public int get_health()
        {
            return health;
        }

        public int get_x_coordinate()
        {
            return x_coordinate;
        }

        public int get_y_coordinate()
        {
            return y_coordinate;
        }

        public int get_faction_ID()
        {
            return faction_ID;
        }

        public int get_army_number()
        {
            return army_number;
        }

        public bool get_has_boats()
        {
            return has_boats;
        }

        public bool get_has_gear()
        {
            return has_gear;
        }

        public bool get_has_packs()
        {
            return has_packs;
        }

        public int get_moves_left()
        {
            return moves_left;
        }
        #endregion

        #region setters
        //In changing any of the bools in this army, a 0 or 1 is entered.  If the input is 1 the bool is changed to true or else it is automatically false.

        public void augment_x_coordinate(int x)
        {
            x_coordinate = x;
        }

        public void augment_y_coordinate(int y)
        {
            y_coordinate = y;
        }
        //checks to see if an army is dead.  If it is it will be deleted from the map.
        public bool augment_heatlh(int health_amount)
        {
            health =health_amount;
            if(health<=0)
            {
                return true;
            }
            return false;
        }

        public void augment_boats(int to_change)
        {
            if(to_change == 1)
            {
                has_boats = true;
            }
            else
            {
                has_boats = false;
            }
        }

        public void augment_gear(int to_change)
        {
            if(to_change == 1)
            {
                has_gear = true;
            }
            else
            {
                has_gear = false;
            }
        }

        public void augment_packs(int to_change)
        {
            if(to_change == 1)
            {
                has_packs = true;
            }
            else
            {
                has_packs = false;
            }
        }

        public void augment_moves_left(int to_change)
        {
            moves_left = to_change;
        }
        #endregion

    }
}
