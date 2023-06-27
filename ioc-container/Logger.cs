using System;

namespace ioc_container
{
    public class Logger : ILogger
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine($"Message from Logger Class: {message}");
        }
    }
}