using System;

namespace Chapter8
{
    public static class Q8_3MagicIndex
    {
        public static int findMagicIndex(int[] magicArray)
        {
            if(magicArray == null || magicArray.Length == 0)
                throw new ArgumentNullException(paramName: $"{nameof(magicArray)} must not be null or empty");
            int magicIndex = findIndex(0, magicArray.Length-1, magicArray);
            return magicIndex;
        }

        private static int findIndex(int leftIndex, int rightIndex, int[] magicArray)
        {
            if (leftIndex > rightIndex)
                return -1;

            int magicIndex = -1;
            int position = (leftIndex + rightIndex) /2;
            
            if(magicArray[position] == position)
                magicIndex = position;              
            else if(magicArray[position] > position)
                magicIndex = findIndex(leftIndex, position-1,magicArray);
            else if(magicArray[position] < position)
                magicIndex = findIndex(position+1, rightIndex,magicArray);
            
            return magicIndex;

        }
    }
}
