using Sah.Properties;
using piece_data;

namespace figurica
{
    public partial class Figurica : Button
    {
        /*
            A T T R I B U T E S
         */
        private Point _pos;
        private PieceType _piece_type;
        private PieceColor _piece_color;

        /*
            G E T T E R S  /  S E T T E R S
         */
        public Point pos { get => _pos; }
        public PieceType type { get => _piece_type; }
        public PieceColor color { get => _piece_color; }

        public Figurica(Point pos, PieceType piece_type, PieceColor piece_color)
        {
            _pos = pos;
            _piece_type = piece_type;
            _piece_color = piece_color;
            InitializeComponent();
        }

        public void set_image()
        {
            switch (type)
            {
                case PieceType.PAWN:
                    if (color == PieceColor.WHITE)
                        this.Image = Resources.white_pawn;
                    else
                        this.Image = Resources.black_pawn;
                    break;
                case PieceType.ROOK:
                    if (color == PieceColor.WHITE)
                        this.Image = Resources.white_rook;
                    else
                        this.Image = Resources.black_rook;
                    break;
                case PieceType.KNIGHT:
                    if (color == PieceColor.WHITE)
                        this.Image = Resources.white_knight;
                    else
                        this.Image = Resources.black_knight;
                    break;
                case PieceType.BISHOP:
                    if (color == PieceColor.WHITE)
                        this.Image = Resources.white_bishop;
                    else
                        this.Image = Resources.black_bishop;
                    break;
                case PieceType.QUEEN:
                    if (color == PieceColor.WHITE)
                        this.Image = Resources.white_queen;
                    else
                        this.Image = Resources.black_queen;
                    break;
                case PieceType.KING:
                    if (color == PieceColor.WHITE)
                        this.Image = Resources.white_king;
                    else
                        this.Image = Resources.black_king;
                    break;
                default:
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
