using parkiranje.Properties;
using System.Reflection.Emit;
using System.Runtime.Versioning;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace parkiranje
{
    public partial class Form1 : Form
    {
        Button[,] parking_mesta;
        Button[] automobili;
        Label[,] vremeParkiranja;
        int[,] vremena;
        Image img;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "Parking";
            CenterToScreen();
            timer1.Tick += timer_tick!;
            timer1.Interval = 1000;
            timer1.Start();

            label1.Text = "Zona 1";
            label2.Text = "Zona 2";
            label3.Text = "Zona 3";

            label1.ForeColor = Color.Red;
            label2.ForeColor = Color.OrangeRed;
            label3.ForeColor = Color.Green;

            vremeParkiranja = new Label[3, 2] {
                { label5,label6},
                {label7,label8},
                {label9,label10},
            };
            foreach (Label l in vremeParkiranja)
            {
                l.Text = "";
            }
            automobili = new Button[2] { button7, button8 };
            for (int i = 0; i < automobili.Length; i++)
            {
                Button auto = automobili[i];
                auto.Text = "";
                auto.BackgroundImage = i == 0 ? Resources.Zuti_auto1 : Resources.beli_auto1;
                auto.BackgroundImageLayout = ImageLayout.Stretch;
                auto.MouseDown += auto_click!;
            }
            parking_mesta = new Button[3, 2] {
                { button1, button2},
                { button3, button4},
                { button5, button6},
            };
            for (int y = 0; y < parking_mesta.GetLength(0); y++)
                for (int x = 0; x < parking_mesta.GetLength(1); x++)
                {
                    Button btn = parking_mesta[y, x];
                    btn.Text = "";
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.MouseDown += button_click!;
                    btn.Tag = new Point(x, y);
                    btn.BackgroundImage = x == 0 ? Resources.parkingmesto1 : Resources.parkingmesto2;
                }
            vremena = new int[3, 2] {
                {0, 0},
                {0, 0},
                {0, 0},
            };
        }
        private void button_click(object sender, MouseEventArgs e)
        {
            Button mesto = (Button)sender;
            Point m = (Point)mesto.Tag;

            if (e.Button == MouseButtons.Left)
            {
                KolikoJeSati forma = new KolikoJeSati();
                forma.ShowDialog();
                int sati = forma.Sati;
                if (sati <= 0)
                    return;

                if (mesto.Image == null)
                    mesto.Image = img;

                trosak(sati * 100);

                vremena[m.Y, m.X] += sati * 60;
                azuriraj_tekst(m.X, m.Y);
            }
        }
        private void auto_click(object sender, MouseEventArgs e)
        {
            Button auto = (Button)sender;
            img = auto.BackgroundImage;
        }
        private void timer_tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 2; j++)
                    if (parking_mesta[i, j].Image != null)
                    {
                        if (vremena[i, j] > 0)
                        {
                            vremena[i, j]--;
                            azuriraj_tekst(i, j);
                        }
                    }
        }
        private void azuriraj_tekst(int i, int j)
        {
            if (vremeParkiranja[i, j] == null)
            {
                Label labela = new Label();
                Point lokacija = parking_mesta[i, j].Location;
                labela.Location = new Point(lokacija.X + 108, lokacija.Y);

                labela.Text = $"{vremena[i, j] / 60}:{vremena[i, j] % 60}";
                this.Controls.Add(labela);
                vremeParkiranja[i, j] = labela;
            }
            else if (vremena[i, j] > 0)
                vremeParkiranja[i, j].Text = $"{vremena[i, j] / 60}:{vremena[i, j] % 60}";
            else
            {
                vremeParkiranja[i, j].Text = "";
                parking_mesta[i, j].Image = null;
                trosak(izracunaj_kaznu(i + 1));
            }
        }
        private int izracunaj_kaznu(int zona)
        {
            switch (zona)
            {
                case 3:
                    return 2000;
                case 2:
                    return 3000;
                case 1:
                    return 4000;
                default:
                    return 0;
            }
        }
        private void trosak(int trosak)
        {
            label4.Text = "Trosak: " + (trosak + int.Parse(label4.Text.Replace("Trosak: ", ""))).ToString();
        }
    }
}
