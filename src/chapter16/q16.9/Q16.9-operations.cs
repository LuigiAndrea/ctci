namespace Chapter16
{
    public class Q16_8Operations
    {
        public static int Multiply(int a, int b)
        {
            int res = 0;
            int sign = 1;

            if (a < 0)
            {
                sign = -1;
                a = -a;
            }

            if (b < 0)
            {
                sign = -sign;
                b = -b;
            }

            if (a > b)
            {
                int temp = b;
                b = a;
                a = temp;
            }

            for (int i = 0; i < a; i++)
            {
                res += b;
            }
            return sign * res;
        }

        public static int Subtract(int a, int b)
        {
            return 0;
        }
        public static int Divide(int a, int b)
        {
            return 0;
        }
    }
}
