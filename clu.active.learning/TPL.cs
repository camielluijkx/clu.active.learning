﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace clu.active.learning
{
    /*
     
    Task Parallel Library (TPL)

    Modern processors use threads to concurrently run multiple operations. If your application performs all of its 
    logic on a single thread, you do not make the best use of the available processing resources, which can result in a 
    poor experience for your users. In this module, you will learn how to improve the performance of your applications 
    by distributing your operations across multiple threads.
    
    A typical graphical application consists of blocks of code that run when an event occurs; these events fire in 
    response to actions such as the user clicking a button, moving the mouse, or opening a window. By default, this 
    code runs by using the UI thread. However, you should avoid executing long-running operations on this thread 
    because they can cause the UI to become unresponsive. Also, running all of your code on a single thread does not 
    make good use of available processing power in the computer; most modern machines contain multiple processor cores, 
    and running all operations on a single thread will only use a single processor core. 

    The Microsoft® .NET Framework includes the Task Parallel Library. This is a set of classes that makes it easy to 
    distribute your code execution across multiple threads. You can run these threads on different processor cores and 
    take advantage of the parallelism that this model provides. You can assign long-running tasks to a separate thread, 
    leaving the UI thread free to respond to user actions. 

    */
    public static class TPL
    {
        #region Implementation

        private static void getTheTime()
        {
            Console.WriteLine("The time now is {0}", DateTime.Now);
        }

        private static void longRunningMethod(int taskNumber, int timeout)
        {
            Thread.Sleep(timeout);

            Console.WriteLine($"Long running task {taskNumber} has completed.");
        }

        private static void doWorkUntilIsCancellationRequested(CancellationToken token)
        {
            Console.WriteLine("Started doing some work.");

            // Check for cancellation.
            if (token.IsCancellationRequested)
            {
                // Tidy up and finish.
                Console.WriteLine("Cancelled doing some work.");
                return;
            }

            // If the task has not been cancelled, continue running as normal.
            Console.WriteLine("Finished doing some work.");
        }

        private static void doWorkAndThrowIfCancellationRequested(CancellationToken token)
        {
            Console.WriteLine("Started doing some work.");

            // Throw an OperationCanceledException if cancellation was requested.
            token.ThrowIfCancellationRequested();

            // If the task has not been cancelled, continue running as normal.
            Console.WriteLine("Finished doing some work.");
        }

        public class Coffee
        {
            public string Name { get; set; }

            public int Strength { get; set; }

            public Coffee(string name, int strength)
            {
                Name = name;
                Strength = strength;
            }
        }

        private static void checkAvailability(Coffee coffee)
        {
            Console.WriteLine($"Coffee {coffee.Name} is available.");
        }

        private static void doWork(CancellationToken token)
        {
            for (int i = 0; i< 100; i++)
            {
                Thread.SpinWait(500000);

                // Throw an OperationCanceledException if cancellation was requested.
                token.ThrowIfCancellationRequested();
            }
        }

        #endregion

        #region Public Methods

        /*

        The Task class lies at the heart of the Task Parallel Library in the .NET Framework. As the name suggests, you 
        use the Task class to represent a task, or in other words, a unit of work. The Task class enables you to 
        perform multiple tasks concurrently, each on a different thread. Behind the scenes, the Task Parallel Library 
        manages the thread pool and assigns tasks to threads. You can implement sophisticated multitasking 
        functionality by using the Task Parallel Library to chain tasks, pause tasks, wait for tasks to complete before 
        continuing, and perform many other operations. 

        */
        public static void UsingTasks()
        {
            Console.WriteLine("* Using Tasks");
            {
                /*

                You create a new Task object by using the Task class. A Task object runs a block of code, and you 
                specify this code as a parameter to the constructor. You can provide this code in a method and create 
                an Action delegate that wraps this method.

                The .NET Framework class library contains the built-in Action delegate that lets you quickly define a 
                delegate that has no return value and up to 16 parameters that use generic parameter types. It also 
                provides the Func delegate that returns a result. You can use these delegates instead of defining new 
                delegates for specific cases.

                */
                Console.WriteLine("** Creating a Task by Using an Action Delegate");
                {
                    Task task1 = new Task(new Action(getTheTime));
                }

                /*

                Using an Action delegate requires that you have defined a method that contains the code that you want 
                to run in a task. However, if the sole purpose of this method is to provide the logic for a task and it 
                is not reused anywhere else, you can find yourself creating (and having to remember the names of) a 
                substantial number of methods. This makes maintenance more difficult. A more common approach is to use 
                an anonymous method. An anonymous method is a method without a name, and you provide the code for an 
                anonymous method inline, at the point you need to it. You can use the delegate keyword to convert an 
                anonymous method into a delegate. 

                */
                Console.WriteLine("** Creating a Task by Using an Anonymous Delegate");
                {
                    Task task2 = new Task(delegate { Console.WriteLine("The time now is {0}", DateTime.Now); });
                }

                /*

                A lambda expression is a shorthand syntax that provides a simple and concise way to define anonymous 
                delegates. When you create a Task instance, you can use a lambda expression to define the delegate that 
                you want to associate with your task. 

                If you want your delegate to invoke a named method or a single line of code, you use can use a lambda 
                expression. A lambda expression provides a shorthand notation for defining a delegate that can take 
                parameters and return a result. It has the following form: 

                    (input parameters) => expression 

                In this case: 

                    • The lambda operator, =>, is read as “goes to.” 
                    • The left side of the lambda operator includes any variables that you want to pass to the 
                      expression. If you do not require any inputs—for example, if you are invoking a method that takes 
                      no parameters—you include empty parentheses () on the left side of the lambda operator. 

                The right side of the lambda operator includes the expression you want to evaluate. This could be a 
                comparison of the input parameters—for example, the expression (x, y) => x == y will return true if x 
                is equal to y; otherwise, it will return false. Alternatively, you can call a method on the right side 
                of the lambda operator. 

                */
                Console.WriteLine("** Using a Lambda Expression to Invoke a Named Method");
                {
                    Task task1 = new Task(() => getTheTime());
                    // This is equivalent to: Task task1 = new Task( delegate(getTheTime) );
                }

                /*

                A lambda expression can be a simple expression or function call, as the previous example shows, or it 
                can reference a more substantial block of code. To do this, specify the code in curly braces (like the 
                body of a method) on the right side of the lambda operator: 

                    (input parameters) => { Visual C# statements; } 

                As your delegates become more complex, lambda expressions offer a far more concise and easily 
                understood way to express anonymous delegates and anonymous methods. As such, lambda expressions are 
                the recommended approach when you work with tasks. 

                https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions

                */
                Console.WriteLine("** Using a Lambda Expression to Invoke an Anonymous Method");
                {
                    Task task2 = new Task(() => Console.WriteLine("Test"));
                    // This is equivalent to: Task task2 = new Task( delegate { Console.WriteLine("Test") } );
                }
            }
        }

        /*

        The Task Parallel Library offers several different approaches that you can use to start tasks. There are also 
        various different ways in which you can pause the execution of your code until one or more tasks have 
        completed.  

        */
        public static void ControllingTaskExecution()
        {
            Console.WriteLine("* Controlling Task Execution");
            {
                /*

                When your code starts a task, the Task Parallel Library assigns a thread to your task and starts 
                running that task. The task runs on a separate thread, so your code does not need to wait for the task 
                to complete. Instead, the task and the code that invoked the task continue to run in parallel. 

                If you want to queue the task immediately, you use the Start method.

                */
                Console.WriteLine("** Using the Task.Start Method to Queue a Task");
                {
                    var task1 = new Task(() => Console.WriteLine("Task 1 has completed."));
                    task1.Start();
                }

                /*

                Alternatively, you can use the static TaskFactory class to create and queue a task with a single line 
                of code. The TaskFactory class is exposed through the static Factory property of the Task class.

                */
                Console.WriteLine("** Using the TaskFactory.StartNew Method to Queue a Task");
                {
                    var task3 = Task.Factory.StartNew(() => Console.WriteLine("Task 3 has completed."));
                }

                /*

                The Task.Factory.StartNew method is highly configurable and accepts a wide range of parameters. If you 
                simply want to queue some code with the default scheduling options, you can use the static Task.Run 
                method as a shortcut for the Task.Factory.StartNew method. 

                */
                Console.WriteLine("** Using the Task.Run Method to Queue a Task");
                {
                    var task4 = Task.Run(() => Console.WriteLine("Task 4 has completed."));
                }
            }
        }

        /*

        In some cases, you may need to pause the execution of your code until a particular task has completed. 
        Typically you do this if your code depends on the result from one or more tasks, or if you need to handle 
        exceptions that a task may throw. The Task class offers various mechanisms to do this: 

            • If you want to wait for a single task to finish executing, use the Task.Wait method. 
            • If you want to wait for multiple tasks to finish executing, use the static Task.WaitAll method. 
            • If you want to wait for any one of a collection of tasks to finish executing, use the static Task.WaitAny 
              method. 

        */
        public static void WaitingForTasks()
        {
            Console.WriteLine("* Waiting for Tasks");
            {
                Console.WriteLine("** Waiting for a Single Task to Complete");
                {
                    var task1 = Task.Run(() => longRunningMethod(1, 5000));
                    // Do some other work.
                    // Wait for task 1 to complete.
                    task1.Wait();
                    // Continue with execution.
                }

                /*

                If you want to wait for multiple tasks to finish executing, or for one of a collection of tasks to 
                finish executing, you must add your tasks to an array. You can then pass the array of tasks to the 
                static Task.WaitAll or Task.WaitAny methods. 

                */
                Console.WriteLine("** Waiting for Multiple Tasks to Complete");
                {
                    Task[] tasks = new Task[3]
                    {
                       Task.Run( () => longRunningMethod(2, 2000)),
                       Task.Run( () => longRunningMethod(3, 1000)),
                       Task.Run( () => longRunningMethod(4, 500))
                    };

                    // Wait for any of the tasks to complete.
                    Task.WaitAny(tasks);
                    // Alternatively, wait for all of the tasks to complete.
                    Task.WaitAll(tasks);
                    // Continue with execution.
                }
            }
        }

        /*

        For tasks to be effective in real-world scenarios, you need to be able to create tasks that can return values, 
        or results, to the code that initiated the task. The regular Task class does not enable you to do this. 
        However, the Task Parallel Library also includes the generic Task<TResult> class that you can use when you need 
        to return a value. 

        */
        public static void ReturningTaskValues()
        {
            Console.WriteLine("* Returning Task Values");
            {
                /*

                When you create an instance of Task<TResult>, you use the type parameter to specify the  type of the 
                result that the task will return. The Task<TResult> class exposes a read-only property named Result. 
                After the task has finished executing, you can use the Result property to retrieve the return value of 
                the task. The Result property is the same type as the task’s type parameter. 

                If you access the Result property before the task has finished running, your code will wait until a 
                result is available before proceeding. 

                */
                Console.WriteLine("** Retrieving a Value from a Task");
                {
                    // Create and queue a task that returns the day of the week as a string.
                    Task<string> task1 = Task.Run<string>(() => DateTime.Now.DayOfWeek.ToString());
                    // Retrieve and display the task result.
                    Console.WriteLine(task1.Result);
                }
            }
        }

        /*

        Tasks are often used to perform long-running operations without blocking the UI thread, because of their 
        asynchronous nature. In some cases, you will want to give your users the opportunity to cancel a task if they 
        are tired of waiting. However, it would be dangerous to simply abort the task on demand, because this could 
        leave your application data in an unknown state. Instead, the Task Parallel Library uses cancellation tokens to 
        support a cooperative cancellation model. At a high level, the cancellation process works as follows: 

            1. When you create a task, you also create a cancellation token.
            2. You pass the cancellation token as an argument to your delegate method.
            3. On the thread that created the task, you request cancellation by calling the Cancel method on the 
              cancellation token source. 
            4. In your task method, you can check the status of the cancellation token at any point. If the instigator 
              has requested that the task be cancelled, you can terminate your task logic gracefully, possibly rolling 
              back any changes resulting from the work that the task has performed. 

        Typically, you would check whether the cancellation token has been set to canceled at one or more convenient 
        points in your task logic. For example, if your task logic iterates over a collection, you might check for 
        cancellation after each iteration. 

        https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/task-cancellation

        https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-cancel-a-task-and-its-children

        */
        public static void CancellingTasks()
        {
            Console.WriteLine("* Cancelling Tasks");
            {
                /*
                
                This approach works well if you do not need to check whether the task ran to completion. Each task 
                exposes a Status property that enables you to monitor the current status of the task in the task life 
                cycle. If you cancel a task by returning the task method, as shown in the previous example, the task 
                status is set to RanToCompletion. In other words, the task has no way of knowing why the method 
                returned—it may have returned in response to a cancellation request, or it may simply have completed 
                its logic. 

                */
                Console.WriteLine("** Cancelling a Task");
                {
                    // Create a cancellation token source and obtain a cancellation token.
                    CancellationTokenSource cts = new CancellationTokenSource();
                    CancellationToken ct = cts.Token;
                    
                    // Create and start a task.
                    Task.Run(() => doWorkUntilIsCancellationRequested(ct));
                }

                /*
                
                If you want to cancel a task and be able to confirm that it was cancelled, you need to pass the 
                cancellation token as an argument to the task constructor in addition to the delegate method. In your 
                task method, you check the status of the cancellation token. If the instigator has requested the 
                cancellation of the task, you throw an OperationCanceledException exception. When an 
                OperationCanceledException exception occurs, the Task Parallel Library checks the cancellation token to 
                verify whether a cancellation was requested. If it was, the Task Parallel Library handles the 
                OperationCanceledException exception, sets the task status to Canceled, and throws a 
                TaskCanceledException exception. In the code that created the cancellation request, you can catch this 
                TaskCanceledException exception and deal with the cancellation accordingly. 

                To check whether a cancellation was requested and throw an OperationCanceledException exception if it 
                was, you call the ThrowIfCancellationRequested method on the cancellation token. 

                */
                Console.WriteLine("** Cancelling a Task by Throwing an Exception");
                {
                    // Create a cancellation token source and obtain a cancellation token.
                    CancellationTokenSource cts = new CancellationTokenSource();
                    CancellationToken ct = cts.Token;

                    // Create and start a task.
                    Task.Run(() => doWorkAndThrowIfCancellationRequested(ct));
                }
            }
        }

        /*
        
        The Task Parallel Library includes a static class named Parallel. The Parallel class provides a range of 
        methods that you can use to execute tasks simultaneously. 

        https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/data-parallelism-task-parallel-library

        */
        public static void RunningTasksInParallel()
        {
            Console.WriteLine("* Running Tasks in Parallel");
            {
                /*
                
                Executing a Set of Tasks Simultaneously 

                If you want to run a fixed set of tasks in parallel, you can use the Parallel.Invoke method. When you 
                call this method, you use lambda expressions to specify the tasks that you want to run simultaneously. 
                You do not need to explicitly create each task—the tasks are created implicitly from the delegates that 
                you supply to the Parallel.Invoke method.

                */
                Console.WriteLine("** Using the Parallel.Invoke Method");
                {
                    Parallel.Invoke(
                        () => longRunningMethod(1, 2000), 
                        () => longRunningMethod(2, 1000), 
                        () => longRunningMethod(3, 500));
                }

                /*
                
                The Parallel class also provides methods that you can use to run for and foreach loop iterations in 
                parallel. Clearly it will not always be appropriate to run loop iterations in parallel. For example, if 
                you want to compare sequential values, you must run your loop iterations sequentially. However, if each 
                loop iteration represents an independent operation, running loop iterations in parallel enables you to 
                maximize your use of the available processing power. 

                To run for loop iterations in parallel, you can use the Parallel.For method. This method has several 
                overloads to cater to many different scenarios. In its simplest form, the Parallel.For method takes 
                three parameters: 

                    • An Int32 parameter that represents the start index for the operation, inclusive. 
                    • An Int32 parameter that represents the end index for the operation, exclusive. 
                    • An Action<Int32> delegate that is executed once per iteration. 

                */
                Console.WriteLine("** Using a Parallel.For Loop");
                {
                    int from = 0;
                    int to = 500000;

                    double[] array = new double[to];

                    // This is a sequential implementation:
                    for (int index = 0; index < 500000; index++)
                    {
                        array[index] = Math.Sqrt(index);
                    }

                    // This is the equivalent parallel implementation:
                    Parallel.For(from, to, index =>
                    {
                        array[index] = Math.Sqrt(index);
                    });
                }

                /*
                
                To run foreach loop iterations in parallel, you can use the Parallel.ForEach method. Like the 
                Parallel.For method, the Parallel.ForEach method includes many different overloads. In its simplest 
                form, the Parallel.ForEach method takes two parameters: 

                    • An IEnumerable<TSource> collection that you want to iterate over. 
                    • An Action<TSource> delegate that is executed once per iteration. 

                */
                Console.WriteLine("** Using a Parallel.ForEach Loop");
                {
                    var coffeeList = new List<Coffee>();
                    coffeeList.Add(new Coffee("Cappuchino", 1));
                    coffeeList.Add(new Coffee("Americano", 2));
                    coffeeList.Add(new Coffee("Espresso", 3));

                    // This is a sequential implementation:
                    foreach (Coffee coffee in coffeeList)
                    {
                        checkAvailability(coffee);
                    }

                    // This is the equivalent parallel implementation:
                    Parallel.ForEach(coffeeList, coffee => checkAvailability(coffee));
                }
            }
        }

        /*
        
        Parallel LINQ (PLINQ) is an implementation of Language-Integrated Query (LINQ) that supports parallel 
        operations. In most cases, PLINQ syntax is identical to regular LINQ syntax. 

        */
        public static void UsingPLINQ()
        {
            Console.WriteLine("* Using PLINQ");
            {
                /*
                
                When you write a LINQ expression, you can “opt in” to PLINQ by calling the AsParallel extension method 
                on your IEnumerable data source. 

                https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/parallel-linq-plinq

                */
                Console.WriteLine("** Using AsParallel (and ForAll)");
                {
                    var coffeeList = new List<Coffee>();
                    coffeeList.Add(new Coffee("Cappuchino", 1));
                    coffeeList.Add(new Coffee("Americano", 2));
                    coffeeList.Add(new Coffee("Espresso", 3));

                    var strongCoffees =
                       from coffee in coffeeList.AsParallel()
                       where coffee.Strength > 1
                       select coffee;

                    strongCoffees.ForAll(p => Console.WriteLine($"{p.Name} is a strong coffee."));
                }

                Console.WriteLine("** Using AsOrdered");
                {
                    // TODO
                }

                Console.WriteLine("** Using AsSequential");
                {
                    // TODO
                }
            }
        }

        /*
        
        Sometimes it is useful to sequence tasks. For example, you might require that if a task completes successfully, 
        another task is run, or if the task fails, a different task is run that possibly needs to perform some kind of 
        recovery process. A task that runs only when a previous task finishes is called a continuation. This approach 
        enables you to construct a pipeline of background operations.
        
        Additionally, a task may spawn other tasks if the work that it needs to perform is also multithreaded in 
        nature. The parent task (the task that spawned the new or nested tasks) can wait for the nested tasks to 
        complete before it finishes itself, or it can return and let the child tasks continue running asynchronously. 
        
        Tasks that cause the parent task to wait are called child tasks. 

        */
        public static void LinkingTasks()
        {
            Console.WriteLine("* Linking Tasks");
            {
                /*
                
                Continuation tasks enable you to chain multiple tasks together so that they execute one after another. 
                The task that invokes another task on completion is known as the antecedent, and the task that it 
                invokes is known as the continuation. You can pass data from the antecedent to the continuation, and 
                you can control the execution of the task chain in various ways. To create a basic continuation, you 
                use the Task.ContinueWith method. 

                Continuations enable you to implement the Promise pattern. This is a common idiom that many 
                asynchronous environments use to ensure that operations perform in a guaranteed sequence.

                https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/chaining-tasks-by-using-continuation-tasks

                */
                Console.WriteLine("** Creating a Task Continuation");
                {
                    // Create a task that returns a string.
                    Task<string> firstTask = new Task<string>(() => "Hello" );

                    // Create the continuation task. 
                    // The delegate takes the result of the antecedent task as an argument.
                    Task<string> secondTask = firstTask.ContinueWith((antecedent) =>
                    {
                        return string.Format("{0}, World!", antecedent.Result);
                    });

                    // Start the antecedent task.
                    firstTask.Start();

                    // Use the continuation task's result.
                    Console.WriteLine(secondTask.Result);

                    // Displays "Hello, World!"
                }

                /*
                
                A nested task is simply a task that you create within the delegate of another task. When you create 
                tasks in this way, the nested task and the outer task are essentially independent. The outer task does 
                not need to wait for the nested task to complete before it finishes. 

                In this case, due to the delay in the nested task, the outer task completes before the nested task.

                */
                Console.WriteLine("** Creating Nested Tasks");
                {
                    var parent = Task.Factory.StartNew(() =>
                    {
                        Console.WriteLine("Outer task executing.");

                        var child = Task.Factory.StartNew(() =>
                        {
                            Console.WriteLine("Nested task starting.");
                            Thread.SpinWait(500000);
                            Console.WriteLine("Nested task completing.");
                        });
                    });

                    parent.Wait();
                    Console.WriteLine("Outer has completed.");

                    /* 

                    Outer task executing
                    Outer has completed.
                    Nested task starting.
                    Nested task completing.

                    */
                }

                Console.WriteLine("** Creating Nested Tasks (with Result)");
                {
                    var outer = Task<int>.Factory.StartNew(() =>
                    {
                        Console.WriteLine("Outer task executing.");

                        var nested = Task<int>.Factory.StartNew(() =>
                        {
                            Console.WriteLine("Nested task starting.");
                            Thread.SpinWait(5000000);
                            Console.WriteLine("Nested task completing.");
                            return 42;
                        });

                        // Parent will wait for this detached child.
                        return nested.Result;
                    });

                    Console.WriteLine("Outer has returned {0}.", outer.Result);

                    /*
                    
                    Outer task executing.
                    Nested task starting.
                    Nested task completing.
                    Outer has returned 42.

                    */
                }

                /*
                
                A child task is a type of nested task, except that you specify the AttachedToParent option when you 
                create the child task. In this case, the child task and the parent task become far more closely 
                connected. The status of the parent task depends on the status of any child tasks—in other words, a 
                parent task cannot complete until all of its child tasks have completed. The parent task will also 
                propagate any exceptions that its child tasks throw. 

                The child task is created by using the AttachedToParent option. As a result, in this case, the parent 
                task waits for the child task to complete before completing itself.
                
                Nested tasks are useful because they enable you to break down asynchronous operations into smaller 
                units that can themselves be distributed across available threads. By contrast, it is more useful to 
                use parent and child tasks when you need to control synchronization by ensuring that certain child 
                tasks are complete before the parent task returns. 

                https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/attached-and-detached-child-tasks

                */
                Console.WriteLine("** Creating Child Tasks");
                {
                    var parent = Task.Factory.StartNew(() =>
                    {
                        Console.WriteLine("Parent task executing.");
                        var child = Task.Factory.StartNew(() =>
                        {
                            Console.WriteLine("Attached child starting.");
                            Thread.SpinWait(5000000);
                            Console.WriteLine("Attached child completing.");
                        }, TaskCreationOptions.AttachedToParent);
                    });
                    parent.Wait();
                    Console.WriteLine("Parent has completed.");

                    parent.Wait();

                    /* 

                    Parent task executing.
                    Attached child starting.
                    Attached child completing.
                    Parent has completed.

                    */
                }
            }
        }

        /*
        
        When a task throws an exception, the exception is propagated back to the thread that initiated the task (the 
        joining thread). The task might be linked to other tasks through continuations or child tasks, so multiple 
        exceptions may be thrown. To ensure that all exceptions are propagated back to the joining thread, the Task 
        Parallel Library bundles any exceptions together in an AggregateException object. This object exposes all of 
        the exceptions that occurred through an InnerExceptions collection. 

        */
        public static void HandlingTaskExceptions()
        {
            Console.WriteLine("* Handling Task Exceptions");
            {
                /*
                
                To catch exceptions on the joining thread, you must wait for the task to complete. You do this by 
                calling the Task.Wait method in a try block and then catching an AggregateException exception in the 
                corresponding catch block. A common exception-handling scenario is to catch the TaskCanceledException 
                exception that is thrown when you cancel a task.

                */
                Console.WriteLine("** Catching Task Exceptions");
                {
                    // Create a cancellation token source and obtain a cancellation token.
                    CancellationTokenSource cts = new CancellationTokenSource();
                    CancellationToken ct = cts.Token;

                    // Create and start a long-running task.
                    var task1 = Task.Run(() => doWork(ct), ct);

                    // Cancel the task.
                    cts.Cancel();

                    // Handle the TaskCanceledException.
                    try
                    {
                        task1.Wait();
                    }
                    catch (AggregateException ae)
                    {
                        foreach (var inner in ae.InnerExceptions)
                        {
                            if (inner is TaskCanceledException)
                            {
                                Console.WriteLine("The task was cancelled.");
                                Console.ReadLine();
                            }
                            else
                            {
                                // If it's any other kind of exception, re-throw it.
                                throw;
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}