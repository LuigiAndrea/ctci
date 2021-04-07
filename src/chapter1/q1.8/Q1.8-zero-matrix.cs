namespace Chapter1
{
    using System;
    using System.Text;

    public class Q1_8ZeroMatrix
    {
        public static void ZeroMatrix(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0)
            {
                throw new ArgumentException("Please provide a non empty MxN matrix");
            }
        }

        public static void zeroColAndRow(int[,] mtx)
        {

        }

    }
}