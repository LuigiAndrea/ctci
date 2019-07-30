using System;
using Xunit;

using static Chapter8.Q8_14BooleanEvaluation;


namespace Tests.Chapter8
{
    public class Q8_14
    {

        [TheoryAttribute]
        [InlineDataAttribute("0|0&1|0", false)]
        [InlineDataAttribute("0^1^0&1", true)]
        [InlineDataAttribute("1|0|1|0", true)]
        private void BooleanEvaluationAllCombinationsTest(string s, bool result)
        {
            int expectedValue = 5;
            int actualValue = CountEvaluation(s, result);
            Assert.Equal(expectedValue, actualValue);
            actualValue = CountEvaluationOptimized(s, result);
            Assert.Equal(expectedValue, actualValue);
        }


        [TheoryAttribute]
        [InlineDataAttribute("0", false)]
        [InlineDataAttribute("1", true)]
        [InlineDataAttribute("1|0", true)]
        [InlineDataAttribute("1^0", true)]
        [InlineDataAttribute("1&0", false)]
        private void BooleanEvaluationOneZeroOperatorTest(string s, bool result)
        {
            int expectedValue = 1;
            int actualValue = CountEvaluation(s, result);
            Assert.Equal(expectedValue, actualValue);
            actualValue = CountEvaluationOptimized(s, result);
            Assert.Equal(expectedValue, actualValue);
        }


        [TheoryAttribute]
        [InlineDataAttribute("0", true)]
        [InlineDataAttribute("1&1&1", false)]
        [InlineDataAttribute("0|0^0&0&1", true)]
        private void BooleanEvaluationNoCombinationTest(string s, bool result)
        {
            int expectedValue = 0;
            int actualValue = CountEvaluation(s, result);
            Assert.Equal(expectedValue, actualValue);
            actualValue = CountEvaluationOptimized(s, result);
            Assert.Equal(expectedValue, actualValue);
        }

        [TheoryAttribute]
        [InlineDataAttribute("0&1&0^1", true)]
        [InlineDataAttribute("0^1^0|1", false)]
        [InlineDataAttribute("0&1^0|1", false)]
        private void BooleanEvaluationMixTest(string s, bool result)
        {
            int expectedValue = 2;
            int actualValue = CountEvaluation(s, result);
            Assert.Equal(expectedValue, actualValue);
            actualValue = CountEvaluationOptimized(s, result);
            Assert.Equal(expectedValue, actualValue);
        }

        [TheoryAttribute]
        [InlineDataAttribute("^0&1|1", true)]
        [InlineDataAttribute("1^0&1^5|1", true)]
        [InlineDataAttribute("1^0&1^b|1", true)]
        [InlineDataAttribute("1^0&1^0|1&", true)]
        [InlineDataAttribute("101", true)]
        [InlineDataAttribute("&", true)]
        [InlineDataAttribute("", false)]
        [InlineDataAttribute(null, false)]
        private void BooleanEvaluationExceptionTest(string s, bool result)
        {
            Exception actualException = Record.Exception(() => CountEvaluation(s,result));
            Assert.IsType<ArgumentException>(actualException);

            actualException = Record.Exception(() => CountEvaluationOptimized(s,result));
            Assert.IsType<ArgumentException>(actualException);
        }
    }
}
