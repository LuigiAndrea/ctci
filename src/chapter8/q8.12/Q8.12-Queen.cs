using System;
using System.Collections.Generic;

namespace Chapter8
{
    public static class Q8_12Queen
    {
        static int sizeChessBoard;

        public static List<int[]> Queen(int sizeBoard = 8){
            if(sizeBoard < 2){
                throw new ArgumentException($"{nameof(Queen)} The size of the chess board must be greater than one");
            }

            sizeChessBoard = sizeBoard;
            List<int[]> results = new List<int[]>();
            placeQueens(new int[sizeChessBoard], 0, results);
            return results;
        }

        private static void placeQueens(int[] columns, int row, List<int[]> results)
        {
            if (row == sizeChessBoard)
            {
                results.Add(columns.Clone() as int[]);
            }
            else
            {
                for (int col = 0; col < sizeChessBoard; col++)
                {
                    if(isValidCell(row,col,columns)){
                        columns[row] = col;
                        placeQueens(columns,row+1,results);
                    }
                }
            }
        }

        private static bool isValidCell(int row, int col, int[] columns)
        {
            for (int rowI = 0; rowI < row; rowI++)
            {
                int colI = columns[rowI];

                //queen same column
                if (colI == col)
                    return false;

                int distRow = row - rowI;
                int distColumn = Math.Abs(col - colI);

                //queen same diagonal
                if (distRow == distColumn)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
