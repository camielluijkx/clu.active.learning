using System;
using System.Runtime.InteropServices;

namespace clu.active.learning
{
    public struct TypeSizeProxy<T>
    {
        public T PublicField;
    }

    public static class SizeCalculator
    {
        public static int SizeOf<T>()
        {
            try
            {
                return Marshal.SizeOf(typeof(T));
            }
            catch (ArgumentException)
            {
                return Marshal.SizeOf(new TypeSizeProxy<T>());
            }
        }

        public static int GetSize(this object obj)
        {
            return Marshal.SizeOf(obj);
        }
    }
}
