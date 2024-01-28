using System.Security.Cryptography.X509Certificates;

namespace Forma2
{
    public partial class Form1 : Form
    {
        double a;

        public Form1()
        {
            InitializeComponent();
        }

        private void izracunajClick(object sender, EventArgs e)
        {
            Izracunaj();
            Nacrtaj();
        }

        private void stranice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                a = int.Parse(stranica.Text.Replace("Stranica kvadrata: ", "").Trim());
            }
            catch (Exception ex) { }
        }

        private void Izracunaj()
        {
            double ru = a / 2;
            double ro = a * Math.Sqrt(2) / 2;
            double Pu = ru * ru * Math.PI;
            double Po = ro * ro * Math.PI;
            double Ou = 2 * ru * Math.PI;
            double Oo = 2 * ro * Math.PI;

            tb_ru.Text = "Poluprecnik upisane: " + (ru).ToString("0.00");
            tb_ro.Text = "Poluprecnik opisane" + (ro).ToString("0.00");
            tb_Pu.Text = "Povrsina upisane: " + (Pu / Math.PI).ToString("0.00") + "π";
            tb_Po.Text = "Povrsina opisane: " + (Po / Math.PI).ToString("0.00") + "π";
            tb_Ou.Text = "Obim upisane: " + (Ou / Math.PI).ToString("0.00") + "π";
            tb_Oo.Text = "Obim opisane: " + (Oo / Math.PI).ToString("0.00") + "π";
        }

        private void Nacrtaj()
        {

            Pen olovka = new Pen(Color.Black);
            //SolidBrush cetka = new SolidBrush(Color.Black);
            Graphics g = CreateGraphics();

            int scale = 50;
            int fix = -2;
            int ru = int.Parse((a / 2 * scale).ToString());
            int ro = int.Parse(Math.Round((a * Math.Sqrt(2) / 2) * scale).ToString());
            Point centar = new Point(300, 100);

            Size kvadratSize = new Size((int)(a * scale), (int)(a * scale));
            Size ruKrugSize = new Size(2 * ru, 2 * ru);
            Size roKrugSize = new Size(2 * ro, 2 * ro);

            Rectangle kvadrat = new Rectangle(centar, kvadratSize);
            Rectangle ruKrug = new Rectangle(centar, ruKrugSize);
            centar.Offset(-ro / 4 + fix, -ro / 4 + fix);
            Rectangle roKrug = new Rectangle(centar, roKrugSize);

            g.DrawRectangle(olovka, kvadrat);
            g.DrawEllipse(olovka, ruKrug);
            g.DrawEllipse(olovka, roKrug);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void tajmerKucanje(object sender, EventArgs e)
        {

        }
    }
}