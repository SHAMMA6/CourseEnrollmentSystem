
using CES.Application.DTOs;
using CES.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : Controller
    {
        private readonly ILevelService _levelService;

        public LevelController(ILevelService levelService)
        {
            _levelService = levelService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterLevel(CreatLevelDTO creatLevelDTO)
        {
            try
            {
                var levelId = await _levelService.RegisterLevelAsync(creatLevelDTO);
                return Ok(new { LevelId = levelId, Message = "Level registered successfully." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }

}
