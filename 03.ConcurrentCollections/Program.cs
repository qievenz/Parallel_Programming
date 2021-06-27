using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace _03.ConcurrentCollections
{
    class Program
    {        
        static void Main(string[] args)
        {
            ConcurrentDictionaryExample.Run();
            ConcurrentQueueExample.Run();
            ConcurrentStackExample.Run();
            ConcurrentBagExample.Run();
            BlockingCollectionAndPubSubExample.Run();
        }
    }
}
