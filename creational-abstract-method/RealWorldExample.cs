using System;

namespace creational_abstract_method
{
    public class RealWorldExample
    {
        static void Main(string[] args)
        {
            // The client code works with any concrete factory class.
            ClientMain(new ConcreteFactoryForGiraffe());
            ClientMain(new ConcreteFactoryForSheep());
        }
        
        static void ClientMain(IAbstractFactory abstractFactory)
        {
            var animal = abstractFactory.CreateAnimal();
            var food = abstractFactory.CreateFood();
            animal.SelfIntro();
            animal.MainFood(food);
        }

    }

    // The Abstract Factory interface with methods to return the abstract products in the same family
    public interface IAbstractFactory
    {
        IFood CreateFood();
        IAnimal CreateAnimal();
    }

    // The concrete factory produce a family of products of a single variant
    public class ConcreteFactoryForSheep : IAbstractFactory
    {
        public IFood CreateFood()
        {
            return new Grass();
        }

        public IAnimal CreateAnimal()
        {
            return new Sheep();
        }
    }
    
    // The concrete factory produce a family of products of a single variant
    public class ConcreteFactoryForGiraffe : IAbstractFactory
    {
        public IFood CreateFood()
        {
            return new Leaves();
        }

        public IAnimal CreateAnimal()
        {
            return new Giraffe();
        }
    }
    
    // The abstract product
    public interface IFood
    {
        string FoodName();
    }

    // The concrete product
    public class Grass : IFood
    {
        public string FoodName()
        {
            return "grass";
        }
    }

    // The concrete product
    public class Leaves : IFood
    {
        public string FoodName()
        {
            return "Leaves";
        }
    }

    // The abstract product with a method that interacts with a product of the same family
    public interface IAnimal
    {
        void SelfIntro();
        void MainFood(IFood food);
    }

    // The concrete product
    public class Sheep : IAnimal
    {
        public void SelfIntro()
        {
            Console.WriteLine("I am a sheep.");
        }

        public void MainFood(IFood food)
        {
            Console.WriteLine("My main food is {0}.", food.FoodName());
        }
    }

    // The concrete product
    public class Giraffe : IAnimal
    {
        public void SelfIntro()
        {
            Console.WriteLine("I am a giraffe.");
        }

        public void MainFood(IFood food)
        {
            Console.WriteLine("My main food is {0}.", food.FoodName());
        }
    }
}