// using System;
// using System.Collections.Generic;
// using System.Linq;

// class Student
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
//     public int Marks { get; set; }
//     public string Department { get; set; }
// }

// class Employee
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
//     public double Salary { get; set; }
//     public string Department { get; set; }
// }

// class Program
// {
//     static void Main()
//     {
//         List<Student> students = new()
//         {
//             new Student{Id=1, Name="Amit", Marks=80, Department="CS"},
//             new Student{Id=2, Name="Sara", Marks=45, Department="IT"},
//             new Student{Id=3, Name="John", Marks=60, Department="CS"},
//             new Student{Id=4, Name="Neha", Marks=90, Department="IT"},
//             new Student{Id=5, Name="Raj", Marks=30, Department="EC"}
//         };

//         List<Employee> employees = new()
//         {
//             new Employee{Id=1, Name="Ravi", Salary=50000, Department="HR"},
//             new Employee{Id=2, Name="Simran", Salary=70000, Department="IT"},
//             new Employee{Id=3, Name="Karan", Salary=45000, Department="HR"},
//             new Employee{Id=4, Name="Pooja", Salary=80000, Department="IT"}
//         };

//         Dictionary<int, Student> studentDict =
//             students.ToDictionary(s => s.Id);

//         Dictionary<int, List<Student>> groupedStudents = new()
//         {
//             {1, students.Where(s=>s.Department=="CS").ToList()},
//             {2, students.Where(s=>s.Department=="IT").ToList()},
//             {3, students.Where(s=>s.Department=="EC").ToList()}
//         };

//         SortedDictionary<int, Employee> sortedEmp =
//             new SortedDictionary<int, Employee>(
//                 employees.ToDictionary(e => e.Id)
//             );
// //=============================================== Topper from each group ====================================================

//     //     Dictionary<string, List<Student>> grStudents =
//     //     students.GroupBy(s => s.Department)
//     //         .ToDictionary(g => g.Key, g => g.ToList());


//     //     var toppers = grStudents
//     //             .Select(g => new
//     //             {
//     //                 Department = g.Key,
//     //                 Topper = g.Value.MaxBy(s => s.Marks),
//     //                 AvgMarks = g.Value.Average(s => s.Marks)
//     //             });
       
//     //    foreach (var g in toppers)
//     //     {
//     //         Console.WriteLine(
//     //             $"{g.Department} Topper: {g.Topper.Name}, Marks: {g.Topper.Marks}, Avg: {g.AvgMarks:F2}"
//     //         );
//     //     }


//     // ---------------------------------ANOTHER APPROACH _ USING DICT OF STUDENT ________

// //     var toppers = groupedStudents.Select(kvp => new 
// // {
// //     DepartmentId = kvp.Key,
// //     // We look into the List<Student> for each dictionary entry
// //     Topper = kvp.Value.OrderByDescending(s => s.Grade).FirstOrDefault()
// // });

// // foreach (var item in toppers)
// // {
// //     if (item.Topper != null)
// //     {
// //         Console.WriteLine($"Dept ID: {item.DepartmentId} | Topper: {item.Topper.Name} | Grade: {item.Topper.Grade}");
// //     }
// // }

// //======================================================= END ==============================================================
        
// //=============================== Average Salary per Department ============================================================
// //             var groupedEmp = employees.GroupBy(e=>e.Department);
// //             var result = groupedEmp.Select(
// //                 g=>new
// //                 {
// //                     Dept = g.Key,
// //                     Avg = g.Average(e=>e.Salary)
// //                 }
// //             );
// //             foreach(var x in result) { Console.WriteLine($"{x.Dept}: {x.Avg:C}"); }

// //     
// //==========================================END===========================================================================

// //////////

// //===========================================GROUP +

//         string[] arr = new string[] {"Hello","hello","World","My"," "};

//         var res = arr
//             .Where(s => !string.IsNullOrWhiteSpace(s)) // remove empty/whitespace
//             .Distinct(StringComparer.OrdinalIgnoreCase)
//             .Count();

//         Console.WriteLine(res);
//         Console.WriteLine(String.Equals("Hello","hello", StringComparison.OrdinalIgnoreCase));

     
//     }
// }
