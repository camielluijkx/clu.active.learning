using System;

namespace clu.active.learning.console
{
    public class Line
    {
        public static void Test()
        {
#line 200 "Special" // forces the next line's number to be 200 and until the next #line directive, the filename will be reported as "Special"
            int i;
            int j;
#line default // returns the line numbering to its default numbering, which counts the lines that were renumbered by the previous directive
            char c;
            float f;
#line hidden // numbering not affected
            string s;
            double d;

            Console.ReadLine();
        }
    }
}
