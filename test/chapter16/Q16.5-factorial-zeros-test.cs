using System;
using Xunit;

using static Chapter16.Q16_5FactorialZeros;

namespace Tests.Chapter6
{
    public class Q16_5
    {

        [FactAttribute]
        public void FactorialZerosTest()
        {
            Assert.Equal(1249, GetFactorialTrailingZeros(5000));
            Assert.Equal(255, GetFactorialTrailingZeros(1025));
            Assert.Equal(255, GetFactorialTrailingZeros(1029));
            Assert.Equal(0, 0);
            Assert.Equal(4, 0);
        }

        [FactAttribute]
        public void FactorialZerosExceptionTest()
        {
            Exception ex = Record.Exception(() => GetFactorialTrailingZeros(-5));
            Assert.IsType<ArgumentException>(ex);
        }
    }
}
