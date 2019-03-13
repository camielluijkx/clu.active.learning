using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace clu.active.learning
{
    /*
    
    Introducing multithreading into your applications has many advantages in terms of performance and 
    responsiveness. However, it also introduces new challenges. When you can simultaneously update a 
    resource from multiple threads, the resource can become corrupted or can be left in an unpredictable 
    state. 

    There are various synchronization techniques to ensure to access resources in a thread-safe manner.
    In other words, in a way that prevents concurrent access from having unpredictable effects. 

    */
    public static class Concurrency
    {
        #region Implementation

        class Coffee
        {
            private object coffeeLock = new object();

            int stock;

            public Coffee(int initialStock)
            {
                stock = initialStock;
            }

            public bool MakeCoffees(int coffeesRequired)
            {
                lock (coffeeLock)
                {
                    if (stock >= coffeesRequired)
                    {
                        Console.WriteLine(String.Format("Stock level before making coffees: {0}", stock));
                        stock = stock - coffeesRequired;
                        Console.WriteLine(String.Format("{0} coffees made", coffeesRequired));
                        Console.WriteLine(String.Format("Stock level after making coffees: {0}", stock));
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient stock to make coffees");
                        return false;
                    }
                }
            }
        }

        private static ConcurrentQueue<string> _queue = new ConcurrentQueue<string>();

        private static void placeOrders()
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(250);
                String order = String.Format("Order {0}", i);
                _queue.Enqueue(order);
                Console.WriteLine("Added {0}", order);
            }
        }

        private static void processOrders()
        {
            while (true) // continue indefinitely
            {
                string order;
                
                if (_queue.TryDequeue(out order))
                {
                    Console.WriteLine("Processed {0}", order);
                }
            }
        }

        #endregion

        #region Public Methods

        /*
        
        When you introduce multithreading into your applications, you can often encounter situations 
        in which a resource is simultaneously accessed from multiple threads. If each of these threads 
        can alter the resource, the resource can end up in an unpredictable state. For example, suppose 
        you create a class that manages stock levels of coffee. When you place an order for a number of 
        coffees, a method in the class will: 

            1. Check the current stock level.
            2. If sufficient stock exists, make the coffees.
            3. Subtract the number of coffees from the current stock level.

        If only one thread can call this method at any one time, everything will work fine. However, 
        suppose two threads call this method at the same time. The current stock level might change 
        between steps 1 and 2, or between steps 2 and 3, making it impossible to keep track of the 
        current stock level and establish whether you have sufficient stock to make a coffee. 

        To solve this problem, you can use the lock keyword to apply a mutual-exclusion lock to critical 
        sections of code. A mutual-exclusion lock means that if one thread is accessing the critical 
        section, all other threads are locked out. To apply a lock, you use the following syntax: 

            lock ( object ) { statement block } 

        The first thing to notice is that you apply the lock to an object. This is because the lock works 
        by ensuring that only one thread can access that object at any one time. This object should be 
        private and should serve no other role in your logic; its purpose is to provide something for the 
        lock keyword to make mutually exclusive. Next, you put your critical section of code inside the 
        lock block. While the lock statement is in scope, only one thread can enter the critical section 
        at any one time. 

        */
        public static void UsingLocks()
        {
            Console.WriteLine("* Using Locks");
            {
                /*
                
                The lock statement ensures that only one thread can enter the critical section of code 
                within the MakeCoffee method at any one time.

                */
                Console.WriteLine("** Using the Lock Keyword");
                {
                    Coffee coffee = new Coffee(5);
                    coffee.MakeCoffees(2);
                    coffee.MakeCoffees(1);
                    coffee.MakeCoffees(3);
                }
            }

            Console.WriteLine("** Using SyncLock");
            {
                // TODO
            }

            Console.WriteLine("** Using Monitor");
            {
                // TODO
            }

            Console.WriteLine("** Using Mutex");
            {
                // TODO
            }
        }

        /*
        
        A synchronization primitive is a mechanism by which an operating system enables its users, in this 
        case the .NET runtime, to control the synchronization of threads. The Task Parallel Library supports 
        a wide range of synchronization primitives that enable you to control access to resources in a variety 
        of ways. These are the most commonly used synchronization primitives: 

            • The ManualResetEventSlim class enables one or more threads to wait for an event. A 
            ManualResetEventSlim object can be in one of two states: signaled and unsignaled. If a thread calls 
            the Wait method and the ManualResetEventSlim object is unsignaled, the thread is blocked until the ManualResetEventSlim object state changes to signaled. In your task logic, you can call the Set or 
            Reset methods on the ManualResetEventSlim object to change the state to signaled or unsignaled 
            respectively. You typically use the ManualResetEventSlim class to ensure that only one thread can 
            access a resource at any one time. 

            https://docs.microsoft.com/en-us/dotnet/api/system.threading.manualreseteventslim?view=netframework-4.7.2
       
            • The SemaphoreSlim class enables you to restrict access to a resource, or a pool of resources, to 
            a limited number of concurrent threads. The SemaphoreSlim class uses an integer counter to track the 
            number of threads that are currently accessing a resource or a pool of resources. When you create a 
            SemaphoreSlim object, you specify an initial value and an optional maximum value. When a thread wants 
            to access the protected resources, it calls the Wait method on the SemaphoreSlim object. If the value 
            of the SemaphoreSlim object is above zero, the counter is decremented and the thread is granted access. 
            When the thread has finished, it should call the Release method on the SemaphoreSlim object, and the 
            counter is incremented. If a thread calls the Wait method and the counter is zero, the thread is blocked 
            until another thread calls the Release method. For example, if your coffee shop has three coffee machines 
            and each can only process one order at a time, you might use a SemaphoreSlim object to prevent more than 
            three threads simultaneously ordering a coffee. 

            https://docs.microsoft.com/en-us/dotnet/api/system.threading.semaphoreslim?view=netframework-4.7.2

            • The CountdownEvent class enables you to block a thread until a fixed number of threads have signaled 
            the CountdownEvent object. When you create a CountdownEvent object, you specify an initial integer value. 
            When a thread completes an operation, it can call the Signal method on the CountdownEvent object to 
            decrement the integer value. Any threads that call the Wait method on the CountdownEvent object are 
            blocked until the counter reaches zero. For example, if you need to run ten tasks before you continue 
            with your code, you can create a CountdownEvent object with an initial value of ten, signal the 
            CountdownEvent object from each task, and wait for the CountdownEvent object to reach zero before you 
            proceed. This is useful because your code can dynamically set the initial value of the counter depending 
            on how much work there is to be done. 

            https://docs.microsoft.com/en-us/dotnet/api/system.threading.countdownevent?view=netframework-4.7.2

            • The ReaderWriterLockSlim class enables you to restrict write access to a resource to one thread at a 
            time, while permitting multiple threads to read from the resource simultaneously. If a thread wants to 
            read the resource, it calls the EnterReadLock method, reads the resource, and then calls the ExitReadLock 
            method. If a thread wants to write to the resource, it calls the EnterWriteLock method. If one or more 
            threads have a read lock on the resource, the EnterWriteLock method blocks until all read locks are 
            released. When the thread has finished writing to the resource, it calls the ExitWriteLock method. Calls 
            to the EnterReadLock method are blocked until the write lock is released. As a result, at any one time, a 
            resource can be locked by either one writer or multiple readers. This type of read/write lock is useful in
            a wide range of scenarios. For example, a banking application might permit multiple threads to read an 
            account balance simultaneously, but a thread that wants to modify the account balance requires an exclusive 
            lock. 

            https://docs.microsoft.com/en-us/dotnet/api/system.threading.readerwriterlockslim?view=netframework-4.7.2

            • The Barrier class enables you to temporarily halt the execution of several threads until they have all 
            reached a particular point. When you create a Barrier object, you specify an initial number of participants. 
            You can change this number at a later date by calling the AddParticipant and RemoveParticipant methods. When 
            a thread reaches the synchronization point, it calls the SignalAndWait method on the Barrier object. This 
            decrements the Barrier counter and also blocks the calling thread until the counter reaches zero. When the 
            counter reaches zero, all threads are allowed to continue. The Barrier class is often used in forecasting 
            scenarios, where various tasks perform interrelated calculations on one time window and then wait for all 
            of the other tasks to reach the same point before performing interrelated calculations on the next time 
            window.

            https://docs.microsoft.com/en-us/dotnet/api/system.threading.barrier?view=netframework-4.7.2

            Many of these classes enable you to set timeouts in terms of the number of spins. When a thread is waiting 
            for an event, it spins. The length of time a spin takes depends on the computer that is running the thread. 
            For example, if you use the ManualResetEventSlim class, you can specify the maximum number of spins as an 
            argument to the constructor. If a thread is waiting for the ManualResetEventSlim object to signal and it 
            reaches the maximum number of spins, the thread is suspended and stops using processor resources. This 
            helps to ensure that waiting tasks do not consume excessive processor time. 

        */
        public static void UsingSynchronizationPrimitives()
        {
            Console.WriteLine("* Using Synchronization Primitives");
            {
                // TODO
            }
        }

        /*
        
        The standard collection classes in the .NET Framework are, by default, not thread-safe. When you 
        access collections from tasks or other multithreading techniques, you must ensure that you do not 
        compromise the integrity of the collections. One way to do this is to use the synchronization 
        primitives described earlier in this lesson to control concurrent access to your collections. 
        However, the .NET Framework also includes a set of collections that are specifically designed for 
        thread-safe access. The following table describes some of the classes and interfaces that the 
        System.Collections.Concurrent namespace provides.
        
        Class or interface                      Description
        ConcurrentBag<T>                        This class provides a thread-safe way to store an unordered 
                                                collection of items.
        ConcurrentDictionary<TKey, TValue>      This class provides a thread-safe alternative to the 
                                                Dictionary<TKey, TValue> class. 
        ConcurrentQueue<T>                      This class provides a thread-safe alternative to the Queue<T> 
                                                class. 
        ConcurrentStack<T>                      This class provides a thread-safe alternative to the Stack<T> 
                                                class. 
        IProducerConsumerCollection<T>          This interface defines methods for implementing classes that 
                                                exhibit producer/consumer behavior; in other words, classes 
                                                that distinguish between producers who add items to a 
                                                collection and consumers who read items from a collection. 
                                                This distinction is important because these collections need 
                                                to implement a read/write locking pattern, where the collection 
                                                can be locked either by a single writer or by multiple readers. 
                                                The ConcurrentBag<T>, ConcurrentQueue<T>, and ConcurrentStack<T> 
                                                classes all implement this interface. 
        BlockingCollection<T>                   This class acts as a wrapper for collections that implement the 
                                                IProducerConsumerCollection<T> interface. For example, it can 
                                                block read requests until a read lock is available, rather than 
                                                simply refusing a request if a lock is unavailable. You can also 
                                                use the BlockingCollection<T> class to limit the size of the
                                                underlying collection. In this case, requests to add items are 
                                                blocked until space is available. 

        https://docs.microsoft.com/en-us/dotnet/api/system.collections?view=netframework-4.7.2

        */
        public static void UsingConcurrentCollections()
        {
            Console.WriteLine("* Using Concurrent Collections");
            {
                /*
                
                Consider an order management system for Fourth Coffee that uses a ConcurrentQueue<T> object to 
                represent the queue of orders that customers have placed. Orders are added to the queue at a 
                single order point, but they can be picked up by one of three baristas working in the store.

                */
                Console.WriteLine("** Using the ConcurrentQueue<T> Collection");
                {
                    var taskPlaceOrders = Task.Run(() => placeOrders());

                    Task.Run(() => processOrders());
                    Task.Run(() => processOrders());
                    Task.Run(() => processOrders());

                    taskPlaceOrders.Wait();

                    Console.WriteLine("Press ENTER to finish");
                    Console.ReadLine();
                }
            }
        }

        #endregion
    }
}
