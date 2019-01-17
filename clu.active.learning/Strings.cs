using System;
using System.Text;
using System.Text.RegularExpressions;

namespace clu.active.learning
{
    public static class Strings
    {
        #region Public Methods

        public static void ConcatenateStrings()
        {
            Console.WriteLine("* Concatenate Strings");
            {
                // Bad coding practice because strings are immutable. This means that every time you concatenate a 
                // string, you create a new string in memory and the old string is discarded.
                string address = "23";
                address = address + ", Main Street";
                address = address + ", Buffalo";
            }

            Console.WriteLine("* Using StringBuilder");
            {
                StringBuilder address = new StringBuilder();
                address.Append("23");
                address.Append(", Main Street");
                address.Append(", Buffalo");

                string concatenatedAddress = address.ToString();
            }
        }

        public static void ValidateStrings()
        {
            Console.WriteLine("* Validate Strings");
            {
                Console.WriteLine("** Using Regex");
                {
                    // https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=netframework-4.7.2

                    var textToTest = "hell0 w0rld";
                    var regularExpression = "\\d";

                    var result = Regex.IsMatch(textToTest, regularExpression, RegexOptions.None);
                    if (result)
                    {
                        // Text matched expression.
                    }
                }

                // TODO: regex expressions
            }
        }

        #endregion
    }
}
