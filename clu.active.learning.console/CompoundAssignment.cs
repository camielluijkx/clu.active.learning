using System;

namespace clu.active.learning.console
{
    public class CompoundAssignment
    {
        public static void Test()
        {
            bool test = true;
            //test &= false;
            test = test & false;
            Console.WriteLine(test);  // output: False

            //test |= true;
            test = test | true;
            Console.WriteLine(test);  // output: True

            //test ^= false;
            test = test ^ false;
            Console.WriteLine(test);  // output: True

            Console.WriteLine();
        }
    }
}