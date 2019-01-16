using System;
using System.Collections;

namespace clu.active.learning
{
    /*
     
     It specifies a set of characteristics and behaviors by defining signatures for methods, 
     properties, events, and indexers, without specifying how any of these members are implemented. 
     When a class implements an interface, the class provides an implementation for each member of 
     the interface. By implementing the interface, the class is thereby guaranteeing that it will 
     provide the functionality specified by the interface.

    */
    public static class Interfaces
    {
        // Defining an interface.
        public interface ILoyaltyCardHolder // public, internal (default)
        {
            // Methods, properties, events and indexers.
            // Signatures only, no implementation details.

            int TotalPoints { get; } // property

            int AddPoints(decimal transactionValue); // method
            void ResetPoints(); // method

            event EventHandler OnSoldOut; // event

            string this[int index] { get; set; } // indexer
        }

        // Implementing an interface.
        public class Customer : ILoyaltyCardHolder
        {
            public int TotalPoints { get; private set; }

            public int AddPoints(decimal transactionValue)
            {
                int points = Decimal.ToInt32(transactionValue);
                TotalPoints += points;

                return points;
            }
            public void ResetPoints()
            {
                TotalPoints = 0;
            }

            public event EventHandler OnSoldOut;

            public string this[int index]
            {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }
        }

        public interface IBeverage
        {
            int GetServingTemperature(bool includesMilk);

            bool IsFairTrade { get; set; }
        }

        public class Coffee : IBeverage
        {
            private int servingTempWithoutMilk { get; set; }

            private int servingTempWithMilk { get; set; }

            public int GetServingTemperature(bool includesMilk)
            {
                if (includesMilk)
                {
                    return servingTempWithMilk;
                }
                else
                {
                    return servingTempWithoutMilk;
                }
            }

            public bool IsFairTrade { get; set; }

            // Other non-interface members go here.
        }

        public interface IInventoryItem
        {

        }

        /* 
        
        Implementing Multiple Interfaces: 

        • Implement the IDisposable interface to enable the .NET runtime to dispose of your class correctly. 
        • Implement the IComparable interface to enable collection classes to sort instances of your class. 
        • Implement custom interface to define the functionality of a custom class.

        */
        public class SpecialCoffee : IBeverage, IInventoryItem
        {
            public bool IsFairTrade
            {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }

            public int GetServingTemperature(bool includesMilk)
            {
                throw new NotImplementedException();
            }
        }

        /* 
        
        Implementing an Interface Explicitly.

        Some developers prefer explicit interface implementation because doing so can make the code easier to 
        understand. 

        The only scenario in which you must use explicit interface implementation is if you are implementing 
        two interfaces that share a member name. For example, if you implement interfaces named IBeverage and 
        IInventoryItem, and both interfaces declare a Boolean property named IsAvailable, you would need to 
        implement at least one of the IsAvailable members explicitly. In this scenario, the Visual C# compiler 
        would be unable to resolve the IsAvailable reference without an explicit implementation. 

        There is a difference in the usage of the class, however. When implementing an interface implicitly 
        the members can be used as normal public members of the class and can be referenced without any 
        special designation. When an interface is implemented explicitly, though, the members are made only 
        available by casting the instance to the corresponding interface. Otherwise, they’ll remain hidden, 
        and the code calling them will not compile.

        */
        public class ExplicitCoffee : IBeverage
        {
            private int servingTempWithoutMilk { get; set; }
            private int servingTempWithMilk { get; set; }

            int IBeverage.GetServingTemperature(bool includesMilk)
            {
                if (includesMilk)
                {
                    return servingTempWithMilk;
                }
                else
                {
                    return servingTempWithoutMilk;
                }
            }

            bool IBeverage.IsFairTrade { get; set; }

            // Other non-interface members.
        }

        /*
        
        https://docs.microsoft.com/en-us/dotnet/api/system.icomparable?view=netframework-4.7.2

        Implementing the IComparable Interface 

            public interface IComparable
            {
                int CompareTo(Object obj);
            }
        
        Implementations of this method must: 
        
            • Compare the current object instance with another object of the same type (the argument).
            • Return an integer value that indicates whether the current object instance should be 
              placed before, in the same position, or after the passed-in object instance. 
        
        The integer values returned by the CompareTo method are interpreted as follows: 

            • Less than zero indicates that the current object instance precedes the supplied instance 
              in the sort order. 
            • Zero indicates that the current object instance occurs at the same position as the supplied
              instance in the sort order. 
            • More than zero indicates that the current object instance follows the supplied instance in 
              the sort order.

        */
        public class ComparableCoffee : IComparable
        {
            public double AverageRating { get; set; }
            public string Variety { get; set; }

            int IComparable.CompareTo(object obj)
            {
                ComparableCoffee coffee2 = obj as ComparableCoffee;

                return String.Compare(this.Variety, coffee2.Variety);
            }
        }

        /* 
        
        Implementing the IComparer Interface 

            public interface IComparer
            {
                int Compare(Object x, Object y)
            }

        
        As you can see, the IComparer interface declares a single method named Compare. 
        Implementations of this method must: 

            • Compare two objects of the same type.
            • Return an integer value that indicates whether the current object instance should 
            be placed before, in the same position, or after the passed-in object instance. 

        */
        public class CoffeeRatingComparer : IComparer
        {
            public int Compare(Object x, Object y)
            {
                ComparableCoffee coffee1 = x as ComparableCoffee;
                ComparableCoffee coffee2 = y as ComparableCoffee;

                double rating1 = coffee1.AverageRating;
                double rating2 = coffee2.AverageRating;

                return rating1.CompareTo(rating2);
            }
        }

        #region Public Methods

        public static void UsingInterfaces()
        {
            Console.WriteLine("** Using Interfaces");
            {
                /*
                 
                Interface Polymorphism 

                As it relates to interfaces, polymorphism states that you can represent an instance 
                of a class as an instance of any interface that the class implements. Interface 
                polymorphism can help to increase the flexibility and modularity of your code. Suppose 
                you have several classes that implement the IBeverage interface, such as Coffee, Tea, 
                Juice, and so on. You can write code that works with any of these classes as instances 
                of IBeverage, without knowing any details of the implementing class. For example, you 
                can build a collection of IBeverage instances without needing to know the details of 
                every class that implements IBeverage. 

                */
                Console.WriteLine("** Representing an Object as an Interface Type");
                {
                    Coffee coffee1 = new Coffee();
                    IBeverage coffee2 = new Coffee();
                }

                Console.WriteLine("** Casting to an Interface Type");
                {
                    Coffee coffee1 = new Coffee();
                    IBeverage coffee2 = coffee1; // implicit cast
                }

                Console.WriteLine("** Casting an Interface Type to a Derived Class Type");
                {
                    Coffee coffee1 = new Coffee();
                    IBeverage coffee2 = new Coffee();

                    Coffee coffee3 = coffee2 as Coffee; // explicit cast
                    // OR
                    Coffee coffee4 = (Coffee)coffee2; // explicit cast
                }
            }
        }

        public static void UsingIComparable()
        {
            Console.WriteLine("* Using IComparable");
            {
                int number1 = 5;
                int number2 = 100;
                int result = number1.CompareTo(number2);
                // The value of result is -1, indicating that number1 should precede number2 in the sort order.
            }
        }

        public static void UsingIComparer()
        {
            Console.WriteLine("* Using IComparer");
            {
                // Create some instances of the Coffee class.
                ComparableCoffee coffee1 = new ComparableCoffee();
                coffee1.AverageRating = 4.5;
                ComparableCoffee coffee2 = new ComparableCoffee();
                coffee2.AverageRating = 8.1;
                ComparableCoffee coffee3 = new ComparableCoffee();
                coffee3.AverageRating = 7.1;

                // Add the Coffee instances to an ArrayList.
                ArrayList coffeeList = new ArrayList();
                coffeeList.Add(coffee1);
                coffeeList.Add(coffee2);
                coffeeList.Add(coffee3);

                // Sort the ArrayList by average rating.
                coffeeList.Sort(new CoffeeRatingComparer());
            }
        }

        #endregion
    }
}
