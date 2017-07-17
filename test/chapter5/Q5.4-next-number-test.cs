using Xunit;

using static Chapter5.Q5_4NextNumber;

namespace Tests.Chapter5
{
    public class Q5_4
    {
        [FactAttribute]
        private static void NextNumberTest()
        {
            (int input, int out1, int out2)[] cases = {
                (287, 252, 303),
                (4, 2, 8),
                (113, 108, 114),
                (56, 52, 67),
                (int.MaxValue,-1,-1),
                (int.MaxValue-1,int.MaxValue-2,-1),
                (int.MaxValue-1,int.MaxValue-2,-1),
                (int.MaxValue-2,int.MaxValue-4,int.MaxValue-1)};

            foreach (var test in cases)
            {
                Assert.Equal((test.out1, test.out2), nextNumber(test.input));
                Assert.Equal((test.out1, test.out2), nextNumber2(test.input));
            }
        }
    }
}
