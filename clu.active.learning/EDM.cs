

using System;
using System.Collections.Generic;
using System.Linq;

namespace clu.active.learning
{
    /*
    
    https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ef/index

    Entity Data Model (EDM)

    Data access applications have traditionally been tedious to develop. They often contain queries that are 
    written as text strings that cannot be type-checked or syntax-checked at compile time, and results are 
    returned as untyped data records. The ADO.NET Entity Framework solves these problems and simplifies the 
    process of developing data access applications by using EDMs. 

    Historically when you write code to access data that is stored in a database, you have to understand the 
    structure of the data in the database and how it all interrelates. Often it is stored in a normalized 
    fashion, where tables do not logically map to the real-life objects that they represent. The ADO.NET 
    Entity Framework enables you to develop applications that target a conceptual model instead of the 
    normalized database structure in the storage layer. 

    The ADO.NET Entity Framework provides the following:

        • EDMs. These are models that you can use to map database tables and queries to .NET Framework 
          objects. 
        • Entity Structured Query Language (SQL). This is a storage independent query language that enables 
          you to query and manipulate EDM constructs. 
        • Object Services. These are services that enable you to work with the Common Language Runtime (CLR) 
          objects in a conceptual model. 

    These components enable you to:

        • Write code against a conceptual model that includes types that support inheritance and 
          relationships. 
        • Update applications to target a different storage model without rewriting or redistributing all of 
          your data access code. 
        • Write standard code that is not dependent on the data storage system.
        • Write data access code that supports compile-time type-checking and syntax-checking.

    The conceptual model that you work with in the Entity Framework describes the semantics of the business 
    view of the data. It defines entities and relationships in a business sense and is mapped to the logical 
    model of the underlying data in the data source.

    Visual Studio provides the Entity Data Model Tools that you can use to create and update EDMs in your 
    applications. It supports both database-first design and code-first design: 

        • Database-first design. In database-first design, you design and create your database before you 
          generate your model. This is commonly used when you are developing applications against an existing 
          data source; however, this can limit the flexibility of the application in the long term. 
        • Code-first design. In code-first design, you design the entities for your application and then 
          create the database structure around these entities. Developers prefer this method because it 
          enables you to design your application around the business functionality that you require. However, 
          in reality, you often have to work with an existing data source.
          
    Visual Studio provides the ADO.NET Entity Data Model Tools, which include the Entity Data Model Designer 
    for graphically creating and relating entities in a model and three wizards for working with models and 
    data sources. The following table describes the wizards. 

    Wizard                      Description
    Entity Data Model Wizard    Enables you to generate a new conceptual model from an existing data source 
                                by using the database-first design method. 
    Update Model Wizard         Enables you to update an existing conceptual model with changes that are made 
                                to the data source on which it is based. 
    Generate Database Wizard    Enables you to generate a database from a conceptual model that you have 
                                designed in the Entity Data Model Designer by using the code-first design 
                                method.
    */
    public static class EDM
    {
        static FourthCoffeeEntities dbContext = new FourthCoffeeEntities();

        private class FullName
        {
            public string Forename { get; set; }
            public string Surname { get; set; }
        }

        #region Implementation

        // Nested types can be partial.
        partial class NestedClass
        {

        }
        partial class NestedClass
        {

        }
        partial class ClassWithNestedClass
        {
            partial class NestedClass
            {

            }
        }
        partial class ClassWithNestedClass
        {
            partial class NestedClass
            {

            }
        }
        //class ClassWithNestedClass
        //{
        //    partial class NestedClass
        //    {

        //    }
        //}

        partial interface ITest
        {
            void Interface_Test();
        }

        partial interface ITest
        {
            void Interface_Test2();
        }

        partial struct S1
        {
            void Struct_Test() { }
        }

        partial struct S1
        {
            void Struct_Test2() { }
        }

        public partial class Coords
        {
            private int x;
            private int y;

            public Coords(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            //partial bool DeleteCoords(); //CS0766: Partial methods must have a void return type
            partial void UpdateCoords(); // definition
        }

        public partial class Coords
        {
            public void PrintCoords()
            {
                Console.WriteLine("Coords: {0},{1}", x, y);
            }

            partial void UpdateCoords() // implementation
            {

            }
        }

        #endregion

        #region Public Methods

        public static void UsingPartialClasses()
        {
            /*
            
            https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods

            There are several situations when splitting a class definition is desirable:

                • When working on large projects, spreading a class over separate files enables multiple 
                  programmers to work on it at the same time.
                • When working with automatically generated source, code can be added to the class 
                  without having to recreate the source file. Visual Studio uses this approach when it 
                  creates Windows Forms, Web service wrapper code, and so on. You can create code that 
                  uses these classes without having to modify the file created by Visual Studio.

            The partial keyword indicates that other parts of the class, struct, or interface can be 
            defined in the namespace. All the parts must use the partial keyword. All the parts must be 
            available at compile time to form the final type. All the parts must have the same 
            accessibility, such as public, private, and so on.

            If any part is declared abstract, then the whole type is considered abstract. If any part 
            is declared sealed, then the whole type is considered sealed. If any part declares a base 
            type, then the whole type inherits that class.

            All the parts that specify a base class must agree, but parts that omit a base class still 
            inherit the base type. Parts can specify different base interfaces, and the final type 
            implements all the interfaces listed by all the partial declarations. Any class, struct, or 
            interface members declared in a partial definition are available to all the other parts. The 
            final type is the combination of all the parts at compile time.

            The following are merged from all the partial-type definitions:

                • XML comments
                • interfaces
                • generic-type parameter attributes
                • class attributes
                • members

            Restrictions

            There are several rules to follow when you are working with partial class definitions:
            
                • All partial-type definitions meant to be parts of the same type must be modified with 
                  partial
                • The partial modifier can only appear immediately before the keywords class, struct, or 
                  interface.
                • Nested partial types are allowed in partial-type definitions as long as parent class 
                  follows same rules.
                • All partial-type definitions meant to be parts of the same type must be defined in the 
                  same assembly and the same module (.exe or .dll file). Partial definitions cannot span 
                  multiple modules. 
                • The class name and generic-type parameters must match on all partial-type definitions. 
                  Generic types can be partial. Each partial declaration must use the same parameter names 
                  in the same order.
                • The following keywords on a partial-type definition are optional, but if present on one 
                  partial-type definition, cannot conflict with the keywords specified on another partial 
                  definition for the same type:
                      • public
                      • private
                      • protected
                      • internal
                      • abstract
                      • sealed
                      • base class
                      • new modifier (nested parts)
                      • generic constraints


            */
            Console.WriteLine("* Using Partial Classes");
            {

            }
        }

        public static void UsingPartialMethods()
        {
            /*
            
            Partial Methods

            A partial class or struct may contain a partial method. One part of the class contains the 
            signature of the method. An optional implementation may be defined in the same part or 
            another part. If the implementation is not supplied, then the method and all calls to the 
            method are removed at compile time.

            Partial methods enable the implementer of one part of a class to define a method, similar 
            to an event. The implementer of the other part of the class can decide whether to implement 
            the method or not. If the method is not implemented, then the compiler removes the method 
            signature and all calls to the method. The calls to the method, including any results that 
            would occur from evaluation of arguments in the calls, have no effect at run time. Therefore, 
            any code in the partial class can freely use a partial method, even if the implementation is 
            not supplied. No compile-time or run-time errors will result if the method is called but not 
            implemented.

            Partial methods are especially useful as a way to customize generated code. They allow for a 
            method name and signature to be reserved, so that generated code can call the method but the 
            developer can decide whether to implement the method. Much like partial classes, partial 
            methods enable code created by a code generator and code created by a human developer to work 
            together without run-time costs.

            A partial method declaration consists of two parts: the definition, and the implementation. 
            These may be in separate parts of a partial class, or in the same part. If there is no 
            implementation declaration, then the compiler optimizes away both the defining declaration and 
            all calls to the method.

                • Partial method declarations must begin with the contextual keyword partial and the method 
                  must return void.
                • Partial methods can have in or ref but not out parameters.
                • Partial methods are implicitly private, and therefore they cannot be virtual.
                • Partial methods cannot be extern, because the presence of the body determines whether they 
                  are defining or implementing.
                • Partial methods can have static and unsafe modifiers.
                • Partial methods can be generic. Constraints are put on the defining partial method 
                  declaration, and may optionally be repeated on the implementing one. Parameter and type 
                  parameter names do not have to be the same in the implementing declaration as in the 
                  defining one.
                • You can make a delegate to a partial method that has been defined and implemented, but not 
                  to a partial method that has only been defined.

            */
            Console.WriteLine("* Using Partial Methods");
            {

            }
        }

        public static void UsingEntityFramework()
        {
            /*
            
            https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.dbset?view=entity-framework-6.2.0

            The automatically generated code files for a model also contains a partial class that inherits 
            from the System.Data.Entity.DbContext class. The DbContext class provides facilities for 
            querying and working with entity data as objects. It contains a default constructor which 
            initializes the class by using the connection string that the wizard generates in the 
            application configuration file. This defines the data connection and model definition to use. 
            The DbContext class also contains a DbSet property that exposes a DbSet(TEntity) class for each 
            entity in your model. The DbSet(TEntity) class represents a typed entity set that you can use to 
            read, create, update, and delete data. 

            The DbSet(TEntity) class implements the IEnumerable interface which provides a number of extension 
            methods that enable you to easily locate specific data in the source.

            */
            Console.WriteLine("* Using EntityFramework");
            {
                Console.WriteLine("** Reading Data");
                {
                    // Print a list of employees.
                    foreach (Employee employee in dbContext.Employees)
                    {
                        Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
                    }
                }

                Console.WriteLine("** Locating and Modifying Data");
                {
                    // Update the employee with a surname of "Prescott."
                    var employee = dbContext.Employees.FirstOrDefault(e => e.LastName == "Prescott");
                    if (employee != null)
                    {
                        employee.LastName = "Forsyth";
                    }
                }

                Console.WriteLine("** Persisting Changes");
                {
                    // Update the employee with a surname of "Prescott."
                    var employee = dbContext.Employees.FirstOrDefault(e => e.LastName == "Prescott");
                    if (employee != null)
                    {
                        employee.LastName = "Forsyth";
                    }
                    // Save changes.
                    dbContext.SaveChanges();
                }

                Console.WriteLine("** Querying Data");
                {
                    IQueryable<Employee> employees = from employee in dbContext.Employees
                                                     orderby employee.LastName
                                                     select employee;

                    Console.WriteLine("Basic LINQ Query to select all employees");
                    Console.WriteLine("========================================");
                    foreach (var employee in employees)
                    {
                        Console.WriteLine("{0} {1} {2}", employee.FirstName, employee.LastName, 
                            DateTime.Parse(employee.DateOfBirth.ToString()).ToShortDateString());
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("** Filtering Data by Row");
                {
                    string lastName = "Prescott";
                    IQueryable<Employee> employees = (from employee in dbContext.Employees
                                                      where employee.LastName == lastName
                                                      select employee);

                    Console.WriteLine("LINQ Query to select all employees with a last name of Prescott");
                    Console.WriteLine("===============================================================");
                    foreach (var employee in employees)
                    {
                        Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("** Filtering Data by Column");
                {
                    IQueryable<FullName> fullNames = from employee in dbContext.Employees
                                                     select new FullName
                                                     {
                                                         Forename = employee.FirstName,
                                                         Surname = employee.LastName
                                                     };

                    Console.WriteLine("LINQ Query to select only the first name and last name of all employees");
                    Console.WriteLine("=======================================================================");

                    foreach (var fullName in fullNames)
                    {
                        Console.WriteLine("{0} {1}", fullName.Forename, fullName.Surname);
                    }
                    Console.WriteLine();
                }
            }
        }

        public static void UsingAnonymousTypes()
        {
            /*
            
            In the examples in the previous topic and demonstration, the return data was always stored in 
            a strongly typed IQueryable<Type> variable; however, in the filtering by column scenario, it 
            is necessary to define the type containing a subset of columns before defining the query. 
            Although this is a perfectly valid way of working, it can become tedious to explicitly define 
            multiple classes. 
        
            You can use anonymous types to store the returned data by declaring the return type as an 
            implicitly typed local variable, a var, and by using the new keyword in the select clause to 
            create the instance of the type. 

            */
            Console.WriteLine("* Using Anonymous Types");
            {
                Console.WriteLine("** Filtering Data by Column");
                {
                    var employees = from employee in dbContext.Employees
                                    select new { employee.FirstName, employee.LastName };

                    Console.WriteLine("LINQ Query to filter data by column by using anonymous types");
                    Console.WriteLine("============================================================");

                    foreach (var employee in employees)
                    {
                        Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("** Grouping Data");
                {
                    var employeeGroups = from employee in dbContext.Employees
                                         group employee by employee.JobTitle into employeesGroup
                                         select new
                                         {
                                             JobTitleId = employeesGroup.Key,
                                             Employees = employeesGroup
                                         };

                    Console.WriteLine("LINQ Query to select all employees and group them by their job title id");
                    Console.WriteLine("=======================================================================");

                    foreach (var employeeGroup in employeeGroups)
                    {
                        Console.WriteLine(employeeGroup.JobTitleId);
                        foreach (var employee in employeeGroup.Employees)
                        {
                            Console.WriteLine("    {0} {1}", employee.FirstName, employee.LastName);
                        }
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("** Aggregating Data");
                {
                    var employeeGroups = from employee in dbContext.Employees
                                         group employee by employee.JobTitle into employeesGroup
                                         select new
                                         {
                                             JobTitleId = employeesGroup.Key,
                                             TotalEmployees = employeesGroup.Count()
                                         };

                    Console.WriteLine("LINQ Query to select all employees, group them by their job title id, and provide total per job title id");
                    Console.WriteLine("========================================================================================================");

                    foreach (var employeeGroup in employeeGroups)
                    {
                        Console.WriteLine("Job Title Id: {0}, Total Employees: {1}",
                            employeeGroup.JobTitleId, employeeGroup.TotalEmployees);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("** Navigating Data");
                {
                    var employees = from employee in dbContext.Employees
                                    select new
                                    {
                                        FirstName = employee.FirstName,
                                        LastName = employee.LastName,
                                        Job = employee.JobTitle1.Job // navigation
                                    };

                    Console.WriteLine("LINQ Query to select all employees and their job titles");
                    Console.WriteLine("=======================================================");
                    foreach (var employee in employees)
                    {
                        Console.WriteLine("{0} {1}, {2}", employee.FirstName, employee.LastName, employee.Job);
                    }
                    Console.WriteLine();
                }
            }
        }

        public static void UsingQueryExecution()
        {
            /*
            
            By default, when you define a LINQ query that returns a sequence of values, it is not run 
            until you actually try to use some of the returned data. This feature is known as deferred 
            query execution and ensures that you can create a query to retrieve data in a multiple-user 
            scenario and know that whenever it is executed you will receive the latest information.

            Conversely, when you define a LINQ query that returns a singleton value, for example, an 
            Average, Count, or Max function, the query is run immediately. This is known as immediate 
            query execution and is necessary in the singleton result scenario because the query must 
            produce a sequence to calculate the singleton result.
            
            You can override the default deferred query execution behavior for queries that do not 
            produce a singleton result by calling one of the following methods on the query: 

                • ToArray 
                • ToDictionary 
                • ToList 

            */
            Console.WriteLine("* Using Query Execution");
            {
                Console.WriteLine("** Using Deferred Query Execution");
                {
                    IQueryable<Employee> employees = from employee in dbContext.Employees
                                                     select employee;
                    foreach (var employee in employees)
                    {
                        Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
                    }
                }

                Console.WriteLine("** Forcing Query Execution");
                {
                    IList<Employee> employees = (from employee in dbContext.Employees
                                                 select employee).ToList();
                    foreach (var employee in employees)
                    {
                        Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
                    }
                }
            }
        }

        #endregion
    }

    // Extend classes generated by Entity Data Model Wizard.
    public partial class Employee
    {
        public int GetAge()
        {
            DateTime dateOfBirth = (DateTime)DateOfBirth;
            TimeSpan difference = DateTime.Now.Subtract(dateOfBirth);
            int ageInYears = (int)(difference.Days / 365.25);
            return ageInYears;
        }
    }
}
