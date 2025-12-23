using System;
using System.IO.Pipelines;
using System.Runtime.ConstrainedExecution;

namespace kamaljeet;
class LeapYear
{
    /// <summary>
    /// Member function to check whether the given year is leap year or not
    /// </summary>
    public void IsLeapYear()
    {
        Console.Write("Enter the Year you want to check: ");
        string? input = Console.ReadLine();
        if(!int.TryParse(input, out int year))
        {
            Console.WriteLine("Enter valid year");
            return;
        }
        string result;
        if((year%400 == 0 ) || (year%4==0 && year%100!=0))  result = "Leap Year";
        else result = "Not a Leap Year";

        Console.WriteLine(result);

    }
}