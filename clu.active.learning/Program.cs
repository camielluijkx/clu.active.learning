using System.Threading;

namespace clu.active.learning
{
    /*
     
    https://www.microsoft.com/en-us/learning/exam-70-483.aspx

    */
    class Program
    {       
        static void Main(string[] args)
        {
            DataTypes.UsingCommonlyUsedDataTypes();
            DataTypes.CastingBetweenDataTypes();

            Variables.UsingVariables();

            Operators.UsingPrimaryOperators();
            Operators.UsingUnaryOperators();
            Operators.UsingMultiplicativeOperators();
            Operators.UsingAdditiveOperators();
            Operators.UsingShiftOperators();
            Operators.UsingRelationalAndTypeTesingOperators();
            Operators.UsingEqualityOperators();
            Operators.UsingLogicalANDOperator();
            Operators.UsingLogicalXOROperator();
            Operators.UsingLogicalOROperator();
            Operators.UsingConditionalANDOperator();
            Operators.UsingConditionalOROperator();
            Operators.UsingNullCoalesingOperator();
            Operators.UsingConditionalOperator();
            Operators.UsingAssigmentAndLambdaOperators();

            Strings.ConcatenateStrings();
            Strings.ValidateStrings();

            Statements.UsingConditionalStatements();
            Statements.UsingIterationStatements();

            Arrays.UsingArrays();

            Namespaces.UsingNamespaces();

            Exceptions.UsingExceptions();

            //Diagnostics.UsingEventLog();
            //Diagnostics.UsingDebugging();
            //Diagnostics.UsingTracing();

            Enums.UsingEnums();

            Structs.UsingStructs();
            Properties.UsingProperties();
            Methods.UsingMethods();

            Collections.UsingArrayList();
            Collections.UsingBitArray();
            Collections.UsingHashTable();
            Collections.UsingQueue();
            Collections.UsingSortedList();
            Collections.UsingStack();
            Collections.UsingListDictionary();
            Collections.UsingHybridDictionary();
            Collections.UsingOrderedDictionary();
            Collections.UsingNameValueCollection();
            Collections.UsingStringCollection();
            Collections.UsingStringDictionary();
            Collections.UsingBitVector32();

            Events.UsingEventHandlers();

            LINQ.UsingQuerySyntax();
            LINQ.UsingMethodSyntax();
            LINQ.UsingMixedSyntax();
            LINQ.UsingLINQToXML();
            LINQ.UsingLINQToEntities();
            LINQ.UsingLINQToObjects();
            LINQ.UsingQueryOperators();
            LINQ.LazyVsEagerEvaluation();

            Classes.UsingClasses();
            Interfaces.UsingInterfaces();
            Interfaces.UsingIComparable();
            Interfaces.UsingIComparer();

            Generics.UsingGenerics();

            Inheritance.UsingInheritance();

            Extensions.UsingExtensions();

            //FileSystem.ReadingFiles();
            //FileSystem.WritingFiles();
            //FileSystem.FileManipulation();
            //FileSystem.FileInformation();
            //FileSystem.DirectoryManipulation();
            //FileSystem.DirectoryInformation();
            //FileSystem.FileAndDirectoryPaths();

            //Serialization.UsingSerialization();

            Streams.UsingStreams();

            Thread.Sleep(5000);

            //Console.ReadKey();
        }
    }
}