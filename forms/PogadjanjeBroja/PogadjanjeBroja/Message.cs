namespace PogadjanjeBroja
{
    public partial class Message : Form
    {
        public Message(String text)
        {
            InitializeComponent();
            this.Text = "Pogadjanje Broja";
            this.label1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
