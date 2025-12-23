using System;
namespace kamaljeet;

public class SumOfDigits
{
    /// <summary>
    /// Member function to calculate sum of digit of number until we get single digit number
    /// </summary>
    /// <param name="n">Number</param>
    /// <returns></returns>
    public int DigitalRoot(int n)
    {
        while (n >= 10) // more than one digit
        {
            int sum = 0;

            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }

            n = sum;
        }

        return n;
    }
}