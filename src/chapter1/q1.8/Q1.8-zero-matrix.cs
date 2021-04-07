namespace Chapter1
{
    using System;
    using System.Collections.Generic;

    public class Q1_8ZeroMatrix
    {
        public static void ZeroMatrix(int[,] mtx)
        {

            if (mtx == null || mtx.GetLength(0) == 0)
            {
                throw new ArgumentException("Please provide a non empty MxN matrix");
            }

            (int rows, int cols) dim = (mtx.GetLength(0), mtx.GetLength(1));
            List<(int r, int c)> zeros = new List<(int r, int c)>();

            for (int i = 0; i < dim.rows; i++)
            {
                for (int j = 0; j < dim.cols; j++)
                {
                    if (mtx[i, j] == 0)
                    {
                        zeros.Add((i, j));
                    }
                }
            }

            foreach (var p in zeros)
            {
                zeroColAndRow(dim, (p.r, p.c), mtx);
            }
        }

        public static void zeroColAndRow((int r, int c) dim, (int r, int c) pos, int[,] mtx)
        {
            //zero the cols
            for (int i = 0; i < dim.c; i++)
            {
                mtx[pos.r, i] = 0;
            }

            //zero the rows
            for (int i = 0; i < dim.r; i++)
            {
                mtx[i, pos.c] = 0;
            }
        }
    }
}
