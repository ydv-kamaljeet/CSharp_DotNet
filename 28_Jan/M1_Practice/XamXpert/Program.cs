namespace XamXpertProblem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IExam ot = new OnlineTest("Kamal",10,9,2,"MCQ");
            double perct =  ot.CalculateScore();
            Console.WriteLine(IExam.EvaluateResult(perct));
            //Console.WriteLine(ot.StudentName);
        }
    }
}