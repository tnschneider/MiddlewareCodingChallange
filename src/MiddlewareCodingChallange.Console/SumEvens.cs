using System;
using System.Collections.Generic;
using System.Linq;

namespace MiddlewareCodingChallange.ConsoleApp
{
    public static class SumEvens
    {
        public static void CalculateAndPrint(IEnumerable<long> numbers)
        {
            Console.WriteLine(Calculate(numbers));
            Console.WriteLine();
        }

        public static long Calculate(IEnumerable<long> numbers)
        {
            return numbers.Where(x => x % 2 == 0).Sum();
        }
    }
}