using Microsoft.AspNetCore.Mvc;

namespace ResumeApi.Controllers.V2
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        [HttpGet("throw")]
        public IActionResult Throw()
        {
            throw new InvalidOperationException("This is a forced test exception");
        }
    }

}
