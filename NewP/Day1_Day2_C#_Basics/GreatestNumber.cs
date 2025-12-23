using System;
namespace kamaljeet;

class GreatestNumber
{
    /// <summary>
    /// Method to check the greatest number between 3 numbers
    /// </summary>
    public void WhoIsGreatest()
    {
        
        int num1,num2,num3,gtnum=0;
        string? input1 = Console.ReadLine();
        string? input2 = Console.ReadLine();
        string? input3 = Console.ReadLine();
        int.TryParse(input1,out num1);
        int.TryParse(input2,out num2);
        int.TryParse(input3,out num3);

        if (num1 > num2)
        {
            if(num1>num3) gtnum=num1; 
        }else if(num2 > num3) gtnum = num2;
        else gtnum = num3;
        
        Console.WriteLine("Greatest number is "+ gtnum);
    }
}