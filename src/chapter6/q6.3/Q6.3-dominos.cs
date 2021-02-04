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
            if (!isCellInChessboard(cell1, cell2))
            {
                throw new ArgumentOutOfRangeException("Please provide a cell in the chessboard");
            }

            return (chessboard[cell1.row, cell1.column] == chessboard[cell2.row, cell2.column]) ? false : true;
        }

        private static bool isCellInChessboard(params Cell[] cells)
        {
            bool valide = true;
            foreach (var c in cells)
            {
                if (c.row < 0 || c.row > 7 || c.column < 0 || c.column > 7)
                {
                    valide = false;
                    break;
                }
            }
            return valide;
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
