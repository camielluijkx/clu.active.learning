using System;

namespace clu.active.learning
{
    /*
    Collections:
        • List classes store linear collections of items. You can think of a list class as a one-dimensional array that dynamically expands as you add items.
        • Dictionary classes store a collection of key/value pairs. Each item in the collection consists of two objects—the key and the value. The value is the object you want to store and retrieve, and the key is the object that you use to index and look up the value. In most dictionary classes, the key must be unique, whereas duplicate values are perfectly acceptable.
        • Queue classes represent a first in, first out collection of objects. Items are retrieved from the collection in the same order they were added.
        • Stack classes represent a last in, first out collection of objects. The item that you added to the collection last is the first item you retrieve.

    The System.Collections namespace provides a range of general-purpose collections that includes lists, dictionaries, queues, and stacks.
    
    Class                   Description
    ArrayList               The ArrayList is a general-purpose list that stores a linear collection of objects. The ArrayList includes methods and                           properties that enable you to add items, remove items, count the number of items in the collection, and sort the                                 collection.
    BitArray                The BitArray is a list class that represents a collection of bits as Boolean values. The BitArray is most commonly used for                      bitwise operations and Boolean arithmetic, and includes methods to perform common Boolean operations such as AND, NOT, and                       XOR.
    Hashtable               The Hashtable class is a general-purpose dictionary class that stores a collection of key/value pairs. The Hashtable                             includes methods and properties that enable you to retrieve items by key, add items, remove items, and check for particular                      keys and values within the collection.
    Queue                   The Queue class is a first in, last out collection of objects. The Queue includes methods to add objects to the back of the                      queue (Enqueue) and retrieve objects from the front of the queue (Dequeue).
    SortedList              The SortedList class stores a collection of key/value pairs that are sorted by key. In addition to the functionality                             provided  by the Hashtable class, the SortedList enables you to retrieve items either by key or by index.
    Stack                   The Stack class is a first in, first out collection of objects. The Stack includes methods to view the top item in the                           collection without removing it (Peek), add an item to the top of the stack (Push), and remove and return the item at the                         top of the stack (Pop).

    The System.Collections.Specialized namespace provides collection classes that are suitable for more specialized requirements, such as specialized dictionary collections and strongly typed string collections.

    Class                   Description
    ListDictionary          The ListDictionary is a dictionary class that is optimized for small collections. As a general rule, if your collection                          includes 10 items or fewer, use a ListDictionary. If your collection is larger, use a Hashtable.
    HybridDictionary        The HybridDictionary is a dictionary class that you can use when you cannot estimate the size of the collection. The                             HybridDictionary uses a ListDictionary implementation when the collection size is small, and switches to a Hashtable                             implementation as the collection size grows larger.
    OrderedDictionary       The OrderedDictionary is an indexed dictionary class that enables you to retrieve items by key or by index. Note that                            unlike the SortedList class, items in an OrderedDictionary are not sorted by key.
    NameValueCollection     The NameValueCollection is an indexed dictionary class in which both the key and the value are strings. The                                      NameValueCollection will throw an error if you attempt to set a key or a value to anything other than a string. You can                          retrieve items by key or by index.
    StringCollection        The StringCollection is a list class in which every item in the collection is a string. Use this class when you want to                          store a simple, linear collection of strings.
    StringDictionary        The StringDictionary is a dictionary class in which both the key and the value are strings. Unlike the NameValueCollection                       class, you cannot retrieve items from a StringDictionary by index.
    BitVector32             The BitVector32 is a struct that can represent a 32-bit value as both a bit array and an integer value. Unlike the BitArray                      class, which can expand indefinitely, the BitVector32 struct is a fixed 32-bit size. As a result, the BitVector32 is more                        efficient than the BitArray for small values. You can divide a BitVector32 instance into sections to efficiently store                           multiple values.

    */
    public static class Collections
    {
        #region Public Methods

        public static void UsingArrayList()
        {
            // TODO: https://docs.microsoft.com/en-us/dotnet/api/system.collections.arraylist?view=netframework-4.7.2
        }

        public static void UsingBitArray()
        {
            // TODO: https://docs.microsoft.com/en-us/dotnet/api/system.collections.bitarray?view=netframework-4.7.2
        }

        public static void UsingHashTable()
        {
            // TODO: https://docs.microsoft.com/en-us/dotnet/api/system.collections.hashtable?view=netframework-4.7.2
        }

        public static void UsingQueue()
        {
            // TODO: https://docs.microsoft.com/en-us/dotnet/api/system.collections.queue?view=netframework-4.7.2
        }

        public static void UsingSortedList()
        {
            // TODO: https://docs.microsoft.com/en-us/dotnet/api/system.collections.sortedlist?view=netframework-4.7.2
        }

        public static void UsingStack()
        {
            // TODO: https://docs.microsoft.com/en-us/dotnet/api/system.collections.stack?view=netframework-4.7.2
        }

        public static void UsingListDictionary()
        {
            // TODO: https://docs.microsoft.com/en-us/dotnet/api/system.collections.specialized.listdictionary?view=netframework-4.7.2
        }

        public static void UsingHybridDictionary()
        {
            // TODO: https://docs.microsoft.com/en-us/dotnet/api/system.collections.specialized.hybriddictionary?view=netframework-4.7.2
        }

        public static void UsingOrderedDictionary()
        {
            // TODO: https://docs.microsoft.com/en-us/dotnet/api/system.collections.specialized.ordereddictionary?view=netframework-4.7.2
        }

        public static void UsingNameValueCollection()
        {
            // TODO: https://docs.microsoft.com/en-us/dotnet/api/system.collections.specialized.namevaluecollection?view=netframework-4.7.2
        }

        public static void UsingStringCollection()
        {
            // TODO: https://docs.microsoft.com/en-us/dotnet/api/system.collections.specialized.stringcollection?view=netframework-4.7.2
        }

        public static void UsingStringDictionary()
        {
            // TODO: https://docs.microsoft.com/en-us/dotnet/api/system.collections.specialized.stringdictionary?view=netframework-4.7.2
        }

        public static void UsingBitVector32()
        {
            // TODO: https://docs.microsoft.com/en-us/dotnet/api/system.collections.specialized.bitvector32?view=netframework-4.7.2
        }

        #endregion
    }
}
