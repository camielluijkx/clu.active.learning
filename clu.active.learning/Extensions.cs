using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using FourthExtensionMethods;

namespace clu.active.learning
{
    /*
     
    There are almost 15,000 public types in the .NET Framework. Although not all of these are extendable classes, many 
    of them are. When you want to develop a class, in many cases there is a built-in .NET Framework class that can 
    provide a foundation for your code. 

    There are two key advantages to creating a class that inherits from a .NET Framework class, rather than developing 
    a class from scratch: 

        • Reduced development time. By inheriting from an existing class, you reduce the amount of logic that you have 
          to create yourself. 
        • Standardized functionality. Just like implementing an interface, inheriting from a standard base class means 
          that your class will work in a standardized way. You can also represent instances of your class as instances 
          of the base class, which makes it easier for developers to use your class alongside other types that derive 
          from the same base class. 

    The rules of inheritance apply to built-in .NET Framework classes in the same way they apply to custom classes: 

        • You can create a class that derives from a .NET Framework class, providing that the class is not sealed or 
          static. 
        • You can override any base class members that are marked as virtual. 
        • If you inherit from an abstract class, you must provide implementations for all abstract members. 

    */
    public static class Extensions
    {
        #region Implementation

        // Extending a .NET Framework Class. 
        public class UniqueList<T> : List<T>
        {
            public void RemoveDuplicates()
            {
                base.Sort();
                for (int i = this.Count - 1; i > 0; i--)
                {
                    if (this[i].Equals(this[i - 1]))
                    {
                        this.RemoveAt(i);
                    }
                }
            }
        }

        // Creating a Custom Exception Type.
        public class LoyaltyCardNotFoundException : Exception
        {
            public LoyaltyCardNotFoundException()
            {
                // This implicitly calls the base class constructor.
            }
            public LoyaltyCardNotFoundException(string message)
                : base(message)
            {
            }
            public LoyaltyCardNotFoundException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }

        public class Customer
        {
            public int TotalPoints { get; set; }
        }
        public class LoyaltyCard
        {
            public static Customer GetCustomer(string loyaltyCardNumber)
            {
                return new Customer
                {
                    TotalPoints = 0
                };
            }

            // Throwing a Custom Exception.
            public static int GetBalance(string loyaltyCardNumber)
            {
                var customer = LoyaltyCard.GetCustomer(loyaltyCardNumber);
                if (customer == null)
                {
                    throw new LoyaltyCardNotFoundException("The card number provided was not found");
                }
                else
                {
                    return customer.TotalPoints;
                }
            }

            public static void DeductPoints(int costInPoints)
            {
                // ...
            }

            // Catching a Custom Exception.
            public bool PayWithPoints(int costInPoints, string cardNumber)
            {
                try
                {
                    int totalPoints = LoyaltyCard.GetBalance(cardNumber);
                    // Throws a LoyaltyCardNotFoundException if the card number is invalid.
                    if (totalPoints >= costInPoints)
                    {
                        LoyaltyCard.DeductPoints(costInPoints);
                        return true;
                    }
                    else return false;
                }
                catch (LoyaltyCardNotFoundException)
                {
                    // Take appropriate action to remedy the invalid card number.
                    return false;
                }
                catch (Exception)
                {
                    // Catches other unanticipated exceptions.
                    return false;
                }
            }
        }

        // Inheriting from a Generic Base Type Without Specifying a Type Argument.
        public class CustomList<T> : List<T>
        {

        }

        // Inheriting from a Generic Base Type by Specifying a Type Argument.
        public class CustomList : List<int>
        {

        }

        // Inheriting from a Base Type with Multiple Type Parameters. Pass all the base type parameters on to the 
        // derived class.
        public class CustomDictionary1<TKey, TValue> : Dictionary<TKey, TValue> { }
        // Provide an argument for one of the base type parameters and pass the other one to the derived class.
        public class CustomDictionary2<TValue> : Dictionary<int, TValue> { }
        // Provide arguments for both of the base type parameters.
        public class CustomDictionary3 : Dictionary<int, string> { }

        // Adding Type Parameters to Derived Class Declarations. Pass the base type parameter on to the derived class, 
        // and add an additional type parameter.
        public class CustomCollection1<T, U> : List<T> { }
        // Provide an argument for the base type parameter, but add a new type parameter.
        public class CustomCollection2<T> : List<int> { }
        //Inherit from a non-generic class, but add a type parameter.
        public class CustomBaseClass { }
        public class CustomCollection3<T> : CustomBaseClass { }

        #endregion

        #region Public Methods

        public static void UsingExtensions()
        {
            Console.WriteLine("* Using Extensions");
            {
                Console.WriteLine("** Using Custom Exceptions");
                {
                    /*

                    https://docs.microsoft.com/en-us/dotnet/api/system?view=netframework-4.7.2

                    The.NET Framework contains built-in exception classes to represent most common error conditions. 
                    For example: 

                        • If you invoke a method with a null argument value, and the method cannot handle null argument 
                          values, the method will throw an ArgumentNullException.
                        • If you attempt to divide a numerical value by zero, the runtime will throw a 
                          DivideByZeroException.
                        • If you attempt to retrieve an indexed item from a collection, and the index it outside the 
                          bounds of the collection, the indexer will throw an IndexOutOfRangeException.

                    When Should You Create a Custom Exception Type? 

                    You should consider creating a custom exception type when:

                        • Existing exception types do not adequately represent the error condition you are identifying.
                        • The exception requires very specific remedial action that differs from how you would handle 
                          built-in exception types. 

                    Remember that the primary purpose of exception types is to enable you to handle specific error 
                    conditions in specific ways by catching a specific exception type. The exception type is not 
                    designed to communicate the precise details of the problem. All exception classes include a message 
                    property for this purpose. Therefore, you should not create a custom exception class just to 
                    communicate the nature of an error condition. Create a custom exception class only if you need to 
                    handle that error condition in a distinct way. 

                    Creating Custom Exception Types

                    All exception classes ultimately derive from the System.Exception class. This class provides a 
                    range of properties that you can use to provide more detail about the error condition. For example: 

                        • The Message property enables you to provide more information about what happened as a text 
                          string. 
                        • The InnerException property enables you to identify another Exception instance that caused 
                          the current instance. 
                        • The Source property enables you to specify the item or application that caused the error 
                          condition. 
                        • The Data property enables you to provide more information about the error condition as 
                          key-value pairs.

                    */
                }

                Console.WriteLine("** Using Extension Methods");
                {
                    Console.WriteLine("Type some text that contains numbers and press Enter");
                    //string text = Console.ReadLine();
                    string text = "123";
                    if (text.ContainsNumbers())
                    {
                        Console.WriteLine("Your text contains numbers. Well done!");
                    }
                    else
                    {
                        Console.WriteLine("Your text does not contain numbers. Please try again.");
                    }
                }
            }
        }

        #endregion
    }
}

namespace FourthExtensionMethods
{
    public static class FourthCoffeeExtensions
    {
        public static bool ContainsNumbers(this String s)
        {
            // Use regular expressions to determine whether a string contains any numerical digits.
            return Regex.IsMatch(s, @"\d");
        }
    }
}