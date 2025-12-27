using Microsoft.AspNetCore.Mvc;
using ResumeApi.Dtos;
using ResumeApi.Services;

namespace ResumeApi.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:ApiVersion}/hireme")]
    public class HireMeController : Controller
    {
        private readonly IHireMeService _hireMeService;
        public HireMeController(IHireMeService hireMeService)
        {
            _hireMeService = hireMeService;
        }

        [HttpPost]
        public IActionResult Submit([FromBody] HireMeRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Company) || string.IsNullOrWhiteSpace(request.JobTitle))
                {
                    return BadRequest("Company and Job Title Required.");
                }
            _hireMeService.Submit(request);
            return Ok(new {message = "Hire request received!"});
        }
    }
}
