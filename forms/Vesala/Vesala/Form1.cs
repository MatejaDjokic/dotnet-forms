using System.Globalization;
using System.Net.NetworkInformation;

namespace Vesala
{
    public partial class Form1 : Form
    {
        private static string[] slova = {
            "a", "b", "c", "č", "ć", "d",
            "dž", "đ", "e", "f", "g", "h",
            "i", "j", "k", "l", "lj", "m",
            "n", "nj", "o", "p", "r", "s",
            "š", "t", "u", "v", "z", "ž" };
        private List<CustomButton> slova_buttons;
        private List<CustomLabel> labels;
        private string word;
        private int broj_gresaka;
        private Graphics g;
        public Form1(string word)
        {
            InitializeComponent();

            this.word = word;
            this.broj_gresaka = 0;
            this.g = CreateGraphics();

            slova_buttons = new List<CustomButton>();
            labels = new List<CustomLabel>();
            this.KeyPreview = true;
            this.KeyDown += key_down!;
            this.MouseClick += mouse_click!;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int index = 0;
            for (int j = 1; j >= 0; j--)
            {
                for (int i = 0; i < 15; i++)
                {
                    CustomButton btn = new CustomButton(slova[index]);
                    int size = 30;
                    btn.Size = new Size(size, size);
                    btn.Location = new Point(i * size, 388 - j * size);
                    btn.Text = btn.value.ToUpper();
                    btn.Click += slovo_click!;
                    this.slova_buttons.Add(btn);
                    this.Controls.Add(btn);
                    index++;
                }
            }
            generate_empty_letters();
        }

        private void mouse_click(object sender, MouseEventArgs e)
        {
        }

        private void key_down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back) { }
        }

        private void generate_empty_letters()
        {
            String[] letters = word.ToCharArray().Select(x => x.ToString()).ToArray();
            for (int i = 0; i < letters.Length; i++)
            {
                CustomLabel label = new CustomLabel(letters[i]);
                int size = 14;
                label.Size = new Size(size, size * 2);
                label.Location = new Point(Width / 2 + i * size - letters.Length * (size / 2), Height / 2 + 75);
                label.Font = new Font("Segoe UI", 12);
                label.Text = label.value == " " ? "" : "_";
                this.labels.Add(label);
                this.Controls.Add(label);
            }
        }

        private void slovo_click(object sender, EventArgs e)
        {
            CustomButton btn = (CustomButton)sender;
            string[] w = this.word.ToCharArray().Select(c => c.ToString()).ToArray();

            int p = 0;
            List<int> indeksi = new List<int>();
            while ((p = word.IndexOf(btn.value, p)) != -1)
            {
                indeksi.Add(p);
                p++;
            }

            if (indeksi.Count > 0)
                indeksi.ForEach(i => labels[i].show());
            else
            {
                this.broj_gresaka++;
                this.nacrtaj();
            }
            btn.Enabled = false;

            if (broj_gresaka >= 7)
            {
                MessageBox.Show($"Izgubili ste!");
                this.Hide();

            }

            if (labels.Select(l => l.opened).All(o => o))
            {
                MessageBox.Show($"Pogodio si rec sa {this.broj_gresaka} gresaka!");
                this.Hide();
            }
        }

        private void nacrtaj()
        {
            Pen p = new Pen(Color.Black);
            Brush b = new SolidBrush(Color.Black);
            switch (this.broj_gresaka)
            {
                case 1: vesalo1(p); break;
                case 2: vesalo2(p); break;
                case 3: vesalo3(p); break;
                case 4: glava(p); break;
                case 5: telo(p); break;
                case 6: ruke(p); break;
                case 7: noge(p); break;
            }
        }

        private void vesalo1(Pen p)
        {
            this.g.DrawLine(
                new Pen(Color.Black),
                new Point(217, 43),
                new Point(217, 290)
                );
        }
        private void vesalo2(Pen p)
        {
            this.g.DrawLine(
                new Pen(Color.Black),
                new Point(120, 43),
                new Point(217, 43)
                );
        }
        private void vesalo3(Pen p)
        {
            this.g.DrawLine(
                new Pen(Color.Black),
                new Point(120, 43),
                new Point(120, 100)
                );
        }

        private void glava(Pen p)
        {
            int r = 30;
            Rectangle rect = new Rectangle(120 - r / 2, 100, r, r);
            this.g.DrawEllipse(p, rect);
        }
        private void telo(Pen p)
        {
            this.g.DrawLine(
                p,
                new Point(120, 130),
                new Point(120, 230)
                );
        }
        private void ruke(Pen p)
        {
            this.g.DrawLine(
                p,
                new Point(120, 130),
                new Point(120 - 30, 100 + 60)
                );
            this.g.DrawLine(
                p,
                new Point(120, 130),
                new Point(120 + 30, 100 + 60)
                );
        }
        private void noge(Pen p)
        {
            this.g.DrawLine(
                p,
                new Point(120, 230),
                new Point(120 - 30, 200 + 60)
                );
            this.g.DrawLine(
                p,
                new Point(120, 230),
                new Point(120 + 30, 200 + 60)
                );

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.ToLower() == this.word)
            {
                MessageBox.Show($"Pogodio si rec sa {this.broj_gresaka} gresaka!");
                this.Hide();
            }
        }
    }
}