using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class StudentService
    {
        public static SortedDictionary<double, List<Student>> ranking =
            new SortedDictionary<double, List<Student>>(Comparer<double>.Create((a, b) => b.CompareTo(a)));

        // To check duplicates quickly
        public static Dictionary<string, Student> studentIndex =
            new Dictionary<string, Student>();
        public void AddStudent()
        {
            Console.Write("Enter Id: ");
            string id = Console.ReadLine();

            if (studentIndex.ContainsKey(id))
                throw new DuplicateStudentException("Student already exists.");

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter GPA: ");
            double gpa = double.Parse(Console.ReadLine());

            ValidateGPA(gpa);

            Student s = new Student(id, name, gpa);
            studentIndex[id] = s;

            if (!ranking.ContainsKey(gpa))
                ranking[gpa] = new List<Student>();

            ranking[gpa].Add(s);

            Console.WriteLine("Student added.");
        }

        public void UpdateGPA()
        {
            Console.Write("Enter Student Id: ");
            string id = Console.ReadLine();

            if (!studentIndex.ContainsKey(id))
                throw new StudentNotFoundException("Student not found.");

            Student s = studentIndex[id];

            Console.Write("Enter new GPA: ");
            double newGpa = double.Parse(Console.ReadLine());

            ValidateGPA(newGpa);

            // Remove from old GPA bucket
            ranking[s.GPA].Remove(s);
            if (ranking[s.GPA].Count == 0)
                ranking.Remove(s.GPA);

            // Update
            s.GPA = newGpa;

            if (!ranking.ContainsKey(newGpa))
                ranking[newGpa] = new List<Student>();

            ranking[newGpa].Add(s);

            Console.WriteLine("GPA updated.");
        }

        public void DisplayRanking()
        {
            Console.WriteLine("\n--- Student Ranking ---");

            foreach (var entry in ranking)
            {
                foreach (var s in entry.Value)
                {
                    Console.WriteLine($"{s.Id} | {s.Name} | GPA: {s.GPA}");
                }
            }
        }

        public void ValidateGPA(double gpa)
        {
            if (gpa < 0 || gpa > 10)
                throw new InvalidGPAException("GPA must be between 0 and 10.");
        }
    }
}
