using System;

namespace clu.active.learning
{
    /*
    
    The .NET Framework enables you to use streams. A stream is a sequence of bytes, which could 
    come from a file on the file system, a network connection, or memory. Streams enable you to 
    read from or write to a data source in small, manageable data packets. Typically, streams 
    provide the following operations:

        • Reading chunks of data into a type, such as a byte array.
        • Writing chunks of data from a type to a stream.
        • Querying the current position in the stream and modifying a specific selection of bytes 
          at the current position.

    Streaming in the .NET Framework

    The .NET Framework provides several stream classes that enable you to work with a variety of 
    data and data sources. When choosing which stream classes to use, you need to consider the 
    following:

        • What type of data you are reading or writing, for example, binary or alphanumeric.
        • Where the data is stored, for example, on the local file system, in memory, or on a web 
          server over a network.

    The .NET Framework class library provides several classes in the System.IO namespace that you 
    can use to read and write files by using streams. At the highest level of abstraction, the 
    Stream class defines the common functionality that all streams provide. The class provides a 
    generic view of a sequence of bytes, together with the operations and properties that all 
    streams provide. Internally, a Stream object maintains a pointer that refers to the current 
    location in the data source. When you first construct a Stream object over a data source, this 
    pointer is positioned immediately before the first byte. As you read and write data, the Stream 
    class advances this pointer to the end of the data that is read or written.

    You cannot use the Stream class directly. Instead, you instantiate specializations of this 
    class that are optimized to perform stream-based I/O for specific types of data sources. For 
    example, the FileStream class implements a stream that uses a disk file as the data source, and 
    the MemoryStream class implements a stream that uses a block of memory as the data source.

    The .NET Framework provides many stream classes that you can use to read and write different 
    types of data from different types of data sources. The following table describes some of these 
    stream classes, and when you might want to use them.

    Stream class        Description
    FileStream          Enables you to establish a stream to a file on the file system. The 
                        FileStream class handles operations such as opening and closing the file, 
                        and provides access to the file through a raw sequence of bytes.
    MemoryStream        Enables you to establish a stream to a location in memory. The MemoryStream 
                        class handles operations such as acquiring the in-memory storage, and 
                        provides access to the memory location through a raw sequence of bytes.
    NetworkStream       Enables you to establish a stream to a network location in memory. The 
                        NetworkStream class handles operations such as opening and closing a 
                        connection to the network location, and provides access to the network 
                        location through a raw sequence of bytes.

    A stream that is established by using a FileStream, MemoryStream, or NetworkStream object is 
    just a raw sequence of bytes. If the source data is structured, you must convert the byte 
    sequence into the appropriate types. This can be a time-consuming and error-prone task. 
    However, the .NET Framework contains classes that you can use to read and write textual data 
    and primitive types in a stream that you have opened by using the FileStream, MemoryStream, or 
    NetworkStream classes. The following table describes some of the stream reader and writer 
    classes.

    Stream class        Description
    StreamReader        Enables you to read textual data from an underlying data source stream, 
                        such as a FileStream, MemoryStream, or NetworkStream object.
    StreamWriter        Enables you to write textual data to an underlying data source stream, such 
                        as a FileStream, MemoryStream, or NetworkStream object.
    BinaryReader        Enables you to read binary data from an underlying data source stream, such 
                        as a FileStream, MemoryStream, or NetworkStream object.
    BinaryWriter        Enables you to write binary data to an underlying data source stream, such 
                        as a FileStream, MemoryStream, or NetworkStream object.

    */
    public static class Streams
    {
        #region Implementation

        #endregion

        #region Public Methods

        public static void UsingStreams()
        {
            Console.WriteLine("* Using Streams");
            {

            }
        }

        #endregion
    }
}
