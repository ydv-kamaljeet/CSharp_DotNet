using System;
class Program
{
    /// <summary>
    /// sample program
    /// </summary>

    public static void EvenOrOdd(string[] args)
    {
        Console.WriteLine("Enter the number to find even or odd (Q to exit)");
        string? choice = Console.ReadLine();
        int Number =0;
        string output = string.Empty;
        bool checkResult = false;

        #region 
        while(choice != "Q" && choice != "q"){
            Number = int.TryParse(choice, out Number) ? Number : 0;
            checkResult = isEven(Number);
            output= checkResult ? "Even" : "Odd";
            Console.WriteLine(output);
            Console.WriteLine("Enter the number to find even or odd (Q to exit)");
            choice = Console.ReadLine();
        }
        #endregion
    }
    
 
    /// <summary>
    /// check given number is even or odd
    /// </summary>
    /// <param name="num">Input to check even or odd</param>
    /// <returns></returns>
    public static bool isEven(int num)
    {
        return num%2==0;
    }
}