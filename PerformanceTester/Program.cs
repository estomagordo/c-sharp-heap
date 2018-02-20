using Heap;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var list = new List<int>();

            for (var i = 0; i < 1000000; i++)
            {
                list.Add(random.Next());
            }

            var sw = new Stopwatch();

            sw.Start();
            var heap = new Heap<int>(list);
            var heapSorted = new List<int>();
            while (!heap.Empty)
            {
                heapSorted.Add(heap.Pop());
            }
            sw.Stop();
            Console.WriteLine("Heap sort took " + sw.ElapsedMilliseconds + " milliseconds.");

            sw.Reset();
            sw.Start();
            list = list.OrderByDescending(item => item).ToList();
            sw.Stop();
            Console.WriteLine("List sort took " + sw.ElapsedMilliseconds + " milliseconds.");

            Console.WriteLine("Results are " + (heapSorted.SequenceEqual(list) ? "equal" : "not equal"));

            Console.Read();
        }
    }
}
