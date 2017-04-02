using System.Collections.Generic;

namespace Chapter4
{
    public static class Q4_3ListOfDepthsIterative
    {
        public static List<LinkedList<TreeBinaryNode<T>>> getListOfDepths<T>(TreeBinaryNode<T> node)
        {
            List<LinkedList<TreeBinaryNode<T>>> list = new List<LinkedList<TreeBinaryNode<T>>>();
            LinkedList<TreeBinaryNode<T>> parent = new LinkedList<TreeBinaryNode<T>>();

            if (node != null)
            {
                parent.AddLast(node);
                list.Add(parent);
            }

            for (int i = 0; i < list.Count; i++)
            {
                parent = list[i];
                LinkedList<TreeBinaryNode<T>> children = new LinkedList<TreeBinaryNode<T>>();

                foreach (var el in parent)
                {
                    if (el.left != null)
                        children.AddLast(el.left);
                    if (el.right != null)
                        children.AddLast(el.right);
                }

                if (children.Count > 0)
                    list.Add(children);
            }
            return list;
        }
    }
}