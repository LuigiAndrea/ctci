using Xunit;

using static Chapter16.Q16_8EnglishInt;

namespace Tests.Chapter6
{
    public class Q16_8
    {
        [TheoryAttribute]
        [InlineDataAttribute("Negative Five Hundred Two", -502)]
        [InlineDataAttribute("One Billion Two Hundred Twenty Milion Fifty Thousand One Hundred Eleven", 1220050111)]
        [InlineDataAttribute("Nine Hundred Ninty Nine Milion Two Thousand Thirteen", 999002013)]
        [InlineDataAttribute("Five Hundred Fifty Five Thousand One", 555001)]
        [InlineDataAttribute("Two Hundred Four", 204)]
        [InlineDataAttribute("Seven", 7)]
        public void EnglishIntTest(string sentence, int num)
        {
            Assert.Equal(sentence, GetEnglishInt(num));
        }
    }
}
