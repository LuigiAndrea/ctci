using System;

namespace Chapter8
{
    public static class Q8_StackBoxes
    {
        public static int GetHeightsBoxes(Box[] boxes)
        {
            int maxHeight = 0;
            Array.Sort(boxes,new Comparison<Box>((x,y)=>y.Height.CompareTo(x.Height)));         

            for (int i = 0; i < boxes.Length; i++)
            {
                int height = buildStackOfBoxes(boxes, i);
                maxHeight = Math.Max(height, maxHeight);
            }

            return maxHeight;
        }

        private static int buildStackOfBoxes(Box[] boxes, int bottomIndex)
        {
            int maxHeight = 0;
            Box bottomBox = boxes[bottomIndex];

            for (int i = bottomIndex + 1; i < boxes.Length; i++)
            {
                if (boxes[i].CanGoAbove(bottomBox))
                {
                    int height = buildStackOfBoxes(boxes, i);
                    maxHeight = Math.Max(height, maxHeight);
                }
            }

            maxHeight+=bottomBox.Height;
            return maxHeight;
        }

         public class Box {
            public int Width { get; set; }
            public int Height { get; set; }
            public int Depth { get; set; }

            public bool CanGoAbove(Box b)
            {
                return this.Depth < b.Depth && this.Width < b.Width && this.Height < b.Height;
            }
        }
    }
}
