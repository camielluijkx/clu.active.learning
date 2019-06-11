using System;

namespace clu.active.learning.console
{
    public class CoalesceOperator
    {
        public static void Test()
        {
            int? a = null;
            int b = a ?? -1;
            Console.WriteLine(b); // -1

            Console.ReadLine();
        }
    }
}