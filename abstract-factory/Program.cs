using System;

namespace abstract_factory
{
    class Program
    {
        static void Main(string[] args)
        {
            IAnimal animal = null;
            AnimalFactory animalFactory = null;

            animalFactory = AnimalFactory.CreateAnimalFactory("water");
            Console.WriteLine("Animal Factory type : " + animalFactory.GetType().Name);
            Console.WriteLine();

            animal = animalFactory.GetAnimal("octopus");
            Console.WriteLine(animal.GetType().Name + " Speak : " + animal.speak());
            Console.WriteLine();

            animalFactory = AnimalFactory.CreateAnimalFactory("land");
            Console.WriteLine("Animal Factory type : " + animalFactory.GetType().Name);
            Console.WriteLine();

            animal = animalFactory.GetAnimal("cat");
            Console.WriteLine(animal.GetType().Name + " Speak : " + animal.speak());
            Console.WriteLine();
        }
    }

    interface IAnimal
    {
        string speak();
    }

    class Cat : IAnimal
    {
        public string speak()
        {
            return "Meow Meow";
        }
    }

    class Octopus : IAnimal
    {
        public string speak()
        {
            return "SQUAWCK SQUAWCK";
        }
    }

    abstract class AnimalFactory
    {
        public abstract IAnimal GetAnimal(string AnimalType);

        public static AnimalFactory CreateAnimalFactory(string FactoryType)
        {
            if (FactoryType.Equals("water"))
                return new WaterAnimalsFactory();
            else
                return new LandAnimalsFactory();
        }
    }

    class LandAnimalsFactory : AnimalFactory
    {
        public override IAnimal GetAnimal(string AnimalType)
        {
            if (AnimalType == "cat")
            {
                return new Cat();
            }

            return null;
        }
    }

    class WaterAnimalsFactory : AnimalFactory
    {
        public override IAnimal GetAnimal(string AnimalType)
        {
            if (AnimalType == "octopus")
            {
                return new Octopus();
            }

            return null;
        }
    }
}
