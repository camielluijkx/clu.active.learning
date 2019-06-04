using System;

namespace clu.active.learning
{
    /*
    
    Software systems can be complex and may involve applications that are implemented in a variety of technologies. For 
    example, some applications may be managed Microsoft® .NET Framework applications, whereas others may be unmanaged 
    C++ applications. You may want to use functionality from one application in another or use functionality that is 
    exposed through Component Object Model (COM) assemblies, such as the Microsoft Word 14.0 Object Library assembly, 
    in your applications. 

    Visual C# is a strongly typed static language. When you create a variable, you specify the type of that variable, 
    and you can only invoke methods and access members that this type defines. If you try to call a method that the 
    type does not implement, your code will not compile. This is good because the compile time checks catch a large 
    number of possible errors even before you run your code.
    
    The .NET Framework provides dynamic objects so that you can define objects that are not constrained by the static 
    type system in Visual C#. Instead, dynamic objects are not type checked until run time, which enables you to write 
    code quickly without worrying about defining every member until you need to call them in your code. 

    You can use dynamic objects in your .NET Framework applications to take advantage of dynamic languages and 
    unmanaged code. 
    
    Dynamic Languages 

    Languages such as IronPython and IronRuby are dynamic and enable you to write code that is not compiled until run 
    time. Dynamic languages provide the following benefits: 

        • They enable faster development cycles because they do not require a build or compile process. 
        • They have increased flexibility over static languages because there are no static types to worry about. 
        • They do not have a strongly typed object model to learn.

    Dynamic languages do suffer from slower execution times in comparison with compiled languages, because any 
    optimization steps that a compiler may take when compiling the code are left out of the build process. 

    Unmanaged Code 

    Visual C# is a managed language, which means that the Visual C# code you write is executed by a runtime environment 
    known as the Common Language Runtime (CLR). The CLR provides other benefits, such as memory management, Code Access 
    Security (CAS), and exception handling. Unmanaged code such as C++ executes outside the CLR and in general benefits 
    from faster execution times and being extremely flexible. 

    When you build applications by using the .NET Framework, it is a common use case to want to reuse unmanaged code. 
    Maybe you have a legacy C++ system that was implemented a decade ago, or maybe you just want to use a function in 
    the user32.dll assembly that Windows provides. The process of reusing functionality that is implemented in 
    technologies other than the .NET Framework is known as interoperability. These technologies can include: 

        • COM
        • C++ 
        • Microsoft ActiveX®
        • Microsoft Win32 application programming interface (API)

    Dynamic objects simplify the code that is required to interoperate with unmanaged code. 

    https://docs.microsoft.com/en-us/dotnet/api/system.dynamic.dynamicobject?view=netframework-4.7.2

    The .NET Framework provides the DLR, which contains the necessary services and components to support dynamic 
    languages and provides an approach for interoperating with unmanaged components. The DLR is responsible for 
    managing the interactions between the executing assembly and the dynamic object, for example, an object that is 
    implemented in IronPython or in a COM assembly. 

    The DLR simplifies interoperating with dynamic objects in the followings ways:

        • It defers type-safety checking for unmanaged resources until run time. Visual C# is a type-safe language and, 
          by default, the Visual C# compiler performs type-safety checking at compile time.

        Type safety relies on the compiler being able to compile or interpret each of the components that the solution 
        references. When interoperating with unmanaged components, the compile-time type-safety check is not always 
        possible. 

        • It abstracts the intricate details of interoperating with unmanaged components, including marshaling data 
          between the managed and unmanaged environments. 

    The DLR does not provide functionality that is pertinent to a specific language but provides a set of language 
    binders. A language binder contains instructions on how to invoke methods and marshal data between the unmanaged 
    language, such as IronPython, and the .NET Framework. The language binders also perform run-time type checks, 
    which include checking that a method with a given signature actually exists in the object. 

    https://docs.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/dynamic-language-runtime-overview

    */
    public static class DLR
    {
        #region Public Properties

        public static void UsingDynamicObjects()
        {
            /*
        
            The DLR infrastructure provides the dynamic keyword to enable you to define dynamic objects in your 
            applications. When you use the dynamic keyword to declare a dynamic object, it has the following 
            implications: 

                • It defines a variable of type object. You can assign any value to this variable and attempt to call 
                  any methods. At run time, the DLR will use the language binders to type check your dynamic code and 
                  ensure that the member you are trying to invoke exists. 
                • It instructs the compiler not to perform type checking on any dynamic code.
                • It suppresses the Microsoft IntelliSense® feature because IntelliSense is unable to provide syntax 
                  assistance for dynamic objects. 

            https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/using-type-dynamic

            */
            Console.WriteLine("* Using Dynamic Objects");
            {
                /*
                
                To create a dynamic object to consume the Microsoft.Office.Interop.Word COM assembly, perform the 
                following steps: 

                    1. In your .NET Framework project, add a reference to the Microsoft.Office.Interop.Word COM 
                       assembly. 
                    2. Bring the Microsoft.Office.Interop.Word namespace into scope. 

                */
                Console.WriteLine("** Dynamic Variable Declaration");
                {
                    //using Microsoft.Office.Interop.Word;

                    //dynamic word = new Application();
                }

                /*
                
                After you have instantiated a dynamic object by using the dynamic keyword, you can access the 
                properties and methods by using the standard Visual C# dot notation. 

                */
                Console.WriteLine("** Invoking a Method on a Dynamic Object");
                {
                    //// Start Microsoft Word.
                    //dynamic word = new Application();

                    //// Create a new document.
                    //dynamic doc = word.Documents.Add();
                    //doc.Activate();
                }

                /*
                
                You can also pass parameters to dynamic object method calls as you would with any .NET Framework 
                object. 

                Traditionally when consuming a COM assembly, the .NET Framework required you to use the ref keyword and 
                pass a Type.Missing object to satisfy any optional parameters that a method contains. Also, any 
                parameters that you pass must be of type object. This can result in simple method calls requiring a 
                long list of Type.Missing objects and code that is verbose and difficult to read. By using the dynamic 
                keyword, you can invoke the same methods but with less code. 

                https://docs.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/how-to-define-and-execute-dynamic-methods

                */
                Console.WriteLine("** Passing Parameters to a Method ");
                {
                    //string filePath = "C:\\FourthCoffee\\Documents\\Schedule.docx"; 

                    //dynamic word = new Application();
                    //dynamic doc = word.Documents.Open(filePath);
                    //doc.SaveAs(filePath);
                }
            }
        }

        #endregion
    }
}