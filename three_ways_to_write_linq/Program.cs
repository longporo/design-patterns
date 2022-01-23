using System;
using System.Collections.Generic;
using System.Linq;

namespace three_ways_write_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numList = new List<int>(){1, 2, 3, 5, 6};

            // Way 01: Query syntax
            var querySyntax = from obj in numList 
                where obj %2 == 0 
                select obj;
            
            // Way 02: Method syntax
            var methodSyntax = numList.Where(x => x % 2 == 0);
            
            // Way 03: Aggregate query
            var aggregateSyntax = numList.Where(x => x % 2 == 0).Sum();
        }
    }
}