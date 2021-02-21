namespace Chapter16
{
    public class Q16_7NumberMax
    {
        public static int GetMaxNumber(int a, int b)
        {  
            int signa = signN(a), signb = signN(b), signc = signN(a - b); //Determine the sign
            int diffSign = signa ^ signb; //1 if they have different sign
            int k = diffSign * signa + (diffSign ^ 1) * signc;
            return k * a + (k ^ 1) * b;
        }

        /// <summary>
        /// Return 1 when +, 0 otherwise
        ///</summary>
        private static int signN(int n) =>((n>>31)&1)^1;        
    }
}
