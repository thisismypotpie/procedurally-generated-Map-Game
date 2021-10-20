using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //I am putting this here to use the picture box object.

namespace Magic_Game
{
    public class Faction
    {
        private String Name;//Name of faction.
        private int Faction_ID; //Integer ID of faction.
        private int gold;//Amount of gold for this faction.
        private List<Army> Armies;//List of all armies for this faction.
        private int total_army_number_count;//How many armies this factions has had total.
        private int victories;//Number of victories for this faction.
        private int defeats;//Number of defeats for this faction.
        private int grand_victories;//Number of times this factions has won the entire game.

        #region Constructors

        //Default constructor
        public Faction()
        {
            Name = "";
            Faction_ID = 0;
            gold = 200;
            total_army_number_count = 0;
            Armies = new List<Army>();
            grand_victories = 0;
            victories = 0;
            defeats = 0;
        }
        //Non-default constructor used for creating a new factions with no armies.
        public Faction(String add_name, int ID, int money, int wins, int losses,int count ,int grand)
        {
            Name = add_name;
            Faction_ID = ID;
            gold = money;
            this.Armies = new List<Army>();
            victories = wins;
            defeats = losses;
            total_army_number_count = 0;
            grand_victories = grand;
            total_army_number_count = count;
        }
        //Non-default constructor used for loading a faction from the save file.
        public Faction(String add_name, int ID, int money, ref List<Army>faction_armies,int wins, int losses, int army_count, int grand)
        {
            Name = add_name;
            Faction_ID = ID;
            gold = money;
            this.Armies = new List<Army>();
            for (int i = 0; i < faction_armies.Count; i++)
            {
                Armies.Add(faction_armies[i]);
            }
            victories = wins;
            defeats = losses;
            total_army_number_count = army_count;
            grand_victories = grand;
        }
        //copy constructor
        public Faction(ref Faction to_copy)
        {
            this.Name = to_copy.get_name();
            this.Faction_ID = to_copy.get_ID();
            this.gold = to_copy.get_gold();
            this.Armies = new List<Army>();
            for (int i = 0; i < to_copy.get_Army_Size();i++ )
            {
                Armies.Add(to_copy.get_army(i));
            }
            this.total_army_number_count = to_copy.total_army_number_count;
            this.grand_victories = to_copy.grand_victories;
            this.victories = to_copy.victories;
            this.defeats = to_copy.defeats;
            
        }
        #endregion

        #region Getters
        //The difference in this function and get army size is that get army size brings back the current number of armies and get army count returns the number of total
        //armies that a factions has had.

        public String get_name()
        {
            return Name;
        }

        public int get_ID()
        {
            return Faction_ID;
        }

        public int get_gold()
        {
            return gold;
        }

        public int get_Army_Size()
        {
            return Armies.Count;
        }

        public int get_victories()
        {
            return victories;
        }

        public int get_loses()
        {
            return defeats;
        }

        public Army get_army(int index)
        {
            if(index<0 || index > (Armies.Count-1))
            {
                MessageBox.Show("Index in get_army function in faction.cs is out of range ."+index,"Out of range error",MessageBoxButtons.OK);
                return null;
            }
            else
            {
                return Armies[index];
            }
        }

        public int get_grand_victories()
        {
            return grand_victories;
        }

        public int get_win_percentage()
        {
            if(victories==0)
            {
                return 0;
            }
            else if(defeats ==0)
            {
                return 100;
            }
            return (int)(((double)victories / ((double)defeats+(double)victories))*100);
        }
 
        public int get_total_number_of_armies_count()
        {
            return total_army_number_count;
        }
        #endregion

        #region Setters
        public void add_Army_to_faction(ref Army to_add)
        {
            //increment_army_number();
            Armies.Add(to_add);
        }

        public void remove_army_from_faction(int to_remove)
        {
            Armies.RemoveAt(to_remove);
        }

        public void change_gold_balance(int to_change)
        {
            gold += to_change;
        }

        public void increment_army_number()
        {
            total_army_number_count++;
        }
        
        public void add_victory()
        {
            victories++;
        }

        public void add_defeat()
        {
            defeats++;
        }

        public void change_army_count(int to_change)
        {
            total_army_number_count = to_change;
        }

        public void add_grand_victory()
        {
            grand_victories++;
        }
        #endregion
    }
}
