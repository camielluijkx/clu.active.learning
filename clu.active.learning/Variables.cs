using System;

namespace clu.active.learning
{
    public static class Variables
    {
        #region Public Methods

        public static void DeclareVariables()
        {
            Console.WriteLine("* Declaring Variables");

            {
                int price; // unassigned
            }

            {
                int price = 5;
                int tax = 10;
            }

            {
                int price, tax; // unassigned
            }

            {
                int price = 5, tax = 10;
                Console.WriteLine($"price: {price}, tax: {tax}");
            }

            {
                Console.WriteLine("** Implicity Types Variables");
                var price = 5; // implicty typed integer
                int tax = 10; // explicitly typed integer
            }

            {
                Console.WriteLine("** Object Variables");
                ServiceConfiguration config = new ServiceConfiguration(); // initialize
            }
        }

        #endregion
    }
}
