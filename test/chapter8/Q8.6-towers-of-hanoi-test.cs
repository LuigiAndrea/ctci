using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

using static Chapter8.Q8_6TowerOfHanoi;


namespace Tests.Chapter8
{
    public class Q8_6
    {
        [FactAttribute]
        private static void moveDisksTest()
        {
            int numberOfDisks = 3;
            var towers = BuildAndLoadTowers(numberOfDisks); 
      
            Tower sourceTower = towers.ElementAt(0);
            Tower bufferTower = towers.ElementAt(1);
            Tower destTower = towers.ElementAt(2);

            Assert.Equal(numberOfDisks,sourceTower.disks.Count);
            Assert.Empty(destTower.disks);

            sourceTower.moveDisks(numberOfDisks, destTower, bufferTower);

            Assert.Empty(sourceTower.disks);
            Assert.Equal(numberOfDisks,destTower.disks.Count);

            int i = 1; 
            foreach (var disk in destTower.disks)
            {
                Assert.Equal(disk,i++);
            }
        }


        [FactAttribute]
        private static void exceptionMoveDiskOnTop()
        {
             Tower a = new Tower("Tower A");
             Tower b = new Tower("Tower B");
             a.disks.Push(5);
             b.disks.Push(7);
             
             Exception actualException = Record.Exception(() => a.moveDiskOnTop(b));
             Assert.IsType<InvalidOperationException>(actualException);

             actualException = Record.Exception(() => b.moveDiskOnTop(a));
             Assert.Null(actualException);

             actualException = Record.Exception(() => BuildAndLoadTowers(-4));
             Assert.IsType<ArgumentException>(actualException);
        }
    }
}