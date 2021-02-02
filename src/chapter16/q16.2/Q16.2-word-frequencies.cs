using System;
using System.Collections.Generic;

namespace Chapter16
{
    public static class Q16_2WordFrequencies
    {
        public class Book
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            public Book(string[] book)
            {
                if (book == null || book.Length == 0)
                    throw new ArgumentException("Book cannot be empty");

                //setup dictionary
                foreach (var item in book)
                {
                    var key = item.Trim().ToLower();
                    if (dic.ContainsKey(key))
                    {
                        dic[key] += 1;
                    }
                    else
                    {
                        dic.Add(key, 1);
                    }
                }
            }

            public int GetFrequencies(string word)
            {
                int count = 0;
                var key = word.Trim().ToLower();
                if (dic.ContainsKey(key))
                {
                    count = dic[key];
                }

                return count;

            }

        }
    }
}