using System;
using Xunit;

using static Chapter16.Q16_4TicTac;

namespace Tests.Chapter16
{
    public class Q16_4
    {
        [TheoryAttribute]
        [MemberData(nameof(TestDataTicTac.getWinningXCombinations), MemberType = typeof(TestDataTicTac))]
        public void TicTacWinningXTest(value[,] board)
        {
            Assert.Equal(value.X, hasWonTicTac(board));
            Assert.Equal(value.X, hasWonTicTacLastMove(board, 1, 1));
        }

        [TheoryAttribute]
        [MemberData(nameof(TestDataTicTac.getWinningOCombinations), MemberType = typeof(TestDataTicTac))]
        public void TicTacWinningOTest(value[,] board)
        {
            Assert.Equal(value.O, hasWonTicTac(board));
            Assert.Equal(value.O, hasWonTicTacLastMove(board, 1, 1));
        }

        [TheoryAttribute]
        [MemberData(nameof(TestDataTicTac.getNoWinningCombinations), MemberType = typeof(TestDataTicTac))]
        public void TicTacNoWinningTest(value[,] board)
        {
            Assert.Equal(value.blank, hasWonTicTac(board));
            Assert.Equal(value.blank, hasWonTicTacLastMove(board, 1, 1));
            Assert.Equal(value.blank, hasWonTicTacLastMove(board, 2, 0));
            Assert.Equal(value.blank, hasWonTicTacLastMove(board, 1, 2));
        }

        [TheoryAttribute]
        [MemberData(nameof(TestDataTicTac.getWrongBoard), MemberType = typeof(TestDataTicTac))]
        public void TicTacExceptionTest(value[,] board)
        {
            Exception ex = Record.Exception(() => hasWonTicTac(board));
            Assert.IsType<ArgumentNullException>(ex);
        }

        [TheoryAttribute]
        [MemberData(nameof(TestDataTicTac.getWrongPositionInBoard), MemberType = typeof(TestDataTicTac))]
        public void TicTacPositionExceptionTest(value[,] board, int r, int c)
        {
            Exception ex = Record.Exception(() => hasWonTicTacLastMove(board, r, c));
            Assert.IsType<ArgumentNullException>(ex);
        }
    }

    class TestDataTicTac
    {
        public static TheoryData<value[,]> getWrongBoard()
        {
            return new TheoryData<value[,]>() {
                { null},
                { new value[3, 2] {{ value.blank, value.blank },{ value.blank, value.blank },{ value.blank, value.blank }}},
                { new value[4, 4] {{ value.blank, value.blank,value.blank,value.blank },{ value.blank, value.blank,value.blank,value.blank },{ value.blank, value.blank,value.blank,value.blank },{ value.blank, value.blank,value.blank,value.blank }}},
                { new value[1, 2] {{ value.blank, value.blank }}}};
        }

        public static TheoryData<value[,], int, int> getWrongPositionInBoard()
        {
            var board = new value[3, 3] {
                { value.blank, value.blank, value.blank },
                { value.blank, value.blank, value.blank },
                { value.blank, value.blank, value.blank }};

            return new TheoryData<value[,], int, int>() { { board, -1, 0 }, { board, 0, 3 }, { board, 5, 2 }, { board, 5, 22 }, { board, 1, -2 } };
        }

        public static TheoryData<value[,]> getWinningXCombinations()
        {
            value[,] board1 = new value[3, 3] {
                { value.X, value.O, value.O },
                { value.O, value.X, value.blank },
                { value.blank, value.blank, value.X } };

            value[,] board2 = new value[3, 3] {
                { value.O, value.O, value.X },
                { value.X, value.X, value.X },
                { value.O, value.O, value.blank } };

            return new TheoryData<value[,]>() { board1, board2 };
        }


        public static TheoryData<value[,]> getWinningOCombinations()
        {
            value[,] board1 = new value[3, 3] {
                    { value.X, value.O, value.O },
                    { value.blank, value.O, value.X },
                    { value.X, value.O, value.X } };

            value[,] board2 = new value[3, 3] {
                { value.O, value.X, value.O },
                { value.X, value.O, value.X },
                { value.O, value.X, value.blank } };

            return new TheoryData<value[,]>() { board1, board2 };
        }

        public static TheoryData<value[,]> getNoWinningCombinations()
        {
            value[,] board1 = new value[3, 3] {
                { value.X, value.O, value.X },
                { value.X, value.O, value.X },
                { value.O, value.X, value.O } };

            value[,] board2 = new value[3, 3] {
                { value.X, value.blank, value.blank },
                { value.X, value.O, value.X },
                { value.O, value.X, value.O } };

            value[,] board3 = new value[3, 3] {
                { value.blank, value.blank, value.blank },
                { value.blank, value.blank, value.blank },
                { value.blank, value.blank, value.blank } };

            return new TheoryData<value[,]>() { board1, board2, board3 };
        }
    }
}
