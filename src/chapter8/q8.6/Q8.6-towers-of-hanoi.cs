using System;
using System.Collections.Generic;
using System.Collections;

namespace Chapter8
{
    public static class Q8_6TowerOfHanoi
    {
        public static List<Tower> BuildAndLoadTowers(int numberOfDisks)
        {
            if(numberOfDisks < 1)
                throw new ArgumentException("You must provide at least one disk!");

            Tower a = new Tower("Tower A");
            Tower b = new Tower("Tower B");
            Tower c = new Tower("Tower C");
            for (int i = numberOfDisks; i > 0; i--)
            {
                a.disks.Push(i);
            }
            
            return new List<Tower>(){a,b,c};
        }
        public class Tower
        {
            public Stack<int> disks = new Stack<int>();
            public string Name{ get; }
            public Tower(string name){
                Name = name;
            }
            public void moveDiskOnTop(Tower sourceTower)
            {
                Stack<int> disksTower = sourceTower.disks;
                if (this.disks.Count >0 && disksTower.Peek() > this.disks.Peek())
                    throw new InvalidOperationException("This disk has been placed on top of a smaller disk!");

                this.disks.Push(disksTower.Pop());
            }

            public void moveDisks(int n, Tower destTower, Tower bufferTower)
            {
                if (n <= 0)
                {
                    return;
                }
                this.moveDisks(n - 1, bufferTower, destTower);
                Console.WriteLine($"Move disk from {this.Name} to {destTower.Name}");
                destTower.moveDiskOnTop(this);           
                bufferTower.moveDisks(n - 1, destTower, this);
            }
        }
    }
}
