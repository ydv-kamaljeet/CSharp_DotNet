namespace Attributes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Calculator c = new Calculator();
            string str = Console.ReadLine();
            Console.WriteLine(str);
            int res = c.OldAdd(2,5);
            Console.WriteLine($"Sum  : {res}");

        }
    }
}