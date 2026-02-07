using System;
namespace LogAnalyzer
{
    class Program
    {
        static void Main()
        {
            string filePath = "sample.log";
            int topN = 5;

            var analyzer = new LogAnalyze();
            var results = analyzer.GetTopErrors(filePath, topN);

            Console.WriteLine("Top Errors:\n");

            foreach (var error in results)
            {
                Console.WriteLine($"{error.ErrorCode} -> {error.Count}");
            }

            Console.WriteLine("\nDone.");
        }
    }

}