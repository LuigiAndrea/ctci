using System;
using System.Linq;

namespace Chapter6
{
    public static class C6_ListOfPrimes
    {
        //Generate full list of primes (<= max) using The Sieve of Eratosthenes
        public static int[] GetListOfPrimes(int max)
        {
            if (max <= 0)
                throw new ArgumentException("Max has to be greater than 0");

            bool[] list = sieveOfEratosthenes(max);
            int count = list.Where(x => x == false).Count();
            int[] primes = new int[count - 1]; //we do not consider zero position

            for (int i = 1, j = 0; i < list.Length; i++)
            {
                if (!list[i]) 
                    primes[j++] = i;          
            }

            return primes;
        }
        private static bool[] sieveOfEratosthenes(int max)
        {
            bool[] notPrimes = new bool[max + 1];
            int prime = 2;

            while (prime * prime <= max) //Same as: prime <= Math.Sqrt(max)
            {
                for (int i = prime * prime; i <= max; i += prime)
                {
                    notPrimes[i] = true;
                }

                prime = getNextPrime(notPrimes, prime);
            }

            return notPrimes;
        }

        private static int getNextPrime(bool[] notPrimes, int CurrentPrime)
        {
            int nextPrime = -1;

            for (int i = CurrentPrime + 1; i < notPrimes.Length; i++)
            {
                if (!notPrimes[i]){
                    nextPrime = i; 
                    break;                    
                } 
            }

            return nextPrime;
        }      
    }
}
