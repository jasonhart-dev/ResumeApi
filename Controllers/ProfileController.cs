using Microsoft.AspNetCore.Mvc;
using ResumeApi.Dtos;
using ResumeApi.Services;

namespace ResumeApi.Controllers
{
    [ApiController]
    [Route("api/profile")]
    public class ProfileController : ControllerBase
    {
        private readonly IResumeService _service;

        public ProfileController(IResumeService service)
        { 
            _service = service;
        }

        [HttpGet]
        public ActionResult<ProfileDto> Get()
        {
            return Ok(_service.GetSummary());
        }
    }
}
