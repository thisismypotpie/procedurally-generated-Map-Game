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
    public partial class LoadForm : Form
    {

        public LoadForm()
        {
            InitializeComponent();
            
        }
        public LoadForm(int x, int y)//width and height of the entire map. Used when lands are being loaded from the map to a form2.
        {
            InitializeComponent();
            progressBarLands.Maximum = (x*y);
            this.Show();
        }
        public LoadForm(int number_of_tiles, String label_text)//number of tiles used with tiles are being placed onto a map.
        {
            InitializeComponent();
            if(number_of_tiles>=0)
            {
                progressBarLands.Maximum = number_of_tiles;
            }
            else
            {
                progressBarLands.Maximum = 0;
            }
            this.LandsLoadingLabel.Text = label_text + " Loading";
            this.Show();
        }

        public void update_bar()
        {
            this.progressBarLands.Increment(1);
            this.progressBarLands.Refresh();
            Application.DoEvents();
            if(progressBarLands.Value == progressBarLands.Maximum)
            {
                this.Close();
            }
            
        }


    }
}
