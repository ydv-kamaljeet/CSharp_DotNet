using System;
namespace Emp;

public class Program
{
    public static void Main(string[] args)
    {
        UsEmployee ue = new UsEmployee();
        Console.WriteLine(ue.CalcTax(450000));

        IndianEmployee ind = new IndianEmployee();
        Console.WriteLine(ind.CalcTax(450000));
    }
}