using System;
namespace kamaljeet;

class Fabonaccii
{
    /// <summary>
    /// Member function to print fabonacci series upto N length
    /// </summary>
    public void Fabo()
    {
        int num1=0;
        int num2=1;
        int num3=num1+num2;
        string? input = Console.ReadLine();
        if(!int.TryParse(input,out int N))
        {
            Console.WriteLine("Enter valid number.");
            return;
        }
        N-=2;
        Console.WriteLine(num1);
        Console.WriteLine(num2);
        while (N-- != 0)
        {
            Console.WriteLine(num3);
            num1=num2;
            num2=num3;
            num3=num1+num2;
        }

    }
}