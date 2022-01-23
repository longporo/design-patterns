using System;

namespace ocp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Open/Closed Principle (OCP)
            // software entities (classes, modules, functions, etc.) should be open for extension,
            // but closed for modification
            Console.WriteLine("Hello World!");
        }
    }

    // In this case, it is not opened for extension, if there is another type of animal, the parameter of GetSound method no longer applies,
    // and it is needed to modify the GetSound method, in another word, it is not closed for modification as well.
    class Dog
    {
    }

    class AnimalSoundExtractor
    {
        // Get the dog sound
        string GetSound(Dog dog)
        {
            return "Woof";
        }
    }
    
    // The abstract class Animal_In_OCP is used for extension, each concrete class must extend it.
    // The parameter of GetSound method is changed to the abstract class, and the sound is in the corresponding concrete class,
    // if there is a new type of animal, the AnimalSoundExtractor will no longer need to be modified.
    // In this case, it is opened for extension and closed for modification.
    
    abstract class Animal_In_OCP
    {
       public abstract string Sound();
    }

    class Dog_In_OCP : Animal_In_OCP
    {
        public override string Sound()
        {
            return "Woof";
        }
    }
    class Cat_In_OCP : Animal_In_OCP
    {
        public override string Sound()
        {
            return "Meow";
        }
    }
    
    class AnimalSoundExtractor_In_OCP
    {
        // Get animal sound
        string GetSound(Animal_In_OCP animal)
        {
            return animal.Sound();
        }
    }
}