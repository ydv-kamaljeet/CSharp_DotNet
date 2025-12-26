
using System.IO.Compression;
using System.Security.Cryptography;

namespace InterfaceLecture;

public class Program
{
    public static void Main(string[] args)
    {
        #region Exam Scheduler
        // HomePage hp = new HomePage(1,"Home Page of Car Rental.");
        // hp.PrintScreen();

        // Exam e1 = new Exam();
        // e1.ExamId=101;
        // e1.ExamName="Dotnet";
        // e1.Sem=1;
       

        // Exam e2 = new Exam();
        // e2.ExamId=102;
        // e2.ExamName="Java";
        // e2.Sem=1;
        

        // Student s1 = new Student();
        // s1.StdId=12214612;
        // s1.StdName="Kamal";
        // s1.Exams[0]=e1;
        // s1.Exams[1]=e2;

        // Student s2 = new Student();
        // s2.StdId=12206381;
        // s2.StdName="sabya";
        // s2.Exams[1]=e2;
        // s2.Exams[1]=e2;

        // e1.Students[0]=s1;
        // e1.Students[1]=s2;
        // e2.Students[0]=s1;
        // e2.Students[1]=s2;

        // Examiner Ex = new Examiner();
        // Ex.EmpId=1000;
        // Ex.EMpName="Rakesh";
        // Ex.ExaminerId=12221;


        // Scheduler sch = new Scheduler();
        // sch.AddStudents(s1);
        // sch.AddStudents(s2);
        // sch.ShowExamTakers();

        #endregion

        IVegEater vs = new Visitor();
        vs.EatVeg();
        vs.Taste();
        

        

    }
}