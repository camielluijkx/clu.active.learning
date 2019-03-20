using System;
using System.Collections;
using System.Collections.Specialized;

namespace clu.active.learning
{
    /*
    
    Collections:

        • List classes store linear collections of items. You can think of a list class as a one-dimensional array that 
          dynamically expands as you add items.
        • Dictionary classes store a collection of key/value pairs. Each item in the collection consists of two 
          objects—the key and the value. The value is the object you want to store and retrieve, and the key is the 
          object that you use to index and look up the value. In most dictionary classes, the key must be unique, 
          whereas duplicate values are perfectly acceptable.
        • Queue classes represent a first in, first out collection of objects. Items are retrieved from the collection 
          in the same order they were added.
        • Stack classes represent a last in, first out collection of objects. The item that you added to the collection 
          last is the first item you retrieve.

    The System.Collections namespace provides a range of general-purpose collections that includes lists, dictionaries, 
    queues, and stacks.
    
    Class                   Description
    ArrayList               The ArrayList is a general-purpose list that stores a linear collection of objects. The 
                            ArrayList includes methods and properties that enable you to add items, remove items, count 
                            the number of items in the collection, and sort the collection.
    BitArray                The BitArray is a list class that represents a collection of bits as Boolean values. The 
                            BitArray is most commonly used for bitwise operations and Boolean arithmetic, and includes 
                            methods to perform common Boolean operations such as AND, NOT, and XOR.
    Hashtable               The Hashtable class is a general-purpose dictionary class that stores a collection of 
                            key/value pairs. The Hashtable includes methods and properties that enable you to retrieve 
                            items by key, add items, remove items, and check for particular keys and values within the 
                            collection.
    Queue                   The Queue class is a first in, last out collection of objects. The Queue includes methods 
                            to add objects to the back of the queue (Enqueue) and retrieve objects from the front of 
                            the queue (Dequeue).
    SortedList              The SortedList class stores a collection of key/value pairs that are sorted by key. In 
                            addition to the functionality provided  by the Hashtable class, the SortedList enables you 
                            to retrieve items either by key or by index. The Stack class is a first in, first out 
                            collection of objects. The Stack includes methods to view the top item in the collection 
                            without removing it (Peek), add an item to the top of the stack (Push), and remove and 
                            return the item at the top of the stack (Pop).

    The System.Collections.Specialized namespace provides collection classes that are suitable for more specialized 
    requirements, such as specialized dictionary collections and strongly typed string collections.

    Class                   Description
    ListDictionary          The ListDictionary is a dictionary class that is optimized for small collections. As a 
                            general rule, if your collection includes 10 items or fewer, use a ListDictionary. If your 
                            collection is larger, use a Hashtable.
    HybridDictionary        The HybridDictionary is a dictionary class that you can use when you cannot estimate the 
                            size of the collection. The HybridDictionary uses a ListDictionary implementation when the 
                            collection size is small, and switches to a Hashtable implementation as the collection size 
                            grows larger.
    OrderedDictionary       The OrderedDictionary is an indexed dictionary class that enables you to retrieve items by 
                            key or by index. Note that unlike the SortedList class, items in an OrderedDictionary are 
                            not sorted by key.
    NameValueCollection     The NameValueCollection is an indexed dictionary class in which both the key and the value 
                            are strings. The NameValueCollection will throw an error if you attempt to set a key or a 
                            value to anything other than a string. You can retrieve items by key or by index.
    StringCollection        The StringCollection is a list class in which every item in the collection is a string. Use 
                            this class when you want to store a simple, linear collection of strings.
    StringDictionary        The StringDictionary is a dictionary class in which both the key and the value are strings. 
                            Unlike the NameValueCollection class, you cannot retrieve items from a StringDictionary by 
                            index.
    BitVector32             The BitVector32 is a struct that can represent a 32-bit value as both a bit array and an 
                            integer value. Unlike the BitArray class, which can expand indefinitely, the BitVector32 
                            struct is a fixed 32-bit size. As a result, the BitVector32 is more efficient than the 
                            BitArray for small values. You can divide a BitVector32 instance into sections to 
                            efficiently store multiple values.

    It is recommended to use generic collections, see Non-generic collections shouldn't be used on GitHub:

    https://github.com/dotnet/platform-compat/blob/master/docs/DE0006.md

    */
    public static class Collections
    {
        #region Private Methods

        private static void printValues(IEnumerable list)
        {
            foreach (object obj in list)
            {
                Console.Write("   {0}", obj);
            }
            Console.WriteLine();
        }

        private static void printValues(IEnumerable list, int width)
        {
            int i = width;
            foreach (object obj in list)
            {
                if (i <= 0)
                {
                    i = width;
                    Console.WriteLine();
                }
                i--;
                Console.Write("{0,8}", obj);
            }
            Console.WriteLine();
        }

        private static void printKeysAndValues(SortedList myList)
        {
            Console.WriteLine("\t-KEY-\t-VALUE-");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine("\t{0}:\t{1}", myList.GetKey(i), myList.GetByIndex(i));
            }
            Console.WriteLine();
        }

        // Uses the foreach statement which hides the complexity of the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        private static void printValues1(StringCollection column)
        {
            foreach (string obj in column)
            {
                Console.WriteLine("   {0}", obj);
            }
            Console.WriteLine();
        }

        // Uses the enumerator. 
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        private static void printValues2(StringCollection column)
        {
            StringEnumerator enumerator = column.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine("   {0}", enumerator.Current);
            }
            Console.WriteLine();
        }

        // Uses the Count and Item properties.
        private static void printValues3(StringCollection column)
        {
            for (int i = 0; i < column.Count; i++)
            {
                Console.WriteLine("   {0}", column[i]);
            }
            Console.WriteLine();
        }

        // Uses the foreach statement which hides the complexity of the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        private static void printKeysAndValues1(StringDictionary column)
        {
            Console.WriteLine("   KEY                       VALUE");
            foreach (DictionaryEntry entry in column)
            {
                Console.WriteLine("   {0,-25} {1}", entry.Key, entry.Value);
            }
            Console.WriteLine();
        }

        // Uses the enumerator. 
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        private static void printKeysAndValues2(StringDictionary myCol)
        {
            IEnumerator enumerator = myCol.GetEnumerator();
            DictionaryEntry entry;
            Console.WriteLine("   KEY                       VALUE");
            while (enumerator.MoveNext())
            {
                entry = (DictionaryEntry)enumerator.Current;
                Console.WriteLine("   {0,-25} {1}", entry.Key, entry.Value);
            }
            Console.WriteLine();
        }

        // Uses the Keys, Values, Count, and Item properties.
        private static void printKeysAndValues3(StringDictionary column)
        {
            String[] keys = new String[column.Count];
            column.Keys.CopyTo(keys, 0);

            Console.WriteLine("   INDEX KEY                       VALUE");
            for (int i = 0; i < column.Count; i++)
            {
                Console.WriteLine("   {0,-5} {1,-25} {2}", i, keys[i], column[keys[i]]);
            }
            Console.WriteLine();
        }

        #endregion

        #region Public Methods

        // Implements the IList interface using an array whose size is dynamically increased as required.
        public static void UsingArrayList()
        {
            /*
            
            https://docs.microsoft.com/en-us/dotnet/api/system.collections.arraylist?view=netframework-4.7.2

            The ArrayList is not guaranteed to be sorted. You must sort the ArrayList by calling its Sort method prior 
            to performing operations (such as BinarySearch) that require the ArrayList to be sorted. To maintain a 
            collection that is automatically sorted as new elements are added, you can use the SortedSet<T> class.

            The capacity of an ArrayList is the number of elements the ArrayList can hold. As elements are added to an 
            ArrayList, the capacity is automatically increased as required through reallocation. The capacity can be 
            decreased by calling TrimToSize or by setting the Capacity property explicitly.

            .NET Framework only: For very large ArrayList objects, you can increase the maximum capacity to 2 billion 
            elements on a 64-bit system by setting the enabled attribute of the <gcAllowVeryLargeObjects> configuration 
            element to true in the run-time environment.

            Elements in this collection can be accessed using an integer index. Indexes in this collection are zero-based.

            The ArrayList collection accepts null as a valid value. It also allows duplicate elements.

            Using multidimensional arrays as elements in an ArrayList collection is not supported.

            Capacity:

                • Capacity is the number of elements that the ArrayList can store.Count is the number of elements that 
                  are actually in the ArrayList.
                • Capacity is always greater than or equal to Count.If Count exceeds Capacity while adding elements, 
                  the capacity is automatically increased by reallocating the internal array before copying the old 
                  elements and adding the new elements.
                • The capacity can be decreased by calling TrimToSize or by setting the Capacity property explicitly. 
                  When the value of Capacity is set explicitly, the internal array is also reallocated to accommodate 
                  the specified capacity.
                • Retrieving the value of this property is an O(1) operation; setting the property is an O(n) 
                  operation, where n is the new capacity.

            Performance Considerations:

                • For a heterogeneous collection of objects, use the List<Object> type.
                • For a homogeneous collection of objects, use the List<T> class.
            
            An ArrayList can support multiple readers concurrently, as long as the collection is not modified. To 
            guarantee the thread safety of the ArrayList, all operations must be done through the wrapper returned by 
            the Synchronized(IList) method.

            Enumerating through a collection is intrinsically not a thread-safe procedure. Even when a collection is 
            synchronized, other threads can still modify the collection, which causes the enumerator to throw an 
            exception. To guarantee thread safety during enumeration, you can either lock the collection during the 
            entire enumeration or catch the exceptions resulting from changes made by other threads.
            
            */
            Console.WriteLine("* Using ArrayList");
            {
                // Creates and initializes a new ArrayList.
                ArrayList arrayList = new ArrayList();
                arrayList.Add("Hello");
                arrayList.Add("World");
                arrayList.Add("!");

                // Displays the properties and values of the ArrayList.
                Console.WriteLine("ArrayList");
                Console.WriteLine("    Count:    {0}", arrayList.Count);
                Console.WriteLine("    Capacity: {0}", arrayList.Capacity);
                Console.Write("    Values:");
                printValues(arrayList);

                /*
                
                This code produces output similar to the following:

                ArrayList
                    Count:    3
                    Capacity: 4
                    Values:   Hello   World   !

                */
            }
        }

        // Manages a compact array of bit values, which are represented as Booleans, where true indicates that the bit 
        // is on (1) and false indicates the bit is off (0).
        public static void UsingBitArray()
        {
            /*
            
            https://docs.microsoft.com/en-us/dotnet/api/system.collections.bitarray?view=netframework-4.7.2

            The BitArray class is a collection class in which the capacity is always the same as the count. Elements 
            are added to a BitArray by increasing the Length property; elements are deleted by decreasing the Length 
            property. The size of a BitArray is controlled by the client; indexing past the end of the BitArray throws 
            an ArgumentException. The BitArray class provides methods that are not found in other collections, 
            including those that allow multiple elements to be modified at once using a filter, such as And, Or, Xor, 
            Not, and SetAll.

            The BitVector32 class is a structure that provides the same functionality as BitArray, but with faster 
            performance. BitVector32 is faster because it is a value type and therefore allocated on the stack, whereas 
            BitArray is a reference type and, therefore, allocated on the heap.

            System.Collections.Specialized.BitVector32 can store exactly 32 bits, whereas BitArray can store a variable 
            number of bits. BitVector32 stores both bit flags and small integers, thereby making it ideal for data that 
            is not exposed to the user. However, if the number of required bit flags is unknown, is variable, or is 
            greater than 32, use BitArray instead.

            BitArray is in the System.Collections namespace; BitVector32 is in the System.Collections.Specialized 
            namespace.

            Elements in this collection can be accessed using an integer index. Indexes in this collection are 
            zero-based.

            This implementation does not provide a synchronized (thread safe) wrapper for a BitArray.

            Enumerating through a collection is intrinsically not a thread-safe procedure. Even when a collection is 
            synchronized, other threads can still modify the collection, which causes the enumerator to throw an 
            exception. To guarantee thread safety during enumeration, you can either lock the collection during the 
            entire enumeration or catch the exceptions resulting from changes made by other threads.
            
            */
            Console.WriteLine("* Using BitArray");
            {
                // Creates and initializes several BitArrays.
                BitArray bitArray1 = new BitArray(5);
                BitArray bitArray2 = new BitArray(5, false);

                byte[] someBytes = new byte[5] { 1, 2, 3, 4, 5 };
                BitArray bitArray3 = new BitArray(someBytes);

                bool[] someBools = new bool[5] { true, false, true, true, false };
                BitArray bitArray4 = new BitArray(someBools);

                int[] someInts = new int[5] { 6, 7, 8, 9, 10 };
                BitArray bitArray5 = new BitArray(someInts);

                // Displays the properties and values of the BitArrays.
                Console.WriteLine("BitArray1");
                Console.WriteLine("   Count:    {0}", bitArray1.Count);
                Console.WriteLine("   Length:   {0}", bitArray1.Length);
                Console.WriteLine("   Values:");
                printValues(bitArray1, 8);

                Console.WriteLine("BitArray2");
                Console.WriteLine("   Count:    {0}", bitArray2.Count);
                Console.WriteLine("   Length:   {0}", bitArray2.Length);
                Console.WriteLine("   Values:");
                printValues(bitArray2, 8);

                Console.WriteLine("BitArray3");
                Console.WriteLine("   Count:    {0}", bitArray3.Count);
                Console.WriteLine("   Length:   {0}", bitArray3.Length);
                Console.WriteLine("   Values:");
                printValues(bitArray3, 8);

                Console.WriteLine("BitArray4");
                Console.WriteLine("   Count:    {0}", bitArray4.Count);
                Console.WriteLine("   Length:   {0}", bitArray4.Length);
                Console.WriteLine("   Values:");
                printValues(bitArray4, 8);

                Console.WriteLine("BitArray5");
                Console.WriteLine("   Count:    {0}", bitArray5.Count);
                Console.WriteLine("   Length:   {0}", bitArray5.Length);
                Console.WriteLine("   Values:");
                printValues(bitArray5, 8);

                /* 
                
                This code produces the following output.

                BitArray1
                   Count:    5
                   Length:   5
                   Values:
                   False   False   False   False   False
                BitArray2
                   Count:    5
                   Length:   5
                   Values:
                   False   False   False   False   False
                BitArray3
                   Count:    40
                   Length:   40
                   Values:
                    True   False   False   False   False   False   False   False
                   False    True   False   False   False   False   False   False
                    True    True   False   False   False   False   False   False
                   False   False    True   False   False   False   False   False
                    True   False    True   False   False   False   False   False
                BitArray4
                   Count:    5
                   Length:   5
                   Values:
                    True   False    True    True   False
                BitArray5
                   Count:    160
                   Length:   160
                   Values:
                   False    True    True   False   False   False   False   False
                   False   False   False   False   False   False   False   False
                   False   False   False   False   False   False   False   False
                   False   False   False   False   False   False   False   False
                    True    True    True   False   False   False   False   False
                   False   False   False   False   False   False   False   False
                   False   False   False   False   False   False   False   False
                   False   False   False   False   False   False   False   False
                   False   False   False    True   False   False   False   False
                   False   False   False   False   False   False   False   False
                   False   False   False   False   False   False   False   False
                   False   False   False   False   False   False   False   False
                    True   False   False    True   False   False   False   False
                   False   False   False   False   False   False   False   False
                   False   False   False   False   False   False   False   False
                   False   False   False   False   False   False   False   False
                   False    True   False    True   False   False   False   False
                   False   False   False   False   False   False   False   False
                   False   False   False   False   False   False   False   False
                   False   False   False   False   False   False   False   False
                
                */
            }
        }

        // Represents a collection of key/value pairs that are organized based on the hash code of 
        // the key.
        public static void UsingHashTable()
        {
            /*
            
            https://docs.microsoft.com/en-us/dotnet/api/system.collections.hashtable?view=netframework-4.7.2

            Each element is a key/value pair stored in a DictionaryEntry object. A key cannot be null, but a value can 
            be.

            The objects used as keys by a Hashtable are required to override the Object.GetHashCode method (or the 
            IHashCodeProvider interface) and the Object.Equals method (or the IComparer interface). The implementation 
            of both methods and interfaces must handle case sensitivity the same way; otherwise, the Hashtable might 
            behave incorrectly. For example, when creating a Hashtable, you must use the 
            CaseInsensitiveHashCodeProvider class (or any case-insensitive IHashCodeProvider implementation) with the 
            CaseInsensitiveComparer class (or any case-insensitive IComparer implementation).

            Furthermore, these methods must produce the same results when called with the same parameters while the key 
            exists in the Hashtable. An alternative is to use a Hashtable constructor with an IEqualityComparer 
            parameter. If key equality were simply reference equality, the inherited implementation of 
            Object.GetHashCode and Object.Equals would suffice.

            Key objects must be immutable as long as they are used as keys in the Hashtable.

            When an element is added to the Hashtable, the element is placed into a bucket based on the hash code of 
            the key. Subsequent lookups of the key use the hash code of the key to search in only one particular 
            bucket, thus substantially reducing the number of key comparisons required to find an element.

            The load factor of a Hashtable determines the maximum ratio of elements to buckets. Smaller load factors 
            cause faster average lookup times at the cost of increased memory consumption. The default load factor of 
            1.0 generally provides the best balance between speed and size. A different load factor can also be 
            specified when the Hashtable is created.

            As elements are added to a Hashtable, the actual load factor of the Hashtable increases. When the actual 
            load factor reaches the specified load factor, the number of buckets in the Hashtable is automatically 
            increased to the smallest prime number that is larger than twice the current number of Hashtable buckets.

            Each key object in the Hashtable must provide its own hash function, which can be accessed by calling 
            GetHash. However, any object implementing IHashCodeProvider can be passed to a Hashtable constructor, and 
            that hash function is used for all objects in the table.

            The capacity of a Hashtable is the number of elements the Hashtable can hold. As elements are added to a 
            Hashtable, the capacity is automatically increased as required through reallocation.

            Hashtable is thread safe for use by multiple reader threads and a single writing thread. It is thread safe 
            for multi-thread use when only one of the threads perform write (update) operations, which allows for 
            lock-free reads provided that the writers are serialized to the Hashtable. To support multiple writers all 
            operations on the Hashtable must be done through the wrapper returned by the Synchronized(Hashtable) 
            method, provided that there are no threads reading the Hashtable object.

            Enumerating through a collection is intrinsically not a thread safe procedure. Even when a collection is 
            synchronized, other threads can still modify the collection, which causes the enumerator to throw an 
            exception. To guarantee thread safety during enumeration, you can either lock the collection during the 
            entire enumeration or catch the exceptions resulting from changes made by other threads.
            
            */
            Console.WriteLine("* Using HashTable");
            {
                // Create a new hash table.
                Hashtable openWith = new Hashtable();

                // Add some elements to the hash table. There are no duplicate keys, but some of the values are 
                // duplicates.
                openWith.Add("txt", "notepad.exe");
                openWith.Add("bmp", "paint.exe");
                openWith.Add("dib", "paint.exe");
                openWith.Add("rtf", "wordpad.exe");

                // The Add method throws an exception if the new key is already in the hash table.
                try
                {
                    openWith.Add("txt", "winword.exe");
                }
                catch
                {
                    Console.WriteLine("An element with Key = \"txt\" already exists.");
                }

                // The Item property is the default property, so you can omit its name when accessing elements. 
                Console.WriteLine("For key = \"rtf\", value = {0}.", openWith["rtf"]);

                // The default Item property can be used to change the value associated with a key.
                openWith["rtf"] = "winword.exe";
                Console.WriteLine("For key = \"rtf\", value = {0}.", openWith["rtf"]);

                // If a key does not exist, setting the default Item property for that key adds a new key/value pair.
                openWith["doc"] = "winword.exe";

                // ContainsKey can be used to test keys before inserting them.
                if (!openWith.ContainsKey("ht"))
                {
                    openWith.Add("ht", "hypertrm.exe");
                    Console.WriteLine("Value added for key = \"ht\": {0}", openWith["ht"]);
                }

                // When you use foreach to enumerate hash table elements, the elements are retrieved as KeyValuePair 
                // objects.
                Console.WriteLine();
                foreach (DictionaryEntry de in openWith)
                {
                    Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
                }

                // To get the values alone, use the Values property.
                ICollection valueColl = openWith.Values;

                // The elements of the ValueCollection are strongly typed with the type that was specified for hash 
                // table values.
                Console.WriteLine();
                foreach (string s in valueColl)
                {
                    Console.WriteLine("Value = {0}", s);
                }

                // To get the keys alone, use the Keys property.
                ICollection keyColl = openWith.Keys;

                // The elements of the KeyCollection are strongly typed with the type that was specified for hash table 
                // keys.
                Console.WriteLine();
                foreach (string s in keyColl)
                {
                    Console.WriteLine("Key = {0}", s);
                }

                // Use the Remove method to remove a key/value pair.
                Console.WriteLine("\nRemove(\"doc\")");
                openWith.Remove("doc");

                if (!openWith.ContainsKey("doc"))
                {
                    Console.WriteLine("Key \"doc\" is not found.");
                }

                /*
                
                This code example produces the following output:

                An element with Key = "txt" already exists.
                For key = "rtf", value = wordpad.exe.
                For key = "rtf", value = winword.exe.
                Value added for key = "ht": hypertrm.exe

                Key = dib, Value = paint.exe
                Key = txt, Value = notepad.exe
                Key = ht, Value = hypertrm.exe
                Key = bmp, Value = paint.exe
                Key = rtf, Value = winword.exe
                Key = doc, Value = winword.exe

                Value = paint.exe
                Value = notepad.exe
                Value = hypertrm.exe
                Value = paint.exe
                Value = winword.exe
                Value = winword.exe

                Key = dib
                Key = txt
                Key = ht
                Key = bmp
                Key = rtf
                Key = doc

                Remove("doc")
                Key "doc" is not found.
                
                */
            }
        }

        // Represents a first-in, first-out collection of objects.
        public static void UsingQueue()
        {
            /*
             
            https://docs.microsoft.com/en-us/dotnet/api/system.collections.queue?view=netframework-4.7.2

            This class implements a queue as a circular array. Objects stored in a Queue are inserted at one end and 
            removed from the other.

            Queues and stacks are useful when you need temporary storage for information; that is, when you might want 
            to discard an element after retrieving its value. Use Queue if you need to access the information in the 
            same order that it is stored in the collection. Use Stack if you need to access the information in reverse 
            order. Use ConcurrentQueue<T> or ConcurrentStack<T> if you need to access the collection from multiple 
            threads concurrently.

            Three main operations can be performed on a Queue and its elements:

                • Enqueue adds an element to the end of the Queue.
                • Dequeue removes the oldest element from the start of the Queue.
                • Peek returns the oldest element that is at the start of the Queue but does not remove it from the 
                  Queue.
             
            The capacity of a Queue is the number of elements the Queue can hold. As elements are added to a Queue, the 
            capacity is automatically increased as required through reallocation. The capacity can be decreased by 
            calling TrimToSize.

            The growth factor is the number by which the current capacity is multiplied when a greater capacity is 
            required. The growth factor is determined when the Queue is constructed. The default growth factor is 2.0. 
            The capacity of the Queue will always increase by at least a minimum of four, regardless of the growth 
            factor. For example, a Queue with a growth factor of 1.0 will always increase in capacity by four when a 
            greater capacity is required.

            Queue accepts null as a valid value and allows duplicate elements.

            To guarantee the thread safety of the Queue, all operations must be done through the wrapper returned by 
            the Synchronized(Queue) method.

            Enumerating through a collection is intrinsically not a thread-safe procedure. Even when a collection is 
            synchronized, other threads can still modify the collection, which causes the enumerator to throw an 
            exception. To guarantee thread safety during enumeration, you can either lock the collection during the 
            entire enumeration or catch the exceptions resulting from changes made by other threads.

            */
            Console.WriteLine("* Using Queue");
            {
                // Creates and initializes a new Queue.
                Queue queue = new Queue();
                queue.Enqueue("Hello");
                queue.Enqueue("World");
                queue.Enqueue("!");

                // Displays the properties and values of the Queue.
                Console.WriteLine("Queue");
                Console.WriteLine("\tCount:    {0}", queue.Count);
                Console.Write("\tValues:");
                printValues(queue);

                /* 
                
                This code produces the following output.
 
                Queue
                    Count:    3
                    Values:    Hello    World    !
                */
            }
        }

        // Represents a collection of key/value pairs that are sorted by the keys and are accessible by key and by 
        // index.
        public static void UsingSortedList()
        {
            /*
             
            https://docs.microsoft.com/en-us/dotnet/api/system.collections.sortedlist?view=netframework-4.7.2

            A SortedList element can be accessed by its key, like an element in any IDictionary implementation or by 
            its index, like an element in any IList implementation.

            A SortedList object internally maintains two arrays to store the elements of the list; that is, one array 
            for the keys and another array for the associated values. Each element is a key/value pair that can be 
            accessed as a DictionaryEntry object. A key cannot be null, but a value can be.

            The capacity of a SortedList object is the number of elements the SortedList can hold. As elements are 
            added to a SortedList, the capacity is automatically increased as required through reallocation. The 
            capacity can be decreased by calling TrimToSize or by setting the Capacity property explicitly.

            .NET Framework only: For very large SortedList objects, you can increase the maximum capacity to 2 billion 
            elements on a 64-bit system by setting the enabled attribute of the <gcAllowVeryLargeObjects> configuration 
            element to true in the run-time environment.

            The elements of a SortedList object are sorted by the keys either according to a specific IComparer 
            implementation specified when the SortedList is created or according to the IComparable implementation 
            provided by the keys themselves. In either case, a SortedList does not allow duplicate keys.

            The index sequence is based on the sort sequence. When an element is added, it is inserted into SortedList 
            in the correct sort order, and the indexing adjusts accordingly. When an element is removed, the indexing 
            also adjusts accordingly. Therefore, the index of a specific key/value pair might change as elements are 
            added or removed from the SortedList object.

            Operations on a SortedList object tend to be slower than operations on a Hashtable object because of the 
            sorting. However, the SortedList offers more flexibility by allowing access to the values either through 
            the associated keys or through the indexes.

            Elements in this collection can be accessed using an integer index. Indexes in this collection are 
            zero-based.
            
            A SortedList object can support multiple readers concurrently, as long as the collection is not modified. 
            To guarantee the thread safety of the SortedList, all operations must be done through the wrapper returned 
            by the Synchronized(SortedList) method.

            Enumerating through a collection is intrinsically not a thread-safe procedure. Even when a collection is 
            synchronized, other threads can still modify the collection, which causes the enumerator to throw an 
            exception. To guarantee thread safety during enumeration, you can either lock the collection during the 
            entire enumeration or catch the exceptions resulting from changes made by other threads.

            */
            Console.WriteLine("* Using SortedList");
            {
                // Creates and initializes a new SortedList.
                SortedList sortedList = new SortedList();
                sortedList.Add("Third", "!");
                sortedList.Add("Second", "World");
                sortedList.Add("First", "Hello");

                // Displays the properties and values of the SortedList.
                Console.WriteLine("SortedList");
                Console.WriteLine("  Count:    {0}", sortedList.Count);
                Console.WriteLine("  Capacity: {0}", sortedList.Capacity);
                Console.WriteLine("  Keys and Values:");
                printKeysAndValues(sortedList);

                /*
                
                This code produces the following output.

                SortedList
                  Count:    3
                  Capacity: 16
                  Keys and Values:
                    -KEY-    -VALUE-
                    First:    Hello
                    Second:    World
                    Third:    !
                
                */
            }
        }

        // Represents a simple last-in-first-out (LIFO) non-generic collection of objects.
        public static void UsingStack()
        {
            /*
            
            https://docs.microsoft.com/en-us/dotnet/api/system.collections.stack?view=netframework-4.7.2

            The capacity of a Stack is the number of elements the Stack can hold. As elements are added to a Stack, the 
            capacity is automatically increased as required through reallocation.

            If Count is less than the capacity of the stack, Push is an O(1) operation. If the capacity needs to be 
            increased to accommodate the new element, Push becomes an O(n) operation, where n is Count. Pop is an O(1) 
            operation.

            Stack accepts null as a valid value and allows duplicate elements.

            To guarantee the thread safety of the Stack, all operations must be done through the wrapper returned by 
            the Synchronized(Stack) method.

            Enumerating through a collection is intrinsically not a thread-safe procedure. Even when a collection is 
            synchronized, other threads can still modify the collection, which causes the enumerator to throw an 
            exception. To guarantee thread safety during enumeration, you can either lock the collection during the 
            entire enumeration or catch the exceptions resulting from changes made by other threads.

            */
            Console.WriteLine("* Using Stack");
            {
                // Creates and initializes a new Stack.
                Stack stack = new Stack();
                stack.Push("Hello");
                stack.Push("World");
                stack.Push("!");

                // Displays the properties and values of the Stack.
                Console.WriteLine("Stack");
                Console.WriteLine("\tCount:    {0}", stack.Count);
                Console.Write("\tValues:");
                printValues(stack);

                /* 
                
                This code produces the following output.

                Stack
                    Count:    3
                    Values:    !    World    Hello

                */
            }
        }

        // Implements IDictionary using a singly linked list. Recommended for collections that typically include fewer 
        // than 10 items.
        public static void UsingListDictionary()
        {
            /*
            
            https://docs.microsoft.com/en-us/dotnet/api/system.collections.specialized.listdictionary?view=netframework-4.7.2

            */
            Console.WriteLine("* Using ListDictionary");
            {
                // TODO 
            }
        }

        // Implements IDictionary by using a ListDictionary while the collection is small, and then switching to a 
        // Hashtable when the collection gets large.
        public static void UsingHybridDictionary()
        {
            /*
            
            https://docs.microsoft.com/en-us/dotnet/api/system.collections.specialized.hybriddictionary?view=netframework-4.7.2

            */
            Console.WriteLine("* Using HybridDictionary");
            {
                // TODO
            }
        }

        // Represents a collection of key/value pairs that are accessible by the key or index.
        public static void UsingOrderedDictionary()
        {
            /*
            
            https://docs.microsoft.com/en-us/dotnet/api/system.collections.specialized.ordereddictionary?view=netframework-4.7.2

            */
            Console.WriteLine("* Using OrderedDictionary");
            {
                // TODO
            }
        }

        // Represents a collection of associated String keys and String values that can be accessed either with the key 
        // or with the index.
        public static void UsingNameValueCollection()
        {
            /*
            
            https://docs.microsoft.com/en-us/dotnet/api/system.collections.specialized.namevaluecollection?view=netframework-4.7.2

            */
            Console.WriteLine("* Using NameValueCollection");
            {
                // TODO
            }
        }

        // Represents a collection of strings.
        public static void UsingStringCollection()
        {
            /*
            
            https://docs.microsoft.com/en-us/dotnet/api/system.collections.specialized.stringcollection?view=netframework-4.7.2

            StringCollection accepts null as a valid value and allows duplicate elements.

            String comparisons are case-sensitive.

            Elements in this collection can be accessed using an integer index. Indexes in this collection are 
            zero-based.

            This implementation does not provide a synchronized (thread safe) wrapper for a StringCollection, but 
            derived classes can create their own synchronized versions of the StringCollection using the SyncRoot 
            property.

            Enumerating through a collection is intrinsically not a thread safe procedure. Even when a collection is 
            synchronized, other threads can still modify the collection, which causes the enumerator to throw an 
            exception. To guarantee thread safety during enumeration, you can either lock the collection during the 
            entire enumeration or catch the exceptions resulting from changes made by other threads.

            */
            Console.WriteLine("* Using StringCollection");
            {
                // Create and initializes a new StringCollection.
                StringCollection column = new StringCollection();

                // Add a range of elements from an array to the end of the StringCollection.
                String[] array = new String[] 
                {
                    "RED", "orange", "yellow", "RED", "green", "blue", "RED", "indigo", "violet", "RED"
                };
                column.AddRange(array);

                // Display the contents of the collection using foreach. This is the preferred method.
                Console.WriteLine("Displays the elements using foreach:");
                printValues1(column);

                // Display the contents of the collection using the enumerator.
                Console.WriteLine("Displays the elements using the IEnumerator:");
                printValues2(column);

                // Display the contents of the collection using the Count and Item properties.
                Console.WriteLine("Displays the elements using the Count and Item properties:");
                printValues3(column);

                // Add one element to the end of the StringCollection and insert another at index 3.
                column.Add("* white");
                column.Insert(3, "* gray");

                Console.WriteLine("After adding \"* white\" to the end and inserting \"* gray\" at index 3:");
                printValues1(column);

                // Remove one element from the StringCollection.
                column.Remove("yellow");

                Console.WriteLine("After removing \"yellow\":");
                printValues1(column);

                // Remove all occurrences of a value from the StringCollection.
                int i = column.IndexOf("RED");
                while (i > -1)
                {
                    column.RemoveAt(i);
                    i = column.IndexOf("RED");
                }

                // Verify that all occurrences of "RED" are gone.
                if (column.Contains("RED"))
                {
                    Console.WriteLine("*** The collection still contains \"RED\".");
                }

                Console.WriteLine("After removing all occurrences of \"RED\":");
                printValues1(column);

                // Copy the collection to a new array starting at index 0.
                String[] myArr2 = new String[column.Count];
                column.CopyTo(myArr2, 0);

                Console.WriteLine("The new array contains:");
                for (i = 0; i < myArr2.Length; i++)
                {
                    Console.WriteLine("   [{0}] {1}", i, myArr2[i]);
                }
                Console.WriteLine();

                // Clears the entire collection.
                column.Clear();

                Console.WriteLine("After clearing the collection:");
                printValues1(column);

                /*
                
                This code produces the following output.

                Displays the elements using foreach:
                   RED
                   orange
                   yellow
                   RED
                   green
                   blue
                   RED
                   indigo
                   violet
                   RED

                Displays the elements using the IEnumerator:
                   RED
                   orange
                   yellow
                   RED
                   green
                   blue
                   RED
                   indigo
                   violet
                   RED

                Displays the elements using the Count and Item properties:
                   RED
                   orange
                   yellow
                   RED
                   green
                   blue
                   RED
                   indigo
                   violet
                   RED

                After adding "* white" to the end and inserting "* gray" at index 3:
                   RED
                   orange
                   yellow
                   * gray
                   RED
                   green
                   blue
                   RED
                   indigo
                   violet
                   RED
                   * white

                After removing "yellow":
                   RED
                   orange
                   * gray
                   RED
                   green
                   blue
                   RED
                   indigo
                   violet
                   RED
                   * white

                After removing all occurrences of "RED":
                   orange
                   * gray
                   green
                   blue
                   indigo
                   violet
                   * white

                The new array contains:
                   [0] orange
                   [1] * gray
                   [2] green
                   [3] blue
                   [4] indigo
                   [5] violet
                   [6] * white

                After clearing the collection:

                */
            }
        }

        // Implements a hash table with the key and the value strongly typed to be strings rather 
        // than objects.
        public static void UsingStringDictionary()
        {
            /*
            
            https://docs.microsoft.com/en-us/dotnet/api/system.collections.specialized.stringdictionary?view=netframework-4.7.2

            A key cannot be null, but a value can.

            The key is handled in a case-insensitive manner; it is translated to lowercase before 
            it is used with the string dictionary.

            In .NET Framework version 1.0, this class uses culture-sensitive string comparisons. 
            However, in .NET Framework version 1.1 and later, this class uses 
            CultureInfo.InvariantCulture when comparing strings.

            This implementation does not provide a synchronized (thread safe) wrapper for a 
            StringDictionary, but derived classes can create their own synchronized versions of the 
            StringDictionary using the SyncRoot property.

            Enumerating through a collection is intrinsically not a thread-safe procedure. Even 
            when a collection is synchronized, other threads can still modify the collection, which 
            causes the enumerator to throw an exception. To guarantee thread safety during 
            enumeration, you can either lock the collection during the entire enumeration or catch 
            the exceptions resulting from changes made by other threads.
            
            */
            Console.WriteLine("* Using StringDictionary");
            {
                // Creates and initializes a new StringDictionary.
                StringDictionary column = new StringDictionary();
                column.Add("red", "rojo");
                column.Add("green", "verde");
                column.Add("blue", "azul");

                // Display the contents of the collection using foreach. This is the preferred method.
                Console.WriteLine("Displays the elements using foreach:");
                printKeysAndValues1(column);

                // Display the contents of the collection using the enumerator.
                Console.WriteLine("Displays the elements using the IEnumerator:");
                printKeysAndValues2(column);

                // Display the contents of the collection using the Keys, Values, Count, and Item properties.
                Console.WriteLine("Displays the elements using the Keys, Values, Count, and Item properties:");
                printKeysAndValues3(column);

                // Copies the StringDictionary to an array with DictionaryEntry elements.
                DictionaryEntry[] myArr = new DictionaryEntry[column.Count];
                column.CopyTo(myArr, 0);

                // Displays the values in the array.
                Console.WriteLine("Displays the elements in the array:");
                Console.WriteLine("   KEY        VALUE");
                for (int i = 0; i < myArr.Length; i++)
                {
                    Console.WriteLine("   {0,-10} {1}", myArr[i].Key, myArr[i].Value);
                }
                Console.WriteLine();

                // Searches for a value.
                if (column.ContainsValue("amarillo"))
                {
                    Console.WriteLine("The collection contains the value \"amarillo\".");
                }
                else
                {
                    Console.WriteLine("The collection does not contain the value \"amarillo\".");
                }
                Console.WriteLine();

                // Searches for a key and deletes it.
                if (column.ContainsKey("green"))
                {
                    column.Remove("green");
                }
                Console.WriteLine("The collection contains the following elements after removing \"green\":");
                printKeysAndValues1(column);

                // Clears the entire collection.
                column.Clear();
                Console.WriteLine("The collection contains the following elements after it is cleared:");
                printKeysAndValues1(column);

                /*
                
                This code produces the following output.

                Displays the elements using foreach:
                   KEY                       VALUE
                   red                       rojo
                   blue                      azul
                   green                     verde

                Displays the elements using the IEnumerator:
                   KEY                       VALUE
                   red                       rojo
                   blue                      azul
                   green                     verde

                Displays the elements using the Keys, Values, Count, and Item properties:
                   INDEX KEY                       VALUE
                   0     red                       rojo
                   1     blue                      azul
                   2     green                     verde

                Displays the elements in the array:
                   KEY        VALUE
                   red        rojo
                   blue       azul
                   green      verde

                The collection does not contain the value "amarillo".

                The collection contains the following elements after removing "green":
                   KEY                       VALUE
                   red                       rojo
                   blue                      azul

                The collection contains the following elements after it is cleared:
                   KEY                       VALUE

                */
            }
        }

        // Provides a simple structure that stores Boolean values and small integers in 32 bits of 
        // memory.
        public static void UsingBitVector32()
        {
            /*
            
            https://docs.microsoft.com/en-us/dotnet/api/system.collections.specialized.bitvector32?view=netframework-4.7.2

            */
            Console.WriteLine("* Using BitVector32");
            {
                // TODO
            }
        }

        #endregion
    }
}