using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magic_Game
{
    //This class gets the name of a new faction and then puts it into the map list of factions.
    public partial class FactionAddingForm : Form
    {
        String add_faction_name;//Name of faction
        bool add_faction;//dtermines if add factions button was pressed by user.
        bool add_all_factions;//determines if add all factions button was pressed by user.

        //Default and common Constructor
        public FactionAddingForm()
        {
            InitializeComponent();
            add_faction_name = "";
            add_faction = false;
            add_all_factions = false;
        }

        #region getters

        //Gets a faction name has is in the items list box.
        public String get_faction_from_list(int index)
        {
            if(index > FactionList.Items.Count)
            {
                return null; 
            }
            else
            {
                MessageBox.Show(FactionList.Items[index].ToString());
                return FactionList.Items[index].ToString();
            }
        }

        //Gets the number of unchosen factions in teh items list box.
        public int get_number_of_items()
        {
            return FactionList.Items.Count;
        }

        //Gets add faction button bool.
        public bool get_add_faction_button_press()
        {
            return add_faction;
        }
        //Gets add all factions button bool.
        public bool get_add_all_factions_button_press()
        {
            return add_all_factions;
        }

        //Gets factions chosen by the user.
        public String get_chosen_faction()
        {
            return add_faction_name;
        }
        #endregion
        #region setters
        public void change_add_faction_button(bool to_change)
        {
            add_faction = to_change;
        }

        public void Add_faction_name_to_list(String to_add)
        {
            bool duplicate = false;
            for (int i = 0; i < FactionList.Items.Count; i++)
            {
                if(to_add.CompareTo(FactionList.Items[i].ToString())==0)
                {
                    duplicate = true;
                }
            }
            if(duplicate == false)
            {
                FactionList.Items.Add(to_add);
            }
        }

        public void remove_faction_name_from_list(int to_remove)
        {
            FactionList.Items.RemoveAt(to_remove);
        }
        #endregion
        #region button_actions

        //changes bool for add faction button
        private void AddFactionBtn_Click(object sender, EventArgs e)
        {
            add_faction_name = FactionList.Text;
            add_faction = true;
            this.Hide();
        }

        //changes bool for add all factions button
        private void add_all_btn_Click(object sender, EventArgs e)
        {
            add_all_factions = true;
            this.Hide();
        }
        #endregion
    }
}
