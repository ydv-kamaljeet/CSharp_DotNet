using System;
using Services;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentService service = new StudentService();

            while (true)
        {
            Console.WriteLine("\n1 → Display Ranking");
            Console.WriteLine("2 → Update GPA");
            Console.WriteLine("3 → Add Student");
            Console.WriteLine("4 → Exit");

            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1:
                        service.DisplayRanking();
                        break;

                    case 2:
                        service.UpdateGPA();
                        break;

                    case 3:
                        service.AddStudent();
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        }
    }
}
