
using static Chapter1.Q1_8ZeroMatrix;
using Xunit;
using System;

namespace Tests.Chapter1
{
    public class Q1_8
    {
        [FactAttribute]
        public void ZeroMatrixTest()
        {
            int[,] matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] expected = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            ZeroMatrix(matrix);
            Assert.Equal(expected, matrix);

            matrix = new int[,] { { 1, 2, 3 }, { 4, 0, 6 }, { 7, 8, 9 } };
            expected = new int[,] { { 1, 0, 3 }, { 0, 0, 0 }, { 7, 0, 9 } };
            ZeroMatrix(matrix);
            Assert.Equal(expected, matrix);

            matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            expected = new int[,] { { 1, 2, 0 }, { 4, 5, 0 }, { 0, 0, 0 } };
            ZeroMatrix(matrix);
            Assert.Equal(expected, matrix);
        }

        [FactAttribute]
        public void MoreZeroMatrixTest()
        {
            int[,] matrix = new int[,] { { 0, 2, 0 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] expected = new int[,] { { 0, 0, 0 }, { 0, 5, 0 }, { 0, 8, 0 } };

            ZeroMatrix(matrix);
            Assert.Equal(expected, matrix);
        }

        [FactAttribute]
        public void ZeroMatrixDiffDimensionsTest()
        {
            int[,] matrix = new int[,] { { 1, 0, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            int[,] expected = new int[,] { { 0, 0, 0 }, { 4, 0, 6 }, { 7, 0, 9 }, { 10, 0, 12 } };

            ZeroMatrix(matrix);
            Assert.Equal(expected, matrix);
        }

        [FactAttribute]
        public void ZeroMatrixExceptionTest()
        {
            Exception ex = Record.Exception(() => ZeroMatrix(new int[,] { }));
            Assert.IsType<ArgumentException>(ex);

            ex = Record.Exception(() => ZeroMatrix(null));
            Assert.IsType<ArgumentException>(ex);
        }
    }
}
