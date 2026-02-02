using System.Collections.Generic;
namespace GenericsProblems
{
    public class HighestScorer<T> where T : Student
    {

        public T FindTopper(List<T> students)
        {
            if (students == null || students.Count() == 0) return null;

            T topper = students[0];

            for (int i = 1; i < students.Count; i++)
            {
                if (students[i].TotalMarks > topper.TotalMarks)
                {
                    topper = students[i];
                }
            }
            return topper;
        }

    }
}