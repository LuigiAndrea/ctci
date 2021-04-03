using System.Collections.Generic;

namespace Chapter16
{
    public class Q16_10LivingPeople
    {
        public static int GetYearMostPeopleAlive(List<Person> persons, int min, int max)
        {
            SortedDictionary<int, int> dic = new SortedDictionary<int, int>();
            foreach (var p in persons)
            {
                for (int i = p.Birth; i <= p.Death; i++)
                {
                    if (dic.ContainsKey(i))
                    {
                        dic[i] += 1;
                    }
                    else
                    {
                        dic.Add(i, 1);
                    }
                }
            }

            int maxpeoplealive = 0;
            int maxyear = min;
            foreach (var year in dic)
            {
                if (year.Value > maxpeoplealive)
                {
                    maxpeoplealive = year.Value;
                    maxyear = year.Key;
                }
            }

            return maxyear;
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
