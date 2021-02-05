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
            //vertical lines
            Line lv1 = new Line(new Point(2, 4), new Point(2, 10));
            Line lv2 = new Line(new Point(2, 7), new Point(2, 13));

            //horizontal lines
            Line lh1 = new Line(new Point(3, 5), new Point(5, 5));
            Line lh2 = new Line(new Point(5, 5), new Point(7, 5));

            //crossing lines
            Line l1 = new Line(new Point(5, -2), new Point(1, -1));
            Line l2 = new Line(new Point(-2, -5), new Point(2, -1));

            return new TheoryData<Line, Line>() { { lv1, lv2 }, { lh1, lh2 }, { l1, l2 } };
        }

        public static TheoryData<Line, Line> geLinesWithoutIntersection()
        {
            Point p = new Point(0, 0);
            Line l = new Line(p, p);
            return new TheoryData<Line, Line>() { { l, l } };
        }
    }
}
