using mata;

namespace Forms
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double x1 = double.Parse(tbx1.Text);
                double y1 = double.Parse(tby1.Text);
                double x2 = double.Parse(tbx2.Text);
                double y2 = double.Parse(tby2.Text);

                double r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
                double O = 2 * r * Mata.PI;
                double P = r * r * Mata.PI;
                obim.Text = O.ToString("0.00");
                povrsina.Text = P.ToString("0.00");
            }
            catch (Exception izuzetak)
            {
                MessageBox.Show(izuzetak.Message);
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            tbx1.Text = "";
            tbx2.Text = "";
            tby1.Text = "";
            tby2.Text = "";
            obim.Text = "";
            povrsina.Text = "";
        }

        private void izadji_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void povrsina_TextChanged(object sender, EventArgs e)
        {

        }

        private void pi_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mata.GetPi(pi_comboBox.Text);
            pi_broj.Text = Mata.PI.ToString();
            obim.Text = "";
            povrsina.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {

        }

        private void timer4_Tick(object sender, EventArgs e)
        {

        }
    }
}