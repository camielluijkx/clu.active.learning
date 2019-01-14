using System;
using System.Collections.Generic;
using System.Linq;

namespace clu.active.learning
{
    /*
    
    Language-Integrated Query (LINQ) is the name for a set of technologies based on the integration 
    of query capabilities directly into the C# language. 
    
    */
    public static class LINQ
    {
        #region Public Methods

        public static void UsingQuerySyntax()
        {
            Console.WriteLine("* Using Query Syntax");
            {
                List<int> numbers = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                string[] vegetables = { "carrots", "cabbage", "broccoli", "beans", "barley" };

                IEnumerable<int> filteringQuery =
                    from num in numbers
                    where num < 3 || num > 7 // filter or restrict results 
                    select num;

                IEnumerable<int> orderingQuery =
                    from num in numbers
                    where num < 3 || num > 7
                    orderby num ascending // order returned results
                    select num;

                
                IEnumerable<IGrouping<char, string>> queryFoodGroups =
                    from item in vegetables
                    group item by item[0]; // group by first character
            }
        }

        public static void UsingMethodSyntax()
        {
            Console.WriteLine("* Using Method Syntax");
            {
                List<int> numbers1 = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                List<int> numbers2 = new List<int>() { 15, 14, 11, 13, 19, 18, 16, 17, 12, 10 };

                // returns single value
                double average = numbers1.Average();
                double sum = numbers1.Sum();
                double max = numbers1.Max();
                double min = numbers1.Min();

                // returns a collection
                IEnumerable<int> concatenationQuery = numbers1.Concat(numbers2);
                IEnumerable<int> largeNumbersQuery = numbers2.Where(c => c > 15);
            }
        }

        public static void UsingMixedSyntax()
        {
            Console.WriteLine("* Using Mixed Syntax");
            {
                List<int> numbers = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

                // Using a query expression with method syntax.
                int numCount1 =
                    (from num in numbers
                     where num < 3 || num > 7
                     select num).Count(); // returns single value, it is executed immediatly

                // Create a new variable to store the method call result.
                IEnumerable<int> numbersQuery =
                    from num in numbers
                    where num < 3 || num > 7
                    select num; // returns collection, needs to be materialized

                int numCount2 = numbersQuery.Count(); // result is materialized here
            }
        }

        public static void UsingLINQToXML()
        {
            Console.WriteLine("* Using LINQ to XML");
            {
                // TODO: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/linq-to-xml
            }
        }

        public static void UsingLINQToEntities()
        {
            Console.WriteLine("* Using LINQ to Entities");
            {
                // TODO: https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/linq-to-entities
            }
        }

        public static void UsingLINQToObjects()
        {
            Console.WriteLine("* Using LINQ to Objects");
            {
                // TODO: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/linq-to-objects
            }
        }

        public static void UsingQueryOperators()
        {
            Console.WriteLine("* Using Query Operators");
            {
                // TODO: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/standard-query-operators-overview
            }
        }

        public static void LazyVsEagerEvaluation()
        {
            Console.WriteLine("* Lazy vs Eager Evaluation");
            {
                // TODO: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/deferred-execution-and-lazy-evaluation-in-linq-to-xml
            }
        }

        #endregion
    }
}
