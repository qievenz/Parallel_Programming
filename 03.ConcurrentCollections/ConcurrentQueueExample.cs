using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace _03.ConcurrentCollections
{
    public static class ConcurrentQueueExample
    {
        public static void Run()
        {
            var q = new ConcurrentQueue<int>();

            q.Enqueue(1);
            q.Enqueue(2);

            
            Parallel.For(0, 100, (i) =>
            {
                q.Enqueue(i);
            });

            
            int result;
            
            while (q.TryDequeue(out result))
            {
                Console.WriteLine($"Removed element {result}");
            }

            // Queue: 2 1 <- front

            //int last = q.Dequeue();
            if (q.TryDequeue(out result))
            {
                Console.WriteLine($"Removed element {result}");
            }

            // Queue: 2

            //int peeked = q.Peek();
            if (q.TryPeek(out result))
            {
                Console.WriteLine($"Last element is {result}");
            }
        }
    }
}
