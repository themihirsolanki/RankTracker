using Microsoft.AspNetCore.Mvc;
using RankTracker.API.Models;

namespace RankTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private ILogger<ConfigurationController> _logger;
        private static string DomainName;

        public ConfigurationController(ILogger<ConfigurationController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public ActionResult<ConfigurationModel> Get()
        {
            var model = new ConfigurationModel();
            model.Domain = DomainName;

            return Ok(model);
        }

        [HttpPost()]
        public ActionResult Post(ConfigurationModel model)
        {
            DomainName = model.Domain;
            return Ok(model);
        }
    }
}
