using System.Security.AccessControl;

namespace SudokulicaDzons
{
    public partial class Form1 : Form
    {
        int[,] sudokuBoard = new int[9, 9];
        int[,] a = new int[,]
        {
            {5, 3, 0, 0, 7, 0, 0, 0, 0},
            {6, 0, 0, 1, 9, 5, 0, 0, 0},
            {0, 9, 8, 0, 0, 0, 0, 6, 0},
            {8, 0, 0, 0, 6, 0, 0, 0, 3},
            {4, 0, 0, 8, 0, 3, 0, 0, 1},
            {7, 0, 0, 0, 2, 0, 0, 0, 6},
            {0, 6, 0, 0, 0, 0, 2, 8, 0},
            {0, 0, 0, 4, 1, 9, 0, 0, 5},
            {0, 0, 0, 0, 8, 0, 0, 7, 9}
        };
        int[,] b = new int[,]
{
    {0, 4, 0, 1, 0, 2, 6, 5, 7},
    {2, 7, 3, 6, 8, 5, 4, 1, 9},
    {0, 6, 0, 9, 0, 4, 2, 8, 3},
    {0, 9, 0, 3, 2, 8, 7, 0, 5},
    {0, 5, 7, 4, 0, 9, 0, 6, 2},
    {4, 2, 8, 5, 6, 7, 3, 9, 1},
    {0, 3, 2, 0, 0, 1, 0, 7, 4},
    {7, 1, 4, 2, 0, 6, 9, 3, 8},
    {0, 8, 0, 7, 4, 0, 1, 2, 6}
};


        int w = 50;
        int xoff = 0;
        int yoff = 0;

        Label l = new Label();
        Btn[] slct_btns = new Btn[10];
        Btn[,] grid = new Btn[9, 9];
        int selected = 0;
        int errors = -50;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            sudokuBoard = b;
            sudokuBoard = flip_around_diagonal(sudokuBoard);
            init_window();
            init_grid();
            init_sclt_btns();
        }
        void init_window()
        {
            this.Width = w * 10 + w / 2 - 8;
            this.Height = w * 13 - 10;
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(this.Width, this.Height);
            this.KeyDown += key_down!;
            this.KeyPreview = true;
            CenterToParent();
        }
        void init_grid()
        {
            for (int y = 0; y < 9; y++)
            {
                xoff = 0;
                for (int x = 0; x < 9; x++)
                {
                    int sg = sudokuBoard[x, y];
                    Btn btn = new Btn(x, y, sg == 0);
                    btn.set(sg);
                    btn.Location = new Point(x * w + xoff, y * w + yoff);
                    if ((x + 1) % 3 == 0 && x != 8)
                        xoff += w / 2;
                    btn.Size = new Size(w, w);
                    btn.BackColor = Color.Gray;

                    btn.Click += btn_click!;
                    grid[x, y] = btn;
                    Controls.Add(btn);
                }
                if ((y + 1) % 3 == 0 && y != 8)
                    yoff += w / 2;
            }
        }
        void init_sclt_btns()
        {
            for (int x = 0; x < 10; x++)
            {
                Btn btn = new Btn(0, 0, true);
                btn.Location = new Point(x * w, w * 11);
                btn.Size = new Size(w, w);

                if (x == 0)
                {
                    btn.Name = "btnx";
                    btn.Text = "X";
                    btn.BackColor = Color.Yellow;
                }
                else
                {
                    btn.Name = $"btn{x}";
                    btn.Text = $"{x}";
                    btn.BackColor = Color.Gray;
                }


                btn.Click += slct_btn_click!;
                slct_btns[x] = btn;
                Controls.Add(btn);
            }
            l.Text = $"Broj gresaka: {errors}/5";
            l.Location = new Point((Width - l.Width) / 2, w * 10 + w / 3);
            Controls.Add(l);
        }
        void key_down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9)
            {
                int num = int.Parse(e.KeyCode.ToString().Replace("D", ""));
                select_button(num + 1);
            }
            else if (e.KeyCode == Keys.X || e.KeyCode == Keys.D0)
                select_button(1);
        }
        void select_button(int num)
        {
            foreach (Btn btn in slct_btns)
                btn.BackColor = Color.Gray;
            slct_btns[num - 1].BackColor = Color.Yellow;
            selected = num - 1;
        }
        void btn_click(object sender, EventArgs e)
        {
            Btn btn = (Btn)sender;
            if (btn.Name == "btnx")
                btn.set(0);

            all_clr(Color.Gray);

            bool cv = row_valid(btn.x);
            bool rv = col_valid(btn.y);
            bool qv = quadrant_valid(btn.q);
            col_clr(btn.x, cv ? Color.Gray : Color.Red);
            row_clr(btn.y, rv ? Color.Gray : Color.Red);
            quadrant_clr(btn.q, qv ? Color.Gray : Color.Red);

            btn.set(selected);

            if ((!cv || !rv || !qv) && selected != 0)
                errors++;
            l.Text = $"Broj gresaka: {errors}/5";
            if (errors == 5)
            {
                MessageBox.Show("Izgubili ste!");
                Application.Exit();
            }

            if (selected == 0)
                all_clr(Color.Gray);
        }
        void get_qadrant_center(int q, out int cx, out int cy)
        {
            switch (q)
            {
                case 0: cx = 1; cy = 1; break;
                case 1: cx = 4; cy = 1; break;
                case 2: cx = 7; cy = 1; break;
                case 3: cx = 1; cy = 4; break;
                case 4: cx = 4; cy = 4; break;
                case 5: cx = 7; cy = 4; break;
                case 6: cx = 1; cy = 7; break;
                case 7: cx = 4; cy = 7; break;
                case 8: cx = 7; cy = 7; break;
                default: cx = -1; cy = -1; break;
            }
        }
        void slct_btn_click(object sender, EventArgs e)
        {
            Btn btn = (Btn)sender;
            String btn_name = btn.Name.Replace("btn", "");
            foreach (Btn item in slct_btns.ToList())
                item.BackColor = Color.Gray;
            btn.BackColor = Color.Yellow;
            if (btn_name == "x")
            {
                selected = 0;
            }
            else
                selected = int.Parse(btn_name);
        }
        void all_clr(Color color)
        {
            foreach (Btn btn in grid)
                btn.BackColor = color;
        }
        void col_clr(int row_index, Color color)
        {
            if (row_index < 0 || row_index >= 9)
                return;
            for (int col = 0; col < 9; col++)
                grid[row_index, col].BackColor = color;
        }
        void row_clr(int col_index, Color color)
        {
            if (col_index < 0 || col_index >= 9)
                return;

            for (int row = 0; row < 9; row++)
                grid[row, col_index].BackColor = color;
        }
        void quadrant_clr(int quadrant_index, Color color)
        {
            if (quadrant_index < 0 || quadrant_index >= 9)
                return;

            int cx, cy;
            get_qadrant_center(quadrant_index, out cx, out cy);

            for (int xoff = -1; xoff <= 1; xoff++)
                for (int yoff = -1; yoff <= 1; yoff++)
                    grid[cx + xoff, cy + yoff].BackColor = color;
        }
        bool row_valid(int x)
        {
            for (int row = 0; row < 9; row++)
            {
                if (grid[row, x].val == selected)
                {
                    return false; // Selected number already exists in the column
                }
            }
            return true;
        }
        bool col_valid(int y)
        {
            //String o = String.Empty;
            //for (int col = 0; col < 9; col++)
            //{
            //    o += grid[y, col].val + ",";
            //}
            //MessageBox.Show(o);
            for (int col = 0; col < 9; col++)
            {
                if (grid[y, col].val == selected)
                {
                    return false; // Selected number already exists in the row
                }
            }
            return true;
        }
        bool quadrant_valid(int q)
        {
            int cx, cy;
            get_qadrant_center(q, out cx, out cy);

            for (int xoff = -1; xoff <= 1; xoff++)
                for (int yoff = -1; yoff <= 1; yoff++)
                {
                    int x = cx + xoff;
                    int y = cy + yoff;

                    if (grid[x, y].val == selected)
                        return false; // Selected number already exists in the quadrant
                }
            return true;
        }
        int[,] flip_around_diagonal(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            int[,] flippedArray = new int[cols, rows];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    flippedArray[j, i] = array[i, j];
                }
            }
            return flippedArray;
        }
    }
}
