using System;

namespace clu.active.learning
{
    /*
     
    A class is a programming construct that can be used to define custom types.

    Classes can be used to create new types, which are effectively creating a blueprint for the instance.

    The class defines the behaviors and characteristics, or class members, which exists in all instances of the class.

    Behaviors and characteristics are defined by methods, fields, properties and events within the class.
    
    */
    public static class Classes
    {
        public class OutOfBeansEventArgs : EventArgs
        {
            public DateTime TimeReached { get; set; }
        }

        public delegate void OutOfBeansEventHandler(object sender, OutOfBeansEventArgs e);

        // Declaring a Class.
        public class DrinksMachine // public, internal (default), private
        {
            // Methods, fields, properties and events go here.

            // The following statements define a property with a private field.
            private int _age;
            public int Age
            {
                get
                {
                    return _age;
                }
                set
                {
                    if (value > 0)
                    {
                        _age = value;
                    }
                }
            }

            // The following statements define properties.
            public string Make;
            public string Model;

            // The following statements define methods.
            public void MakeCappucino()
            {
                // Method logic goes here.
            }
            public void MakeEspresso()
            {
                // Method logic goes here.
            }

            // The following statement defines an event. 
            public event OutOfBeansEventHandler OutOfBeans;

            public DrinksMachine()
            {
                // This is a default constructor (it has no parameters).
                // Empty public default constructor is automatically added by the Visual C# compiler 
                // if not included in class.
                this.Age = 0;
            }

            // Adding some constructors.
            public DrinksMachine(int age)
            {
                this.Age = age;
            }
            public DrinksMachine(string make, string model)
            {
                this.Make = make;
                this.Model = model;
            }
            public DrinksMachine(int age, string make, string model)
            {
                this.Age = age;
                this.Make = make;
                this.Model = model;
            }
        }

        /*
         
        Creating Static Classes and Members

        Create a class purely to encapsulate some useful functionality, rather than to represent 
        an instance of anything.   

        Use a static class when it would not make sense to instantiate a class in order to use 
        methods or properties, to store or retrieve any instance-specific data.

        A static class cannot be instantiated.

        */
        public static class Conversions
        {
            public static double PoundsToKilos(double pounds)
            {
                // Convert argument from pounds to kilograms
                double kilos = pounds * 0.4536;
                return kilos;
            }
            public static double KilosToPounds(double kilos)
            {
                // Convert argument from kilograms to pounds
                double pounds = kilos * 2.205;
                return pounds;
            }
        }

        /* 
         
        Static Members

        Non-static classes can include static members. This is useful when some behaviors and 
        characteristics relate to the instance (instance members), while some behaviors and 
        characteristics relate to the type itself (static members). Methods, fields, properties, 
        and events can all be declared static. Static properties are often used to return data 
        that is common to all instances, or to keep track of how many instances of a class have 
        been created. Static methods are often used to provide utilities that relate to the type 
        in some way, such as comparison functions.
         
        */
        public class AnotherDrinksMachine
        {
            public static int CountDifferentDrinks()
            {
                // Add method logic here.
                return 2;
            }
        }

        public static void UsingClasses()
        {
            Console.WriteLine("* Using Classes");
            {
                Console.WriteLine("** Instantiating a Class");
                {
                    /* 
                
                    Instantiating a Class:

                        • A new object in memory is created based on the type DrinksMachine.
                        • An object reference name drinksMachine is created that refers to the new DrinksMachine object.

                    */
                    DrinksMachine drinksMachine = new DrinksMachine();
                }

                Console.WriteLine("** Instantiating a Class by Using Type Inference");
                {
                    /*
                     
                    Type Inference:

                    Allow the Visual C# compiler to deduce the type of the object at compile time.

                    In some circumstances, type inference can make code easier to read,
                    while in other circumstances it may make code more confusing.

                    As a general rule, consider using type inference when the type of variable
                    is absolutely clear. It also clearly helps when applying TDD!

                    */
                    var drinksMachine = new DrinksMachine();
                }

                Console.WriteLine("** Using Object Members");
                {
                    /*
                     
                     Calling members on an instance variable is known as dot notation.

                     */ 
                    var drinksMachine = new DrinksMachine();
                    drinksMachine.Make = "Fourht Coffee";
                    drinksMachine.Model = "Beancrusher 3000";
                    drinksMachine.Age = 2;
                    drinksMachine.MakeEspresso();
                }

                Console.WriteLine("** Using Constructors");
                {
                    var drinksMachine1 = new DrinksMachine(2);
                    var drinksMachine2 = new DrinksMachine("Fourth Coffee", "BeanCrusher 3000");
                    var drinksMachine3 = new DrinksMachine(3, "Fouth Coffee", "BeanToaser Turbo");
                }

                Console.WriteLine("** Calling Methods on a Static Class");
                {
                    double weightInKilos = 80;
                    double weightInPounds = Conversions.KilosToPounds(weightInKilos);
                }

                Console.WriteLine("** Access Static Members");
                {
                    int drinksMachineCount = AnotherDrinksMachine.CountDifferentDrinks();
                }
            }
        }
    }
}
