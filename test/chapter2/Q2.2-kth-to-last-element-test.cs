using Singly = Chapter2.SinglyLinkedListNode;
using Xunit;
using static Chapter2.Q2_2KthToLastElement;
using static Chapter2.Q2_2KthToLastElementRecursive.KThLastEleRec;
using static Chapter2.Q2_2KthToLastElementRecursive;
using static Chapter2.Utilities;

namespace Tests.Chapter2
{
    public class Q2_2
    {
        [TheoryAttribute]
        [MemberData("getLinkedList", MemberType = typeof(TestDataKLastElement))]
        public static void KLastElementTest(Singly head, int k)
        {
            Singly node = KLastElement(head, k);
            Assert.True(node.data.Equals(55));
            Singly node2 = KLastElementTwoPointers(head, k);
            Assert.True(node2.data.Equals(55));
        }
        [TheoryAttribute]
        [MemberData("getLinkedList2", MemberType = typeof(TestDataKLastElement))]
        public static void KLastElementTest2(Singly head, int k)
        {
            Singly node = KLastElement(head, k);
            Assert.True(node.data.Equals(11));
            Singly node2 = KLastElementTwoPointers(head, k);
            Assert.True(node2.data.Equals(11));
        }

        [TheoryAttribute]
        [MemberData("getLinkedList3", MemberType = typeof(TestDataKLastElement))]
        public static void KLastElementTest3(Singly head, int k)
        {
            Singly node = KLastElement(head, k);
            Assert.True(node == null);
            Singly node2 = KLastElementTwoPointers(head, k);
            Assert.True(node2 == null);
        }

        [TheoryAttribute]
        [MemberData("getLinkedList", MemberType = typeof(TestDataKLastElement))]
        public static void KLastElementRecursiveTest(Singly head, int k)
        {
            Singly node = KLastElementRec(head, k);
            Assert.True(node.data.Equals(55));
            node = KLastElementRec2(head, k);
            Assert.True(node.data.Equals(55));
        }

        [TheoryAttribute]
        [MemberData("getLinkedList2", MemberType = typeof(TestDataKLastElement))]
        public static void KLastElementRecursiveTest2(Singly head, int k)
        {
            Singly node = KLastElementRec(head, k);
            Assert.True(node.data.Equals(11));
            node = KLastElementRec2(head, k);
            Assert.True(node.data.Equals(11));
        }

        [TheoryAttribute]
        [MemberData("getLinkedList3", MemberType = typeof(TestDataKLastElement))]
        public static void KLastElementRecursiveTest3(Singly head, int k)
        {
            Singly node = KLastElementRec(head, k);
            Assert.True(node == null);
            node = KLastElementRec2(head, k);
            Assert.True(node == null);
        }
    }

    class TestDataKLastElement
    {
        static int[] values = { 11, 5, 15, 5, 7, 55 };
        static Singly node = buildLinkedListNodeFromArray<Singly>(values);

        public static TheoryData<Singly, int> getLinkedList()
        {
            return new TheoryData<Singly, int>() { { node, 1 } };
        }

        public static TheoryData<Singly, int> getLinkedList2()
        {
            return new TheoryData<Singly, int>() { { node, 6 } };
        }

        public static TheoryData<Singly, int> getLinkedList3()
        {
            return new TheoryData<Singly, int>() { { node, 13 }, { node, 0 } };
        }
    }
}