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
    //This class is the form that shows up when a battle is commenced.  There are four options: both teams die, one of the teams wins, or there is a draw and no one
    //dies.
    public partial class BattleForm : Form
    {

        Army team_one;//Attacking army.
        String team_one_faction;//The faction of the attacking army.
        Army team_two;//defending army.
        String team_two_faction;//The faction of the defending army.
        bool team_one_victory;//bool for attacker victory
        bool team_two_victory;//bool for defending victory
        bool everyone_died;//bool for everyone dying.
        bool draw;//bool for a draw.

        #region constructors

        //Default constructor
        public BattleForm()
        {
            InitializeComponent();
        }
        //Common constructor
        public BattleForm(ref Army team_one,String faction_one, ref Army team_two,String faction_two)
        {
            InitializeComponent();
            this.team_one = team_one;
            this.team_two = team_two;
            team_one_faction = faction_one;
            team_two_faction = faction_two;

            team_one_victory = false;
            team_two_victory = false;
            everyone_died = false;
            draw = false;

            TeamNameOneLbl.Text = team_one_faction+ " Army"+" "+this.team_one.get_army_number();
            TeamNameTwoLbl.Text = team_two_faction + " Army" + " " + this.team_two.get_army_number();
            TeamOneHealthLbl.Text = "HP: "+this.team_one.get_health() + "/20";
            TeamTwoHealthLbl.Text = "HP: " + this.team_two.get_health() + "/20";
            TeamOneVictoryBtn.Text = team_one_faction+" Victory";
            TeamTwoVictoryBtn.Text = team_two_faction + " Victory";
            TeamOneHealthRemainingBx.Text = team_one.get_health().ToString();
            TeamTwoHealhRemainingBx.Text = team_two.get_health().ToString();
        }

        #endregion

        #region get_button_push
        //These functions determine which button has been pressed by the user.
        public bool get_team_one_victory()
        {
            return team_one_victory;
        }

        public bool get_team_two_victory()
        {
            return team_two_victory;
        }

        public bool get_everyone_died()
        {
            return everyone_died;
        }

        public bool get_draw()
        {
            return draw;
        }
        #endregion
        #region getters

        //If attackers win, this will get the health remaining inputted by the user.
        public int get_life_remaining_from_team_one()
        {
            int parse = 0;
            int.TryParse(TeamOneHealthRemainingBx.Text, out parse);
            return parse;
        }
        //If defenders win, this will get the health remaining inputted by the uers.
        public int get_life_remaining_from_team_two()
        {
            int parse = 0;
            int.TryParse(TeamTwoHealhRemainingBx.Text, out parse);
            return parse;
        }

        #endregion
        #region button_click_actions
        //These functions are the specific actions if each button on the battleform are clicked.  Each one checks for potential user input errors, and then turns
        //the respective bool true.  Afterward, it closes the battle app.

        private void TeamOneVictoryBtn_Click(object sender, EventArgs e)
        {
            int parse = 0;
            int.TryParse(TeamOneHealthRemainingBx.Text,out parse);
            if(parse<=0)
            {
                MessageBox.Show("Please enter the reamaining health for the victor.  Must be more than zero.");
            }
            else
            {
                team_one_victory = true;
                this.Close();
            }
        }

        private void TeamTwoVictoryBtn_Click(object sender, EventArgs e)
        {
            int parse = 0;
            int.TryParse(TeamTwoHealhRemainingBx.Text, out parse);
            if (parse <= 0)
            {
                MessageBox.Show("Please enter the reamaining health for the victor.  Must be more than zero.");
            }
            else
            {
                team_two_victory = true;
                this.Close();
            }
        }

        private void Draw_btn_Click(object sender, EventArgs e)
        {
            draw = true;
            this.Close();
        }

        private void Everyone_died_btn_Click(object sender, EventArgs e)
        {
            everyone_died = true;
            this.Close();
        }
        #endregion
    }
}
