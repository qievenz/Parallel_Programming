using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _02.DataSharingAndSynchronization
{
    public class BankAccount
    {
        public object padlock = new object();
        public int Balance { get; set; }

        public void Deposit(int amount)
        {
            lock (padlock)
            {
                Balance += amount;
            }
        }

        public void Withdraw(int amount)
        {
            lock (padlock)
            {
                Balance -= amount;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var ba = new BankAccount();
            var tasks = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        ba.Deposit(100);
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        ba.Withdraw(100);
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine(ba.Balance);
        }
    }
}
