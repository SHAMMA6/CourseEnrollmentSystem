
using CES.Application.DTOs;
using CES.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
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
                return Ok(new { CourseId = courseId, Message = "Course created successfully." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }

        }



        [HttpPut("{courseId}/update-description")]
        public async Task<IActionResult> UpdateCourseDescription(UpdateCourseDTO updateCourseDTO)
        {
            try
            {
                await _courseService.UpdateCourseDescriptionAsync(updateCourseDTO);
                return Ok(new { Message = "Course description updated successfully." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }

}
