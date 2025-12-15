using Microsoft.AspNetCore.Mvc;
using ResumeApi.Services;

namespace ResumeApi.Controllers
{
    [ApiController]
    [Route ("api/experience")]
    public class ExperienceController : ControllerBase
    {
        private readonly IResumeService _service;

        public ExperienceController(IResumeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetExperience());
        }
    }
}
