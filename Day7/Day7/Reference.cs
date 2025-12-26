namespace Day7;


public class Operations
{
    /// <summary>
    /// Member function to demonstrate the implementation of passing the value by reference so that actual value change.
    /// </summary>
    /// <param name="num1">Number 1</param>
    /// <param name="num2">Number 2</param>
    public void Addition(ref int num1,ref int num2)     //DrawBack : We must assign the value to variables whose reference we are passing(i.e input1,input2)
    {
        Console.WriteLine($"After Adding these 2 numbers passed by reference, we got - {num1+num2}");
        num1++;
        num2++;
    }
    public void Add(int num1,int num2)
    {
        //It will check the values and if it overflows it throws error instead of doing Round Robin.
        //Round robin will happen only in runtime, if user enter the overflowed value in input , it will simply throw error even without using checked keyword.
        checked{
            Console.WriteLine($"After Adding these 2 numbers passed by value, we got - {num1+num2}");
            num1++;
            num2++;
        }
    }
    public int MultiMath(int n , out int SqrVal , out int halfVal, out int addBy3)
    {
        SqrVal= n*n;
        halfVal=n/2;
        addBy3=n+3;
        return n;

    }
}