using System;
using System.Threading;

namespace clu.active.learning.console
{
    public class ThreadJoin
    {
        static Thread thread1, thread2;

        private static void threadStart1()
        {
            Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
            if (Thread.CurrentThread.Name == "Thread1" &&
                thread2.ThreadState != ThreadState.Unstarted)
                thread2.Join();

            Thread.Sleep(4000);
            Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
            Console.WriteLine("Thread1: {0}", thread1.ThreadState);
            Console.WriteLine("Thread2: {0}\n", thread2.ThreadState);
        }

        private static void threadStart2()
        {
            Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
            if (Thread.CurrentThread.Name == "Thread1" &&
                thread2.ThreadState != ThreadState.Unstarted)
                if (thread2.Join(2000))
                    Console.WriteLine("Thread2 has termminated.");
                else
                    Console.WriteLine("The timeout has elapsed and Thread1 will resume.");

            Thread.Sleep(4000);
            Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
            Console.WriteLine("Thread1: {0}", thread1.ThreadState);
            Console.WriteLine("Thread2: {0}\n", thread2.ThreadState);
        }

        public static void Test()
        {
            thread1 = new Thread(threadStart1);
            thread1.Name = "Thread1";
            thread1.Start();

            thread2 = new Thread(threadStart1);
            thread2.Name = "Thread2";
            thread2.Start();

            Console.ReadLine();

            // The example displays output like the following:
            //       Current thread: Thread1
            //       
            //       Current thread: Thread2
            //       
            //       Current thread: Thread2
            //       Thread1: WaitSleepJoin
            //       Thread2: Running
            //       
            //       
            //       Current thread: Thread1
            //       Thread1: Running
            //       Thread2: Stopped

            thread1 = new Thread(threadStart2);
            thread1.Name = "Thread1";
            thread1.Start();

            thread2 = new Thread(threadStart2);
            thread2.Name = "Thread2";
            thread2.Start();

            Console.ReadLine();

            // The example displays the following output:
            //       Current thread: Thread1
            //       
            //       Current thread: Thread2
            //       The timeout has elapsed and Thread1 will resume.
            //       
            //       Current thread: Thread2
            //       Thread1: WaitSleepJoin
            //       Thread2: Running
            //       
            //       
            //       Current thread: Thread1
            //       Thread1: Running
            //       Thread2: Stopped
        }
    }
}