using System;
using System.Collections;
using System.Collections.Generic;

namespace clu.active.learning
{
    /*
     
    Generics enable creation and usage of strongly typed collections that are type safe, not 
    requiring to cast items, and not requiring to box and unbox value types. 
    
    Generic classes work by including a type parameter, T, in the class or interface declaration. 
    It is not needed to specify the type of T until class is instantiated. 
    
    To create a generic class, you need to: 
        • Add the type parameter T in angle brackets after the class name. 
        • Use the type parameter T in place of type names in your class members. 

    The use of generic classes, particularly for collections, offers three main advantages over 
    non-generic approaches: type safety, no casting, and no boxing and unboxing. 

    */
    public static class Generics
    {
        #region Implementation

        // Creating a Generic Class.
        public class CustomList<T>
        {
            public T this[int index]
            {
                get
                {
                    //throw new NotImplementedException();
                    return default;
                }
                set
                {
                    throw new NotImplementedException();
                }
            }

            public void Add(T item)
            {
                // Method logic goes here.
            }
            public void Remove(T item)
            {
                // Method logic goes here.
            }
        }

        public class Coffee
        {

        }

        public class Tea
        {

        }

        public interface IBeverage
        {

        }

        /* 
        
        Constraining Type Parameters by Interface 

        Constraint                      Description 
        where T : <name of interface>   The type argument must be, or implement, the specified 
                                        interface.
        where T : <name of base class>  The type argument must be, or derive from, the specified 
                                        class.
        where T : U                     The type argument must be, or derive from, the supplied
                                        type argument U.
        where T : new()                 The type argument must have a public default constructor.
        where T : struct                The type argument must be a value type.
        where T : class                 The type argument must be a reference type.

        */
        public class ConstrainedList<T> 
            where T : IBeverage
        {

        }

        // Apply Multiple Type Constraints.
        public class MultipleConstrainedCustomList<T> 
            where T : IBeverage, IComparable<T>, new()
        {
        }

        /*
         
        Using Generic List Collections 

        The List<T> Class 

        The List<T> class provides a strongly-typed alternative to the ArrayList class. Like the 
        ArrayList class, the List<T> class includes methods to: 
            • Add an item.
            • Remove an item.
            • Insert an item at a specified index.
            • Sort the items in the collection by using the default comparer or a specified 
              comparer.
            • Reorder all or part of the collection.
        
        Other Generic List Classes

        The System.Collections.Generic namespace also includes various generic collections that 
        provide more specialized functionality: 

        • The LinkedList<T> class provides a generic collection in which each item is linked to the 
          previous item in the collection and the next item in the collection. Each item in the 
          collection is represented by a LinkedListNode<T> object, which contains a value of type 
          T, a reference to the parent LinkedList<T> instance, a reference to the previous item in 
          the collection, and a reference to the next item in the collection. 
        • The Queue<T> class represents a strongly typed first in, last out collection of objects. 
        • The Stack<T> class represents a strongly typed last in, last out collection of objects.
        
        The Dictionary<TKey, TValue> Class 

        The Dictionary<TKey, TValue> class provides a general purpose, strongly typed dictionary 
        class. You can add duplicate values to the collection, but the keys must be unique. The 
        class will throw an ArgumentException if you attempt to add a key that already exists in 
        the dictionary. 

        Other Generic Dictionary Classes
        
        The SortedList<TKey, TValue> and SortedDictionary<TKey, TValue> classes both provide 
        generic dictionaries in which the entries are sorted by key. The difference between these 
        classes is in the underlying implementation: 

            • The SortedList generic class uses less memory than the SortedDictionary generic 
              class. 
            • The SortedDictionary class is faster and more efficient at inserting and removing 
              unsorted data. 

        Using Collection Interfaces 

        IEnumberable -> IEnumerable<T> -> ICollection<T> -> IList<T> | IDictionary<TKey, TValue>

        The IEnumerable and IEnumerable<T> Interfaces

        If you want to be able to use a foreach loop to enumerate over the items in your custom 
        generic collection, you must implement the IEnumerable<T> interface. The IEnumerable<T> 
        method defines a single method named GetEnumerator(). This method must return an object of 
        type IEnumerator<T>. The foreach statement relies on this enumerator object to iterate 
        through the collection. 

        The IEnumerable<T> interface inherits from the IEnumerable interface, which also defines a 
        single method named GetEnumerator(). When an interface inherits from another interface, it 
        exposes all the members of the parent interface. In other words, if you implement 
        IEnumerable<T>, you also need to implement IEnumerable. 

        The ICollection<T> Interface

        The ICollection<T> interface defines the basic functionality that is common to all generic 
        collections. The interface inherits from IEnumerable<T>, which means that if you want to 
        implement ICollection<T>, you must also implement the members defined by IEnumerable<T> and 
        IEnumerable. 

        The ICollection<T> interface defines the following methods: 

        Name            Description 
        Add             Adds an item of type T to the collection. 
        Clear           Removes all items from the collection.
        Contains        Indicates whether the collection contains a specific value.
        CopyTo          Copies the items in the collection to an array.
        Remove          Removes a specific object from the collection.

        The ICollection<T> interface defines the following properties: 

        Name            Description
        Count           Gets the number of items in the collection.
        IsReadOnly      Indicates whether the collection is read-only.

        The IList<T> Interface 

        The IList<T> interface defines the core functionality for generic list classes. You should 
        implement this interface if you are defining a linear collection of single values. In 
        addition to the members it inherits from ICollection<T>, the IList<T> interface defines 
        methods and properties that enable you to use indexers to work with the items in the 
        collection. For example, if you create a list named myList, you can use myList[0] to access 
        the first item in the collection. 

        The IList<T> interface defines the following methods: 

        Name            Description 
        Insert          Inserts an item into the collection at the specified index.
        RemoveAt        Removes the item at the specified index from the collection.

        The IList<T> interface defines the following properties: 

        Name            Description
        IndexOf         Determines the position of a specified item in the collection.

        The IDictionary<TKey, TValue> Interface

        The IDictionary<TKey, TValue> interface defines the core functionality for generic 
        dictionary classes. You should implement this interface if you are defining a collection of 
        key-value pairs. In addition to the members it inherits from ICollection<T>, the 
        IDictionary<T> interface defines methods and properties that are specific to working with 
        key-value pairs. 

        The IDictionary<TKey, TValue> interface defines the following methods: 

        Name            Description 
        Add             Adds an item with the specified key and value to the collection.
        ContainsKey     Indicates whether the collection includes a key-value pair with the 
                        specified key.
        GetEnumerator   Returns an enumerator of KeyValuePair<TKey, TValue> objects. 
        Remove          Removes the item with the specified key from the collection.
        TryGetValue     Attempts to set the value of an output parameter to the value associated 
                        with a specified key. If the key exists, the method returns true. If the 
                        key does not exist, the method returns false and the output parameter is 
                        unchanged. 

        The IDictionary<TKey, TValue> interface defines the following properties: 

        Name            Description 
        Item            Gets or sets the value of an item in the collection, based on a specified 
                        key. This property enables you to use indexer notation, for example 
                        myDictionary[myKey] = myValue. 
        Keys            Returns the keys in the collection as an ICollection<T> instance. 
        Values          Returns the values in the collection as an ICollection<T> instance. 

        The IEnumerator<T> Interface 

        The IEnumerator<T> interface defines the functionality that all enumerators must implement. 
        
        The IEnumerator<T> interface defines the following methods: 

        Name            Description 
        MoveNext        Advanced the enumerator to the next item in the collection.
        Reset           Sets the enumerator to its starting position, which is before the first 
                        item in the collection. 
        
        The IEnumerator<T> interface defines the following properties: 

        Name            Description 
        Current         Gets the item that the enumerator is pointing to.
                        
        An enumerator is essentially a pointer to the items in the collection. The starting point 
        for the pointer is before the first item. When you call the MoveNext method, the pointer 
        advances to the next element in the collection. The MoveNext method returns true if the 
        enumerator was able to advance one position, or false if it has reached the end of the 
        collection. At any point during the enumeration, the Current property returns the item to 
        which the enumerator is currently pointing.
        
        When you create an enumerator, you must define:

            • Which item the enumerator should treat as the first item in the collection.
            • In what order the enumerator should move through the items in the collection.

        The IEnumerable<T> Interface 

        The IEnumerable<T> interface defines a single method named GetEnumerator. This returns an 
        IEnumerator<T> instance. 

        The GetEnumerator method returns the default enumerator for your collection class. This is 
        the enumerator that a foreach loop will use, unless you specify an alternative. However, 
        you can create additional methods to expose alternative enumerators. 

        */

        // Default and Alternative Enumerators.
        public class CustomCollection<T> : IEnumerable<T>
        {
            public IEnumerator<T> Backwards()
            {
                // This method returns an alternative enumerator. The implementation details are 
                // not shown.
                throw new NotImplementedException();
            }

            #region IEnumerable<T> Members

            public IEnumerator<T> GetEnumerator()
            {
                // This method returns the default enumerator. The implementation details are not 
                // shown.
                //throw new NotImplementedException();
                return default;
            }

            #endregion

            #region IEnumerable Members

            IEnumerator IEnumerable.GetEnumerator()
            {
                // This method is required because IEnumerable<T> inherits from IEnumerable.
                throw new NotImplementedException();
            }

            #endregion
        }

        // Implementing an Enumerator by Using an Iterator.
        class BasicCollection<T> : IEnumerable<T>
        {
            private List<T> data = new List<T>();

            public void FillList(params T[] items)
            {
                foreach (var datum in items)
                    data.Add(datum);
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                foreach (var datum in data)
                {
                    yield return datum;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Public Methods

        public static void UsingGenerics()
        {
            Console.WriteLine("* Using Generics");
            {
                /*
                 
                When instantiating a class, every instance of T within the class is effectively 
                replaced with the type parameter supplied.

                */
                Console.WriteLine("** Instantiating a Generic Class");
                {
                    CustomList<Coffee> clc = new CustomList<Coffee>();
                    Coffee coffee1 = new Coffee();
                    Coffee coffee2 = new Coffee();
                    clc.Add(coffee1);
                    clc.Add(coffee2);
                    Coffee firstCoffee = clc[0];
                }

                Console.WriteLine("** Type Safety Limitations for Non-Generic Collections");
                {
                    var coffee1 = new Coffee();
                    var coffee2 = new Coffee();
                    var tea1 = new Tea();
                    var arrayList1 = new ArrayList();
                    arrayList1.Add(coffee1);
                    arrayList1.Add(coffee2);
                    arrayList1.Add(tea1);

                    // The Sort method throws a runtime exception because the collection is not 
                    // homogenous.
                    //arrayList1.Sort();

                    // The cast throws a runtime exception because you cannot cast a Tea instance 
                    // to a Coffee instance.
                    //Coffee coffee3 = (Coffee)arrayList1[2];
                }

                Console.WriteLine("** Type Safety in Generic Collections");
                {
                    var coffee1 = new Coffee();
                    var coffee2 = new Coffee();
                    var tea1 = new Tea();
                    var genericList1 = new List<Coffee>();
                    genericList1.Add(coffee1);
                    genericList1.Add(coffee2);

                    // This line causes a build error, as the argument is not of type Coffee.
                    //genericList1.Add(tea1);

                    // The Sort method will work because the collection is guaranteed to be 
                    // homogenous.
                    //genericList1.Sort();

                    // The indexer returns objects of type Coffee, so there is no need to cast the 
                    // return value.
                    Coffee coffee3 = genericList1[1];
                }

                Console.WriteLine("** Boxing and Unboxing: Generic vs. Non-Generic Collections");
                {
                    int number1 = 1;
                    var arrayList1 = new ArrayList();

                    // This statement boxes the Int32 value as a System.Object.
                    arrayList1.Add(number1);

                    // This statement unboxes the Int32 value.
                    int number2 = (int)arrayList1[0];

                    var genericList1 = new List<Int32>();

                    // This statement adds an Int32 value without boxing.
                    genericList1.Add(number1);

                    // This statement retrieves the Int32 value without unboxing.
                    int number3 = genericList1[0];
                }

                Console.WriteLine("** Using the List<T> Class");
                {
                    string s1 = "Latte";
                    string s2 = "Espresso";
                    string s3 = "Americano";
                    string s4 = "Cappuccino";
                    string s5 = "Mocha";

                    // Add the items to a strongly-typed collection.
                    var coffeeBeverages = new List<String>();
                    coffeeBeverages.Add(s1);
                    coffeeBeverages.Add(s2);
                    coffeeBeverages.Add(s3);
                    coffeeBeverages.Add(s4);
                    coffeeBeverages.Add(s5);

                    // Sort the items using the default comparer. For objects of type String, the 
                    // default comparer sorts the items alphabetically.
                    coffeeBeverages.Sort();

                    // Write the collection to a console window.
                    foreach (String coffeeBeverage in coffeeBeverages)
                    {
                        Console.WriteLine(coffeeBeverage);
                    }
                }

                Console.WriteLine("** Using the Dictionary<TKey, TValue> Class");
                {
                    // Create a new dictionary of strings with string keys.
                    var coffeeCodes = new Dictionary<String, String>();

                    // Add some entries to the dictionary.
                    coffeeCodes.Add("CAL", "Café Au Lait");
                    coffeeCodes.Add("CSM", "Cinammon Spice Mocha");
                    coffeeCodes.Add("ER", "Espresso Romano");
                    coffeeCodes.Add("RM", "Raspberry Mocha");
                    coffeeCodes.Add("IC", "Iced Coffee");

                    // This statement would result in an ArgumentException because the key already 
                    // exists.
                    //coffeeCodes.Add("IC", "Instant Coffee");

                    // To retrieve the value associated with a key, you can use the indexer. This 
                    // will throw a KeyNotFoundException if the key does not exist.
                    Console.WriteLine("The value associated with the key \"CAL\" is {0}", 
                        coffeeCodes["CAL"]);

                    // Alternatively, you can use the TryGetValue method. This returns true if the 
                    // key exists and false if the key does not exist.
                    string csmValue = "";
                    if (coffeeCodes.TryGetValue("CSM", out csmValue))
                    {
                        Console.WriteLine("The value associated with the key \"CSM\" is {0}", 
                            csmValue);
                    }
                    else
                    {
                        Console.WriteLine("The key \"CSM\" was not found");
                    }

                    // You can also use the indexer to change the value associated with a key.
                    coffeeCodes["IC"] = "Instant Coffee";
                }
            
                Console.WriteLine("** Enumerating a Collection ");
                {
                    CustomCollection<Int32> numbers = new CustomCollection<Int32>();

                    // Add some items to the collection.

                    // Use the default enumerator to iterate through the collection:
                    foreach (int number in numbers)
                    {
                        // …
                    }

                    //// Use the alternative enumerator to iterate through the collection:
                    //foreach (int number in numbers.Backwards())
                    //{
                    //    // …
                    //}
                }
            }
        }

        #endregion
    }
}
