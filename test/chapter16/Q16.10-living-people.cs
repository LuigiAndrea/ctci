using System.Collections.Generic;
using Chapter16;
using Xunit;

using static Chapter16.Q16_10LivingPeople;

namespace Tests.Chapter16
{
    public class Q16_10
    {
        [TheoryAttribute]
        [MemberData(nameof(TestDataLivingPeople.getLivingPeople), MemberType = typeof(TestDataLivingPeople))]
        public void LivingPeopleTest(List<Person> persons, int min, int max)
        {
            Assert.Equal(1905, GetYearMostPeopleAlive(persons, min, max));
        }
    }
    class TestDataLivingPeople
    {
        public static TheoryData<List<Person>, int, int> getLivingPeople()
        {
            var persons = new List<Person>(){
                    new Person(1905,1950),
                    new Person(1905,1905),
                    new Person(1910,1960),
                    new Person(1951,1960),
                    new Person(1905,1907),
                    new Person(1965,1980),
                    };

            return new TheoryData<List<Person>, int, int>() {
                {persons, 1900, 2000}};

        }
    }
}
