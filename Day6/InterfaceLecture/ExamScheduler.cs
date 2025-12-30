using System;
using System.Collections.Generic;

namespace InterfaceLecture
{
    class Student
    {
        public int Id;
        public string Name;
        public List<Exam> Exams = new List<Exam>();

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    class Examiner
    {
        public int Id;
        public string Name;

        public Examiner(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    class Exam
    {
        public string Subject;
        public DateTime ExamDate;
        public Examiner Examiner;
        public List<Student> Students = new List<Student>();

        public void AssignStudent(Student student)
        {
            Students.Add(student);
            student.Exams.Add(this);
        }
    }

    class Semester
    {
        public int Number;
        public List<Exam> Exams = new List<Exam>();
    }

    class HOD
    {
        public Exam ScheduleExam(
            Semester sem,
            string subject,
            DateTime date,
            Examiner examiner)
        {
            Exam exam = new Exam
            {
                Subject = subject,
                ExamDate = date,
                Examiner = examiner
            };

            sem.Exams.Add(exam);
            return exam;
        }
    }

    class ExamScheduler
    {
        public void Execute()
        {
            HOD hod = new HOD();

            Semester sem1 = new Semester { Number = 1 };

            Examiner ex1 = new Examiner(1, "Dr. Sharma");

            Student s1 = new Student(101, "Amit");
            Student s2 = new Student(102, "Riya");
            Student s3 = new Student(103, "Neha");

            Exam math = hod.ScheduleExam(
                sem1,
                "Mathematics",
                new DateTime(2025, 3, 10),
                ex1);

            Exam physics = hod.ScheduleExam(
                sem1,
                "Physics",
                new DateTime(2025, 3, 12),
                ex1);

            math.AssignStudent(s1);
            math.AssignStudent(s2);

            physics.AssignStudent(s1); // same student, multiple exams
            physics.AssignStudent(s3);

            PrintSemester(sem1);
            //PrintStudent(s1);
        }

        static void PrintSemester(Semester sem)
        {
            Console.WriteLine($"Semester {sem.Number}");

            foreach (var exam in sem.Exams)
            {
                Console.WriteLine($" Subject   : {exam.Subject}");
                Console.WriteLine($" Date      : {exam.ExamDate:dd-MM-yyyy}");
                Console.WriteLine($" Examiner  : {exam.Examiner.Name}");
                Console.WriteLine(" Students  :");

                foreach (var s in exam.Students)
                {
                    Console.WriteLine($"  - {s.Name}");
                }

                Console.WriteLine();
            }
        }

        static void PrintStudent(Student student)
        {
            Console.WriteLine($"Student : {student.Name}");
            Console.WriteLine(" Exams  :");

            foreach (var exam in student.Exams)
            {
                Console.WriteLine($"  - {exam.Subject}");
            }

            Console.WriteLine();
        }
    }
}
