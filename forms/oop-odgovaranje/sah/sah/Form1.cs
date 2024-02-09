using System.Net.NetworkInformation;

namespace sah
{
    public partial class Form1 : Form
    {
        private int W = 50;
        private String king = "♔";
        private String queen = "♕";
        private String rook = "♖";
        private String bishop = "♗";
        private String knight = "♘";
        private String pawn = "♙";
        //private String blackKing = "♚";
        //private String blackQueen = "♛";
        //private String blackRook = "♜";
        //private String blackBishop = "♝";
        //private String blackKnight = "♞";
        //private String blackPawn = "♟";
        private ComboBox box = new ComboBox();
        private String selected = "";
        private Cel[,] cels = new Cel[8, 8];

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            init_window();
            init_board();
        }
        private void init_window()
        {
            this.Text = "Sah";
            this.Height = (int)((8 * 1.1) * 50);
            box.Location = new Point((int)((8 * 1.1) * 50) - 40, Height / 2 - box.Height - W / 2);
            box.Items.AddRange(new String[] {
            king,queen,rook,bishop,knight,pawn,
            //blackKing,blackQueen,blackRook,blackBishop,blackKnight,blackPawn,
            });
            box.Font = new Font("Arial", 25);
            box.SelectedIndexChanged += box_changed!;
            this.Controls.Add(box);
            this.Width = (int)((8 * 1.1) * 50) - 25 + box.Width;
            CenterToScreen();
        }
        private void init_board()
        {
            int index = 0;
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Cel cel = new Cel(row, col);
                    cel.Size = new Size(W, W);
                    cel.Location = new Point(row * W, col * W);
                    //cel.Text = (row + col * 8).ToString();
                    cel.BackColor = index % 2 == 0 ? Color.Green : Color.Beige;
                    cel.Click += cel_click!;
                    cel.Font = new Font("Arial", 25);
                    this.Controls.Add(cel);
                    cels[row, col] = cel;
                    index++;
                }
                index++;
            }
        }
        private bool valid(int x, int y)
        {
            return x >= 0 && y >= 0 && x < 8 && y < 8;
        }
        private void cel_click(object sender, EventArgs e)
        {
            Cel cel = (Cel)sender;
            clear();
            switch (selected)
            {
                case "♔": do_king(cel.x, cel.y); break;
                case "♕": do_queen(cel.x, cel.y); break;
                case "♖": do_rook(cel.x, cel.y); break;
                case "♗": do_bishop(cel.x, cel.y); break;
                case "♘": do_knight(cel.x, cel.y); break;
                case "♙": do_pawn(cel.x, cel.y); break;
            }
        }
        private void clear()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    cels[i, j].Text = "";
        }
        private void box_changed(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            selected = box.Text;
        }
        private void do_king(int x, int y)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int nx = x + i;
                    int ny = y + j;
                    set(nx, ny);
                }
            }
            cels[x, y].Text = king;
        }
        private void do_queen(int x, int y)
        {
            for (int i = 0; i < 8; i++)
            {
                set(x + i, y);
                set(x - i, y);
                set(x, y + i);
                set(x, y - i);
                set(x + i, y + i);
                set(x - i, y - i);
                set(x - i, y + i);
                set(x + i, y - i);
            }
            cels[x, y].Text = queen;
        }
        private void do_rook(int x, int y)
        {
            for (int i = 0; i < 8; i++)
            {
                set(x + i, y);
                set(x - i, y);
                set(x, y + i);
                set(x, y - i);
            }
            cels[x, y].Text = rook;

        }
        private void do_bishop(int x, int y)
        {
            for (int i = 0; i < 8; i++)
            {

                set(x + i, y + i);
                set(x - i, y - i);
                set(x - i, y + i);
                set(x + i, y - i);
            }
            cels[x, y].Text = bishop;
        }
        private void do_knight(int x, int y)
        {
            set(x - 2, y - 1);
            set(x - 1, y - 2);
            set(x + 1, y + 2);
            set(x + 2, y + 1);
            set(x + 2, y - 1);
            set(x + 1, y - 2);
            set(x - 2, y + 1);
            set(x - 1, y + 2);
            cels[x, y].Text = knight;
        }
        private void do_pawn(int x, int y)
        {
            set(x, y - 1);
            cels[x, y].Text = pawn;
        }
        private void set(int x, int y)
        {
            if (valid(x, y))
                cels[x, y].toggle();
        }
    }
}
