namespace InterfaceLecture;

public class Student
{
    public int StdId{get;set;}
    public string StdName{get;set;}

    public List<Exam> Exams{get;set;}

}

public class Semester
{
    public int Sem{get;set;}
    
}
public class Exam : Semester
{
    public int ExamId{get;set;}
    public string ExamName{get;set;}

    public List<Student> Students{get;set;}
}

#region Employee
public class Employee
{
    public int EmpId{get;set;}
    public string EMpName{get;set;}
}
public class HOD : Employee
{
    public string department{get;set;}
}

public class Examiner : Employee
{
    public int ExaminerId{get;set;}
}
#endregion

public class Scheduler
{
    public int ExamId{get;set;}
    public int ExaminerId{get;set;}
    public List<Student> ExamTaker{get;set;}

    public void AddStudents(Student student)
    {
        ExamTaker.Add(student);
    }
    public void ShowExamTakers()
    {
        Console.WriteLine(ExamTaker);
    }
}