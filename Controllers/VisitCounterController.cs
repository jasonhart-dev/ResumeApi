using Microsoft.AspNetCore.Mvc;
using ResumeApi.Services;

namespace ResumeApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class VisitCounterController : ControllerBase
    {
        private readonly IVisitCounterService _visitCounterService;
        private readonly ILogger<VisitCounterController> _logger;

        public VisitCounterController(IVisitCounterService visitCounterService, ILogger<VisitCounterController> logger)
        {
            _visitCounterService = visitCounterService;
            _logger = logger;
        }

        /// <summary>
        /// Get the current visit count
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetVisitCount()
        {
            try
            {
                var count = await _visitCounterService.GetVisitCountAsync();
                return Ok(new { totalVisits = count });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting visit count");
                return StatusCode(500, new { error = "Failed to retreived visit count" });
            }
        }
        /// <summary>
        /// Increment the visit count and return the new total
        /// </summary>
        [HttpPost("increment")]
        public async Task<IActionResult> IncrementVisitCount()
        {
            try
            {
                var count = await _visitCounterService.IncrementVisitAsync();
                return Ok(new { totalVisits = count });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error incrementing visit count");
                return StatusCode(500, new { error = "Failed to increment visit count" });
            }
        }

        /// <summary>
        /// Get audit history of visit count changes
        /// </summary>
        [HttpGet("audit")]
        public async Task<IActionResult> GetAuditHistory([FromQuery] int limit = 100)
        {
            try
            {
                var history = await _visitCounterService.GetAuditHistoryAsync(limit);
                return Ok(history);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving audit history");
                return StatusCode(500, new { error = "Failed to retrieve audit history" });
            }
        }
    }
}
