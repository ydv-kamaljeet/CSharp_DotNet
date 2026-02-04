namespace StudentManagementSystem
{
    public class Student
    {
        public int Id{get;set;}
        public string? Name{get;set;}
        public string? GradeLevel{get;set;}
        public Dictionary<string, double> Subjects;
    }
}