using System;
using System.Threading;

namespace clu.active.learning.console
{
    /*

    Semaphore

    Limits the number of threads that can access a resource or pool of resources concurrently (derived from WaitHandle).

    https://docs.microsoft.com/en-us/dotnet/api/system.threading.semaphore?view=netframework-4.8

    SemaphoreSlim

    Represents a lightweight alternative to Semaphore that limits the number of threads that can access a resource or pool 
    of resources concurrently.

    Difference:

    A difference is that SemaphoreSlim does not permit named semaphores, which can be system-wide. This would mean that a 
    SemaphoreSlim could not be used for cross-process synchronization.

    SemaphoreSlim should be used when "wait times are expected to be very short".

    https://docs.microsoft.com/en-us/dotnet/api/system.threading.semaphoreslim?view=netframework-4.8

    */
    public class Semaphore
    {
        // A semaphore that simulates a limited resource pool.
        private static System.Threading.Semaphore _semaphore;

        // A padding interval to make the output more orderly.
        private static int _padding;

        private static void Worker(object num)
        {
            // Each worker thread begins by requesting the semaphore.
            Console.WriteLine("Thread {0} begins and waits for the semaphore.", num);
            _semaphore.WaitOne();

            // A padding interval to make the output more orderly.
            int padding = Interlocked.Add(ref _padding, 100);

            Console.WriteLine("Thread {0} enters the semaphore.", num);

            // The thread's "work" consists of sleeping for about a second. Each thread "works" a little longer, just to make 
            // the output more orderly.
            Thread.Sleep(1000 + padding);

            Console.WriteLine("Thread {0} releases the semaphore.", num);
            Console.WriteLine("Thread {0} previous semaphore count: {1}", num, _semaphore.Release());
        }

        public static void Test()
        {
            Console.WriteLine("Semaphore");

            // Create a semaphore that can satisfy up to three concurrent requests. Use an initial count of zero, so that the 
            // entire semaphore count is initially owned by the main program thread.
            _semaphore = new System.Threading.Semaphore(0, 3);

            // Create and start five numbered threads. 
            for (int i = 1; i <= 5; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(Worker));

                // Start the thread, passing the number.
                t.Start(i);
            }

            // Wait for half a second, to allow all the threads to start and to block on the semaphore.
            Thread.Sleep(500);

            // The main thread starts out holding the entire semaphore count. Calling Release(3) brings the semaphore count back 
            // to its maximum value, and allows the waiting threads to enter the semaphore, up to three at a time.
            Console.WriteLine("Main thread calls Release(3).");
            _semaphore.Release(3);

            Console.WriteLine("Main thread exits.");

            Console.ReadLine();
        }
    }
}