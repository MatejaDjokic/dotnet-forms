using System.ComponentModel;
using System.Net.Sockets;

namespace Sastavi4
{
    public partial class Form1 : Form
    {
        private Polje[,] polja;
        private bool prvi_igra;
        private static int[][] smerovi;
        public Form1()
        {
            InitializeComponent();
            polja = new Polje[6, 7];
            prvi_igra = true;
            smerovi = new int[4][]
            {
                new int[2] {0, -1},
                new int[2] {1, -1},
                new int[2] {1, 0},
                new int[2] {1, 1},
            };

            this.KeyPreview = true;
            this.KeyDown += key!;
        }

        private void key(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                MessageBox.Show($"{Width},{Height}");
            }
        }

        private void polje_click(object sender, EventArgs e)
        {
            Polje polje = (Polje)sender;
            //MessageBox.Show($"r:{polje.red},k:{polje.kolona}");
            int red = -1;
            int kolona = polje.kolona;

            List<Polje> polja_kolone = new List<Polje>();
            for (int i = 0; i < polja.GetLength(0); i++)
            {
                for (int j = 0; j < polja.GetLength(1); j++)
                {
                    if (j == kolona)
                    {
                        polja_kolone.Add(polja[i, j]);
                    }
                }
            }
            red = polja_kolone.Where(pk => pk.status == Status.Prazno).Select(pk => pk.red).Max();
            polja[red, kolona].BackColor = prvi_igra ? Color.Red : Color.Yellow;
            polja[red, kolona].status = prvi_igra ? Status.Crveno : Status.Zuto;
            polja[red, kolona].Enabled = false;
            prvi_igra = !prvi_igra;

            proveri_pobedu(Status.Crveno, red, kolona);
            proveri_pobedu(Status.Zuto, red, kolona);
        }

        private void proveri_pobedu(Status st, int red, int kolona)
        {
            foreach (int[] smer in smerovi)
            {
                int broj_podudarnih_polja = -1;
                List<Polje> podudarna_polja = new List<Polje>();

                for (int smer_gore_dole = -1; smer_gore_dole <= 1; smer_gore_dole += 2)
                {
                    int x_korak = smer[0] * smer_gore_dole;
                    int y_korak = smer[1] * smer_gore_dole;

                    for (int razdaljina = 0; razdaljina <= 5; razdaljina++)
                    {
                        int x = red + x_korak * razdaljina;
                        int y = kolona + y_korak * razdaljina;

                        if (van_table(x, y))
                            break;

                        if (polja[x, y].status == st)
                        {
                            broj_podudarnih_polja++;
                            podudarna_polja.Add(polja[x, y]);
                        }
                        else
                            break;
                    }
                }

                if (broj_podudarnih_polja >= 4)
                {
                    for (int i = 0; i < polja.GetLength(0); i++)
                        for (int j = 0; j < polja.GetLength(1); j++)
                            polja[i, j].BackColor = Color.Green;

                    for (int i = 0; i < podudarna_polja.Count; i++)
                    {
                        Polje polje = polja[podudarna_polja[i].red, podudarna_polja[i].kolona];
                        polje.BackColor = polje.status == Status.Crveno ? Color.Red : Color.Yellow;

                    }

                    string x = "Niko ni";
                    x = st == Status.Crveno ? "Crveni " : x;
                    x = st == Status.Zuto ? "Zuti " : x;
                    MessageBox.Show($"{x}je pobedio!");
                    Application.Exit();
                }
            }
        }

        private bool van_table(int x, int y)
        {
            bool x_valid = x >= 0 && x < polja.GetLength(0);
            bool y_valid = y >= 0 && y < polja.GetLength(1);
            return !(x_valid && y_valid);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    int size = 100;
                    Polje polje = new Polje(j, i);
                    polje.Size = new Size(size, size);
                    polje.Location = new Point(i * size, j * size);
                    polje.Click += polje_click!;
                    polje.BackColor = Color.Green;
                    polje.Text = $"{j},{i}";
                    this.polja[j, i] = (polje);
                    this.Controls.Add(polje);
                }
            }
        }
    }
}