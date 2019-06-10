using System;

namespace clu.active.learning.console
{
    /*
    
    https://docs.microsoft.com/en-us/dotnet/api/system.gc?view=netframework-4.8

        AddMemoryPressure(Int64)	
        Informs the runtime of a large allocation of unmanaged memory that should be taken into account when scheduling garbage collection.

        CancelFullGCNotification()	
        Cancels the registration of a garbage collection notification.

        Collect()	
        Forces an immediate garbage collection of all generations.

        Collect(Int32)	
        Forces an immediate garbage collection from generation 0 through a specified generation.

        Collect(Int32, GCCollectionMode)	
        Forces a garbage collection from generation 0 through a specified generation, at a time specified by a GCCollectionMode value.

        Collect(Int32, GCCollectionMode, Boolean)	
        Forces a garbage collection from generation 0 through a specified generation, at a time specified by a GCCollectionMode value, with a value specifying whether the collection should be blocking.

        Collect(Int32, GCCollectionMode, Boolean, Boolean)	
        Forces a garbage collection from generation 0 through a specified generation, at a time specified by a GCCollectionMode value, with values that specify whether the collection should be blocking and compacting.

        CollectionCount(Int32)	
        Returns the number of times garbage collection has occurred for the specified generation of objects.

        EndNoGCRegion()	
        Ends the no GC region latency mode.

        GetAllocatedBytesForCurrentThread()	
        Gets the total number of bytes allocated to the current thread since the beginning of its lifetime.

        GetGeneration(Object)	
        Returns the current generation number of the specified object.

        GetGeneration(WeakReference)	
        Returns the current generation number of the target of a specified weak reference.

        GetTotalMemory(Boolean)	
        Retrieves the number of bytes currently thought to be allocated. A parameter indicates whether this method can wait a short interval before returning, to allow the system to collect garbage and finalize objects.

        KeepAlive(Object)	
        References the specified object, which makes it ineligible for garbage collection from the start of the current routine to the point where this method is called.

        RegisterForFullGCNotification(Int32, Int32)	
        Specifies that a garbage collection notification should be raised when conditions favor full garbage collection and when the collection has been completed.

        RemoveMemoryPressure(Int64)	
        Informs the runtime that unmanaged memory has been released and no longer needs to be taken into account when scheduling garbage collection.

        ReRegisterForFinalize(Object)	
        Requests that the system call the finalizer for the specified object for which SuppressFinalize(Object) has previously been called.

        SuppressFinalize(Object)	
        Requests that the common language runtime not call the finalizer for the specified object.

        TryStartNoGCRegion(Int64)	
        Attempts to disallow garbage collection during the execution of a critical path if a specified amount of memory is available.

        TryStartNoGCRegion(Int64, Boolean)	
        Attempts to disallow garbage collection during the execution of a critical path if a specified amount of memory is available, and controls whether the garbage collector does a full blocking garbage collection if not enough memory is initially available.

        TryStartNoGCRegion(Int64, Int64)	
        Attempts to disallow garbage collection during the execution of a critical path if a specified amount of memory is available for the large object heap and the small object heap.

        TryStartNoGCRegion(Int64, Int64, Boolean)	
        Attempts to disallow garbage collection during the execution of a critical path if a specified amount of memory is available for the large object heap and the small object heap, and controls whether the garbage collector does a full blocking garbage collection if not enough memory is initially available.

        WaitForFullGCApproach()	
        Returns the status of a registered notification for determining whether a full, blocking garbage collection by the common language runtime is imminent.

        WaitForFullGCApproach(Int32)	
        Returns, in a specified time-out period, the status of a registered notification for determining whether a full, blocking garbage collection by the common language runtime is imminent.

        WaitForFullGCComplete()	
        Returns the status of a registered notification for determining whether a full, blocking garbage collection by the common language runtime has completed.

        WaitForFullGCComplete(Int32)	
        Returns, in a specified time-out period, the status of a registered notification for determining whether a full, blocking garbage collection by common language the runtime has completed.

        WaitForPendingFinalizers()	
        Suspends the current thread until the thread that is processing the queue of finalizers has emptied that queue.

    */
    public class GarbageCollector
    {
        public static void Test()
        {
            // ...

            Console.ReadLine();
        }
    }
}