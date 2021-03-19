using Xunit;

using static Chapter16.Q16_8EnglishInt;

namespace Tests.Chapter16
{
    public class Q16_8
    {
        [TheoryAttribute]
        [InlineDataAttribute("Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred Ninety Nine", 999999999999)] //Max number allowed
        [InlineDataAttribute("Thirty Three Billion", 33000000000)]
        [InlineDataAttribute("Negative Five Hundred Two", -502)]
        [InlineDataAttribute("One Billion Two Hundred Twenty Million Fifty Thousand One Hundred Eleven", 1220050111)]
        [InlineDataAttribute("Nine Hundred Ninety Nine Million Two Thousand Thirteen", 999002013)]
        [InlineDataAttribute("Five Hundred Fifty Five Thousand One", 555001)]
        [InlineDataAttribute("Two Hundred Four", 204)]
        [InlineDataAttribute("Nineteen Million Four Hundred Seven Thousand Nine", 19407009)]
        [InlineDataAttribute("Sixty Two Million Thirty", 62000030)]
        [InlineDataAttribute("Eighty One Thousand", 81000)]
        [InlineDataAttribute("Negative Seventy Seven Thousand One Hundred", -77100)]
        [InlineDataAttribute("Seventy Seven Thousand One Hundred One", 77101)]
        [InlineDataAttribute("Zero", 0)]
        [InlineDataAttribute("Seven", 7)]
        public void EnglishIntTest(string sentence, long num)
        {
            Assert.Equal(sentence, GetEnglishInt(num));
        }
    }
}
