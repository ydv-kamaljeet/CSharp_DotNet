using System.ComponentModel;

namespace Test1;

public class Source
{
    public void Add(int a , int b, int c)
    {
        Console.WriteLine("Adding integer : " +  a+b+c);
    }

    public void Add(double a , double b, double c)
    {
        Console.WriteLine($"Adding integer : {a+b+c}");
    }
}