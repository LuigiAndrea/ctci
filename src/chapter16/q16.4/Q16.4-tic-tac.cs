using System;
using System.Runtime.CompilerServices;

namespace Chapter16
{
    public class Q16_4TicTac
    {
        public enum value { X, O, blank };
        const int length = 3;

        public static value hasWonTicTac(value[,] ttboard)
        {
            validateBoard(ttboard);
            value piece = value.blank;

            for (int i = 0; i < length; i++)
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

        //Knowing the last move
        public static value hasWonTicTacLastMove(value[,] ttboard, int r, int c)
        {
            validateBoard(ttboard, r, c);

            //check rows at index r
            if (hasWon(ttboard[r, 0], ttboard[r, 1], ttboard[r, 2]) != value.blank)
            {
                return ttboard[r, c];
            }

            //check columns at index c
            if (hasWon(ttboard[0, c], ttboard[1, c], ttboard[2, c]) != value.blank)
            {
                return ttboard[r, c];
            }

            //check diagonals
            if (r == c)
            {
                if (hasWon(ttboard[0, 0], ttboard[1, 1], ttboard[2, 2]) != value.blank)
                {
                    return ttboard[r, c];
                }
                if (r == 1 && hasWon(ttboard[length - 1, 0], ttboard[1, 1], ttboard[0, length - 1]) != value.blank)
                {
                    return ttboard[r, c];
                }
            }

            return (c == length - 1 || r == length - 1)
            ? hasWon(ttboard[length - 1, 0], ttboard[1, 1], ttboard[0, length - 1])
            : value.blank;

        }
        private static void validateBoard(value[,] ttboard, int r = 0, int c = 0, [CallerMemberName] string callerName = "")
        {
            if (callerName == nameof(hasWonTicTacLastMove))
            {
                validatePosition(r, c);
            }

            if (ttboard == null)
            {
                throw new ArgumentNullException("Please provide non-null 3x3 tic-tac board");
            }

            var firstDim = ttboard.GetLength(0);
            var secondDim = ttboard.GetLength(1);

            if (firstDim != secondDim || firstDim > length)
            {
                throw new ArgumentNullException("Please provide a 3x3 tic-tac board");
            }
        }

        private static void validatePosition(int r, int c)
        {
            if (r >= length || c >= length || r < 0 || c < 0)
            {
                throw new ArgumentNullException("Please provide a valid position");
            }
        }

        private static value hasWon(value p1, value p2, value p3) => (p1 == p2 && p2 == p3) ? p1 : value.blank;
    }
}
