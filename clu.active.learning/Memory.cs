using System;

namespace clu.active.learning
{
    public static class Memory
    {
        /*
         
         The .NET Memory Model

         Stack

         The stack is used to save local value variables in the current scope. It functions just like 
         the stack collection, with each new variable being assigned right next to the last one used. 
         When the code exits its current scope, all the associated data in the stack is cleared, and 
         the stack reverts to its previous scope. A scope in .Net is generally defined as the currently 
         running code block surrounded by curly brackets. The most common use of that is the method. 
         When a method is entered, the stack will save all local value variables created in that method, 
         as well as any value parameters passed to the method. When the code exits the method, all of 
         this data is cleared. However, if another method is called from the current method, the new 
         data will be saved right after the current data. This allows the stack to easily load the 
         appropriate data when a scope is exited.

         The stack has a fixed size during the lifetime of the application. Exceeding it will result in a 
         StackOverflowException.

         Heap

         The heap is used to save large reference variables. Memory is allocated dynamically from the heap 
         as needed. When a new large object is created, the CLR looks for the next continuous free memory 
         space large enough to contain the object and allocates that memory to it. 

         Memory is not automatically cleared from the heap when the scope is exited like it was with the 
         stack. Rather, the garbage collector is responsible to clear the heap. When it decides so, the 
         garbage collector will initiate a scan of the objects in the heap. It continues to delete any 
         object it determines is no longer in use. Lastly the garbage collector defragments the memory left 
         in use to eliminate small gaps between existing objects. This is to avoid waste since objects on 
         the heap are only allocated to continuous free memory spaces. 

         The heap doesn’t have a fixed size and can grow during the lifetime of the application. However, 
         it does have an upper limit to its size. If the application reaches that upper limit, it throws 
         an OutOfMemoryException exception.

         Reference Types

         These are assumed to be rather large objects and are therefore referred to by their address only 
         (hence the name). When you create a reference type object, you do allocate all the memory it requires, 
         however, what you receive back is not the object itself, but only its address in the memory. When you 
         “copy” a reference type, as shown below: 

            var x = new SomeClass();
            var y = x;

         Only the reference is copied. Any change made to data within the instance will show when either 
         x or y is queried, since they are, in fact, the same instance. 

            x.SomeProperty = 42;
            Console.WriteLine(y.SomeProperty); // Output: 42
            y.SomeProperty += 100;
            Console.WriteLine(x.SomeProperty); // Output: 142

         This also means any change made to a referenced type passed as a parameter to a method will be 
         present when the method exits. Reference types are only saved on the heap. 

         In Visual C#, classes and delegates, are always reference types. To create a new reference type yourself, 
         you only need to define a new class. This applies to built-in types as well, you can see if a certain 
         type is a reference type by looking up its definition.

        Value Types 

        These are assumed to be smaller objects and are not referenced indirectly. When a value type variable is 
        created, that variable will keep the variable’s value itself. When you copy a value type to another it 
        really is copied, resulting in two different instances with the same value. A change to the first will 
        not affect the other. 

            var x = 1;
            var y = x;
            x = 42
            Console.WriteLine(x); // Output: 42
            Console.WriteLine(y); // Output: 1
            y += 100;
            Console.WriteLine(x); // Output: 42
            Console.WriteLine(y); // Output: 101

        When a value type is assigned as a method parameter, its value is again copied, and the method will use 
        the copied value. Meaning that any change to the parameter’s value will not be seen when the method
        returns. 

        Value types are sometimes saved on the heap, and sometimes on the stack, depending on their usage. 
        Generally, only local method members and parameters are saved on the stack. While other usages (like 
        class fields and properties) are saved on the heap as a part of their parent object. 

        In Visual C#, only structs are value types. To create a new value type yourself, you only need to define 
        a new struct. This applies to built-in types as well, you can see if a certain type is a value type by 
        looking up its definition. 

        Boxing and Unboxing 

        In some scenarios you may need to convert value types to reference types, and vice versa. For example, 
        some collection classes will only accept reference types. This is less likely to be an issue with the 
        advent of generic collections. However, you still need to be aware of the concept, because a fundamental 
        concept of Visual C# is that you can treat any type as an object. 

        The process of converting a value type to a reference type is called boxing. To box a variable, you assign 
        it to an object reference: 

        Boxing

            int i = 100;
            object o = i;

        The boxing process is implicit. When you assign an object reference to a value type, the C# compiler 
        automatically creates an object to wrap the value and stores it in memory. If you copy the object reference, 
        the copy will point to the same object wrapper in memory. 

        The process of converting a reference type to a value type is called unboxing. Unlike the boxing process, to 
        unbox a value type you must explicitly cast the variable back to its original type: 

        Unboxing 
        
            int j;
            j = (int)o;
        
        */
    }
}
