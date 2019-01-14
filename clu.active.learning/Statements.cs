using System;

namespace clu.active.learning
{
    public static class Statements
    {
        #region Private Methods

        private static bool checkIfUserWantsToEnterData()
        {
            return false;
        }

        private static bool checkIfUserHasMoreData()
        {
            return true;
        }

        #endregion

        #region Public Methods

        public static void UsingConditionalStatements()
        {
            Console.WriteLine("* Using Conditional Statements");
            {
                Console.WriteLine("** If");
                {
                    string response = "….";
                    if (response == "connection_failed")
                    {
                        // Block of code to execute if the value of the response variable is "connection_failed".
                    }
                }

                Console.WriteLine("** If / Else");
                {
                    string response = "….";
                    if (response == "connection_failed")
                    {
                        // Block of code executes if the value of the response variable is "connection_failed".
                    }
                    else
                    {
                        // Block of code executes if the value of the response variable is not "connection_failed".
                    }
                }

                Console.WriteLine("** Else If");
                {
                    string response = "….";
                    if (response == "connection_failed")
                    {
                        // Block of code executes if the value of the response variable is "connection_failed".
                    }
                    else if (response == "connection_error")
                    {
                        // Block of code executes if the value of the response variable is "connection_error".
                    }
                    else
                    {
                        // Block of code executes if the value of the response variable is not "connection_failed" or "connection_error".
                    }
                }

                Console.WriteLine("** Switch");
                {
                    string response = "….";
                    switch (response) // A switch case must end with a jump statement, such as break, return or goto.
                    {
                        case "connection_failed":
                            // Block of code executes if the value of response is "connection_failed".
                            break;
                        case "connection_success":
                            // Block of code executes if the value of response is "connection_success".
                            break;
                        case "connection_error":
                            // Block of code executes if the value of response is "connection_error".
                            break;
                        default:
                            // Block executes if none of the above conditions are met.
                            break;
                    }
                }
            }
        }

        public static void UsingIterationStatements()
        {
            Console.WriteLine("* Using Iteration Statements");
            {
                Console.WriteLine("** For");
                {
                    for (int i = 0; i < 10; i++)
                    {
                        // Code to execute.
                    }
                }

                Console.WriteLine("Foreach");
                {
                    string[] names = new string[10];
                    // Process each name in the array.
                    foreach (string name in names)
                    {
                        // Code to execute.
                    }
                }

                Console.WriteLine("** While");
                {
                    bool dataToEnter = checkIfUserWantsToEnterData();
                    while (dataToEnter)
                    {
                        // Process the data.
                        dataToEnter = checkIfUserHasMoreData();
                    }
                }

                Console.WriteLine("** Do");
                {
                    bool dataToEnter = checkIfUserWantsToEnterData();
                    if (dataToEnter)
                    {
                        do // A do loop is very similar to a while loop, with the exception that a do loop will always execute at least once.
                           // Whereas if the condition is not initially met, a while loop will never execute.
                        {
                            // Process the data.
                            dataToEnter = checkIfUserHasMoreData();
                        } while (dataToEnter);
                    }
                }
            }
        }

        #endregion
    }
}
