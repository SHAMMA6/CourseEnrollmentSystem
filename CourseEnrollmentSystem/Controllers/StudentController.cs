
using CES.Application.DTOs;
using CES.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterStudent(CreatStudentDto creatStudentDto)
        {
            try
            {
                var studentId = await _studentService.RegisterStudentAsync(creatStudentDto);
                return Ok(new { StudentId = studentId, Message = "Student registered successfully & Enrolled to required courses." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }

}
