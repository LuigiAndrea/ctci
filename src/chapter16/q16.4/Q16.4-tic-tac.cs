using System;

namespace Chapter16
{
    public class Q16_4TicTac
    {
        public enum value { X, O, blank };
        //General case without knowing the last move
        public static bool hasWonTicTac(value[,] ttboard)
        {
            if (ttboard == null || ttboard.GetLength(0) != ttboard.GetLength(1))
            {
                throw new ArgumentNullException("Please provide non-null 3x3 tic-tac board");
            }

            return false;
        }
    }
}
