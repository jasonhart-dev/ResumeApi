using Microsoft.AspNetCore.Mvc;
using ResumeApi.Dtos;
using ResumeApi.Services;

namespace ResumeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult CaptureEmail([FromBody] EmailCaptureDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email))
                return BadRequest("Email is required");
            _emailService.StoreEmail(dto.Email);

            return Ok(new {Message = "Email captured successfully"});
        }
        [HttpGet]
        public IActionResult GetEmails()
        {
            var emails = _emailService.GetEmails();
            return Ok(emails);
        }
    }
}
