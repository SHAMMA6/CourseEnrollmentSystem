
using CES.Application.DTOs;
using CES.Application.DTOs.APIRESPONDS;
using CES.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreatCourseDTO creatCourseDTO)
        {
            try
            {
                var courseId = await _courseService.CreateCourseAsync(creatCourseDTO);
                var response = new ApiResponse<object>
                {
                    Success = true,
                    Message = "Course created successfully.",
                    Data = new { CourseId = courseId }
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

        [HttpPut("{courseId}/update-description")]
        public async Task<IActionResult> UpdateCourseDescription(int courseId, UpdateCourseDTO updateCourseDTO)
        {
            try
            {
                await _courseService.UpdateCourseDescriptionAsync(updateCourseDTO);
                var response = new ApiResponse<object>
                {
                    Success = true,
                    Message = "Course description updated successfully."
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
