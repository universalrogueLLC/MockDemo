using MD.Interfaces;
using System;

namespace MD.Implementations.ResultServices
{
    public class ConsoleResultService : IResultService
    {
        public void LogException(string message)
        {
            Console.WriteLine($"EXCEPTION: {message}");
        }

        public void LogResult(string operation, double a, double b, double result)
        {
            Console.WriteLine($"OPERATION: {operation}({a}, {b}), RESULT: {result}");
        }
    }
}
