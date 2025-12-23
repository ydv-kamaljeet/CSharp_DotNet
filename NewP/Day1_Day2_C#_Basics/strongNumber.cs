using System;
namespace kamaljeet;

class StrongNumber
{
    
    public void isStrong(int num)
    {
        //copying the number to compare with result later 
        int temp=num,result=0;
        while (num > 0)
        {
            result+=(Factorial(num%10));
            num/=10;
        }
        string FinalResult=(temp==result)?"Strong Number":"Not a Strong Number";
        Console.WriteLine(FinalResult);
    }
    public int Factorial(int num)
    {
        int res=1;
        if(num==0 || num==1) return 1;

        for(int i = num; i >= 2; i--)
        {
            res*=i;
        }  
        return res;      
    }
}