// BL project
namespace  ReverseStringApp.BL;

using ReverseStringApp.DAL;

public class StringService
{
    public StringRepository repo = new();

    public string Reverse(string input)
    {
        var str = repo.GetString(input);
        return new string(str.Reverse().ToArray());
    }
}