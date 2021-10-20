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
    //This form acts as the main menu for the game.
    public partial class Form1 : Form
    {
        Form3 map_creator;//Creates a form three for the main menu.
        
        //Defualt Constructor
        public Form1()
        {
         InitializeComponent();
        }

        //Brings up the form three for when the user presses the new game button.
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            map_creator = new Form3();
            try
            {
                this.Hide();
                map_creator.ShowDialog();
                this.ShowDialog();
            }
            catch(Exception)
            {
                map_creator = new Form3();
                this.NewGameButton_Click(sender, e);
            }
        }

        //Loads the previously saved game.
        private void Form1ContinueGameButton_Click(object sender, EventArgs e)//loads the information from the text files to the game.
        {
            String path;
            String current_line = "";
            String[] extracted_numbers;
            Form2 the_game;
            Map input;
            City new_city;
            Faction new_faction;
            int[,] positions;
            int at_row = 0;
            int height = 0;
            int width = 0;
            int water = 0;
            int mountain = 0;
            int plains = 0;
            int forest = 0;
            String name;
            int x = 0;
            int y = 0;
            int gold = 0;
            int faction_ID = 0;
            int index = 0;
            int wins = 0;
            int loses = 0;
            int army_count = 0;
            int health = 0;
            int army_num = 0;
            int int_boats = 0;
            bool bool_boats = false;
            int int_gear = 0;
            bool bool_gear = false;
            int int_packs = 0;
            bool bool_packs = false;
            int moves_left = 0;
            bool bool_moved = false;
            int  int_moved;
            int grand_victories = 0;
            String turn_faction_name;
            Faction found_faction;
            int game_loaded = 0;
            int prod_level = 1;
            List<Army> found_faction_armies = new List<Army>();

            #region game_load_choose

            LoadChooseForm choose_save = new LoadChooseForm();
            choose_save.ShowDialog();
            if(choose_save.get_game_one_button_press()==true)
            {
                game_loaded = 1;
            }
            else if(choose_save.get_game_two_button_press()==true)
            {
                game_loaded = 2;
            }
            else if(choose_save.get_game_three_button_press()==true)
            {
                game_loaded = 3;
            }
            else
            {
                MessageBox.Show("Something went wrong, no game was loaded.");
                choose_save.Dispose();
                return;
            }
            choose_save.Dispose();
            #endregion

            #region LoadLand
            if(game_loaded == 1)
            {
                //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\MapSave.txt";
                path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "MapSave.txt");

            }
            else if(game_loaded == 2)
            {
                //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\MapSave2.txt";
                path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "MapSave2.txt");
            }
            else if(game_loaded == 3)
            {
                //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\MapSave3.txt";
                path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "MapSave3.txt");
            }
            else
            {
                MessageBox.Show("There was an error loading lands, game could not be loaded.");
                return;
            }
                using (StreamReader map_loader = new StreamReader(path))
                {
                    try
                    {
                        current_line = map_loader.ReadLine();
                        extracted_numbers = current_line.Split('_');
                        int.TryParse(extracted_numbers[0], out width);
                        int.TryParse(extracted_numbers[1], out height);
                        positions = new int[width, height];

                        current_line = map_loader.ReadLine();
                        extracted_numbers = current_line.Split('_');
                        int.TryParse(extracted_numbers[0], out water);
                        int.TryParse(extracted_numbers[1], out mountain);
                        int.TryParse(extracted_numbers[2], out plains);
                        int.TryParse(extracted_numbers[3], out forest);
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("This game is empty, please choose another game to play.");
                        return;
                    }
                   while(!map_loader.EndOfStream)
                   {
                           current_line = map_loader.ReadLine();
                           extracted_numbers = current_line.Split('_');
                           for(int i=0;i<extracted_numbers.Length-1;i++)
                           {
                              //MessageBox.Show((i)+" "+extracted_numbers[i-1],"",MessageBoxButtons.OK);
                               int.TryParse(extracted_numbers[i], out positions[i,at_row]);
                               //MessageBox.Show("ID: "+positions[i,at_row]+"\n Position: "+(i)+","+at_row,"",MessageBoxButtons.OK);

                           }
                           at_row++;
                   }
                   input = new Map(height, width, water, plains, mountain, forest, positions);
                   map_loader.Close();
                 /*  the_game.Show();
                   this.Hide();*/

                }
                #endregion

            #region all_faction_load
                //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\FactionSave.txt";
                path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "FactionSave.txt");
            using (StreamReader Faction_Loader = new StreamReader(path))
                {
                   // StreamReader to_pass = Faction_Loader;
                   // game_finder(ref to_pass, game_loaded, save_one_name, save_two_name, save_three_name);
                    while (!Faction_Loader.EndOfStream)
                    {
                        current_line = Faction_Loader.ReadLine();
                        extracted_numbers = current_line.Split('_');
                        if (extracted_numbers.Length >= 7)
                        {
                            name = extracted_numbers[0];
                            int.TryParse(extracted_numbers[1], out faction_ID);
                            int.TryParse(extracted_numbers[2], out gold);
                            int.TryParse(extracted_numbers[3], out wins);
                            int.TryParse(extracted_numbers[4], out loses);
                            int.TryParse(extracted_numbers[5], out army_count);
                            int.TryParse(extracted_numbers[6], out grand_victories);
                            new_faction = new Faction(name, faction_ID,gold,wins,loses,army_count, grand_victories);
                            //MessageBox.Show(new_faction.get_name());
                            input.add_to_all_factions(ref new_faction);
                        }
                    }
                    Faction_Loader.Close();
                }
                #endregion

            #region factions_in_play_load
                if (game_loaded == 1)
                {
                    //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\FactionsInPlay.txt";
                    path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "FactionsInPlay.txt");
            }
                else if (game_loaded == 2)
                {
                    //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\FactionsInPlay2.txt";
                    path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "FactionsInPlay2.txt");
            }
                else if (game_loaded == 3)
                {
                    //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\FactionsInPlay3.txt";
                    path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "FactionsInPlay3.txt");
            }
                else
                {
                    MessageBox.Show("There was an error loading factions in play, game could not be loaded.");
                    return;
                }
                using (StreamReader Faction_Loader = new StreamReader(path))
                {
                   // StreamReader to_pass = Faction_Loader;
                    //game_finder(ref to_pass, game_loaded, save_one_name, save_two_name, save_three_name);
                    while (!Faction_Loader.EndOfStream)
                    {
                        current_line = Faction_Loader.ReadLine();
                        extracted_numbers = current_line.Split('_');
                        if (extracted_numbers.Length >= 7)
                        {
                            name = extracted_numbers[0];
                            int.TryParse(extracted_numbers[1], out faction_ID);
                            int.TryParse(extracted_numbers[2], out gold);
                            int.TryParse(extracted_numbers[3], out wins);
                            int.TryParse(extracted_numbers[4], out loses);
                            int.TryParse(extracted_numbers[5], out army_count);
                            int.TryParse(extracted_numbers[6], out grand_victories);
                            new_faction = new Faction(name, faction_ID, gold, wins, loses, army_count, grand_victories);
                            input.add_faction_to_list(ref new_faction);
                        }
                    }
                    Faction_Loader.Close();
                }

                #endregion

            #region army_load
                if (game_loaded == 1)
                {
                    //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\ArmySave.txt";
                    path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "ArmySave.txt");
            }
                else if (game_loaded == 2)
                {
                    //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\ArmySave2.txt";
                    path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "ArmySave2.txt");

            }
                else if (game_loaded == 3)
                {
                    //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\ArmySave3.txt";
                    path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "ArmySave3.txt");
            }
                else
                {
                    MessageBox.Show("There was an error loading armies, game could not be loaded.");
                    return;
                }
                using(StreamReader ArmyLoad = new StreamReader(path))
                {
                    //StreamReader to_pass = ArmyLoad;
                    //game_finder(ref to_pass, game_loaded, save_one_name, save_two_name, save_three_name);
                    while(!ArmyLoad.EndOfStream)
                    {
                        current_line = ArmyLoad.ReadLine();
                        extracted_numbers = current_line.Split('_');

                        if (extracted_numbers.Length >= 9)
                        {
                            int.TryParse(extracted_numbers[0], out faction_ID);
                            int.TryParse(extracted_numbers[1], out health);
                            int.TryParse(extracted_numbers[2], out army_num);
                            int.TryParse(extracted_numbers[3], out x);
                            int.TryParse(extracted_numbers[4], out y);
                            int.TryParse(extracted_numbers[5], out int_boats);
                            int.TryParse(extracted_numbers[6], out int_gear);
                            int.TryParse(extracted_numbers[7], out int_packs);
                            int.TryParse(extracted_numbers[8], out moves_left);
                            if(int_boats == 1)
                            {
                                bool_boats = true;
                            }
                            if(int_gear == 1)
                            {
                                bool_gear = true;
                            }
                            if(int_packs == 1)
                            {
                                bool_packs = true;
                            }
                            Army new_Army = new Army(health,x,y,faction_ID,army_num,bool_boats,bool_gear,bool_packs,moves_left);

                            for(int i=0; i<input.get_number_of_factions();i++)
                            {
                                if(input.get_faction_from_list(i).get_ID() == new_Army.get_faction_ID())
                                {
                                    input.get_faction_from_list(i).add_Army_to_faction(ref new_Army);
                                    break;
                                }
                                if(i == input.get_number_of_factions()-1)
                                {
                                    MessageBox.Show("An army could not be added to any faction.");
                                }
                            }
                        }
                        bool_boats = false;
                        bool_gear = false;
                        bool_packs = false;
                    }
                    ArmyLoad.Close();
                }
                #endregion

            #region faction_turn_load
                if (game_loaded == 1)
                {
                    //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\TurnFactionSave.txt";
                    path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "TurnFactionSave.txt");
                }
                else if (game_loaded == 2)
                {
                    //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\TurnFactionSave2.txt";
                    path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "TurnFactionSave2.txt");
                }
                else if (game_loaded == 3)
                {
                    //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\TurnFactionSave3.txt";
                    path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "TurnFactionSave3.txt");
                }
                else
                {
                    MessageBox.Show("There was an error loading who's turn it is in the game, game could not be loaded.");
                    return;
                }
                using (StreamReader TurnLoad = new StreamReader(path))
                {
                    //StreamReader to_pass = TurnLoad;
                    //game_finder(ref to_pass, game_loaded, save_one_name, save_two_name, save_three_name);
                    turn_faction_name = TurnLoad.ReadLine();
                }
                #endregion

            #region CityLoad
                if (game_loaded == 1)
                {
                    //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\CitySave.txt";
                    path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "CitySave.txt");
                }
                else if (game_loaded == 2)
                {
                    //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\CitySave2.txt";
                    path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "CitySave2.txt");
                }
                else if (game_loaded == 3)
                {
                    //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\CitySave3.txt";
                    path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "CitySave3.txt");
                }
                else
                {
                    MessageBox.Show("There was an error loading cities, game could not be loaded.");
                    return;
                }
                using (StreamReader City_Loader = new StreamReader(path))
                {
                    //StreamReader to_pass = City_Loader;
                    //game_finder(ref to_pass, game_loaded, save_one_name, save_two_name, save_three_name);
                    //make a while loop to make this happen until end of file.
                    while (!City_Loader.EndOfStream)
                    {
                        current_line = City_Loader.ReadLine();
                        extracted_numbers = current_line.Split('_');
                        if (extracted_numbers.Length >= 6)
                        {
                            name = extracted_numbers[0];
                            int.TryParse(extracted_numbers[1], out x);
                            int.TryParse(extracted_numbers[2], out y);
                            for (int i = 0; i < input.get_number_of_factions(); i++)//checks for the owning faction for each city.
                            {
                                if (input.get_faction_from_list(i).get_name().CompareTo(extracted_numbers[3]) == 0)
                                {
                                    index = i;
                                    break;
                                }
                            }
                            for (int i = 0; i < input.get_faction_from_list(index).get_Army_Size(); i++)//adds of the armies to found faction so that found faction can be passed by reference.
                            {
                                found_faction_armies.Add(input.get_faction_from_list(index).get_army(i));
                            }
                            int.TryParse(extracted_numbers[4], out int_moved);
                            if (int_moved == 1)
                            {
                                bool_moved = true;
                            }
                            else
                            {
                                bool_moved = false;
                            }
                            int.TryParse(extracted_numbers[5], out prod_level);
                            //found_faction = new Faction(input.get_faction_from_list(index).get_name(),input.get_faction_from_list(index).get_ID(),input.get_faction_from_list(index).get_gold(),ref found_faction_armies, input.get_faction_from_list(index).get_victories(),input.get_faction_from_list(index).get_loses());
                            found_faction = input.get_faction_from_list(index);
                            new_city = new City(x, y, name, ref found_faction, bool_moved, prod_level);
                            //MessageBox.Show("Name: "+new_city.get_name()+"\n"+"Location: "+new_city.get_x_location()+","+new_city.get_y_locations(),"",MessageBoxButtons.OK);
                            input.add_city_to_list(ref new_city);
                        }
                    }
                    City_Loader.Close();
                    //MessageBox.Show("Cities: "+input.get_city_list_size(),"",MessageBoxButtons.OK);
                }

                #endregion

               // MessageBox.Show(input.get_number_of_all_factions().ToString());
                the_game = new Form2(ref input, turn_faction_name, game_loaded);
                this.Hide();
                the_game.ShowDialog();
                this.ShowDialog();
        }

        //Faction records
        private void button1_Click(object sender, EventArgs e)//Displays all of the faction records.
        {
            String path;
            String current_line;
            String[] extracted_numbers;
            String name;
            int faction_ID;
            int gold;
            int wins;
            int loses;
            int count;
            int grand;
            Faction new_faction;
            List<Faction> record_factions = new List<Faction>();
            List<Faction> ordered_factions = new List<Faction>();
            Faction best_faction;
            int number_of_factions = 0;
            String listing_factions="";

            #region get_factions
           // path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\FactionSave.txt";
            path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "FactionSave.txt");
            if (File.Exists(path))
            {
                //MessageBox.Show("brk");
                using (StreamReader Faction_Loader = new StreamReader(path))
                {
                    while (!Faction_Loader.EndOfStream)
                    {
                        current_line = Faction_Loader.ReadLine();
                        extracted_numbers = current_line.Split('_');
                        if (extracted_numbers.Length >= 7)
                        {
                            name = extracted_numbers[0];
                            int.TryParse(extracted_numbers[1], out faction_ID);
                            int.TryParse(extracted_numbers[2], out gold);
                            int.TryParse(extracted_numbers[3], out wins);
                            int.TryParse(extracted_numbers[4], out loses);
                            int.TryParse(extracted_numbers[5], out count);
                            int.TryParse(extracted_numbers[6], out grand);
                            new_faction = new Faction(name, faction_ID, gold, wins, loses, count, grand);
                            record_factions.Add(new_faction);
                        }
                    }
                    Faction_Loader.Close();            
            }

            #endregion
            #region faction_ordering_loops
                while (record_factions.Count > 0)
                {
                    number_of_factions = record_factions.Count;
                    best_faction = record_factions[0];
                    for (int i = 1; i < record_factions.Count; i++)
                    {
                        if (record_factions[i].get_win_percentage() > best_faction.get_win_percentage())
                        {
                            best_faction = record_factions[i];
                        }
                    }
                    ordered_factions.Add(best_faction);
                    for (int i = 0; i < record_factions.Count; i++)
                    {
                        if (best_faction.get_name().CompareTo(record_factions[i].get_name()) == 0)
                        {
                            record_factions.RemoveAt(i);
                            break;
                        }
                    }
                }
                record_factions = null;
                #endregion//Orders all factions by their success rate
            #region faction_display
                for (int i=0;i<ordered_factions.Count;i++)
                {
                    listing_factions += (i+1)+"."+ordered_factions[i].get_name() + "("+ ordered_factions[i].get_grand_victories()+") "+" (" + ordered_factions[i].get_victories() + "/" + /*(*/ordered_factions[i].get_loses()/*+ordered_factions[i].get_victories()).ToString()*/ + ")   " + ordered_factions[i].get_win_percentage() + "%" + "\n"; 
                }

                MessageBox.Show(listing_factions);
                #endregion
            }
        }

        //Makes it so all of the forms close when the user exits the form.
        private void btnExitProgram_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TourneyModeBtn_Click(object sender, EventArgs e)
        {
            TourneyForm fight_club = new TourneyForm();
            this.Hide();
            fight_club.ShowDialog();
            this.ShowDialog();
            btnExitProgram_Click(sender,e);
        }
    }
}
