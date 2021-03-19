using System;

namespace Chapter16
{
    public class Q16_8Operations
    {
        public static int Multiply(int a, int b)
        {
            int res = 0;

            int sign = getSign(a);
            sign *= getSign(b);

            makePositive(ref a, ref b);
            swap(ref a, ref b);

            for (int i = 0; i < a; i++)
            {
                res += b;
            }
            return sign * res;
        }

        public static int Divide(int a, int b)
        {
            int res = 0;

            if(b==0){
                  throw new ArgumentException("Please provide a number greater than 0 for the second parameter");
            }

            int sign = getSign(a);
            sign *= getSign(b);

            makePositive(ref a, ref b);
            int cond=b;
            while(a >= cond)
            {
                cond+=b;
                res++;
            }

            return sign*res;
        }

        public static int Subtract(int a, int b)
        {
            return 0;
        }

        //Return 1 if the sign is positive +, -1 otherwise -
        private static int getSign(int n) => (n < 0) ? -1 : 1;

        //Make a and b positive numbers
        private static void makePositive(ref int a, ref int b)
        {
            a = (a < 0) ? -a : a;
            b = (b < 0) ? -b : b;
        }

        //swap a and b in order to have a < b 
        private static void swap(ref int a, ref int b){
            if (a > b)
            {
                int temp = b;
                b = a;
                a = temp;
            }
        }

    }
}
