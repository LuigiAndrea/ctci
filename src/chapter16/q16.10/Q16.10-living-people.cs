using System.Collections.Generic;

namespace Chapter16
{
    public class Q16_10LivingPeople
    {
        public static int GetYearMostPeopleAlive(List<Person> persons, int min, int max)
        {
            return -1;
        }
    }

    public class Person
    {
        public int Birth { get; set; }
        public int Death { get; set; }

        public Person(int b, int d)
        {
            Birth = b;
            Death = d;
        }
    }
}
