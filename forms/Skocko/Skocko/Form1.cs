using Skocko;
using System.Drawing.Drawing2D;
namespace Skocko
{
    public partial class Form1 : Form
    {
        private char[] symbols = new char[6] { '♥', '♠', '♣', '♦', '★', '☻' };
        private Color[] colors = new Color[6] {
            Color.Red, Color.Black, Color.Black,
            Color.Red, Color.Yellow, Color.Yellow,
        };
        private const int button_size = 50;
        private int display_i = 0;
        private int display_j = 0;
        private int playing_i = 0;
        private int playing_j = 0;
        private int errors = 0;
        private Label[,] playing;
        private Label[,] display;
        private String correct;
        private String combination;
        public Form1()
        {
            InitializeComponent();
            playing = new Label[5, 4];
            display = new Label[5, 4];
            correct = Skocko.gen(4, 6);
            combination = String.Empty;
            this.Text = $"Skocko: {correct}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int x = init_display_field(init_playing_field());
            this.Width = x + 16;
            init_buttons();
            CenterToScreen();
        }
        private int init_playing_field()
        {
            int last = 0; ;
            for (int col = 0; col < 5; col++)
                for (int row = 0; row < 4; row++)
                {
                    Label label = new Label();
                    label.Size = new Size(button_size, button_size);
                    Point point = new Point(row * button_size + row * 10, col * button_size + col * 5);
                    last = point.X;
                    label.Location = point;
                    label.BorderStyle = BorderStyle.FixedSingle;
                    label.Font = new Font("Arial", 25);
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    this.playing[col, row] = label;
                    this.Controls.Add(label);
                }
            return last;
        }

        private int init_display_field(int last)
        {
            int nly = 0;
            for (int col = 0; col < 5; col++)
                for (int row = 1; row <= 4; row++)
                {
                    Label label = new Label();
                    label.Size = new Size(button_size, button_size);
                    Point point = new Point(25 + last + row * button_size + row * 10, col * button_size + col * 5);
                    nly = point.X;
                    label.Location = point;
                    label.BorderStyle = BorderStyle.FixedSingle;
                    label.Font = new Font("Arial", 25);
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    this.display[col, row - 1] = label;
                    this.Controls.Add(label);
                }
            return nly + button_size;
        }
        private void init_buttons()
        {
            for (int i = 0; i < symbols.Length; i++)
            {
                Button btn = new Button();
                btn.Size = new Size(button_size, button_size);
                btn.Location = new Point(Width / 2 + i * button_size - symbols.Length / 2 * button_size - 10, this.Height - (int)(button_size * 1.8));
                btn.Text = symbols[i].ToString();
                btn.ForeColor = colors[i];
                btn.Font = new Font("Arial", 25);
                btn.Click += btn_click!;
                this.Controls.Add(btn);
            }
        }
        private void btn_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            playing[playing_j, playing_i].Text = btn.Text;
            combination += btn.Text;
            playing[playing_j, playing_i].ForeColor = colors[symbols.ToList().IndexOf(btn.Text.ToCharArray()[0])];
            //MessageBox.Show(combination);
            if ((playing_i + 1) % 4 == 0)
            {
                playing_i = 0;
                playing_j++;
                errors++;
                int[] guess = Skocko.guess(correct, Skocko.to_numbers(combination, symbols));

                for (int i = 0; i < guess[0]; i++)
                {
                    display[display_i, display_j + i].BackColor = Color.Red;
                }
                display_j += guess[0];
                for (int i = 0; i < guess[1]; i++)
                {
                    display[display_i, display_j + i].BackColor = Color.Yellow;
                }
                combination = String.Empty;
                display_j = 0;
                display_i++;
                if (guess[0] == 4)
                {
                    MessageBox.Show("POBEDIO SI!");
                    Application.Exit();
                }
                if (errors == 5)
                {
                    MessageBox.Show("IZGUNIO SI!");
                    Application.Exit();
                }
            }
            else
                playing_i++;
        }
    }
}
