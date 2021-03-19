namespace Chapter16
{
    public class Q16_1NumberSwapper
    {
        public static void SwapNumber(ref int a,ref int b)
        {
           a-=b;
           b+=a;
           a=b-a;
        }

        public static void SwapNumberXor(ref int a, ref int b){
            a^=b;
            b^=a;
            a^=b;
        }
    }
}