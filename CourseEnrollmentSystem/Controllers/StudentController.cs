
using CES.Application.DTOs;
using CES.Application.DTOs.APIRESPONDS;
using CES.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
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
                var response = new ApiResponse<object>
                {
                    Success = true,
                    Message = "Student registered successfully & Enrolled to required courses.",
                    Data = new { StudentId = studentId }
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
