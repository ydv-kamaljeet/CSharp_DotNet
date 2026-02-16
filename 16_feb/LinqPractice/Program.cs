using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }
    public string Department { get; set; }
}

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
    public string Department { get; set; }
}

class Program
{
    static void Main()
    {
        List<Student> students = new()
        {
            new Student{Id=1, Name="Amit", Marks=80, Department="CS"},
            new Student{Id=2, Name="Sara", Marks=45, Department="IT"},
            new Student{Id=3, Name="John", Marks=60, Department="CS"},
            new Student{Id=4, Name="Neha", Marks=90, Department="IT"},
            new Student{Id=5, Name="Raj", Marks=30, Department="EC"}
        };

        List<Employee> employees = new()
        {
            new Employee{Id=1, Name="Ravi", Salary=50000, Department="HR"},
            new Employee{Id=2, Name="Simran", Salary=70000, Department="IT"},
            new Employee{Id=3, Name="Karan", Salary=45000, Department="HR"},
            new Employee{Id=4, Name="Pooja", Salary=80000, Department="IT"}
        };

        Dictionary<int, Student> studentDict =
            students.ToDictionary(s => s.Id);

        Dictionary<int, List<Student>> groupedStudents = new()
        {
            {1, students.Where(s=>s.Department=="CS").ToList()},
            {2, students.Where(s=>s.Department=="IT").ToList()},
            {3, students.Where(s=>s.Department=="EC").ToList()}
        };

        SortedDictionary<int, Employee> sortedEmp =
            new SortedDictionary<int, Employee>(
                employees.ToDictionary(e => e.Id)
            );


        // Write your LINQ query in:
       
        var emp = sortedEmp.Select(e=>e.Value.Name).ToList();


        foreach(var e in emp)
        {
            Console.WriteLine(e);
        }

        //Console.WriteLine(emp);

    }

}
