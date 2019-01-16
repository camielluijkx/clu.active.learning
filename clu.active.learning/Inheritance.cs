using System;

namespace clu.active.learning
{
    /*
     
    In Visual C#, a class can inherit from another class. When you create a class that inherits from 
    another class, your class is known as the derived class and the class that you inherit from is 
    known as the base class. The derived class inherits all the members of the base class, including 
    constructors, methods, properties, fields, and events. 

    Access Modifier     Details 
    public              The member is available to code running in any assembly.
    protected           The member is available only within the containing class or in classes derived 
                        from the containing class. 
    internal            The member is available only to code within the current assembly.
    protected internal  The member is available to any code within the current assembly, and to types 
                        derived from the containing class in any assembly. 
    private             The member is available only within the containing class.
    private protected   The member is available to types derived from the containing class, but only 
                        within its containing assembly. (Only available since Visual C# 7.2) 

    Members of a class are private by default. Private members are not inherited by derived classes. 
    If you want members that would otherwise be private to be accessible to derived classes, you must 
    prefix the member with the protected keyword. 

    */
    public static class Inheritance
    {
        public class Beverage
        {
            protected int servingTemperature;

            public string Name { get; set; }
            public bool IsFairTrade { get; set; }

            public int GetServingTemperature()
            {
                return servingTemperature;
            }
        }

        // In object-oriented programming, the terms derives and inherits are used interchangeably. 
        // Saying that the Coffee class derives from the Beverage class means the same as saying the 
        // Coffee class inherits from the Beverage class. 
        public class Coffee : Beverage
        {
            public string Bean { get; set; }
            public string Roast { get; set; }
            public string CountryOfOrigin { get; set; }
        }

        // Abstract and Non-Abstract Members.
        abstract class AbstractBeverage
        {
            // Non-abstract members.
            // Derived classes can use these members without modifying them.
            public string Name { get; set; }
            public bool IsFairTrade { get; set; }

            // Abstract members.
            // Derived classes must override and implement these members.
            public abstract int GetServingTemperature();
        }
        class InheritFromAbstractBeverage : AbstractBeverage
        {
            public override int GetServingTemperature()
            {
                throw new NotImplementedException();
            }
        }

        // Sealed classes.
        sealed class SealedBeverage
        {

        }
        //class InheritFromSealedBeverage : SealedBeverage //CS0509: 'Inheritance.InheritFromSealedBeverage': 
        // cannot derive from sealed type 'Inheritance.SealedBeverage'

        // Virtual Members.
        public class BeverageWithVirtualMember
        {
            protected int servingTemperature;
            public string Name { get; set; }
            public bool IsFairTrade { get; set; }
            public virtual int GetServingTemperature()
            {
                // This is the default implementation of the GetServingTemperature method.
                // Because the method is declared virtual, you can override the implementation in derived classes.
                return servingTemperature;
            }
        }

        // Overriding Base Class Members.
        public class CoffeeWithOverrideMember : BeverageWithVirtualMember
        {
            protected bool includesMilk;
            private int servingTempWithMilk;
            private int servingTempWithoutMilk;
            public override int GetServingTemperature()
            {
                if (includesMilk) return servingTempWithMilk;
                else return servingTempWithoutMilk;
            }
        }
        public class CoffeeWithNewImplementation : BeverageWithVirtualMember
        {
            public new int GetServingTemperature()
            {
                throw new NotImplementedException();
            }
        }

        // Sealing an Overridden Member.
        public class CoffeeWithSealedOverrideMember : BeverageWithVirtualMember
        {
            sealed public override int GetServingTemperature()
            {
                // Derived classes cannot override this method.
                throw new NotImplementedException();
            }
        }

        // Calling Base Class Constructors.
        public class BeverageWithBaseClassConstructor
        {
            public BeverageWithBaseClassConstructor()
            {
                // Implementation details not shown.
            }
            public BeverageWithBaseClassConstructor(string name, bool isFairTrade, int servingTemp)
            {
                // Implementation details are not shown.
            }

            // Other class members are not shown.
        }
        public class CoffeeCallingBaseClassConstructor : BeverageWithBaseClassConstructor
        {
            public CoffeeCallingBaseClassConstructor()
                //: base()
            {
                // This constructor implicitly calls the default Beverage constructor.
                // You can include additional code here.
            }
            public CoffeeCallingBaseClassConstructor(string name, bool isFairTrade, int servingTemp, string bean, string roast)
               : base(name, isFairTrade, servingTemp)
            {
                // This calls the Beverage(string, bool, int) constructor.
                // You can include additional code here:
                Bean = bean;
                Roast = roast;
            }
            public string Bean { get; set; }
            public string Roast { get; set; }
            public string CountryOfOrigin { get; set; }
        }

        // Calling Base Class Methods.
        public class BeverageWithBaseClassMethod
        {
            protected int servingTemperature;
            public virtual int GetServingTemperature()
            {
                return servingTemperature;
            }

            // Constructors and additional class members are not shown.
        }
        public class CoffeeCallingBaseClassMethod : BeverageWithBaseClassMethod
        {
            bool iced = false;
            protected int servingTempIced = 40;
            public override int GetServingTemperature()
            {
                if (iced)
                {
                    return servingTempIced;
                }
                else
                {
                    return base.GetServingTemperature();
                }
            }
        }

        #region Public Methods

        public static void UsingInheritance()
        {
            Console.WriteLine("* Using Inheritance");
            {
                Console.WriteLine("** Calling Base Class Members");
                {
                    Coffee coffee1 = new Coffee();

                    // Use base class members.
                    coffee1.Name = "Fourth Espresso";
                    coffee1.IsFairTrade = true;
                    int servingTemp = coffee1.GetServingTemperature();

                    // Use derived class members.
                    coffee1.Bean = "Arabica";
                    coffee1.Roast = "Dark";
                    coffee1.CountryOfOrigin = "Columbia";
                }

                /*
                 
                Override can be used for both virtual and abstract members. 
                The difference is that overriding virtual members is optional, while overriding 
                abstract members is mandatory. Only an abstract class must implement every abstract 
                member defined by its ancestors. 

                */
                Console.WriteLine("** Abstract vs Virtual");
                {
                    // TODO: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract
                    // TODO: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/virtual
                }

                Console.WriteLine("** Override vs New");
                {
                    // TODO: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords
                }
            }

            #endregion
        }
    }
}