using System;

namespace clu.active.learning.console
{
    /*
    
    https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/unsafe

    */
    public class Unsafe
    {
        // Error CS0227  Unsafe code may only appear if compiling with /unsafe (Build > Allow unsafe code)
        public unsafe static void FastCopy1(byte[] src, byte[] dst, int count)
        {
            // Unsafe context: can use pointers here.
        }

        public unsafe static void FastCopy2(byte* ps, byte* pd, int count)
        {

        }

        public unsafe static void SquarePtrParam(int* p)
        {
            *p *= *p;
        }

        public static void Test()
        {
            int i = 5;

            unsafe
            {
                SquarePtrParam(&i);
            }

            Console.WriteLine(i);

            Console.ReadLine();
        }
    }
}