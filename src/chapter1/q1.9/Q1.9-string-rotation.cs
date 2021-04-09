namespace Chapter1
{
    public class Q1_9StringRotation
    {
        public static bool IsStringRotation(string str1, string str2) =>
        (string.IsNullOrEmpty(str1)
        || string.IsNullOrEmpty(str2)
        || str1.Length != str2.Length) ? false : isSubstring(str2, str1 + str1);

        private static bool isSubstring(string str1, string str2) => str2.IndexOf(str1) != -1;
    }
}
