using System;
using Xunit;

using static Chapter6.Q6_3Dominos;

namespace Tests.Chapter6
{
    public class Q6_3
    {
        [FactAttribute]
        private static void DominosTrueTest()
        {
            Assert.False(CanYouCoverEntireBoard(new Cell(7, 0), new Cell(0, 7)));
            Assert.False(CanYouCoverEntireBoard(new Cell(0, 7), new Cell(7, 0)));
            Assert.False(CanYouCoverEntireBoard(new Cell(1, 6), new Cell(5, 2)));
            Assert.True(CanYouCoverEntireBoard(new Cell(0, 0), new Cell(2, 3)));
            Assert.True(CanYouCoverEntireBoard(new Cell(5, 5), new Cell(5, 6)));
        }

        [FactAttribute]
        private static void DominosExceptionTest()
        {
            Cell[,] cells = new Cell[4, 2]{
                {new Cell(8,2),new Cell(5,5)},{new Cell(1,-2),new Cell(5,5)},
                {new Cell(1,2),new Cell(5,-5)},{new Cell(1,2),new Cell(5,1)},
                };

            for (int i = 0; i < cells.Length; i++)
            {
                Exception ext = Record.Exception(() => CanYouCoverEntireBoard(
                    new Cell(cells[i, 0].row, cells[i, 0].column),
                    new Cell(cells[i, 1].row, cells[i, 1].column)));
                Assert.IsType<ArgumentException>(ext);
            }
        }
    }
}
