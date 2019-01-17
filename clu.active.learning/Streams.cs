using System;
using System.IO;
using System.Text;

namespace clu.active.learning
{
    /*
    
    The .NET Framework enables you to use streams. A stream is a sequence of bytes, which could come from a file on the 
    file system, a network connection, or memory. Streams enable you to read from or write to a data source in small, 
    manageable data packets. Typically, streams provide the following operations:

        • Reading chunks of data into a type, such as a byte array.
        • Writing chunks of data from a type to a stream.
        • Querying the current position in the stream and modifying a specific selection of bytes at the current 
          position.

    Streaming in the .NET Framework

    The .NET Framework provides several stream classes that enable you to work with a variety of data and data sources. 
    When choosing which stream classes to use, you need to consider the following:

        • What type of data you are reading or writing, for example, binary or alphanumeric.
        • Where the data is stored, for example, on the local file system, in memory, or on a web server over a 
          network.

    The .NET Framework class library provides several classes in the System.IO namespace that you can use to read and 
    write files by using streams. At the highest level of abstraction, the Stream class defines the common 
    functionality that all streams provide. The class provides a generic view of a sequence of bytes, together with the 
    operations and properties that all streams provide. Internally, a Stream object maintains a pointer that refers to 
    the current location in the data source. When you first construct a Stream object over a data source, this pointer 
    is positioned immediately before the first byte. As you read and write data, the Stream class advances this pointer 
    to the end of the data that is read or written.

    You cannot use the Stream class directly. Instead, you instantiate specializations of this class that are optimized 
    to perform stream-based I/O for specific types of data sources. For example, the FileStream class implements a 
    stream that uses a disk file as the data source, and the MemoryStream class implements a stream that uses a block 
    of memory as the data source.

    The .NET Framework provides many stream classes that you can use to read and write different types of data from 
    different types of data sources. The following table describes some of these stream classes, and when you might 
    want to use them.

    Stream class        Description
    FileStream          Enables you to establish a stream to a file on the file system. The FileStream class handles 
                        operations such as opening and closing the file, and provides access to the file through a raw 
                        sequence of bytes.
    MemoryStream        Enables you to establish a stream to a location in memory. The MemoryStream class handles 
                        operations such as acquiring the in-memory storage, and provides access to the memory location 
                        through a raw sequence of bytes.
    NetworkStream       Enables you to establish a stream to a network location in memory. The NetworkStream class 
                        handles operations such as opening and closing a connection to the network location, and 
                        provides access to the network location through a raw sequence of bytes.

    A stream that is established by using a FileStream, MemoryStream, or NetworkStream object is just a raw sequence of 
    bytes. If the source data is structured, you must convert the byte sequence into the appropriate types. This can be 
    a time-consuming and error-prone task. However, the .NET Framework contains classes that you can use to read and 
    write textual data and primitive types in a stream that you have opened by using the FileStream, MemoryStream, or 
    NetworkStream classes. The following table describes some of the stream reader and writer classes.

    Stream class        Description
    StreamReader        Enables you to read textual data from an underlying data source stream, such as a FileStream, 
                        MemoryStream, or NetworkStream object.
    StreamWriter        Enables you to write textual data to an underlying data source stream, such as a FileStream, 
                        MemoryStream, or NetworkStream object.
    BinaryReader        Enables you to read binary data from an underlying data source stream, such as a FileStream, 
                        MemoryStream, or NetworkStream object.
    BinaryWriter        Enables you to write binary data to an underlying data source stream, such as a FileStream, 
                        MemoryStream, or NetworkStream object.

    It’s best to use the IDisposable interface with a using statement, as opposed to directly using the Open and Close 
    methods.

    */
    public static class Streams
    {
        #region Implementation

        #endregion

        #region Public Methods

        /*
            
        After you have created a BinaryReader object, you can use its members to read the binary data. The following 
        list describes some of the key members:

            • The BaseStream property enables you to access the underlying stream that the BinaryReader object uses.
            • The Close method enables you to close the BinaryReader object and the underlying stream.
            • The Read method enables you to read the number of remaining bytes in the stream from a specific index.
            • The ReadByte method enables you to read the next byte from the stream, and advance the stream to the next 
              byte.
            • The ReadBytes method enables you to read a specified number of bytes into a byte array.

        Similarly, the BinaryWriter object exposes various members to enable you to write data to an underlying stream. 
        The following list describes some of the key members.

            • The BaseStream property enables you to access the underlying stream that the BinaryWiter object uses.
            • The Close method enables you to close the BinaryWiter object and the underlying stream.
            • The Flush method enables you to explicitly flush any data in the current buffer to the underlying stream.
            • The Seek method enables you to set your position in the current stream, thus writing to a specific byte.
            • The Write method enables you to write your data to the stream, and advance the stream. The Write method 
              provides several overloads that enable you to write all primitive data types to a stream.

        */
        public static void UsingBinaryReaderAndWriter()
        {
            Console.WriteLine("* Using Binary Reader and Writer");
            {
                Console.WriteLine("** Reading Binary Data");
                {
                    // Source file path.
                    string sourceFilePath = @"C:\fourthcoffee\applicationdata\settings.txt ";

                    // Create a FileStream object so that you can interact with the file system.
                    FileStream sourceFile = new FileStream(
                        sourceFilePath,   // Pass in the source file path.
                        FileMode.Open,    // Open an existing file.
                        FileAccess.Read); // Read an existing file.
                                          
                    // Create a BinaryWriter object passing in the FileStream object.
                    BinaryReader reader = new BinaryReader(sourceFile);

                    // Store the current position of the stream.
                    int position = 0;

                    // Store the length of the stream.
                    int length = (int)reader.BaseStream.Length;

                    // Create an array to store each byte from the file.
                    byte[] dataCollection = new byte[length];

                    int returnedByte;
                    while ((returnedByte = reader.Read()) != -1)
                    {
                        // Set the value at the next index.
                        dataCollection[position] = (byte)returnedByte;

                        // Advance our position variable.
                        position += sizeof(byte);
                    }

                    // Close the streams to release any file handles.
                    reader.Close();
                    sourceFile.Close();
                }

                Console.WriteLine("** Writing Binary Data");
                {
                    string destinationFilePath = @"C:\fourthcoffee\applicationdata\settings.txt";

                    // Collection of bytes.
                    byte[] dataCollection = { 1, 4, 6, 7, 12, 33, 26, 98, 82, 101 };

                    // Create a FileStream object so that you can interact with the file system.
                    FileStream destFile = new FileStream(
                        destinationFilePath, // Pass in the destination path.
                        FileMode.Create,     // Always create new file.
                        FileAccess.Write);   // Only perform writing.
                                             
                    // Create a BinaryWriter object passing in the FileStream object.
                    BinaryWriter writer = new BinaryWriter(destFile);

                    // Write each byte to stream.
                    foreach (byte data in dataCollection)
                    {
                        writer.Write(data);
                    }

                    // Close both streams to flush the data to the file.
                    writer.Close();
                    destFile.Close();
                }
            }
        }

        /*
                
        After you have created a StreamReader object, you can use its members to read the plain text. The following 
        list describes some of the key members:

            • The Close method enables you to close the StreamReader object and the underlying stream.
            • The EndOfStream property enables you to determine whether you have reached the end of the stream.
            • The Peek method enables you to get the next available character in the stream, but does not consume it.
            • The Read method enables you to get and consume the next available character in the stream. This method 
              returns an int variable that represents the binary of the character, which you may need to explicitly 
              convert.
            • The ReadBlock method enables you to read an entire block of characters from a specific index from the 
              stream.
            • The ReadLine method enables you to read an entire line of characters from the stream.
            • The ReadToEnd method enables you to read all characters from the current position in the stream.

        Similarly, the StreamWriter object exposes various members to enable you to write data to an underlying stream. 
        The following list describes some of the key members:

            • The AutoFlush property enables you to instruct the StreamWriter object to flush data to the underlying 
              stream after every write call.
            • The Close method enables you to close the StreamWriter object and the underlying stream.
            • The Flush method enables you to explicitly flush any data in the current buffer to the underlying stream.
            • The NewLine property enables you to get or set the characters that are used for new line breaks.
            • The Write method enables you to write your data to the stream, and to advance the stream.
            • The WriteLine method enables you to write your data to the stream followed by a new line break, and then 
              advance the stream. 
                      
        These members provide many options to suit many different requirements. If you do not want to store the entire 
        file in memory in a single chunk, you can use a combination of the Peek and Read methods to read each 
        character, one at a time. Similarly, if you want to write lines of text to a file one at time, you can use the 
        WriteLine method.

        */
        public static void UsingStreamReaderAndWriter()
        {
            Console.WriteLine("* Using Stream Reader and Writer");
            {
                Console.WriteLine("** Reading Plain Text");
                {
                    string sourceFilePath = @"C:\fourthcoffee\applicationdata\settings.txt ";
                    
                    // Create a FileStream object so that you can interact with the file system.
                    FileStream sourceFile = new FileStream(
                        sourceFilePath,  // Pass in the source file path.
                        FileMode.Open,   // Open an existing file.
                        FileAccess.Read);// Read an existing file.

                    StreamReader reader = new StreamReader(sourceFile);
                    StringBuilder fileContents = new StringBuilder();

                    // Check to see if the end of the file has been reached.
                    while (reader.Peek() != -1)
                    {
                        // Read the next character.
                        fileContents.Append((char)reader.Read());
                    }
                    // Store the file contents in a new string variable.
                    string data = fileContents.ToString();

                    // Always close the underlying streams release any file handles.
                    reader.Close();
                    sourceFile.Close();
                }

                Console.WriteLine("** Writing Plain Text");
                {
                    string destinationFilePath = @"C:\fourthcoffee\applicationdata\settings.txt ";
                    string data = "Hello, this will be written in plain text";
                    
                    // Create a FileStream object so that you can interact with the file system.
                    FileStream destFile = new FileStream(
                        destinationFilePath, // Pass in the destination path.
                        FileMode.Create,     // Always create new file.
                        FileAccess.Write);   // Only perform writing.
                                             
                    // Create a new StreamWriter object.
                    StreamWriter writer = new StreamWriter(destFile);
                    
                    // Write the string to the file.
                    writer.WriteLine(data);

                    // Always close the underlying streams to flush the data to the file and release any file handles.
                    writer.Close();
                    destFile.Close();
                }
            }
        }

        #endregion
    }
}
