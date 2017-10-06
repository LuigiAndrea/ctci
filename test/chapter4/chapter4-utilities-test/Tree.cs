using System;

using Chapter4;
using static Chapter4.Utilities;

namespace Tests.Chapter4
{
    public class Tree : IDisposable
    {
        public TreeBinaryNode<int> tbn { get; private set; }
        public TreeBinaryNode<char> charTree { get; private set; }
        public Tree()
        {
            tbn = CreateBinaryTree<TreeBinaryNode<int>,int>(new int[] { 7,2,3,5,9,23 });
            charTree = CreateBinaryTree<TreeBinaryNode<char>,char>(new char[] { 'A','B','C','D' });
        }
        
        public void Dispose()
        {
        }
    }
}
