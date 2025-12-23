using System;
namespace kamaljeet;

public class BinaryToInteger
{
    /// <summary>
    /// Member function to convert the binary string to integer 
    /// </summary>
    /// <param name="binary">string of a binary number</param>
    /// <returns></returns>
    public int ConvertBinaryToDecimal(string binary)
    {
        int decimalValue = 0;
        int power = 1;   // similar to 2^0

        for (int i = binary.Length - 1; i >= 0; i--)
        {
            if (binary[i] == '1')
            {
                decimalValue += power;
            }

            power = power * 2;
        }

        return decimalValue;
    }
}