using Microsoft.AspNetCore.Mvc;

namespace ResumeApi.Controllers
{
    [ApiController]
    [Route("api/meta")]
    public class MetaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var meta = new
            {
                name = "ResumeAPI",
                owner = "Jason Hart",
                purpose = "Portfolio project showcasing ASP.NET Core APIs + Razor Pages resume UI",
                techStack = new[]
                {
                    "C#", "ASP.NET Core", "Razor Pages", "REST APIs", "Swagger / OpenAPI", "Bootstrap"
                },
                links = new
                {
                    home = "/",
                    resume = "/Resume",
                    swagger = "/swagger",
                    about = "/About",
                    github = "https://github.com/jasonhart-dev/ResumeApi",
                    contactEmail = "mailto:j24hart@gmail.com?subject=ResumeAPI%20-%20Inquiry"
                },
                endpoints = new[]
                {
                    "/api/meta",
                    "/swagger",
                    "/api/v2/resume (example)",
                    "/api/v2/hireme (example)"
                }
            };

            return Ok(meta);
        }
    }
}
