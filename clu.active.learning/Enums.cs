using System;

namespace clu.active.learning
{
    /*
    
    Efficient way to define a set of named integral constants that may be assigned to a variable.

    Using enums has several advantages over using text or numerical types:

        • Improved manageability. By constraining a variable to a fixed set of valid values, you are less likely to 
          experience invalid arguments and spelling mistakes.
        • Improved developer experience. In Visual Studio, the IntelliSense feature will prompt you with the available 
          values when you use an enum.
        • Improved code readability. The enum syntax makes your code easier to read and understand. 
    
    */
    public static class Enums
    {
        #region Implementation

        // Declaring an enum.
        // Each member of an enum has a name and a value.
        public enum Day : int // By default the underlying type of each element in the enum is int. 
        {
            // If you do not specify a value for each member, members are assigned incremental values starting with 0.
            Sunday = 0,

            // Monday will be 1.
            Monday,

            // Tuesday will be 2.
            Tuesday,

            Wednesday,
            Thursday,
            Friday,

            // Saturday will be 6.
            Saturday
        };

        public enum MachineState // Approved types for enum are byte, sbyte, short, ushort, int, uint, long, or ulong.
        {
            PowerOff = 0,
            Running = 5, // Continues with 5.
            SomethingInBetween, // Will be 6.
            Sleeping = 10,
            Hibernating = Sleeping + 5
        }

        public enum Range : long
        {
            Max = 2147483648L,
            Zero = 0L,
            Min = 255L
        };

        [Flags] // Using bit flags to arrange AND, OR, NOT and XOR bitwise operations can be performed on them.
        enum Days
        {
            None = 0x0,
            Sunday = 0x1,
            Monday = 0x2,
            Tuesday = 0x4,
            Wednesday = 0x8,
            Thursday = 0x10,
            Friday = 0x20,
            Saturday = 0x40
        }

        #endregion

        #region Public Methods

        public static void UsingEnums()
        {
            Console.WriteLine("* Using Enums");
            {
                Day favoriteDay = Day.Friday;
            }

            Console.WriteLine("** Set Enum by Name");
            {
                Day favoriteDay = Day.Saturday;
                Console.WriteLine($"({(int)favoriteDay}) {favoriteDay}"); // Output: (6) Saturday
            }

            Console.WriteLine("** Set Enum by Value");
            {
                Day favoriteDay = (Day)7; // It's possible to assign any arbitrary integer value to favoriteDay.
                Console.WriteLine($"({(int)favoriteDay}) {favoriteDay}"); // Output: (7) 7
            }

            Console.WriteLine("** Define a Range");
            {
                long x = (long)Range.Max;
                long y = (long)Range.Min;
                Console.WriteLine("Max = {0}", x);
                Console.WriteLine("Zero = {0}", (long)Range.Zero);
                Console.WriteLine("Min = {0}", y);

                /* 
                
                Output:
                Max = 2147483648
                Zero = 0
                Min = 255
                
                */
            }

            Console.WriteLine("** Using Bit Flags");
            {
                // Initialize with two flags using bitwise OR.
                Days meetingDays = Days.Tuesday | Days.Thursday;

                // Set an additional flag using bitwise OR.
                meetingDays = meetingDays | Days.Friday;

                Console.WriteLine("Meeting days are {0}", meetingDays);
                // Output: Meeting days are Tuesday, Thursday, Friday

                // Remove a flag using bitwise XOR.
                meetingDays = meetingDays ^ Days.Tuesday;
                Console.WriteLine("Meeting days are {0}", meetingDays);
                // Output: Meeting days are Thursday, Friday

                // Test value of flags using bitwise AND.
                bool test = (meetingDays & Days.Thursday) == Days.Thursday;
                Console.WriteLine("Thursday {0} a meeting day.", test == true ? "is" : "is not");
                // Output: Thursday is a meeting day.
            }

            Console.WriteLine("Using System.Enum");
            {
                string s = Enum.GetName(typeof(Day), 4);
                Console.WriteLine(s);

                Console.WriteLine("The values of the Day Enum are:");
                foreach (int i in Enum.GetValues(typeof(Day)))
                {
                    Console.WriteLine(i);
                }

                Console.WriteLine("The names of the Day Enum are:");
                foreach (string str in Enum.GetNames(typeof(Day)))
                {
                    Console.WriteLine(str);
                }
            }
        }

        #endregion
    }
}
