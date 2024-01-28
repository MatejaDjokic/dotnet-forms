namespace Memorije
{
    public partial class Form1 : Form
    {
        private const int NUMBER_OF_PAIRS = 9;
        private char[] patterns;
        private List<Card> cards;
        private int[] opened;
        private int num_of_tries;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyUp += key_up;
            cards = new List<Card>();
            opened = new int[2] { -1, -1 };
            num_of_tries = 0;
            patterns = new char[NUMBER_OF_PAIRS] { '@', '#', '!', '?', '%', '*', '$', '^', '>' };
        }

        private void key_up(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                String str = String.Empty;

                cards.ForEach(c =>
                {
                    char x = c.found ? '1' : '0';
                    str += $"{c.id}: {x}\n";
                });

                MessageBox.Show(str);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<char> cs = new List<char>();
            patterns.ToList().ForEach(pattern =>
            {
                cs.Add(pattern);
                cs.Add(pattern);
            });

            Random rng = new Random();
            cs = cs.OrderBy(a => rng.Next()).ToList();

            int index = 0;
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 6; i++)
                {
                    Card card = new Card(cs[index], index);
                    int size = 120;
                    card.Size = new Size(size, size);
                    card.Font = new Font("Segoe UI", 24);
                    card.Padding = new Padding(0);
                    card.Location = new Point(i * size, j * size);
                    cards.Add(card);
                    index++;
                }
            }

            cards.ForEach(card =>
            {
                card.Click += card_click;
                this.Controls.Add(card);
            });
        }

        private async void card_click(object sender, EventArgs e)
        {
            Card crd = (Card)sender;
            if (!opened.Contains(crd.id))
            {
                if (opened[0] == -1)
                {
                    opened[0] = crd.id;
                    crd.Text = crd.value.ToString();
                }
                else if (opened[1] == -1)
                {
                    opened[1] = crd.id;
                    crd.Text = crd.value.ToString();

                    Card first = cards.Where(c => opened[0] == c.id).FirstOrDefault()!;
                    Card second = cards.Where(c => opened[1] == c.id).FirstOrDefault()!;

                    await Delay(500);
                    if (first.value != second.value)
                    {
                        first.Text = "";
                        second.Text = "";
                    }
                    else if (first.value == second.value)
                    {
                        first.BackColor = Color.Green;
                        first.found = true;
                        second.BackColor = Color.Green;
                        second.found = true;
                    }
                    opened[1] = -1;
                    opened[0] = -1;
                    num_of_tries++;
                    label1.Text = $"Broj poteza: {num_of_tries}";
                    if (cards.All(c => c.found))
                    {
                        MessageBox.Show($"Otkrili ste sve kartice iz {num_of_tries} poteza!");
                        Application.Exit();
                    }
                }
            }
        }
        private async Task Delay(int miliseconds) => await Task.Delay(miliseconds);
    }
}