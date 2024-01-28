using minolovac.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minolovac
{
    public partial class Cell : Button
    {
        private bool _is_mine;
        private bool _revealed;
        private bool _marked;
        private bool _is_dark;

        private int _i;
        private int _j;
        private int _count_neighbours;

        private Image _image;

        public bool is_mine
        {
            get => _is_mine;
            set => _is_mine = value;
        }
        public bool is_revealed
        {
            get => _revealed;
            set => _revealed = value;
        }
        public bool marked
        {
            get => _marked;
            set => _marked = value;
        }
        public bool is_dark
        {
            get => _is_dark;
        }
        public int i
        {
            get => _i;
        }
        public int j
        {
            get => _j;
        }
        public int count_neighbours
        {
            get => _count_neighbours;
            set => _count_neighbours = value;
        }
        public Image image
        {
            get => _image;
            set => _image = value;
        }

        public Cell(int i, int j, bool mine, bool is_dark)
        {
            InitializeComponent();
            this._i = i;
            this._j = j;
            this._marked = false;
            this._revealed = false;
            this._is_mine = mine;
            this._is_dark = is_dark;
            this._image = Resources.none;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void reveal(Cell[,] grid)
        {
            this.is_revealed = true;
            this.BackgroundImage = this.image;
            this.Text = this.count_neighbours > 0 ? $"{this.count_neighbours}" : "";
            if (this.count_neighbours == 0)
            {
                this.flood_fill(grid);
            }
        }

        private void flood_fill(Cell[,] grid)
        {
            int len = (int)Math.Sqrt(grid.Length);
            for (int xoff = -1; xoff <= 1; xoff++)
            {
                for (int yoff = -1; yoff <= 1; yoff++)
                {
                    int i = this.i + xoff;
                    int j = this.j + yoff;
                    if (i > -1 && i < len && j > -1 && j < len)
                    {
                        Cell neighbour = grid[i, j];
                        if (!this.is_mine && !neighbour.is_revealed)
                            neighbour.reveal(grid);
                    }
                }
            }
        }

        public List<int[]> mark(List<int[]> marked_cells)
        {
            if (!this.is_revealed)
            {
                if (this.marked)
                {
                    marked_cells.Remove(new int[] { this.i, this.j });
                    this.marked = false;
                    this.BackgroundImage = this.is_dark ? Resources.unrevealed_dark : Resources.unrevealed_light;
                }
                else
                {
                    marked_cells.Add(new int[] { this.i, this.j });
                    this.marked = true;
                    this.BackgroundImage = this.is_dark ? Resources.marked_dark : Resources.marked_light;
                }
            }
            return marked_cells;
        }
    }
}
