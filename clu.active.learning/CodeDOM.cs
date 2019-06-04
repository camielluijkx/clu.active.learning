using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

namespace clu.active.learning
{
    /*
    
    You can use Visual Studio to write managed code when you have clearly defined requirements upon which to base your implementation. However, 
    sometimes you may want to generate code at run time based on a varying set of requirements. In this scenario, you need a framework that enables 
    you to define instructions that a process can translate into executable code. The .NET Framework provides the CodeDOM feature for this very 
    purpose. 

    CodeDOM is a feature of the .NET Framework that enables you to generate code at run time. CodeDOM enables you to build a model that represents 
    the source code that you want to create and then generate the source code by using one of the code generators that are included in CodeDOM. By 
    default, CodeDOM includes code generators for Visual C#, Microsoft Visual Basic®, and Microsoft JScript®. 

    CodeDOM is a powerful feature that you can use for generating template source files that contain boilerplate code or even generating source code 
    files that serve as a proxy between your application and a remote entity. To use CodeDOM in your application, use the following namespaces: 

        • System.CodeDom. This namespace contains types that enable you to define a model that represents the source code you want to generate. 
        • System.CodeDom.Compiler. This namespace contains types that enable you to generate and manage compiled code. 
        • Microsoft.CSharp.CSharpCodeProvider. This namespace contains the Visual C# code compiler and generator. 
        • Microsoft.JScript.JScriptCodeProvider. This namespace contains the JScript code compiler and generator. 
        • Microsoft.VisualBasic.VBCodeProvider. This namespace contains the Visual Basic code compiler and generator. 

    You can use the classes in the System.CodeDom namespace to create a model that represents the code you want to create. The model can include 
    anything from a complex class hierarchy to a single class with some members. For example, you can use the CodeNamespace class to represent a 
    namespace, and you can use the CodeMemberMethod class to represent a method. 

    The following table describes some of the classes you can use to create your model.

    Class                           Description 
    CodeCompileUnit                 Enables you to encapsulate a collection of types that ultimately will compile into an assembly. 
    CodeNamespace                   Enables you to define a namespace that you can use to organize your class hierarchy.
    CodeTypeDeclaration             Enables you to define a class, structure, interface, or enumeration in your model.
    CodeMemberMethod                Enables you to define a method in your model and add it to a type, such as a class or an interface. 
    CodeMemberField                 Enables you to define a field, such as an int variable, and add it to a type, such as a class or struct. 
    CodeMemberProperty              Enables you to define a property with get and set accessors and add it to a type, such as a class or struct. 
    CodeConstructor                 Enables you to define a constructor so that you can create an instance type in your model. 
    CodeTypeConstructor             Enables you to define a static constructor so that you can create a singleton type in your model. 
    CodeEntryPoint                  Enables you to define an entry point in your type, which is typically a static method with the name Main. 
    CodeMethodInvokeExpression      Enables you to create a set of instructions that represents an expression that you want to execute. 
    CodeMethodReferenceExpression   Enables you to create a set of instructions that detail a method in a particular type that you want to execute. 
                                    Typically, you would use this class with the CodeMethodInvokeExpression class when you implement the body of method 
                                    in a model. 
    CodeTypeReferenceExpression     Enables you to represent a reference type that you want to use as part of an expression in your model. Typically, 
                                    you would use this class with the CodeMethodInvokeExpression class and the CodeTypeReferenceExpression class when 
                                    you implement the body of method in a model. 
    CodePrimitiveExpression         Enables you to define an expression value, which you may want to pass as a parameter to a method or store in a 
                                    variable. 
    
    After you have defined your model by using the classes in the System.CodeDom namespace, you can then use a code generator provider, such as the 
    CSharpCodeProvider class in the Microsoft.CSharp.CSharpCodeProvider namespace, to compile your model and generate your code. 

    https://docs.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/dynamic-source-code-generation-and-compilation

    */
    public static class CodeDOM
    {
        #region Implementation

        private static CodeCompileUnit getCodeCompileUnit()
        {
            var unit = new CodeCompileUnit();

            var dynamicNamespace = new CodeNamespace("FourthCoffee.Dynamic");
            unit.Namespaces.Add(dynamicNamespace);

            dynamicNamespace.Imports.Add(new CodeNamespaceImport("System"));

            var programType = new CodeTypeDeclaration("Program");
            dynamicNamespace.Types.Add(programType);

            var mainMethod = new CodeEntryPointMethod();
            programType.Members.Add(mainMethod);

            var targetObject = new CodeTypeReferenceExpression("Console");
            var someExpression = new CodeMethodInvokeExpression(targetObject, "WriteLine",
                new CodePrimitiveExpression("Hello Development Team..!!"));
            mainMethod.Statements.Add(someExpression);

            var anotherExpression = new CodeMethodInvokeExpression(targetObject, "ReadLine");
            mainMethod.Statements.Add(anotherExpression);

            return unit;
        }

        #endregion

        #region Public Methods

        public static void DefiningTypeAndTypeMembers()
        {
            /*
            
            Defining a type by using CodeDOM follows the same pattern as defining a type in native Visual C#. The only difference is that when using 
            CodeDOM, you write a set of instructions that a code generator provider will interpret to generate the source code that represents your 
            model. 

            The System.CodeDOM namespace includes the types that you can use to write these instructions. The following steps describe how to use some 
            of the System.CodeDOM types to define a type that contains an entry point method named Main: 

                1. Create a CodeCompileUnit object to represent the assembly that will contain the type. 
                2. Create a CodeNamespace object to represent the namespace that the type will be scoped to and add the namespace to the 
                   CodeCompileUnit object.
                3. Import any additional namespaces that the types in the namespace will use.
                4. Create a CodeTypeDeclaration object that represents the type you want to add to the namespace.
                5. Create a CodeEntryPointMethod object to represent the static main method in the Program type.
                6. Define the body of the Main method by using the CodeMethodInvokeExpression, CodeTypeReferenceExpression, and 
                   CodePrimitiveExpression classes. The parameters that you pass to the constructors of these objects enable you to define which method 
                   you want to invoke and the parameters that the method expects.

            https://docs.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/using-the-codedom

            */
            Console.WriteLine("* Defining Type and Type Members");
            {
                var compileUnit = getCodeCompileUnit();
            }
        }

        public static void CompilingCodeDOMModel()
        {
            /*
            
            After you have defined the contents of your assembly by using the types in the System.CodeDOM namespace, you can then compile and generate 
            an assembly. You can split the process for compiling and generating an assembly into the following parts: 

                1. Compiling the model and generating source code files for each type.
                2. Generating an assembly that contains the necessary references and the types that are defined in the source code files. 

            https://docs.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/generating-and-compiling-source-code-from-a-codedom-graph

            */
            Console.WriteLine("* Compiling a CodeDOM Model");
            {
                /*
                
                To compile your model and generate source code files, perform the following steps:

                    1. Create an instance of the code generator provider you want to use.
                    2. Create a StreamWriter object that the code generator will use to write the compiled code to a file.
                    3. Create an IndentedTextWriter object that will write the indented source code to a file. 
                    4. Create a CodeGeneratorOptions object that encapsulates your code generation settings.
                    5. Invoke the GenerateCodeFromCompileUnit method on the CSharpCodeProvider object to generate the source code. 
                    6. Close the IndentedTextWriter and StreamWriter objects. 

                */
                Console.WriteLine("** Compiling a Model into a Source Code File");
                {
                    var provider = new CSharpCodeProvider();

                    var fileName = "program.cs";
                    var stream = new StreamWriter(fileName);

                    var textWriter = new IndentedTextWriter(stream);

                    var options = new CodeGeneratorOptions();
                    options.BlankLinesBetweenMembers = true;

                    var compileUnit = getCodeCompileUnit();
                    provider.GenerateCodeFromCompileUnit(compileUnit, textWriter, options);

                    textWriter.Close();
                    stream.Close();

                    /*
                    
                    //------------------------------------------------------------------------------
                    // <auto-generated>
                    //     This code was generated by a tool.
                    //     Runtime Version:4.0.30319.42000
                    //
                    //     Changes to this file may cause incorrect behavior and will be lost if
                    //     the code is regenerated.
                    // </auto-generated>
                    //------------------------------------------------------------------------------

                    namespace FourthCoffee.Dynamic {
                        using System;
      
                        public class Program {
        
                            public static void Main() {
                                Console.WriteLine("Hello Development Team..!!");
                                Console.ReadLine();
                            }
                        }
                    }

                    */
                }

                /*
                
                After you have compiled your CodeDOM model into one or more source code files, you can compile the files into an assembly. 

                To generate an executable assembly that contains the FourthCoffee.Dynamic.Program type from a source code file, perform the following 
                steps: 

                    1. Create an instance of the code generator provider you want to use.
                    2. Create a CompilerParameters object that you will use to define the settings for the compiler, such as which assemblies to 
                       reference, and whether to generate a .dll or an .exe file. 
                    3. Invoke the CompileAssemblyFromFile method on the CSharpCodeProvider object to generate the assembly.
                    4. You can then use the properties that the CompilerResults object provides to determine whether the compilation was successful. 

                The CompileAssemblyFromFile method also accepts an array of source file names, so you can compile several source code files into a 
                single assembly. 

                */
                Console.WriteLine("** Compiling Source Code into an Assembly");
                {
                    var provider = new CSharpCodeProvider();

                    var compilerSettings = new CompilerParameters();
                    compilerSettings.ReferencedAssemblies.Add("System.dll");
                    compilerSettings.GenerateExecutable = true;
                    compilerSettings.OutputAssembly = "FourthCoffee.exe";

                    var sourceCodeFileName = "program.cs";
                    var compilationResults = provider.CompileAssemblyFromFile(compilerSettings, sourceCodeFileName);

                    var buildFailed = false;
                    foreach (var error in compilationResults.Errors)
                    {
                        var errorMessage = error.ToString();
                        buildFailed = true;
                    }
                }
            }
        }

        #endregion
    }
}
