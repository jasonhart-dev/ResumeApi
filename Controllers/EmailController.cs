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
        private readonly IEmailPersistenceService _emailPersistenceService;
        private readonly ILogger <EmailController> _logger;

        public EmailController(IEmailService emailService, IEmailPersistenceService emailPersistenceService, ILogger<EmailController> logger    )
        {
            _emailService = emailService;
            _emailPersistenceService = emailPersistenceService;
            _logger = logger;
        }

        /// <summary>
        /// Capture an email and store it in the database
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CaptureEmail([FromBody] EmailCaptureDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email))
                return BadRequest(new { success = false, message = "Email is required" });

            try
            {
                // Store in database
                bool saved = await _emailPersistenceService.SaveEmailAsync(dto.Email, "HomePage");

                if (saved)
                {
                    // Also store in memory for existing functionality
                    _emailService.Store(dto.Email);
                    return Ok(new { success = true, message = "Email captured" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Failed to save email" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error capturing email");
                return StatusCode(500, new { success = false, message = "Error capturing email" });
            }
        }

        /// <summary>
        /// Get all captured emails from the database
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetEmails()
        {
            try
            {
                var emails = await _emailPersistenceService.GetAllEmailsAsync();
                return Ok(emails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving emails");
                return StatusCode(500, new { success = false, message = "Error retrieving emails" });
            }
        }
        /// <summary>
        /// Get captured emails within a date range
        /// </summary>
        [HttpGet("range")]
        public async Task<IActionResult> GetEmailsByDateRange([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            try
            {
                var emails = await _emailPersistenceService.GetEmailsAsync(from, to);
                return Ok(emails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving emails for date range");
                return StatusCode(500, new { success = false, message = "Error retrieving emails" });
            }
        }
        /// <summary>
        /// Delete a captured email by ID (admin only)
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmail(int id)
        {
            try
            {
                bool deleted = await _emailPersistenceService.DeleteEmailAsync(id);
                if (deleted)
                    return Ok(new { success = true, message = "Email deleted" });
                else
                    return NotFound(new { success = false, message = "Email not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting email");
                return StatusCode(500, new { success = false, message = "Error deleting email" });
            }
        }
    }
}
