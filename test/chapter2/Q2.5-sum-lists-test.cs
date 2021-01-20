using Xunit;

using static Chapter2.Utilities;
using static Chapter2.Q2_5SumList;
using static Chapter2.Q2_5SumListFollowUp;
using static Chapter2.Q2_5SumListFollowUpIterative;
using Singly = Chapter2.SinglyLinkedListNode;

namespace Tests.Chapter2
{
    public class Q2_5
    {
        [TheoryAttribute]
        [MemberData(nameof(TestDataSumLists.getLists), MemberType = typeof(TestDataSumLists))]
        public static void sumLists(Singly l1, Singly l2)
        {
            int[] result = new int[6] { 1, 0, 8, 7, 2, 2 };
            Singly list = addListsForward(l1, l2);
            compareValues(list, result);

            list = addListsForwardIte(l1, l2);
            compareValues(list, result);

            result = new int[5] { 8, 8, 0, 3, 1 };
            list = addLists(l1, l2);
            compareValues(list, result);
        }

        [TheoryAttribute]
        [MemberData(nameof(TestDataSumLists.getLists2), MemberType = typeof(TestDataSumLists))]
        public static void sumLists2(Singly l1, Singly l2)
        {
            int[] result = new int[2] { 8, 1 };
            Singly list = addListsForward(l1, l2);
            compareValues(list, result);

            list = addListsForwardIte(l1, l2);
            compareValues(list, result);

            result = new int[2] { 8, 1 };
            list = addLists(l1, l2);
            compareValues(list, result);
        }

        [TheoryAttribute]
        [MemberData(nameof(TestDataSumLists.getLists3), MemberType = typeof(TestDataSumLists))]
        public static void sumLists3(Singly l1, Singly l2)
        {
            Assert.True(addListsForward(l1, l2) == null);
            Assert.True(addListsForwardIte(l1, l2) == null);
            Assert.True(addLists(l1, l2) == null);
        }

        private static void compareValues(Singly list, int[] res)
        {
            for (int i = 0; i < res.Length; i++)
            {
                Assert.True(list?.data.Equals(res[i]));
                list = list.next;
            }
        }
    }

    class TestDataSumLists
    {
        public static TheoryData<Singly, Singly> getLists()
        {
            Singly l1 = buildLinkedListNodeFromArray<Singly,int>(new int[4] { 9, 9, 1, 1 });
            Singly l2 = buildLinkedListNodeFromArray<Singly,int>(new int[5] { 9, 8, 8, 1, 1 });

            return new TheoryData<Singly, Singly>() { { l1, l2 } };
        }

        public static TheoryData<Singly, Singly> getLists2()
        {
            Singly l1 = buildLinkedListNodeFromArray<Singly,int>(new int[2] { 8, 1 });
            Singly l2 = buildLinkedListNodeFromArray<Singly,int>(new int[0] { });
            Singly l2_1 = buildLinkedListNodeFromArray<Singly,int>(null);

            return new TheoryData<Singly, Singly>() { { l1, l2 }, { l1, l2_1 } };
        }

        public static TheoryData<Singly, Singly> getLists3()
        {
            Singly l1 = buildLinkedListNodeFromArray<Singly,string>(null);
            Singly l2 = buildLinkedListNodeFromArray<Singly,string>(null);

            return new TheoryData<Singly, Singly>() { { l1, l2 } };
        }

    }
}