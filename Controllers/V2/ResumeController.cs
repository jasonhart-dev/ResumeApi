using Microsoft.AspNetCore.Mvc;
using ResumeApi.Services;
 

namespace ResumeApi.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/resume")]
    public class ResumeController : ControllerBase
    {
        private readonly IResumeService _resumeService;

        public ResumeController(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }

        /// <summary>
        /// Gets profesional summary information
        /// </summary>
        [HttpGet("summary")]
        public IActionResult GetSummary()
        {
            return Ok(_resumeService.GetSummary());
        }

        ///<summary>
        ///Gets frouped skill categories
        /// </summary>
        [HttpGet("skills")]
        public IActionResult GetSkills()
        {
            return Ok(_resumeService.GetSkills());
        }

        ///<summary>
        ///Get all experience entries
        /// </summary>
        [HttpGet("experience")]
        public IActionResult GetExperience() 
        { 
            return Ok(_resumeService.GetExperience());
        }

        ///<summary>
        /// Gets experience detail by ID
        /// </summary>
        [HttpGet("experience/{id}")]
        public IActionResult GetExperienceById(int id)
        {
            var experience = _resumeService.GetExperienceById(id);

            if (experience == null) 
                return NotFound();

                return Ok(experience);
            
        }

        /// <summary>
        /// Gets education information
        /// </summary>
        [HttpGet("education")]
        public IActionResult GetEducation()
        {
            return Ok(_resumeService.GetEducation());
        }
    }
}
