using System;

namespace Chapter8
{
    public static class Q8_StackBoxes
    {
        public static int GetHeightBoxes(Box[] boxes)
        {
            int maxHeight = 0;
            Array.Sort(boxes, new Comparison<Box>((x, y) => y.Height.CompareTo(x.Height)));

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

            maxHeight += bottomBox.Height;
            return maxHeight;
        }

        public static int GetHeightBoxesMemorization(Box[] boxes)
        {
            int maxHeight = 0;
            Array.Sort(boxes, new Comparison<Box>((x, y) => y.Height.CompareTo(x.Height)));
            int[] BoxHeighstMap = new int[boxes.Length];

            for (int i = 0; i < boxes.Length; i++)
            {
                int height = buildStackOfBoxesMemorization(boxes, i, BoxHeighstMap);
                maxHeight = Math.Max(height, maxHeight);
            }

            return maxHeight;
        }

        private static int buildStackOfBoxesMemorization(Box[] boxes, int bottomIndex, int[] boxHeightsMap)
        {
            if (boxHeightsMap[bottomIndex] > 0)
            {
                return boxHeightsMap[bottomIndex];
            }

            int maxHeight = 0;
            Box bottomBox = boxes[bottomIndex];

            for (int i = bottomIndex + 1; i < boxes.Length; i++)
            {
                if (boxes[i].CanGoAbove(bottomBox))
                {
                    int height = buildStackOfBoxesMemorization(boxes, i, boxHeightsMap);
                    maxHeight = Math.Max(height, maxHeight);
                }
            }

            maxHeight += bottomBox.Height;
            return boxHeightsMap[bottomIndex] = maxHeight;
        }

        //Decide every step whether to place or not the current box in the stack
        public static int GetHeightBoxesWithOrWithoutCurrentBox(Box[] boxes)
        {
            Array.Sort(boxes, new Comparison<Box>((x, y) => y.Height.CompareTo(x.Height)));
            int[] boxHeightsMap = new int[boxes.Length];
            return buildStackOfBoxesWithOrWithoutCurrentBox(boxes, null, 0, boxHeightsMap);
        }

        private static int buildStackOfBoxesWithOrWithoutCurrentBox(Box[] boxes, Box bottomBox, int offset, int[] boxHeightsMap)
        {
            if (offset >= boxes.Length)
                return 0;

            Box newBottomBox = boxes[offset];
            int heightWithBottom = 0;

            //Height with current bottom
            if(bottomBox == null || newBottomBox.CanGoAbove(bottomBox))
            {
                if(boxHeightsMap[offset] == 0){
                    boxHeightsMap[offset] = buildStackOfBoxesWithOrWithoutCurrentBox(boxes,newBottomBox,offset + 1,boxHeightsMap);
                    boxHeightsMap[offset] += newBottomBox.Height;
                }

                heightWithBottom = boxHeightsMap[offset];
            }

            //Height without current bottom
            int heightWithoutCurrentBottom = buildStackOfBoxesWithOrWithoutCurrentBox(boxes,bottomBox,offset + 1,boxHeightsMap);

            return Math.Max(heightWithBottom,heightWithoutCurrentBottom);
        }

        public class Box
        {
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
