using System;
using System.Text;
using static System.Console;

namespace Chapter6
{
    public static class Q6_1HeavyPill
    {
        private static double totalNormalWeight;
        private static double diffWeight;
        private static ((double normalWeight, double specialWeight) pill, int count) bottle;

        public static void init(((double n, double s) p, int count) b)
        {
            bottle = b;
            diffWeight = bottle.pill.specialWeight - bottle.pill.normalWeight;

            if (b.count < 2 & diffWeight==0)
                throw new ArgumentException();        
            
            totalNormalWeight = (bottle.count * (bottle.count + 1) / 2) * bottle.pill.normalWeight;
            WriteLine($"The bottle # {getBottle()} has the {(diffWeight>0 ? "heavy" : "light")} pills");
        }
        public static double getBottle()
        {
            return Math.Round((scale() - totalNormalWeight) / diffWeight, 0);
        }

        private static double scale()
        {
            Random r = new Random();
            int n = r.Next(1, bottle.count);
            WriteLine($"Random bottle chosen: {n}");
            return totalNormalWeight + n * diffWeight;
        }
    }
}