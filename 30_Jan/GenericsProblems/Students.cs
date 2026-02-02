namespace GenericsProblems
{
    //public delegate void Notify();
    public class Student : IComparable<Student>
    {
        public string? Name{get;set;}
        public int Programming{get;set;}
        public int Sql{get;set;}
        public int Softskill{get;set;}

        public int TotalMarks => Programming + Sql + Softskill;


        public int CompareTo(Student? other)
        {
            return other.TotalMarks.CompareTo(this.TotalMarks);
        }

       // public event  Notify OnNotify;

        public void SendNotification(Student s)
        {
            Action OnNotify;

            if (s.TotalMarks <= 100)
            {
                OnNotify = Fail;
            }
            else if (s.TotalMarks >= 260)
            {
                OnNotify = Merit;
            }
            else
            {
                OnNotify = NeedImprovement;
            }
            OnNotify?.Invoke();
            Predicate<Student> CheckFail  = IsFailed;
            Func<string> failureReport = failMessage; 
            if(CheckFail.Invoke(s))
                Console.WriteLine(failureReport.Invoke());

        }
        public static bool IsFailed (Student s){
            return s.Programming < 35 || s.Sql < 35 || s.Softskill < 35;
        }
        public static void Fail()
        {
            Console.WriteLine($" You failed in the  exams");
        }
        public static void NeedImprovement()
        {
            Console.WriteLine($" You need to improve and work hard.");
        }
        public static void Merit()
        {
            Console.WriteLine($" Good, You are in the merit list");
        }
        public static string failMessage()
        {
            return "You failed in your exam , you need to improve yourself.";
        }
        
    }

}
//action predicate function