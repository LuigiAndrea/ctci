using System;

namespace Chapter8
{
    public static class Q8_3MagicIndex
    {
        public static int findMagicIndex(int[] magicArray)
        {
            if (magicArray == null || magicArray.Length == 0)
                throw new ArgumentNullException(paramName: $"{nameof(magicArray)} must not be null or empty");
            int magicIndex = findIndex(0, magicArray.Length - 1, magicArray);
            return magicIndex;
        }

        private static int findIndex(int leftIndex, int rightIndex, int[] magicArray)
        {
            if (leftIndex > rightIndex)
                return -1;

            int magicIndex = -1;
            int position = (leftIndex + rightIndex) / 2;

            if (magicArray[position] == position)
                magicIndex = position;
            else if (magicArray[position] > position)
                magicIndex = findIndex(leftIndex, position - 1, magicArray);
            else if (magicArray[position] < position)
                magicIndex = findIndex(position + 1, rightIndex, magicArray);

            return magicIndex;

        }

        public static int findMagicIndexNotDistinctValues(int[] magicArray)
        {
            if (magicArray == null || magicArray.Length == 0)
                throw new ArgumentNullException(paramName: $"{nameof(magicArray)} must not be null or empty");
            int magicIndex = findIndexNotDistinct(0, magicArray.Length - 1, magicArray);
            return magicIndex;
        }

        private static int findIndexNotDistinct(int leftIndex, int rightIndex, int[] magicArray)
        {
            int magicIndex = -1;

            if (leftIndex > rightIndex)
                return magicIndex;

            int magicLength = magicArray.Length;
            int pos = (leftIndex + rightIndex) / 2;
            int magicValue = magicArray[pos];

            if (magicValue == pos)
                return magicValue;

            int newRightIndex = Math.Min(magicValue, pos - 1);
            if (newRightIndex >= 0)
                magicIndex = findIndexNotDistinct(leftIndex, newRightIndex, magicArray);

            if (magicIndex == -1)
            {
                int newLeftIndex = Math.Max(magicValue, pos + 1);

                if (newLeftIndex < magicLength)
                    return findIndexNotDistinct(newLeftIndex, rightIndex, magicArray);
            }

            return magicIndex;
        }
    }
}
