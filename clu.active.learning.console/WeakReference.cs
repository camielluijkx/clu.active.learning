using System;
using System.Text;
using System.Threading;

namespace clu.active.learning.console
{
    /*
    
    https://docs.microsoft.com/en-us/dotnet/api/system.weakreference?view=netframework-4.8

    https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/weak-references?view=netframework-4.8

    */
    public class WeakReference
    {
        public static void Test()
        {
            StringBuilder shortBuilder = new StringBuilder("short weak reference test");
            System.WeakReference shortWeakReference = new System.WeakReference(shortBuilder, false);
            //if (shortWeakReference.IsAlive)
            //{
            //    Console.WriteLine("short weak reference is alive");
            //    Console.WriteLine((shortWeakReference.Target as StringBuilder).ToString());
            //}
            shortBuilder = null;
            GC.Collect();
            if (shortWeakReference.IsAlive)
            {
                Console.WriteLine("short weak reference is alive");
                Console.WriteLine((shortWeakReference.Target as StringBuilder).ToString()); // Target might be null
            }

            StringBuilder longBuilder = new StringBuilder("long weak reference test");
            System.WeakReference longWeakReference = new System.WeakReference(longBuilder, true);
            //if (longWeakReference.IsAlive)
            //{
            //    Console.WriteLine("long weak reference is alive");
            //    Console.WriteLine((longWeakReference.Target as StringBuilder).ToString());
            //}
            longBuilder = null;
            GC.Collect();
            if (longWeakReference.IsAlive)
            {
                Console.WriteLine("long weak reference is alive");
                Console.WriteLine((longWeakReference.Target as StringBuilder).ToString());
            }

            StringBuilder normalBuilder = new StringBuilder("normal reference test");
            normalBuilder = null;
            GC.Collect();
            //Console.WriteLine(normalBuilder.ToString());

            Console.ReadLine();
        }
    }
}