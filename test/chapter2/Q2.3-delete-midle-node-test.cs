using Singly = Chapter2.SinglyLinkedListNode;
using Xunit;
using static Chapter2.Utilities;
using static Chapter2.Q2_3DeleteMiddleNode;
using System;

namespace Tests.Chapter2
{
    public class Q2_3
    {
        [TheoryAttribute]
        [MemberData("getMiddleNode", MemberType = typeof(TestDataMiddleNode))]
        public static void deleteMiddleNodeTest(Singly middleNode)
        {
            Console.WriteLine(middleNode.data);
            Singly newNextNode = middleNode.next.next;
            Assert.True(middleNode.data.Equals(9));
            bool result = DeleteMiddleNode(middleNode);
            Assert.True(result);
            Assert.True(middleNode.next == newNextNode);
            Assert.True(middleNode.data.Equals(-4));
        }

        [TheoryAttribute]
        [MemberData("getMiddleNode2", MemberType = typeof(TestDataMiddleNode))]
        public static void deleteMiddleNodeTest2(Singly middleNode)
        {
            bool result = DeleteMiddleNode(middleNode);
            Assert.False(result);
        }
    }

    class TestDataMiddleNode
    {
        public static TheoryData<Singly> getMiddleNode()
        {
            int[] values = { 11, 5, 15, 5, 7, 9, -4 };
            Singly node = buildLinkedListNodeFromArray<Singly>(values);

            while (node.data != 9)
            {
                node = node.next;
            }

            return new TheoryData<Singly>() { node };
        }

        public static TheoryData<Singly> getMiddleNode2()
        {
            int[] values = { 11, 5, 15, 5, 7, 9, -4 };
            Singly node = buildLinkedListNodeFromArray<Singly>(values);
            Singly tail = node;
            while (tail.data != -4)
            {
                tail = tail.next;
            }

            return new TheoryData<Singly>() { tail, null };
        }
    }
}