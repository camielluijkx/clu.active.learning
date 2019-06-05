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

        }
    }
}