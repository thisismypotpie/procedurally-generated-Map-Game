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
    public partial class TourneyForm : Form
    {
        private List<Faction> Faction_list;
        private List<Faction> winners_bracket;
        private List<Faction> losers_bracket;
        //private int round;
        private int match;
        private List<PictureBox> round_images;
        private Faction[,] pairs;
        private int all_picture_size;
        private int displace_picture_box;

        public TourneyForm()
        {
            InitializeComponent();
            Faction_list = new List<Faction>();
            winners_bracket = new List<Faction>();
            losers_bracket = new List<Faction>();
            round_images = new List<PictureBox>();
            pairs = new Faction[0,0];
            //round = 1;
            match = 1;
            all_picture_size = 40;
            displace_picture_box = 20;
            MatchButton.Hide();
            load_factions();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult choice;
            choice =MessageBox.Show("Start new tournament?","New Tournament",MessageBoxButtons.YesNo);
            if (choice == DialogResult.Yes)
            {
                //Puts all factions into winner's bracket so that they can be divided up into a bracket including everyone.
                for(int i=0; i < Faction_list.Count;i++)
                {
                    winners_bracket.Add(Faction_list[i]);
                }
                //this.Height = Faction_list.Count * 50;
                make_new_bracket();
                MatchButton.Location = new Point(displace_picture_box,displace_picture_box +2*(all_picture_size));
                MatchButton.Show();
                MatchButton.BringToFront();
            }
        }

        private void continueGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_tournament();
            //implement retrieved data.
        }

        private void make_new_bracket()
        {
            #region random_match_up
            Random rnd = new Random();
            int chosen_index = 0;
            if(winners_bracket.Count == 1)
            {
                MessageBox.Show(winners_bracket[0].get_name()+" is victorious!");
                //winners_bracket[0].add_grand_victory();
                //save_factions();
                this.Dispose();
            }
            //Resizes pairs to the size of the new bracket.
            if(winners_bracket.Count%2==0)
            {
                pairs = new Faction[(winners_bracket.Count / 2), 2];
            }
            else
            {
                pairs = new Faction[(winners_bracket.Count / 2) + 1, 2];
            }
            if(losers_bracket.Count > 0)//empties the loser's bracket.
            {
                losers_bracket.RemoveRange(0, losers_bracket.Count);
            }

            while(winners_bracket.Count >0)
            {
                chosen_index = rnd.Next(0,winners_bracket.Count);
                for(int i=0; i < Faction_list.Count;i++)
                {
                    if(Faction_list[i].get_ID() == winners_bracket[chosen_index].get_ID())
                    {
                        for(int j=0; j < pairs.GetLength(0); j++)
                        {
                            if(pairs[j,0]==null)
                            {
                                pairs[j, 0] = Faction_list[i];
                                break;
                            }
                            else if(pairs[j,1]==null)
                            {
                                pairs[j, 1] = Faction_list[i];
                                break;
                            }
                        }
                        winners_bracket.RemoveAt(chosen_index);
                        break;
                    }
                }
            }
            /*for (int i = 0; i < pairs.GetLength(0); i++)
            {
                if (pairs[i, 0] != null && pairs[i, 1] != null)
                {
                    MessageBox.Show((i + 1) + ". " + pairs[i, 0].get_name() + " and " + pairs[i, 1].get_name());
                }
                else if (pairs[i, 0] != null && pairs[i, 1] == null)
                {
                    MessageBox.Show(pairs[i, 0].get_name() + " has no partner.");
                }
                else if (pairs[i, 0] == null && pairs[i, 1] == null)
                {
                    MessageBox.Show("Error: empty set.");
                }
                else
                {
                    MessageBox.Show("Man, I don't even know, I'm going to bed.");
                }
            }*/
            #endregion
            #region add_sprites
            Image Auxilex = (Image)(new Bitmap(Properties.Resources.Auxilex_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Azorius = (Image)(new Bitmap(Properties.Resources.Azorius_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Boros = (Image)(new Bitmap(Properties.Resources.Boros_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Dimir = (Image)(new Bitmap(Properties.Resources.Dimir_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Drogskol = (Image)(new Bitmap(Properties.Resources.Drogskol_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Drohl_Tide = (Image)(new Bitmap(Properties.Resources.Drohl_Tide_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Firefolk = (Image)(new Bitmap(Properties.Resources.Firefolk_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Glint_Leaf = (Image)(new Bitmap(Properties.Resources.Glint_Leaf_Symbol, new Size(all_picture_size, all_picture_size)));
            Image Golgari = (Image)(new Bitmap(Properties.Resources.Golgari_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Gruul = (Image)(new Bitmap(Properties.Resources.Gruul_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Howlpack = (Image)(new Bitmap(Properties.Resources.Howlpack_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Hruktar = (Image)(new Bitmap(Properties.Resources.Hruktar_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Immurtius = (Image)(new Bitmap(Properties.Resources.Immutius_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Izzet = (Image)(new Bitmap(Properties.Resources.Izzet_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Lex_Imperium = (Image)(new Bitmap(Properties.Resources.Lex_Imperium_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Nimium = (Image)(new Bitmap(Properties.Resources.Nimium_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Orzhov = (Image)(new Bitmap(Properties.Resources.Orzhov_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Parcorium = (Image)(new Bitmap(Properties.Resources.Parcorium_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Phyrexian = (Image)(new Bitmap(Properties.Resources.Phyrexian_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Rakdos = (Image)(new Bitmap(Properties.Resources.Rakdos_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Roxveard = (Image)(new Bitmap(Properties.Resources.Roxveard_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Selesnya = (Image)(new Bitmap(Properties.Resources.Selesnya_Sigil, new Size(all_picture_size,all_picture_size)));
            Image Simic = (Image)(new Bitmap(Properties.Resources.Simic_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Vallatus = (Image)(new Bitmap(Properties.Resources.Vallatus_Sigil, new Size(all_picture_size, all_picture_size)));
            Image Zeplitor = (Image)(new Bitmap(Properties.Resources.Zeplitor_Sigil, new Size(all_picture_size, all_picture_size)));
            Image null_symbol = (Image)(new Bitmap(Properties.Resources.tourney_null, new Size(all_picture_size, all_picture_size)));
            Bitmap match_ups = new Bitmap(all_picture_size, (all_picture_size * Faction_list.Count)+(all_picture_size * Faction_list.Count)/2 + all_picture_size*2);
            Graphics g = Graphics.FromImage(match_ups);
            Image chosen_image= null;
            int Displced_pixels = 0;
            for(int i=0;i < pairs.GetLength(0);i++)
            {
                #region choosing_zero_element
                if(pairs[i,0]==null)
                {
                    chosen_image = null_symbol;
                }
                else if (pairs[i, 0].get_ID() ==1)
                {
                    chosen_image = Auxilex;
                }
                else if (pairs[i, 0].get_ID() ==2)
                {
                    chosen_image = Azorius;
                }
                else if (pairs[i, 0].get_ID() ==3)
                {
                    chosen_image = Boros;
                }
                else if (pairs[i, 0].get_ID() ==4)
                {
                    chosen_image = Dimir;
                }
                else if (pairs[i, 0].get_ID() ==5)
                {
                    chosen_image = Drogskol;
                }
                else if (pairs[i, 0].get_ID() ==6)
                {
                    chosen_image = Drohl_Tide;
                }
                else if (pairs[i, 0].get_ID() ==7)
                {
                    chosen_image = Firefolk;
                }
                else if (pairs[i, 0].get_ID() ==8)
                {
                    chosen_image = Glint_Leaf;
                }
                else if (pairs[i, 0].get_ID() ==9)
                {
                    chosen_image = Golgari;
                }
                else if (pairs[i, 0].get_ID() ==10)
                {
                    chosen_image = Gruul;
                }
                else if (pairs[i, 0].get_ID() ==11)
                {
                    chosen_image = Howlpack;
                }
                else if (pairs[i, 0].get_ID() ==12)
                {
                    chosen_image = Hruktar;
                }
                else if (pairs[i, 0].get_ID() ==13)
                {
                    chosen_image = Immurtius;
                }
                else if (pairs[i, 0].get_ID() ==14)
                {
                    chosen_image = Izzet;
                }
                else if (pairs[i, 0].get_ID() ==15)
                {
                    chosen_image = Lex_Imperium;
                }
                else if (pairs[i, 0].get_ID() ==16)
                {
                    chosen_image = Nimium;
                }
                else if (pairs[i, 0].get_ID() ==17)
                {
                    chosen_image = Orzhov;
                }
                else if (pairs[i, 0].get_ID() ==18)
                {
                    chosen_image = Parcorium;
                }
                else if (pairs[i, 0].get_ID() ==19)
                {
                    chosen_image = Phyrexian;
                }
                else if (pairs[i, 0].get_ID() ==20)
                {
                    chosen_image = Rakdos;
                }
                else if (pairs[i, 0].get_ID() ==21)
                {
                    chosen_image = Roxveard;
                }
                else if (pairs[i, 0].get_ID() ==22)
                {
                    chosen_image = Selesnya;
                }
                else if (pairs[i, 0].get_ID() ==23)
                {
                    chosen_image = Simic;
                }
                else if (pairs[i, 0].get_ID() ==24)
                {
                    chosen_image = Vallatus;
                }
                else if (pairs[i, 0].get_ID() ==25)
                {
                    chosen_image = Zeplitor;
                }
                g.DrawImage(chosen_image,0,(i*all_picture_size)+Displced_pixels);
                Displced_pixels += all_picture_size;
                #endregion
                #region choosing_first_element
                if (pairs[i, 1] == null)
                {
                    chosen_image = null_symbol;
                }
                else if (pairs[i, 1].get_ID() == 1)
                {
                    chosen_image = Auxilex;
                }
                else if (pairs[i, 1].get_ID() == 2)
                {
                    chosen_image = Azorius;
                }
                else if (pairs[i, 1].get_ID() == 3)
                {
                    chosen_image = Boros;
                }
                else if (pairs[i, 1].get_ID() == 4)
                {
                    chosen_image = Dimir;
                }
                else if (pairs[i, 1].get_ID() == 5)
                {
                    chosen_image = Drogskol;
                }
                else if (pairs[i, 1].get_ID() == 6)
                {
                    chosen_image = Drohl_Tide;
                }
                else if (pairs[i, 1].get_ID() == 7)
                {
                    chosen_image = Firefolk;
                }
                else if (pairs[i, 1].get_ID() == 8)
                {
                    chosen_image = Glint_Leaf;
                }
                else if (pairs[i, 1].get_ID() == 9)
                {
                    chosen_image = Golgari;
                }
                else if (pairs[i, 1].get_ID() == 10)
                {
                    chosen_image = Gruul;
                }
                else if (pairs[i, 1].get_ID() == 11)
                {
                    chosen_image = Howlpack;
                }
                else if (pairs[i, 1].get_ID() == 12)
                {
                    chosen_image = Hruktar;
                }
                else if (pairs[i, 1].get_ID() == 13)
                {
                    chosen_image = Immurtius;
                }
                else if (pairs[i, 1].get_ID() == 14)
                {
                    chosen_image = Izzet;
                }
                else if (pairs[i, 1].get_ID() == 15)
                {
                    chosen_image = Lex_Imperium;
                }
                else if (pairs[i, 1].get_ID() == 16)
                {
                    chosen_image = Nimium;
                }
                else if (pairs[i, 1].get_ID() == 17)
                {
                    chosen_image = Orzhov;
                }
                else if (pairs[i, 1].get_ID() == 18)
                {
                    chosen_image = Parcorium;
                }
                else if (pairs[i, 1].get_ID() == 19)
                {
                    chosen_image = Phyrexian;
                }
                else if (pairs[i, 1].get_ID() == 20)
                {
                    chosen_image = Rakdos;
                }
                else if (pairs[i, 1].get_ID() == 21)
                {
                    chosen_image = Roxveard;
                }
                else if (pairs[i, 1].get_ID() == 22)
                {
                    chosen_image = Selesnya;
                }
                else if (pairs[i, 1].get_ID() == 23)
                {
                    chosen_image = Simic;
                }
                else if (pairs[i, 1].get_ID() == 24)
                {
                    chosen_image = Vallatus;
                }
                else if (pairs[i, 1].get_ID() == 25)
                {
                    chosen_image = Zeplitor;
                }
                g.DrawImage(chosen_image,0,(i * all_picture_size)+Displced_pixels);
                Displced_pixels += all_picture_size;
                #endregion
            }
            match_ups.Save("match_ups", System.Drawing.Imaging.ImageFormat.Jpeg);
            PictureBox new_round = new PictureBox();
            new_round.Image = match_ups;
            new_round.ClientSize = new Size(all_picture_size, (all_picture_size * Faction_list.Count)+(all_picture_size * Faction_list.Count)/2 + all_picture_size*2);
            new_round.Location = new System.Drawing.Point(displace_picture_box,displace_picture_box);
            this.Controls.Add(new_round);
            new_round.Show();
            #endregion
            #region create_labels
            #region generate_labels
            List<Label> all_labels = new List<Label>();
            int grabbed_height = (all_picture_size+displace_picture_box)/2;
            for(int i=0; i < pairs.GetLength(0);i++)
            {
                #region text
                if(pairs[i,0]!=null)
                {
                    all_labels.Add(new Label());
                    all_labels[all_labels.Count-1].Text = pairs[i, 0].get_name();
                    all_labels.Add(new Label());
                    all_labels[all_labels.Count - 1].Text = "VS";
                }
                if(pairs[i,1]!=null)
                {
                    all_labels.Add(new Label());
                    all_labels[all_labels.Count-1].Text = pairs[i, 1].get_name();
                }
                else
                {
                    all_labels.Add(new Label());
                    all_labels[all_labels.Count-1].Text = "Wild Card";
                }
                #endregion
            }
            for(int i=0; i < all_labels.Count;i++)
            {
                if(i%3==0)//first pair
                {
                    //MessageBox.Show("1");
                    all_labels[i].Location = new Point(displace_picture_box + (all_picture_size),grabbed_height);
                    grabbed_height += displace_picture_box;
                    //MessageBox.Show("Grabbed hieght: "+grabbed_height);
                }
                else if(all_labels[i].Text.CompareTo("VS")==0)//vs
                {
                    //MessageBox.Show("2");
                    all_labels[i].Location = new Point(displace_picture_box + (all_picture_size),grabbed_height);
                    grabbed_height += displace_picture_box;
                    //MessageBox.Show("Grabbed hieght: " + grabbed_height);
                }
                else//second pair
                {
                    //MessageBox.Show("3");
                    all_labels[i].Location = new Point(displace_picture_box + (all_picture_size),grabbed_height);
                    grabbed_height +=2*all_picture_size;
                    //MessageBox.Show("Grabbed hieght: " + grabbed_height);
                }
                this.Controls.Add(all_labels[i]);
                all_labels[i].Show();
                all_labels[i].BringToFront();
            }

            #endregion
            #endregion

        }

        private void load_factions()
        {
            String path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "FactionSave.txt");
            String name;
            int ID;
            int wins;
            int loses;
            int gold;
            int count;
            int grand;
            String current_line;
            String[] extracted_numbers;

            #region faction_load
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
                            Faction new_faction = new Faction(name, ID, gold, wins, loses, count, grand);
                            Faction_list.Add(new_faction);
                        }
                    }
                    Faction_Loader.Close();
                }
            }
            #endregion

        }

        private void load_tournament()
        {

        }

        private void save_factions()
        {
            String path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "FactionSave.txt");
            if (File.Exists(path))
            {
                using (StreamWriter SaveFileTo = File.CreateText(path))
                {
                    for (int i = 0; i < Faction_list.Count; i++)
                    {
                        SaveFileTo.Write(Faction_list[i].get_name());
                        SaveFileTo.Write('_');
                        SaveFileTo.Write(Faction_list[i].get_ID());
                        SaveFileTo.Write('_');
                        SaveFileTo.Write(Faction_list[i].get_gold());
                        SaveFileTo.Write('_');
                        SaveFileTo.Write(Faction_list[i].get_victories());
                        SaveFileTo.Write('_');
                        SaveFileTo.Write(Faction_list[i].get_loses());
                        SaveFileTo.Write('_');
                        SaveFileTo.Write(Faction_list[i].get_total_number_of_armies_count());
                        SaveFileTo.Write('_');
                        SaveFileTo.Write(Faction_list[i].get_grand_victories());
                        SaveFileTo.WriteLine();
                    }
                }
            }

        }

        private void save_tournament()
        {
            String path = "";
        }

        private void MatchButton_Click(object sender, EventArgs e)
        {
            if(pairs[match-1,1]==null)
            {
                int chosen_index = 0;
                Random rnd = new Random();
                chosen_index = rnd.Next(0,losers_bracket.Count-1);
                MessageBox.Show(losers_bracket[chosen_index].get_name()+" has been chosen for the wild card.");
                pairs[match - 1, 1] = losers_bracket[chosen_index];
                losers_bracket.RemoveAt(chosen_index);
            }
            RoundFightForm fight_form = new RoundFightForm(pairs[match-1,0].get_name(),pairs[match-1,1].get_name());
            //this.Hide();
            fight_form.ShowDialog();
            if(fight_form.get_team_one_victory()==true)
            {
                //pairs[match - 1, 0].add_victory();
                winners_bracket.Add(pairs[match-1,0]);
                //pairs[match - 1, 1].add_defeat();
                losers_bracket.Add(pairs[match-1,1]);
                //save_factions();
            }
            else if(fight_form.get_team_two_victory()==true)
            {
                //pairs[match - 1, 1].add_victory();
                winners_bracket.Add(pairs[match-1,1]);
                //pairs[match - 1, 0].add_defeat();
                losers_bracket.Add(pairs[match-1,0]);
                //save_factions();
            }
            else
            {
                fight_form.Dispose();
                MessageBox.Show("There was an error, returning to previous screen.");
                MatchButton_Click(sender, e);
            }
            match++;
            if(match-1 == pairs.GetLength(0))//end of a bracket.
            {
                clear_form_pictures_and_boxes();
                make_new_bracket();
                this.Width = 400;
                this.Height = 400;
                match = 1;
                MatchButton.Location = new Point(displace_picture_box, displace_picture_box + 2 * (all_picture_size));
            }
            else
            {
                MatchButton.Location = new Point(MatchButton.Location.X, MatchButton.Location.Y + 3 * (all_picture_size));
            }
        }

        private void clear_form_pictures_and_boxes()
        {
                for(int i=0; i < this.Controls.Count;i++)
                {
                    if(this.Controls[i] is Label)
                    {
                        this.Controls[i].Dispose();
                    }
                    if(this.Controls[i] is PictureBox)
                    {
                        this.Controls[i].Dispose();
                    }
                }
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label)
                    (ctrl as Label).Hide();
            }
        }
    }
}
