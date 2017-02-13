using static Chapter2.Q2_1RemoveDuplicates;
using static Chapter2.Q2_1RemoveDuplicates2;
using System.Collections.Generic;
using Xunit;

namespace Tests.Chapter2
{
    public class Q2_1
    {

        [TheoryAttribute]
        [MemberData("geLinkedList", MemberType = typeof(TestDataremoveDuplicates))]
        public static void removeDuplicatesTest(LinkedList<int> list)
        {
            Assert.True(list.Count.Equals(5));
            removeDuplicates(list);
            Assert.True(list.Count.Equals(2));
            Assert.True(list.First.Value.Equals(5));
            Assert.True(list.Last.Value.Equals(15));
        }

        [TheoryAttribute]
        [MemberData("geLinkedList2", MemberType = typeof(TestDataremoveDuplicates))]
        public static void removeDuplicatesTestNoChange(LinkedList<int> list)
        {
            Assert.True(list.Count.Equals(0) || list.Count.Equals(3));
            removeDuplicates(list);
            Assert.True(list.Count.Equals(0) || list.Count.Equals(3));
        }

        [TheoryAttribute]
        [MemberData("geLinkedList", MemberType = typeof(TestDataremoveDuplicates))]
        public static void removeDuplicatesTest2(LinkedList<int> list)
        {
            Assert.True(list.Count.Equals(5));
            removeDuplicatesNoBuffer(list);
            Assert.True(list.Count.Equals(2));
            Assert.True(list.First.Value.Equals(5));
            Assert.True(list.Last.Value.Equals(15));
        }

        [TheoryAttribute]
        [MemberData("geLinkedList2", MemberType = typeof(TestDataremoveDuplicates))]
        public static void removeDuplicatesTestNoChange2(LinkedList<int> list)
        {
            Assert.True(list.Count.Equals(0) || list.Count.Equals(3));
            removeDuplicatesNoBuffer(list);
            Assert.True(list.Count.Equals(0) || list.Count.Equals(3));
        }

        [TheoryAttribute]
        [MemberData("geLinkedList", MemberType = typeof(TestDataremoveDuplicates))]
        public static void removeDuplicatesTest3(LinkedList<int> list)
        {
            Assert.True(list.Count.Equals(5));
            removeDuplicatesNoBuffer2(list);
            Assert.True(list.Count.Equals(2));
            Assert.True(list.First.Value.Equals(5));
            Assert.True(list.Last.Value.Equals(15));
        }

        [TheoryAttribute]
        [MemberData("geLinkedList2", MemberType = typeof(TestDataremoveDuplicates))]
        public static void removeDuplicatesTestNoChange3(LinkedList<int> list)
        {
            Assert.True(list.Count.Equals(0) || list.Count.Equals(3));
            removeDuplicatesNoBuffer2(list);
            Assert.True(list.Count.Equals(0) || list.Count.Equals(3));
        }
    }

    class TestDataremoveDuplicates
    {
        public static TheoryData<LinkedList<int>> geLinkedList()
        {
            LinkedList<int> ll = new LinkedList<int>();
            ll.AddLast(5);
            ll.AddLast(15);
            ll.AddLast(5);
            ll.AddLast(15);
            ll.AddLast(5);

            return new TheoryData<LinkedList<int>>() { ll };
        }

        public static TheoryData<LinkedList<int>> geLinkedList2()
        {
            LinkedList<int> ll = new LinkedList<int>();
            LinkedList<int> ll2 = new LinkedList<int>();
            for (int i = 0; i < 3; i++)
                ll2.AddLast(i);

            return new TheoryData<LinkedList<int>>() { ll, ll2 };
        }
    }
}