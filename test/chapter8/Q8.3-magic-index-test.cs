using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

using static Chapter8.Q8_3MagicIndex;


namespace Tests.Chapter8
{
    public class Q8_3
    {
        [FactAttribute]
        private static void EmptyOrNullMagicArray()
        {
            Exception actualEmptyException = Record.Exception(() => findMagicIndex(new int[] { }));
            Assert.IsType<ArgumentNullException>(actualEmptyException);

            Exception actualNullException = Record.Exception(() => findMagicIndex(null));
            Assert.IsType<ArgumentNullException>(actualNullException);
        }

        [FactAttribute]
        private static void ArrayWithMagicIndex()
        {
            int[] magic = new int[] { -1, 0, 2, 31, 44, 45, 47, 118 };
            int magicIndex = findMagicIndex(magic);
            Assert.Equal(magicIndex, 2);

            magic = new int[] { 0 };
            magicIndex = findMagicIndex(magic);
            Assert.Equal(magicIndex, 0);

            magic = new int[] { -3, -1, 1,2,3,4,5,6,7,8,10};
            magicIndex = findMagicIndex(magic);
            Assert.Equal(magicIndex, 10);
        }

        [FactAttribute]
        private static void ArrayWithoutMagicIndex()
        {
            int[] magic = new int[] { -10, -5, 1, 13, 44, 45, 47, 118 };
            int magicIndex = findMagicIndex(magic);
            Assert.Equal(magicIndex, -1);
        }
    }
}