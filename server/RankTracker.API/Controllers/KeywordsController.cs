using Microsoft.AspNetCore.Mvc;
using RankTracker.API.Models;

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

        [HttpPost()]
        public IActionResult Post([FromBody] AddKeywordModel model)
        {
            return Ok();
        }
    }
}
