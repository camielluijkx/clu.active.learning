using System;

namespace clu.active.learning.console
{
    /*
    
    https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers

    public
    The type or member can be accessed by any other code in the same assembly or another assembly that references it.

    private
    The type or member can be accessed only by code in the same class or struct.

    protected
    The type or member can be accessed only by code in the same class, or in a class that is derived from that class.

    internal
    The type or member can be accessed by any code in the same assembly, but not from another assembly.

    protected internal 
    The type or member can be accessed by any code in the assembly in which it is declared, or from within a derived class in 
    another assembly.

    private protected 
    The type or member can be accessed only within its declaring assembly, by code in the same class or in a type that is derived 
    from that class.

    */
    public class AccessModifiers
    {
        public class Person
        {
            protected string Name { get; private set; }

            public Person()
            {

            }

            public override string ToString()
            {
                if (string.IsNullOrEmpty(this.Name))
                {
                    return "John Doe";
                }

                return null;
            }
        }

        public class Student : Person
        {
            public Student()
            {
                var name = base.Name;
            }

            public override string ToString()
            {
                return base.ToString();
            }
        }

        public static void Test()
        {
            var student = new Student();
            //student.Name; // inaccessible due to its protection level
            Console.WriteLine(student.ToString());

            Console.WriteLine();
        }
    }
}