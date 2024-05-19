
using CES.Application.DTOs;
using CES.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : Controller
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
                return Ok(new { InstructorId = instructorId, Message = "Instructor registered successfully." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }

}
