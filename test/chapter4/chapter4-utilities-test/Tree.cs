using System;

using Chapter4;

namespace Tests.Chapter4
{
    public class Tree : IDisposable
    {
        public TreeBinaryNode<int> tbn { get; private set; }
        public TreeBinaryNode<char> charTree { get; private set; }
        public Tree()
        {
            createTree();
            createCharTree();
        }

        private void createTree()
        {
            TreeBinaryNode<int> tl = new TreeBinaryNode<int>(7);
            TreeBinaryNode<int> tr = new TreeBinaryNode<int>(9);
            tbn = new TreeBinaryNode<int>(3, tl, tr);
            tl.left = new TreeBinaryNode<int>(2);
            tl.right = new TreeBinaryNode<int>(5);
            tr.right = new TreeBinaryNode<int>(23);
        }

        private void createCharTree()
        {
            TreeBinaryNode<char> tl = new TreeBinaryNode<char>('s');
            TreeBinaryNode<char> tr = new TreeBinaryNode<char>('A');
            charTree = new TreeBinaryNode<char>('R', tl, tr);
            tl.left = new TreeBinaryNode<char>('f');
        }

        public void Dispose()
        {
        }
    }
}