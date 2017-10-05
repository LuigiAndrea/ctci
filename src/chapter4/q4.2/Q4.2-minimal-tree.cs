//Minimal Tree: Given a sorted (increasing  order) array with unique integer elements, 
//write an algorithm to create a binary search tree with minimal height. 

namespace Chapter4
{
    public static class Q4_2MinimalTree
    {
        public static TreeBinaryNode<T> MinimalTree<T>(T[] array)
        {
            return (array == null) ? null : MinimalTree(array, 0, array.Length - 1);
        }

        private static TreeBinaryNode<T> MinimalTree<T>(T[] array, int start, int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;
            return new TreeBinaryNode<T>(array[mid], MinimalTree(array, start, mid - 1), MinimalTree(array, mid + 1, end));
        }
    }

}