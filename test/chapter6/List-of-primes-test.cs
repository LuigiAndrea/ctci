using Xunit;

using static Chapter6.C6_ListOfPrimes;

namespace Tests.Chapter6
{ 
    public class C6_ListOfPrimes
    {
        [TheoryAttribute]
        [InlineDataAttribute(4999999,348514)]
        [InlineDataAttribute(5000000,348514)]
        [InlineDataAttribute(1234567,95361)]       
        [InlineDataAttribute(1,1)]
        [InlineDataAttribute(3,3)]
        private static void ListOfPrimesTest(int input, int output)
        {        
            Assert.Equal(output,GetListOfPrimes(input).Length);
        }
    }
}
