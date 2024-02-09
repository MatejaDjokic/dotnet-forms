using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minolovac
{
    public partial class Pocetak : Form
    {
        private int num_of_mines;

        public Pocetak()
        {
            InitializeComponent();

            num_of_mines = 0;
        }

        private void pocetak_load(object sender, EventArgs e)
        {
            play_btn.Enabled = false;
        }


        private void play_btn_click(object sender, EventArgs e)
        {
            Minolovac minolovac = new Minolovac(num_of_mines);
            this.Hide();
            minolovac.Show();
        }

        private void tb_mine_number_text_changed(object sender, EventArgs e)
        {

            try
            {
                tb_mine_number.ForeColor = Color.Black;
                int max_mines = (int)Math.Round(Math.Pow(10, 2) / 2.0);
                this.num_of_mines = int.Parse(tb_mine_number.Text);
                play_btn.Enabled = true;
                if (this.num_of_mines > max_mines || this.num_of_mines < 1 || tb_mine_number.Text == "")
                {
                    tb_mine_number.ForeColor = Color.Red;
                    play_btn.Enabled = false;
                }
            }
            catch
            {
                tb_mine_number.ForeColor = Color.Red;
                play_btn.Enabled = false;
            }
        }
    }
}
