using System.Data.Common;
using System.Xml;
using ExamScheduler.Model;
namespace ExamScheduler.Data{

public class DataBank
{
    static DataBank()
    {
        //Creating and Adding students
        students.Add(new Student(){Id=1,Name="Igloo"});
        students.Add(new Student(){Id=2,Name="Aklavya"});
        students.Add(new Student(){Id=3,Name="Ravi"});
        students.Add(new Student(){Id=4,Name="Kamal"});
        students.Add(new Student(){Id=5,Name="Sabya"});
        //creating and adding sessions
        Stdsession.Add(new StudentSession(){Id="2022-2026",Details="CSE" });
        Stdsession.Add(new StudentSession(){Id="2021-2025",Details="Mechanical"});


    }
    public static List<Student> students = new List<Student>();
    public  static List<StudentSession> Stdsession = new List<StudentSession>();

    //Method to get Students Detail
    public List<Student> GetStudents()
    {
        return students;
    }

    //method to get Session Details
    public List<StudentSession> GetSessions()
        {
            return Stdsession;
        }

}

}