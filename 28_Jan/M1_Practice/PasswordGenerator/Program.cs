using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;

namespace PasswordGeneratorProblem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine() ?? string.Empty;
            int idx = input.IndexOf('@');
            int sum=0;
            string str = input.Substring(0,idx).ToLower();
            foreach( char c in str)
            {
                sum+= (int) c;
            }
            string Password = "TECH_"+sum+input.Substring(input.Length - 2);
            Console.WriteLine($"Password : {Password}");
        }
    }
}