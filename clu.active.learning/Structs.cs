using System;

namespace clu.active.learning
{
    /*
     
    A struct is a programming construct that you can use to define custom types. 

    Structs are essentially lightweight data structures that represent related pieces of 
    information as a single item. 
    
    For example:
        • A struct named Point might consist of fields to represent an x-coordinate and a 
          y-coordinate.
        • A struct named Circle might consist of fields to represent an x-coordinate, a 
          y-coordinate, and a radius.
        • A struct named Color might consist of fields to represent a red component, a green 
          component, and a blue component.
       
    Most of the built-in types, such as int, bool, and char, are defined by structs. 
    
    You can use structs to create your own types that behave like built-in types.
     
    */
    public static class Structs
    {
        #region Implementation

        // Declaring a Struct.
        public struct Coffee // public, internal (default), private
        {
            // This is the custom constructor.
            public Coffee(int strength, string bean, string countryOfOrigin)
            {
                this.Strength = strength;
                this.Bean = bean;
                this.CountryOfOrigin = countryOfOrigin;
            }

            // These statements declare the struct fields and set the default values.
            public int Strength;
            public string Bean;
            public string CountryOfOrigin;

            // Other methods, fields, properties, and events.
        }

        #endregion

        #region Public Methods

        public static void UsingStructs()
        {
            Console.WriteLine("* Using Structs");
            {
                Console.WriteLine("Instantiating a Struct");
                {
                    Coffee coffee1 = new Coffee();
                    coffee1.Strength = 3;
                    coffee1.Bean = "Arabica";
                    coffee1.CountryOfOrigin = "Kenya";
                }

                Console.WriteLine("Initializing Structs");
                {
                    // Call the custom constructor by providing arguments for the three required 
                    // parameters.
                    Coffee coffee1 = new Coffee(4, "Arabica", "Columbia");
                    Coffee coffee2 = new Coffee(); // struct always has a default constructor
                }
            }
        }

        #endregion
    }
}
