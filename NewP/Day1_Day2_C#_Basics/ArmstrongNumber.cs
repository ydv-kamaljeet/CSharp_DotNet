using System;

namespace kamaljeet;
/// <summary>
/// Class
/// </summary>
class ArmstrongNumber
{
/// <summary>
/// member function to check whether the number is armstrong or not
/// </summary>
    public void IsArmstrong()
    {
        #region   Declaration
        Console.WriteLine("Enter the number : ");
        string? input = Console.ReadLine();
        int power = input != null? input.Length : 0;
        int.TryParse(input,out int num);

        int temp=num,rem=0;
        int res=0;
        #endregion
        #region Checking the number is Armstrong? 
        while (num > 0)
        {
            rem= num%10;
            res+=(int)Math.Pow(rem,power);
        }
        string result = (res==temp)?"Armstrong Number ":"Not an Armstrong Number";
        Console.WriteLine(result);
        #endregion
    }
}
