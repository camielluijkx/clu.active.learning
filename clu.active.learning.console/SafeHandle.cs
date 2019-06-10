using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace clu.active.learning.console
{
    /*
    
    Represents a wrapper class for operating system handles. This class must be inherited.

    https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.safehandle?view=netframework-4.8

    */
    public class SafeHandle
    {
        static class SomeUnmanagedApiV1
        {
            [DllImport("SomeUnmanagedApi.dll")]
            public static extern IntPtr CreateSomething();

            [DllImport("SomeUnmanagedApi.dll")]
            public static extern void DoSomething(IntPtr handle);

            [DllImport("SomeUnmanagedApi.dll")]
            public static extern void ReleaseSomething(IntPtr handle);
        }

        static class SomeUnmanagedApiV2
        {
            [DllImport("SomeUnmanagedApi.dll")]
            public static extern SomeSafeHandle CreateSomething();

            [DllImport("SomeUnmanagedApi.dll")]
            public static extern void DoSomething(SomeSafeHandle handle);

            [DllImport("SomeUnmanagedApi.dll")]
            public static extern void ReleaseSomething(SomeSafeHandle handle);  
        }

        class MyClass1
        {
            readonly IntPtr handle;

            public MyClass1()
            {
                handle = SomeUnmanagedApiV1.CreateSomething();
            }

            ~MyClass1()
            {
                SomeUnmanagedApiV1.ReleaseSomething(handle);
            }
        }

        class MyClass2 : IDisposable
        {
            readonly IntPtr handle;

            public MyClass2()
            {
                handle = SomeUnmanagedApiV1.CreateSomething();
            }

            ~MyClass2()
            {
                Dispose(false);
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                SomeUnmanagedApiV1.ReleaseSomething(handle);

                if (disposing)
                {
                    // dispose managed resources
                }
            }
        }

        class SomeSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            public SomeSafeHandle(IntPtr handle)
                : base(true)
            {
                SetHandle(handle);
            }

            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            protected override bool ReleaseHandle()
            {
                SomeUnmanagedApiV1.ReleaseSomething(handle);
                return true;
            }
        }

        class MyClass3 : IDisposable
        {
            readonly SomeSafeHandle handle;

            public MyClass3()
            {
                handle = new SomeSafeHandle(SomeUnmanagedApiV1.CreateSomething());
            }

            public void Dispose()
            {
                handle.Dispose();
            }
        }

        public static void Test()
        {
            // ...

            Console.ReadLine();
        }
    }
}