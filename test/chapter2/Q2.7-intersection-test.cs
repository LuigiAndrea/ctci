using Xunit;

using static Chapter2.Utilities;
using static Chapter2.Q2_7Intersection;
using Singly = Chapter2.SinglyLinkedListNode;

namespace Tests.Chapter2
{
    public class Q2_7
    {
        [TheoryAttribute]
        [MemberData(nameof(TestDataIntersection.getLists), MemberType = typeof(TestDataIntersection))]
        public static void intersectionTest(Singly l1, Singly l2)
        {
            Singly result = intersection(l1, l2);
            Assert.True(result.data.Equals(3));
        }

        [TheoryAttribute]
        [MemberData(nameof(TestDataIntersection.getLists2), MemberType = typeof(TestDataIntersection))]
        public static void intersectionTestNull(Singly l1, Singly l2)
        {
            Singly result = intersection(l1, l2);
            Assert.True(result == null);
        }
    }

    class TestDataIntersection
    {
        public static TheoryData<Singly, Singly> getLists()
        {
            Singly l1 = buildLinkedListNodeFromArray<Singly,int>(new int[6] { 9, 3, 1, 1, 7, 7 });
            Singly l2 = buildLinkedListNodeFromArray<Singly,int>(new int[3] { 1, 1, 1 });
            l2.next.next.next = l1.next;
            Singly l1_1 = buildLinkedListNodeFromArray<Singly,int>(new int[2] { 9, 3 });
            Singly l2_2 = buildLinkedListNodeFromArray<Singly,int>(new int[1] { 1 });
            l2_2.next = l1_1.next;
            return new TheoryData<Singly, Singly>() { { l1, l2 }, { l1_1, l2_2 } };
        }

        public static TheoryData<Singly, Singly> getLists2()
        {
            Singly l1 = buildLinkedListNodeFromArray<Singly,int>(new int[2] { 9, 3 });
            Singly l2 = buildLinkedListNodeFromArray<Singly,int>(new int[2] { 1, 3 });

            Singly l1_1 = buildLinkedListNodeFromArray<Singly,int>(null);
            Singly l2_2 = buildLinkedListNodeFromArray<Singly,int>(new int[2] { 1, 3 });

            Singly l1_3 = buildLinkedListNodeFromArray<Singly,int>(null);
            Singly l2_3 = buildLinkedListNodeFromArray<Singly,int>(null);

            Singly l1_4 = buildLinkedListNodeFromArray<Singly,int>(new int[0] { });
            Singly l2_4 = buildLinkedListNodeFromArray<Singly,int>(new int[0] { });

            return new TheoryData<Singly, Singly>() { { l1, l2 }, { l1_1, l2_2 },{l1_3,l2_3},{l1_4,l2_4} };
        }
    }
}