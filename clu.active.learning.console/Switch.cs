using System;

namespace clu.active.learning.console
{
    public class Switch
    {
        public abstract class Shape
        {
            public abstract double Area { get; }

            public abstract double Circumference { get; }
        }

        public class Rectangle : Shape
        {
            public Rectangle(double length, double width)
            {
                Length = length;
                Width = width;
            }

            public double Length { get; set; }

            public double Width { get; set; }

            public override double Area
            {
                get { return Math.Round(Length * Width, 2); }
            }

            public override double Circumference
            {
                get { return (Length + Width) * 2; }
            }
        }

        public class Square : Rectangle
        {
            public Square(double side)
                : base(side, side)
            {
                Side = side;
            }

            public double Side { get; set; }
        }

        private static void showShapeInfo(Object obj)
        {
            switch (obj)
            {
                case Shape shape when shape.Area == 0:
                    Console.WriteLine($"The shape: {shape.GetType().Name} with no dimensions");
                    break;
                case Square sq when sq.Area > 0:
                    Console.WriteLine("Information about the square:");
                    Console.WriteLine($"   Length of a side: {sq.Side}");
                    Console.WriteLine($"   Area: {sq.Area}");
                    break;
                case Rectangle r when r.Area > 0:
                    Console.WriteLine("Information about the rectangle:");
                    Console.WriteLine($"   Dimensions: {r.Length} x {r.Width}");
                    Console.WriteLine($"   Area: {r.Area}");
                    break;
                case Shape shape:
                    Console.WriteLine($"A {shape.GetType().Name} shape");
                    break;
                case null:
                    Console.WriteLine($"The {nameof(obj)} variable is uninitialized.");
                    break;
                default:
                    Console.WriteLine($"The {nameof(obj)} variable does not represent a Shape.");
                    break;
            }
        }

        public static void Test()
        {
            int i = -2;

            switch (i)
            {
                case 2:
                    Console.WriteLine("variable is >= 2");
                    goto case 1;
                case 1:
                    Console.WriteLine("variable is >= 1");
                    break;
                case 0:
                case -1:
                    Console.WriteLine("variable is <= 0");
                    break;
                case -2:
                    goto MinusTwo;
                default: break;
            }

        MinusTwo:
            Console.WriteLine("variable is -2");

            Shape sh = null;
            Shape[] shapes = { new Square(10), new Rectangle(5, 7),
                         new Rectangle(10, 10), sh, new Square(0) };
            foreach (var shape in shapes)
                showShapeInfo(shape);
        }
    }
}