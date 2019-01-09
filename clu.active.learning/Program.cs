using System;

namespace clu.active.learning
{
    class Program
    {       
        static void Main(string[] args)
        {
            DataTypes.ShowCommonlyUsedDataTypes();
            DataTypes.CastingBetweenDataTypes();

            Variables.DeclareVariables();

            Operators.InvokePrimaryOperators();
            Operators.InvokeUnaryOperators();
            Operators.InvokeMultiplicativeOperators();
            Operators.InvokeAdditiveOperators();
            Operators.InvokeShiftOperators();
            Operators.InvokeRelationalAndTypeTesingOperators();
            Operators.InvokeEqualityOperators();
            Operators.InvokeLogicalANDOperator();
            Operators.InvokeLogicalXOROperator();
            Operators.InvokeLogicalOROperator();
            Operators.InvokeConditionalANDOperator();
            Operators.InvokeConditionalOROperator();
            Operators.InvokeNullCoalesingOperator();
            Operators.InvokeConditionalOperator();
            Operators.InvokeAssigmentAndLambdaOperators();

            Strings.ConcatenateStrings();
            Strings.ValidateStrings();

            Statements.InvokeConditionalStatements();

            Arrays.CreateDifferentArrays();

            Namespaces.UsingNamespaces();

            Properties.UseProperties();
            Methods.InvokeMethods();

            Exceptions.HandleExceptions();

            Console.ReadKey();
        }
    }
}