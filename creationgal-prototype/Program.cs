using System;

namespace creationgal_prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    /// <summary>
    /// The SingletonPrototype abstract class
    /// </summary>
    public abstract class SingletonPrototype
    {
        public abstract SingletonPrototype Clone();
    }

    /// <summary>
    /// The ConcretePrototype class 
    /// </summary>
    public class ConcretePrototype : SingletonPrototype
    {
        // the thread safe singleton
        private static readonly ConcretePrototype _instance = new ConcretePrototype();

        private ConcretePrototype()
        {
        }

        public static ConcretePrototype GetInstance => _instance;
        
        // return a shallow copy
        public override SingletonPrototype Clone()
        {
            return (SingletonPrototype) this.MemberwiseClone();
        }
    }
}