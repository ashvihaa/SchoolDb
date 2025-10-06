namespace SchoolDbWeb.API.ViewModels
{
    public class StudentsVM
    {
        public partial class Student
        {
            internal object CourseId;
            internal object Students;
            internal object Course;
            internal object students;
            internal object Courses;

            public int StudentId { get; set; }

            public string Name { get; set; } = null!;

            public string? Email { get; set; }
        }
    }
}
