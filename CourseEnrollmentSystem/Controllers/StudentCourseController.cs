
using CES.Application.DTOs;
using CES.Application.DTOs.APIRESPONDS;
using CES.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase  
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
                var response = new ApiResponse<object>
                {
                    Success = true,
                    Message = "Student enrolled in course successfully."
                };
                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                var response = new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Errors = new List<string> { ex.Message }
                };
                return BadRequest(response);
            }
        }

        [HttpGet("course/{courseId}/students")]
        public async Task<IActionResult> GetStudentsEnrolledInCourse(int courseId)
        {
            try
            {
                var students = await _studentCourseService.GetStudentsEnrolledInCourseAsync(courseId);
                var response = new ApiResponse<object>
                {
                    Success = true,
                    Message = "Students retrieved successfully.",
                    Data = students
                };
                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                var response = new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Errors = new List<string> { ex.Message }
                };
                return BadRequest(response);
            }
        }

        [HttpGet("student/{studentId}/courses")]
        public async Task<IActionResult> GetCoursesEnrolledByStudent(int studentId)
        {
            try
            {
                var courses = await _studentCourseService.GetCoursesEnrolledByStudentAsync(studentId);
                var response = new ApiResponse<object>
                {
                    Success = true,
                    Message = "Courses retrieved successfully.",
                    Data = courses
                };
                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                var response = new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Errors = new List<string> { ex.Message }
                };
                return BadRequest(response);
            }
        }
    }

}
