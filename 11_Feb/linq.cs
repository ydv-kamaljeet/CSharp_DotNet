using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }
}

public class Program
{
    public static void Main()
    {
        var deptStudents = new Dictionary<string, List<Student>>()
        {
            ["IT"] = new List<Student>
            {
                new Student{Id=1, Name="Amit", Marks=80},
                new Student{Id=2, Name="Ravi", Marks=55},
                new Student{Id=3, Name="Kiran", Marks=70}
            },
            ["HR"] = new List<Student>
            {
                new Student{Id=4, Name="Neha", Marks=60},
                new Student{Id=5, Name="Sara", Marks=45}
            },
            ["Sales"] = new List<Student>
            {
                new Student{Id=6, Name="John", Marks=90},
                new Student{Id=7, Name="Pooja", Marks=50}
            }
        };

        // Call your methods here:
        // Example:
        GetAllStudents(deptStudents);
        GetTopStudents(deptStudents);

    }
    public static void GetAllStudents(Dictionary<string, List<Student>> data)
        {
            // LINQ here
            var students = data.Values.SelectMany(x=>x);
            foreach(var stud in students){
                Console.WriteLine(stud.Name);
            }
            Console.WriteLine("-----------------------------------");
        }


    // Write LINQ logic inside these methods ↓↓↓
    static void GetTopStudents(Dictionary<string, List<Student>> data)
    {
        // LINQ here
        var students = data.Values.SelectMany(x=>x).Where(x=>x.Marks>60);
        foreach(var stud in students){
                Console.WriteLine(stud.Name);
            }
    }
    static void StudentWithDept(Dictionary<string, List<Student>> data)
    {
        // LINQ here
       // var students = data.SelectMany(s=>s)
    }


}
