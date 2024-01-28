using saved_boards;
using figurica;
using piece_data;
using chess;
using System.Diagnostics;

namespace Sah
{
    public partial class Form1 : Form
    {
        const int PIECE_SIZE = 50;

        Figurica[,] figurice;

        private Figurica? selected;
        private bool white_plays;

        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            figurice = new Figurica[8, 8];
            this.BackColor = Color.DimGray;
            this.selected = null;
            this.white_plays = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Point pos = new Point(i, j);
                    TypeColorPair data_pair = SavedBoards.DEFAULT_BOARD[i, j];
                    Figurica figurica = new Figurica(pos, data_pair.type, data_pair.color);

                    figurica.set_image();
                    figurica.Click += figurica_click!;

                    figurica.Size = new Size(PIECE_SIZE, PIECE_SIZE);

                    figurica.BackColor = Color.DimGray;

                    int x = figurica.pos.X * PIECE_SIZE;
                    int y = figurica.pos.Y * PIECE_SIZE;
                    figurica.Location = new Point(x, y);

                    figurice[i, j] = figurica;
                    this.Controls.Add(figurica);
                }
            }
        }
        private void figurica_click(object sender, EventArgs e)
        {
            // PARSUJEMO object sender (OBJEKAT KOJI JE KLIKNUT) U FIGURICA KLASU
            Figurica figurica = (Figurica)sender;

            // AKO IZABRANO POLJE JOS NIJE IZABRAONO 
            if (selected == null)
            {
                // AKO POLJE NA KOJE SMO KLINULI NIJE PRAZNO 
                if (figurica.type != PieceType.EMPTY)
                {
                    bool white = white_plays && Chess.is_white(figurica);
                    bool black = !white_plays && Chess.is_black(figurica);
                    if (white || black)
                    {
                        selected = figurica;
                        foreach (Figurica f in figurice) f.BackColor = Color.DimGray;
                        figurica.BackColor = Color.Green;
                    }
                    else MessageBox.Show("Ne mozete izabrati figuricu suprotne boje!");
                }
                else MessageBox.Show("Molim vas izaberite polje koje nije prazno!");
            }
            // AKO JE IZARANO POLJE VEC IZABRANO
            else
            {
                Tuple<int, int> pos_tuple = Tuple.Create(figurica.pos.X, figurica.pos.Y);

                Tuple<int, int>[] valid_positions = Chess.get_possible_for_piece(figurica, figurice);

                foreach (Tuple<int, int> valid_pos in valid_positions)
                    figurice[valid_pos.Item1, valid_pos.Item2].BackColor = Color.Green;

                if (valid_positions.Contains(pos_tuple))
                {
                    Figurica temp = figurice[figurica.pos.X, figurica.pos.Y];
                    figurice[figurica.pos.X, figurica.pos.Y] = figurice[selected.pos.X, selected.pos.Y];
                    figurice[selected.pos.X, selected.pos.Y] = temp;

                    figurice[figurica.pos.X, figurica.pos.Y].set_image();
                    figurice[selected.pos.X, selected.pos.Y].set_image();

                    foreach (Figurica f in figurice) f.BackColor = Color.DimGray;
                    selected = null;
                }
                else
                {
                    MessageBox.Show("Molim vas izaberite valido polje!");
                }
            }
        }
    }
}