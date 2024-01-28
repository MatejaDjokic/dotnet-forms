using minolovac.Properties;

namespace minolovac
{
    public partial class Minolovac : Form
    {
        private int board_size;
        private int mine_num;
        private Cell[,] grid;

        private bool mark_mode;
        private List<int[]> marked_cells;
        private List<int[]> mine_cells;


        public Minolovac(int mine_num)
        {
            InitializeComponent();
            this.board_size = 10;
            this.mine_num = mine_num;
            this.grid = new Cell[board_size, board_size];
            this.mark_mode = false;
            this.marked_cells = new List<int[]>();
            this.mine_cells = new List<int[]>();
        }

        private void form_load(object sender, EventArgs e)
        {
            mark_mode_btn.BackColor = Color.Red;
            mark_mode_btn.Text = "Ukljuci Mod Oznacavanja";
            restart_button.BackColor = Color.LightBlue;

            int btn_size = (this.Width - 20) / this.board_size - 1;

            int counter = 1;
            for (int row = 0; row < this.board_size; row++)
            {
                for (int col = 0; col < this.board_size; col++)
                {
                    bool is_dark = counter % 2 == 0;
                    Cell cell = new Cell(row, col, false, is_dark);

                    cell.Size = new Size(btn_size, btn_size);
                    cell.Location = new Point(10 + row * btn_size, 10 + col * btn_size);

                    cell.BackgroundImageLayout = ImageLayout.Zoom;
                    cell.BackgroundImage = is_dark ? Resources.unrevealed_dark : Resources.unrevealed_light;
                    cell.image = is_dark ? Resources.revealed_dark : Resources.revealed_light;

                    cell.Click += cell_click!;

                    this.grid[row, col] = cell;
                    this.Controls.Add(cell);

                    if (col == this.board_size - 1)
                        counter += 1;
                    counter += 1;
                }
            }

            List<int[]> options = new List<int[]>();
            for (int row = 0; row < this.board_size; row++)
            {
                for (int col = 0; col < this.board_size; col++)
                {
                    options.Add(new int[] { row, col });
                }
            }

            for (int n = 0; n < this.mine_num; n++)
            {
                Random rnd = new Random();
                int index = (int)Math.Floor(rnd.NextDouble() * options.Count);
                int[] choice = options[index];

                int i = choice[0];
                int j = choice[1];

                mine_cells.Add(new int[] { i, j });

                options.RemoveAt(index);
                grid[i, j].is_mine = true;
                grid[i, j].image = Resources.mine;
            }


            for (int row = 0; row < this.board_size; row++)
            {
                for (int col = 0; col < this.board_size; col++)
                {
                    count_neighbours(grid[row, col]);
                    //grid[row, col].reveal(grid);
                }
            }
        }
        private void count_neighbours(Cell cell)
        {
            if (cell.is_mine) cell.count_neighbours = -1;
            else
            {
                int count = 0;

                for (int xoff = -1; xoff <= 1; xoff++)
                {
                    for (int yoff = -1; yoff <= 1; yoff++)
                    {
                        int i = cell.i + xoff;
                        int j = cell.j + yoff;
                        if (i > -1 && j > -1 && i < this.board_size && j < this.board_size)
                            if (grid[i, j].is_mine)
                                count++;
                    }
                }
                cell.count_neighbours = count;
            }
        }

        private void cell_click(object sender, EventArgs e)
        {
            Cell cell = (Cell)sender;

            if (!cell.is_revealed)
            {
                if (this.mark_mode)
                    mark_mode_on_click(cell, e);
                else
                    mark_mode_off_click(cell, e);
            }

        }

        private void try_win()
        {
            bool won = contains_all(marked_cells, mine_cells);
            if (won)
                game_over("Pobedio si!");
        }

        private bool contains_all(List<int[]> arr1, List<int[]> arr2)
        {
            if (arr1.Count != arr2.Count) return false;
            arr1.Sort(cmp_arrarys);
            arr2.Sort(cmp_arrarys);
            for (int i = 0; i < arr1.Count; i++)
            {
                int[] a1 = arr1[i];
                int[] a2 = arr2[i];
                if (!(a1[0] == a2[0] && a1[1] == a2[1])) return false;
            }
            return true;
        }
        private int cmp_arrarys(int[] a, int[] b)
        {
            int result = a[0].CompareTo(b[0]);
            if (result == 0)
            {
                result = a[1].CompareTo(b[1]);
            }
            return result;
        }
        private void try_lose(Cell cell)
        {
            if (cell.is_mine)
                game_over("Izgubio si!");
        }

        private void game_over(String msg)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    grid[i, j].marked = false;
                    grid[i, j].is_revealed = true;
                }
            }
            MessageBox.Show(msg);
            Application.Exit();
        }

        private void mark_mode_on_click(Cell cell, EventArgs e)
        {
            marked_cells = cell.mark(marked_cells);
            try_win();
        }
        private void mark_mode_off_click(Cell cell, EventArgs e)
        {
            cell.reveal(grid);
            try_lose(cell);
        }
        private void restart_button_click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void mark_mode_btn_click(object sender, EventArgs e)
        {
            if (this.mark_mode)
            {
                this.mark_mode = false;
                mark_mode_btn.BackColor = Color.Red;
                mark_mode_btn.Text = "Ukljuci Mod Oznacavanja";
            }
            else
            {
                this.mark_mode = true;
                mark_mode_btn.BackColor = Color.Green;
                mark_mode_btn.Text = "Iskljuci Mod Oznacavanja";
            }
        }
    }
}
