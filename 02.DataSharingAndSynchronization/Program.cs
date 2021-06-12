namespace _02.DataSharingAndSynchronization
{
    public static class Program
    {
        public static void Main()
        {
            CriticalSections.Run();
            InterlockedOperations.Run();
            ReaderWriterLocks.Run();
            MutexExample.Run();
            SpinLocking.Run();
        }
    }
}
