using proizvod;

namespace Word4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Proizvod p;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Text = "Test aplikacija";
                p = new Proizvod("Kifla", "Pekara Ljupce");
                tbProizvod.Text = p.Prikaz();
                tbProizvod.ReadOnly = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cenaLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnPromeni_Click(object sender, EventArgs e)
        {
            try
            {
                double novaCena = Convert.ToDouble(tbNovaCena.Text);
                p.PromeniCenu(novaCena);
                tbProizvod.Text = p.Prikaz();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnKojiJeSkuplji_Click(object sender, EventArgs e)
        {
            try
            {
                int ce = int.Parse(tbNovaCena.Text);

                if (ce < 0)
                    throw new Exception("Cena je manja od 0!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                string naziv = tbNaziv.Text;
                string proizvodjac = tbProizvodjac.Text;
                double cena = Convert.ToDouble(tbCena.Text);
                Proizvod p2 = new Proizvod(naziv, proizvodjac, cena);

                if (p.SkupljiOd(p2))
                    tbPoruka.Text = "Skuplji je prvi!";
                else if (p2.SkupljiOd(p))
                    tbPoruka.Text = "Skuplji je drugi!";
                else tbPoruka.Text = "Kostaju isto";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}