using System.Collections.Immutable;
using System.Net.NetworkInformation;

namespace PogadjanjeKombinacije
{
    public partial class Form1 : Form
    {
        private Kombinacija kombinacija;
        private string pitanje;
        private List<Button> dugmad;
        private int index;
        private PictureBox[,] polja;
        private PictureBox[,] rezultat;
        public Form1()
        {
            InitializeComponent();
            kombinacija = new Kombinacija(4, 6);
            //kombinacija = new Kombinacija("1232", 6);
            index = 0;
            dugmad = new List<Button> { skocko, karo, tref, herc, pik, zvezda };
            polja = new PictureBox[,]
            {
                { pictureBox1,pictureBox2,pictureBox3,pictureBox4,},
                { pictureBox5,pictureBox6,pictureBox7,pictureBox8, },
                { pictureBox9,pictureBox10,pictureBox11,pictureBox12, },
                { pictureBox13,pictureBox14,pictureBox15,pictureBox16, },
                { pictureBox17,pictureBox18,pictureBox19,pictureBox20, },
                { pictureBox21,pictureBox22,pictureBox23,pictureBox24, },
            };

            rezultat = new PictureBox[,] {
                { pictureBox25,pictureBox26,pictureBox27,pictureBox28},
                { pictureBox29,pictureBox30, pictureBox31, pictureBox32},
                { pictureBox33,pictureBox34,pictureBox35,pictureBox36},
                { pictureBox37,pictureBox38,pictureBox39,pictureBox40},
                { pictureBox41,pictureBox42,pictureBox43,pictureBox44},
                { pictureBox45,pictureBox46,pictureBox7,pictureBox48},
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = kombinacija.kombinacijica;
            //this.Text = "Slagalica";
            dugmad.ToList().ForEach(button =>
            {
                button.Click += button_click!;
            });
        }

        private void button_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var image = btn.BackgroundImage;
            int i = index / 4;
            int j = index % 4;
            polja[i, j].BackgroundImage = image;
            int na_mestu = -1;
            int nisu_na_mestu = -1;

            switch (btn.Name)
            {
                case "skocko": pitanje += "1"; break;
                case "karo": pitanje += "2"; break;
                case "tref": pitanje += "3"; break;
                case "herc": pitanje += "4"; break;
                case "pik": pitanje += "5"; break;
                case "zvezda": pitanje += "6"; break;
            }
            if ((index + 1) % 4 == 0)
            {
                string odgovor = kombinacija.odgovor2(pitanje);
                bool bul = pitanje == kombinacija.kombinacijica;

                if (bul)
                {
                    na_mestu = 4;
                    nisu_na_mestu = 0;
                }
                else
                {
                    na_mestu = int.Parse(odgovor.Trim().Split(',')[0]);
                    nisu_na_mestu = int.Parse(odgovor.Trim().Split(',')[1]);
                }


                int ii = 0;
                for (int nm = 0; nm < na_mestu; nm++, ii++)
                {
                    if (ii <= 4)
                        rezultat[i, ii].BackColor = Color.Red;
                }

                for (int nnm = 0; nnm < nisu_na_mestu; nnm++, ii++)
                {
                    if (ii < 4)
                        rezultat[i, ii].BackColor = Color.Yellow;
                }

                if (bul)
                {
                    MessageBox.Show("Pogodili ste kombinaciju!");
                    Application.Exit();
                }

                pitanje = "";
            }
            index++;
        }

        //private void btn_postavi_pitanje_click(object sender, EventArgs e)
        //{
        //    if (unos_je_validan(pitanje))
        //    {
        //        string odgovor = kombinacija.odgovor2(pitanje);

        //        lb_postavljena_pitanja.Items.Add(pitanje);
        //        lb_odgovori.Items.Add(odgovor);
        //        tb_pitanje.Clear();
        //    }
        //    else
        //        MessageBox.Show("Unos nije validan!");
        //}

        private bool unos_je_validan(string pitanje)
        {
            List<char> chars = pitanje.ToCharArray().Where(c => c != ' ').ToList();
            //chars.Insert(0, 'p');
            //chars.Insert(chars.Count, 'k');
            bool valid1 = pitanje.Length == 4;
            bool valid2 = chars.All(c => kombinacija.mogucnosti.Contains(c));
            return valid1 && valid2;
        }

        //private void tb_pitanje_TextChanged(object sender, EventArgs e)
        //{
        //    pitanje = tb_pitanje.Text;
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            int i = index / 4;
            int j = index % 4;
            polja[i, j].BackgroundImage = null;
            if (index - 1 >= 0)
                index--;
        }
    }
}