using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

using static Chapter8.Q8_10PaintFill;


namespace Tests.Chapter8
{
    public class Q8_10
    {
        [FactAttribute]
        private static void paintFillGeneralTest()
        {
            Color[,] screen = new Color[10, 10];
            fillupScreenRandom(screen);
            paintScreenWithColor(screen, (1, 4), (1, 5), Color.yellow);
            paintScreenWithColor(screen, (4, 5), (0, 2), Color.yellow);      

            PaintFill(screen, new Coordinates() { row = 1, column = 2 }, Color.red);
            shouldBeThisColor(screen, (1, 4), (1, 5), Color.red);
            shouldBeThisColor(screen, (4, 5), (0, 2), Color.red);
        }

        /// <summary>
        /// Assert that the range of rows and colums provided have the color passed as parameter
        ///</summary>
        /// <param name="screen"> The screen.</param>
        /// <param name="rowRange"> The row range to check. From minRow to maxRow [minRow,maxRow) </param>
        /// <param name="colRange"> The column range to check. From minRow to maxRow [minRow,maxRow)</param>
        /// <param name="color"> The cell should have this color.</param>
        private static void shouldBeThisColor(Color[,] screen, (int minRow, int maxRow) rowRange, (int minCol, int maxCol) colRange, Color color)
        {
            for (int i = rowRange.minRow; i < rowRange.maxRow; i++)
            {
                for (int j = colRange.minCol; j < colRange.maxCol; j++)
                {
                    Assert.Equal(color, screen[i, j]);
                }
            }
        }

        /// <summary>
        ///  Paint the screen with random colors
        ///</summary>
        /// <param name="screen"> The screen to paint.</param>
        private static void fillupScreenRandom(Color[,] screen)
        {
            int numberOfColors = Enum.GetNames(typeof(Color)).Length;
            int rowLength = screen.GetLength(0);
            int columnLength = screen.GetLength(1);
            Random random = new Random();

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    screen[i, j] = (Color)random.Next(0, numberOfColors);
                }
            }
        }

        /// <summary>
        /// Paint the screen with a specific color
        ///</summary>
        /// <param name="screen"> The screen to paint.</param>
        /// <param name="rowRange"> The row range to paint. From minRow to maxRow [minRow,maxRow) </param>
        /// <param name="colRange"> The column range to paint. From minRow to maxRow [minRow,maxRow)</param>
        /// <param name="color"> The color to use to paint the screen.</param>
        private static void paintScreenWithColor(Color[,] screen, (int minRow, int maxRow) rowRange, (int minCol, int maxCol) colRange, Color color)
        {
            for (int i = rowRange.minRow; i < rowRange.maxRow; i++)
            {
                for (int j = colRange.minCol; j < colRange.maxCol; j++)
                {
                    screen[i, j] = color;
                }
            }
        }
    }
}
