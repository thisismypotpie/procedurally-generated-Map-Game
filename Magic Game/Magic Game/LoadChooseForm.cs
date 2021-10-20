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
    public partial class LoadChooseForm : Form
    {

        bool game_one_pressed;
        bool game_two_pressed;
        bool game_three_pressed;
        public LoadChooseForm()
        {
            InitializeComponent();
            game_one_pressed = false;
            game_two_pressed = false;
            game_three_pressed = false;
        }

        public bool get_game_one_button_press()
        {
            return game_one_pressed;
        }

        public bool get_game_two_button_press()
        {
            return game_two_pressed;
        }

        public bool get_game_three_button_press()
        {
            return game_three_pressed;
        }

        private void GameOneBtn_Click(object sender, EventArgs e)
        {
            game_one_pressed = true;
            this.Close();
        }

        private void GameTwoBtn_Click(object sender, EventArgs e)
        {
            game_two_pressed = true;
            this.Close();
        }

        private void GameThreeBtn_Click(object sender, EventArgs e)
        {
            game_three_pressed = true;
            this.Close();
        }
    }
}
