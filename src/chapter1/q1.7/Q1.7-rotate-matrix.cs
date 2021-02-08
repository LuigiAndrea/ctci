namespace Chapter1
{
    using System;
    using System.Text;

    public class Q1_7RotateMatrix
    {
        public class RotateMatrix
        {
            int[,] mtx;
            int size = 0;
            public RotateMatrix(int[,] matrix)
            {
                if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(0) != matrix.GetLength(1))
                {
                    throw new ArgumentException("Please provide a non empty NxN matrix");
                }

                mtx = matrix;
                size = mtx.GetLength(0);
            }

            //Rotate the matrix clockwise
            public void Rotate()
            {
                for (int i = 0; i < size / 2; i++)
                {
                    for (int j = 0; j < size - (2 * i + 1); j++)
                    {
                        swapCells(i, j);
                    }
                }
            }

            private void swapCells(int layer, int offset)
            {
                int temp = mtx[size - layer - (offset + 1), layer]; //left from bottom
                mtx[size - layer - (offset + 1), layer] = mtx[size - (layer + 1), size - layer - (offset + 1)]; //bottom from right 
                mtx[size - (layer + 1), size - layer - (offset + 1)] = mtx[layer + offset, size - (layer + 1)];//right from top
                mtx[layer + offset, size - (layer + 1)] = mtx[layer, layer + offset]; //top from left
                mtx[layer, layer + offset] = temp;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < size; i++)
                {
                    sb.Append("[");
                    for (int j = 0; j < size; j++)
                    {
                        sb.AppendFormat(" {0} ", mtx[i, j]);
                    }
                    sb.AppendFormat("]{0}", Environment.NewLine);
                }
                return sb.ToString();
            }
        }
    }
}