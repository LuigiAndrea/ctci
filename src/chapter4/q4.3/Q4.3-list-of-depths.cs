using System.Collections.Generic;

namespace Chapter4
{
    public static class Q4_3ListOfDepths
    {
        public static List<LinkedList<TreeBinaryNode<T>>> getListOfDepths<T>(TreeBinaryNode<T> tree)
        {
            List<LinkedList<TreeBinaryNode<T>>> lists = new List<LinkedList<TreeBinaryNode<T>>>();
            getDepths(tree, lists, 0);
            return lists;
        }

        private static List<LinkedList<TreeBinaryNode<T>>> getDepths<T>(TreeBinaryNode<T> node, List<LinkedList<TreeBinaryNode<T>>> lists, int level)
        {
            if (node == null)
                return null;

            LinkedList<TreeBinaryNode<T>> linkedList;
            if (lists.Count.Equals(level))
            {
                linkedList = new LinkedList<TreeBinaryNode<T>>();
                lists.Add(linkedList);
            }
            else
            {
                linkedList = lists[level];
            }

            linkedList.AddLast(node);
            getDepths(node.left, lists, level + 1);
            getDepths(node.right, lists, level + 1);

            return lists;
        }
    }
}