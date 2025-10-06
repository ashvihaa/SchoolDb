namespace SchoolDbWeb.API.ViewModels
{
    public class CoursesVM
    {
        public int CourseId { get; set; }

        public string Title { get; set; } = null!;

        public int Credits { get; set; }
    }
}
