using System;
using System.IO;

namespace clu.active.learning
{
    /*
     
    The File class in the System.IO namespace exposes several static methods that you can use 
    to perform transactional operations for direct reading and writing of files. These methods 
    are transactional because they wrap several underlying functions into a single method call. 
    Typically, to read data from a file, you: 

        1. Acquire the file handle.
        2. Open a stream to the file.
        3. Buffer the data from the file into memory.
        4. Release the file handle so that it can be reused.
         
    */
    public static class FileSystem
    {
        #region Public Methods

        public static void ReadingFiles()
        {
            Console.WriteLine("* Reading Files");
            {
                Console.WriteLine("Using File.ReadAllText");
                {
                    /*
                     
                    The ReadAllText method enables you to read the contents of a file into a single 
                    string variable. The following code example shows how to read the contents of 
                    the settings.txt file into a string named settings. 

                    */
                    string filePath = @"C:\fourthCoffee\settings.txt";
                    //string settings = File.ReadAllText(filePath);
                }

                Console.WriteLine("** Using ReadAllLines");
                {
                    /*
                     
                    The ReadAllLines method enables you to read the contents of a file and store each 
                    line at a new index in a string array. The following code example shows how to 
                    read the contents of the settings.txt file and store each line in the string array 
                    named settingsLineByLine.

                    */

                    string filePath = @"C:\fourthCoffee\settings.txt";
                    //string[] settingsLineByLine = File.ReadAllLines(filePath);
                }

                Console.WriteLine("** Using ReadAllBytes");
                {
                    /*
                    
                    The ReadAllBytes method enables you to read the contents of a file as binary data 
                    and store the data in a byte array. The following code example shows how to read 
                    the contents of the settings.txt file into a byte array named rawSettings.
                    
                    */

                    string filePath = @"C:\fourthCoffee\settings.txt";
                    //byte[] rawSettings = File.ReadAllBytes(filePath);
                }
            }
        }

        public static void WritingFiles()
        {
            Console.WriteLine("* Writing Files");
            {
                Console.WriteLine("** Using WriteAllText");
                {
                    /*
                     
                    The WriteAllText method enables you to write the contents of a string variable to a 
                    file. If the file exists, its contents will be overwritten. The following code example 
                    shows how to write the contents of a string named settings to a new file named 
                    settings.txt. 

                    */

                    string filePath = @"C:\fourthCoffee\settings.txt";
                    string settings = "companyName=fourth coffee;";
                    //File.WriteAllText(filePath, settings);
                }

                Console.WriteLine("** Using WriteAllLines");
                {
                    /* 
                    
                    The WriteAllLines method enables you to write the contents of a string array to a file.
                    Each entry in the string array represents a new line in the file. The following code 
                    example shows how to write the contents of a string array named hosts to a new file 
                    named hosts.txt.

                    */

                    string filePath = @"C:\fourthCoffee\hosts.txt ";
                    string[] hosts = { "86.120.1.203", "113.45.80.31", "168.195.23.29" };
                    //File.WriteAllLines(filePath, hosts);
                }

                Console.WriteLine("** Using WriteAllBytes");
                {
                    /*
                     
                    The WriteAllBytes method enables you to write the contents of a byte array to a binary 
                    file. The following code example shows how to write the contents of a byte array named 
                    rawSettings to a new file named settings.txt. 

                    */

                    string filePath = @"C:\fourthCoffee\setting.txt ";
                    byte[] rawSettings = {99,111,109,112,97,110,121,78,97,109,101,61,102,111,
                    117,114,116,104,32,99,111,102,102,101,101};
                    //File.WriteAllBytes(filePath, rawSettings);
                }

                Console.WriteLine("** Using AppendAllText");
                {
                    /*
                     
                    The AppendAllText method enables you to write the contents of a string variable to the 
                    end of an existing file. The following code example shows how to write the contents of 
                    a string variable named settings to the end of the existing settings.txt file. 

                    */

                    string filePath = @"C:\fourthCoffee\settings.txt";
                    string settings = "companyContact= Dean Halstead";
                    //File.AppendAllText(filePath, settings);
                }

                Console.WriteLine("** Using AppendAllLines");
                {
                    /*
                    
                    The AppendAllLines method enables you to write the contents of a string array to the end 
                    of an existing file. The following code example shows how to write the contents of a 
                    string array named newHosts to the existing hosts.txt file. 

                    */

                    string filePath = @"C:\fourthCoffee\hosts.txt ";
                    string[] newHosts = { "97.11.1.195", "203.194.40.177" };
                    //File.AppendAllLines(filePath, newHosts);
                }
            }
        }

        public static void FileManipulation()
        {
            Console.WriteLine("* File Manipulation");
            {
                Console.WriteLine("** Using File.Copy");
                {
                    /*
                    
                    The Copy method enables you to copy an existing file to a different directory on the file 
                    system. The following code example shows how to copy the settings.txt file from the 
                    C:\fourthCoffee\ directory to the C:\temp\ directory. 

                    */

                    string sourceSettingsPath = @"C:\fourthCoffee\settings.txt";
                    string destinationSettingsPath = @"C:\temp\settings.txt";
                    bool overwrite = true;
                    //File.Copy(sourceSettingsPath, destinationSettingsPath, overWrite);
                }

                Console.WriteLine("** Using File.Delete");
                {
                    /*
                     
                    The Delete method enables you to delete an existing file from the file system. The following 
                    code example shows how to delete the existing settings.txt file. 

                    */

                    string filePath = @"C:\fourthCoffee\settings.txt";
                    //File.Delete(filePath);
                }

                Console.WriteLine("** Using File.Exists");
                {
                    /*
                     
                    The Exists method enables you to check whether a file exists on the file system. The following 
                    code example shows how to check whether the settings.txt file exists.

                    */

                    string filePath = @"C:\fourthCoffee\settings.txt";
                    //bool persistedSettingsExist = File.Exists(filePath);
                }

                Console.WriteLine("** Using File.GetCreationTime");
                {
                    /*
                    
                    The GetCreationTime method enables you to read the date time stamp that describes when a file 
                    was created, from the metadata associated with the file. The following code example shows how 
                    you can determine when the settings.txt file was created. 

                    */

                    string filePath = @"C:\fourthCoffee\settings.txt";
                    //DateTime settingsCreatedOn = File.GetCreationTime(filePath);
                }
            }
        }

        public static void FileInformation()
        {
            Console.WriteLine("* File Information");
            {
                Console.WriteLine("** Using CopyTo");
                {
                    /*
                    
                    The CopyTo method enables you to copy an existing file to a different 
                    directory on the file system. The following code example shows how to 
                    copy the settings.txt file from the C:\fourthCoffee\ directory to the 
                    C:\temp\ directory. 
                    
                    */

                    string sourceSettingsPath = @"C:\fourthCoffee\settings.txt";
                    string destinationSettingsPath = @"C:\temp\settings.txt";
                    bool overwrite = true;
                    //FileInfo settings = new FileInfo(sourceSettingsPath);
                    //settings.CopyTo(destinationSettingsPath, overwrite);
                }

                Console.WriteLine("** Using Delete");
                {
                    /*
                    
                    The Delete method enables you to delete a file. The following code example 
                    shows how to delete the settings.txt file. 

                    */

                    string filePath = @"C:\fourthCoffee\settings.txt";
                    //FileInfo settings = new FileInfo(filePath);
                    //settings.Delete();
                }

                Console.WriteLine("** Using DirectoryName");
                {
                    /*
                     
                    The DirectoryName property enables you to get the directory path to the file. 
                    The following code example shows how to get the path to the settings.txt file. 

                    */

                    string filePath = @"C:\fourthCoffee\settings.txt";
                    //FileInfo settings = new FileInfo(filePath);
                    //string directoryPath = settings.DirectoryName; // returns C:\\fourthCoffee
                }

                Console.WriteLine("** Using Exists");
                {
                    /* 
                    
                    The Exists method enables you to determine if the file exists within the file 
                    system. The following code example shows how to check whether the settings.txt 
                    file exists. 

                    */

                    string filePath = @"C:\fourthCoffee\settings.txt";
                    //FileInfo settings = new FileInfo(filePath);
                    //bool persistedSettingsExist = settings.Exists;
                }

                Console.WriteLine("** Using Extension");
                {
                    /*
                                     
                    The Extension property enables you to get the file extension of a file. The following 
                    code example shows how to get the extension of a path returned from a method call. 

                    */

                    string filePath = @"C:\fourthCoffee\settings.txt";
                    //FileInfo settings = new FileInfo(filePath);
                    //string extension = settings.Extension;
                }

                Console.WriteLine("** Using Length");
                {
                    /*
                    
                    The Length property enables you to get the length of the file in bytes. The following 
                    code example shows how to get the length of the settings.txt file. 

                    */

                    string filePath = @"C:\fourthCoffee\settings.txt";
                    //FileInfo settings = new FileInfo(filePath);
                    //long length = settings.Length;
                }
            }
        }

        public static void DirectoryManipulation()
        {
            Console.WriteLine("* Directory Manipulation");
            {
                // TODO
            }
        }

        public static void DirectoryInformation()
        {
            Console.WriteLine("* Directory Information");
            {
                // TODO
            }
        }

        public static void FileAndDirectoryPaths()
        {
            Console.WriteLine("* File and Directory Paths");
            {
                // TODO
            }
        }

        #endregion
    }
}
