using System;
using System.Collections.Generic;
using System.Collections;

namespace Chapter8
{
    public static class Q8_5RecursiveMultiply
    {
        public static int multiply(int a, int b)
        {
            int smallerNumber = (a>b) ? b : a;
            int biggerNumber = (a>b) ? a : b;
            int baseCase = -1;

            if (a < 0 || b < 0)
                throw new ArgumentOutOfRangeException(paramName: $"{nameof(multiply)} - the values to calculate the product must be positive");
            else if (a == 0 || b == 0)
                baseCase = 0;
            else if (a == 1)
                baseCase = b;
            else if (b == 1)
                baseCase = a;

            return (baseCase != -1) ? baseCase : calculate_product(a, b, 0);
        }

        private static int calculate_product(int smallerNumber, int biggerNumber, int result)
        {
            if (smallerNumber == 0)
                return result;

            result += biggerNumber;
            return calculate_product(biggerNumber, --smallerNumber, result);

        }
    }
}
