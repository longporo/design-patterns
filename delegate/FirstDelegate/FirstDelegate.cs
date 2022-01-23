using System;

namespace FirstDelegate
{
    class FirstDelegate
    {
         // Declare Delegates
        public delegate void MyDelegate (string text);
        public delegate int MyOtherDelegate (int x, int y);

        static void Main(string[] args)
        {
            // Instantiate delegate d1
             MyDelegate d1 = new MyDelegate (MyStringOne);

            // Invoke delegate
            d1 ("Hello from Delegate!");

            // New reference (re-instantiation)
            d1 = new MyDelegate(MyStringTwo);

            // Invoke delegate again (using .Invoke()this time)
            d1.Invoke("Hello (again) from Delegate!");

            Console.ReadLine();

            // Instantiate and invoke delegate d12
             MyOtherDelegate d2 = new MyOtherDelegate (Sum);
             int res = d2 (2,4);
             Console.WriteLine ("D2 (Sum): {0}!",res);

             // And do it again
            d2 = new MyOtherDelegate(Product);
            res = d2.Invoke (2,4);
            Console.WriteLine ("D2 (Product): {0}!",res);

            Console.ReadLine();

            // Could also just instantiate this way
            MyOtherDelegate d3 = Sum;
            d3 = Product;

            // And using Anonymous method
            MyDelegate d4 = delegate (string text) {
                Console.WriteLine ($"Anonymous Method: {text}");
            };
            d4 ("Hello from Delegate D4!");
            d4 = MyStringOne;
            d4 ("Hello (again) from Delegate D4!");

            Console.ReadLine();

            // Finaly using a Lambda expression
            MyDelegate d5 = text => { Console.WriteLine ($"Anonymous Method (Lambda): {text}"); };
            d5.Invoke("Hello again!");

            Console.ReadLine();

        }

        //
        // Functions (static) used in delegates example
        //

        static void MyStringOne  (string s)   {
            Console.WriteLine("StringOne: "+s);
        }

        static void MyStringTwo  (string s)   {
            Console.WriteLine("StringTwo: "+s);
        }

        static int Sum (int x, int y)

        {
            return x + y;
        }

        static int Product (int x, int y)

        {
            return x * y;
        }
    }
}