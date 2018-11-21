using System;
using System.Collections.Generic;
using Xunit;

using static Chapter8.Q8_2RobotGrid;

namespace Tests.Chapter8
{
    public class Q8_2
    {
        [TheoryAttribute]
        [MemberDataAttribute("getGridPath", MemberType = typeof(Grid))]
        private static void RobotGridTest(bool[,] grid)
        {
            List<Point> expectedPoints = createExpectedPoints(new List<(int c, int r)>() { (0, 0), (1, 0), (1, 1), (2, 1), (3, 1), (3, 2), (4, 2) });
            List<Point> actualPoints = getPathRobot(grid);
            Assert.True(pointsAreEqual(expectedPoints, actualPoints));
        }

        [TheoryAttribute]
        [MemberDataAttribute("getGridNoPath", MemberType = typeof(Grid))]
        private static void RobotGridExceptionTest(bool[,] grid)
        {
            Exception actualException = Record.Exception(() => getPathRobot(grid));
            Assert.IsType<ArgumentException>(actualException);
        }

        private static List<Point> createExpectedPoints(List<(int c, int r)> points)
        {
            List<Point> expectedPoints = new List<Point>();

            foreach (var point in points)
            {
                expectedPoints.Add(new Point() { column = point.c, row = point.r });
            }

            return expectedPoints;
        }

        private static bool pointsAreEqual(List<Point> expectedPoints, List<Point> actualPoints)
        {
            if (expectedPoints.Count != actualPoints.Count)
                return false;

            for (int i = 0; i < expectedPoints.Count; i++)
            {
                if (!expectedPoints[i].Equals(actualPoints[i]))
                    return false;
            }

            return true;
        }

        class Grid
        {
            public static TheoryData<bool[,]> getGridPath()
            {        
                bool[,] grid = new bool[5,3];
                fillGrids(new List<bool[,]>() { grid });
                setOffLimitCells(grid, new List<(int c, int r)>() { (0, 1), (1, 2), (2, 0), (2, 2), (4, 1) });

                return new TheoryData<bool[,]>() { grid };
            }

            public static TheoryData<bool[,]> getGridNoPath()
            {
                Dictionary<int, bool[,]> grids = buildGrids(new List<(int c, int r)>() { (4, 4), (6, 7), (2, 2), (0, 1), (0, 0) });
                fillGrids(new List<bool[,]>() { grids[0], grids[1], grids[2] });
                setOffLimitCells(grids[0], new List<(int c, int r)>() { (0, 1), (1, 1), (2, 1), (3, 2) });
                setOffLimitCells(grids[1], new List<(int c, int r)>() { (0, 0) });
                setOffLimitCells(grids[2], new List<(int c, int r)>() { (1, 1) });

                return new TheoryData<bool[,]>() { grids[0], grids[1], grids[2], grids[3], grids[4] };
            }

            private static Dictionary<int, bool[,]> buildGrids(List<(int c, int r)> grids)
            {
                Dictionary<int, bool[,]> gridsBuilt = new Dictionary<int, bool[,]>();
                int i = 0;
                foreach (var grid in grids)
                {
                    gridsBuilt.Add(i++, new bool[grid.c, grid.r]);
                }

                return gridsBuilt;
            }

            private static void setOffLimitCells(bool[,] grid, List<(int col, int row)> cordinates) => cordinates.ForEach(c => grid[c.col, c.row] = false);

            private static void fillGrids(List<bool[,]> grids)
            {
                foreach (var grid in grids)
                {
                    for (int i = 0; i < grid.GetLength(0); i++)
                    {
                        for (int j = 0; j < grid.GetLength(1); j++)
                        {
                            grid[i, j] = true;
                        }
                    }
                }
            }
        }
    }
}