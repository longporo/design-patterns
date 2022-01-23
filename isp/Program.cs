using System;

namespace isp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Interface Segregation Principle (ISP)
            // The clients should not implement the interfaces that they do not use,
            // it should be better to divide one fat interfaces into several small interfaces.
            Console.WriteLine("Hello World!");
        }
    }
    
    // The IAbility represents the abilities of an animal, the dog itself can not fly,
    // but the Dog class is enforced to implement such an unused method, this violates the ISP.
    interface IAbility
    {
        void Walk();
        
        void Fly();
    }

    class Bird : IAbility
    {
        public void Walk()
        {
            // code to walk
        }

        public void Fly()
        {
            // code to fly
        }
    }
    
    class Dog : IAbility
    {
        public void Walk()
        {
            // code to walk
        }

        public void Fly()
        {
            throw new Exception("Dog can not fly!");
        }
    }
    
    // The IAbility is divided into two interfaces instead of one,
    // now the Dog class only need to implement the IWalkAbility_In_ISP interface,
    // it does not have to implement the fly method, this means it is in ISP
    interface IWalkAbility_In_ISP
    {
        void Walk();
    }
    interface IFlyAbility_In_ISP
    {
        void Fly();
    }

    class Bird_In_ISP : IWalkAbility_In_ISP, IFlyAbility_In_ISP
    {
        public void Walk()
        {
            // code to walk
        }

        public void Fly()
        {
            // code to fly
        }
    }
    
    class Dog_In_ISP : IWalkAbility_In_ISP
    {
        public void Walk()
        {
            // code to walk
        }
    }
}