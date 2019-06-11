using System;


namespace clu.active.learning.console
{
    public class Predicate
    {
        public class Point
        {
            public int X { get; set; }
            
            public int Y { get; set; }

            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        private static bool findPoints(Point obj)
        {
            return obj.X * obj.Y > 100000;
        }

        public static void Test()
        {
            // Create an array of Point structures.
            Point[] points = { new Point(100, 200),
                         new Point(150, 250), new Point(250, 375),
                         new Point(275, 395), new Point(295, 450) };

            // Define the Predicate<T> delegate.
            Predicate<Point> predicate = findPoints;

            // Find the first Point structure for which X times Y  
            // is greater than 100000. 
            Point first = Array.Find(points, predicate);

            // Display the first structure found.
            Console.WriteLine("Found: X = {0}, Y = {1}", first.X, first.Y);

            Console.ReadLine();
        }
    }
}