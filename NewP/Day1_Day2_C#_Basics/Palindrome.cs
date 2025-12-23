using System;
namespace kamaljeet;

class Palindrome
{
    /// <summary>
    /// Palindrome class Method to check whether the number is palindrome or not 
    /// </summary>
    /// <param name="num"> integer input to check it's palindrome or not</param>
    /// <returns></returns>
    public string IsPalindrome(int num)
    {
        int revNum=0;
        int rem=0,temp=num;
        while (num > 0)
        {
            rem = num%10;
            revNum= rem + revNum*10;
            num/=10;

        }
        return (revNum==temp)? "Palindrome":"Not Palindrome"; 
        
    }
}