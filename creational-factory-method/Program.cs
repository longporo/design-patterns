using System;

namespace creational_factory_method
{
    class Program
    {
        static void Main(string[] args)
        {
            // The Factory Method design pattern defines an interface for creating an object,
            // but let subclasses decide which class to instantiate.
            AnimalCreator[] acArr = new AnimalCreator [2];
            acArr[0] = new CatCreator();
            acArr[1] = new DogCreator();
            foreach (var creator in acArr)
            {
                Animal animal = creator.FactoryMethod();
                Console.WriteLine("Animal: {0}", animal.GetType().Name);
            }
        }
    }

    abstract class Animal
    {
        public abstract string Sound();
    }

    class Dog : Animal
    {
        public override string Sound()
        {
            return "Woof";
        }
    }

    class Cat : Animal
    {
        public override string Sound()
        {
            return "Meow";
        }
    }

    abstract class AnimalCreator
    {
        public abstract Animal FactoryMethod();
    }

    class DogCreator : AnimalCreator
    {
        public override Animal FactoryMethod()
        {
            return new Dog();
        }
    }

    class CatCreator : AnimalCreator
    {
        public override Animal FactoryMethod()
        {
            return new Cat();
        }
    }
}