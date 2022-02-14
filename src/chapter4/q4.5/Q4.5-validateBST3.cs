namespace Chapter4
{
    //Assume that the Binary Tree cannot have duplicate values.
    public static class Q4_5ValidateBST3
    {
        static int? lastNumber = null;
        public static bool IsBST(TreeBinaryNode<int> tree)
        {
            return IsBST(tree,null,null);
        }
        public static bool IsBST(TreeBinaryNode<int> root, int? min, int? max) =>
            (root == null) ? true
                        : (min == null || root.value > min) && (max == null || root.value < max)
                            && IsBST(root.left, min, root.value) && IsBST(root.right, root.value, max);
    }
}
