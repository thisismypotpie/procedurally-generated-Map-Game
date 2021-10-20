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
    //This forms gets the user input for the specifications of the terrain for the map.
    public partial class Form3 : Form
    {
        //Defualt Constructor
        public Form3()
        {
            InitializeComponent();
        }

        //Executes when user clicks the ok button.  A map and form2 get created through which the game is played.
        private void Form3OKButton_Click(object sender, EventArgs e)
        {
            int height = 0;
            int width = 0;
            int percent_water = 0;
            int percent_Forest = 0;
            int percent_Mountain = 0;
            int percent_Plains = 0;

            String path;
            String current_line;
            String[] extracted_numbers;
            String name;
            int faction_ID = 0;
            int gold = 0;
            int wins = 0;
            int loses = 0;
            int army_count=0;
            int grand_victories=0;
            int save_file_game=0;
            Faction new_faction;

            //try
            //{
                int.TryParse(Form3HeightInput.Text, out height);
                int.TryParse(Form3WidthInput.Text, out width);
                int.TryParse(Form3WaterInput.Text, out percent_water);
                int.TryParse(Form3ForestInput.Text, out percent_Forest);
                int.TryParse(Form3MountainInput.Text, out percent_Mountain);
                int.TryParse(Form3PlainsInput.Text, out percent_Plains);
                label1.Text = height.ToString() + " tiles";
                label2.Text = width.ToString() + " tiles";
                label3.Text = percent_water.ToString() + "%";
                label4.Text = percent_Mountain.ToString() + "%";
                label5.Text = percent_Plains.ToString() + "%";
                label6.Text = percent_Forest.ToString() + "%";
                if(height <=0 || width <=0 || percent_water < 0 || percent_Forest < 0 || percent_Mountain < 0 || percent_Plains < 0)
                {
                    MessageBox.Show("You cannot enter a value of less and zero or zero(for width and height).");
                }
              //  try
              //  {
                    if(percent_water + percent_Mountain + percent_Plains + percent_Forest !=100)
                    {
                        MessageBox.Show("Please make sure that all of your terrain percentages add up to 100.");
                    }
                    else
                    {
                        Map test = new Map(height,width,percent_water,percent_Plains,percent_Mountain, percent_Forest);//the chain for the error starts here.
                #region get_save_file
                LoadChooseForm choose_game = new LoadChooseForm();
                this.Hide();
                choose_game.ShowDialog();
                while (save_file_game == 0)
                {
                    if (choose_game.get_game_one_button_press() == true)
                    {
                        save_file_game = 1;
                        MessageBox.Show("Game one chosen.");
                    }
                    else if (choose_game.get_game_two_button_press() == true)
                    {
                        save_file_game = 2;
                        MessageBox.Show("Game two chosen.");

                    }
                    else if (choose_game.get_game_three_button_press() == true)
                    {
                        save_file_game = 3;
                        MessageBox.Show("Game three chosen.");
                    }
                    else
                    {
                        MessageBox.Show("You have not chosen a save file, please choose a save file.");
                        choose_game.Refresh();
                    }
                }
                MessageBox.Show("Out of Loop");
                choose_game.Dispose();
                //this.Show();
                #endregion
                #region load_all_factions
                //path = @"C:\Users\Brandon\Documents\Visual Studio 2013\Projects\Magic Game\Magic Game\FactionSave.txt";
                path = Path.Combine(Environment.CurrentDirectory,@"..\..\","FactionSave.txt");
                        using (StreamReader Faction_Loader = new StreamReader(path))
                        {
                            while (!Faction_Loader.EndOfStream)
                            {
                                current_line = Faction_Loader.ReadLine();
                                extracted_numbers = current_line.Split('_');
                                //MessageBox.Show(extracted_numbers.Length.ToString());
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
                                    //MessageBox.Show(new_faction.get_name());
                                    test.add_to_all_factions(ref new_faction);
                                }
                            }
                            Faction_Loader.Close();
                        }
                #endregion
                MessageBox.Show("loading map");
                        Form2 the_map = new Form2(ref test,save_file_game);
                        this.Hide();
                        this.Dispose(); 
                        the_map.ShowDialog();
                MessageBox.Show("load complete");
                    }
              //  }
              //  catch(Exception)
             //   {
             //       MessageBox.Show("Please make sure that the water, mountain, plains, and forest percentage add up to 100%."+"\n"+"Total: "+(percent_water+percent_Plains+percent_Mountain+percent_Forest).ToString(),"Error",MessageBoxButtons.OK);
           //     }
               

            //}
           // catch(Exception)
           // {
             //   MessageBox.Show("There was an error, please only enter positive numbers.  Please make sure that every box has a number.","Error",MessageBoxButtons.OK);
           // }
           /* Map test = new Map(height, width, percent_water, percent_Plains, percent_Mountain, percent_Forest);
            Form2 the_map = new Form2(test);*/
        }

        //Executes when the form is closed to close the entire program.
        private void btnExitProgram_Click(object sender, EventArgs e)
        {         
            //Application.Exit();
        }
    }
}
