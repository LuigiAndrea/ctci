namespace Chapter1
{
    public class Q1_1IsUnique
    {
        public static bool isUnique(string a)
        {
            //Using Ascii codes
            if (a.Length > 256)
            {
                return false;
            }

            bool[] values = new bool[256];

            foreach (char c in a)
            {
                int ind = c;
                if (values[ind])
                    return false;

                values[ind] = true;
            }

            return true;
        }

        // Implement an algorithm to determine if a string has all unique characters without using additional DS
        public static bool isUnique2(string s)
        {
            int size = s.Length;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[i].Equals(s[j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool isUnique3(string s)
        {
            int check = 0;
            foreach (char c in s)
            {
                int val = 1 << c;
                if ((check & val) > 0)
                    return false;

                check |= val;
            }
            return true;
        }
    }
}