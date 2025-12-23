using System;
namespace kamaljeet;
class GCD
{
    /// <summary>
    /// Member function to calculate GCD
    /// </summary>
    /// <param name="a">Number 1</param>
    /// <param name="b">Number 2</param>
    /// <returns></returns>
    public  int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int r = a % b;
            a = b;
            b = r;
        }
        return a;
    }
/// <summary>
/// Member function to calculate LCM of 2 numbers
/// </summary>
/// <param name="a">Number 1</param>
/// <param name="b">Number 2</param>
/// <returns></returns>
    public  int LCM(int a, int b)
    {
        return a / Gcd(a, b) * b;
    }
}