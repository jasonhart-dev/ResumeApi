using Microsoft.AspNetCore.Mvc;
using ResumeApi.Services;

namespace ResumeApi.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly IResumeService _service;

        public SkillsController(IResumeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetSkills());
        }
    }
}
