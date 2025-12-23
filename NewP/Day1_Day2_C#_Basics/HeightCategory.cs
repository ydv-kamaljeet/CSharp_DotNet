using System.IO.Pipelines;
using System;
namespace kamaljeet;

class HeightCategory
{
    /// <summary>
    /// Function to categorize the height of Human
    /// </summary>
    public void CheckCategory()
    {
        Console.Write("Enter Height in CM : ");
        string? input = Console.ReadLine();
        string result=string.Empty;
        if(!int.TryParse(input,out int height))
        {
            Console.WriteLine("Enter Valid Height.");
            return;
        }
        if(height <150) result = "Dwarf";
        else if(height>=150 && height <165 ) result="Average";
        else if(height>=165 && height <190) result="Tall";
        else result = "Abnormal";
        

        Console.WriteLine(result);
    }
}