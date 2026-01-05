using Microsoft.AspNetCore.Mvc;
using ResumeApi.Dtos;
using ResumeApi.Services;

namespace ResumeApi.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:ApiVersion}/hireme")]
    public class HireMeController : ControllerBase
    {
        private readonly IHireMeService _hireMeService;
        private readonly ILogger<HireMeController> _logger;
        public HireMeController(IHireMeService hireMeService, ILogger<HireMeController> logger)
        {
            _hireMeService = hireMeService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Submit([FromBody] HireMeRequestDto request)
        {
            if (request is null)
            {
                _logger.LogWarning("HireMe request body was null");
                return BadRequest("Request body is required.");
            }

            if (string.IsNullOrWhiteSpace(request.Company) || string.IsNullOrWhiteSpace(request.JobTitle))
                {
                    _logger.LogWarning("HireMe validation failed. Missing Company or JobTitle. Company: {Company}, JobTitle: {JobTitle}",
                         request.Company, request.JobTitle);

                    return BadRequest("Company and Job Title Required.");
                }

            _logger.LogInformation("HireMe request received. Company: {Company}, JobTitle: {JobTitle}",
                request.Company, request.JobTitle);

            _hireMeService.Submit(request);

            _logger.LogInformation("HireMe request processed successfully. Company: {Company}, JobTitle: {JobTitle}",
                request.Company, request.JobTitle);

            return Ok(new {message = "Hire request received!"});
        }
    }
}
