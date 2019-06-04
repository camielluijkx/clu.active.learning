using System;

namespace clu.active.learning
{
    public static class Properties
    {
        #region Implementation

        public class Coffee
        {
            #region Fields

            private int _strength;

            private string _color;

            private decimal _price;

            public int _size;

            #endregion

            #region Properties

            public int Strength
            {
                get { return _strength; }
                set { _strength = value; }
            }

            // Compiler will implicitly create a private field and map it to your property. These are known as 
            // auto-implemented properties.
            public string Bean { get; private set; }
            public string CountryOfOrigin { get; set; }
            public bool SpecialEdition { private get; set; }

            // This is a read-only property.
            public string Color
            {
                get { return _color; }
                //get; //CS8051: Auto-implemented properties must have get accessors.
            }

            // This is a write-only property.
            public decimal Price
            {
                set { _price = value; }
                //set; //CS8051: Auto-implemented properties must have get accessors.
            }

            // Validation logic.
            public int Size
            {
                get { return _size; }
                set
                {
                    if (value < 1)
                    { _size = 1; }
                    else if (value > 5)
                    { _size = 5; }
                    else
                    { _size = value; }
                }
            }

            // Const property.
            public string Brand
            {
                get
                {
                    return "Nespresso";
                }
            }

            #endregion
        }

        /*
        
        public class DataBinding
        {
            // Create a property that reads and writes to a private field.
            public int Strength { get; set; }

            // Create a property that can be publicly read, but set only by its containing class.
            public int Strength { get; private set; }   
            
            // Create a readonly property where only the constructor can set the value to this property.
            public int Strength { get; }

            // Create a property that writes to a private field.
            public int Strength { private get; set; }
        }

        */

        public class CoffeeMenu
        {
            public string[] beverages;

            // This is the indexer.
            public string this[int index]
            {
                get { return this.beverages[index]; }
                set { this.beverages[index] = value; }
            }

            // Enable client code to determine the size of the collection.
            public int Length
            {
                get { return beverages.Length; }
            }

            public CoffeeMenu()
            {
                beverages = new string[] 
                {
                    "Americano", "Café au Lait", "Café Macchiato", "Cappuccino", "Espresso"
                };
            }
        }

        public class ServiceConfiguration
        {
            public string ApplicationName { get; set; } // property

            public string ApplicationUser { get; set; } // property
        }

        #endregion

        #region Public Methods

        public static void UsingProperties()
        {
            Console.WriteLine("* Using Properties");
            {
                ServiceConfiguration config = new ServiceConfiguration(); // initialize

                Console.WriteLine("** Get");
                {
                    var applicationName = config.ApplicationName; // get property
                }

                Console.WriteLine("** Set");
                {
                    config.ApplicationUser = "clu"; // set property
                }
            }

            Console.WriteLine("** Using Indexers");
            {
                CoffeeMenu coffeeMenu = new CoffeeMenu();
                string firstDrink = coffeeMenu[0];
                Console.WriteLine("First drink: {0}", firstDrink);
                int numberOfChoices = coffeeMenu.Length;
                Console.WriteLine("Number of choices: {0}", numberOfChoices);
                coffeeMenu[0] = "Mexicano";
                Console.WriteLine("Updated drink: {0}", coffeeMenu[0]);
            }
        }

        #endregion
    }
}