
using CES.Application.DTOs;
using CES.Application.DTOs.APIRESPONDS;
using CES.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterInstructor(CreatInstructorDTO creatInstructorDTO)
        {
            try
            {
                var instructorId = await _instructorService.RegisterInstructorAsync(creatInstructorDTO);
                var response = new ApiResponse<object>
                {
                    Success = true,
                    Message = "Instructor registered successfully.",
                    Data = new { InstructorId = instructorId }
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
