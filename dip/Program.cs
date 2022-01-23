using System;

namespace dip
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dependency Inversion Principle (DIP)
            // High-level classes should not depend on the concrete implementation of low-level,
            // instead, it should depend upon abstraction of low-level classes.
            Console.WriteLine("Hello World!");
        }
    }

    // The high-level class SoundSpeaker has depended the concrete implementation
    // of low-level classes(Dog, Cat), which against DIP.
    class SoundSpeaker
    {
        public void MakeDogSound(Dog dog)
        {
            var sound = dog.Sound();
            // code to play by sound
        }
        
        public void MakeCatSound(Cat cat)
        {
            var sound = cat.Sound();
            // code to play by sound
        }
        
    }

    class Dog
    {
        public string Sound()
        {
            return "Woof";
        }
    }

    class Cat
    {
        public string Sound()
        {
            return "Meow";
        }
    }
    
    // Now the high-level class SoundSpeaker_In_DIP just depends the abstraction of the low-level classes,
    // Any change in the low-level classes will not affect the high-level class SoundSpeaker_In_DIP.
    // So that this case is in DIP now.
    class SoundSpeaker_In_DIP
    {
        public void MakeDogSound(Animal_In_DIP animal)
        {
            var sound = animal.Sound();
            // code to play by sound
        }
        
    }

    abstract class Animal_In_DIP
    {
        public abstract string Sound();
    }
    
    class Dog_In_DIP : Animal_In_DIP
    {
        public override string Sound()
        {
            return "Woof";
        }
    }

    class Cat_In_DIP : Animal_In_DIP
    {
        public override string Sound()
        {
            return "Meow";
        }
    }
}