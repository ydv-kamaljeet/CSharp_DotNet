using System.IO.Pipelines;

namespace XamXpertProblem
{
    public interface IExam
    {
        public double CalculateScore();
        public static string EvaluateResult(double Percentage)
        {
            string result =string.Empty;
            if(Percentage>=85)
                result = "Merit";
            else if(Percentage <85 && Percentage >=60)
                result = "Pass";
            else   
                result = "Fail";
            return result;
        }
    }

    public class OnlineTest : IExam
    {
        public string? StudentName{get;set;}
        public int NumberOfQues{get;set;}
        public int CorrectAnswers{get;set;}
        public int WrongAnswers{get;set;}
        public string QuestionType{get;set;}

        public OnlineTest(string name , int totalQ, int correct , int wrong, string type)
        {
            StudentName = name;
            NumberOfQues =totalQ;
            CorrectAnswers = correct;
            WrongAnswers= wrong;
            QuestionType = type;
        }
        public double CalculateScore()
        {
            int markPerQuestion = 1 ;
            if (QuestionType.Equals("MCQ"))
            {
                markPerQuestion =2 ;
            } else if (QuestionType.Equals("Coding"))
            {
                markPerQuestion = 5;
            }

            double totalScore = (CorrectAnswers * markPerQuestion) - (WrongAnswers*markPerQuestion*0.1 );
            double percentage = (totalScore/(NumberOfQues*markPerQuestion))*100; 
            return percentage;
        }
    }
}