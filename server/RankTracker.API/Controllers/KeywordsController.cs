using Microsoft.AspNetCore.Mvc;

namespace RankTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KeywordsController : ControllerBase
    {
        private ILogger<KeywordsController> _logger;

        public KeywordsController(ILogger<KeywordsController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok("API is running");
        }
    }
}
