using Chapter3.Exceptions;

namespace Chapter3
{
    public class StackWithCapacity : Stack<int>
    {
        private int capacity;
        private int count = 0;
        public int Count
        {
            get
            {
                return count;
            }
        }

        public StackWithCapacity(int cap)
        {
            this.capacity = cap;
        }

        new public void push(int item)
        {
            if(this.isFull()){
                throw new FullStackException();
            }
            
            this.count++;
            base.push(item);
        }

        new public int pop()
        {
            this.count--;
            return base.pop();
        }

        public bool isFull()
        {
            return this.capacity.Equals(this.count);
        }
    }
}