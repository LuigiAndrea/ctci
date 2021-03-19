using System;
using Xunit;

using static Chapter16.Q16_2WordFrequencies;

namespace Tests.Chapter16
{
    public class Q16_2
    {

        [FactAttribute]
        private void WordFrequenciesTest()
        {
            string bookArtemis = "Born to a typical dwarf cavern-dwelling family, Mulch had decided early that mining was not for him and resolved to put his talents to another use, namely digging and entering, generally entering Mud People’s property. Of course this meant forfeiting his magic. Dwellings were sacred. If you broke that rule, you had to be prepared to accept the consequences. Mulch didn’t mind. He didn’t care much for magic anyway. There had never been much use for it down the mines. Things had gone pretty well for a few centuries, and he’d built up quite a lucrative above-ground memorabilia business. That was until he’d tried to sell the Jules Rimet Cup to an undercover LEP operative. From then on his luck had turned, and he’d been arrested over twenty times to date. A total of 300 years in and out of prison.";
            var book = bookArtemis.Split(new[] { ',', ' ', ';', '.' }, StringSplitOptions.RemoveEmptyEntries);
            Book bk = new Book(book);
            Assert.Equal(8, bk.GetFrequencies("to"));
            Assert.Equal(2, bk.GetFrequencies("entering"));
            Assert.Equal(2, bk.GetFrequencies("EntEriNg"));
            Assert.Equal(5, bk.GetFrequencies("AND"));
        }

        [FactAttribute]
        public void WordFrequenciesExceptionTest()
        {
            Exception ex = Record.Exception(() => new Book(new string[] { }));
            Assert.IsType<ArgumentException>(ex);

            ex = Record.Exception(() => new Book(null));
            Assert.IsType<ArgumentException>(ex);
        }
    }
}
