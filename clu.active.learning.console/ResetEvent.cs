using System;
using System.Threading;
using System.Threading.Tasks;

namespace clu.active.learning.console
{
    /*
    
    https://docs.microsoft.com/en-us/dotnet/api/system.threading.autoresetevent?view=netframework-4.8

    https://docs.microsoft.com/en-us/dotnet/api/system.threading.manualresetevent?view=netframework-4.8
    
    */
    public class ResetEvent
    {
        public class AutoResetEventSample
        {
            private AutoResetEvent autoReset = new AutoResetEvent(false);

            public void RunAll()
            {
                new Thread(Worker1).Start();
                new Thread(Worker2).Start();
                new Thread(Worker3).Start();

                autoReset.Set();
                Thread.Sleep(1000);
                autoReset.Set();
                Console.WriteLine("Main thread reached to end.");
            }

            public void Worker1()
            {
                Console.WriteLine("Entered Worker1");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Worker1 is running {0}", i);
                    Thread.Sleep(2000);
                    autoReset.WaitOne();
                }
            }

            public void Worker2()
            {
                Console.WriteLine("Entered Worker2");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Worker2 is running {0}", i);
                    Thread.Sleep(2000);
                    autoReset.WaitOne();
                }
            }

            public void Worker3()
            {
                Console.WriteLine("Entered Worker3");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Worker3 is running {0}", i);
                    Thread.Sleep(2000);
                    autoReset.WaitOne();
                }
            }
        }

        public class ManualResetEventSample
        {
            private ManualResetEvent manualReset = new ManualResetEvent(false);

            public void RunAll()
            {
                new Thread(Worker1).Start();
                new Thread(Worker2).Start();
                new Thread(Worker3).Start();

                manualReset.Set();
                Thread.Sleep(1000);
                manualReset.Reset();
                Console.WriteLine("Press to release all threads.");
                Console.ReadLine();
                manualReset.Set();
                Console.WriteLine("Main thread reached to end.");
            }

            public void Worker1()
            {
                Console.WriteLine("Entered Worker1");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Worker1 is running {0}", i);
                    Thread.Sleep(2000);
                    manualReset.WaitOne();
                }
            }

            public void Worker2()
            {
                Console.WriteLine("Entered Worker2");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Worker2 is running {0}", i);
                    Thread.Sleep(2000);
                    manualReset.WaitOne();
                }
            }

            public void Worker3()
            {
                Console.WriteLine("Entered Worker3");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Worker3 is running {0}", i);
                    Thread.Sleep(2000);
                    manualReset.WaitOne();
                }
            }
        }

        public static void Test()
        {
            Console.WriteLine("AutoResetEventSample");
            AutoResetEventSample autoResetEventSample = new AutoResetEventSample();
            autoResetEventSample.RunAll();

            Console.ReadLine();

            Console.WriteLine("ManualResetEventSample");
            ManualResetEventSample manualResetEventSample = new ManualResetEventSample();
            manualResetEventSample.RunAll();

            Console.ReadLine();
        }
    }
}