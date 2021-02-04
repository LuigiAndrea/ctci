using System;

namespace Chapter6
{
    public static class Q6_3Dominos
    {
        static int[,] chessboard = new int[8, 8]{
            {0,1,0,1,0,1,0,1},{1,0,1,0,1,0,1,0},
            {0,1,0,1,0,1,0,1},{1,0,1,0,1,0,1,0},
            {0,1,0,1,0,1,0,1},{1,0,1,0,1,0,1,0},
            {0,1,0,1,0,1,0,1},{1,0,1,0,1,0,1,0},
        };

        public static bool CanYouCoverEntireBoard(Cell cell1, Cell cell2)
        {
            return false;
        }

        //Cut off cell
        public class Cell
        {
            public int row { get; set; }
            public int column { get; set; }

            public Cell(int r, int c)
            {
                row = r;
                column = c;
            }
        }
    }
}
