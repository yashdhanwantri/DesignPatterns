using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class Coordinate
    {
        private double x;
        private double y;
        private Coordinate(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
        public static class Factory
        {
            public static Coordinate NewCartesianPoint(double x, double y)
            {
                return new Coordinate(x, y);
            }
            public static Coordinate NewPolarPoint(double rho, double theta)
            {
                return new Coordinate(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
    }
    class InnerFactoryClass
    {
        public static void Main(string[] args)
        {
            var result = Coordinate.Factory.NewCartesianPoint(1, 2);
            Console.WriteLine(result);
        }
    }
}
