namespace Jan10th;
public enum Semesters
{
    FirstSem = 1,
    SecondSem = 2

}
public enum Subjects
{
    Physics = 1,
    Python = 2,
    HTML = 3,
    Maths = 4,
    C = 5,

}

public class College
{
    public string[,] details = new string[2,5];

    public void SetDetails()
    {
        int semesterIndex = 0;
        foreach (Semesters semester in Enum.GetValues(typeof(Semesters)))
        {
            int subjectIndex = 0;

            foreach (Subjects subject in Enum.GetValues(typeof(Subjects)))
            {
                details[semesterIndex, subjectIndex] =$"{semester} - {subject}";
                subjectIndex++;
            }
            semesterIndex++;
        }


    }
    //Memeber function to print the details of semesters and subject
    public void GetDetails()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.WriteLine(details[i, j]);
            }
            Console.WriteLine();
        }
    }
}