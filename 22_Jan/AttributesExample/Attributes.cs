namespace Attributes
{
    public class Calculator
    {
        [Obsolete("Use the Add(int, int) method instead")]
        
        public int OldAdd(int a,int b)
        {
            return a+b;
        }
        public int Add(int a , int b)
        {
            return a+b;
        }
    }
}