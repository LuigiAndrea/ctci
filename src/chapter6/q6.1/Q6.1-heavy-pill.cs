using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Chapter6
{
    public static class Q6_1HeavyPill
    {
        private static double totalNormalWeight;
        private static double totalSpecialWeight;
        private static double diffWeight;
        //  private static ((double normalWeight, double specialWeight) pill, int count) bottle;
        //  private static List<Bottle> bottles;

        public static void SetHeavyPillProblem(Pill p, int numberBottles, int heavyBottle)
        {
            diffWeight = p.SpecialWeight - p.NormalWeight;

            if (numberBottles < 2 || diffWeight == 0 || heavyBottle > numberBottles || heavyBottle < 1)
                throw new ArgumentException();

            int totalNumbePills = (numberBottles * (numberBottles + 1) / 2);
            totalNormalWeight = totalNumbePills * p.NormalWeight;
            totalSpecialWeight = totalNormalWeight + heavyBottle * diffWeight; // make the heavyBottle the one with the heavy pills         
        }

        //Get the bottle with heavier weight
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