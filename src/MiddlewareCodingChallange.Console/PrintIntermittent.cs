using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiddlewareCodingChallange.ConsoleApp
{
    public static class PrintIntermittent
    {
        public static async Task PrintOn2ThreadsAsync(IEnumerable<long> numbers)
        {
            var threadA = Task.Run(() => PrintAsync(numbers, TimeSpan.FromMilliseconds(500), "t1"));
            var threadB = Task.Run(() => PrintAsync(numbers, TimeSpan.FromMilliseconds(1000), "t2"));

            await Task.WhenAll(threadA, threadB);

            Console.WriteLine();
            Console.WriteLine();
        }

        private static async Task PrintAsync(IEnumerable<long> numbers, TimeSpan delay, string name)
        {
            foreach (var num in numbers)
            {
                await Task.Delay(delay);
                Console.Write($"{name}: {num}; ");
            }
        }
    }
}