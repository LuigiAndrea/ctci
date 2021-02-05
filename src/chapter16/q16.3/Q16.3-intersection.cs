using System;
using System.Collections.Generic;

namespace Chapter16
{
    public static class Q16_3Intersection
    {
        public static Point Intersection(Line l1, Line l2)
        {
            return null;
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
            public Point a { get; set; }
            public Point b { get; set; }

            public Line(Point a, Point b)
            {
                this.a = a;
                this.b = b;
            }
        }
    }
}