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
        private ILogger<KeywordsController> logger;
        
        public KeywordsController(ILogger<KeywordsController> logger)
        {
            this.logger = logger;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<KeywordModel>>> GetAll([FromServices] IKeywordRepository keywordRepository)
        {
            try
            {
                var keywords = await keywordRepository.GetAllAsync();

                // TODO: Replace this with AutoMapper
                var models = keywords.Select(k => new KeywordModel
                {
                    Id = k.Id,
                    Keyword = k.Text,
                    Rank = k.Rank,
                    DateUpdated = k.DateModified
                });

                return Ok(models);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while getting the keywords.");
                return StatusCode(500);
            }
            
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] AddKeywordModel model,[FromServices] IKeywordService keywordService)
        {
            try
            {
                await keywordService.AddKeywordAsync(model.Keyword);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while adding the keyword.");
                return StatusCode(500);
            }
            
        }

        [HttpGet("refresh-all")]
        public async Task<IActionResult> RefreshAll([FromServices] IKeywordService keywordService)
        {
            try
            {
                await keywordService.RefreshRankings();
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while refreshing keyword rankings.");
                return StatusCode(500);
            }
        }

        [HttpGet("refresh/{id}")]
        public async Task<IActionResult> Refresh(int id, [FromServices] IKeywordService keywordService)
        {
            try
            {
                await keywordService.RefreshRanking(id);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while refreshing keyword rankings.");
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromServices] IKeywordService keywordService)
        {
            try
            {
                await keywordService.DeleteKeywordAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while adding the keyword.");
                return StatusCode(500);
            }

        }

    }
}
