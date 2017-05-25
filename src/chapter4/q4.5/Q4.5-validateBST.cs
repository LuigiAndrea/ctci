using System.Collections.Generic;

using static Chapter4.Utilities;

namespace Chapter4
{
    //Assume that the Binary Tree cannot have duplicate values.
    public static class Q4_5ValidateBST
    {
        public static bool isBST(TreeBinaryNode<int> tree)
        {
            Traversal<int> t = new Traversal<int>(TypeTraversal.inOrder, tree);
            List<int> inOrderList = t.getTraversalList();

            for (int i = 0; i < inOrderList.Count - 1; i++)
            {
                if (inOrderList[i + 1] <= inOrderList[i])
                    return false;
            }

            return true;
        }
    }
}