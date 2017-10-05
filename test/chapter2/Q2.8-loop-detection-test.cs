using Xunit;

using static Chapter2.Utilities;
using static Chapter2.Q2_8LoopDetection;
using static Chapter2.Q2_8LoopDetection2;
using Singly = Chapter2.SinglyLinkedListNode;

namespace Tests.Chapter2
{
    public class Q2_8
    {
        [TheoryAttribute]
        [MemberDataAttribute("getListWithLoop", MemberType = typeof(TestDataLoop))]
        public static void listLoopTest(Singly list)
        {
            Singly startLoopNode = loopDetection(list);
            Assert.True(startLoopNode.data.Equals(44));

            startLoopNode = loopDetection2(list);
            Assert.True(startLoopNode.data.Equals(44));
        }

        [TheoryAttribute]
        [MemberDataAttribute("getListWithoutLoop", MemberType = typeof(TestDataLoop))]
        public static void listLoopTest2(Singly list)
        {
            Singly startLoopNode = loopDetection(list);
            Assert.True(startLoopNode == null);

            startLoopNode = loopDetection2(list);
            Assert.True(startLoopNode == null);
        }
    }

    class TestDataLoop
    {
        public static TheoryData<Singly> getListWithLoop()
        {
            int[] array = new int[150];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            Singly list = buildLinkedListNodeFromArray<Singly,int>(array);
            Result r = getStartLoopNodeandTail(list, 44);
            r.tail.next = r.startLoop;

            return new TheoryData<Singly>() { list };
        }

        public static TheoryData<Singly> getListWithoutLoop()
        {
            Singly list = buildLinkedListNodeFromArray<Singly,int>(new int[] { 1, 2, 3, 4 });
            Singly list2 = buildLinkedListNodeFromArray<Singly,int>(new int[0] { });
            return new TheoryData<Singly>() { list, null, list2 };
        }

        protected class Result
        {
            public Singly tail;
            public Singly startLoop;
        }
        private static Result getStartLoopNodeandTail(Singly l, int n)
        {

            Result re = new Result();
            while (l.next != null)
            {
                if (l.data.Equals(n))
                {
                    re.startLoop = l;
                }
                l = l.next;
            }
            re.tail = l;

            return re;
        }
    }
}