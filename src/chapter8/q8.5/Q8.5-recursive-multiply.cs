using System;
using System.Collections.Generic;
using System.Collections;

namespace Chapter8
{
    public static class Q8_5RecursiveMultiply
    {
        public static int multiply(int a, int b)
        {
            int smallerNumber = (a > b) ? b : a;
            int biggerNumber = (a > b) ? a : b;

            if (smallerNumber < 0)           
                throw new ArgumentOutOfRangeException(paramName: $"{nameof(multiply)} - the values to calculate the product must be positive");
            

            return calculate_product(smallerNumber, biggerNumber, 0);
        }

        private static int calculate_product(int smallerNumber, int biggerNumber, int result) =>
           (smallerNumber == 0) ? result : calculate_product(--smallerNumber, biggerNumber, result += biggerNumber);

        public static int multiply_opt(int a, int b)
        {
            int smallerNumber = (a > b) ? b : a;
            int biggerNumber = (a > b) ? a : b;

            if (smallerNumber < 0)
                throw new ArgumentOutOfRangeException(paramName: $"{nameof(multiply)} - the values to calculate the product must be positive");
            
            return (smallerNumber == 0) ? smallerNumber : calculate_product_opt(smallerNumber, biggerNumber, 0);
        }

        private static int calculate_product_opt(int smallerNumber, int biggerNumber, int result)
        {
            if (smallerNumber == 1)
                return biggerNumber;
            
            bool odd = (smallerNumber % 2 != 0) ? true : false;

            result = calculate_product_opt(smallerNumber >>= 1, biggerNumber, result) << 1;       
            
            return (odd) ? result += biggerNumber : result;
        }
    }
}
