using System;

namespace Generics
{
    delegate T addition<T>(T p1, T p2); // this generic delegate
    
    class Generics
    {
        static void Main(string[] args)
        {
            // declare delegate sum
            addition<int> sum = Sum;
            Console.WriteLine(sum(100, 100));

            // declare delegate concat
            addition<string> concat = Concat;
            Console.WriteLine(concat("Hello", "World!"));

            Console.ReadLine();
        }

        // support mmethods
        static int Sum(int p1, int p2)
        {
            return p1 + p2;
        }

        static string Concat(string s1, string s2)
        {
            return s1 + " " + s2;
        }
    }
}