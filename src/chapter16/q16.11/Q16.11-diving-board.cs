using System.Collections.Generic;

namespace Chapter16
{
    public class Q16_11DivingBoard
    {
        public static List<int> GetLengthsBoard(int k, int shortPlank, int longPlank)
        {
            List<int> lengthsBoards = new List<int>();
            
            if (shortPlank == longPlank)
            {
               lengthsBoards.Add(shortPlank*k);
               return lengthsBoards;
            }

            for (int i = 0; i <= k; i++)
            {
                lengthsBoards.Add(shortPlank * i + longPlank * (k - i));
            }

            return lengthsBoards;
        }
    }
}
