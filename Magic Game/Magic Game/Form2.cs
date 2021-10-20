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
    //This form is what the user will use to interact with the map.  It will show land, cities, and armies as the user plays the game.
    public partial class Form2 : Form
    {
        private Map world_map;//Contains a number matrix map for the form to display.
        private LoadForm landtracker;//shows progress of the map as it loads the land sprites.
        private bool grid_on = false;//Determines whether or not the grid is on display for the user.
        private PictureBox[,] army_grid;//Grid of pictureboxes for all armies on the map.  Either null or populated by a picturebox.
        private PictureBox[,] city_grid;//Grid of pictureboxes for all cities on the map.  Either null or populated by a picturebox.
        private Faction player_turn;//Faction who's turn it is.
        private PictureBox complete_grid = null;//picturebox for the entire grid.
        private PictureBox complete_map = null;//picturebox for the entire map.
        private int game_save_number = 0;//tells the program which game to save to.

        #region constructors
        //Default constructor for form 2.
        public Form2()
        {
            InitializeComponent();
            //List_of_Cities = new List<City>();
        }
        //Constructor of form2 for a new game.
        public Form2(ref Map input_map, int save)
        {
            InitializeComponent();
            world_map = new Map(ref input_map);
            //grid = new Label[world_map.get_height()];
            army_grid = new PictureBox[world_map.get_width(), world_map.get_height()];
            city_grid = new PictureBox[world_map.get_width(), world_map.get_height()];
            game_save_number = save;
            player_turn = null;
            Populate_Map();
            Faction owner;
            Army found_army;
            for(int i=0;i<world_map.get_city_list_size();i++)
            {
                owner = world_map.get_city_from_list(i).get_owning_faction();
                Add_Cities(world_map.get_city_from_list(i).get_x_location(),world_map.get_city_from_list(i).get_y_locations(),ref owner);
            }
            for(int i=0; i < world_map.get_number_of_factions();i++)
            {
                for(int j=0; j < world_map.get_faction_from_list(i).get_Army_Size();j++)
                {
                    found_army = world_map.get_faction_from_list(i).get_army(j);
                    this.add_army_to_map(ref found_army,world_map.get_position_ID(found_army.get_x_coordinate(),found_army.get_y_coordinate()));
                }
            }
        }

        //Constructor for form 2 that takes a map and then runs the function populate mape so each land tile shows up on the map.  Used for saved game.
        public Form2(ref Map input_map, String turn_faction_name, int save)
        {
            InitializeComponent();
            //MessageBox.Show("Constructor "+input_map.get_number_of_all_factions().ToString());
            world_map = new Map(ref input_map);
            //grid = new Label[world_map.get_height()];
            army_grid = new PictureBox[world_map.get_width(), world_map.get_height()];
            city_grid = new PictureBox[world_map.get_width(), world_map.get_height()];
            game_save_number = save;
            for (int i = 0; i < world_map.get_number_of_factions(); i++)
            {
                if (turn_faction_name.CompareTo(world_map.get_faction_from_list(i).get_name()) == 0)
                {
                    player_turn = world_map.get_faction_from_list(i);
                    turn_tracker_lbl.Text = "Turn: " + player_turn.get_name();
                    break;
                }
            }
            Populate_Map();


            Faction owner;
            for (int i = 0; i < world_map.get_city_list_size(); i++)
            {
                owner = world_map.get_city_from_list(i).get_owning_faction();
                Add_Cities(world_map.get_city_from_list(i).get_x_location(), world_map.get_city_from_list(i).get_y_locations(), ref owner);
            }
            Army found_army;
            for (int i = 0; i < world_map.get_number_of_factions(); i++)
            {
                for (int j = 0; j < world_map.get_faction_from_list(i).get_Army_Size(); j++)
                {
                    found_army = world_map.get_faction_from_list(i).get_army(j);
                    if(found_army !=null)
                    {
                        this.add_army_to_map(ref found_army, world_map.get_position_ID(found_army.get_x_coordinate(), found_army.get_y_coordinate()));
                    }
                    else
                    {
                        MessageBox.Show("There was an error with loading the armies of faction"+ world_map.get_faction_from_list(i).get_name()+", lowering army count to fix this problem.");
                        world_map.get_faction_from_list(i).change_army_count(world_map.get_faction_from_list(i).get_total_number_of_armies_count()- 1);
                        //break;
                    }
                }
            }
            //create_grid();
        }
        #endregion

        #region add_sptires_to_the_map
        //This function populates the map of a form2.
        private void Populate_Map()
        {
            Image water =(Image)(new Bitmap(Properties.Resources.water,new Size(50,50)));
            Image Mountain = (Image)(new Bitmap(Properties.Resources.Moutain, new Size(50, 50)));
            Image Plains = (Image)(new Bitmap(Properties.Resources.Plains, new Size(50,50)));
            Image Forest = (Image)(new Bitmap(Properties.Resources.Forest, new Size(50,50)));
            Bitmap complete_map = new Bitmap((world_map.get_width()*50),(world_map.get_height()*50));
            Graphics g = Graphics.FromImage(complete_map);
            landtracker = new LoadForm(world_map.get_height(),world_map.get_width());

            #region creating_complete_map
            for (int i=0; i < world_map.get_width();i++)
            {
                for(int j=0; j < world_map.get_height();j++)
                {
                    if(world_map.get_position_ID(i,j)==1)
                    {
                        g.DrawImage(water,(i*50),(j*50));
                    }
                    else if(world_map.get_position_ID(i,j)==2)
                    {
                        g.DrawImage(Mountain,(i*50),(j*50));
                    }
                    else if(world_map.get_position_ID(i,j)==4)
                    {
                        g.DrawImage(Forest,(i*50),(j*50));
                    }
                    else
                    {
                        g.DrawImage(Plains,(i*50),(j*50));
                    }
                    landtracker.update_bar();
                }
            }
            complete_map.Save("complete_map",System.Drawing.Imaging.ImageFormat.Jpeg);
            this.complete_map = new PictureBox();
            this.complete_map.Image = complete_map;
            this.complete_map.ClientSize = new Size((world_map.get_width()*50),(world_map.get_height()*50));
            this.complete_map.Location = new System.Drawing.Point(20,20);

            this.Controls.Add(this.complete_map);
            this.complete_map.Show();
            #endregion//Creates the image by splicing together a bunch or images to form one image to put into one picturebox to improve performance.
            landtracker.Dispose();
            landtracker = null;

            //Grid is created after the complete map is created.
            create_grid(ref complete_map);
        }

        //Adds a city sprite on the given coordinate location of the two int parameters. Changes the land id to plains if built on forest or mountains.
        private void Add_Cities(int add_city_x, int add_city_y, ref Faction building_faction)
        {
            world_map.get_land(add_city_x, add_city_y).change_land_ID(3);
            city_grid[add_city_x, add_city_y] = new PictureBox();
            PictureBox new_city = city_grid[add_city_x, add_city_y];
            new_city.ClientSize = new Size(50, 50);
            new_city.SizeMode = PictureBoxSizeMode.StretchImage;
            new_city.Image = Properties.Resources.City;
            new_city.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            if (building_faction.get_ID() == player_turn.get_ID())
            {
                new_city.BackgroundImage = Properties.Resources.Highlight;
            }
            else
            {
                new_city.BackgroundImage = Properties.Resources.Plains;
            }
            new_city.Location = new System.Drawing.Point((((add_city_x * 50))+ 21)-this.HorizontalScroll.Value, (((add_city_y * 50)) + 20)-this.VerticalScroll.Value);//add locations numbers here.
            new_city.Click += (sender, EventArgs) => { city_click(sender, EventArgs, add_city_x, add_city_y); };
            this.Controls.Add(new_city);
            new_city.Show();
            new_city.BringToFront();
            new_city.Update();
            new_city.Refresh();
            this.Update();
            this.Refresh();

        }

        //Adds an army on the map.
        private void add_army_to_map(ref Army to_add, int land_ID)
        {
            army_grid[to_add.get_x_coordinate(), to_add.get_y_coordinate()] = new PictureBox();
            PictureBox new_army = army_grid[to_add.get_x_coordinate(), to_add.get_y_coordinate()];
            int faction_name = 0;
            String name_to_send = "";
            Army adding = to_add;
            new_army.Width = 36;
            new_army.Height = 36;
            new_army.ClientSize = new Size(36, 36);
            new_army.SizeMode = PictureBoxSizeMode.StretchImage;
            new_army.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            new_army.Click += (sender, EventArgs) => { Army_click(sender, EventArgs, ref adding, name_to_send); };

            #region land_background
            if (land_ID == 1)
            {
                new_army.BackgroundImage = Properties.Resources.water;
            }
            else if (land_ID == 2)
            {
                new_army.BackgroundImage = Properties.Resources.Moutain;
            }
            else if (land_ID == 3)
            {
                new_army.BackgroundImage = Properties.Resources.Plains;
            }
            else if (land_ID == 4)
            {
                new_army.BackgroundImage = Properties.Resources.Forest;
            }
            else
            {
                new_army.BackgroundImage = Properties.Resources.Plains;
            }
            #endregion

            //contains assignment for each sigil sprite by name.  If you make a new faction, add the name and sprite here.
            #region army_background

            for (int i = 0; i < world_map.get_number_of_factions(); i++)
            {
                if (world_map.get_faction_from_list(i).get_ID() == to_add.get_faction_ID())
                {
                    faction_name = world_map.get_faction_from_list(i).get_ID();
                    name_to_send = world_map.get_faction_from_list(i).get_name();
                    break;
                }
            }

            if (faction_name == 1)
            {
                new_army.BackgroundImage = Properties.Resources.Auxilex_Sigil;
            }
            else if (faction_name == 2)
            {
                new_army.BackgroundImage = Properties.Resources.Azorius_Sigil;
            }
            else if (faction_name == 3)
            {
                new_army.BackgroundImage = Properties.Resources.Boros_Sigil;
            }
            else if (faction_name == 4)
            {
                new_army.BackgroundImage = Properties.Resources.Dimir_Sigil;
            }
            else if (faction_name == 5)
            {
                new_army.BackgroundImage = Properties.Resources.Drogskol_Sigil;
            }
            else if (faction_name == 6)
            {
                new_army.BackgroundImage = Properties.Resources.Drohl_Tide_Sigil;
            }
            else if (faction_name == 7)
            {
                new_army.BackgroundImage = Properties.Resources.Firefolk_Sigil;
            }
            else if (faction_name == 8)
            {
                new_army.BackgroundImage = Properties.Resources.Glint_Leaf_Symbol;
            }
            else if (faction_name == 9)
            {
                new_army.BackgroundImage = Properties.Resources.Golgari_Sigil;
            }
            else if (faction_name == 10)
            {
                new_army.BackgroundImage = Properties.Resources.Gruul_Sigil;
            }
            else if (faction_name == 11)
            {
                new_army.BackgroundImage = Properties.Resources.Howlpack_Sigil;
            }
            else if (faction_name == 12)
            {
                new_army.BackgroundImage = Properties.Resources.Hruktar_Sigil;
            }
            else if (faction_name == 13)
            {
                new_army.BackgroundImage = Properties.Resources.Immutius_Sigil;
            }
            else if (faction_name == 14)
            {
                new_army.BackgroundImage = Properties.Resources.Izzet_Sigil;
            }
            else if (faction_name == 15)
            {
                new_army.BackgroundImage = Properties.Resources.Lex_Imperium_Sigil;
            }
            else if (faction_name == 16)
            {
                new_army.BackgroundImage = Properties.Resources.Nimium_Sigil;
            }
            else if (faction_name == 17)
            {
                new_army.BackgroundImage = Properties.Resources.Orzhov_Sigil;
            }
            else if (faction_name == 18)
            {
                new_army.BackgroundImage = Properties.Resources.Parcorium_Sigil;
            }
            else if (faction_name == 19)
            {
                new_army.BackgroundImage = Properties.Resources.Phyrexian_Sigil;
            }
            else if (faction_name == 20)
            {
                new_army.BackgroundImage = Properties.Resources.Rakdos_Sigil;
            }
            else if (faction_name == 21)
            {
                new_army.BackgroundImage = Properties.Resources.Roxveard_Sigil;
            }
            else if (faction_name == 22)
            {
                new_army.BackgroundImage = Properties.Resources.Selesnya_Sigil;
            }
            else if (faction_name == 23)
            {
                new_army.BackgroundImage = Properties.Resources.Simic_Sigil;
            }
            else if(faction_name == 24)
            {
                new_army.BackgroundImage = Properties.Resources.Vallatus_Sigil;
            }
            else if(faction_name == 25)
            {
                new_army.BackgroundImage = Properties.Resources.Zeplitor_Sigil;
            }
            else
            {
                MessageBox.Show("The faction :" + faction_name + " has no sprite.");
            }
            #endregion

            new_army.Location = new System.Drawing.Point(((to_add.get_x_coordinate() * 50) + 27)-this.HorizontalScroll.Value,((to_add.get_y_coordinate() * 50) + 27)-this.VerticalScroll.Value); //adjust this as neccesarry.
            this.Controls.Add(new_army);
            new_army.BringToFront();
            new_army.Show();
            //MessageBox.Show("ARmy being added");
        }
        //Removes an army sprite from the map.
        private void remove_army_from_map(int x, int y)
        {
            if (army_grid[x, y] != null)
            {
                army_grid[x, y].Hide();
                army_grid[x, y].Dispose();
                army_grid[x, y] = null;
            }
            else
            {
                MessageBox.Show("The army spot that army grid tried to delete is null.");
            }
        }

        //creates a grid for the user to user on the map by using the complete map image and adding graphics to it to create a duplicate with a grid on it.
        private void create_grid(ref Bitmap Background)
        {
            Bitmap grid_numbers =new Bitmap((world_map.get_width()*50), (world_map.get_height()*50));
            Graphics g = Graphics.FromImage(grid_numbers);
            RectangleF text;
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            g.DrawImage(Background,0,0);
            for (int i = 0; i < world_map.get_width();i++)
            {
                for(int j = 0; j < world_map.get_height();j++)
                {
                    g.DrawRectangle(Pens.Black,i*50,j*50,50,50);
                    text = new RectangleF((i * 50)+3, (j * 50) + 20, 45, 15);
                    g.FillRectangle(Brushes.Gray,text);
                    g.DrawString("("+(i+1)+","+(j+1)+")",new Font("Ariel",7),Brushes.Black,text,sf);
                    g.Flush();
                }
            }
            grid_numbers.Save("grid_map", System.Drawing.Imaging.ImageFormat.Jpeg);
            complete_grid = new PictureBox();
            complete_grid.ClientSize = new Size((world_map.get_width()*50),(world_map.get_height()*50));
            complete_grid.Image = grid_numbers;
            complete_grid.Location = new System.Drawing.Point(20,20);
            this.Controls.Add(complete_grid);
        }
        #endregion

        #region Menu_options
        //Saves the game when the menu item save game is pressed.
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "";
            #region map_save
            if(game_save_number == 1)
            {
                //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\MapSave.txt";
                path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "MapSave.txt");
            }
            else if(game_save_number == 2)
            {
                //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\MapSave2.txt";
                path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "MapSave2.txt");
            }
            else if(game_save_number == 3)
            {
                //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\MapSave3.txt";
                path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "MapSave3.txt");
            }
            else
            {
                MessageBox.Show("There was an error saving the map, game not saved.");
                return;
            }
            if (File.Exists(path))
            {
                File.WriteAllText(path, String.Empty);
                using (StreamWriter SaveFileTo = File.CreateText(path))
                {
                    SaveFileTo.Write(world_map.get_width());
                    SaveFileTo.Write("_");
                    SaveFileTo.Write(world_map.get_height());
                    SaveFileTo.WriteLine();
                    SaveFileTo.Write(world_map.get_percent_water());
                    SaveFileTo.Write("_");
                    SaveFileTo.Write(world_map.get_percent_mountain());
                    SaveFileTo.Write("_");
                    SaveFileTo.Write(world_map.get_percent_plains());
                    SaveFileTo.Write("_");
                    SaveFileTo.Write(world_map.get_percent_forest());
                    //SaveFileTo.WriteLine();
                    for (int i = 0; i < world_map.get_height(); i++)//might have to switch width and height if this does not store properly.
                    {
                        SaveFileTo.WriteLine();
                        for (int j = 0; j < world_map.get_width(); j++)
                        {
                            SaveFileTo.Write(world_map.get_position_ID(j, i));
                            SaveFileTo.Write("_");
                        }
                    }
                    SaveFileTo.Close();
                }
            #endregion
            #region city_Save
                if (game_save_number == 1)
                {
                    //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\CitySave.txt";
                    path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "CitySave.txt");

                }
                else if (game_save_number == 2)
                {
                    //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\CitySave2.txt";
                    path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "CitySave2.txt");

                }
                else if (game_save_number == 3)
                {
                    //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\CitySave3.txt";
                    path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "CitySave3.txt");
                }
                else
                {
                    MessageBox.Show("There was an error saving all cities, game not saved.");
                    return;
                }
                if (File.Exists(path))
                {
                    File.WriteAllText(path, String.Empty);
                    using (StreamWriter SaveFileTo = File.CreateText(path))
                    {

                        for (int i = 0; i < world_map.get_city_list_size(); i++)
                        {
                            SaveFileTo.Write(world_map.get_city_from_list(i).get_name());
                            SaveFileTo.Write("_");
                            SaveFileTo.Write(world_map.get_city_from_list(i).get_x_location());
                            SaveFileTo.Write("_");
                            SaveFileTo.Write(world_map.get_city_from_list(i).get_y_locations());
                            SaveFileTo.Write("_");
                            SaveFileTo.Write(world_map.get_city_from_list(i).get_owning_faction().get_name());
                            SaveFileTo.Write("_");
                            if (world_map.get_city_from_list(i).get_has_moved() == true)
                            {
                                SaveFileTo.Write(1);
                            }
                            else
                            {
                                SaveFileTo.Write(0);
                            }
                            SaveFileTo.Write("_");
                            SaveFileTo.Write(world_map.get_city_from_list(i).get_production_level());
                            SaveFileTo.WriteLine();
                        }
                        SaveFileTo.Close();
                    }
                }
                #endregion
            #region army_save
                if (game_save_number == 1)
                {
                    //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\ArmySave.txt";
                    path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "ArmySave.txt");

                }
                else if (game_save_number == 2)
                {
                    //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\ArmySave2.txt";
                    path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "ArmySave2.txt");

                }
                else if (game_save_number == 3)
                {
                    //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\ArmySave3.txt";
                    path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "ArmySave3.txt");
                }
                else
                {
                    MessageBox.Show("There was an error saving all armies, game not saved.");
                    return;
                }
                if (File.Exists(path))
                {
                    File.WriteAllText(path, String.Empty);
                    using (StreamWriter SaveFleTo = File.CreateText(path))
                    {
                        for (int i = 0; i < world_map.get_number_of_factions(); i++)
                        {
                            for (int j = 0; j < world_map.get_faction_from_list(i).get_Army_Size(); j++)
                            {
                                SaveFleTo.Write(world_map.get_faction_from_list(i).get_army(j).get_faction_ID());
                                SaveFleTo.Write('_');
                                SaveFleTo.Write(world_map.get_faction_from_list(i).get_army(j).get_health());
                                SaveFleTo.Write('_');
                                SaveFleTo.Write(world_map.get_faction_from_list(i).get_army(j).get_army_number());
                                SaveFleTo.Write('_');
                                SaveFleTo.Write(world_map.get_faction_from_list(i).get_army(j).get_x_coordinate());
                                SaveFleTo.Write('_');
                                SaveFleTo.Write(world_map.get_faction_from_list(i).get_army(j).get_y_coordinate());
                                SaveFleTo.Write('_');
                                if (world_map.get_faction_from_list(i).get_army(j).get_has_boats() == true)
                                {
                                    SaveFleTo.Write(1);
                                }
                                else
                                {
                                    SaveFleTo.Write(0);
                                }
                                SaveFleTo.Write('_');
                                if (world_map.get_faction_from_list(i).get_army(j).get_has_gear() == true)
                                {
                                    SaveFleTo.Write(1);
                                }
                                else
                                {
                                    SaveFleTo.Write(0);
                                }
                                SaveFleTo.Write('_');
                                if (world_map.get_faction_from_list(i).get_army(j).get_has_packs() == true)
                                {
                                    SaveFleTo.Write(1);
                                }
                                else
                                {
                                    SaveFleTo.Write(0);
                                }
                                SaveFleTo.Write('_');
                                SaveFleTo.Write(world_map.get_faction_from_list(i).get_army(j).get_moves_left());
                                SaveFleTo.WriteLine();

                            }
                        }
                        SaveFleTo.Close();
                    }

                }
                #endregion
            #region Turn_save
                if (game_save_number == 1)
                {
                    //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\TurnFactionSave.txt";
                    path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "TurnFactionSave.txt");

                }
                else if (game_save_number == 2)
                {
                    //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\TurnFactionSave2.txt";
                    path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "TurnFactionSave2.txt");

                }
                else if (game_save_number == 3)
                {
                    //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\TurnFactionSave3.txt";
                    path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "TurnFactionSave3.txt");

                }
                else
                {
                    MessageBox.Show("There was an error saving who's turn it is, game not saved.");
                    return;
                }
                if (player_turn != null)
                {
                    if (File.Exists(path))
                    {
                        File.WriteAllText(path, String.Empty);
                        using (StreamWriter SaveFileTo = File.CreateText(path))
                        {
                            SaveFileTo.Write(player_turn.get_name());
                        }
                    }
                }
            }
                #endregion
            #region factions_in_play_save
            if (game_save_number == 1)
            {
                //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\FactionsInPlay.txt";
                path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "FactionsInPlay.txt");

            }
            else if (game_save_number == 2)
            {
                //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\FactionsInPlay2.txt";
                path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "FactionsInPlay2.txt");

            }
            else if (game_save_number == 3)
            {
                //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\FactionsInPlay3.txt";
                path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "FactionsInPlay3.txt");

            }
            else
            {
                MessageBox.Show("There was an error saving factions in play, game not saved.");
                return;
            }
            if(File.Exists(path))
            {
                using(StreamWriter SaveFileTo = File.CreateText(path))
                {
                    for (int i = 0; i < world_map.get_number_of_factions();i++ )
                    {
                        SaveFileTo.Write(world_map.get_faction_from_list(i).get_name());
                        SaveFileTo.Write('_');
                        SaveFileTo.Write(world_map.get_faction_from_list(i).get_ID());
                        SaveFileTo.Write('_');
                        SaveFileTo.Write(world_map.get_faction_from_list(i).get_gold());
                        SaveFileTo.Write('_');
                        SaveFileTo.Write(world_map.get_faction_from_list(i).get_victories());
                        SaveFileTo.Write('_');
                        SaveFileTo.Write(world_map.get_faction_from_list(i).get_loses());
                        SaveFileTo.Write('_');
                        SaveFileTo.Write(world_map.get_faction_from_list(i).get_total_number_of_armies_count());
                        SaveFileTo.Write('_');
                        SaveFileTo.Write(world_map.get_faction_from_list(i).get_grand_victories());
                        SaveFileTo.WriteLine();
                    }
                }
            }
            #endregion
            MessageBox.Show("Game has been saved.");
        }

        //Executes when the form is closed to make sure everything shuts down when the program is finished.
        private void btnExitProgram_Click(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        //Adds a city by opening up a get coordinate form for user input.
        private void addCityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool is_copy = false;
            bool paid_extra = false;
            #region error_handlers
            if (player_turn == null)
            {
                MessageBox.Show("There are no factions so a city cannot be bought.");
                return;
            }
            else if (player_turn.get_gold() < 100)
            {
                MessageBox.Show("You do not have enough gold to build a city.");
                return;
            }
            else
            {
                DialogResult city_build = MessageBox.Show("Are you sure you want to spend 100 gold to buy a city?", "City Purchase", MessageBoxButtons.YesNo);
                if (city_build == DialogResult.No)
                {
                    return;
                }
            }
            if (world_map.get_number_of_factions() == 0)
            {
                MessageBox.Show("There are no factions, you cannot build cities without first adding a faction.");
                return;
            }
            #endregion
            GetCoordinatesForm add_city = new GetCoordinatesForm(world_map.get_width(), world_map.get_height(), ref player_turn);
            add_city.ShowDialog();
            #region city_constraints
            if (add_city.get_city_x()+1==0 || add_city.get_city_y()+1==0)
            {
                MessageBox.Show("City out of bounds of map.");
                return;
            }
            if (world_map.get_position_ID(add_city.get_city_x(), add_city.get_city_y()) == 1)//makes sure no one builds on water.
            {
                MessageBox.Show("You cannot build you city on water.");
                return;
            }
            else if(world_map.get_position_ID(add_city.get_city_x(),add_city.get_city_y())==2  || world_map.get_position_ID(add_city.get_city_x(),add_city.get_city_y())==4)
            {   
               DialogResult extra_build = MessageBox.Show("Building on a forest or mountain costs 150G, continue?","Extra Town Cost",MessageBoxButtons.YesNo);
                 if(extra_build == DialogResult.Yes)
                 {
                     paid_extra = true;   
                 }
                 else
                 {
                     return;
                 }

            }
            #endregion//Covers where you cannot build and that building on a mountain or forest costs extra.
            # region check_for_duplicate_name_or_location
            for (int i = 0; i < world_map.get_city_list_size(); i++)//checks for location copy of a city.
            {
                if (add_city.get_city_x() == world_map.get_city_from_list(i).get_x_location() && add_city.get_city_y() == world_map.get_city_from_list(i).get_y_locations())
                {
                    is_copy = true;
                    break;
                }
            }

            if (is_copy == true)
            {
                MessageBox.Show("There are already a city at location: " + (add_city.get_city_x()+1) + "," + (add_city.get_city_y()+1), "Duplicate City", MessageBoxButtons.OK);
            }
            else if (add_city.get_city_x() < 0 || add_city.get_city_y() < 0)
            {
                //This was added here because a city would show up at 0,0 if the user exits from the add a city form.  This prevents that from happening.
            }
            else if (world_map.check_for_duplicate_cities(add_city.get_name()) == true)//checks to see if there is a city of the same name.
            {
                MessageBox.Show("A City with the same name already exists.");
            }
            #endregion
            #region city_Addition_to_data
            else
            {
                //MessageBox.Show("Adding city to map.");
                Add_Cities(add_city.get_city_x(), add_city.get_city_y(), ref player_turn);
                City new_city = new City(add_city.get_city_x(), add_city.get_city_y(), add_city.get_name(), ref player_turn, false,1);
                if(paid_extra == true)
                {
                    player_turn.change_gold_balance(-150);
                }
                else
                {
                    player_turn.change_gold_balance(-100);
                }
                world_map.add_city_to_list(ref new_city);

            }
            add_city.Dispose();
            #endregion//Adds city data to its respective faction and then calls the function to add a sprite to the map.
        }

        //Lists all of the cities of whoever's turn it is.
        private void listCitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String City_text = "";
            int cities_found = 0;
            if(world_map.get_city_list_size()==0)
            {
                MessageBox.Show("There are no cities on the map.", "No Cities", MessageBoxButtons.OK);
                return;
            }
            for(int i=0; i < world_map.get_city_list_size();i++)
            {
                if( player_turn.get_name().CompareTo(world_map.get_city_from_list(i).get_owning_faction().get_name())==0)
                {
                    cities_found++;
                    City_text += (cities_found) + ". Name: " + world_map.get_city_from_list(i).get_name() + "\n" + "Location: " + (world_map.get_city_from_list(i).get_x_location() + 1) + "," + (world_map.get_city_from_list(i).get_y_locations() + 1) + "\n Owned by: " + world_map.get_city_from_list(i).get_owning_faction().get_name() + "\nProduction: "+world_map.get_city_from_list(i).get_production_level()+ "\n\n";
                }
                if(cities_found % 10 == 0 && City_text.Length > 0)
                {
                    MessageBox.Show(City_text);
                    City_text = "";
                }
            }
            if(cities_found == 0)
            {
                MessageBox.Show("This faction has no cities.");
            }
            else
            {
                MessageBox.Show(City_text);
            }
        }

        //Lists the location and name of each army for whoever's turn it is.
        private void listArmiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String Army_text = "";
            int page_helper = 0;//makes sure each message box has no more than then army locations.
            if(player_turn == null)
            {
                MessageBox.Show("There are no factions in play.");
            }
            else if(player_turn.get_Army_Size()==0)//may need to change this to get army count.
            {
                MessageBox.Show("This faction has not armies.");
            }
            else
            {
                for(int i=0; i < player_turn.get_Army_Size();i++)//may need to change this to get army count.
                {
                    page_helper++;
                    Army_text +=player_turn.get_army(i).get_army_number().ToString()+" "+player_turn.get_name()+" army \n Location:  x: "+(player_turn.get_army(i).get_x_coordinate()+1).ToString() + "  y: "+(player_turn.get_army(i).get_y_coordinate()+1).ToString()+"\nMoves left: "+player_turn.get_army(i).get_moves_left()+"\n Health: "+player_turn.get_army(i).get_health()+"\n\n";
                    if(page_helper % 10 == 0 && page_helper >0)
                    {
                        MessageBox.Show(Army_text);
                        Army_text = "";
                    }
                }
                if(Army_text.Length >0)
                {
                    MessageBox.Show(Army_text);
                }
            }
        }

        //Adds a Faction to the map.
        private void addFactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FactionAddingForm add_faction = new FactionAddingForm();
            Faction new_faction;
            List<String> show_list = new List<String>();
            int size = 0;
            bool found_dup = false;
            Faction found_faction;
            MessageBox.Show("all factions: "+world_map.get_number_of_all_factions()+"  factions in play: "+world_map.get_number_of_factions());
            if(world_map.get_number_of_all_factions() ==world_map.get_number_of_factions())
            {
                MessageBox.Show("All factions have been added, there are no more factions to add.");
                add_faction.Dispose();
                return;
            }
            #region add_faction_list_of_remaining_factions

            if(world_map.get_number_of_factions() == 0)
            {
                for(int i=0; i < world_map.get_number_of_all_factions();i++)
                {
                    add_faction.Add_faction_name_to_list(world_map.get_faction_from_all_factions(i).get_name());
                }
            }
            else
            {
                for(int i = 0; i < world_map.get_number_of_all_factions();i++)
                {
                    show_list.Add(world_map.get_faction_from_all_factions(i).get_name());
                }
                for(int i=0; i < world_map.get_number_of_factions();i++)
                {
                    if(show_list.Contains(world_map.get_faction_from_list(i).get_name()))
                    {
                        size = show_list.Count;
                        for(int j=0; j < size; j++)
                        {
                            if(world_map.get_faction_from_list(i).get_name().CompareTo(show_list[j])==0)
                            {
                                show_list.RemoveAt(j);
                                --size;
                            }
                        }
                    }
                }
                for(int i=0; i < show_list.Count; i++)
                {
                    add_faction.Add_faction_name_to_list(show_list[i]);
                }
                
            }
            #endregion
                add_faction.ShowDialog();
                #region add_one_faction
                if (add_faction.get_add_faction_button_press()==true)
            {
                for (int i = 0; i < world_map.get_number_of_all_factions(); i++ )
                {
                    if(world_map.get_faction_from_all_factions(i).get_name().CompareTo(add_faction.get_chosen_faction())==0)
                    {
                        new_faction = world_map.get_faction_from_all_factions(i);
                        new_faction.change_gold_balance(300 - new_faction.get_gold());
                        new_faction.change_army_count(0);
                        world_map.add_faction_to_list(ref new_faction);
                        break;
                    }
                }
                   MessageBox.Show(world_map.get_faction_from_list(world_map.get_number_of_factions()-1).get_name()+" has been added to your game.");
                    add_faction.Dispose();

                if(world_map.get_number_of_factions()==1)
                {
                    player_turn = world_map.get_faction_from_list(0);
                    turn_tracker_lbl.Text = "Turn: "+world_map.get_faction_from_list(0).get_name();
                    MessageBox.Show("Turn: "+player_turn.get_name());
                }
            }
                #endregion
                #region Add_all_unadded_factions
                else if (add_faction.get_add_all_factions_button_press() == true)
            {
               for(int i=0; i < world_map.get_number_of_all_factions();i++)
               {
                   for(int j = 0; j < world_map.get_number_of_factions();j++)
                   {
                       if(world_map.get_faction_from_all_factions(i).get_name().CompareTo(world_map.get_faction_from_list(j).get_name())==0)
                       {
                           found_dup = true;
                       }
                   }
                   if(found_dup == false)
                   {
                       found_faction = world_map.get_faction_from_all_factions(i);
                       found_faction.change_gold_balance(300 - found_faction.get_gold());
                       world_map.add_faction_to_list(ref found_faction);
                   }
                   else
                   {
                       found_dup = false;
                   }
               }
               MessageBox.Show("All remaining factions have been added to the game.");
            #endregion
               if (player_turn == null)
                {
                    player_turn = world_map.get_faction_from_list(0);
                    turn_tracker_lbl.Text = "Turn: " + player_turn.get_name();
                }
            }
        }

        //Lists all of the factions that are in play.
        private void listFactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String[] cities = new String[world_map.get_number_of_factions()];
            String faction_text = "";
            int at_faction = 0;
            if (world_map.get_number_of_factions() == 0)
            {
                MessageBox.Show("There are no factions on the map.", "No Factions", MessageBoxButtons.OK);
            }
            else
            {
                for (int i = 0; i < world_map.get_city_list_size(); i++)
                {
                    for(int j = 0; j < world_map.get_number_of_factions();j++)
                    {
                      if(world_map.get_city_from_list(i).get_owning_faction().get_name().CompareTo(world_map.get_faction_from_list(j).get_name())==0)
                      {
                          cities[j] += world_map.get_city_from_list(i).get_name() + " , ";
                      }
                    }
                }
                while (at_faction < world_map.get_number_of_factions())
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (at_faction < world_map.get_number_of_factions())
                        {
                            faction_text += "\n" + (at_faction + 1) + ". Faction:" + world_map.get_faction_from_list(at_faction).get_name() + "\n ID: " + world_map.get_faction_from_list(at_faction).get_ID() + "\n Gold: " + world_map.get_faction_from_list(at_faction).get_gold() + "\n Cites: " + cities[at_faction] + "\n Victories: " + world_map.get_faction_from_list(at_faction).get_victories() + "\n Loses: " + world_map.get_faction_from_list(at_faction).get_loses() + "\n Armies: " + world_map.get_faction_from_list(at_faction).get_Army_Size() + "\n";
                        }
                        at_faction++;
                    }
                    MessageBox.Show(faction_text);
                    faction_text = "";
                }

            }
        }

        //Turn the grid on and off
        private void gridOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grid_on == false)
            {
                complete_map.SendToBack();
                complete_map.Update();
                complete_map.Refresh();
                gridOnToolStripMenuItem.Text = "Grid Off";
                grid_on = true;
            }
            else
            {
                gridOnToolStripMenuItem.Text = "Grid On";
                grid_on = false;
                complete_grid.SendToBack();
                complete_grid.Update();
                complete_grid.Refresh();
            }
        }

        //Ends the turn of the current faction.
        private void endTurnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Army search_army;
            City search_city;
            String faction_name = "";
            Faction change_to;
            PictureBox update_image;
            bool city_found = false;
            int delete_index = 0;
            bool delete_faction = false;


            #region Death_checkers
            for (int i = 0; i < world_map.get_number_of_factions(); i++)
            {
                for (int j = 0; j < world_map.get_city_list_size(); j++)
                {
                    if (world_map.get_city_from_list(j).get_owning_faction().get_name().CompareTo(world_map.get_faction_from_list(i).get_name()) == 0)
                    {
                        city_found = true;
                        break;
                    }
                }
                if (city_found == false && world_map.get_faction_from_list(i).get_gold() < 100 && world_map.get_faction_from_list(i).get_Army_Size() == 0 && world_map.get_faction_from_list(i).get_name().CompareTo(player_turn.get_name()) != 0)
                {
                    MessageBox.Show(world_map.get_faction_from_list(i).get_name() + " has been defeated by the " + player_turn.get_name() + ".");
                    world_map.remove_faction_from_play(i);
                }
                else if (city_found == false && world_map.get_faction_from_list(i).get_gold() < 100 && world_map.get_faction_from_list(i).get_Army_Size() == 0 && world_map.get_faction_from_list(i).get_name().CompareTo(player_turn.get_name()) == 0)
                {
                    MessageBox.Show(world_map.get_faction_from_list(i).get_name() + " has been defeated.");
                    delete_index = i;
                    delete_faction = true;

                }
            }
            city_found = false;
            #endregion
            #region checks for city takeovers
            for (int i = 0; i < world_map.get_number_of_factions(); i++)
            {
                for (int j = 0; j < world_map.get_faction_from_list(i).get_Army_Size(); j++)
                {
                    for (int k = 0; k < world_map.get_city_list_size(); k++)
                    {
                        search_army = world_map.get_faction_from_list(i).get_army(j);
                        search_city = world_map.get_city_from_list(k);
                        if (search_army.get_x_coordinate() == search_city.get_x_location() && search_army.get_y_coordinate() == search_city.get_y_locations() && search_army.get_faction_ID() != search_city.get_owning_faction().get_ID())
                        {
                            for (int m = 0; m < world_map.get_number_of_factions(); m++)
                            {
                                if (world_map.get_faction_from_list(m).get_ID() == search_army.get_faction_ID())
                                {
                                    faction_name = world_map.get_faction_from_list(m).get_name();
                                    change_to = world_map.get_faction_from_list(m);
                                    search_city.change_owning_faction(ref change_to);
                                    break;
                                }
                            }
                            MessageBox.Show(search_city.get_name() + " has been taken over by the " + faction_name);
                            break;
                        }
                    }
                }

            }
            #endregion
            #region error_checkers
            if (world_map.get_number_of_factions() == 0)
            {
                MessageBox.Show("There are no factions yet, please create factions.");
            }
            else if (player_turn == null)
            {
                MessageBox.Show(" Error: Does not know who's turn it is, setting to " + world_map.get_faction_from_list(0).get_name());
                player_turn = world_map.get_faction_from_list(0);
                turn_tracker_lbl.Text = "Turn: " + world_map.get_faction_from_list(0).get_name();
            }
            #endregion
            else
            {
                #region set_next_player_turn
                if (player_turn.get_name().CompareTo(world_map.get_faction_from_list(world_map.get_number_of_factions() - 1).get_name()) == 0)
                {
                    player_turn = world_map.get_faction_from_list(0);
                    turn_tracker_lbl.Text = "Turn: " + player_turn.get_name();
                    //MessageBox.Show("Reset: ");
                }
                else
                {
                    for (int i = 0; i < world_map.get_number_of_factions(); i++)
                    {
                        if (player_turn.get_name().CompareTo(world_map.get_faction_from_list(i).get_name()) == 0)
                        {
                            player_turn = world_map.get_faction_from_list(i + 1);
                            turn_tracker_lbl.Text = "Turn: " + player_turn.get_name();
                            break;
                        }
                    }
                }
                #endregion
                #region update_movements_and_sprites
                for (int i = 0; i < world_map.get_number_of_factions(); i++)
                {
                    for (int j = 0; j < world_map.get_faction_from_list(i).get_Army_Size(); j++)
                    {
                        world_map.get_faction_from_list(i).get_army(j).augment_moves_left(3);
                    }
                }
                for (int i = 0; i < world_map.get_city_list_size(); i++)
                {
                    world_map.get_city_from_list(i).augment_has_moved(0);
                    //start here

                    update_image = city_grid[world_map.get_city_from_list(i).get_x_location(), world_map.get_city_from_list(i).get_y_locations()];
                    change_to = world_map.get_city_from_list(i).get_owning_faction();
                    /* if (update_image != null)
                     {
                         update_image.Dispose();
                     }
                     Add_Cities(world_map.get_city_from_list(i).get_x_location(),world_map.get_city_from_list(i).get_y_locations(),ref change_to);*/
                    if (world_map.get_city_from_list(i).get_owning_faction().get_name().CompareTo(player_turn.get_name()) == 0)
                    {
                        update_image.BackgroundImage = Properties.Resources.Highlight;
                    }
                    else
                    {
                        update_image.BackgroundImage = Properties.Resources.Plains;
                    }
                    //update_image.BringToFront();
                    update_image.Update();
                    update_image.Refresh();
                    //this.Update();
                    //this.Refresh();

                    //end here
                #endregion
                }
            }
            #region update_gold_accounts_per_city
            for (int j = 0; j < world_map.get_city_list_size(); j++)
            {
                if (world_map.get_city_from_list(j).get_owning_faction().get_name().CompareTo(player_turn.get_name()) == 0)
                {
                    player_turn.change_gold_balance(world_map.get_city_from_list(j).get_production_level());
                }
            }
            #endregion

            #region replenish_moves_for_armies
            #endregion
            #region delete_player_turn_faction
            if (delete_faction == true)
            {
                world_map.remove_faction_from_play(delete_index);
            }
            #endregion
            MessageBox.Show("Turn is over.\n Turn: " + player_turn.get_name());
        }
        #endregion

        #region picture_box_clicks

        //Brings up an option menu when each city is clicked.
        private void city_click(object sender, EventArgs e, int x_coord, int y_coord)
        {
            City found_city = world_map.get_city_from_list(x_coord, y_coord);
            if (found_city == null)
            {
                MessageBox.Show("There was an error, no city was found at the location you clicked.");
            }
            else
            {
                #region has_moved_handler
                if (found_city.get_owning_faction().get_ID() != player_turn.get_ID())
                {
                    MessageBox.Show("This city is owned by " + found_city.get_owning_faction().get_name() + " and it not their turn. \n" + " Gold: " + found_city.get_owning_faction().get_gold());
                    return;
                }
                if (found_city.get_has_moved() == true)
                {
                    String message = "";
                    message += "This city has already performed an action.\n Owned by: " + found_city.get_owning_faction().get_name() + "\n Gold: " + found_city.get_owning_faction().get_gold()+"\n Production: " + found_city.get_production_level();
                    MessageBox.Show(message);
                    return;
                }
                #endregion
                CityOptions options = new CityOptions(ref found_city);
                options.ShowDialog();
                #region create_army
                if (options.get_army_push() == true && options.get_heal_push() == false)//create army
                {
                    found_city.get_owning_faction().increment_army_number();
                    Army new_army = new Army(20, found_city.get_x_location(), found_city.get_y_locations(), found_city.get_owning_faction().get_ID(),player_turn.get_total_number_of_armies_count(), false, false, false, 0);
                    //player_turn.increment_army_number();
                    found_city.get_owning_faction().add_Army_to_faction(ref new_army);
                    add_army_to_map(ref new_army, world_map.get_position_ID(new_army.get_x_coordinate(), new_army.get_y_coordinate()));
                    found_city.get_owning_faction().change_gold_balance(-20);
                    found_city.augment_has_moved(1);
                }
                #endregion
                else if (options.get_heal_push() == true && options.get_army_push() == false)//heal armies
                {
                    bool army_heal = false;
                    #region heal_at_city
                    if (army_grid[found_city.get_x_location(), found_city.get_y_locations()] != null)//at city
                    {
                        if (world_map.get_Army_faction_name(found_city.get_owning_faction().get_ID()).CompareTo(world_map.get_Army_faction_name(world_map.get_army_at_location(found_city.get_x_location(), found_city.get_y_locations()).get_faction_ID())) == 0)
                        {
                            if (world_map.get_army_at_location(found_city.get_x_location(), found_city.get_y_locations()).get_health() < 20)
                            {
                                world_map.get_army_at_location(found_city.get_x_location(), found_city.get_y_locations()).augment_heatlh(world_map.get_army_at_location(found_city.get_x_location(), found_city.get_y_locations()).get_health() + 1);
                                //found_city.get_owning_faction().change_gold_balance(-1);
                                army_heal = true;
                            }
                        }
                    }
                    #region heal_north
                    if (found_city.get_y_locations() - 1 >= 0 && army_grid[found_city.get_x_location(), found_city.get_y_locations() - 1] != null)//north of city
                    {
                        if (world_map.get_Army_faction_name(found_city.get_owning_faction().get_ID()).CompareTo(world_map.get_Army_faction_name(world_map.get_army_at_location(found_city.get_x_location(), found_city.get_y_locations() - 1).get_faction_ID())) == 0)
                        {
                            if (world_map.get_army_at_location(found_city.get_x_location(), found_city.get_y_locations() - 1).get_health() < 20)
                            {
                                world_map.get_army_at_location(found_city.get_x_location(), found_city.get_y_locations() - 1).augment_heatlh(world_map.get_army_at_location(found_city.get_x_location(), found_city.get_y_locations() - 1).get_health() + 1);
                                //found_city.get_owning_faction().change_gold_balance(-1);
                                army_heal = true;
                            }
                        }
                    }
                    #endregion
                    #region heal_east
                    if (found_city.get_x_location() + 1 < world_map.get_width() - 1 && army_grid[found_city.get_x_location() + 1, found_city.get_y_locations()] != null)//east of city
                    {
                        if (world_map.get_Army_faction_name(found_city.get_owning_faction().get_ID()).CompareTo(world_map.get_Army_faction_name(world_map.get_army_at_location(found_city.get_x_location() + 1, found_city.get_y_locations()).get_faction_ID())) == 0)
                        {
                            if (world_map.get_army_at_location(found_city.get_x_location() + 1, found_city.get_y_locations()).get_health() < 20)
                            {
                                world_map.get_army_at_location(found_city.get_x_location() + 1, found_city.get_y_locations()).augment_heatlh(world_map.get_army_at_location(found_city.get_x_location() + 1, found_city.get_y_locations()).get_health() + 1);
                                //found_city.get_owning_faction().change_gold_balance(-1);
                                army_heal = true;
                            }
                        }
                    }
                    #endregion
                    #region heal_south
                    if (found_city.get_y_locations() + 1 < world_map.get_height() - 1 && army_grid[found_city.get_x_location(), found_city.get_y_locations() + 1] != null)//south of city
                    {
                        if (world_map.get_Army_faction_name(found_city.get_owning_faction().get_ID()).CompareTo(world_map.get_Army_faction_name(world_map.get_army_at_location(found_city.get_x_location(), found_city.get_y_locations() + 1).get_faction_ID())) == 0)
                        {
                            if (world_map.get_army_at_location(found_city.get_x_location(), found_city.get_y_locations() + 1).get_health() < 20)
                            {
                                world_map.get_army_at_location(found_city.get_x_location(), found_city.get_y_locations() + 1).augment_heatlh(world_map.get_army_at_location(found_city.get_x_location(), found_city.get_y_locations() + 1).get_health() + 1);
                                //found_city.get_owning_faction().change_gold_balance(-1);
                                army_heal = true;
                            }
                        }
                    }
                    #endregion
                    #region heal_west
                    if (found_city.get_x_location() - 1 >= 0 && army_grid[found_city.get_x_location() - 1, found_city.get_y_locations()] != null)//west of city
                    {
                        if (world_map.get_Army_faction_name(found_city.get_owning_faction().get_ID()).CompareTo(world_map.get_Army_faction_name(world_map.get_army_at_location(found_city.get_x_location() - 1, found_city.get_y_locations()).get_faction_ID())) == 0)
                        {
                            if (world_map.get_army_at_location(found_city.get_x_location() - 1, found_city.get_y_locations()).get_health() < 20)
                            {
                                world_map.get_army_at_location(found_city.get_x_location() - 1, found_city.get_y_locations()).augment_heatlh(world_map.get_army_at_location(found_city.get_x_location() - 1, found_city.get_y_locations()).get_health() + 1);
                                //found_city.get_owning_faction().change_gold_balance(-1);
                                army_heal = true;
                            }
                        }
                    }
                    #endregion
                    if (army_heal == true)
                    {
                        found_city.get_owning_faction().change_gold_balance(-1);
                        MessageBox.Show("An army has been healed.");
                        found_city.augment_has_moved(1);
                    }
                    else
                    {
                        MessageBox.Show("All surrounding are at full health.");
                    }
                    #endregion
                }
                options.Dispose();
            }

        }

        //Moves an army
        private void Army_click(object sender, EventArgs e, ref Army to_move, String faction_name)
        {
            #region has_moved_handler
            if (to_move.get_faction_ID() != player_turn.get_ID())
            {
                MessageBox.Show("It is not the turn of the faction that owns this army. \n Health: " + to_move.get_health());
                return;
            }
            if (to_move.get_moves_left() < 1)
            {
               // MessageBox.Show("moves left: "+to_move.get_moves_left());
                String message = "";
                message += "That army is out of moves for the turn.\n Health: " + to_move.get_health() + "\n Water: ";
                if (to_move.get_has_boats() == true)
                {
                    message += "Yes \n";
                }
                else
                {
                    message += "No \n";
                }
                message += "Mountains: ";
                if (to_move.get_has_gear() == true)
                {
                    message += "Yes \n";
                }
                else
                {
                    message += "No \n";
                }
                message += "Forests: ";
                if (to_move.get_has_packs() == true)
                {
                    message += "Yes \n";
                }
                else
                {
                    message += "No \n";
                }
                MessageBox.Show(message);
                return;
            }
            #endregion
            int old_x = to_move.get_x_coordinate();
            int old_y = to_move.get_y_coordinate();
            MovingArmyForm moving = new MovingArmyForm(ref to_move, faction_name, world_map.get_width(), world_map.get_height());
            Army defending_army;
            BattleForm new_battle;
            Faction found_faction = null;
            #region Faction_finder
            for (int i = 0; i < world_map.get_number_of_factions(); i++)
            {
                if (faction_name.CompareTo(world_map.get_faction_from_list(i).get_name()) == 0)
                {
                    found_faction = world_map.get_faction_from_list(i);
                    break;
                }
            }
            if (found_faction == null)
            {
                MessageBox.Show("Faction could not be found for this army.");
                moving.Dispose();
                return;
            }
            #endregion
            moving.BringToFront();
            moving.ShowDialog();
            #region buy_boats
            if (moving.get_boat_buy() == true)
            {
                if (found_faction.get_gold() >= 10)
                {
                    if (to_move.get_has_boats() == true)
                    {
                        MessageBox.Show("This army already has boats.");
                    }
                    else
                    {
                        to_move.augment_boats(1);
                        found_faction.change_gold_balance(-10);
                        MessageBox.Show("This army now has boats and can cross water. \n Gold remaining: " + found_faction.get_gold());
                        to_move.augment_moves_left(to_move.get_moves_left()-1);
                    }
                }
                else
                {
                    MessageBox.Show("You do not have enough gold to buy boats for this army.");
                }
            }
            #endregion
            #region buy_gear
            else if (moving.get_gear_buy() == true)
            {
                if (found_faction.get_gold() >= 10)
                {
                    if (to_move.get_has_gear() == true)
                    {
                        MessageBox.Show("This army already has climbing gear.");
                    }
                    else
                    {
                        to_move.augment_gear(1);
                        found_faction.change_gold_balance(-10);
                        MessageBox.Show("This army now has climbing hear and can scale mountains. \n Gold remaining: " + found_faction.get_gold());
                        to_move.augment_moves_left(to_move.get_moves_left()-1);
                    }
                }
                else
                {
                    MessageBox.Show("You do not have enough gold to buy climbing gear for this army.");
                }
            }
            #endregion
            #region buy_packs
            else if (moving.get_pack_buy() == true)
            {
                if (found_faction.get_gold() >= 10)
                {
                    if (to_move.get_has_packs() == true)
                    {
                        MessageBox.Show("This army already has exploration packs.");
                    }
                    else
                    {
                        to_move.augment_packs(1);
                        found_faction.change_gold_balance(-10);
                        MessageBox.Show("This army now has exploration packs and can traverse forests. \n Gold remaining: " + found_faction.get_gold());
                        to_move.augment_moves_left(to_move.get_moves_left()-1);
                    }
                }
                else
                {
                    MessageBox.Show("You do not have enough gold to buy exploration packs for this army.");
                }
            }
            #endregion

                #region moving_north
            else
            {
                //moving north
                if (moving.get_direction_changed() == 1)
                {
                    if (army_grid[to_move.get_x_coordinate(), to_move.get_y_coordinate() - 1] != null)
                    {

                        if (world_map.get_Army_faction_name(to_move.get_faction_ID()).CompareTo(world_map.get_Army_faction_name(world_map.get_army_at_location(to_move.get_x_coordinate(), to_move.get_y_coordinate() - 1).get_faction_ID())) != 0)
                        {
                            to_move.augment_moves_left(to_move.get_moves_left()-1);
                            defending_army = world_map.get_army_at_location(to_move.get_x_coordinate(), to_move.get_y_coordinate() - 1);
                            battle_time(ref to_move,ref defending_army);
                        }
                        else
                        {
                            MessageBox.Show("Another one of your armies is already in that space, move that army before moving the one you want to move.");
                        }
                    }
                    else if (world_map.get_position_ID(to_move.get_x_coordinate(), to_move.get_y_coordinate() - 1) == 1 && to_move.get_has_boats() == false)//checks for boats
                    {
                        MessageBox.Show("This army does not have boats to cross water.  This army must purchase boats before crossing water.");
                    }
                    else if (world_map.get_position_ID(to_move.get_x_coordinate(), to_move.get_y_coordinate() - 1) == 2 && to_move.get_has_gear() == false)
                    {
                        MessageBox.Show("This army does not have boats to scale mountains. This army must purchase climbing gear before scaling mountains.");
                    }
                    else if (world_map.get_position_ID(to_move.get_x_coordinate(), to_move.get_y_coordinate() - 1) == 4 && to_move.get_has_packs() == false)
                    {
                        MessageBox.Show("This army does not have exploration packs to traverse forests.  This army must purchase exploration packs before traversing forets.");
                    }
                    else
                    {
                        to_move.augment_y_coordinate((to_move.get_y_coordinate() - 1));
                        add_army_to_map(ref to_move, world_map.get_position_ID(to_move.get_x_coordinate(), to_move.get_y_coordinate()));
                        remove_army_from_map(old_x, old_y);
                        to_move.augment_moves_left(to_move.get_moves_left()-1);
                    }
                }
            #endregion
                #region moving_east
                //moving east
                else if (moving.get_direction_changed() == 2)
                {
                    if (army_grid[to_move.get_x_coordinate() + 1, to_move.get_y_coordinate()] != null)
                    {
                        //if (!to_move.get_faction_ID().Equals(world_map.get_army_at_location(to_move.get_x_coordinate()+1, to_move.get_y_coordinate())))
                        if (world_map.get_Army_faction_name(to_move.get_faction_ID()).CompareTo(world_map.get_Army_faction_name(world_map.get_army_at_location(to_move.get_x_coordinate() + 1, to_move.get_y_coordinate()).get_faction_ID())) != 0)
                        {
                            to_move.augment_moves_left(to_move.get_moves_left()-1);
                            defending_army = world_map.get_army_at_location(to_move.get_x_coordinate() + 1, to_move.get_y_coordinate());
                            battle_time(ref to_move,ref defending_army);
                        }
                        else
                        {
                            MessageBox.Show("Another one of your armies is already in that space, move that army before moving the one you want to move.");
                        }
                    }
                    else if (world_map.get_position_ID(to_move.get_x_coordinate() + 1, to_move.get_y_coordinate()) == 1 && to_move.get_has_boats() == false)//checks for boats
                    {
                        MessageBox.Show("This army does not have boats to cross water.  This army must purchase boats before crossing water.");
                    }
                    else if (world_map.get_position_ID(to_move.get_x_coordinate() + 1, to_move.get_y_coordinate()) == 2 && to_move.get_has_gear() == false)
                    {
                        MessageBox.Show("This army does not have boats to scale mountains. This army must purchase climbing gear before scaling mountains.");
                    }
                    else if (world_map.get_position_ID(to_move.get_x_coordinate() + 1, to_move.get_y_coordinate()) == 4 && to_move.get_has_packs() == false)
                    {
                        MessageBox.Show("This army does not have exploration packs to traverse forests.  This army must purchase exploration packs before traversing forets.");
                    }

                    else
                    {
                        to_move.augment_moves_left(to_move.get_moves_left()-1);
                        to_move.augment_x_coordinate((to_move.get_x_coordinate() + 1));
                        add_army_to_map(ref to_move, world_map.get_position_ID(to_move.get_x_coordinate(), to_move.get_y_coordinate()));
                        remove_army_from_map(old_x, old_y);
                    }
                }
                #endregion
                #region moving_south
                //moving south
                else if (moving.get_direction_changed() == 3)
                {
                    if (army_grid[to_move.get_x_coordinate(), to_move.get_y_coordinate() + 1] != null)
                    {
                        //if (!to_move.get_faction_ID().Equals(world_map.get_army_at_location(to_move.get_x_coordinate(), to_move.get_y_coordinate()+1)))
                        if (world_map.get_Army_faction_name(to_move.get_faction_ID()).CompareTo(world_map.get_Army_faction_name(world_map.get_army_at_location(to_move.get_x_coordinate(), to_move.get_y_coordinate() + 1).get_faction_ID())) != 0)
                        {
                            to_move.augment_moves_left(to_move.get_moves_left()-1);
                            defending_army = world_map.get_army_at_location(to_move.get_x_coordinate(), to_move.get_y_coordinate() + 1);
                            battle_time(ref to_move, ref defending_army);
                        }
                        else
                        {
                            MessageBox.Show("Another one of your armies is already in that space, move that army before moving the one you want to move.");
                        }
                    }
                    else if (world_map.get_position_ID(to_move.get_x_coordinate(), to_move.get_y_coordinate() + 1) == 1 && to_move.get_has_boats() == false)//checks for boats
                    {
                        MessageBox.Show("This army does not have boats to cross water.  This army must purchase boats before crossing water.");
                    }
                    else if (world_map.get_position_ID(to_move.get_x_coordinate(), to_move.get_y_coordinate() + 1) == 2 && to_move.get_has_gear() == false)
                    {
                        MessageBox.Show("This army does not have boats to scale mountains. This army must purchase climbing gear before scaling mountains.");
                    }
                    else if (world_map.get_position_ID(to_move.get_x_coordinate(), to_move.get_y_coordinate() + 1) == 4 && to_move.get_has_packs() == false)
                    {
                        MessageBox.Show("This army does not have exploration packs to traverse forests.  This army must purchase exploration packs before traversing forets.");
                    }

                    else
                    {
                        to_move.augment_y_coordinate((to_move.get_y_coordinate() + 1));
                        add_army_to_map(ref to_move, world_map.get_position_ID(to_move.get_x_coordinate(), to_move.get_y_coordinate()));
                        remove_army_from_map(old_x, old_y);
                        to_move.augment_moves_left(to_move.get_moves_left()-1);
                    }

                }
                #endregion
                #region moving_west
                //moving west
                else if (moving.get_direction_changed() == 4)
                {
                    if (army_grid[to_move.get_x_coordinate() - 1, to_move.get_y_coordinate()] != null)
                    {
                        //if (!to_move.get_faction_ID().Equals(world_map.get_army_at_location(to_move.get_x_coordinate()-1, to_move.get_y_coordinate())))
                        if (world_map.get_Army_faction_name(to_move.get_faction_ID()).CompareTo(world_map.get_Army_faction_name(world_map.get_army_at_location(to_move.get_x_coordinate() - 1, to_move.get_y_coordinate()).get_faction_ID())) != 0)
                        {
                            to_move.augment_moves_left(to_move.get_moves_left()-1);
                            defending_army = world_map.get_army_at_location(to_move.get_x_coordinate() - 1, to_move.get_y_coordinate());
                            battle_time(ref to_move, ref defending_army);
                        }
                        else
                        {
                            MessageBox.Show("Another one of your armies is already in that space, move that army before moving the one you want to move.");
                        }
                    }
                    else if (world_map.get_position_ID(to_move.get_x_coordinate() - 1, to_move.get_y_coordinate()) == 1 && to_move.get_has_boats() == false)//checks for boats
                    {
                        MessageBox.Show("This army does not have boats to cross water.  This army must purchase boats before crossing water.");
                    }
                    else if (world_map.get_position_ID(to_move.get_x_coordinate() - 1, to_move.get_y_coordinate()) == 2 && to_move.get_has_gear() == false)
                    {
                        MessageBox.Show("This army does not have boats to scale mountains. This army must purchase climbing gear before scaling mountains.");
                    }
                    else if (world_map.get_position_ID(to_move.get_x_coordinate() - 1, to_move.get_y_coordinate()) == 4 && to_move.get_has_packs() == false)
                    {
                        MessageBox.Show("This army does not have exploration packs to traverse forests.  This army must purchase exploration packs before traversing forets.");
                    }

                    else
                    {
                        to_move.augment_x_coordinate((to_move.get_x_coordinate() - 1));
                        add_army_to_map(ref to_move, world_map.get_position_ID(to_move.get_x_coordinate(), to_move.get_y_coordinate()));
                        remove_army_from_map(old_x, old_y);
                        to_move.augment_moves_left(to_move.get_moves_left()-1);
                    }
                }
                #endregion
            }
            moving.Dispose();
        }

        #endregion


        #region key_bindings_and_battle_function
        //Creates key shortcuts for the game
        #region KeyBindings
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.C)
            {
                //adds city
                addCityToolStripMenuItem.PerformClick();
            }
            else if (keyData == Keys.A)
            {
                //adds faction
                addFactionToolStripMenuItem.PerformClick();
            }
            else if (keyData == Keys.E)
            {
                //ends turn
                endTurnToolStripMenuItem.PerformClick();
            }
            else if(keyData == Keys.K)
            {
                //Lists all armies of whoever's turn it is.
                listArmiesToolStripMenuItem.PerformClick();
            }
            else if (keyData == Keys.G)
            {
                //toggles grid
                gridOnToolStripMenuItem.PerformClick();
            }
            else if (keyData == Keys.L)
            {
                //list cities
                listCitiesToolStripMenuItem.PerformClick();
            }
            else if (keyData == Keys.S)
            {
                //saves game
                optionsToolStripMenuItem.PerformClick();
            }
            else if(keyData == Keys.F)
            {
                //lists factions
                listFactionsToolStripMenuItem.PerformClick();
            }
            else if(keyData == Keys.Q)
            {
                MessageBox.Show("x-position: " + this.HorizontalScroll.Value+"\n"+"y-position: "+this.VerticalScroll.Value);
            }
            else if(keyData == Keys.T)
            {
                MessageBox.Show("Turn: "+player_turn.get_name()+"\n Gold: "+player_turn.get_gold());
            }
            else if(keyData == Keys.Up)
            {
                if(this.VerticalScroll.Value < 200)
                {
                    this.VerticalScroll.Value = 0;
                }
                else
                {
                    this.VerticalScroll.Value -= 200;
                }
                this.PerformLayout();
            }
            else if(keyData == Keys.Right)
            {
                if(this.HorizontalScroll.Value+200 > this.HorizontalScroll.Maximum)
                {
                    this.HorizontalScroll.Value = this.HorizontalScroll.Maximum;
                }
                else
                {
                  this.HorizontalScroll.Value += 200;
                }
                this.PerformLayout();
            }
            else if(keyData == Keys.Down)
            {
                if(this.VerticalScroll.Value+200>this.VerticalScroll.Maximum)
                {
                    this.VerticalScroll.Value = this.VerticalScroll.Maximum;
                }
                else
                {
                    this.VerticalScroll.Value += 200;

                }
                this.PerformLayout();
            }
            else if(keyData == Keys.Left)
            {
                if(this.HorizontalScroll.Value < 200)
                {
                    this.HorizontalScroll.Value = 0;
                }
                else
                {
                    this.HorizontalScroll.Value -= 200;
                }
                this.PerformLayout();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
        //Creates a battle for two armies.
        private void battle_time(ref Army attacking_army, ref Army defending_army)
        {
            Faction inspecting_faction;
            Army inspecting_army;
            
            #region get_faction_data_for_permanent_recordings
            String path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "FactionSave.txt");
            int wins = 0;
            int loses = 0;
            String name = "";
            int ID = 0;
            int gold = 0;
            int grand = 0;
            int count = 0;
            String current_line = "";
            String[] extracted_numbers;
            List<Faction> all_factions = new List<Faction>();

            if (!File.Exists(path))
            {
                MessageBox.Show("Faction file missing.  Cannot start battle");
                return;
            }
            else
            {
                using (StreamReader Faction_Loader = new StreamReader(path))
                {
                    while (!Faction_Loader.EndOfStream)
                    {
                        current_line = Faction_Loader.ReadLine();
                        extracted_numbers = current_line.Split('_');
                        if (extracted_numbers.Length >= 7)
                        {
                            name = extracted_numbers[0];
                            int.TryParse(extracted_numbers[1], out ID);
                            int.TryParse(extracted_numbers[2], out gold);
                            int.TryParse(extracted_numbers[3], out wins);
                            int.TryParse(extracted_numbers[4], out loses);
                            int.TryParse(extracted_numbers[5], out count);
                            int.TryParse(extracted_numbers[6], out grand);
                            Faction new_faction = new Faction(name, ID, gold ,wins, loses, count,grand);
                            all_factions.Add(new_faction);
                        }
                    }
                    Faction_Loader.Close();
                }
            }
            #endregion
            BattleForm new_battle = new BattleForm(ref attacking_army, world_map.get_Army_faction_name(attacking_army.get_faction_ID()), ref defending_army, world_map.get_Army_faction_name(defending_army.get_faction_ID()));
            new_battle.ShowDialog();
            #region everyone_dies
            if(new_battle.get_everyone_died()==true)
            {
                army_grid[attacking_army.get_x_coordinate(), attacking_army.get_y_coordinate()].Dispose();
                army_grid[attacking_army.get_x_coordinate(), attacking_army.get_y_coordinate()] = null;
                army_grid[defending_army.get_x_coordinate(), defending_army.get_y_coordinate()].Dispose();
                army_grid[defending_army.get_x_coordinate(), defending_army.get_y_coordinate()] = null;
                for (int i = 0; i < world_map.get_number_of_factions(); i++)
                {
                    if(world_map.get_faction_from_list(i).get_ID()==attacking_army.get_faction_ID() || world_map.get_faction_from_list(i).get_ID() == defending_army.get_faction_ID())
                    {
                        inspecting_faction = world_map.get_faction_from_list(i);
                        for(int j = 0; j < inspecting_faction.get_Army_Size();j++)
                        {
                            inspecting_army = inspecting_faction.get_army(j);
                            if(inspecting_army.get_x_coordinate()==attacking_army.get_x_coordinate() && inspecting_army.get_y_coordinate() == attacking_army.get_y_coordinate() || inspecting_army.get_x_coordinate() == defending_army.get_x_coordinate() && inspecting_army.get_y_coordinate() == defending_army.get_y_coordinate())
                            {
                                inspecting_faction.remove_army_from_faction(j);
                            }
                        }
                    }
                }
            }
            #endregion
            #region attackers_win
            else if(new_battle.get_team_one_victory()==true)
            {
                army_grid[defending_army.get_x_coordinate(),defending_army.get_y_coordinate()].Dispose();
                army_grid[defending_army.get_x_coordinate(), defending_army.get_y_coordinate()] = null;
                for(int i=0; i < world_map.get_number_of_factions();i++)
                {
                    inspecting_faction = world_map.get_faction_from_list(i);
                    if(inspecting_faction.get_ID() == defending_army.get_faction_ID() || inspecting_faction.get_ID() == attacking_army.get_faction_ID())
                    {
                        for(int j = 0;j<inspecting_faction.get_Army_Size();j++)
                        {
                            inspecting_army = inspecting_faction.get_army(j);
                            if(inspecting_army.get_x_coordinate() == defending_army.get_x_coordinate() && inspecting_army.get_y_coordinate() == defending_army.get_y_coordinate())
                            {
                                inspecting_faction.remove_army_from_faction(j);
                                //inspecting_faction.add_defeat();
                                for(int k =0; k < all_factions.Count;k++)
                                {
                                    if(all_factions[k].get_name().CompareTo(inspecting_faction.get_name())==0)
                                    {
                                        all_factions[k].add_defeat();
                                        MessageBox.Show("Defeat added to "+all_factions[k]+" :"+all_factions[k].get_loses()+"loses.");
                                        break;
                                    }
                                }
                                MessageBox.Show("Defending army has been defeated.");
                            }
                            if(inspecting_army.get_x_coordinate() == attacking_army.get_x_coordinate() && inspecting_army.get_y_coordinate() == attacking_army.get_y_coordinate())
                            {
                                for (int k = 0; k < all_factions.Count; k++)
                                {
                                    if (all_factions[k].get_name().CompareTo(inspecting_faction.get_name()) == 0)
                                    {
                                        all_factions[k].add_victory();
                                        MessageBox.Show("Victory added to " + all_factions[k] + " :" + all_factions[k].get_victories() + "victories.");
                                        break;
                                    }
                                }
                                //inspecting_faction.add_victory();
                            }
                        }
                    }
                }
                attacking_army.augment_heatlh(new_battle.get_life_remaining_from_team_one());
            }
            #endregion
            #region defenders_win
            else if(new_battle.get_team_two_victory()==true)
            {
                army_grid[attacking_army.get_x_coordinate(),attacking_army.get_y_coordinate()].Dispose();
                army_grid[attacking_army.get_x_coordinate(),attacking_army.get_y_coordinate()] = null;
                for (int i = 0; i < world_map.get_number_of_factions(); i++)
                {
                    inspecting_faction = world_map.get_faction_from_list(i);
                    if (inspecting_faction.get_ID() == defending_army.get_faction_ID() || inspecting_faction.get_ID() == attacking_army.get_faction_ID())
                    {
                        for (int j = 0; j < inspecting_faction.get_Army_Size(); j++)
                        {
                            inspecting_army = inspecting_faction.get_army(j);
                            if (inspecting_army.get_x_coordinate() == attacking_army.get_x_coordinate() && inspecting_army.get_y_coordinate() == attacking_army.get_y_coordinate())
                            {
                                inspecting_faction.remove_army_from_faction(j);
                                //inspecting_faction.add_defeat();
                                for (int k = 0; k < all_factions.Count; k++)
                                {
                                    if (all_factions[k].get_name().CompareTo(inspecting_faction.get_name()) == 0)
                                    {
                                        all_factions[k].add_defeat();
                                        MessageBox.Show("Defeat added to " + all_factions[k] + " :" + all_factions[k].get_loses() + "loses.");
                                        break;
                                    }
                                }
                                MessageBox.Show("Attacking army has been defeated.");
                            }
                            if (inspecting_army.get_x_coordinate() == defending_army.get_x_coordinate() && inspecting_army.get_y_coordinate() == defending_army.get_y_coordinate())
                            {
                                for (int k = 0; k < all_factions.Count; k++)
                                {
                                    if (all_factions[k].get_name().CompareTo(inspecting_faction.get_name()) == 0)
                                    {
                                        all_factions[k].add_victory();
                                        MessageBox.Show("Victory added to " + all_factions[k] + " :" + all_factions[k].get_victories() + "victories.");
                                        break;
                                    }
                                }
                                //inspecting_faction.add_victory();
                            }
                        }
                    }
                }
                defending_army.augment_heatlh(new_battle.get_life_remaining_from_team_one());
            }
            #endregion
            #region draw
            else if(new_battle.get_draw()==true)
            {
                attacking_army.augment_heatlh(new_battle.get_life_remaining_from_team_one());
                defending_army.augment_heatlh(new_battle.get_life_remaining_from_team_two());
            }
            #endregion

            #region Write_to_permanent_faction_records
            using (StreamWriter SaveFileTo = File.CreateText(path))
            {
                for (int i = 0; i < all_factions.Count; i++)
                {
                    SaveFileTo.Write(all_factions[i].get_name());
                    SaveFileTo.Write('_');
                    SaveFileTo.Write(all_factions[i].get_ID());
                    SaveFileTo.Write('_');
                    SaveFileTo.Write(all_factions[i].get_gold());
                    SaveFileTo.Write('_');
                    SaveFileTo.Write(all_factions[i].get_victories());
                    SaveFileTo.Write('_');
                    SaveFileTo.Write(all_factions[i].get_loses());
                    SaveFileTo.Write('_');
                    SaveFileTo.Write(all_factions[i].get_total_number_of_armies_count());
                    SaveFileTo.Write('_');
                    SaveFileTo.Write(all_factions[i].get_grand_victories());
                    SaveFileTo.WriteLine();
                }
                SaveFileTo.Close();
            }
            #endregion
            new_battle.Dispose();
        }
        #endregion
    }
}