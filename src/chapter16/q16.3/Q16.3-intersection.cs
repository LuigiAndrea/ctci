using System;

namespace Chapter16
{
    public class Q16_3Intersection
    {
        public static Point Intersection(Line l1, Line l2)
        {
            if (l1 == null || l2 == null || l1.pa == null || l1.pb == null || l2.pa == null || l2.pb == null)
            {
                throw new ArgumentNullException("Please provide non-null lines or points");
            }

            orderPointsInLines(l1, l2);
            orderTwoLines(l1, l2);

            //create equation of the two lines   
            //slopes    
            double m1 = calculateSlope(l1);
            double m2 = calculateSlope(l2);

            //shifts
            double s1 = l1.pa.y - m1 * l1.pa.x;
            double s2 = l2.pa.y - m2 * l2.pa.x;

            //lines with same slopes
            if (m1 == m2)
            {
                if (l1.pa.x == l1.pb.x && l1.pa.y != l1.pb.y) // vertical line
                {
                    if (l1.pa.x != l2.pa.x)
                        return null;

                    double y_minl1 = (l1.pa.y > l1.pb.y) ? l1.pb.y : l1.pa.y;
                    double y_minl2 = (l2.pa.y > l2.pb.y) ? l2.pb.y : l2.pa.y;

                    return (y_minl2 > y_minl1)
                     ? ((y_minl2 < l1.pb.y) ? new Point(l2.pa.x, l2.pa.y) : null)
                     : y_minl1 < l2.pb.y ? new Point(l1.pa.x, l1.pa.y) : null;
                }
                else //horizontal or oblique lines
                {
                    return (l2.pa.x <= l1.pb.x && s1 == s2) ? new Point(l2.pa.x, l2.pa.y) : null;
                }
            }

            double x = (s2 - s1) / (m1 - m2);
            double y = x * m1 + s1;

            //check if the intersection lay within line-segment
            return (x >= l2.pa.x && x <= l1.pb.x) ? new Point(x, y) : null;
        }

        private static double calculateSlope(Line l) => (l.pb.y - l.pa.y) / (l.pb.x - l.pa.x);

        private static void orderPointsInLines(params Line[] lines)
        {
            foreach (var line in lines)
            {
                if (line.pa.x > line.pb.x)
                {
                    swapPointsLine(line);
                }
            }
        }

        private static void orderTwoLines(Line l1, Line l2)
        {
            if (l1.pa.x > l2.pa.x)
            {
                var temp = new Line(new Point(l1.pa.x, l1.pa.y), new Point(l1.pb.x, l1.pb.y));
                l1.pa = l2.pa;
                l1.pb = l2.pb;
                l2.pa = temp.pa;
                l2.pb = temp.pb;
            }
        }

        private static void swapPointsLine(Line line)
        {
            Point temp = new Point(line.pa.x, line.pa.y);
            line.pa.x = line.pb.x;
            line.pa.y = line.pb.y;
            line.pb.x = temp.x;
            line.pb.y = temp.y;
        }

        public class Point
        {
            public double x { get; set; }
            public double y { get; set; }

            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }
        public class Line
        {
            public Point pa { get; set; }
            public Point pb { get; set; }

            public Line(Point a, Point b)
            {
                this.pa = a;
                this.pb = b;
            }
        }
    }
}
