using System;

namespace Multicast
{
    // Declare a delegate
    delegate void MyDelegate();

    class SampleClass
    {
        public void MyInstanceMethod()
        {
            Console.WriteLine("Hello from the instance method!");
        }

        public void MySecondInstanceMethod()
        {
            Console.WriteLine("Hello from the second instance method!");
        }

        static public void MyStaticMethod()
        {
            Console.WriteLine("Hello from the static method!");
        }
    }
    
    class Multicast
    {
        static void Main()
        {
            var sc = new SampleClass();

            // Map delegate to the instance method, and invoke it
            MyDelegate d = sc.MyInstanceMethod; d();

            // Next map to the static method, and invoke it
            d = SampleClass.MyStaticMethod; d.Invoke();

            Console.ReadLine();

            // Multicast delegate declaration example

            MyDelegate md1, md2, md3;

            md1 = sc.MyInstanceMethod; md1(); Console.WriteLine();
            md1 += sc.MySecondInstanceMethod; md1(); Console.WriteLine();
            md1 += SampleClass.MyStaticMethod; md1(); Console.WriteLine();
            md1 -= sc.MySecondInstanceMethod; md1(); Console.WriteLine();

            Console.WriteLine();
            md2 = sc.MyInstanceMethod;
            md3 = sc.MySecondInstanceMethod;
            md1 = md2 + md3;
            md1.Invoke();

            Console.WriteLine();
            md1 = sc.MyInstanceMethod;
            md2 = sc.MySecondInstanceMethod;
            md3 = SampleClass.MyStaticMethod;
            md1 += md2;
            md1 += md3;
            md1.Invoke();

            Console.ReadLine();

        }
    }
}