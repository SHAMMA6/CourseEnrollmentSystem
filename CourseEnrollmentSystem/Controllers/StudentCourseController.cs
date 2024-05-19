
using CES.Application.DTOs;
using CES.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : Controller
    {
        private readonly IStudentCourseService _studentCourseService;

        public StudentCourseController(IStudentCourseService studentCourseService)
        {
            _studentCourseService = studentCourseService;
        }

        [HttpPost]
        public async Task<IActionResult> EnrollStudentInCourse(StudentCourseDTO studentCourseDTO)
        {
            try
            {
                await _studentCourseService.EnrollStudentInCourseAsync(studentCourseDTO);
                return Ok(new { Message = "Student enrolled in course successfully." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("course/{courseId}/students")]
        public async Task<IActionResult> GetStudentsEnrolledInCourse(int courseId)
        {
            var students = await _studentCourseService.GetStudentsEnrolledInCourseAsync(courseId);
            return Ok(students);
        }

        [HttpGet("student/{studentId}/courses")]
        public async Task<IActionResult> GetCoursesEnrolledByStudent(int studentId)
        {
            var courses = await _studentCourseService.GetCoursesEnrolledByStudentAsync(studentId);
            return Ok(courses);
        }
    }

}
