namespace Chapter4
{
    //Assume that the Binary Tree cannot have duplicate values.
    public static class Q4_5ValidateBST2
    {
        static int? lastNumber = null;
        public static bool isBST(TreeBinaryNode<int> tree)
        {
            if (tree == null)
                return true;

            if (!isBST(tree.left)) return false;

            if (lastNumber !=null && tree.value <= lastNumber)
                return false;
            lastNumber = tree.value;

            if (!isBST(tree.right)) return false;
            return true;
        }
    }
}