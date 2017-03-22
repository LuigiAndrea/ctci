namespace Chapter4
{
    public class TreeBinaryNode<T>{
        public T value;
        public TreeBinaryNode<T> left;
        public TreeBinaryNode<T> right;

        public TreeBinaryNode(T v){
            this.value=v;
        }

        public TreeBinaryNode(T v, TreeBinaryNode<T> left, TreeBinaryNode<T> right){
            this.value = v;
            this.left = left;
            this.right = right;
        }
    }
}