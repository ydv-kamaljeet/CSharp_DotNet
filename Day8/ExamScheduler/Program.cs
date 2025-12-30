using ExamScheduler.Model;
using ExamScheduler.Data;
namespace ExamScheduler;

public class Program
{
    public static void Main(string[] args)
    {
        DataBank db = new DataBank();
        var localStudents = db.GetStudents();
        var batch = db.GetSessions();

        foreach(Student std in localStudents)
        {
            Console.WriteLine($"Name = {std.Name} and Id = {std.Id}");
        }

        Console.WriteLine("\n############################################\n");
        
        foreach(StudentSession s in batch)
        {
            Console.WriteLine($"Id = {s.Id} and Details = {s.Details}");
        }
    }
}