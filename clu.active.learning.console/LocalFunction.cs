using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace clu.active.learning.console
{
    /*
    
    Starting with C# 7.0, C# supports local functions. Local functions are private methods of a type that are nested in another 
    member. They can only be called from their containing member. Local functions can be declared in and called from:

        • Methods, especially iterator methods and async methods
        • Constructors
        • Property accessors
        • Event accessors
        • Anonymous methods
        • Lambda expressions
        • Finalizers
        • Other local functions
    
    However, local functions can't be declared inside an expression-bodied member.

    One of the useful features of local functions is that they can allow exceptions to surface immediately. For method iterators, 
    exceptions are surfaced only when the returned sequence is enumerated, and not when the iterator is retrieved. For async methods, 
    any exceptions thrown in an async method are observed when the returned task is awaited.

    Local functions can be used in a similar way to handle exceptions outside of the asynchronous operation. Ordinarily, exceptions 
    thrown in async method require that you examine the inner exceptions of an AggregateException. Local functions allow your code 
    to fail fast and allow your exception to be both thrown and observed synchronously.

    https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions

    */
    public class LocalFunction
    {
        private static string getText(string path, string filename)
        {
            var sr = File.OpenText(appendPathSeparator(path) + filename);
            var text = sr.ReadToEnd();
            return text;

            // Declare a local function.
            string appendPathSeparator(string filepath)
            {
                if (!filepath.EndsWith(@"\"))
                    filepath += @"\";

                return filepath;
            }
        }

        public static IEnumerable<int> OddSequence1(int start, int end)
        {
            Console.WriteLine("Executing OddSequence1...");

            if (start < 0 || start > 99)
                throw new ArgumentOutOfRangeException("start must be between 0 and 99.");
            if (end > 100)
                throw new ArgumentOutOfRangeException("end must be less than or equal to 100.");
            if (start >= end)
                throw new ArgumentException("start must be less than end.");

            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 1)
                    yield return i;
            }
        }

        public static IEnumerable<int> OddSequence2(int start, int end)
        {
            Console.WriteLine("Executing OddSequence2...");

            if (start < 0 || start > 99)
                throw new ArgumentOutOfRangeException("start must be between 0 and 99.");
            if (end > 100)
                throw new ArgumentOutOfRangeException("end must be less than or equal to 100.");
            if (start >= end)
                throw new ArgumentException("start must be less than end.");

            return getOddSequenceEnumerator();

            IEnumerable<int> getOddSequenceEnumerator()
            {
                for (int i = start; i <= end; i++)
                {
                    if (i % 2 == 1)
                        yield return i;
                }
            }
        }

        static async Task<int> getMultipleAsync1(int secondsDelay)
        {
            Console.WriteLine("Executing getMultipleAsync1...");

            if (secondsDelay < 0 || secondsDelay > 5)
                throw new ArgumentOutOfRangeException("secondsDelay cannot exceed 5.");

            await Task.Delay(secondsDelay * 1000);
            return secondsDelay * new Random().Next(2, 10);
        }

        static Task<int> getMultiple2(int secondsDelay)
        {
            Console.WriteLine("Executing getMultiple2...");

            if (secondsDelay < 0 || secondsDelay > 5)
                throw new ArgumentOutOfRangeException("secondsDelay cannot exceed 5.");

            return getValueAsync();

            async Task<int> getValueAsync()
            {
                Console.WriteLine("Executing getValueAsync...");
                await Task.Delay(secondsDelay * 1000);
                return secondsDelay * new Random().Next(2, 10);
            }
        }

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

        public static void Test()
        {
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
                // using method invoking a local function
                string contents = getText(@"D:\TODO", "example.txt");
                Console.WriteLine("Contents of the file:\n" + contents);
            }

            {
                /*
            
                The following example defines an OddSequence method that enumerates odd numbers between a specified range. Because 
                it passes a number greater than 100 to the OddSequence enumerator method, the method throws an 
                ArgumentOutOfRangeException. As the output from the example shows, the exception surfaces only when you iterate the 
                numbers, and not when you retrieve the enumerator.

                */
                try
                {
                    Console.WriteLine("OddSequence without local function");

                    IEnumerable<int> ienum = OddSequence1(50, 110);
                    Console.WriteLine("Retrieved enumerator..."); // enumerator is retrieved before exception

                    foreach (var i in ienum)
                    {
                        Console.Write($"{i} ");
                    }
                }
                catch (Exception ex)
                {
                    // Specified argument was out of the range of valid values. 
                    // Parameter name: end must be less than or equal to 100.
                    Console.WriteLine(ex.Message);
                }
            }

            {
                /*
            
                Instead, you can throw an exception when performing validation and before retrieving the iterator by returning the 
                iterator from a local function, as the following example shows.

                */
                try
                {
                    Console.WriteLine("OddSequence with local function");

                    IEnumerable<int> ienum = OddSequence2(50, 110);
                    Console.WriteLine("Retrieved enumerator..."); // enumerator is not retrieved before exception

                    foreach (var i in ienum)
                    {
                        Console.Write($"{i} ");
                    }
                }
                catch (Exception ex)
                {
                    // Specified argument was out of the range of valid values.
                    // Parameter name: end must be less than or equal to 100.
                    Console.WriteLine(ex.Message);
                }
            }

            {
                /*
                
                The following example uses an asynchronous method named getMultipleAsync1 to pause for a specified number of 
                seconds and return a value that is a random multiple of that number of seconds. The maximum delay is 5 seconds; 
                an ArgumentOutOfRangeException results if the value is greater than 5. As the following example shows, the 
                exception that is thrown when a value of 6 is passed to the getMultipleAsync1 method is wrapped in an 
                AggregateException after the getMultipleAsync1 method begins execution.

                */
                try
                {
                    int result = getMultipleAsync1(6).Result;
                    Console.WriteLine($"The returned value is {result:N0}");
                }
                catch (AggregateException ex)
                {
                    // One or more errors occurred.             
                    Console.WriteLine(ex.Message);
                }
            }

            {
                /*
                
                As we did with the method iterator, we can refactor the code from this example to perform the validation before 
                calling the asynchronous method. As the output from the following example shows, the ArgumentOutOfRangeException 
                is not wrapped in an AggregateException.

                */
                try
                {
                    int result = getMultiple2(6).Result;
                    Console.WriteLine($"The returned value is {result:N0}");
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    // Specified argument was out of the range of valid values.
                    // Parameter name: secondsDelay cannot exceed 5.
                    Console.WriteLine(ex.Message);
                }
            }

            Console.ReadLine();
        }
    }
}