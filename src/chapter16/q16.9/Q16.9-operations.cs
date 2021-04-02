using System;

namespace Chapter16
{
    public class Q16_9Operations
    {
        public static int Multiply(int a, int b)
        {
            int res = 0;

            //Determine final sign
            int sign = (getSign(a) != getSign(b)) ? -1 : 1;
            makePositive(ref a, ref b);
            swapInOrder(ref a, ref b);

            for (int i = 0; i < a; i++)
            {
                res += b;
            }

            return (sign == -1) ? changeSign(res) : res;
        }

        public static int Divide(int a, int b)
        {
            int res = 0;

            if (b == 0)
            {
                throw new ArgumentException("Please provide a number greater than 0 for the second parameter");
            }

            //Determine final sign
            int sign = (getSign(a) != getSign(b)) ? -1 : 1;

            makePositive(ref a, ref b);
            int cond = b;
            while (a >= cond)
            {
                cond += b;
                res++;
            }

            return (sign == -1) ? changeSign(res) : res;
        }

        public static int Subtract(int a, int b) => a + changeSign(b);


        //Return 1 if the sign is positive +, -1 otherwise -
        private static int getSign(int n) => (n < 0) ? -1 : 1;


        //change sign of n
        private static int changeSign(int n)
        {
            int newValue = 0;
            int add = (n < 0) ? 1 : -1;
            int jump = add;
            while (n != 0)
            {
                if (n + jump < 0)
                {
                    jump = add;
                }
                n += jump;
                newValue += jump;
            }
            return newValue;
        }

        //Make a and b positive numbers
        private static void makePositive(ref int a, ref int b)
        {
            a = (a < 0) ? changeSign(a) : a;
            b = (b < 0) ? changeSign(b) : b;
        }

        //swap a and b in order to have a < b 
        private static void swapInOrder(ref int a, ref int b)
        {
            if (a > b)
            {
                int temp = b;
                b = a;
                a = temp;
            }
        }
    }
}
