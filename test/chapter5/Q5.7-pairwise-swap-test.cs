using Xunit;

using static Chapter5.Q5_7PairwiseSwap;

namespace Tests.Chapter5
{
    public class Q5_7
    {
        [FactAttribute]
        private static void PairWiseTest()
        {
            (int input, int output)[] cases = {
                (3726,3405),
                (int.MaxValue,unchecked((int)0xbfffffff)),
                (int.MinValue,0x40000000),
                (0,0),
                (1,2),
                (-1,-1)
                };

            foreach (var test in cases)
                Assert.Equal(test.output, pairwiseSwap(test.input));

        }
    }
}
