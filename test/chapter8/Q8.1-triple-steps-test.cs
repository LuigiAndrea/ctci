using System;
using Xunit;

using static Chapter8.Q8_1TripleSteps;

namespace Tests.Chapter8
{
    public class Q8_1
    {
        [FactAttribute]
        private static void TripleStepsTest()
        {
            Exception actualException = Record.Exception(() => CountSteps(0,false));
            Assert.IsType<ArgumentException>(actualException);
            Assert.Equal(7,CountSteps(4,false));
            Assert.Equal(1,CountSteps(1,false));
        }

        [FactAttribute]
        private static void TripleStepsMemoTest()
        {
            Exception actualException = Record.Exception(() => CountSteps(0,true));
            Assert.IsType<ArgumentException>(actualException);
            Assert.Equal(7,CountSteps(4,true));
            Assert.Equal(1,CountSteps(1,true));
        }
    }
}