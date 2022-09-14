using System;

namespace factory
{
    class Program
    {
        static void Main(string[] args)
        {
            IVechile vechile = Factory.GetVechile("car");
            vechile.Write();
            vechile = Factory.GetVechile("bike");
            vechile.Write();
        }
    }

    interface IVechile
    {
        void Write();
    }

    class Car : IVechile
    {
        public void Write()
        {
            Console.WriteLine("I am car");
        }
    }

    class Bike : IVechile
    {
        public void Write()
        {
            Console.WriteLine("I am Bike");
        }
    }

    class Factory
    {
        public static IVechile GetVechile(string type)
        {
            IVechile vechile = null;

            if (type == "car")
                vechile = new Car();
            else if (type == "bike")
                vechile = new Bike();

            return vechile;
        }
    }
}
