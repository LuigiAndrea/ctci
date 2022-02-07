using System.Collections.Generic;
using System.Linq;
using static Chapter4.Utilities;

namespace Chapter4
{
    //Assume that the Binary Tree cannot have duplicate values.
    public static class Q4_5ValidateBST
    {
        public static bool IsBST(TreeBinaryNode<int> tree)
        {
            Traversal<int> t = new Traversal<int>(TypeTraversal.inOrder, tree);
            List<int> inOrderList = t.getTraversalList();

            return inOrderList.Zip(inOrderList.Skip(1)).All(l=> l.First<l.Second);           
        }
    }
}
