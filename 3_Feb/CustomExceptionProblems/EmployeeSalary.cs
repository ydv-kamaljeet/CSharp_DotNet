//This code is similar to Employee salary Problem.

namespace CustomException
{
    public class DivideByZero
    {
        public void Divide()
        {
            int[] arr = {1000,8,0,1200};
            int number = 60000;

            foreach(var element in arr)
            {
                try
                {
                    Console.WriteLine(number/element);
                }catch(DivideByZeroException e)
                {
                    Console.WriteLine("You cannt divide the number by zero.");
                }
            }
        }
    }
}