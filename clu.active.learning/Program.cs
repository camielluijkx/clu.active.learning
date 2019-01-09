using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace clu.active.learning
{
    class Program
    {       
        static void Main(string[] args)
        {
            DataTypes.ShowCommonlyUsedDataTypes();
            DataTypes.CastingBetweenDataTypes();

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

            Console.ReadKey();
        }
    }
}