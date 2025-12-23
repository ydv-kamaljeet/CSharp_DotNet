using System;

class PascalsTriangle
{
    //function to print the pascals triangle
    public void PrintTriangle()
    {
        int n = 5;

        int[,] tri = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            // formatting spaces
            for (int sp = 0; sp < n - i - 1; sp++)
            {
                Console.Write(" ");
            }

            for (int j = 0; j <= i; j++)
            {
                if (j == 0 || j == i)
                {
                    tri[i, j] = 1;
                }
                else
                {
                    tri[i, j] = tri[i - 1, j - 1] + tri[i - 1, j];
                }

                Console.Write(tri[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
}
