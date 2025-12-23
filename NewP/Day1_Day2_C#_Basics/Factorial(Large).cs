using System;
using System.Numerics;

class LargeFactorial
{
    /// <summary>
    /// Memeber function to find the factorial of number and prevent the integer overflow
    /// </summary>
    public void FindFactorial()
    {
        int n = 34;
        BigInteger factorial = 1;

        for (int i = 1; i <= n; i++)
        {
            factorial = factorial * i;
        }

        Console.WriteLine($"{n}! = {factorial}");
    }
}
