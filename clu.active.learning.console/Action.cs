using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace clu.active.learning.console
{
    /*
    
    Action

    Encapsulates a method that has no parameters and does not return a value.

    https://docs.microsoft.com/en-us/dotnet/api/system.action?view=netframework-4.8

    Action<T>

    Encapsulates a method that has a single parameter and does not return a value.

    https://docs.microsoft.com/en-us/dotnet/api/system.action-1?view=netframework-4.8

    Action<T1, T2>

    Encapsulates a method that has two parameters and does not return a value.

    https://docs.microsoft.com/en-us/dotnet/api/system.action-2?view=netframework-4.8

    etc.
    
    */
    public class Action
    {
        public delegate void ShowValue();

        private delegate void concatStrings(string string1, string string2);

        public class Name
        {
            private string instanceName;

            public Name(string name)
            {
                this.instanceName = name;
            }

            public void DisplayToConsole()
            {
                Console.WriteLine(this.instanceName);
            }

            public void DisplayToWindow()
            {
                MessageBox.Show(this.instanceName);
            }
        }

        private static void print(string s)
        {
            Console.WriteLine(s);
        }

        private static void writeToConsole(string string1, string string2)
        {
            Console.WriteLine("{0}\n{1}", string1, string2);
        }

        private static void writeToFile(string string1, string string2)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(Environment.GetCommandLineArgs()[1], false);
                writer.WriteLine("{0}\n{1}", string1, string2);
            }
            catch
            {
                Console.WriteLine("File write operation failed...");
            }
            finally
            {
                if (writer != null) writer.Close();
            }
        }

        public static void Test()
        {
            {
                // using delegate
                Name testName = new Name("John Doe");
                ShowValue showMethod = testName.DisplayToConsole;
                showMethod();
            }

            {
                // using action instead of delegate
                Name testName = new Name("John Doe");
                System.Action showMethod = testName.DisplayToConsole;
                showMethod();
            }

            {
                // using action and anonymous method
                Name testName = new Name("John Doe");
                System.Action showMethod = delegate() { testName.DisplayToConsole(); };
                showMethod();
            }

            {
                // using action and lambda expression
                Name testName = new Name("John Doe");
                System.Action showMethod = () => testName.DisplayToConsole();
                showMethod();
            }

            {
                // using local function instead
                Name testName = new Name("John Doe");
                void showMethod() => testName.DisplayToConsole();
                showMethod();
            }

            {
                // using action with single parameter
                List<string> names = new List<string>
                {
                    "Bruce",
                    "Alfred",
                    "Tim",
                    "Richard"
                };

                // Display the contents of the list using the Print method.
                names.ForEach(print);

                // The following demonstrates the anonymous method feature of C# to display the contents of the list to the console.
                names.ForEach(delegate(string name)
                {
                    Console.WriteLine(name);
                });
            }

            {
                // using delegate with two parameters
                string message1 = "The first line of a message.";
                string message2 = "The second line of a message.";
                concatStrings concat;

                if (Environment.GetCommandLineArgs().Length > 1)
                    concat = writeToFile;
                else
                    concat = writeToConsole;

                concat(message1, message2);
            }

            {
                // using action with two parameters
                string message1 = "The first line of a message.";
                string message2 = "The second line of a message.";
                System.Action<string, string> concat;

                if (Environment.GetCommandLineArgs().Length > 1)
                    concat = writeToFile;
                else
                    concat = writeToConsole;

                concat(message1, message2);
            }

            // etc.

            Console.ReadLine();
        }
    }
}