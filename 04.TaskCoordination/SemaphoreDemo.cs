using System;
using System.Threading.Tasks;
using System.Threading;

namespace _04.TaskCoordination
{
    public class SemaphoreDemo
    {
        public static void Run()
        {
            var semaphore = new SemaphoreSlim(2, 10);

            for (int i = 0; i < 20; ++i)
            {
                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"Entering task {Task.CurrentId}.");
                    semaphore.Wait(); // ReleaseCount--
                    Console.WriteLine($"Processing task {Task.CurrentId}.");
                });
            }

            while (semaphore.CurrentCount <= 2)
            {
                Console.WriteLine($"Semaphore count: {semaphore.CurrentCount}");
                Console.ReadKey();
                semaphore.Release(2); // ReleaseCount += n
            }
        }
    }
}
