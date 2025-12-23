using System;
namespace kamaljeet;

/// <summary>
/// Class 
/// </summary>
class PrimeOrNot
{
    /// <summary>
    /// Method to check whether the number is prime or not
    /// </summary>
    public string CheckPrime()
    {
        string? input = Console.ReadLine();
        if(!int.TryParse(input,out int num))
        {
            return "Enter valid number";    //Handling the invalid inputs (like anything other than integer) 
        }
        string result="Prime";
        for(int i = 2; i <= num / 2; i++)
        {
            if(num%i == 0)
            {
                result="Not Prime";
                break;
            }
        }
        if(num==0 || num==1) result = "Not Prime";

        return result;

    }
}