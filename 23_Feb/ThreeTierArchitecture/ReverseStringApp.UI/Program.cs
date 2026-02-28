// Console App
using ReverseStringApp.BL;

class Program
{
    static void Main()
    {
        var service = new StringService();

        Console.Write("Enter string: ");
        var input = Console.ReadLine() ?? "";

        Console.WriteLine("Reversed: " + service.Reverse(input));
    }
}