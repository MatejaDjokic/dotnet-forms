using System.Configuration;
using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace parking
{
    public partial class Form1 : Form
    {
        private String car = "🚗";
        private int button_size = 100;
        private Button[,] cars = new Button[3, 2];
        private Button[,] spots = new Button[3, 3];
        private Point selected = new Point();
        private Timer[,] timers = new Timer[3, 3];
        private Label[,] labels = new Label[3, 3];
        private int[,] paid_time = new int[3, 3]; 
        private int[,] times = new int[3, 3];
        private Label cost_label = new Label();
        private int cost = 0;
        private Color[] colors = new Color[6]
        {
            Color.Red, Color.Yellow, Color.Green,
            Color.Blue,Color.HotPink, Color.Aqua,
        };

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            init();
        }
        private void init()
        {

            this.Text = "Parking";
            int x1 = init_cars();
            init_labels(x1);
            int x2 = init_parking_spots(x1);
            this.Width = (int)(1.214 * x2) + 10;
            CenterToScreen();
            cost_label.Location = new Point(0, Height - 20);
            cost_label.Text = "Racun: 0";
            this.Controls.Add(cost_label);
        }
        private int init_cars()
        {
            int x = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(button_size, button_size);
                    x = 10 + j * button_size;
                    button.Location = new Point(x, 10 + i * button_size);
                    button.ForeColor = colors[i * 3 + j];
                    button.Text = car;
                    button.Font = new Font("Arial", 25);
                    button.Tag = new Point(j, i);
                    button.BackColor = Color.White;
                    cars[j, i] = button;
                    button.Click += car_click!;
                    this.Controls.Add(button);
                }
            }
            return x;
        }
        private void init_labels(int x)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Label label = new Label();
                    label.Size = new Size(30, 15);
                    label.Location = new Point(
                        x + 10 + (j + 1) * button_size + button_size / 2 - 10,
                        10 + i * button_size + (int)(3 / 2 * button_size) - 30
                    );
                    label.Font = new Font("Arial", 10);
                    label.Tag = new Point(j, i);
                    labels[j, i] = label;
                    label.Text = "";
                    label.Visible = false;
                    this.Controls.Add(label);
                }
            }
        }
        private int init_parking_spots(int x)
        {
            int lx = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(button_size, button_size);
                    lx = x + 10 + (j + 1) * button_size;
                    button.Location = new Point(lx, 10 + i * button_size);
                    button.Font = new Font("Arial", 25);
                    spots[j, i] = button;
                    button.Tag = new Point(j, i);
                    button.BackColor = Color.White;
                    button.Click += spot_click!;
                    this.Controls.Add(button);

                    Timer timer = new Timer();
                    timer.Stop();
                    timer.Interval = 1000;
                    timer.Tick += timer_tick!;
                    timer.Tag = new Point(j, i);
                    timers[j, i] = timer;
                }
            }
            return lx;
        }
        private void car_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            foreach (Button c in cars) c.BackColor = Color.White;
            button.BackColor = Color.Beige;
            Point pos = (Point)button.Tag!;
            //MessageBox.Show($"x: {pos.X} y: {pos.Y}");
            selected = pos;
        }
        private void spot_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Point pos = (Point)button.Tag!;


            SuspendLayout();
            HowMuch howMuch = new HowMuch();
            howMuch.Show();
            paid_time[pos.X, pos.Y] = howMuch.hours;
            this.Show();

            cars[selected.X, selected.Y].Tag = pos;
            button.Tag = selected;
            spots[pos.X, pos.Y].Text = cars[selected.X, selected.Y].Text;
            spots[pos.X, pos.Y].ForeColor = cars[selected.X, selected.Y].ForeColor;
            cars[selected.X, selected.Y].Text = "";
            cars[selected.X, selected.Y].ForeColor = Color.Black;
            timers[pos.X, pos.Y].Start();
            times[pos.X, pos.Y] = 1;
            labels[pos.X, pos.Y].Text = times[pos.X, pos.Y].ToString();
            labels[pos.X, pos.Y].Visible = true;
        }
        private void timer_tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            Point pos = (Point)timer.Tag!;
            times[pos.X, pos.Y]++;
            labels[pos.X, pos.Y].Text = times[pos.X, pos.Y].ToString();

            if (times[pos.X, pos.Y] > 10)
            {
                MessageBox.Show("Dobili ste kaznu!");
                add_cost(100);
                spots[pos.X, pos.Y].Text = "";
                timers[pos.X, pos.Y].Stop();
                labels[pos.X, pos.Y].Visible = false;
            }
        }

        private void add_cost(int value)
        {
            cost += value;
            cost_label.Text = cost.ToString();
        }
    }
}
