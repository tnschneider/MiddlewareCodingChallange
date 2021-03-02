using System.Threading.Tasks;

namespace MiddlewareCodingChallange.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SumEvens.CalculateAndPrint(new long[] { 1, 3, 4, 8, 9, 16, 21 });

            await PrintIntermittent.PrintOn2ThreadsAsync(new long[] { 1, 2, 3, 4, 5 });
    
            //should return 200
            await Http.GetAsync("http://localhost:5000/time");

            //should return 500
            await Http.GetAsync("http://localhost:5000/time?throw500=true");
            
            //should timeout
            await Http.GetAsync("http://10.255.255.1");
        }
    }
}
