using System;

namespace clu.active.learning.console
{
    /*
    
    https://docs.microsoft.com/en-us/dotnet/api/system.threading.mutex?view=netframework-4.8

    */
    public class Mutex
    {
        private static System.Threading.Mutex _mutex;

        private static bool isSingleInstance()
        {
            try
            {
                System.Threading.Mutex.OpenExisting("mutex");
            }
            catch
            {
                _mutex = new System.Threading.Mutex(true, "mutex");

                return true;
            }

            return false;
        }

        private readonly object syncLock = new object();
        public void ThreadSafeMethod1()
        {
            lock (syncLock)
            {
                /* critical code */
            }
        }

        private readonly System.Threading.Mutex m = new System.Threading.Mutex();
        public void ThreadSafeMethod2()
        {
            m.WaitOne();
            try
            {
                /* critical code */
            }
            finally
            {
                m.ReleaseMutex();
            }
        }

        public static void Test()
        {
            if (!isSingleInstance())
            {
                Console.WriteLine("multiple instances");
            }
            else
            {
                Console.WriteLine("single instance");
            }

            Console.ReadLine();
        }
    }
}