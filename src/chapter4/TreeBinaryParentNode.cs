namespace Chapter4
{
    public class TreeBinaryParentNode<T> : TreeBinaryNode<T>
    {
        public TreeBinaryParentNode<T> parent;
        public TreeBinaryParentNode(T v) : base(v)
        {
            this.value = v;
        }

        public TreeBinaryParentNode(T v, TreeBinaryParentNode<T> left, TreeBinaryParentNode<T> right, TreeBinaryParentNode<T> parent) : base(v, left, right)
        {
            this.value = v;
            this.left = left;
            this.right = right;
            this.parent = parent;
        }
    }
}