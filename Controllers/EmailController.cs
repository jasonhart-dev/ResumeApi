using Microsoft.AspNetCore.Mvc;
using ResumeApi.Dtos;
using ResumeApi.Services;

namespace ResumeApi.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/emails")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        // POST  /api/emails
        //[HttpGet]
        [HttpPost]
        public IActionResult CaptureEmail([FromBody] EmailCaptureDto dto)
        {
            
            if (string.IsNullOrWhiteSpace(dto.Email))
                return BadRequest("Email is required");

            //_emailService.StoreEmail(dto.Email);
            
            //_emailService.Store(dto.Email);
            bool added = _emailService.Store(dto.Email);
            if (added)
                return Ok(new { success = true, message = "Email captured" });
            else
                return BadRequest(new { success = false, message = "Email already registered" });


            //return Ok(new {Message = "Email captured successfully"});
        }
        [HttpGet]
        public IActionResult GetEmails()
        {
            //var emails = _emailService.GetEmails();
            var emails = _emailService.GetAll();
            return Ok(emails);
        }
    }
}
