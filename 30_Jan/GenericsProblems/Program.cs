using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
namespace GenericsProblems
{
    
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

               
            students.Sort();
            Console.WriteLine("\n--- Result ---");
            int Rank=1;
            foreach (var student in students)
            {
                Console.WriteLine($"{Rank++}  - {student.Name} ");
                student.SendNotification(student);
                Console.WriteLine();
            }
            
        }

        
    }
}