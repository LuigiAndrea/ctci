using System;


namespace Chapter8
{
    public static class Q8_1TripleSteps
    {
        public static int CountSteps(int staircaseSteps, bool memo)
        {
            if (staircaseSteps <= 0)
                throw new ArgumentException("The Staircase should have at least one step");
            else
                return (memo) ? tripleStepsMemo(staircaseSteps, new int[staircaseSteps + 1])
                              : tripleSteps(staircaseSteps);
        }
        private static int tripleSteps(int n)
        {
            if (n < 0) return 0;
            if (n == 0) return 1;

            return tripleSteps(n - 1) + tripleSteps(n - 2) + tripleSteps(n - 3);
        }

        private static int tripleStepsMemo(int n, int[] memoSteps)
        {
            if (n < 0) return 0;
            if (n == 0) return 1;
            if (memoSteps[n] != 0) return memoSteps[n];

            return memoSteps[n] = tripleStepsMemo(n - 1, memoSteps)
                                + tripleStepsMemo(n - 2, memoSteps)
                                + tripleStepsMemo(n - 3, memoSteps);
        }
    }
}