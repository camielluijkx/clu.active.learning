using System;

namespace clu.active.learning.console
{
    public class StringInterpolation
    {
        public static void Test()
        {
            var text = $"{DateTime.Now,6:HH:mm}";
            Console.WriteLine(text);

            Console.ReadLine();
        }
    }
}