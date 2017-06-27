using System.Text;

namespace Chapter5
{
    public static class Q5_2BinaryToString
    {
        private static readonly string Err = "Error";
        
        public static string printBinary(double num)
        {
            StringBuilder res = new StringBuilder();
            if (num >= 1 || num <= 0)
                return Err;

            res.Append(".");

            while (num > 0)
            {
                if (res.Length > 32)
                    return Err;

                double shiftRight = 2 * num;
                if (shiftRight >= 1)
                {
                    res.Append(1);
                    num = shiftRight - 1;
                }
                else
                {
                    res.Append(0);
                    num = shiftRight;
                }
            }

            return res.ToString();
        }

        public static string printBinary2(double num)
        {
            StringBuilder res = new StringBuilder();
            if (num >= 1 || num <= 0)
                return Err;
            res.Append(".");

            double fraction = .5;

            while (num > 0)
            {
                if (res.Length > 32)
                    return Err;

                if (num >= fraction){
                    res.Append(1);
                    num -= fraction;
                }
                else
                    res.Append(0);

                fraction /= 2;
            }

            return res.ToString();
        }
    }
}