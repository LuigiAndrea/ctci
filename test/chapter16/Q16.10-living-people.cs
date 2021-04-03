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
        public void LivingPeopleTest(List<Person> persons, int min, int max, int year)
        {
            Assert.Equal(year, GetYearMostPeopleAlive(persons, min, max));
        }
    }
    class TestDataLivingPeople
    {
        public static TheoryData<List<Person>, int, int,int> getLivingPeople()
        {
            var persons = new List<Person>(){
                    new Person(1905,1950),
                    new Person(1905,1905),
                    new Person(1910,1960),
                    new Person(1951,1960),
                    new Person(1905,1907),
                    new Person(1965,1980),
                    };

            var persons2 = new List<Person>(){
                    new Person(1905,1950),
                    new Person(1902,1915),
                    new Person(1910,1960),
                    new Person(1906,1960),
                    new Person(1965,1980),
                    };

            return new TheoryData<List<Person>, int, int, int>() {
                {persons, 1900, 2000,1905},
                {persons2, 1900, 2000,1910},
                };
        }
    }
}
