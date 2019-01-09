using System;

namespace clu.active.learning
{
    /*
    Order of operations                                     ()
    Arithmetic                                              +, -, *, /, %
    Increment, decrement                                    ++, --
    Comparison                                              ==, !=, <, >, <=, >=, is, ??
    String concatenation                                    +
    Logical/bitwise operations                              &, !, ^, !, ~, &&, ||
    Indexing (counting starts from element 0)               []
    Casting                                                 (), as
    Assignment                                              =, +=, -=, *=, /=, %=, &=, |=, ^=, <<=, >>=
    Bit shift                                               <<, >>
    Type information                                        sizeof, typeof
    Delegate concatenation and removal                      +, -
    Overflow exception control                              checked, unchecked
    Indirection and Address (unsafe code only)              *, ->, [], &
    Conditional (ternary operator)                          ?:
    */
    public static class Operators
    {
        #region Private Methods

        private static int? getNullableIntReturnsNull()
        {
            return null;
        }

        private static string getStringReturnsNull()
        {
            return null;
        }

        private static bool secondOperandReturnsTrue()
        {
            Console.WriteLine("Second operand is evaluated and returns true.");
            return true;
        }

        #endregion

        #region Public Methods

        public static void InvokePrimaryOperators()
        {
            // TODO: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators
        }

        public static void InvokeUnaryOperators()
        {
            // TODO: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators
        }

        public static void InvokeMultiplicativeOperators()
        {
            // TODO: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators
        }

        public static void InvokeAdditiveOperators()
        {
            // TODO: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators
        }

        public static void InvokeShiftOperators()
        {
            // TODO: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators
        }

        public static void InvokeRelationalAndTypeTesingOperators()
        {
            // TODO: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators
        }

        public static void InvokeEqualityOperators()
        {
            // TODO: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators
        }

        public static void InvokeLogicalANDOperator()
        {
            Console.WriteLine("* Logical AND Operator");

            Console.WriteLine("** Integer logical bitwise AND operator");
            uint a = 0b_1111_1000;
            uint b = 0b_1001_1111;
            uint c = a & b;
            Console.WriteLine(Convert.ToString(c, toBase: 2));
            /*
            Output:
            10011000
            */

            Console.WriteLine("** Boolean logical AND operator");
            bool test = false & secondOperandReturnsTrue();
            Console.WriteLine(test);
            /*
            Output:
            Second operand is evaluated.
            False
            */
        }

        public static void InvokeLogicalXOROperator()
        {
            Console.WriteLine("* Logical XOR Operator");

            Console.WriteLine("** Logical exclusive-OR");
            // When one operand is true and the other is false, exclusive-OR 
            // returns True.
            Console.WriteLine(true ^ false);
            Console.WriteLine(false ^ true);
            // When both operands are false, exclusive-OR returns False.
            Console.WriteLine(false ^ false);
            // When both operands are true, exclusive-OR returns False.
            Console.WriteLine(true ^ true);
            /*
            Output:
            True
            True
            False
            False
            */

            Console.WriteLine("** Bitwise exclusive-OR"); // TODO
            // Bitwise exclusive-OR of 0 and 1 returns 1.
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0x0 ^ 0x1, 2));
            // Bitwise exclusive-OR of 0 and 0 returns 0.
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0x0 ^ 0x0, 2));
            // Bitwise exclusive-OR of 1 and 1 returns 0.
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0x1 ^ 0x1, 2));

            // With more than one digit, perform the exclusive-OR column by column.
            //    10
            //    11
            //    --
            //    01
            // Bitwise exclusive-OR of 10 (2) and 11 (3) returns 01 (1).
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0x2 ^ 0x3, 2));

            // Bitwise exclusive-OR of 101 (5) and 011 (3) returns 110 (6).
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0x5 ^ 0x3, 2));

            // Bitwise exclusive-OR of 1111 (decimal 15, hexadecimal F) and 0101 (5)
            // returns 1010 (decimal 10, hexadecimal A).
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0xf ^ 0x5, 2));

            // Finally, bitwise exclusive-OR of 11111000 (decimal 248, hexadecimal F8)
            // and 00111111 (decimal 63, hexadecimal 3F) returns 11000111, which is 
            // 199 in decimal, C7 in hexadecimal.
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0xf8 ^ 0x3f, 2));

            /*
            Output:
            Bitwise result: 1
            Bitwise result: 0
            Bitwise result: 0
            Bitwise result: 1
            Bitwise result: 110
            Bitwise result: 1010
            Bitwise result: 11000111
            */
        }

        public static void InvokeLogicalOROperator()
        {
            Console.WriteLine("* Logical OR Operator");

            Console.WriteLine("** Logical OR");
            Console.WriteLine(true | false);
            Console.WriteLine(false | false);
            /*
            Output:
            True
            False
            */

            Console.WriteLine("** Bitwise OR"); // TODO
            Console.WriteLine("0x{0:x}", 0xf8 | 0x3f);
            /*
            Output:
            0xff
            */
        }

        public static void InvokeConditionalANDOperator()
        {
            Console.WriteLine("* Conditional AND Operator"); // aka Short-Circuiting Logical AND Operator

            bool a = false && secondOperandReturnsTrue();
            Console.WriteLine(a);
            /* 
            Output:
            False
            */

            bool b = true && secondOperandReturnsTrue();
            Console.WriteLine(b);
            /*
            Output:
            Second operand is evaluated.
            True
            */
        }

        public static void InvokeConditionalOROperator()
        {
            Console.WriteLine("* Conditional OR Operator"); // aka Short-Circuiting Logical OR Operator

            bool a = true || secondOperandReturnsTrue();
            Console.WriteLine(a);
            /*
            Output:
            True
            */

            bool b = false || secondOperandReturnsTrue();
            Console.WriteLine(b);
            /*
            Output:
            Second operand is evaluated.
            True
            */
        }

        public static void InvokeNullCoalesingOperator()
        {
            Console.WriteLine("* Null Coalesing Operator");

            int? x = null;

            // Set y to the value of x if x is NOT null; otherwise,
            // if x == null, set y to -1.
            int y = x ?? -1;

            // Assign i to return value of the method if the method's result
            // is NOT null; otherwise, if the result is null, set i to the
            // default value of int.
            int i = getNullableIntReturnsNull() ?? default(int);

            string s = getStringReturnsNull();
            // Display the value of s if s is NOT null; otherwise, 
            // display the string "Unspecified".
            Console.WriteLine(s ?? "Unspecified");
        }

        public static void InvokeConditionalOperator()
        {
            Console.WriteLine("* Conditional Operator"); // aka Ternary Conditional Operator

            //The syntax for the conditional operator is as follows:
            //condition? consequence : alternative

            //The conditional operator is right-associative, that is, an expression of the form
            //a ? b : c ? d : e
            //is evaluated as
            //a ? b : (c ? d : e)

            //Use of the conditional operator over an if-else statement might result in more concise code in cases when you need conditionally to compute a value. 
            int input = new Random().Next(-5, 5);
            string classify;
            if (input >= 0)
            {
                classify = "nonnegative";
            }
            else
            {
                classify = "negative";
            }
            Console.WriteLine(classify);
            classify = (input >= 0) ? "nonnegative" : "negative";
            Console.WriteLine(classify);

            double sinc(double x) => x != 0.0 ? Math.Sin(x) / x : 1;
            Console.WriteLine(sinc(0.1));
            Console.WriteLine(sinc(0.0));
            /*
            Output:
            0.998334166468282
            1
            */

            Console.WriteLine("** Conditional ref expression (C# 7.2)"); // TODO

            //The syntax for the conditional ref expression is as follows:
            //condition ? ref consequence : ref alternative

            var smallArray = new int[] { 1, 2, 3, 4, 5 };
            var largeArray = new int[] { 10, 20, 30, 40, 50 };

            int index = 7;
            ref int refValue = ref ((index < 5) ? ref smallArray[index] : ref largeArray[index - 5]);
            refValue = 0;

            index = 2;
            ((index < 5) ? ref smallArray[index] : ref largeArray[index - 5]) = 100;

            Console.WriteLine(string.Join(" ", smallArray));
            Console.WriteLine(string.Join(" ", largeArray));
            /*
            Output:
            1 2 100 4 5
            10 20 0 40 50
            */
        }

        public static void InvokeAssigmentAndLambdaOperators()
        {
            // TODO: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators
        }

        #endregion
    }
}
