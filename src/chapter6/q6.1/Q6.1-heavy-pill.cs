using System;

namespace Chapter6
{
    public static class Q6_1HeavyPill
    {
        private static double totalNormalWeight;
        private static double totalSpecialWeight;
        private static double diffWeight;

        public static void SetHeavyPillProblem(Pill p, int numberBottles, int heavyBottle)
        {
            diffWeight = p.SpecialWeight - p.NormalWeight;

            if (numberBottles < 2 || diffWeight == 0
            || heavyBottle > numberBottles || heavyBottle < 1 || p.SpecialWeight <= 0 || p.NormalWeight <= 0)
                throw new ArgumentException();

            int totalNumbePills = (numberBottles * (numberBottles + 1) / 2);
            totalNormalWeight = totalNumbePills * p.NormalWeight;
            // Make the heavyBottle the one with the heavy pills         
            totalSpecialWeight = totalNormalWeight + heavyBottle * diffWeight;
        }

        //Get the bottle with pills with heavier weight
        public static double GetHeavyBottle() => (diffWeight != 0)
        ? Math.Round((totalSpecialWeight - totalNormalWeight) / diffWeight, 0)
        : throw new InvalidProgramException($"Call {nameof(SetHeavyPillProblem)} first");


        public class Pill
        {
            public double NormalWeight;
            public double SpecialWeight;

            public Pill(double nw, double sw)
            {
                NormalWeight = nw;
                SpecialWeight = sw;
            }
        }
    }
}