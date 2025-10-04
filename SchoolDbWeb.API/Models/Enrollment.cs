using System;
using System.Collections.Generic;

namespace SchoolDbWeb.API.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public int? Grade { get; set; }

    public virtual Course Course { get; set; } = null!;

    //public virtual Student Student { get; set; } = null!;
    //public required object Courses { get; set; }
    public required Student Student { get; set; }
    public required Course Courses { get; set; }    // <- use Course, not object
}
