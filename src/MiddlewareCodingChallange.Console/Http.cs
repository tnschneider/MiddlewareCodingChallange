using System;
using System.Net.Http;
using System.Threading.Tasks;
using MiddlewareCodingChallange.ConsoleApp.Models;

namespace MiddlewareCodingChallange.ConsoleApp
{
    public static class Http
    {
        public static async Task GetAsync(string url)
        {
            var response = await GetInternalAsync(url);
            await LogServerResponseAsync(response);
            Console.WriteLine($"url: {url}\nresponse: {response.DataString}\n\n");
        }

        private static async Task<ServerResponseLog> GetInternalAsync(string url)
        {
            using var client = new HttpClient();

            var startTime = DateTime.Now;

            var status = Status.Unknown;
            int? statusCode = null;
            string statusString = null;
            string data = null;

            try
            {
                var response = await client.GetAsync(url);

                statusCode = (int)response.StatusCode;
                statusString = response.StatusCode.ToString();
                
                status = statusCode == 200
                    ? Status.Http200Ok
                    : Status.HttpOther; 
                
                data = await response.Content.ReadAsStringAsync();
            }
            catch (Exception) 
            { 
                status = Status.Timeout;
            }

            var endTime = DateTime.Now;

            return new ServerResponseLog
            {
                StartTimeUTC = startTime,
                EndTimeUTC = endTime,
                HTTPStatusCode = statusCode,
                DataString = data,
                Status = status,
                StatusString = statusString
            };
        }

        private static async Task LogServerResponseAsync(ServerResponseLog model)
        {
            using(var context = new ServerResponseDbContext())
            {
                context.ServerResponseLogs.Add(model);

                await context.SaveChangesAsync();
            }
        }
    }
}