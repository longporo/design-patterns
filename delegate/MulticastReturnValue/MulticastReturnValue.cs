using System;

namespace MulticastReturnValue
{
    // Declare a delegate
    delegate int MyDelegate();
    
    class MulticastReturnValue
    {            
        static void Main()
        {
            // If a delegate returns a value, then the last assigned target method’s value will be return when a multicast delegate called
            MyDelegate d1 = MyClassA.MethodA;
            MyDelegate d2 = MyClassB.MethodB;

            MyDelegate d = d1 + d2;
            Console.WriteLine(d());
            d = d2 + d1;
            Console.WriteLine(d());
        }
    }

    class MyClassA
    {
        public static int MethodA()
        {
            return 0;
        }
    }

    class MyClassB
    {
        public static int MethodB()
        {
            return 1;
        }
    }
}