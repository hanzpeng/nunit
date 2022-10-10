using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0295_FindMedianfromDataStream
    {
        public void test()
        {
            var f = new MedianFinder();
            f.AddNum(1);
            Console.WriteLine(f.FindMedian());
            f.AddNum(2);
            Console.WriteLine(f.FindMedian());
            f.AddNum(3);
            f.AddNum(4);
            f.AddNum(5);
            Console.WriteLine(f.FindMedian());
        }
    }
    public class MedianFinder
    {
        private readonly PriorityQueue<int, int> top = new();
        private readonly PriorityQueue<int, int> bot = new();
        public MedianFinder()
        {

        }

        public void AddNum(int num)
        {
            if (top.Count == 0 && bot.Count == 0)
            {
                top.Enqueue(num, num);
                return;
            }

            var minTop = top.Peek();
            if (num >= minTop)
            {
                top.Enqueue(num, num);
            }
            else
            {
                bot.Enqueue(num, -num);
            }

            while (bot.Count > top.Count)
            {
                var x = bot.Dequeue();
                top.Enqueue(x, x);
            }

            while (top.Count > bot.Count + 1)
            {
                var x = top.Dequeue();
                bot.Enqueue(x, -x);
            }
        }

        public double FindMedian()
        {
            if (top.Count == bot.Count)
            {
                return ((top.Peek() + bot.Peek()) / 2.0);
            }
            else
            {
                return top.Peek();
            }
        }
    }
}
