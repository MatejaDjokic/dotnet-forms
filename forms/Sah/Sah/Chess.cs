using figurica;
using piece_data;
using System.Diagnostics.CodeAnalysis;

namespace chess
{
    public static class Chess
    {
        public static bool is_empty(Figurica figurica) => figurica.type == PieceType.EMPTY;
        public static bool is_black(Figurica figurica) => figurica.color == PieceColor.BLACK;
        public static bool is_white(Figurica figurica) => figurica.color == PieceColor.WHITE;
        public static bool is_opponent(Figurica f1, Figurica f2) => f1.color != f2.color;

        public static int[,] convert(Figurica[,] figurice)
        {
            int[,] output = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Figurica f = figurice[i, j];
                    if (f.type == PieceType.EMPTY)
                        output[i, j] = 0;
                    else if (f.color == PieceColor.WHITE)
                        output[i, j] = 1;
                    else if (f.color == PieceColor.BLACK)
                        output[i, j] = -1;
                }
            }

            return output;
        }
        private static bool[,] get_all_possible(PieceColor color, int[,] matrix)
        {
            int int_color = color == PieceColor.WHITE ? 1 : -1;
            bool[,] output = new bool[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (matrix[i, j] == 0 || matrix[i, j] == int_color)
                        output[i, j] = true;
                    else output[i, j] = false;
                }
            }
            return output;
        }
        public static Tuple<int, int>[] get_possible_for_piece(Figurica figurica, Figurica[,] figurice)
        {
            bool[,] all_possible_positions = get_all_possible(figurica.color, convert(figurice));

            bool[,] possible_for_piece_matrix = new bool[8, 8];
            Tuple<int, int>[] possible_for_piece_array = new Tuple<int, int>[8 * 8];



            switch (figurica.type)
            {
                case PieceType.PAWN: possible_for_piece_matrix = pawn(all_possible_positions); break;
                case PieceType.ROOK: possible_for_piece_matrix = rook(all_possible_positions); break;
                case PieceType.KNIGHT: possible_for_piece_matrix = knight(all_possible_positions); break;
                case PieceType.BISHOP: possible_for_piece_matrix = bishop(all_possible_positions); break;
                case PieceType.QUEEN: possible_for_piece_matrix = queen(all_possible_positions); break;
                case PieceType.KING: possible_for_piece_matrix = king(all_possible_positions); break;
            }

            int index = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (possible_for_piece_matrix[i, j])
                        possible_for_piece_array[index] = Tuple.Create(i, j);
                }
            }

            return possible_for_piece_array;
        }

        private static bool[,] pawn(bool[,] all_possible_positions)
        {
            return all_possible_positions;
        }
        private static bool[,] rook(bool[,] all_possible_positions)
        {
            return all_possible_positions;
        }
        private static bool[,] knight(bool[,] all_possible_positionst)
        {
            return all_possible_positionst;
        }
        private static bool[,] bishop(bool[,] all_possible_positions)
        {
            return all_possible_positions;
        }
        private static bool[,] queen(bool[,] all_possible_positions)
        {
            return all_possible_positions;
        }
        private static bool[,] king(bool[,] all_possible_positions)
        {
            return all_possible_positions;
        }
    }
}
