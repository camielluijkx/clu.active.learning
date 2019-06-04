using System;
using System.Diagnostics;

namespace clu.active.learning.console
{
    public class ExplicitlyDisposable : IDisposable
    {
        void IDisposable.Dispose()
        {
            Debug.WriteLine("Disposal was called");
        }

        public void DoWork()
        {
            Console.WriteLine("DoWork");

            // Do some work that might throw an exception
            throw new NotImplementedException();
        }

        public static void Test()
        {
            //var target = new ExplicitlyDisposable(); // UE
            //try
            //{
            //    target.DoWork();
            //    // Do other work
            //    Console.WriteLine("DoOtherWork");
            //}
            //finally
            //{
            //    if (target != null)
            //    {
            //        ((IDisposable)target).Dispose();
            //    }
            //}

            //using (var target = new ExplicitlyDisposable()) // UE
            //{
            //    target.DoWork();
            //    // Do other work
            //    Console.WriteLine("DoOtherWork");
            //}

            //var target = new ExplicitlyDisposable(); // CE
            //try
            //{
            //    target.DoWork();
            //}
            //finally
            //{
            //    if (target != null)
            //    {
            //        target.Dispose();
            //    }
            //}

            var target = new ExplicitlyDisposable(); // UE
            try
            {
                target.DoWork();
                // Do some more work...
                Console.WriteLine("DoSomeMoreWork");
            }
            finally
            {
                ((IDisposable)target).Dispose();
            }

            //var target = new ExplicitlyDisposable(); // UE
            //target.DoWork();
            //// Do some more work...
            //Console.WriteLine("DoSomeMoreWork");
            //((IDisposable)target).Dispose();

            Console.ReadLine();
        }
    }
}