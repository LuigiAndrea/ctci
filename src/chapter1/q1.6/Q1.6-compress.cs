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