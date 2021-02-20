namespace Chapter16
{
    public class Q16_7NumberMax
    {
        public static int GetMaxNumber(int a, int b) => ((a - b) & 0x8000) == 0 ? a : b;       
    }
}
