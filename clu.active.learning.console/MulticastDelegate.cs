using System;

namespace clu.active.learning.console
{
    /*
    
    https://docs.microsoft.com/en-us/dotnet/api/system.multicastdelegate?view=netframework-4.8

    */
    public class MulticastDelegate
    {
        delegate void CustomDelegate(string someString);

        static void Hello(string someString)
        {
            Console.WriteLine($"Hello, {someString}!");
        }

        static void Goodbye(string someString)
        {
            Console.WriteLine($"Goodbye, {someString}!");
        }

        public static void Test()
        {
            CustomDelegate hiDelegate, byeDelegate, multiDelegate, multiMinusHiDelegate;

            hiDelegate = Hello;
            byeDelegate = Goodbye; 
            multiDelegate = hiDelegate + byeDelegate;
            multiMinusHiDelegate = multiDelegate - hiDelegate;

            Console.WriteLine("Invoking delegate hiDelegate:");
            hiDelegate("A");
            Console.WriteLine("Invoking delegate byeDelegate:");
            byeDelegate("B");
            Console.WriteLine("Invoking delegate multiDelegate:");
            multiDelegate("C");
            Console.WriteLine("Invoking delegate multiMinusHiDelegate:");
            multiMinusHiDelegate("D");

            Console.ReadLine();
        }
    }
}