using System;

using Chapter4;
using static Chapter4.Utilities;

namespace Tests.Chapter4
{
    public class Tree : IDisposable
    {
        public TreeBinaryNode<int> NumericTree { get; private set; }
        public TreeBinaryNode<char> CharTree { get; private set; }
        public TreeBinaryNode<int> ParentTree { get; private set; }
        public TreeBinaryNode<int> SearchTree { get; private set; }
        public TreeBinaryNode<int> SearchParentTree { get; private set; }

        public Tree()
        {
            NumericTree = CreateBinaryTree<TreeBinaryNode<int>, int>(new int[] { 7, 2, 3, 5, 9, 23 });
            CharTree = CreateBinaryTree<TreeBinaryNode<char>, char>(new char[] { 'A', 'B', 'C', 'D' });
            ParentTree = CreateBinaryTree<TreeBinaryParentNode<int>, int>(new int[] { 7, 2, 3, 5, 9, 23 });
            SearchTree = CreateBinarySearchTree<TreeBinaryNode<int>>(5);
            SearchParentTree = CreateBinarySearchTree<TreeBinaryParentNode<int>>(5);
        }

        public void Dispose()
        {
        }
    }
}
