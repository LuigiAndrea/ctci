using System;
using Xunit;

using static Chapter8.Q8_13StackBoxes;


namespace Tests.Chapter8
{
    public class Q8_13
    {

        [TheoryAttribute]
        [MemberDataAttribute(nameof(Boxes.getBoxes), MemberType = typeof(Boxes))]
        private static void StackOfBoxesTest(Box[][] boxes)
        {
            int[] expectedValues = new int[] { 128, 132, 92, 94, 100, 12 };
            for (int i = 0; i < boxes.Length; i++)
            {
                int h = GetHeightBoxesWithOrWithoutCurrentBox(boxes[i]);
                Assert.Equal(expectedValues[i], h);
                h = GetHeightBoxes(boxes[i]);
                Assert.Equal(expectedValues[i], h);
                h = GetHeightBoxesMemorization(boxes[i]);
                Assert.Equal(expectedValues[i], h);
            }
        }

        [TheoryAttribute]
        [MemberDataAttribute(nameof(Boxes.getBoxesNullOrWrongDimensions), MemberType = typeof(Boxes))]
        private static void StackOfBoxesNullTest(Box[] b)
        {
            Exception actualException = Record.Exception(() => GetHeightBoxesWithOrWithoutCurrentBox(b));
            Assert.IsType<ArgumentException>(actualException);
            actualException = Record.Exception(() => GetHeightBoxes(b));
            Assert.IsType<ArgumentException>(actualException);
            actualException = Record.Exception(() => GetHeightBoxesMemorization(b));
            Assert.IsType<ArgumentException>(actualException);
        }

        class Boxes
        {
            public static TheoryData<Box[][]> getBoxes()
            {
                Box b1 = new Box()
                {
                    Height = 4,
                    Width = 8,
                    Depth = 2,
                };

                Box b2 = new Box()
                {
                    Height = 40,
                    Width = 5,
                    Depth = 3,

                };

                Box b3 = new Box()
                {
                    Height = 88,
                    Width = 15,
                    Depth = 20,

                };

                Box[] boxes = new Box[] { b1, b2, b3 };
                Box[] boxes2 = new Box[] { b1, new Box() { Height = 40, Width = 10, Depth = 3 }, b3 };
                Box[] boxes3 = new Box[] { b1, new Box() { Height = 91 }, b3 };
                Box[] boxes4 = new Box[] { b1, new Box() { Height = 94 }, b3 };
                Box[] boxes5 = new Box[] { b1, new Box() { Height = 12 }, b3 };
                Box[] boxes6 = new Box[] { new Box { Width = 3 }, new Box() { Height = 12 }, new Box() { } };

                return new TheoryData<Box[][]>() { new Box[][] { boxes, boxes2, boxes3, boxes4, boxes5, boxes6 } };
            }

            public static TheoryData<Box[]> getBoxesNullOrWrongDimensions()
            {
                Box[] b = new Box[] {
                new Box{ Height=-3, Width=3, Depth=1},
                new Box{ Height=3, Width=-3, Depth=1},
                new Box{ Height=3, Width=3, Depth=-1}
                };

                return new TheoryData<Box[]>() { new Box[] { null }, null, b };
            }
        }
    }
}
