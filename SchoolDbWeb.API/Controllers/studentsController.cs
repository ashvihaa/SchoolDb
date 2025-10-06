using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolDbWeb.API.Models;

namespace SchoolDbWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentsController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        public studentsController(SchoolDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllStudents")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var students = await _context.Students.ToListAsync();
                return Ok(students);
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }
            
        }

        [HttpGet]
        [Route("GetById")]

        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var students = await _context.Students.FindAsync(id);
                if (students == null)
                {
                    return NotFound();
                }
                return Ok(students);
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }
        }

        [HttpGet]
        [Route("GetAllCourse")]

        public async Task<IActionResult> courses()
        {
            try
            {
                var courses = await _context.Courses.ToListAsync();
                return Ok(courses);
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }
        }

        [HttpGet]
        [Route("GetByCourseId")]

        public async Task<IActionResult> Courses(int id)
        {
            try
            {
                var courses = await _context.Courses.FindAsync(id);
                return Ok(courses);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        [HttpGet]
        [Route("GetCredits")]

        public async Task<IActionResult> Credits(int id)
        {
            try
            {
                var courses = await _context.Courses.FindAsync(id);
                return Ok(courses);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        [HttpGet]
        [Route("GetAllEnrollments")]

        public async Task<IActionResult> AllEnrollemnts()
        {
            try
            {
                var enrollments = await _context.Enrollments.ToListAsync();
                return Ok(enrollments);
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }
        }

        [HttpGet]
        [Route("EnrollmentId")]

        public async Task<IActionResult> Enrollment(int id)
        {
            try
            {
                var enrollments = await _context.Enrollments.FindAsync(id);
                return Ok(enrollments);
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }
        }

        [HttpGet]
        [Route("StudentId")]

        public async Task<IActionResult> enrollstudentid(int id)
        {
            try
            {
                var enrollments = await _context.Enrollments.FindAsync(id);
                return Ok(enrollments);
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }
        }

        [HttpGet]
        [Route("EnrollmentStudentId")]

        public async Task<IActionResult> enrollid(int id)
        {
            try
            {
                var enrollments = await _context.Enrollments.FindAsync(id);
                return Ok(enrollments);
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }
        }
        [HttpGet]
        [Route("StudentsCredits")]
        public async Task<IActionResult> GetCreditsByStudent(int id)
        {
            //using Exception handling try and catch
            try
            {
                //linq statements
                var credits = await (from e in _context.Enrollments
                                     join c in _context.Courses on e.CourseId equals c.CourseId
                                     where e.StudentId == id
                                     select c.Credits)
                                    .ToListAsync();

                if (credits == null || credits.Count == 0)
                    return NotFound("No enrolled courses found for studentId");

                return Ok(credits); // e.g. [3, 2]
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        [HttpGet]
        [Route("studentGrade")]

        public async Task<IActionResult> GetStudentGrades(int id)
        {
            try
            {
                var result = await (from s in _context.Students
                                    join e in _context.Enrollments on s.StudentId equals e.StudentId
                                    where s.StudentId == id
                                    select new
                                    {
                                        StudentName = s.Name,
                                        Grade = e.Grade
                                    }).ToListAsync();

                if (result == null || result.Count == 0)
                    return NotFound("No grades found for studentId");

                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        [HttpGet]
        [Route("Title")]

        public async Task<IActionResult> GetStudentCourses(int id)
        {
            try
            {
                var result = await (from s in _context.Students
                                    join e in _context.Enrollments on s.StudentId equals e.StudentId
                                    join c in _context.Courses on e.CourseId equals c.CourseId
                                    where s.StudentId == id
                                    select new
                                    {
                                        StudentName = s.Name,
                                        CourseTitle = c.Title
                                    }).ToListAsync();

                if (result == null || result.Count == 0)
                    return NotFound("No courses found for studentId");

                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        [HttpGet]
        [Route("StudentEmail")]
        public async Task<IActionResult> GetStudentInfo(int id)
        {
            try
            {
                var student = await _context.Students
                    .Where(s => s.StudentId == id)
                    .Select(s => new
                    {
                        Name = s.Name,
                        Email = s.Email
                    }).FirstOrDefaultAsync();


                if (student == null)
                    return NotFound("No student found with ID");

                return Ok(student);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

         [HttpGet]
         [Route("GetStudentName")]
         public async Task<IActionResult> GetStudentName(int id)
         {
                try
                {
                    var studentName = await _context.Students
                                                    .Where(s => s.StudentId == id)
                                                    .Select(s => s.Name)
                                                    .FirstOrDefaultAsync();

                    if (studentName == null)
                        return NotFound("Student not found");

                    return Ok(studentName);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                } 
         }
    }

}
