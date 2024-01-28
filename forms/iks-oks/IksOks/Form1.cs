namespace IksOks
{
    public partial class Form1 : Form
    {
        private Tuple<Button, bool, char>[] fields;
        private bool first_playing;
        private double vreme_od_pocetka;
        private int curr_i, curr_j;

        public Form1()
        {
            InitializeComponent();

            first_playing = true;
            vreme_od_pocetka = 0.0;
            curr_i = 0;
            curr_j = 0;
            this.KeyPreview = true;
            this.KeyUp += new KeyEventHandler(key_press);
        }

        private void form1_load(object sender, EventArgs e)
        {
            this.Text = "IksOks";
            fields = new Tuple<Button, bool, char>[9] {
                Tuple.Create(button1, false, '_'),
                Tuple.Create(button2, false, '_'),
                Tuple.Create(button3, false, '_'),
                Tuple.Create(button4, false, '_'),
                Tuple.Create(button5, false, '_'),
                Tuple.Create(button6, false, '_'),
                Tuple.Create(button7, false, '_'),
                Tuple.Create(button8, false, '_'),
                Tuple.Create(button9, false, '_'),
            };
            fields.ToList().ForEach(f =>
            {
                f.Item1.Visible = false;
                f.Item1.Enabled = false;
                f.Item1.Click += field_click!;
                f.Item1.Text = f.Item3.ToString();
            });
        }

        private void key_press(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.E)
            {
                char[] chars = new char[fields.Length];
                for (int i = 0; i < fields.Length; i++)
                {
                    chars[i] = fields[i].Item1.Text.FirstOrDefault();
                }

                List<string> strs = chars.ToList().Select(x => x.ToString()).ToList();
                for (int i = 0; i < 9; i++)
                {
                    if ((i + 1) % 4 == 0)
                        strs.Insert(i, "\n");
                }
                MessageBox.Show(string.Join("", strs));
            }
        }

        private void field_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int index = int.Parse(btn.Name.Replace("button", "")) - 1;
            fields[index] = Tuple.Create(fields[index].Item1, true, first_playing ? 'X' : 'O');
            btn.Text = fields[index].Item3.ToString();
            if (fields[index].Item2)
                btn.Enabled = false;

            curr_i = index / 3;
            curr_j = index % 3;

            first_playing = !first_playing;
        }

        private bool check(char player)
        {
            if (check_diagonals(player)) return true;
            if (check_horizontals(player)) return true;
            if (check_verticals(player)) return true;
            return false;
        }

        private bool check_horizontals(char player)
        {
            char[] c = fields.Select(x => x.Item1.Text.FirstOrDefault()).ToArray();

            for (int i = 0; i < 3; i++)
                if (c[0 + i * 3] == player &&
                    c[1 + i * 3] == player &&
                    c[2 + i * 3] == player)
                    return true;
            return false;
        }

        private bool check_verticals(char player)
        {
            char[] c = fields.Select(x => x.Item1.Text.FirstOrDefault()).ToArray();
            for (int i = 0; i < 3; i++)
            {
                if (c[0 + i * 1] == player &&
                    c[3 + i * 1] == player &&
                    c[6 + i * 1] == player)
                    return true;
            }
            return false;
        }

        private bool check_diagonals(char player)
        {
            char[] c = fields.Select(x => x.Item1.Text.FirstOrDefault()).ToArray();
            if ((c[0] == player &&
                c[4] == player &&
                c[8] == player) ||
                (c[2] == player &&
                c[4] == player &&
                c[6] == player))
                return true;
            return false;
        }

        private void zapocni_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            fields.ToList().ForEach(x =>
            {
                x.Item1.Enabled = true;
                x.Item1.Visible = true;
            });
            game_timer.Start();
            btn.Enabled = false;
            btn.TabIndex = 0;
            btn.Visible = false;
        }

        private void game_timer_tick(object sender, EventArgs e)
        {
            vreme_od_pocetka += (double)game_timer.Interval / 1000;
            this.Text = $"IksOks: {vreme_od_pocetka.ToString("0.0")} s";

            if (check('X'))
            {
                new Message("Prvi igrac je pobedio!", vreme_od_pocetka).Show();
                game_timer.Stop();
            }
            if (check('O'))
            {
                new Message("Drugi igrac je pobedio!", vreme_od_pocetka).Show();
                game_timer.Stop();
            }
            if (fields.Select(x => x.Item2).All(x => x) && !check('O') && !check('X'))
            {
                new Message("Nereseno je!", vreme_od_pocetka).Show();
                game_timer.Stop();
            }
        }
    }
}