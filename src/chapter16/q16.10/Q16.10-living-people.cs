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

        public enum TypeYear { birth, death }
        public static int GetYearMostPeopleAliveOptimal(List<Person> persons, int min, int max)
        {
            int maxpeoplealive = 0, currentpeoplealive = 0;
            int maxyear = min;
            List<int> births = getYears(persons, TypeYear.birth);
            List<int> deaths = getYears(persons, TypeYear.death);

            for (int i = 0, j = 0; i < births.Count && j < deaths.Count;)
            {
                if (births[i] <= deaths[j])
                {
                    currentpeoplealive++;
                    if (currentpeoplealive > maxpeoplealive)
                    {
                        maxpeoplealive = currentpeoplealive;
                        maxyear = births[i];
                    }
                    i++;
                }
                else
                {
                    currentpeoplealive--;
                    j++;
                }
            }

            return maxyear;
        }

        public static List<int> getYears(List<Person> persons, TypeYear type)
        {
            var l = new List<int>();

            foreach (var p in persons)
            {
                if (type == TypeYear.birth)
                {
                    l.Add(p.Birth);
                }
                else
                {
                    l.Add(p.Death);
                }
            }

            l.Sort((x, y) => x.CompareTo(y));
            return l;
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
