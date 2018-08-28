using System;
using System.Collections.Generic;

namespace Chapter8
{
    public static class Q8_2RobotGrid
    {
        private static List<Point> Points = new List<Point>();
        public static List<Point> getPathRobot(bool[,] grid)
        {
            if (grid == null || grid.Length == 0)
                throw new ArgumentException("The grid must not be null or empty");

            (int colms, int rows) gridDim = getDimensions(grid);
            bool res = getPath(gridDim, grid);

            return (res) ? Points : throw new ArgumentException("The maze must have a path that leads to the bottom right!");
        }

        private static bool getPath((int c, int r) gridDim, bool[,] grid)
        {
            if (offLimit(gridDim, grid))
                return false;

            if (reachedBottom(gridDim) || getPath((gridDim.c - 1, gridDim.r), grid) || getPath((gridDim.c, gridDim.r - 1), grid))
            {
                Points.Add(new Point() { column = gridDim.c, row = gridDim.r });
                return true;
            }

            return false;
        }

        private static bool reachedBottom((int cols, int rows) gridDim) => gridDim.rows == 0 && gridDim.cols == 0;
        private static bool offLimit((int cols, int rows) gridDim, bool[,] grid) => gridDim.rows < 0 || gridDim.cols < 0 || !grid[gridDim.cols, gridDim.rows];
        private static (int c, int r) getDimensions(bool[,] grid) => (grid.GetLength(0) - 1, grid.GetLength(1) - 1);

        public class Point
        {
            public int column;
            public int row;

            public override bool Equals(object obj)
            {
                Point p = (Point)obj;
                return this.column == p.column && this.row == p.row;
            }

            public override int GetHashCode() => base.GetHashCode();
            
        }
    }
}
