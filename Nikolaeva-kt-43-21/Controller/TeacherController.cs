using Microsoft.AspNetCore.Mvc;
using Nikolaeva_kt_43_21.Filters.TeacherInterfaces;
using Nikolaeva_kt_43_21.Interfaces.TeacherInterfaces;

namespace Nikolaeva_kt_43_21.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ILogger<TeacherController> _logger;
        private readonly ITeacherService _teacherService;

        public TeacherController(ILogger<TeacherController> logger, ITeacherService teacherService)
        {
            _logger = logger;
            _teacherService = teacherService;
        }

        [HttpPost("GetTeachers")]
        public async Task<IActionResult> GetTeachersByCathedraAsync(TeacherCathedraFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherService.GetTeachersByCathedraAsync(filter, cancellationToken);
            return Ok(teachers);
        }
    }
}
