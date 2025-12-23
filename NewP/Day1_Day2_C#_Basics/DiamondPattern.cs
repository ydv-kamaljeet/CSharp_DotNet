using System;

class DiamondPattern
{
    /// <summary>
    /// Member function to print the Diamond Pattern using nested loops
    /// </summary>
    public void PrintDiamond()
    {
        int n = 5;

        // Upper half part:
        for (int i = 1; i <= n; i++)
        {
            for (int space = 1; space <= n - i; space++)
            {
                Console.Write(" ");
            }
            for (int star = 1; star <= (2 * i - 1); star++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }

        // Lower half part:
        for (int i = n - 1; i >= 1; i--)
        {
            for (int space = 1; space <= n - i; space++)
            {
                Console.Write(" ");
            }
            for (int star = 1; star <= (2 * i - 1); star++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }
    }
}
