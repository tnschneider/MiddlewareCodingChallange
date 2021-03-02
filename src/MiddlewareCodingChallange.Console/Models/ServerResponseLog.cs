using System;

namespace MiddlewareCodingChallange.ConsoleApp.Models
{
    public class ServerResponseLog
    {
        public int pk { get; set; }
        public DateTime StartTimeUTC { get; set; }
        public DateTime EndTimeUTC { get; set; }
        public int? HTTPStatusCode { get; set; }
        public string DataString { get; set; }
        public Status Status { get; set; }
        public string StatusString { get; set; }
    }

    public enum Status 
    {
        Unknown = 0,
        Http200Ok = 1,
        HttpOther = 2,
        Timeout = -999
    }
}