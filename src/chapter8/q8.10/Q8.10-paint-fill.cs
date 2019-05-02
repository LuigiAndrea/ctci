using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter8
{
    public static class Q8_10PaintFill
    {
        public enum Color { red, yellow, green, blue, purple, black, white, orange, brown };

        public static void PaintFill(Color[,] screen, Coordinates coordinates, Color newColor)
        {
            int rowLength = screen.GetLength(0);
            int columnLength = screen.GetLength(1);

            if(screen.Length == 0 || screen == null || coordinates == null || coordinates.row >= rowLength || coordinates.column >= columnLength){
                throw new ArgumentException($"{nameof(PaintFill)}: Parameters provided are wrong");
            }
            Color oldColor = screen[coordinates.row, coordinates.column];
            if (oldColor == newColor)
                return;

            PaintFill(screen, (oldColor, newColor), coordinates, (rowLength,columnLength));
        }

        private static void PaintFill(Color[,] screen, (Color oldColor, Color newColor) colorMapping, Coordinates c, (int hight, int width) resolution)
        {
            if (c.row < 0 || c.column < 0 || c.row == resolution.hight || c.column == resolution.width)
            {
                return;
            }

            if (colorMapping.oldColor == screen[c.row, c.column])
            {
                screen[c.row, c.column] = colorMapping.newColor;
                PaintFill(screen, colorMapping, updateCoordinates(c, move.up), resolution);
                PaintFill(screen, colorMapping, updateCoordinates(c, move.down), resolution);
                PaintFill(screen, colorMapping, updateCoordinates(c, move.left), resolution);
                PaintFill(screen, colorMapping, updateCoordinates(c, move.right), resolution);
            }
        }

        private enum move { up, down, left, right };
        private static Coordinates updateCoordinates(Coordinates c, move m)
        {
            Coordinates newCoord = new Coordinates() { row = c.row, column = c.column };

            switch (m)
            {
                case move.up:
                    newCoord.row = c.row + 1;
                    break;
                case move.down:
                    newCoord.row = c.row - 1;
                    break;
                case move.left:
                    newCoord.column = c.column - 1;
                    break;
                case move.right:
                    newCoord.column = c.column + 1;
                    break;
            }

            return newCoord;
        }


        public class Coordinates
        {
            public int row { get; set; }
            public int column { get; set; }
        }
    }
}
