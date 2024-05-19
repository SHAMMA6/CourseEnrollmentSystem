
using CES.Application.DTOs;
using CES.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterDepartment(CreatDepartmentDTO creatDepartmentDTO)
        {
            try
            {
                var departmentId = await _departmentService.RegisterDepartmentAsync(creatDepartmentDTO);
                return Ok(new { DepartmentId = departmentId, Message = "Department registered successfully." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }

}
