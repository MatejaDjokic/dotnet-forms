namespace PogadjanjeBroja
{
    public partial class form1 : Form
    {
        private const int MIN_NUMBER = 0;
        private const int MAX_NUMBER = 99;

        private int number;
        private int num_of_tries;
        private List<CustomButton> buttons;
        public form1()
        {
            InitializeComponent();
            num_of_tries = 0;
            number = new Random().Next(MIN_NUMBER, MAX_NUMBER);
            buttons = new List<CustomButton>();
        }

        private void form1_Load(object sender, EventArgs e)
        {
            label2.Text = number.ToString();
            int n = 1;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 1; i <= MAX_NUMBER / 4; i++)
                {
                    int size = Width / (MAX_NUMBER / 4);
                    CustomButton btn = new CustomButton(n);
                    btn.Size = new Size(size, size);
                    btn.Location = new Point((i - 1) * size, Height / 2 + j * size - 3 * size);
                    btn.Click += button_click!;
                    buttons.Add(btn);
                    this.Controls.Add(btn);
                    n++;
                }
            }
        }

        private void button_click(object sender, EventArgs e)
        {
            CustomButton btn = (CustomButton)sender;
            if (!btn.clicked)
            {
                btn.Text = btn.value.ToString();
                btn.clicked = true;
                btn.Enabled = false;
                num_of_tries++;
                label1.Text = "Broj pokusaja: " + num_of_tries.ToString();

                String s = num_of_tries == 1 ? "try" : "tries";
                if (btn.value == number)
                    new Message($"Well done, you guessed the number in {num_of_tries} {s}!").Show();

            }
        }
    }
}