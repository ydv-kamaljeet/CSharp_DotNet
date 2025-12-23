using  System;
using System.Reflection.Metadata;
namespace kamaljeet;

class ContinueUsage
{
    //Simple function to demonstrate the usage of Continue
    public void UseContinue(){
        for(int i = 1; i <= 30; i++)
        {
            if(i%3==0) continue;
            Console.WriteLine(i);
        }
    }
}