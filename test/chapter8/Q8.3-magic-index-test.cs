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

            actualNullException = Record.Exception(() => findMagicIndexNotDistinctValues(null));
            Assert.IsType<ArgumentNullException>(actualNullException);
        }

        [FactAttribute]
        private static void ArrayWithMagicIndex()
        {
            int[] magic = new int[] { -1, 0, 2, 31, 44, 45, 47, 118 };
            int magicIndex = findMagicIndex(magic);
            Assert.Equal(2, magicIndex);

            magicIndex = findMagicIndexNotDistinctValues(magic);
            Assert.Equal(2, magicIndex);

            magic = new int[] { 0 };
            magicIndex = findMagicIndex(magic);
            Assert.Equal(0, magicIndex);

            magicIndex = findMagicIndexNotDistinctValues(magic);
            Assert.Equal(0, magicIndex);

            magic = new int[] { -3, -1, 1, 2, 3, 4, 5, 6, 7, 8, 10 };
            magicIndex = findMagicIndex(magic);
            Assert.Equal(10, magicIndex);

            magicIndex = findMagicIndexNotDistinctValues(magic);
            Assert.Equal(10, magicIndex);
        }

        [FactAttribute]
        private static void ArrayWithoutMagicIndex()
        {
            int[] magic = new int[] { -10, -5, 1, 13, 44, 45, 47, 118 };
            int magicIndex = findMagicIndex(magic);
            Assert.Equal(-1, magicIndex);

            magicIndex = findMagicIndexNotDistinctValues(magic);
            Assert.Equal(-1, magicIndex);

            magic = new int[] { -10, -9, -8, -7, -6, -5, -2, -1 };
            magicIndex = findMagicIndex(magic);
            Assert.Equal(-1, magicIndex);

            magicIndex = findMagicIndexNotDistinctValues(magic);
            Assert.Equal(-1, magicIndex);

            magic = new int[] { 30, 44, 78, 97, 98, 106, 115, 122 };
            magicIndex = findMagicIndex(magic);
            Assert.Equal(-1, magicIndex);

            magicIndex = findMagicIndexNotDistinctValues(magic);
            Assert.Equal(-1, magicIndex);
        }

        [FactAttribute]
        private static void ArrayWithoutMagicIndexNotDistinct()
        {
            int[] magic = new int[] { -2, -2, 1, 2, 2, 2, 2 };

            int magicIndex = findMagicIndexNotDistinctValues(magic);
            Assert.Equal(-1, magicIndex); 
            
            magic = new int[] { 12, 12, 12, 12, 12, 12, 12, 15 };

            magicIndex = findMagicIndexNotDistinctValues(magic);
            Assert.Equal(-1, magicIndex); 

            magic = new int[] { 1, 2, 3, 5, 5, 7, 7, 8 };

            magicIndex = findMagicIndexNotDistinctValues(magic);
            Assert.Equal(-1, magicIndex); 
        
        }

        [FactAttribute]
        private static void ArrayWithtMagicIndexNotDistinct()
        {
            int[] magic = new int[] { -1, 2, 2, 2, 3, 7, 12 };

            int magicIndex = findMagicIndexNotDistinctValues(magic);
            Assert.Equal(2, magicIndex);

            magic = new int[] { -3, -1, -1, -1, 3, 3, 6 };
            magicIndex = findMagicIndexNotDistinctValues(magic);
            Assert.Equal(6, magicIndex);
        }
    }
}