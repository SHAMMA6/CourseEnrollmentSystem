
using CES.Application.DTOs;
using CES.Application.DTOs.APIRESPONDS;
using CES.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseTypeController : ControllerBase
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
                var response = new ApiResponse<object>
                {
                    Success = true,
                    Message = "CourseType registered successfully.",
                    Data = new { CourseTypeId = courseTypeId }
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
