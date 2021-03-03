using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter16
{
    public class Q16_8EnglishInt
    {
        const int thousand = 1000;
        static string[] special = new string[] { "", " Thousand", " Million", " Billion" };
        static Dictionary<int, string> dic = new Dictionary<int, string>{
            {0,"Zero"},{1," One"},{2," Two"},{3," Three"},{4," Four"},{5," Five"},{6," Six"},{7," Seven"},{8," Eight"},
            {9," Nine"},{10," Ten"},{11," Eleven"},{12," Twelve"},{13," Thirteen"},{14," Fourteen"},{15," Fifteen"},
            {16," Sixteen"},{17," Seventeen"},{18," Eighteen"},{19," Nineteen"},{20," Twenty"},{30," Thirty"},{40," Fourty"},
            {50," Fifty"},{60," Sixty"},{70," Seventy"},{80," Eighty"},{90," Ninety"}
            };

        public static string GetEnglishInt(long number)
        {
            StringBuilder result = new StringBuilder();
            bool neg = false;
            if (number < 0)
            {
                neg = true;
                number = -number;
            }

            if (number == 0)
                return dic[0];

            int i = 0;
            while (number > 0)
            {
                var str = HandleTriplets((int)(number % thousand), i);
                result.Insert(0, str);
                number /= thousand;
                i++;
            }

            if (neg)
            {
                result.Insert(0, "Negative");
            }

            return result.ToString().Trim();
        }

        private static StringBuilder HandleTriplets(int n, int i)
        {
            StringBuilder str = new StringBuilder();

            if (n == 0)
                return str;

            int firstNninteen = n % 100;
            if (firstNninteen < 20 && firstNninteen > 0)
            {
                str.Insert(0, dic[(firstNninteen)]);
                n /= 100;
            }
            else
            {
                if (n % 10 > 0)
                {
                    str.Insert(0, dic[(n % 10)]);
                }

                n /= 10;
                if (n % 10 > 0)
                {
                    str.Insert(0, dic[(n % 10) * 10]);
                }
                n /= 10;
            }

            if (n % 10 > 0)
            {
                str.Insert(0, dic[(n % 10)] + " Hundred");
            }

            return str.Append(special[i]);
        }
    }
}
