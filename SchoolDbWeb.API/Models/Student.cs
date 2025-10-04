using System;
using System.Collections.Generic;

namespace SchoolDbWeb.API.Models;

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

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
