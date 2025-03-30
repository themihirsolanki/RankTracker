using Microsoft.AspNetCore.Mvc;
using RankTracker.API.Models;
using RankTracker.API.Models.Keywords;
using RankTracker.Core.Repositories;
using RankTracker.Core.Services;

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
        public async Task<ActionResult<IEnumerable<KeywordModel>>> GetAll([FromServices] IKeywordRepository keywordRepository)
        {
            var keywords = await keywordRepository.GetAllAsync();

            var models = keywords.Select(k => new KeywordModel
            {
                Id = k.Id,
                Keyword = k.Text,
                Rank = 5,
                DateUpdated = k.DateModified
            });

            return Ok(models);
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] AddKeywordModel model,[FromServices] IKeywordService keywordService)
        {
            await keywordService.AddKeywordAsync(model.Keyword);
            
            return Ok();
        }
    }
}
