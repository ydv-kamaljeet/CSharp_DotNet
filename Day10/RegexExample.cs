using System.Text.RegularExpressions;
namespace Day10;

public class RegexExample
{
    public void Implement()
    {
        string input = "Error: TIMEOUt while calling API";
        string pattern = @"timeout";

        var rx = new Regex(
            pattern,
            RegexOptions.IgnoreCase,
            TimeSpan.FromMilliseconds(150) // match timeout
        );

        Console.WriteLine(rx.IsMatch(input) ? "Found" : "Not Found");
    }
}