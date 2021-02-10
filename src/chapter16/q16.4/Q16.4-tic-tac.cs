using System;

namespace Chapter16
{
    public class Q16_4TicTac
    {
        public enum value { X, O, blank };

        public static value hasWonTicTac(value[,] ttboard)
        {
            validateBoard(ttboard);
            value piece = value.blank;

            for (int i = 0; i < 3; i++)
            {
                //check rows
                piece = hasWon(ttboard[i, 0], ttboard[i, 1], ttboard[i, 2]);
                {
                    if (piece != value.blank)
                        return piece;
                }

                //check columns
                piece = hasWon(ttboard[0, i], ttboard[1, i], ttboard[2, i]);
                {
                    if (piece != value.blank)
                        return piece;
                }

            }

            //check diagonals
            piece = hasWon(ttboard[0, 0], ttboard[1, 1], ttboard[2, 2]);
            {
                if (piece != value.blank)
                    return piece;
            }

            piece = hasWon(ttboard[0, 2], ttboard[1, 1], ttboard[2, 0]);
            {
                if (piece != value.blank)
                    return piece;
            }

            return piece;
        }

        private static void validateBoard(value[,] ttboard)
        {
            if (ttboard == null)
            {
                throw new ArgumentNullException("Please provide non-null 3x3 tic-tac board");
            }

            var firstDim = ttboard.GetLength(0);
            var secondDim = ttboard.GetLength(1);

            if (firstDim != secondDim || firstDim > 3)
            {
                throw new ArgumentNullException("Please provide a 3x3 tic-tac board");
            }
        }

        private static value hasWon(value p1, value p2, value p3) => (p1 == p2 && p2 == p3) ? p1 : value.blank;
    }
}
