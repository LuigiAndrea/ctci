using System.Collections.Generic;
using Xunit;

using static Chapter16.Q16_11DivingBoard;

namespace Tests.Chapter16
{
    public class Q16_11
    {
        [FactAttribute]
        public void DivingBoardTest()
        {
            Assert.Equal(new List<int>() { 10, 9, 8, 7, 6, 5 }, GetLengthsBoard(5, 1, 2));
            Assert.Equal(new List<int>() { 30 }, GetLengthsBoard(10, 3, 3));
            Assert.Equal(new List<int>() { 6, 4, 2 }, GetLengthsBoard(2, 1, 3));
            Assert.Equal(new List<int>() { 10, 2 }, GetLengthsBoard(1, 2, 10));
            Assert.Equal(new List<int>() { 0 }, GetLengthsBoard(0, 2, 10));
        }
    }
}
