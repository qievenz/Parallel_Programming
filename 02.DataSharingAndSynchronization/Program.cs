using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace _02.DataSharingAndSynchronization
{
    public class BankAccount
    {
        private int balance;

        public int Balance { get => balance; set => balance = value; }

        public void Deposit(int amount)
        {
            balance += amount;
        }

        public void Withdraw(int amount)
        {
            balance -= amount;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var ba = new BankAccount();
            var tasks = new List<Task>();
            var spinLock = new SpinLock();

            for (int i = 0; i < 10; i++)
            {
                var lockTaken = false;

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        var lockTaken = false;
                        try
                        {
                            spinLock.Enter(ref lockTaken);
                            ba.Deposit(100);
                        }
                        finally
                        {
                            if (lockTaken) spinLock.Exit();
                        }
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        var lockTaken = false;
                        try
                        {
                            spinLock.Enter(ref lockTaken);
                            ba.Withdraw(100);
                        }
                        finally
                        {
                            if (lockTaken) spinLock.Exit();
                        }
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine(ba.Balance);
        }
    }
}
