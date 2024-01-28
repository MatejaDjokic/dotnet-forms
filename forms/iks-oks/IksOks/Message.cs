namespace IksOks
{
    public partial class Message : Form
    {
        public Message(String text, double final_time)
        {
            InitializeComponent();
            this.label1.Text = text;
            this.Text = $"IksOks: {final_time.ToString("0.0")} s";
        }

        private void exit_button_click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
