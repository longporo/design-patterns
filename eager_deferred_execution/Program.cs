using System;
using System.Collections.Generic;
using System.Linq;

namespace eager_deferred_execution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // deferredExecution();
            eagerExecution();
        }

        private static void eagerExecution()
        {
            var numList = new List<int>() {1, 2, 3, 5};
            // query is execute immediately when calling ToList method, the later changes in numList will not affect the result
            var filterList = numList.Where(x => x > 2).ToList();
            numList.Add(9);
            foreach (var num in filterList)
            {
                Console.WriteLine(num);
            }
        }

        private static void deferredExecution()
        {
            var numList = new List<int>() {1, 2, 3, 5};
            // query is written before adding an item to the list, but it was executed when iterating the loop
            var filterList = numList.Where(x => x > 2);
            numList.Add(9);
            foreach (var num in filterList)
            {
                Console.WriteLine(num);
            }
        }
    }
}