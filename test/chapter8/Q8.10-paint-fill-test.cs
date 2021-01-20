using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

using static Chapter8.Q8_10PaintFill;


namespace Tests.Chapter8
{
    public class Q8_10 : IClassFixture<Q8_10TestFixture>
    {
        private readonly Q8_10TestFixture _fixture;

        public Q8_10(Q8_10TestFixture fixture)
        {
            _fixture = fixture;
        }

        [FactAttribute]
        private void paintFillGeneralTest()
        {
            PaintFill(_fixture.screen.screenFilledUp, new Coordinates() { row = 1, column = 2 }, Color.red);
            shouldBeThisColor(_fixture.screen.screenFilledUp, (1, 4), (1, 5), Color.red);
            shouldBeThisColor(_fixture.screen.screenFilledUp, (4, 5), (0, 2), Color.red);
        }

        [FactAttribute]
        private void paintFillSameColor()
        {
            PaintFill(_fixture.screen.screenFilledUp, new Coordinates() { row = 4, column = 0 }, Color.red);
            shouldBeThisColor(_fixture.screen.screenFilledUp, (4, 5), (0, 1), Color.red);
        }

        [TheoryAttribute]
        [MemberData(nameof(TestPaintDataExceptions.getPaintParameters), MemberType = typeof(TestPaintDataExceptions))]
        private void exceptionWrongParameters(PaintParameter p)
        {
            Exception actualException = Record.Exception(() => PaintFill(p.screen, p.coordinates, p.newColor));
            Assert.IsType<ArgumentException>(actualException);
        }

        [TheoryAttribute]
        [MemberData(nameof(TestPaintDataExceptions.getPaintParametersForFixture), MemberType = typeof(TestPaintDataExceptions))]
        private void exceptionWrongParametersForFixture(PaintParameter p)
        {
            Exception actualException = Record.Exception(() => PaintFill(_fixture.screen.screenFilledUp, p.coordinates, p.newColor));
            Assert.IsType<ArgumentException>(actualException);
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
    }

    public class Q8_10TestFixture : IDisposable
    {
        public Screen screen { get; private set; }
        public Q8_10TestFixture()
        {
            screen = new Screen();
        }

        public void Dispose()
        {
            screen.Dispose();
        }
    }

    public class Screen : IDisposable
    {
        public Color[,] screenFilledUp { get; private set; } = new Color[10, 10];
        public Screen()
        {
            fillupScreenRandom(screenFilledUp);
            paintScreenWithColor(screenFilledUp, (1, 4), (1, 5), Color.yellow);
            paintScreenWithColor(screenFilledUp, (4, 5), (0, 2), Color.yellow);
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
        public void Dispose() { }
    }

    class TestPaintDataExceptions
    {
        public static TheoryData<PaintParameter> getPaintParameters()
        {
            PaintParameter obj1 = new PaintParameter(null, new Coordinates() { row = 4, column = 0 }, Color.orange);
            PaintParameter obj2 = new PaintParameter(new Color[0, 0], new Coordinates() { row = 0, column = 0 }, Color.orange);
            PaintParameter obj3 = new PaintParameter(new Color[1, 1] { { Color.orange } }, null, Color.orange);

            return new TheoryData<PaintParameter>() { obj1, obj2, obj3 };
        }
        public static TheoryData<PaintParameter> getPaintParametersForFixture()
        {
            PaintParameter obj1 = new PaintParameter(null, new Coordinates() { row = 4, column = 10 }, Color.orange);
            PaintParameter obj2 = new PaintParameter(new Color[0, 0], new Coordinates() { row = -1, column = 1 }, Color.orange);

            return new TheoryData<PaintParameter>() { obj1, obj2};
        }
    }

    class PaintParameter
    {
        public Color[,] screen { get; }
        public Coordinates coordinates { get; }
        public Color newColor { get; }
        public PaintParameter(Color[,] screen, Coordinates coordinates, Color newColor)
        {
            this.screen = screen;
            this.coordinates = coordinates;
            this.newColor = newColor;
        }
    }
}
