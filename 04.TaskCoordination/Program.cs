using System;
using System.Threading.Tasks;

namespace _04.TaskCoordination
{
    class Program
    {
        static void Main(string[] args)
        {
            ContinuationsDemo.Run();
            ChildTasks.Run();
            BarrierDemo.Run();
            CountDownEventDemo.Run();
            ResetEventsDemo.Run();
            SemaphoreDemo.Run();
        }
    }
}
