using System;

namespace DelegateDemo
{
   // public delegate void Notify();
    // ================= STUDENT CLASS =================
    class Student
    {
        public string? Name;
        public int Programming;
        public int Sql;
        public int SoftSkill;

        public int Total()
        {
            return Programming + Sql + SoftSkill;
        }
    }

    // ================= MAIN PROGRAM =================
    class Program
    {
        static void Main()
        {

            if(false){
            Student student = new Student();

            Console.Write("Enter Name: ");
            student.Name = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Programming Marks: ");
            student.Programming = int.Parse(Console.ReadLine()) ;

            Console.Write("Enter SQL Marks: ");
            student.Sql = int.Parse(Console.ReadLine()) ;

            Console.Write("Enter SoftSkill Marks: ");
            student.SoftSkill = int.Parse(Console.ReadLine());

            // -------- ACTION --------
            Action<string> failAction = PrintFailMessage;

            // -------- FUNC --------
            Func<int, int, int, int> totalFunc = CalculateTotal;

            // -------- PREDICATE --------
            Predicate<Student> failCheck = IsFailed;

            int totalMarks = totalFunc.Invoke(
                student.Programming,
                student.Sql,
                student.SoftSkill
            );

            Console.WriteLine("\nTotal Marks: " + totalMarks);

            if (failCheck.Invoke(student))
            {
                failAction?.Invoke(student.Name);
            }
            else
            {
                Console.WriteLine(student.Name + " PASSED the Exam.");
            }
            }


            //Notification system:
            Execution ex = new Execution();
            ex.Execute();
        }

        // ================= METHODS =================

        static void PrintFailMessage(string name)
        {
            Console.WriteLine("❌ Student " + name + " has FAILED");
        }

        static int CalculateTotal(int p, int s, int soft)
        {
            return p + s + soft;
        }

        static bool IsFailed(Student s)
        {
            return s.Programming < 35 ||
                   s.Sql < 35 ||
                   s.SoftSkill < 35;
        }
    }
}
