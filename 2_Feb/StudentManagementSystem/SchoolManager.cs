namespace StudentManagementSystem
{
    public class SchoolManager
    {
        private int IdCounter = 1;
        public void AddStudent(string name, string gradeLevel)
        {
            Student stud = new Student
            {
                Id = IdCounter++,
                Name = name,
                GradeLevel = gradeLevel
            };

            Program.students.Add(stud);

        }

        public void AddGrade(int studentId, string subject, double grade)
        {
            if (grade < 0 && grade > 100)
            {
                Console.WriteLine("Invalid Grades");
                return;
            }

            foreach (var student in students)
            {
                if (student.Id == studentId)
                {
                    student.Subjects.Add(subject, grade);
                }
            }
        }

        public SortedDictionary<string, List<Student>> GroupStudentsByGradeLevel()
        {
            SortedDictionary<string, List<Student>> classes = new SortedDictionary<string, List<Student>>();

            foreach (var student in students)
            {
                if (!classes.ContainsKey(student.GradeLevel))
                {
                    classes[student.GradeLevel] = new List<Student>();
                }
                classes[student.GradeLevel].Add(student);
            }

            return classes;
        }


        public double CalculateStudentAverage(int studentId)
        {
            double result = -1;
            foreach (var student in students)
            {
                if (student.Id == studentId)
                {
                    double total = 0;
                    int count = student.Subjects.Count;
                    foreach (var subject in student.Subjects)
                    {
                        total += subject.Value;
                    }
                    result = total / (double)count;
                }

            }
            return result;
        }


        public Dictionary<string, double> CalculateSubjectAverages()
        {
            Dictionary<string, double> subjectAvg = new Dictionary<string, double>();

        }


        public Dictionary<string, List<Student>> groupStudentBySubject()
        {
            Dictionary<string, List<Student>> subjectGroup = new Dictionary<string, double>();
            foreach (var student in students)
            {
                foreach (var sub in student.Subjects)
                {
                    if (!subjectGroup.ContainsKey(sub.Key))
                    {
                        subjectGroup[sub.Key] = new List<Student>();
                    }
                    subjectGroup[sub.Key].Add();
                }

            }
        }
    }
}