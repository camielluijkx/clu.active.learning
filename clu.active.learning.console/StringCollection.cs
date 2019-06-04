using System;
using System.Collections.Generic;
using System.Linq;

namespace clu.active.learning.console
{
    /*
    
    https://docs.microsoft.com/en-us/dotnet/api/system.collections.specialized.stringcollection?view=netframework-4.8

    */
    public class StringCollection
    {
        public static void Test()
        {
            string[] numbers = { "one", "two", "three" };

            System.Collections.Specialized.StringCollection stringsCollection = new System.Collections.Specialized.StringCollection();
            stringsCollection.AddRange(numbers);
            stringsCollection.Add("four");
            stringsCollection.Remove("one");
            foreach (string s in stringsCollection)
            {
                Console.WriteLine(s);
            }
            bool collectionContains = stringsCollection.Contains("two");

            List<string> stringsList = new List<string>();
            stringsList.AddRange(numbers);
            stringsList.Add("four");
            stringsList.Remove("one");
            foreach (string s in stringsList)
            {
                Console.WriteLine(s);
            }
            bool listContains = stringsList.Contains("two");

            stringsList = stringsCollection.Cast<String>().ToList();

            Console.ReadLine();
        }
    }
}