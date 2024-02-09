using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parkiranje
{
    public partial class KolikoJeSati : Form
    {
        private int sati;
        public int Sati => sati;
        public KolikoJeSati()
        {
            InitializeComponent();
            CenterToScreen();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sati = int.Parse(textBox1.Text);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Broj sati nije lepo unet!", "ERROR");
            }
        }
    }
}
