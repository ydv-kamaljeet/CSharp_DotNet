namespace UniversityCourseRegistration
{
    public class EngineeringStudent : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Semester { get; set; }
        public string Specialization { get; set; }
    }

    public class LabCourse : ICourse
    {
        public string CourseCode { get; set; }
        public string Title { get; set; }
        public int MaxCapacity { get; set; }
        public int Credits { get; set; }
        public string LabEquipment { get; set; }
        public int RequiredSemester { get; set; }
    }
    public class EnrollmentSystem<TStudent, TCourse>
        where TStudent : IStudent
        where TCourse : ICourse
    {
        private readonly Dictionary<TCourse, List<TStudent>> _enrollments = new();

        public bool EnrollStudent(TStudent student, TCourse course)
        {
            if (!_enrollments.ContainsKey(course))
                _enrollments[course] = new List<TStudent>();

            var students = _enrollments[course];

            // Capacity check
            if (students.Count >= course.MaxCapacity)
            {
                Console.WriteLine($"Enroll failed: {course.Title} full.");
                return false;
            }

            // Duplicate check
            if (students.Any(s => s.StudentId == student.StudentId))
            {
                Console.WriteLine($"Enroll failed: {student.Name} already enrolled.");
                return false;
            }

            // Prerequisite check (only if LabCourse)
            if (course is LabCourse lab &&
                student.Semester < lab.RequiredSemester)
            {
                Console.WriteLine(
                    $"Enroll failed: {student.Name} semester too low for {course.Title}.");
                return false;
            }

            students.Add(student);
            Console.WriteLine($"Enroll success: {student.Name} -> {course.Title}");
            return true;
        }

        public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
        {
            return _enrollments.ContainsKey(course)
                ? _enrollments[course].AsReadOnly()
                : new List<TStudent>().AsReadOnly();
        }

        public IEnumerable<TCourse> GetStudentCourses(TStudent student)
        {
            return _enrollments
                .Where(kv => kv.Value.Any(s => s.StudentId == student.StudentId))
                .Select(kv => kv.Key);
        }

        public int CalculateStudentWorkload(TStudent student)
        {
            return GetStudentCourses(student).Sum(c => c.Credits);
        }

        public bool IsStudentEnrolled(TStudent student, TCourse course)
        {
            return _enrollments.ContainsKey(course) &&
                   _enrollments[course].Any(s => s.StudentId == student.StudentId);
        }
    }

    public class GradeBook<TStudent, TCourse>
        where TStudent : IStudent
        where TCourse : ICourse
    {
        private readonly Dictionary<(TStudent, TCourse), double> _grades = new();
        private readonly EnrollmentSystem<TStudent, TCourse> _enrollment;

        public GradeBook(EnrollmentSystem<TStudent, TCourse> enrollment)
        {
            _enrollment = enrollment;
        }

        public void AddGrade(TStudent student, TCourse course, double grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentException("Grade must be 0–100");

            if (!_enrollment.IsStudentEnrolled(student, course))
                throw new InvalidOperationException("Student not enrolled");

            _grades[(student, course)] = grade;
            Console.WriteLine($"Grade added: {student.Name} {course.Title} = {grade}");
        }

        public double? CalculateGPA(TStudent student)
        {
            var studentGrades = _grades
                .Where(g => g.Key.Item1.StudentId == student.StudentId)
                .ToList();

            if (!studentGrades.Any())
                return null;

            double weightedSum = 0;
            int totalCredits = 0;

            foreach (var g in studentGrades)
            {
                weightedSum += g.Value * g.Key.Item2.Credits;
                totalCredits += g.Key.Item2.Credits;
            }

            return weightedSum / totalCredits;
        }

        public (TStudent student, double grade)? GetTopStudent(TCourse course)
        {
            var courseGrades = _grades
                .Where(g => EqualityComparer<TCourse>.Default.Equals(g.Key.Item2, course));

            if (!courseGrades.Any())
                return null;

            var top = courseGrades.OrderByDescending(g => g.Value).First();
            return (top.Key.Item1, top.Value);
        }
    }

}