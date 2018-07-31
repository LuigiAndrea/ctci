using System;


namespace Chapter8
{
    public static class Q8_1TripleSteps
    {
        public static int TripleSteps(int n)
        {
            if (n < 0) return 0;
            if (n == 0) return 1;

            return TripleSteps(n - 1) + TripleSteps(n - 2) + TripleSteps(n - 3);
        }

        public static int TripleStepsMemo(int n, int[] memoSteps)
        {
            if (n < 0) return 0;
            if (n == 0) return 1;
            if (memoSteps[n] != 0) return memoSteps[n];

            return memoSteps[n] = TripleStepsMemo(n - 1, memoSteps)
                                + TripleStepsMemo(n - 2, memoSteps) 
                                + TripleStepsMemo(n - 3, memoSteps);
        }
    }
}