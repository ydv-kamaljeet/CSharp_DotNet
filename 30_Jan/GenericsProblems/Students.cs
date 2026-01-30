namespace GenericsProblems
{
    public class Student
    {
        public string? Name{get;set;}
        public int Programming{get;set;}
        public int Sql{get;set;}
        public int Softskill{get;set;}

        public int TotalMarks => Programming + Sql + Softskill;
        public bool IsFailed => Programming < 35 || Sql < 35 || Softskill < 35;

//Constructor
        // public Student(string name,int programming,int sql , int ss)
        // {
        //     Name = name;
        //     ProgrammingMarks = programming;
        //     SqlMarks = sql;
        //     Softskill = ss;
        // }
    }

}