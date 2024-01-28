using piece_data;

namespace saved_boards
{
    public class TypeColorPair
    {
        private PieceType _type;
        private PieceColor _color;

        public PieceType type => _type;
        public PieceColor color => _color;

        public TypeColorPair(PieceType t, PieceColor c)
        {
            _type = t;
            _color = c;
        }
    }

    public static class SavedBoards
    {
        private static TypeColorPair em = new TypeColorPair(PieceType.EMPTY, PieceColor.NONE);

        private static TypeColorPair wp = new TypeColorPair(PieceType.PAWN, PieceColor.WHITE);
        private static TypeColorPair wr = new TypeColorPair(PieceType.ROOK, PieceColor.WHITE);
        private static TypeColorPair wn = new TypeColorPair(PieceType.KNIGHT, PieceColor.WHITE);
        private static TypeColorPair wb = new TypeColorPair(PieceType.BISHOP, PieceColor.WHITE);
        private static TypeColorPair wq = new TypeColorPair(PieceType.QUEEN, PieceColor.WHITE);
        private static TypeColorPair wk = new TypeColorPair(PieceType.KING, PieceColor.WHITE);

        private static TypeColorPair bp = new TypeColorPair(PieceType.PAWN, PieceColor.BLACK);
        private static TypeColorPair br = new TypeColorPair(PieceType.ROOK, PieceColor.BLACK);
        private static TypeColorPair bn = new TypeColorPair(PieceType.KNIGHT, PieceColor.BLACK);
        private static TypeColorPair bb = new TypeColorPair(PieceType.BISHOP, PieceColor.BLACK);
        private static TypeColorPair bq = new TypeColorPair(PieceType.QUEEN, PieceColor.BLACK);
        private static TypeColorPair bk = new TypeColorPair(PieceType.KING, PieceColor.BLACK);


        public static TypeColorPair[,] DEFAULT_BOARD = {
            {wr, wn, wb, wq, wk, wb, wn, wr},
            {wp, wp, wp, wp, wp, wp, wp, wp},
            {em, em, em, em, em, em, em, em},
            {em, em, em, em, em, em, em, em},
            {em, em, em, em, em, em, em, em},
            {em, em, em, em, em, em, em, em},
            {bp, bp, bp, bp, bp, bp, bp, bp},
            {br, bn, bb, bq, bk, bb, bn, br},
        };
    }
}
