using System;

namespace clu.active.learning
{
    public static class Constructors
    {
        #region Implementation

        public class Person
        {
            private string last;
            private string first;

            public Person(string lastName, string firstName)
            {
                last = lastName;
                first = firstName;
            }

            // Remaining implementation of Person class.
        }

        public class Location
        {
            private string locationName;

            // Expression body definition can be used if a constructor can be implemented as a 
            // single statement. The following example defines a Location class whose constructor 
            // has a single string parameter named name. The expression body definition assigns the 
            // argument to the locationName field.
            public Location(string name) => Name = name;

            public string Name
            {
                get => locationName;
                set => locationName = value;
            }
        }

        /*

        A class or struct can also have a static constructor, which initializes static members of 
        the type. Static constructors are parameterless. If you don't provide a static constructor 
        to initialize static fields, the Visual C# compiler will supply a default static 
        constructor that initializes static fields to their default value. 

        */
        public class Adult : Person
        {
            private static int minimumAge;

            public Adult(string lastName, string firstName)
                : base(lastName, firstName)
            {
            }

            static Adult()
            {
                minimumAge = 18;
            }

            // Remaining implementation of Adult class.
        }

        public class Child : Person
        {
            private static int maximumAge;

            public Child(string lastName, string firstName)
                : base(lastName, firstName)
            {
            }

            // Static constructor with an expression body definition.
            static Child() => maximumAge = 18;

            // Remaining implementation of Child class.
        }

        #endregion
    }
}