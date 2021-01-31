
using static Chapter1.Q1_7RotateMatrix;
using Xunit;
using System;

namespace Tests.Chapter1
{
    public class Q1_7
    {
        [FactAttribute]
        public void TestRotateMatrix()
        {
            int[,] matrix = new int[,] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 }, { 16, 17, 18, 19, 20 }, { 21, 22, 23, 24, 25 } };
            int[,] expected = new int[,] { { 21, 16, 11, 6, 1 }, { 22, 17, 12, 7, 2 }, { 23, 18, 13, 8, 3 }, { 24, 19, 14, 9, 4 }, { 25, 20, 15, 10, 5 } };
            RotateMatrix rm = new RotateMatrix(matrix);
            rm.Rotate();
            Assert.Equal(expected, matrix);

            matrix = new int[,] { { 1, 2 }, { 3, 4, } };
            expected = new int[,] { { 3, 1 }, { 4, 2 } };
            rm = new RotateMatrix(matrix);
            rm.Rotate();
            Assert.Equal(expected, matrix);

            matrix = new int[,] { { 120 } };
            expected = new int[,] { { 120 } };
            rm = new RotateMatrix(matrix);
            rm.Rotate();
            Assert.Equal(expected, matrix);
        }

        [FactAttribute]
        public void TestRotateMatrixException()
        {                   
            Exception ex = Record.Exception(() => new RotateMatrix(new int[,]{}));
            Assert.IsType<ArgumentException>(ex);

            ex = Record.Exception(() => new RotateMatrix(new int[,]{{2},{3}}));
            Assert.IsType<ArgumentException>(ex);

            ex = Record.Exception(() => new RotateMatrix(null));
            Assert.IsType<ArgumentException>(ex);
        }  
    }
}