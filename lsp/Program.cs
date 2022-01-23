using System;

namespace lsp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Liskov Substitution Principle (LSP)
            // Replace a parent class with a child class without breaking the behavior of the parent class
        }
    }
    
    // If we run the code: 'Dog dog = new Cat(); dog.Sound();', the Sound method return a Meow which is not supposed to be the sound of dog,
    // In this way, it violate the LSP.
    class Dog
    {
        public virtual string Sound()
        {
            return "Woof";
        }
    }
    
    class Cat : Dog
    {
        public override string Sound()
        {
            return "Meow";
        }
    }
    
    // The Animal_In_LSP class is used as a parent class for Dog and Cat,
    // it now can be replaced with its child classes,
    // and behave correctly, which means the case is in LSP.
    abstract class Animal_In_LSP
    {
        public abstract string Sound();
    }
    
    class Dog_In_LSP : Animal_In_LSP
    {
        public override string Sound()
        {
            return "Woof";
        }
    }
    
    class Cat_In_LSP : Animal_In_LSP
    {
        public override string Sound()
        {
            return "Meow";
        }
    }
    
}