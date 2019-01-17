using System;

namespace clu.active.learning
{
    public static class Variables
    {
        #region Implementation

        public class ServiceConfiguration
        {

        }

        #endregion

        #region Public Methods

        public static void UsingVariables()
        {
            Console.WriteLine("* Using Variables");
            {
                Console.WriteLine("** Assigning Variables");
                {
                    int price; // unassigned
                }
                {
                    int price, tax; // unassigned
                }

                Console.WriteLine("** Declaring Variables");
                {
                    int price = 5;
                    int tax = 10;
                }
                {
                    int price = 5, tax = 10;
                }

                Console.WriteLine("** Implicity Types Variables");
                {
                    var price = 5; // implicty typed integer
                    int tax = 10; // explicitly typed integer
                }

                Console.WriteLine("** Object Variables");
                {
                    ServiceConfiguration config = new ServiceConfiguration();  // initialize
                }
            }
        }

        #endregion
    }
}
