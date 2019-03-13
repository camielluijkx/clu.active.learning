using System;

namespace clu.active.learning
{
    /*
    
    When interoperating with unmanaged resources, it is important that you manage and release these 
    resources when you are no longer using them. 

    The life cycle of an object has several stages, which start at creation of the object and end in its 
    destruction. To create an object in your application, you use the new keyword. When the CLR executes 
    code to create a new object, it performs the following steps: 

        1. It allocates a block of memory large enough to hold the object.
        2. It initializes the block of memory to the new object.

    The CLR handles the allocation of memory for all managed objects. However, when you use unmanaged 
    objects, you may need to write code to allocate memory for the unmanaged objects that you create. 

    When you have finished with an object, you can dispose of it to release any resources, such as database
    connections and file handles, that it consumed. When you dispose of an object, the CLR uses a feature 
    called the garbage collector (GC) to perform the following steps: 

        1. The GC releases resources.
        2. The memory that is allocated to the object is reclaimed.

    The GC runs automatically in a separate thread. When the GC runs, other threads in the application are 
    halted, because the GC may move objects in memory and therefore must update the memory pointers. 

    https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/index

    */
    public static class OLC
    {
        #region Public Methods

        /*
        
        The dispose pattern is a design pattern that frees resources that an object has used. The .NET 
        Framework provides the IDisposable interface in the System namespace to enable you to implement the 
        dispose pattern in your applications. 

        The IDisposable interface defines a single parameterless method named Dispose. You should use the 
        Dispose method to release all of the unmanaged resources that your object consumed. If the object is 
        part of an inheritance hierarchy, the Dispose method can also release resources that the base types 
        consumed by calling the Dispose method on the parent type. Invoking the Dispose method does not 
        destroy an object. The object remains in memory until the final reference to the object is removed 
        and the GC reclaims any remaining resources. 

        Many of the classes in the .NET Framework that wrap unmanaged resources, such as the StreamWriter class, 
        implement the IDisposable interface. You should also implement the IDisposable interface when you create 
        your own classes that reference unmanaged types. 

        */
        public static void ImplementingDisposePattern()
        {
            /*
            
            To implement the IDisposable pattern in your application, perform the following steps:

                1. Ensure that that the System namespace is in scope. 
                2. Implement the IDisposable interface in your class definition.
                3. Add a private field to the class, which you can use to track the disposal status of the object, 
                and check whether the Dispose method has already been invoked and the resources released.
                4. Add code to any public methods in your class to check whether the object has already been disposed 
                of. If the object has been disposed of, you should throw an ObjectDisposedException. 
                5. Add an overloaded implementation of the Dispose method that accepts a Boolean parameter. The 
                overloaded Dispose method should dispose of both managed and unmanaged resources if it was called 
                directly, in which case you pass a Boolean parameter with the value true. If you pass a Boolean 
                parameter with the value of false, the Dispose method should only attempt to release unmanaged 
                resources. You may want to do this if the object has already been disposed of or is about to be 
                disposed of by the GC. 
                6. Add code to the parameterless Dispose method to invoke the overloaded Dispose method and then 
                call the GC.SuppressFinalize method. The GC.SuppressFinalize method instructs the GC that the 
                resources that the object referenced have already been released and the GC does not need to waste 
                time running the finalization code.

            After you have implemented the IDisposable interface in your class definitions, you can then invoke the
            Dispose method on your object to release any resources that the object has consumed. You can invoke the
            Dispose method from a destructor that is defined in the class. 

            */
            Console.WriteLine("* Implementing Dispose Pattern");
            {
                // TODO
            }
        }

        public static void ImplementingDestructor()
        {
            Console.WriteLine("* Implementing Destructor");
            {
                Console.WriteLine("** Defining a Destructor");
                {
                    // TODO
                }

                Console.WriteLine("** Calling the Dispose Method from a Destructor");
                {
                    // TODO
                }
            }
        }

        public static void ManagingObjectLifetime()
        {
            Console.WriteLine("* Managing Object Lifetime");
            {
                Console.WriteLine("** Invoking the Dispose Method");
                {
                    // TODO
                }

                Console.WriteLine("** Invoking the Dispose Method in a finally Block");
                {
                    // TODO
                }

                Console.WriteLine("** Disposing Of an Object by Using a using Statement");
                {
                    // TODO
                }
            }
        }

        #endregion
    }
}
