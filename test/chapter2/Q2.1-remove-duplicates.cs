using static Chapter2.Q2_1RemoveDuplicates;
using static Chapter2.Q2_1RemoveDuplicates2;
using LinkedListNode = Chapter2.LinkedListNode;
using static Tests.Chapter2.Utilities;
using static Chapter2.Q2_1RemoveDuplicatesFromScratch;
using System.Collections.Generic;
using Xunit;

namespace Tests.Chapter2
{
    public class Q2_1
    {

        [TheoryAttribute]
        [MemberData("getLinkedList", MemberType = typeof(TestDataremoveDuplicates))]
        public static void removeDuplicatesTest(LinkedList<int> list)
        {
            Assert.True(list.Count.Equals(5));
            removeDuplicates(list);
            Assert.True(list.Count.Equals(2));
            Assert.True(list.First.Value.Equals(5));
            Assert.True(list.Last.Value.Equals(15));
        }

        [TheoryAttribute]
        [MemberData("getLinkedList2", MemberType = typeof(TestDataremoveDuplicates))]
        public static void removeDuplicatesTestNoChange(LinkedList<int> list)
        {
            Assert.True(list.Count.Equals(0) || list.Count.Equals(3));
            removeDuplicates(list);
            Assert.True(list.Count.Equals(0) || list.Count.Equals(3));
        }

        [TheoryAttribute]
        [MemberData("getLinkedList", MemberType = typeof(TestDataremoveDuplicates))]
        public static void removeDuplicatesTest2(LinkedList<int> list)
        {
            Assert.True(list.Count.Equals(5));
            removeDuplicatesNoBuffer(list);
            Assert.True(list.Count.Equals(2));
            Assert.True(list.First.Value.Equals(5));
            Assert.True(list.Last.Value.Equals(15));
        }

        [TheoryAttribute]
        [MemberData("getLinkedList2", MemberType = typeof(TestDataremoveDuplicates))]
        public static void removeDuplicatesTestNoChange2(LinkedList<int> list)
        {
            Assert.True(list.Count.Equals(0) || list.Count.Equals(3));
            removeDuplicatesNoBuffer(list);
            Assert.True(list.Count.Equals(0) || list.Count.Equals(3));
        }

        [TheoryAttribute]
        [MemberData("getLinkedList", MemberType = typeof(TestDataremoveDuplicates))]
        public static void removeDuplicatesTest3(LinkedList<int> list)
        {
            Assert.True(list.Count.Equals(5));
            removeDuplicatesNoBuffer2(list);
            Assert.True(list.Count.Equals(2));
            Assert.True(list.First.Value.Equals(5));
            Assert.True(list.Last.Value.Equals(15));
        }

        [TheoryAttribute]
        [MemberData("getLinkedList2", MemberType = typeof(TestDataremoveDuplicates))]
        public static void removeDuplicatesTestNoChange3(LinkedList<int> list)
        {
            Assert.True(list.Count.Equals(0) || list.Count.Equals(3));
            removeDuplicatesNoBuffer2(list);
            Assert.True(list.Count.Equals(0) || list.Count.Equals(3));
        }

        [TheoryAttribute]
        [MemberData("getLinkedList", MemberType = typeof(TestDataRemoveDuplicatesFromSratch))]
        public static void removeDuplicatesScratchTest(LinkedListNode node)
        {
            removeDuplicates(node);
            Assert.True(node.data.Equals(5) && node.next.data.Equals(15));
            LinkedListNode last = node.next;
            Assert.True(last.next == null);
        }

        [TheoryAttribute]
        [MemberData("getLinkedList2", MemberType = typeof(TestDataRemoveDuplicatesFromSratch))]
        public static void removeDuplicatesScratchTestNoChange(LinkedListNode node)
        {
            Assert.True(node.data.Equals(1) && node.next.data.Equals(2) && node.next.next.data.Equals(3));
            removeDuplicates(node);
            Assert.True(node.data.Equals(1) && node.next.data.Equals(2) && node.next.next.data.Equals(3));
            LinkedListNode last = node.next.next;
            Assert.True(last.next == null);
        }

        [TheoryAttribute]
        [MemberData("getLinkedList3", MemberType = typeof(TestDataRemoveDuplicatesFromSratch))]
        public static void removeDuplicatesScratchTestNoChangeNull(LinkedListNode node)
        {
            Assert.True(node == null);
            removeDuplicates(node);
            Assert.True(node == null);
        }

        [TheoryAttribute]
        [MemberData("getLinkedList", MemberType = typeof(TestDataRemoveDuplicatesFromSratch))]
        public static void removeDuplicatesScratchTest2(LinkedListNode node)
        {
            removeDuplicatesNoBuffer(node);
            Assert.True(node.data.Equals(5) && node.next.data.Equals(15));
            LinkedListNode last = node.next;
            Assert.True(last.next == null);
        }

        [TheoryAttribute]
        [MemberData("getLinkedList2", MemberType = typeof(TestDataRemoveDuplicatesFromSratch))]
        public static void removeDuplicatesScratchTestNoChange2(LinkedListNode node)
        {
            Assert.True(node.data.Equals(1) && node.next.data.Equals(2) && node.next.next.data.Equals(3));
            removeDuplicatesNoBuffer(node);
            Assert.True(node.data.Equals(1) && node.next.data.Equals(2) && node.next.next.data.Equals(3));
            LinkedListNode last = node.next.next;
            Assert.True(last.next == null);
        }

        [TheoryAttribute]
        [MemberData("getLinkedList3", MemberType = typeof(TestDataRemoveDuplicatesFromSratch))]
        public static void removeDuplicatesScratchTestNoChangeNull2(LinkedListNode node)
        {
            Assert.True(node == null);
            removeDuplicatesNoBuffer(node);
            Assert.True(node == null);
        }
    }

    class TestDataremoveDuplicates
    {
        public static TheoryData<LinkedList<int>> getLinkedList()
        {
            LinkedList<int> ll = new LinkedList<int>();
            ll.AddLast(5);
            ll.AddLast(15);
            ll.AddLast(5);
            ll.AddLast(15);
            ll.AddLast(5);

            return new TheoryData<LinkedList<int>>() { ll };
        }

        public static TheoryData<LinkedList<int>> getLinkedList2()
        {
            LinkedList<int> ll = new LinkedList<int>();
            LinkedList<int> ll2 = new LinkedList<int>();
            for (int i = 0; i < 3; i++)
                ll2.AddLast(i);

            return new TheoryData<LinkedList<int>>() { ll, ll2 };
        }
    }

    class TestDataRemoveDuplicatesFromSratch
    {
        public static TheoryData<LinkedListNode> getLinkedList()
        {
            int[] values = { 5, 15, 5, 15, 5 };
            LinkedListNode node = buildLinkedListNodeFromArray(values);

            return new TheoryData<LinkedListNode>() { node };
        }

        public static TheoryData<LinkedListNode> getLinkedList2()
        {
            int[] values = { 1, 2, 3 };
            LinkedListNode node = buildLinkedListNodeFromArray(values);

            return new TheoryData<LinkedListNode>() { node };
        }

        public static TheoryData<LinkedListNode> getLinkedList3()
        {
            LinkedListNode node = buildLinkedListNodeFromArray(new int[] { });
            return new TheoryData<LinkedListNode>() { node };
        }
    }
}