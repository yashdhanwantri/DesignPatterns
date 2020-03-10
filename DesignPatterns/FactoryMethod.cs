using System;

namespace DesignPatterns
{
    class Point
    {
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }

        public double x { get; set; }
        public double y { get; set; }
        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }
    class FactoryMethod
    {
        static void Main(string[] args)
        {
            var cartesianPoint = Point.NewCartesianPoint(2,4);
            Console.WriteLine(cartesianPoint);

            var polarPoint = Point.NewPolarPoint(1, Math.PI / 2);
            Console.WriteLine(polarPoint);
        }
    }
}
