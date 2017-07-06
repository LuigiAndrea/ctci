using System;
using System.Text;
using static System.Console;
using System.Linq;

namespace Chapter6
{
    public static class Q6_ListOfPrimes
    {
        //Generate a list of Primes using The Sieve of Eratosthenes

        public static int[] listOfPrimes(int max)
        {
            if(max<=0)
                throw new ArgumentException("Mex has to be greater than 0");

            bool[] list = sieveOfEratosthenes(max);
            int count = list.Where(x => x==true).Count();
            int[] primes = new int[count-1];

            int j = 0;
            for (int i = 1; i < list.Length; i++)
            {
                if (list[i] == true)
                {
                    primes[j] = i;
                    j++;
                }
            }

            return primes;
        }
        private static bool[] sieveOfEratosthenes(int max)
        {
            bool[] listOfBool = new bool[max + 1];
            init(listOfBool);

            int prime = 2;

            while (prime <= Math.Sqrt(max))
            {
                for (int i = prime * prime; i < listOfBool.Length; i += prime)
                {
                    listOfBool[i] = false;
                }

                prime = getNextPrime(listOfBool, prime);
            }

            return listOfBool;
        }

        private static int getNextPrime(bool[] listOfBool, int CurrentPrime)
        {
            for (int i = CurrentPrime + 1; i < listOfBool.Length; i++)
                if (listOfBool[i] == true)
                    return i;

            return CurrentPrime;
        }

        private static void init(bool[] list)
        {
            for (int i = 0; i < list.Length; i++)
                list[i] = true;
        }
    }
}