namespace Chapter4
{
    //Assume that the Binary Tree cannot have duplicate values.
    public static class Q4_5ValidateBST2
    {
        static int? lastNumber = null;
        public static bool IsBST(TreeBinaryNode<int> tree)
        {
            if (tree == null)
                return true;

            if (!IsBST(tree.left) || (lastNumber != null && tree.value <= lastNumber))
                return false;

            lastNumber = tree.value;

            return IsBST(tree.right);
        }
    }
}