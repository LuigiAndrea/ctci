using Xunit;

using static Chapter16.Q16_3Intersection;

namespace Tests.Chapter6
{
    public class Q16_3
    {
        [TheoryAttribute]
        [MemberData(nameof(TestDataIntersection.geLinesWithIntersection), MemberType = typeof(TestDataIntersection))]
        public void WithIntersectionTest(Line l1, Line l2)
        {
            Intersection(l1, l2);
        }

        [TheoryAttribute]
        [MemberData(nameof(TestDataIntersection.geLinesWithoutIntersection), MemberType = typeof(TestDataIntersection))]
        public void WithoutIntersectionTest(Line l1, Line l2)
        {
            Intersection(l1, l2);
        }
    }

    class TestDataIntersection
    {
        public static TheoryData<Line, Line> geLinesWithIntersection()
        {
            Point p = new Point(0, 0);
            Line l = new Line(p, p);
            return new TheoryData<Line, Line>() { { l, l } };


        }
        public static TheoryData<Line, Line> geLinesWithoutIntersection()
        {
            Point p = new Point(0, 0);
            Line l = new Line(p, p);
            return new TheoryData<Line, Line>() { { l, l } };
        }
    }
}
