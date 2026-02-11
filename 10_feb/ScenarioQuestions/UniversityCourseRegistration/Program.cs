using System;
using System.Collections.Generic;
using System.Linq;
namespace UniversityCourseRegistration{



// 4. TEST SCENARIO
class Program
{
    static void Main()
    {
        var enrollment = new EnrollmentSystem<EngineeringStudent, LabCourse>();
        var gradebook = new GradeBook<EngineeringStudent, LabCourse>(enrollment);

        // Students
        var s1 = new EngineeringStudent { StudentId = 1, Name = "Aman", Semester = 2 };
        var s2 = new EngineeringStudent { StudentId = 2, Name = "Neha", Semester = 4 };
        var s3 = new EngineeringStudent { StudentId = 3, Name = "Ravi", Semester = 5 };

        // Courses
        var c1 = new LabCourse
        {
            CourseCode = "PHY101",
            Title = "Physics Lab",
            MaxCapacity = 2,
            Credits = 3,
            RequiredSemester = 2
        };

        var c2 = new LabCourse
        {
            CourseCode = "ADV500",
            Title = "Advanced Robotics Lab",
            MaxCapacity = 2,
            Credits = 4,
            RequiredSemester = 4
        };

        Console.WriteLine("\n--- Enrollment Tests ---");

        enrollment.EnrollStudent(s1, c1); // success
        enrollment.EnrollStudent(s2, c1); // success
        enrollment.EnrollStudent(s3, c1); // fail capacity
        enrollment.EnrollStudent(s1, c2); // fail prerequisite
        enrollment.EnrollStudent(s3, c2); // success

        Console.WriteLine("\n--- Workload ---");
        Console.WriteLine($"{s3.Name} credits: {enrollment.CalculateStudentWorkload(s3)}");

        Console.WriteLine("\n--- Grades ---");

        gradebook.AddGrade(s1, c1, 85);
        gradebook.AddGrade(s2, c1, 92);
        gradebook.AddGrade(s3, c2, 88);

        Console.WriteLine($"{s1.Name} GPA: {gradebook.CalculateGPA(s1)}");
        Console.WriteLine($"{s2.Name} GPA: {gradebook.CalculateGPA(s2)}");
        Console.WriteLine($"{s3.Name} GPA: {gradebook.CalculateGPA(s3)}");

        var top = gradebook.GetTopStudent(c1);
        if (top != null)
            Console.WriteLine($"Top in {c1.Title}: {top.Value.student.Name} ({top.Value.grade})");
    }
}

}