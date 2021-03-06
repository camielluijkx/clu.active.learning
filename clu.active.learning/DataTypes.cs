﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace clu.active.learning
{
    #region Extensions

    public struct TypeSizeProxy<T>
    {
        public T PublicField;
    }

    public static class SizeCalculator
    {
        public static int SizeOf<T>()
        {
            try
            {
                return Marshal.SizeOf(typeof(T));
            }
            catch (ArgumentException)
            {
                return Marshal.SizeOf(new TypeSizeProxy<T>());
            }
        }

        public static int GetSize(this object obj)
        {
            return Marshal.SizeOf(obj);
        }
    }

    #endregion

    public static class DataTypes
    {
        #region Constants

        /* 
        
        Numeral literal syntax improvements (introduced in Visual C# 7.0, enhanced in C# 7.2).

        The 0b at the beginning indicates that the number is written as a binary number.
        
        Binary numbers can get very long, so it's often easier to see the bit patterns by introducing the _ as a digit 
        separator.
        
        */
        public const int One = 0b0001;
        public const int Two = 0b0010;
        public const int Four = 0b0100;
        public const int Eight = 0b1000;
        public const int Sixteen = 0b0001_0000;
        public const int ThirtyTwo = 0b0010_0000;
        public const int SixtyFour = 0b0100_0000;
        public const int OneHundredTwentyEight = 0b1000_0000;

        // The digit separator can appear anywhere in the constant. For base 10 numbers, it would be common to use it 
        // as a thousands separator.
        public const long BillionsAndBillions = 100_000_000_000;

        // The digit separator can be used with decimal, float and double types as well.
        public const double AvogadroConstant = 6.022_140_857_747_474e23;
        public const decimal GoldenRatio = 1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M;

        #endregion

        #region Public Methods

        public static void UsingCommonlyUsedDataTypes()
        {
            Console.WriteLine("* Using Commonly Used Data Types");
            {
                // int - whole numbers
                int intMinValue = int.MinValue;
                Console.WriteLine($"int min value: {intMinValue} (size: {Marshal.SizeOf(intMinValue)})");
                int intMaxValue = int.MaxValue;
                Console.WriteLine($"int max value: {intMaxValue} (size: {Marshal.SizeOf(intMaxValue)})");

                // long - whole numbers (bigger range)
                long longMinValue = long.MinValue;
                Console.WriteLine($"long min value: {longMinValue} (size: {Marshal.SizeOf(longMinValue)})");
                long longMaxValue = long.MaxValue;
                Console.WriteLine($"long max value: {longMaxValue} (size: {Marshal.SizeOf(longMaxValue)})");

                // float - floating-point numbers
                float floatMinValue = float.MinValue;
                Console.WriteLine($"float min value: {floatMinValue} (size: {Marshal.SizeOf(floatMinValue)})");
                float floatMaxValue = float.MaxValue;
                Console.WriteLine($"float max value: {floatMaxValue} (size: {Marshal.SizeOf(floatMaxValue)})");

                // double - double precision
                double doubleMinValue = double.MinValue;
                Console.WriteLine($"double min value: {doubleMinValue} (size: {Marshal.SizeOf(doubleMinValue)})");
                double doubleMaxValue = double.MaxValue;
                Console.WriteLine($"double max value: {doubleMaxValue} (size: {Marshal.SizeOf(doubleMaxValue)})");

                // decimal - monetary values
                decimal decimalMinValue = decimal.MinValue;
                Console.WriteLine($"decimal min value: {decimalMinValue} (size: {Marshal.SizeOf(decimalMinValue)})");
                decimal decimalMaxValue = decimal.MaxValue;
                Console.WriteLine($"decimal max value: {decimalMaxValue} (size: {Marshal.SizeOf(decimalMaxValue)})");

                // char - single character
                char charMinValue = char.MinValue;
                Console.WriteLine($"char min value: {charMinValue} (size: {Marshal.SizeOf(charMinValue)})");
                char charMaxValue = char.MaxValue;
                Console.WriteLine($"char max value: {charMaxValue} (size: {Marshal.SizeOf(charMaxValue)})");

                // bool - boolean
                bool boolFalseValue = false;
                Console.WriteLine($"bool false value: {boolFalseValue} (size: {Marshal.SizeOf(boolFalseValue)})");
                bool boolTrueValue = true;
                Console.WriteLine($"bool true value: {boolTrueValue} (size: {Marshal.SizeOf(boolTrueValue)})");

                // datetime - moments in time
                DateTime datetimeMinValue = DateTime.MinValue;
                //Console.WriteLine($"datetime min value: {datetimeMinValue} (size: " +
                //$"{Marshal.SizeOf(datetimeMinValue)})");
                //System.ArgumentException: 'Type 'System.DateTime' cannot be marshaled as an unmanaged structure; no 
                //meaningful size or offset can be computed.'
                Console.WriteLine($"datetime min value: {datetimeMinValue} (size: " +
                    $"{SizeCalculator.SizeOf<DateTime>()})");
                DateTime datetimeMaxValue = DateTime.MaxValue;
                //Console.WriteLine($"datetime max value: {datetimeMaxValue} (size: " +
                    //$"{Marshal.SizeOf(datetimeMaxValue)})");
                //System.ArgumentException: 'Type 'System.DateTime' cannot be marshaled as an unmanaged structure; no 
                //meaningful size or offset can be computed.'
                Console.WriteLine($"datetime max value: {datetimeMaxValue} (size: " +
                    $"{SizeCalculator.SizeOf<DateTime>()})");

                // string - sequence of characters
                string stringValue = "some string";
                //Console.WriteLine($"string value: {stringValue}, characters: " +
                    //$"{string.Join(",", stringValue.ToCharArray())}, (size: " +
                    //$"{Marshal.SizeOf(stringValue)})");
                //System.ArgumentException: 'Type 'System.String' cannot be marshaled as an unmanaged structure; no 
                //meaningful size or offset can be computed.'
                Console.WriteLine($"string value: {stringValue}, characters: " +
                    $"{string.Join(",", stringValue.ToCharArray())}, (size: " +
                    $"{ASCIIEncoding.ASCII.GetByteCount(stringValue)} in ASCII)"); // 1 byte per character
                Console.WriteLine($"string value: {stringValue}, characters: " +
                    $"{string.Join(",", stringValue.ToCharArray())}, (size: " +
                    $"{ASCIIEncoding.Unicode.GetByteCount(stringValue)} in Unicode)"); // 2 bytes per character
            }
        }

        public static void CastingBetweenDataTypes()
        {
            Console.WriteLine("* Casting Between Data Types"); // aka Type Conversion
            {
                Console.WriteLine("** Implicit Conversion"); // without losing information
                {
                    /*
                    
                    From            To
                    sbyte           short, int, long, float, double, decimal
                    byte            short, ushort, int, uint, long, ulong, float, double, decimal
                    short           int, long, float, double, decimal
                    ushort          int, uint, long, ulong, float, double, decimal
                    int             long, float, double, decimal
                    uint            long, ulong, float, double, decimal
                    long, ulong     float, double, decimal
                    float           double
                    char            ushort, int, uint, long, ulong, float, double, decimal
                    
                    */

                    int a = 4;
                    long b = 5;
                    b = a; // widening of an integer
                }

                Console.WriteLine("** Explicit Conversion"); // possibly lose information
                {
                    int a = 4;
                    long b = 5;
                    b = a;
                    a = (int)b;
                }

                Console.WriteLine("** Using System.Convert");
                {
                    string numberString = "1234";
                    int number = Convert.ToInt32(numberString);
                }

                Console.WriteLine("** Using TryParse");
                {
                    int number = 0;
                    string numberString = "1234";
                    if (int.TryParse(numberString, out number))
                    {
                        // Conversion succeeded, number now equals 1234.
                    }
                    else
                    {
                        // Conversion failed, number now equals 0.
                    }
                }
            }
        }

        #endregion
    }
}