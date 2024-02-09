using RimskeMice.Properties;
using System.Diagnostics.Eventing.Reader;
using System.IO.Pipes;

namespace RimskeMice
{
    public partial class Form1 : Form
    {
        private Button[] buttons;
        private Point[] positions;
        private int W = 40;
        private int num_of_black = 0;
        private int num_of_white = 0;
        public Form1()
        {
            InitializeComponent();
            buttons = new Button[24];
            positions = GetPositions();
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            InitWindow();
            InitBoard();
        }
        private Point[] GetPositions()
        {
            int x1 = 0;
            int x2 = Width / 2 - 2 * W / 3 - 4 * W + W / 3;
            int x3 = Width / 2 - 2 * W / 3 - 2 * W;
            int x4 = Width / 2 - 2 * W / 3;
            int x5 = Width / 2 - 2 * W / 3 + 2 * W;
            int x6 = Width / 2 - 2 * W / 3 + 4 * W - W / 3;
            int x7 = Width - W - W / 2;

            int y1 = 0;
            int y2 = 2 * W - W / 2;
            int y3 = 4 * W - W / 2;
            int y4 = 6 * W - W + W / 3;
            int y5 = 7 * W;
            int y6 = 9 * W;
            int y7 = 11 * W - W / 2;

            return new Point[24] {
                new Point(x1, y1),
                new Point(x4, y1),
                new Point(x7, y1),

                new Point(x2, y2),
                new Point(x4, y2),
                new Point(x6, y2),

                new Point(x3, y3),
                new Point(x4, y3),
                new Point(x5, y3),

                new Point(x1, y4),
                new Point(x2, y4),
                new Point(x3, y4),

                new Point(x5, y4),
                new Point(x6, y4),
                new Point(x7, y4),

                new Point(x3, y5),
                new Point(x4, y5),
                new Point(x5, y5),

                new Point(x2, y6),
                new Point(x4, y6),
                new Point(x6, y6),

                new Point(x1, y7),
                new Point(x4, y7),
                new Point(x7, y7),
            };
        }
        private Point GetPosition(int index)
        {
            switch (index)
            {
                case 0: return new Point(0, 0);
                case 1: return new Point(3, 0);
                case 2: return new Point(6, 0);
                case 3: return new Point(1, 1);
                case 4: return new Point(3, 1);
                case 5: return new Point(5, 1);
                case 6: return new Point(2, 2);
                case 7: return new Point(3, 2);
                case 8: return new Point(4, 2);
                case 9: return new Point(0, 3);
                case 10: return new Point(1, 3);
                case 11: return new Point(2, 3);
                case 12: return new Point(4, 3);
                case 13: return new Point(5, 3);
                case 14: return new Point(6, 3);
                case 15: return new Point(2, 4);
                case 16: return new Point(3, 4);
                case 17: return new Point(4, 4);
                case 18: return new Point(1, 5);
                case 19: return new Point(3, 5);
                case 20: return new Point(5, 5);
                case 21: return new Point(0, 6);
                case 22: return new Point(3, 6);
                case 23: return new Point(6, 6);
            }
            return new Point(-1, -1);
        }
        private void InitWindow()
        {
            this.Text = "Mica";
            this.Height = 500;
            this.Width = 500;
            CenterToScreen();
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = Resources.pozadina;
        }
        private void InitBoard()
        {
            for (int i = 0; i < positions.Length; i++)
            {
                Point pos = positions[i];

                Button btn = new Button();
                btn.Tag = GetPosition(i);
                btn.Size = new Size(W, W);
                btn.Location = pos;
                //btn.Text = $"{pos.X}:{pos.Y}";
                btn.Click += Click!;
                buttons[i] = btn;
                this.Controls.Add(btn);
            }
        }
        private void Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Point position = (Point)button.Tag;

            MessageBox.Show($"Kliknuli ste na polje u vrsti {position.X}, koloni {position.Y}");
        }
        private void SetFigure(int x, int y, Color color)
        {

        }
    }
}
