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
    public partial class RoundFightForm : Form
    {
        private bool team_one_victory;
        private bool team_two_victory;
        public RoundFightForm()
        {
            InitializeComponent();
            team_one_victory = false;
            team_two_victory = false;
        }

        public RoundFightForm(String team_one, String team_two)
        {
            InitializeComponent();
            TeamOneBtn.Text = team_one;
            TeamTwoBtn.Text = team_two;
            team_two_victory = false;
            team_one_victory = false;
        }

        private void TeamOneBtn_Click(object sender, EventArgs e)
        {
            DialogResult choice =MessageBox.Show("The "+TeamOneBtn.Text+"is victorious?","Vitory",MessageBoxButtons.YesNo);
            if(choice == DialogResult.Yes)
            {
                team_one_victory = true;
                this.Close();
            }
        }

        private void TeamTwoBtn_Click(object sender, EventArgs e)
        {
            DialogResult choice = MessageBox.Show("The " + TeamTwoBtn.Text + "is victorious?", "Vitory", MessageBoxButtons.YesNo);
            if(choice == DialogResult.Yes)
            {
                team_two_victory = true;
                this.Close();
            }
        }

        public bool get_team_one_victory()
        {
            return team_one_victory;
        }

        public bool get_team_two_victory()
        {
            return team_two_victory;
        }
    }
}
