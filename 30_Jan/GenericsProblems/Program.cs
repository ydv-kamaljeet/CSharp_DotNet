using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
namespace GenericsProblems
{
    public delegate void FailMessageNotify(string studentName);

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            Console.Write("Enter number of students: ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nEnter details for student {i + 1}:");

                Console.Write("Name: ");
                string? name = Console.ReadLine();

                Console.Write("Programming marks: ");
                int prog = int.Parse(Console.ReadLine());

                Console.Write("SQL marks: ");
                int sql = int.Parse(Console.ReadLine());

                Console.Write("SoftSkill marks: ");
                int soft = int.Parse(Console.ReadLine());

                students.Add(new Student
                {
                    Name = name,
                    Programming = prog,
                    Sql = sql,
                    Softskill = soft
                });
            }

            HighestScorer<Student> scorer = new HighestScorer<Student>();
            Student topper = scorer.FindTopper(students);

            Console.WriteLine("\n--- Topper ---");
            Console.WriteLine($"Topper Name : {topper.Name} | Total Marks : {topper.TotalMarks}");

            FailMessageNotify Notify = PrintFailMessage;    //assing the function to delegate
            Notify += PrintSuggestion;
            Console.WriteLine("\n--- Result ---");

            foreach (var student in students)
            {
                if (student.IsFailed)
                {
                    Notify?.Invoke(student.Name); //  callback
                }
            }
            
        }

        public static void PrintFailMessage(string name)
        {
            Console.WriteLine($"{name} failed in his exams");
        }
        public static void PrintSuggestion(string name)
        {
            Console.WriteLine($"{name}, you need to improve and work hard.");
        }
    }
}