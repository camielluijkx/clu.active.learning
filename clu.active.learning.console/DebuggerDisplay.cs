using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace clu.active.learning.console
{
    /*
    
    https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.debuggerdisplayattribute?view=netframework-4.8

    */
    public class DebuggerDisplay
    {
        [DebuggerDisplay("Name = {Name}, Age = {Age}")]
        public class Student
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }

        //[DebuggerDisplay("Number = {Number}")]
        public class Card
        {
            public string Number { get; set; }

            public override string ToString()
            {
                return $"Number: {Number}";
            }
        }

        [DebuggerDisplay("{DebuggerDisplay,nq}")] // nq = no quotes
        public sealed class MyClass
        {
            public int Count { get; set; }

            public bool Flag { get; set; }

            private string DebuggerDisplay
            {
                get
                {
                    return string.Format("Object {0}", Count - 2);
                }
            }
        }

        [DebuggerDisplay("{value}", Name = "{key}", Type = "non existing")]
        internal class KeyValuePairs
        {
            private IDictionary dictionary;
            private object key;
            private object value;

            public KeyValuePairs(IDictionary dictionary, object key, object value)
            {
                this.value = value;
                this.key = key;
                this.dictionary = dictionary;
            }
        }

        public static void Test()
        {
            Student student = new Student(); // Name = null, Age = 0
            student.Name = "Joe"; // Name = "Joe", Age = 0
            student.Age = 21; // Name = "Joe", Age = 21

            Card card = new Card();
            card.Number = "777"; // {Number: 777}

            MyClass myClass = new MyClass(); // Object -2
            myClass.Count = 4; // Object 2
            myClass.Flag = true; // Object 2 

            IDictionary dictionary = new Dictionary<string, string>();
            KeyValuePairs pairs = new KeyValuePairs(dictionary, "some unique key", "value for unique key"); // "value for unique key"
            Console.ReadLine();
        }
    }
}