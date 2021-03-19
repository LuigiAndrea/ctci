using System;
using Xunit;

using static Chapter16.Q16_3Intersection;

namespace Tests.Chapter16
{
    public class Q16_3
    {
        [FactAttribute]
        public void VerticalLinesIntersectionTest()
        {
            //Vertical Lines
            Line lv1 = new Line(new Point(2, 4), new Point(2, 10));
            Line lv2 = new Line(new Point(2, 7), new Point(2, 13));
            Point p = Intersection(lv1, lv2);
            Assert.NotNull(p);
            Assert.Equal(2, p.x);
            Assert.Equal(7, p.y);
        }

        [FactAttribute]
        public void HorizontalLinesIntersectionTest()
        {
            // Horizontal Lines
            Line lh1 = new Line(new Point(5, 5), new Point(3, 5));
            Line lh2 = new Line(new Point(3, 5), new Point(7, 5));
            Point p = Intersection(lh1, lh2);
            Assert.NotNull(p);
            Assert.Equal(3, p.x);
            Assert.Equal(5, p.y);

            lh1 = new Line(new Point(2, 15), new Point(9, 15));
            lh2 = new Line(new Point(9, 15), new Point(11, 15));
            p = Intersection(lh1, lh2);
            Assert.NotNull(p);
            Assert.Equal(9, p.x);
            Assert.Equal(15, p.y);
        }

        [FactAttribute]
        public void CrossingLinesIntersectionTest()
        {
            // Crossing Lines
            Line l1 = new Line(new Point(5, -2), new Point(1, -1));
            Line l2 = new Line(new Point(-2, -5), new Point(2, -1));
            Point p = Intersection(l1, l2);

            Assert.NotNull(p);
            Assert.Equal(1.8, p.x);
            Assert.Equal(-1.2, p.y);

            // Same Lines (same slope and shift)
            l1 = new Line(new Point(-1, 7), new Point(-2, 12));
            l2 = new Line(new Point(-4, 22), new Point(0, 2));
            p = Intersection(l1, l2);

            Assert.NotNull(p);
            Assert.Equal(-2, p.x);
            Assert.Equal(12, p.y);
        }

        [FactAttribute]
        public void NoLinesSegmentTest()
        {
            Line l1 = new Line(new Point(-2, 12), new Point(-2, 12));
            Line l2 = new Line(new Point(-4, 22), new Point(0, 2));
            Assert.Null(Intersection(l1, l2));

            l1 = new Line(new Point(-2, 12), new Point(-2, 12));
            l2 = new Line(new Point(-4, 22), new Point(-4, 22));
            Assert.Null(Intersection(l1, l2));
        }

        [TheoryAttribute]
        [MemberData(nameof(TestDataIntersection.getLinesWithoutIntersection), MemberType = typeof(TestDataIntersection))]
        public void WithoutIntersectionTest(Line l1, Line l2)
        {
            Assert.Null(Intersection(l1, l2));
        }

        [TheoryAttribute]
        [MemberData(nameof(TestDataIntersection.getWrongLinesAndPoints), MemberType = typeof(TestDataIntersection))]
        public void IntersectionExceptionTest(Line l1, Line l2)
        {
            Exception ex = Record.Exception(() => Intersection(l1, l2));
            Assert.IsType<ArgumentNullException>(ex);
        }

        class TestDataIntersection
        {
            public static TheoryData<Line, Line> getWrongLinesAndPoints()
            {
                return new TheoryData<Line, Line>() {
                    { null, null },
                    { new Line(null,null), new Line(null,null) },
                    { new Line(new Point(0,0), new Point(0,0)),null },
                    { new Line(new Point(0,0), null),new Line(new Point(0,0), new Point(0,0)) }
                    };
            }

            public static TheoryData<Line, Line> getLinesWithoutIntersection()
            {
                // Vertical Lines
                Line lv1 = new Line(new Point(2, 4), new Point(2, 10));
                Line lv2 = new Line(new Point(2, 10.2), new Point(2, 13));

                Line lv3 = new Line(new Point(2, 4), new Point(2, 10));
                Line lv4 = new Line(new Point(3, 5.2), new Point(3, 5.8));

                // Horizontal Lines
                Line lh1 = new Line(new Point(8.5, 5), new Point(7.1, 5));
                Line lh2 = new Line(new Point(3, 5), new Point(7, 5));

                Line lh3 = new Line(new Point(2, 5), new Point(4, 5));
                Line lh4 = new Line(new Point(3, 6), new Point(7, 6));

                // Oblique Lines
                Line lo1 = new Line(new Point(1, 5), new Point(4, 11));
                Line lo2 = new Line(new Point(1, 6.5), new Point(11, 31.5));

                // Parallel Lines
                Line lpar1 = new Line(new Point(1, 5), new Point(1.5, 6));
                Line lpar2 = new Line(new Point(5, 14), new Point(-1, 2));

               return new TheoryData<Line, Line>() { { lv1, lv2 }, { lv3, lv4 }, { lh1, lh2 }, { lh3, lh4 }, { lo1, lo2 }, { lpar1, lpar2 } };
            }
        }
    }
}
