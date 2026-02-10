using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        
        Console.WriteLine($"Main start time: {DateTime.Now} ");

        var t1 = AWorkAsync("Task1");
        var t2 = BWorkAsync("Task2");
        await Task.WhenAll(t1, t2);

        Console.WriteLine($"Main End time: {DateTime.Now}");
    }

    static async Task AWorkAsync(string name)
    {
        Console.WriteLine($"A End time: {DateTime.Now}");
        await Task.Delay(2000);                 
        Console.WriteLine($"A End time: {DateTime.Now}");
    }

    static async Task BWorkAsync(string name)
    {
        Console.WriteLine($"B End time: {DateTime.Now}");
        await Task.Delay(6000);     
        Console.WriteLine($"B End time: {DateTime.Now}");
    }
}
