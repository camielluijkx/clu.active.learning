using System;

namespace clu.active.learning.console
{
    public static class ExplicitImplicitOperator
    {
        public struct Point2d
        {
            public double X { get; set; }

            public double Y { get; set; }

            public Point2d(double x, double y)
                : this()
            {

            }
        }

        public struct Point3d
        {
            public static explicit operator Point2d(Point3d value)
            {
                return new Point2d(value.X, value.Y);
            }

            public static implicit operator Point3d(Point2d value)
            {
                return new Point3d(value.X, value.Y, 0d);
            }

            public double X { get; set; }

            public double Y { get; set; }

            public double Z { get; set; }

            public Point3d(double x, double y, double z)
                : this()
            {

            }
        }

        public static void Test()
        {
            //Point3d p1 = new Point2d(11d, 13d) as Point3d;
            Point3d p2 = new Point2d(3d, 2d);
            Point3d p3 = (Point3d)new Point2d(3d, 5d);
            //Point2d p4 = new Point3d(1d, 1d, 1d) as Point2d;
            Point2d p5 = (Point2d)new Point3d(1d, 2d, 3d);
            //Point2d p6 = new Point3d(5d, 3d, 1d);

            Console.ReadLine();
        }
    }
}