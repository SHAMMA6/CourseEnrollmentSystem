
using CES.Application.DTOs;
using CES.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseTypeController : Controller
    {
        private readonly ICoursTypeService _courseTypeService;

        public CourseTypeController(ICoursTypeService courseTypeService)
        {
            _courseTypeService = courseTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCourseTypeAsync(CreatCorseTypeDTO creatCorseTypeDTO)
        {
            try
            {
                var courseTypeId = await _courseTypeService.RegisterCourseTypeAsync(creatCorseTypeDTO);
                return Ok(new { DepartmentId = courseTypeId, Message = "CourseType registered successfully." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
