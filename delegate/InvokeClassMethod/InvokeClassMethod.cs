using System;

namespace InvokeClassMethod
{
    // Declare a delegate
    delegate void MyDelegate();

    class SampleClass
    {
        public void MyInstanceMethod()
        {
            Console.WriteLine("Hello from the instance method!");
        }

        static public void MyStaticMethod()
        {
            Console.WriteLine("Hello from the static method!");
        }
    }

    class InvokeClassMethod
    {
        static void Main()
        {
            var sc = new SampleClass();

            // Map delegate to the instance method, and invoke it
            MyDelegate d = sc.MyInstanceMethod; d();

            // Next map to the static method, and invoke it
            d = SampleClass.MyStaticMethod; d.Invoke();

            Console.ReadLine();
        }
    }
}