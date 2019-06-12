using System;

namespace clu.active.learning.console
{
    class Program
    {
        static void Main(string[] args)
        {
            //TaskExecutor.Test();
            //ExplicitlyDisposable.Test();

            //ExplicitImplicitOperator.Test();
            //ExpressionBodyDefinition.Test();

#if (BETA)
            StringInterpolation.Test();
#endif

            //DebuggerDisplay.Test();
            //StringCollection.Test();
            //LazyInitialization.Test();
            //EnumFlags.Test();

            //WeakReference.Test();
            //MulticastDelegate.Test();
            //DataContractSurrogate.Test();

            //Mutex.Test();
            //Unsafe.Test();

            //PrincipalPermission.Test();
            //ProtectionScope.Test();

            //ResetEvent.Test();

            //Equatable.Test();
            //ValidateableObject.Test();

            //GarbageCollector.Test();
            AccessModifiers.Test();

            //PerformanceCounterType.Test();

            //SafeHandle.Test();
            //WaitHandle.Test();

            //Semaphore.Test();
            //ReaderWriterLockSlim.Test();

            //Action.Test();
            //LocalFunction.Test();

            //CompoundAssignment.Test();
            //CoalesceOperator.Test();

            //Switch.Test();

            //WhenException.Test();

            //Closures.Test();
            //Predicate.Test();

            //Line.Test();

            //ThreadJoin.Test();

            //var date = new DateTime(2013, 04, 21, 14, 0, 0);
            //var temp = 19.567;
            //string output = string.Format("Temperature at {0:t} on {0:MM/dd/yyyy}: {1:N2}", date, temp);
            //Console.WriteLine(output);

            Console.ReadLine();
        }
    }
}