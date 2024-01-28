using System.CodeDom;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.Versioning;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        String tekst;
        double vreme1;
        double vreme2;
        bool prvi_igrac;
        bool prvi_moze_da_pokusa;
        bool drugi_moze_da_pokusa;

        List<CButton> sva_polja;
        List<CButton> polu_polja;
        List<CButton> a_polja = new List<CButton>();
        List<CButton> b_polja = new List<CButton>();
        List<CButton> c_polja = new List<CButton>();
        List<CButton> d_polja = new List<CButton>();

        int a_counter;
        int b_counter;
        int c_counter;
        int d_counter;

        int poeni1;
        int poeni2;
        int prvi_counter;
        int drugi_counter;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            prvi_igrac = true;
            poeni1 = 0;
            poeni2 = 0;
            sva_polja = new List<CButton>() { a, a1, a2, a3, a4, b, b1, b2, b3, b4, c, c1, c2, c3, c4, d, d1, d2, d3, d4, konacno };
            polu_polja = new List<CButton>() { a, b, c, d };
            a_polja = new List<CButton>() { a1, a2, a3, a4 };
            b_polja = new List<CButton>() { b1, b2, b3, b4 };
            c_polja = new List<CButton>() { c1, c2, c3, c4 };
            c_polja = new List<CButton>() { c1, c2, c3, c4 };

            a_counter = 0;
            b_counter = 0;
            c_counter = 0;
            d_counter = 0;

            textBox1.Enabled = false;

            vreme1 = 10.0;
            vreme2 = 10.0;
            prvi_moze_da_pokusa = false;
            drugi_moze_da_pokusa = false;

            label1.Text = vreme1.ToString();
            label2.Text = vreme2.ToString();
            label3.Text = poeni1.ToString();
            label4.Text = poeni2.ToString();

            timer1.Interval = 100;
            timer2.Interval = 100;

            timer1.Start();
            timer2.Stop();

            textBox1.TextChanged += TextBox1_TextChanged!;

            polu_polja.ForEach(pp => pp.Enabled = false);
            konacno.Enabled = false;
        }

        private void specijalno_polje(object sender, EventArgs e)
        {
            if ((prvi_igrac && prvi_counter != 2) || (!prvi_igrac && drugi_counter != 2))
            {
                Color boja = Color.LightBlue;
                CButton btn = (CButton)sender;
                bool jednako = btn.resenje == this.tekst;
                if (jednako)
                {
                    btn.Text = btn.resenje;
                    btn.Enabled = false;
                    if (prvi_igrac)
                    {
                        boja = Color.LightBlue;
                        btn.BackColor = boja;
                        prvi_moze_da_pokusa = false;
                    }
                    else if (drugi_moze_da_pokusa)
                    {
                        boja = Color.Red;
                        btn.BackColor = boja;
                        drugi_moze_da_pokusa = false;
                    }

                    List<CButton> dugmici = new List<CButton>();
                    if (btn.klasa == "a")
                        dugmici = a_polja;
                    else if (btn.klasa == "b")
                        dugmici = b_polja;
                    else if (btn.klasa == "c")
                        dugmici = c_polja;
                    else if (btn.klasa == "d")
                        dugmici = d_polja;
                    else if (btn.klasa == "konacno")
                        dugmici = sva_polja;

                    dugmici.ForEach(d =>
                    {
                        d.BackColor = boja;
                    });
                }
                else
                {
                    MessageBox.Show("Netacan odgovor");
                    tekst = "";
                    prvi_moze_da_pokusa = false;
                    drugi_moze_da_pokusa = false;
                }
                if (prvi_igrac)
                    promeni_igraca_na_2($"Pogodili ste polje {btn.klasa}{btn.broj}!\n" +
                        $"Vreme je da drugi igrac igra!");
                else
                    promeni_igraca_na_1($"Pogodili ste polje {btn.klasa}{btn.broj}!\n" +
                        $"Vreme je da prvi igrac igra!");
                if (prvi_igrac)
                    prvi_counter++;
                else
                    drugi_counter++;
                prvi_igrac = !prvi_igrac;
            }
        }

        private void PoljeKlik(object sender, EventArgs e)
        {
            if ((prvi_igrac && prvi_counter != 2) || (!prvi_igrac && drugi_counter != 2))
            {
                if (prvi_igrac)
                {
                    vreme1 += 10;
                    prvi_moze_da_pokusa = true;
                }
                else if (!prvi_igrac)
                {
                    vreme2 += 10;
                    drugi_moze_da_pokusa = true;
                }

                CButton cbtn = (CButton)sender;


                if (prvi_igrac)
                    if (prvi_counter == 2)
                    {
                        promeni_igraca_na_1("Vreme je da prvi igrac igra!");
                        return;
                    }

                if (!prvi_igrac)
                    if (drugi_counter == 2)
                    {
                        promeni_igraca_na_2("Vreme je da drugi igrac igra!");
                        return;
                    }


                cbtn.Text = cbtn.resenje;
                cbtn.otkljucan = true;

                if (prvi_igrac)
                {
                    cbtn.BackColor = Color.LightBlue;
                    prvi_counter++;
                }
                if (!prvi_igrac)
                {
                    cbtn.BackColor = Color.Red;
                    drugi_counter++;
                }

                if (cbtn.klasa == "a")
                {
                    a_counter++;
                    if (a_polja.Any(ap => ap.otkljucan))
                        a.Enabled = true;
                }
                if (cbtn.klasa == "b")
                {
                    b_counter++;

                    if (b_polja.Any(ap => ap.otkljucan))
                        b.Enabled = true;
                }
                if (cbtn.klasa == "c")
                {
                    c_counter++;

                    if (c_polja.Any(ap => ap.otkljucan))
                        c.Enabled = true;
                }
                if (cbtn.klasa == "d")
                {
                    d_counter++;

                    if (d_polja.Any(ap => ap.otkljucan))
                        d.Enabled = true;
                }


                if (a_counter == 4 || b_counter == 4 || c_counter == 4 || d_counter == 4)
                    textBox1.Enabled = true;
                else
                    textBox1.Enabled = false;
                cbtn.Enabled = false;

            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            tekst = textBox1.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Enabled = prvi_moze_da_pokusa;

            if (vreme1 <= 0)
            {
                promeni_igraca_na_2("Isteklo vreme drugi igrac je na redu!");
            }
            else
            {
                vreme1 -= 0.1;
                label1.Text = vreme1.ToString("0.0");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            textBox1.Enabled = drugi_moze_da_pokusa;

            if (vreme2 <= 0)
            {
                promeni_igraca_na_1("Isteklo vreme prvi igrac je na redu!");
            }
            else
            {
                vreme2 -= 0.1;
                label2.Text = vreme2.ToString("0.0");
            }
        }

        private void promeni_igraca_na_2(string poruka)
        {
            prvi_counter = 0;
            prvi_moze_da_pokusa = false;
            vreme1 = 10.0;
            label1.Text = vreme1.ToString();
            timer1.Stop();
            MessageBox.Show(poruka);
            prvi_igrac = false;
            timer2.Start();
        }
        private void promeni_igraca_na_1(String poruka)
        {
            drugi_counter = 0;
            drugi_moze_da_pokusa = false;
            vreme2 = 10.0;
            label2.Text = vreme2.ToString();
            timer2.Stop();
            MessageBox.Show(poruka);
            prvi_igrac = true;
            timer1.Start();
        }
    }
}