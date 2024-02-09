using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking
{
    public partial class HowMuch : Form
    {
        private int _hours = 0;
        public int hours => _hours;
        public HowMuch()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _hours = Convert.ToInt32(textBox1.Text);
            }
            catch { }
        }

        private void HowMuch_Load(object sender, EventArgs e)
        {
            button1.Text = "Uplati";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
