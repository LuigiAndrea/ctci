using Chapter3.Exceptions;

namespace Chapter3
{
    public class StackPlate
    {
        private int capacity;
        private int count = 0;

        protected class StackNode
        {
            public int data;
            public StackNode above;
            public StackNode below;

            public StackNode(int data)
            {
                this.data = data;
            }
        }
        public StackPlate(int capacity)
        {
            this.capacity = capacity;
        }
        protected StackNode top;
        protected StackNode bottom;
        public int Count
        {
            get
            {
                return count;
            }
        }

        public int pop()
        {
            if (top == null)
                throw new EmptyStackException(nameof(pop));

            int item = top.data;
            top = top.below;
            if (top != null)
                top.above = null;
            else
                bottom = null;

            this.count--;
            return item;
        }

        public void push(int item)
        {
            if (this.isFull())
                throw new FullStackException(nameof(push));

            StackNode node = new StackNode(item);
            node.below = top;
            if (top != null)
            {
                top.above = node;
                top = node;
            }
            else
            {
                top = node;
                bottom = node;
            }
            this.count++;
        }

        public int peek()
        {
            if (top == null)
                throw new EmptyStackException(nameof(peek));
            return top.data;
        }

        public int getBottom()
        {
            if (bottom == null)
                throw new EmptyStackException(nameof(getBottom));

            int value = bottom.data;

            bottom = bottom.above;
            if (bottom != null)
                bottom.below = null;
            else
            {
                top = null;
            }

            this.count--;

            return value;
        }

        public int peekBottom()
        {
            if (bottom == null)
                throw new EmptyStackException(nameof(peekBottom));
            return bottom.data;
        }

        public bool isFull()
        {
            return this.capacity.Equals(this.count);
        }

        public bool isEmpty()
        {
            return top == null;
        }
    }
}