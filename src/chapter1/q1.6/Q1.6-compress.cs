// Summary:
// String Compression: Implement a method to perform basic string compression using the counts of repeated characters. 
// For example, the string aabcccccaaa would become a2blc5a3. 
// If the "compressed" string would not become smaller than the original string, your method should return the original string. 
// You can assume the string has only uppercase and lowercase letters (a - z). 

using System.Text;

namespace Chapter1
{
    public class Q1_6Compress
    {
        public static string compress(string str)
        {
            StringBuilder sb = new StringBuilder();
            int consecutive = 1;
            int size = str.Length;
            for (int i = 0; i < size; i++)
            {
                if (i + 1 < size && str[i].Equals(str[i + 1]))
                {
                    consecutive++;
                }
                else
                {
                    sb.Append(str[i]);
                    sb.Append(consecutive);
                    consecutive = 1;
                }
            }

            string strBuilt = sb.ToString();
            return strBuilt.Length < size ? strBuilt : str;
        }
    }
}