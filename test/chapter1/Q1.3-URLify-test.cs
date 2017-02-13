using System;
using static Chapter1.Q1_3URLify;
using Xunit;

namespace Tests.Chapter1
{
    public class Q1_3
    {
        [FactAttribute]
        public void TestURLify()
        {
            const int size = 4;
            string[] s = new String[size] { " Luigi Andrea ", "   ", "", "Let's go there" };
            string[] r = new String[size] { "%20Luigi%20Andrea%20", "%20%20%20", "", "Let's%20go%20there" };

            for (int i = 0; i < size; i++)
            {
                Assert.True(URLify(s[i]).Equals(r[i]));
            }
        }
    }
    }