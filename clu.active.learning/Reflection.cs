using System;
using System.IO;
using System.Reflection;

namespace clu.active.learning
{
    /*
    
    Reflection is a powerful feature that enables you to inspect and perform dynamic manipulation of assemblies, types, and type members at run time.

    Reflection is used throughout the Microsoft® .NET Framework. Reflection is used by some of the classes that the base class library provides and 
    some of the utilities that ship with Microsoft Visual Studio®. For example, the serialization classes in the System.Runtime.Serialization namespace 
    uses reflection to determine which type members should be serialized when serializing types. 

    Reflection Usage Scenarios 

    The following table describes some of the possible uses for reflection in your applications.

    Use                                                     Scenario
    Examining metadata and dependencies of an assembly.     You might choose to do this if you are consuming an unknown assembly in your application 
                                                            and you want to determine whether your application satisfies the unknown assembly’s 
                                                            dependencies. 
    Finding members in a type that have been decorated      You might choose to do this if you are implementing a generic storage repository, which 
    with a particular attribute.                            will inspect each type and determine which members it needs to persist. 
    Determining whether a type implements a specific        You might choose to do this if you are creating a pluggable application that enables you to 
    interface.                                              include new assemblies at run time, but you only want your application to load types that 
                                                            implement a specific interface. 
    Defining and executing a method at run time.            You might choose to do this if you are implementing a virtualized platform that can read 
                                                            types and methods that are implemented in a language such as JavaScript, and then creating 
                                                            managed implementations that you can execute in your .NET Framework application. 

    Executing code by using reflection is much slower than executing static Microsoft Visual C#® code, so you should only use reflection to create and 
    execute code when you really have to and not just because reflection makes it possible. 

    https://docs.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/reflection

    The .NET Framework provides the System.Reflection namespace, which contains classes that enable you to take advantage of reflection in your 
    applications. The following list describes some of these classes: 

        • Assembly. This class enables you to load and inspect the metadata and types in a physical assembly. 
        • TypeInfo. This class enables you to inspect the characteristics of a type. 
        • ParameterInfo. This class enables you to inspect the characteristics of any parameters that a member accepts. 
        • ConstructorInfo. This class enables you to inspect the constructor of the type. 
        • FieldInfo. This class enables you to inspect the characteristics of fields that are defined within a type. 
        • MemberInfo. This class enables you to inspect members that a type exposes. 
        • PropertyInfo. This class enables you to inspect the characteristics of properties that are defined within a type. 
        • MethodInfo. This class enables you to inspect the characteristics of the methods that are defined within a type. 

    The System namespace includes the Type class, which also exposes a selection of members that you will find useful when you use reflection. For 
    example, the GetFields instance method enables you to get a list of FieldInfo objects, representing the fields that are defined within a type. 
    
    https://docs.microsoft.com/en-us/dotnet/api/system.type?view=netframework-4.7.2

    */
    public static class Reflection
    {
        #region Public Methods

        public static void LoadingAnAssembly()
        {
            /*
            
            The System.Reflection namespace provides the Assembly class, which enables you to encapsulate an assembly in your code so that you can 
            inspect any metadata that is associated with that assembly. 
            
            The Assembly class provides a number of static and instance members that you can use to load and examine the contents of assemblies. 
            There are two ways that you can load an assembly into your application by using reflection: 

                • Reflection-only context, in which you can view the metadata that is associated with the assembly and not execute code. 
                • Execution context, in which you can execute the loaded assembly.

            Loading an assembly in reflection-only context can improve performance; however, if you do try to execute it, the Common Language Runtime 
            (CLR) will throw an InvalidOperationException exception. 

            */
            Console.WriteLine("* Loading an Assembly");
            {
                /*
                
                This method enables you to load an assembly in execution context by using an absolute file path to the assembly.

                */
                Console.WriteLine("** Using LoadFrom");
                {
                    var assemblyPath = "C:\\FourthCoffee\\Libs\\FourthCoffee.Service.ExceptionHandling.dll";
                    var assembly = Assembly.LoadFrom(assemblyPath);
                }

                /*
                
                This method enables you to load an assembly in reflection-only context from a binary large object (BLOB) that represents the assembly.

                */
                Console.WriteLine("** Using ReflectionOnlyLoad");
                {
                    var assemblyPath = "C:\\FourthCoffee\\Libs\\FourthCoffee.Service.ExceptionHandling.dll";
                    var rawBytes = File.ReadAllBytes(assemblyPath);
                    var assembly = Assembly.ReflectionOnlyLoad(rawBytes);
                }

                /*
                
                This method enables you to load an assembly in reflection-only context by using an absolute file path to the assembly.

                */
                Console.WriteLine("** Using ReflectionOnlyLoadFrom");
                {
                    var assemblyPath = "C:\\FourthCoffee\\Libs\\FourthCoffee.Service.ExceptionHandling.dll";
                    var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);
                }
            }
        }

        public static void UsingAssemblyClass()
        {
            /*
            
            After you have loaded an assembly and have created an instance of the Assembly class, you can use any of the instance members to examine 
            the contents of the assembly. The following list describes some of the instance members that the Assembly class provides:

                • FullName. This property enables you to get the full name of the assembly, which includes the assembly version and public key token. 
                • GetReferencedAssemblies. This method enables you to get a list of all of the names of any assemblies that the loaded assembly 
                  references. 
                • GlobalAssemblyCache. This property enables you to determine whether the assembly was loaded from the GAC. 
                • Location. This property enables you to get the absolute path to the assembly. 
                • ReflectionOnly. This property enables you to determine whether the assembly was loaded in a reflection-only context or in an execution 
                  context. If you load an assembly in reflection-only context, you can only examine the code. 
                • GetType. This method enables you to get an instance of the Type class that encapsulates a specific type in an assembly, based on the 
                  name of the type. 
                • GetTypes. This method enables you to get all of the types in an assembly in an array of type Type. 

            https://docs.microsoft.com/en-us/dotnet/api/system.reflection.assembly?view=netframework-4.7.2

            */
            Console.WriteLine("* Using Assembly Class");
            {
                /*
                
                Reflection enables you to examine the definition of any type in an assembly. Depending on whether you are looking for a type with a 
                specific name or you want to iterate through each type in the assembly in sequence, you can use the GetType and GetTypes methods that 
                the Assembly class provides.

                If you use the GetType method and specify a name of a type that does not exist in the assembly, the GetType method returns null. 

                */
                Console.WriteLine("** Load a Type by Using the GetType Method");
                {
                    var assemblyPath = "C:\\FourthCoffee\\Libs\\FourthCoffee.Service.ExceptionHandling.dll";
                    var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);

                    var type = assembly.GetType("FourthCoffee.Service.ExceptionHandling.HandleError");
                }

                /*
               
                The GetTypes method returns an array of Type objects. 

                After you have created an instance of the Type class, you can then use any of its members to inspect the type’s definition. 

                */
                Console.WriteLine("** Iterate All Types in an Assembly by Using the GetTypes Method");
                {
                    var assemblyPath = "C:\\FourthCoffee\\Libs\\FourthCoffee.Service.ExceptionHandling.dll";
                    var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);

                    foreach (var type in assembly.GetTypes())
                    {
                        // Code to process each type.
                        var typeName = type.FullName;
                    }
                }

                /*
                
                This method enables you to get all of the constructors that exist in a type. The GetConstructors method returns an array that 
                contains ConstructorInfo objects. 

                */
                Console.WriteLine("** Using type.GetConstructors");
                {
                    var assemblyPath = "C:\\FourthCoffee\\Libs\\FourthCoffee.Service.ExceptionHandling.dll";
                    var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);

                    foreach (var type in assembly.GetTypes())
                    {
                        var constructors = type.GetConstructors();
                        foreach (var constructor in constructors)
                        {
                            var parameters = constructor.GetParameters();
                        }
                    }
                }

                /*
                 
                This method enables you to get all of the fields that exist in the current type. The GetFields method returns an array that 
                contains FieldInfo objects.
                
                */
                Console.WriteLine("** Using type.GetFields");
                {
                    var assemblyPath = "C:\\FourthCoffee\\Libs\\FourthCoffee.Service.ExceptionHandling.dll";
                    var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);

                    foreach (var type in assembly.GetTypes())
                    {
                        var fields = type.GetFields();
                        foreach (var field in fields)
                        {
                            var isStatic = field.IsStatic;
                        }
                    }
                }

                /*
                 
                This method enables you to get all of the properties that exist in the current type. The GetProperties method returns an array 
                that contains PropertyInfo objects. 
                
                */
                Console.WriteLine("** Using type.GetProperties");
                {
                    var assemblyPath = "C:\\FourthCoffee\\Libs\\FourthCoffee.Service.ExceptionHandling.dll";
                    var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);

                    foreach (var type in assembly.GetTypes())
                    {
                        var properties = type.GetProperties();
                        foreach (var property in properties)
                        {
                            var propertyName = property.Name;
                        }
                    }
                }

                /*
                
                This method enables you to get all of the methods that exist in the current type. The GetMethods method returns an array that 
                contains MethodInfo objects.

                */
                Console.WriteLine("** Using type.GetMethods");
                {
                    var assemblyPath = "C:\\FourthCoffee\\Libs\\FourthCoffee.Service.ExceptionHandling.dll";
                    var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);

                    foreach (var type in assembly.GetTypes())
                    {
                        var methods = type.GetMethods();
                        foreach (var method in methods)
                        {
                            var methodName = method.Name;
                        }
                    }
                }

                /*
                
                This method enables you to get any members that exist in the current type, including properties and methods. The GetMembers method 
                returns an array that contains MemberInfo objects. 

                You can use these members to get a collection of xxxxInfo objects that represents the different members that a type exposes. If you 
                loaded the type in execution context, you can then use the xxxxInfo objects to execute each member. 

                */
                Console.WriteLine("** Using type.GetMembers");
                {
                    var assemblyPath = "C:\\FourthCoffee\\Libs\\FourthCoffee.Service.ExceptionHandling.dll";
                    var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);

                    foreach (var type in assembly.GetTypes())
                    {
                        var members = type.GetMembers();
                        foreach (var member in members)
                        {
                            if (member.MemberType == MemberTypes.Method)
                            {
                                // Process the method.
                            }
                            if (member.MemberType == MemberTypes.Property)
                            {
                                // Process the property.
                            }
                        }
                    }
                }

            }
        }

        public static void InvokingMembers()
        {
            /*
            
            The reflection application programming interface (API) in the .NET Framework enables you to invoke objects and use the functionality that 
            they encapsulate. Invoking an object by using reflection follows the same pattern that you use to invoke an object in Visual C#, which 
            typically involves the following steps: 

                1. Create an instance of the type.
                2. Invoke methods on the instance.
                3. Get or set property values on the instance.

            */
            Console.WriteLine("* Invoking Members by Using Reflection");
            {
                /*
                
                When you invoke static members by using reflection, there is no need to explicitly create an instance of the type. 

                To create an instance of a type by using reflection, you need to get a reference to a constructor that the type exposes and then use 
                the Invoke method. To instantiate a type by using the ConstructorInfo class, perform the following steps: 

                    1. Create an instance of the ConstructorInfo class that represents the constructor you will use to initialize an instance of the 
                       type.                  
                    2. Call the Invoke method on the ConstructorInfo object to initialize an instance of the type, passing an object array that 
                    represents any parameters that the constructor call expects.

                To get the default constructor, you pass an empty array of type Type to the GetConstructor method call. If you want to invoke a 
                constructor that accepts parameters, you must pass a Type array that contains the types that the constructor accepts.

                */
                Console.WriteLine("** Instantiating a Type");
                {
                    var assemblyPath = "C:\\FourthCoffee\\Libs\\FourthCoffee.Service.ExceptionHandling.dll";
                    var assembly = Assembly.LoadFrom(assemblyPath);

                    var type = assembly.GetType("FourthCoffee.Service.ExceptionHandling.HandleError");

                    var constructor = type.GetConstructor(new Type[0]);
                    var initializedObject = constructor.Invoke(new object[0]);
                }

                /*
                
                To invoke an instance method, perform the following steps:

                    1. Create an instance of the MethodInfo class that represents the method you want to invoke. 
                    2. Call the Invoke method on the MethodInfo object, passing the initialized object and an object array that represents any 
                       parameters that the method call expects. You can then cast the return value of the Invoke method to the type of value you were 
                       expecting from the method call. 

                */
                Console.WriteLine("** Invoking Methods");
                {
                    var assemblyPath = "C:\\FourthCoffee\\Libs\\FourthCoffee.Service.ExceptionHandling.dll";
                    var assembly = Assembly.LoadFrom(assemblyPath);

                    var type = assembly.GetType("FourthCoffee.Service.ExceptionHandling.HandleError");

                    var constructor = type.GetConstructor(new Type[0]);
                    var initializedObject = constructor.Invoke(new object[0]);

                    var methodToExecute = type.GetMethod("LogError");
                    var response = methodToExecute.Invoke(initializedObject, new object[] { "Error message" }) as string;
                }

                /*
                
                When you invoke static methods, there is no need to create an instance of the type. Instead, you just create an instance of the 
                MethodInfo class that represents the method you want to invoke and then call the Invoke method. To invoke a static method, perform 
                the following steps: 

                    1. Create an instance of the MethodInfo class that represents the method you want to invoke. 
                    2. Call the Invoke method on the MethodInfo object, passing a null value to satisfy the initialized object and an object array 
                       that represents any parameters that the method call expects.

                */
                Console.WriteLine("** Invoking Static Methods");
                {
                    var assemblyPath = "C:\\FourthCoffee\\Libs\\FourthCoffee.Service.ExceptionHandling.dll";
                    var assembly = Assembly.LoadFrom(assemblyPath);

                    var type = assembly.GetType("FourthCoffee.Service.ExceptionHandling.HandleError");

                    var methodToExecute = type.GetMethod("FlushLog");
                    var isFlushed = methodToExecute.Invoke(null, new object[0]) as bool?;
                }
            }

            /*
            
            To get or set the value of an instance property, you must first perform the following steps:

                1. Create an instance of the PropertyInfo class that represents the property you want to get or set.
                2. If you want to get the value of a property, you must invoke the GetValue method on the PropertyInfo object. The GetValue method 
                   accepts an instance of the type as a parameter. 
                3. If you want to set the value of a property, you must invoke SetValue method on the PropertyInfo object. The SetValue method 
                   accepts an instance of the type and the value you want to set the property to as parameters. 

            */
            Console.WriteLine("** Gettting and Setting Properties");
            {
                var assemblyPath = "C:\\FourthCoffee\\Libs\\FourthCoffee.Service.ExceptionHandling.dll";
                var assembly = Assembly.LoadFrom(assemblyPath);

                var type = assembly.GetType("FourthCoffee.Service.ExceptionHandling.HandleError");

                var constructor = type.GetConstructor(new Type[0]);
                var initializedObject = constructor.Invoke(new object[0]);

                var property = type.GetProperty("LastErrorMessage");

                var lastErrorMessage = property.GetValue(initializedObject) as string;
                property.SetValue(initializedObject, "Database connection error");
            }

            /*
            
            When you get or set a static property, there is no need to create an instance of the type. Instead, you just create an instance of the 
            PropertyInfo class and then call either the GetValue or SetValue method. To get or set the value of a static property, perform the 
            following steps: 

                1. Create an instance of the PropertyInfo class that represents the property you want to get or set. 
                2. If you want to get the value of a property, you must invoke the GetValue method on the PropertyInfo object, passing a null value 
                   to satisfy the initialized object parameter.
                3. If you want to set the value of a property, you must invoke the SetValue method on the PropertyInfo object, passing a null value 
                   to satisfy the initialized object parameter, and the value you want to set the property too.

            */
            Console.WriteLine("** Gettting and Setting Static Properties");
            {
                var assemblyPath = "C:\\FourthCoffee\\Libs\\FourthCoffee.Service.ExceptionHandling.dll";
                var assembly = Assembly.LoadFrom(assemblyPath);

                var type = assembly.GetType("FourthCoffee.Service.ExceptionHandling.HandleError");

                var property = type.GetProperty("LastErrorMessage");

                var lastErrorMessage = property.GetValue(null) as string;
                property.SetValue(null, "Database connection error");
            }
        }

        #endregion
    }
}
