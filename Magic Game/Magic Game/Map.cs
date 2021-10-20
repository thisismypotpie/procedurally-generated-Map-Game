using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //I am putting this here to use the picture box object.

namespace Magic_Game
{
    /*
     This function is the map class declaration.  This class will make a map of inputted width, height, and assorted land tiles.
     */
    public class Map
    {
        private int height;//height of the map.
        private int width;//width of the map.
        private int percent_water;//percent of the map that will be water.
        private int percent_plains;//percent of the map that will be plains.
        private int percent_mountain;//percent of the map that will be mountain.
        private int percent_forest;//percent of the map that will be forest.
        private Land[,] positions;//2-D array of the entire map.
        private List<City> List_of_Cities;//List of all cities on the map.
        private List<Faction> List_of_Factions;//List of all factions on map.
        private List<Faction> All_Factions;

        #region Constructors
        //This is a default constructor for the Map class.        
        public Map()
        {
            height = 0;
            width = 0;
            percent_water = 0;
            percent_plains = 0;
            percent_mountain = 0;
            percent_forest = 0;
            positions = new Land[0, 0];
            List_of_Cities = new List<City>();
            List_of_Factions = new List<Faction>();
            All_Factions = new List<Faction>();
        }

         //This is a non default constructor for the map class.  It takes in all of the parameters for the map class. 
        public Map(int input_height, int input_width, int input_water, int input_plains, int input_mountain, int input_forest)
        {
            height = input_height;
            width = input_width;
            percent_water = input_water;
            percent_plains = input_plains;
            percent_mountain = input_mountain;
            percent_forest = input_forest;
            positions = new Land[width, height];
            List_of_Cities = new List<City>();
            List_of_Factions = new List<Faction>();
            All_Factions = new List<Faction>();

            populate_number_map();
        }

         //This is a copy constructor the the Map class. 
        public Map(ref Map to_copy)
        {
            if (to_copy == null)//checking to see if to copy is null.
            {
                MessageBox.Show("Copy to map is null.", "", MessageBoxButtons.OK);
            }
            height = to_copy.height;
            width = to_copy.width;
            percent_water = to_copy.percent_water;
            percent_plains = to_copy.percent_plains;
            percent_mountain = to_copy.percent_mountain;
            percent_forest = to_copy.percent_forest;
            positions = new Land[width, height];
            List_of_Cities = new List<City>();
            List_of_Factions = new List<Faction>();
            All_Factions = new List<Faction>();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    positions[i, j] = new Land(ref to_copy.positions[i, j]);// the current error is sent through this line. some of the lines from to_copy are null and i need
                    //to find out where the copy constructor for map is being called.
                }
            }
            for(int i=0;i<to_copy.List_of_Cities.Count;i++)
            {
                this.List_of_Cities.Add(to_copy.List_of_Cities[i]);
            }
            for (int i = 0; i < to_copy.List_of_Factions.Count;i++ )
            {
                this.List_of_Factions.Add(to_copy.List_of_Factions[i]);
            }
            for(int i = 0; i < to_copy.All_Factions.Count; i++)
            {
                this.All_Factions.Add(to_copy.All_Factions[i]);
            }
        }

        //Non-defualt constuctor for the map class.
        public Map(int input_height, int input_width, int input_water, int input_plains, int input_mountain, int input_forest, int[,] land_positions)
        {
            height = input_height;
            width = input_width;
            percent_water = input_water;
            percent_plains = input_plains;
            percent_mountain = input_mountain;
            percent_forest = input_forest;
            positions = new Land[width, height];
            List_of_Cities = new List<City>();
            List_of_Factions = new List<Faction>();
            All_Factions = new List<Faction>();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    positions[i, j] = new Land(land_positions[i, j]);
                }
            }
        }
        #endregion

        #region getters
        //This function gets the hieght of the map.         
        public int get_height()
        {
            return height;
        }

         //This function gets the width of the map.         
        public int get_width()
        {
            return width;
        }

         //This function will get the ID of the tile of a position on the map.
        public int get_position_ID(int x, int y)
        {
            return positions[x, y].get_land_ID();
        }

         //This function returns the percent water of the map.
        public int get_percent_water()
        {
            return percent_water;
        }

         //This function returns the percent mountain of the map.
        public int get_percent_mountain()
        {
            return percent_mountain;
        }

         //This function returns the percent plains of the map.
        public int get_percent_plains()
        {
            return percent_plains;
        }

         //This function returns percent forest of the map.
        public int get_percent_forest()
        {
            return percent_forest;
        }

        public int get_city_list_size()
        {
            return List_of_Cities.Count;
        }

        public City get_city_from_list(int index)
        {
            if(index > (List_of_Cities.Count-1))
            {
                MessageBox.Show("The number you have entered for get_city_from_list on map.cs is out of range.","Out of Range",MessageBoxButtons.OK);
                return null;
            }
            else
            {
                return List_of_Cities[index];
            }
        }

        public Faction get_faction_from_list(int index)
        {
            if(index > (List_of_Factions.Count-1))
            {
                MessageBox.Show("The number you have entered for get_faction_from_list on map.cs is out of range. \n "+index+" vs. "+(List_of_Factions.Count-1),"Out of Range",MessageBoxButtons.OK);
                return null;
            }
            else
            {
                return List_of_Factions[index];
            }
        }

        public int get_number_of_factions()
        {
            return List_of_Factions.Count;
        }

        public City get_city_from_list(int x, int y)
        {
            for(int i=0; i < List_of_Cities.Count;i++)
            {
                if(List_of_Cities[i].get_x_location()==x && List_of_Cities[i].get_y_locations()==y)
                {
                    return List_of_Cities[i];
                }
            }
            return null;
        }

        public Army get_army_at_location(int x, int y)
        {
            for (int i = 0; i < List_of_Factions.Count;i++)
            {
                for(int j = 0; j < List_of_Factions[i].get_Army_Size();j++)
                {
                   if(List_of_Factions[i].get_army(j).get_x_coordinate()==x && List_of_Factions[i].get_army(j).get_y_coordinate()==y)
                   {
                       return List_of_Factions[i].get_army(j);
                   }
                }
            }
            return null;
        }

        public String get_Army_faction_name(int faction_ID)
        {
            for(int i=0; i < List_of_Factions.Count;i++)
            {
                if(List_of_Factions[i].get_ID().Equals(faction_ID))
                {
                    return List_of_Factions[i].get_name();
                }
            }
            return null;
        }

        public int get_number_of_all_factions()
        {
            return All_Factions.Count;
        }

        public Faction get_faction_from_all_factions(int index)
        {
            for(int i=0; i < All_Factions.Count; i++)
            {
                //MessageBox.Show(All_Factions[i].get_ID().ToString() + "vs. "+index);
                if(All_Factions[i].get_ID().ToString().CompareTo((index+1).ToString())==0)
                {
                    return All_Factions[i];
                }
            }
            return null;
        }

        public Land get_land(int x, int y)
        {
            return positions[x, y];
        }
        #endregion

        //This functions populates the map with different kinds of land in a semi-random pattern.
        private void populate_number_map()
        {

            #region step_zero
            /*
             STEP ZERO: FILL IN EVERYTHING IF ONE LAND TYPE IS 100%.
             */
             if(percent_water==100 || percent_mountain==100 || percent_plains==100 || percent_forest==100)
             {
                 if(percent_water==100)
                 {
                     for(int i=0;i < width;i++)
                     {
                         for(int j=0; j < height;j++)
                         {
                             positions[i, j] = new Land(1);
                         }
                     }
                     return;
                 }
                 else if(percent_mountain==100)
                 {
                     for (int i = 0; i < width; i++)
                     {
                         for (int j = 0; j < height; j++)
                         {
                             positions[i, j] = new Land(2);
                         }
                     }
                     return;
                 }
                 else if(percent_plains==100)
                 {
                     for (int i = 0; i < width; i++)
                     {
                         for (int j = 0; j < height; j++)
                         {
                             positions[i, j] = new Land(3);
                         }
                     }
                     return;
                 }
                 else if(percent_forest==100)
                 {
                     for (int i = 0; i < width; i++)
                     {
                         for (int j = 0; j < height; j++)
                         {
                             positions[i, j] = new Land(4);
                         }
                     }
                     return;
                 }
                 else 
                 {
                     MessageBox.Show("The functions says that one land type is 100% however it was unable to distinguish which one.  Going to regular function.","Error",MessageBoxButtons.OK);
                 }
             }
             /*
              END OF STEP ZERO
              */
            #endregion

            #region step_one
             /*
             STEP ONE: DETERMINE BODIES OF LAND AND NUMBER OF TILES FOR EACH LAND TYPE.
             */
            int remaining_water_tiles = Convert.ToInt32((((float)percent_water / 100) * (float)(width * height)));
            int remaining_moutain_tiles_ = Convert.ToInt32((((float)percent_mountain / 100) * (float)(width*height)));
            int remaining_forest_tiles = Convert.ToInt32((((float)percent_forest / 100) * (float)(width*height)));
           // MessageBox.Show("Total Tiles: " + width * height+"\n"+"water_tiles: "+remaining_water_tiles+"\n"+"mountain tiles: "+remaining_moutain_tiles_+"\n"+"forest tiles: "+ remaining_forest_tiles,"Total Tiles", MessageBoxButtons.OK);
            int bodies_of_water = 0;
            int bodies_of_mountain = 0;
            int bodies_of_forest = 0;

            while ((bodies_of_water * 20) < percent_water)
            {
                bodies_of_water++;
            }
            while((bodies_of_mountain * 20)<percent_mountain)
            {
                bodies_of_mountain++;
            }
            while((bodies_of_forest * 20)< percent_forest)
            {
                bodies_of_forest++;
            }
           // MessageBox.Show("Bodies of water: "+ bodies_of_water +"\n"+"Bodies of mountains: "+bodies_of_mountain+"\n"+"Bodies of forests:"+bodies_of_forest ,"Bodies",MessageBoxButtons.OK);
            /*
             END OF STEP ONE
             */
             #endregion

            #region step_two
            /* 
             STEP TWO: PLANT ONE TILE FOR EACH LAND BODY
             */
            int[,] current_tile_placings = new int[bodies_of_water+bodies_of_mountain+bodies_of_forest,3];//1=x coordinate of the current placement of a body, 2=ycoordinate of the current placement body. 3=land type
            Random rand = new Random();
            int x = 0;
            int y = 0;

            for (int i = 0; i < bodies_of_water + bodies_of_mountain + bodies_of_forest;i++)
            {
                if(i<bodies_of_water)
                {
                    current_tile_placings[i, 2] = 1;
                    //MessageBox.Show("Adding water at body number: " + i, "Adding Body Land ID", MessageBoxButtons.OK);
                }
                else if(i>=bodies_of_water && i< bodies_of_water+bodies_of_mountain)
                {
                    current_tile_placings[i, 2] = 2;
                    //MessageBox.Show("Adding mountain at body number: " + i, "Adding Body Land ID", MessageBoxButtons.OK);
                }
                else if(i>=bodies_of_water+bodies_of_mountain)
                {
                    current_tile_placings[i, 2] = 4;
                    //MessageBox.Show("Adding forest at body number: " + i, "Adding Body Land ID", MessageBoxButtons.OK);
                }
            }


                for (int i = 0; i < bodies_of_water + bodies_of_mountain + bodies_of_forest; i++)
                {
                    x = rand.Next(0, width - 1);
                    y = rand.Next(0, height - 1);
                    if (positions[x, y] == null)
                    {
                        positions[x,y]=new Land(current_tile_placings[i,2]);
                        current_tile_placings[i, 0] = x;
                        current_tile_placings[i, 0] = y;
                      //  MessageBox.Show("Creating new land at position: "+x+","+y,"New Land",MessageBoxButtons.OK);
                    }
                    else
                    {
                        --i;
                    }
                }
                
               /* //The following loop has been introduced for testing purposes so that I can see the entire map.
                for(int i=0;i<height;i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if(positions[i,j]==null)
                        {
                            positions[i, j] = new Land(3);
                        }
                    }
                }*/



            /*
             END OF STEP TWO
             */
            #endregion

            #region step_three
            /*
             STEP THREE:  DISCOVER WHICH DIRECTIONS ARE AVAILABLE FOR PLACEMENT FOR EACH BODY.
             */

            bool[] directions_available = new bool[4] {false,false,false,false};//0=north, 1=east, 2=south, 3=west
            bool direction_is_free = false;
            int direction_chosen = 0;
 

            while(remaining_water_tiles >0 || remaining_moutain_tiles_>0 || remaining_forest_tiles>0)
            {
                //MessageBox.Show("Starting new iteration of body addition."+(bodies_of_water+bodies_of_mountain+bodies_of_forest),"New Array Traversal",MessageBoxButtons.OK);
                for (int i = 0; i < (bodies_of_water + bodies_of_mountain + bodies_of_forest); i++)
                {
                    //MessageBox.Show("Starting new iteration of for loop: i= "+i,"New main for loop traversal.",MessageBoxButtons.OK);
                    if (current_tile_placings[i, 2] == 1 && remaining_water_tiles > 0 || current_tile_placings[i, 2] == 2 && remaining_moutain_tiles_ > 0 || current_tile_placings[i, 2] == 4 && remaining_forest_tiles > 0)
                    {
                        #region Direction_Determiner
                        if (current_tile_placings[i, 1] - 1 >= 0)//checking for up.  Checking to makes sure I won't go out of bounds and that the tile above the curr position is free.
                        {
                            if (positions[current_tile_placings[i, 0], current_tile_placings[i, 1] - 1] == null)
                            {
                                directions_available[0] = true;
                            }
                        }
                        if (current_tile_placings[i, 0] + 1 < width)//checking for right position.
                        {
                            if (positions[current_tile_placings[i, 0] + 1, current_tile_placings[i, 1]] == null)
                            {
                                directions_available[1] = true;
                            }
                        }
                        if (current_tile_placings[i, 1] + 1 < height)//checking for down position.
                        {
                            if (positions[current_tile_placings[i, 0], current_tile_placings[i, 1] + 1] == null)
                            {
                                directions_available[2] = true;
                            }
                        }
                        if (current_tile_placings[i, 0] - 1 >= 0)
                        {
                            if (positions[current_tile_placings[i, 0] - 1, current_tile_placings[i, 1]] == null)
                            {
                                directions_available[3] = true;
                            }
                        }
                        #endregion

                        #region All_Directions_Taken_Contingency
                        if (directions_available[0] == false && directions_available[1] == false && directions_available[2] == false && directions_available[3] == false)
                        {
                            //MessageBox.Show("All Direction Taken Contingency triigered.","ADTC",MessageBoxButtons.OK);
                            while (positions[x, y] != null)//refer to step two for definitions of x,y,and rand.
                            {
                                x = rand.Next(0, width - 1);
                                y = rand.Next(0, height - 1);
                            }
                            positions[x, y] = new Land(current_tile_placings[i, 2]);
                            current_tile_placings[i, 0] = x;
                            current_tile_placings[i, 1] = y;
                            if (current_tile_placings[i, 2] == 1)
                            {
                                remaining_water_tiles--;
                            }
                            else if (current_tile_placings[i, 2] == 2)
                            {
                                remaining_moutain_tiles_--;
                            }
                            else if (current_tile_placings[i, 2] == 4)
                            {
                                remaining_forest_tiles--;
                            }
                        }
                        #endregion

                        #region Direcional_Tile_Placer
                        else
                        {
                            while (direction_is_free == false)
                            {
                                direction_chosen = rand.Next(0, 4);
                                if (directions_available[direction_chosen] == true)
                                {
                                    if (direction_chosen == 0)
                                    {
                                       // MessageBox.Show("i: "+i+"\n"+"current_placings 0: "+current_tile_placings[i,0]+"\n"+"current_placings 1: "+(current_tile_placings[i,1]-1)+"\n"+current_tile_placings[i,2],"Up directions coordinates",MessageBoxButtons.OK);
                                        positions[current_tile_placings[i, 0], current_tile_placings[i, 1] - 1] = new Land(current_tile_placings[i, 2]);
                                        current_tile_placings[i, 1]--;
                                    }
                                    else if (direction_chosen == 1)
                                    {
                                       // MessageBox.Show("i: " + i + "\n" + "current_placings 0: " + (current_tile_placings[i, 0]+1) + "\n" + "current_placings 1: " + current_tile_placings[i, 1] + "\n" + current_tile_placings[i, 2], "Right directions coordinates", MessageBoxButtons.OK);
                                        positions[current_tile_placings[i, 0] + 1, current_tile_placings[i, 1]] = new Land(current_tile_placings[i, 2]);
                                        current_tile_placings[i, 0]++;
                                    }
                                    else if (direction_chosen == 2)
                                    {
                                       // MessageBox.Show("i: " + i + "\n" + "current_placings 0: " + current_tile_placings[i, 0] + "\n" + "current_placings 1: " + (current_tile_placings[i, 1] + 1) + "\n" + current_tile_placings[i, 2], "Down directions coordinates", MessageBoxButtons.OK);
                                        positions[current_tile_placings[i, 0], current_tile_placings[i, 1] + 1] = new Land(current_tile_placings[i, 2]);
                                        current_tile_placings[i, 1]++;
                                    }
                                    else if (direction_chosen == 3)
                                    {
                                        //MessageBox.Show("i: " + i + "\n" + "current_placings 0: " + (current_tile_placings[i, 0]-1) + "\n" + "current_placings 1: " + current_tile_placings[i, 1] + "\n" + current_tile_placings[i, 2], "Left directions coordinates", MessageBoxButtons.OK);
                                        positions[current_tile_placings[i, 0] - 1, current_tile_placings[i, 1]] = new Land(current_tile_placings[i, 2]);
                                        current_tile_placings[i, 0]--;
                                    }
                                    else
                                    {
                                        MessageBox.Show("There is a problem with the direction that was chosen, none are available.", "Directional Error", MessageBoxButtons.OK);
                                    }

                                    if (current_tile_placings[i, 2] == 1)
                                    {
                                        remaining_water_tiles--;
                                    }
                                    if (current_tile_placings[i, 2] == 2)
                                    {
                                        remaining_moutain_tiles_--;
                                    }
                                    if (current_tile_placings[i, 2] == 4)
                                    {
                                        remaining_forest_tiles--;
                                    }
                                    direction_is_free = true;
                                }
                            }
                            direction_is_free = false;
                        }
                        #endregion
                    }
                    for (int k = 0; k < 4; k++)
                    {
                        directions_available[k] = false;
                    }
                }
            }

            #region Plains_Filler
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (positions[i, j] == null)
                    {
                        positions[i, j] = new Land(3);
                    }
                }
            }
            #endregion

            /*
             END OF STEP THREE.
             */
            #endregion
        }


        #region add_info_to_map
        //Adds a city to the list of cites on the map.
        public void add_city_to_list(ref City to_add)
        {
            //City adding = new City(to_add.get_x_location(), to_add.get_y_locations(), to_add.get_name());
            List_of_Cities.Add(to_add);
        }

        public void add_faction_to_list(ref Faction to_add)
        {
            List_of_Factions.Add(to_add);
        }

        public void add_to_all_factions(ref Faction to_add)
        {
           // MessageBox.Show(to_add.get_name());
            All_Factions.Add(to_add);
        }
        #endregion

        public bool check_for_duplicate_factions(String new_faction_name)
        {
            for(int i=0; i < List_of_Factions.Count;i++)
            {
                if(new_faction_name.ToLower().CompareTo(List_of_Factions[i].get_name().ToLower())==0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool check_for_duplicate_cities(String new_city_name)
        {
            for(int i=0;i<List_of_Cities.Count;i++)
            {
                if(new_city_name.ToLower().CompareTo(List_of_Cities[i].get_name().ToLower())==0)
                {
                    return true;
                }
            }
            return false;
        }

        public void remove_faction_from_play(int position)
        {
            List_of_Factions.RemoveAt(position);
        }
    }
}
