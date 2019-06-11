using System;

namespace clu.active.learning.console
{
    public class Closures
    {
        public static Func<int, int> GetAFunc()
        {
            var myVar = 1;
            Func<int, int> inc = delegate (int var1)
            {
                myVar = myVar + 1;
                return var1 + myVar;
            };
            return inc;
        }

        public static void Test()
        {
            var inc = GetAFunc();
            Console.WriteLine(inc(5));
            Console.WriteLine(inc(6));

            Console.ReadLine();
        }
    }
}