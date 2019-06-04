using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace clu.active.learning
{
    /*
    
    The .NET Framework uses attributes to provide additional metadata about a type or type member. The .NET Framework provides many attributes out 
    of the box that you can use in your applications. 
         
    Attributes provide a mechanism that uses the declarative programming model to include additional metadata about elements, such as types, 
    properties, and methods, in your application. Your application can use the additional information that attributes provide to control application 
    behavior and how data is processed at run time. You can also use the information that attributes encapsulate in case tools and other utilities 
    that aid the development process, such as unit test frameworks. 

    The .NET Framework makes extensive use of attributes throughout the base class library. The following list describes some of the attributes that 
    the .NET Framework provides: 

        • The Obsolete attribute in the System namespace, which you can use to indicate that a type or a type member has been superseded and is only 
          there to ensure backward compatibility. 
        • The Serializable attribute in the System namespace, which you can use to indicate that an IFormatter implementation can serialize and 
          deserialize a type. 
        • The NonSerialized attribute in the System namespace, which you can use to indicate that an IFormatter implementation should not serialize 
          or deserialize a member in a type. 
        • The DataContract attribute in the System.Runtime.Serialization namespace, which you can use to indicate that a DataContractSerializer object 
          can serialize and deserialize a type. 
        • The QueryInterceptor attribute in the System.Data.Services namespace, which you can use to control access to an entity in Window 
          Communication Foundation (WCF) Data Services. 
        • The ConfigurationProperty attribute in the System.Configuration namespace, which you can use to map a property member to a section in an 
          application configuration file. 

    All attributes in the .NET Framework derive either directly from the abstract Attribute base class in the System namespace or from another 
    attribute. 

    https://docs.microsoft.com/en-us/dotnet/api/system.attribute?view=netframework-4.7.2

    */
    public static class Attributes
    {
        #region Implementation

        [DataContract(Name = "SalesPersonContract", IsReference = false)]
        public class SalesPerson
        {
            [Obsolete("This property will be removed in the next release. Use the FirstName and LastName properties instead.")]
            [DataMember]
            public string Name { get; set; }
        }

        [AttributeUsage(AttributeTargets.All)]
        public class DeveloperInfoAttribute : Attribute
        {
            private string _emailAddress;
            private int _revision;

            public DeveloperInfoAttribute(string emailAddress, int revision)
            {
                this._emailAddress = emailAddress;
                this._revision = revision;
            }

            public string EmailAddress
            {
                get { return this._emailAddress; }
            }

            public int Revision
            {
                get { return this._revision; }
            }
        }

        [DeveloperInfo("holly@fourthcoffee.com", 3)]
        public class SalePerson
        {
            [DeveloperInfo("linda@fourthcoffee.com", 1)]
            public IEnumerable<Sale> GetAllSales()
            {
                return new List<Sale>();
            }
        }

        public class Sale
        {

        }

        #endregion

        #region Public Methods

        public static void ApplyingAttributes()
        {
            /*
            
            To use an attribute in your code, perform the following steps:

                1. Bring the namespace that contains the attribute you want to use into scope.
                2. Apply the attribute to the code element, satisfying any parameters that the constructor expects. 
                3. Optionally set any of the named parameters that the attribute exposes.
            
            You can apply multiple attributes to a single element to create a hierarchy of metadata that describes the element. 

            */
            Console.WriteLine("* Applying Attributes");
            {
                Console.WriteLine("** Applying the DataContract Attribute");
                {
                    
                }

                Console.WriteLine("** Applying the Obsolete and DataContract Attributes");
                {

                }
            }
        }

        public static void CreatingCustomAttributes()
        {
            /*
            
            The .NET Framework provides an extensive set of attributes that you can use in your applications. However, there will be a time when 
            you need an attribute that the .NET Framework does not provide.

            To create an attribute, perform the following steps:

                1. Create a type that derives from the Attribute base class or another existing attribute type. 
                2. Apply the AttributeUsage attribute to your custom attribute class to describe which elements you can apply this attribute to. 
                3. Define a constructor to initialize the custom attribute. 
                4. Define any properties that you want to enable users of the attribute to optionally provide information. Any properties that you 
                  define that have a get accessor will be exposed through the attribute as a named parameter. 

            When creating attributes, the convention is to end the name with an attribute suffix. When the type is used as an attribute, the 
            compiler removes that suffix. 

            https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/creating-custom-attributes

            */
            Console.WriteLine("* Creating Custom Attributes");
            {
                Console.WriteLine("** Creating a Custom Attribute");
                {

                }
            }
        }

        public static void ApplyingCustomAttributes()
        {
            Console.WriteLine("* Applying Custom Attributes");
            {
                Console.WriteLine("** Applying a Custom Attribute");
                {

                }
            }
        }

        public static void UsingReflection()
        {
            /*
            
            If you use the existing attributes that the .NET Framework provides, they normally have a purpose other than just to exist in your code. 
            For example, the IFormatter serializers use the Serializable attribute during the serializing and deserializing processes. 
            
            Similarly, you can use attributes to encapsulate metadata about an element in your code. For example, if you create an attribute that 
            provides information about the developer who authored the element, you may want a way to extract this information so that you can produce 
            a document listing all of the developers who were involved in developing the application. 

            Similar to accessing other type and member information, you can also use reflection to process attributes. The System.Reflection namespace 
            provides a collection of extension methods that you can use to access attributes and the metadata they encapsulate. The following list 
            describes some of these methods: 

                • GetCustomAttribute. This method enables you to get a specific attribute that was used on an element. The following code example 
                  shows how to get a DeveloperInfo attribute that has been applied to a type. 
                • GetCustomAttribute<T>. This generic method also enables you to get a specific attribute that was used on an element. This is a 
                  generic method, so you can specify the type of attribute you want the GetCustomAttribute method to return. This means that you do 
                  not have to write conditional logic to filter an array of objects to determine the type of an attribute and perform any casting.
                • GetCustomAttributes. This method enables you to get a list of specific attributes that were used on an element. Typically, you 
                  would use this method if more than one attribute of the same type has been applied to an element, in which case this method call 
                  would return all instances. 
                • GetCustomAttributes<T>. This generic method enables you to get a list of specific attributes that were used on an element. Similar 
                  to the GetCustomAttribute<T> generic method, because this is a generic method, the method call will only return attributes that 
                  match the generic type.

            The getInheritedAttributes parameter instructs the GetCustomAttribute method call to return either only attributes that have been 
            explicitly applied to the current type, or attributes that have been either explicitly applied or inherited from any parent type. 

            https://docs.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/accessing-custom-attributes

            */
            Console.WriteLine("* Using Reflection");
            {
                Console.WriteLine("** Using type.GetCustomAttribute");
                {
                    var assemblyPath = "C:\\FourthCoffee\\Libs\\FourthCoffee.Service.ExceptionHandling.dll";
                    var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);

                    var type = assembly.GetType("FourthCoffee.Service.ExceptionHandling.HandleError");

                    var getInheritedAttributes = false;
                    var attribute = type.GetCustomAttribute(typeof(DeveloperInfoAttribute), getInheritedAttributes);
                }

                Console.WriteLine("** Using type.GetCustomAttribute<T>");
                {
                    var assemblyPath = "C:\\FourthCoffee\\Libs\\FourthCoffee.Service.ExceptionHandling.dll";
                    var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);

                    var type = assembly.GetType("FourthCoffee.Service.ExceptionHandling.HandleError");

                    var getInheritedAttributes = false;
                    var attribute = type.GetCustomAttribute<DeveloperInfoAttribute>(getInheritedAttributes);
                }

                Console.WriteLine("** Using type.GetCustomAttributes");
                {
                    var assemblyPath = "C:\\FourthCoffee\\Libs\\FourthCoffee.Service.ExceptionHandling.dll";
                    var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);

                    var type = assembly.GetType("FourthCoffee.Service.ExceptionHandling.HandleError");

                    var getInheritedAttributes = false;
                    var attributes = type.GetCustomAttributes(typeof(DeveloperInfoAttribute), getInheritedAttributes);
                }

                Console.WriteLine("** Using type.GetCustomAttributes<T>");
                {
                    var assemblyPath = "C:\\FourthCoffee\\Libs\\FourthCoffee.Service.ExceptionHandling.dll";
                    var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);

                    var type = assembly.GetType("FourthCoffee.Service.ExceptionHandling.HandleError");

                    var getInheritedAttributes = false;
                    var attributes = type.GetCustomAttributes<DeveloperInfoAttribute>(getInheritedAttributes);
                }

                /*
                
                To access custom attributes that have been applied to a member, you must create an xxxxInfo object that represents the member 
                and then invoke the GetCustomAttributes method. 

                */
                Console.WriteLine("** Iterating Custom Attributes That Have Been Applied to a Type");
                {
                    var assemblyPath = "C:\\FourthCoffee\\Libs\\FourthCoffee.Service.ExceptionHandling.dll";
                    var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);

                    var type = assembly.GetType("FourthCoffee.Service.ExceptionHandling.HandleError");

                    var attributes = type.GetCustomAttributes(typeof(DeveloperInfoAttribute), false) as DeveloperInfoAttribute[];
                    foreach (var attribute in attributes)
                    {
                        var developerEmailAddress = attribute.EmailAddress;
                        var codeRevision = attribute.Revision;
                    }
                }

                Console.WriteLine("** Iterate Custom Attributes That Have Been Applied to a Method");
                {
                    var assemblyPath = "C:\\FourthCoffee\\Libs\\FourthCoffee.Service.ExceptionHandling.dll";
                    var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);

                    var type = assembly.GetType("FourthCoffee.Service.ExceptionHandling.HandleError");

                    var methodToInspect = type.GetMethod("GetAllSales");
                    var attributes = methodToInspect.GetType().GetCustomAttributes(typeof(DeveloperInfoAttribute), false) as DeveloperInfoAttribute[];
                    foreach (var attribute in attributes)
                    {
                        var developerEmailAddress = attribute.EmailAddress;
                        var codeRevision = attribute.Revision;
                    }
                }
            }
        }

        #endregion
    }
}
