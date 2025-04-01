using Microsoft.AspNetCore.Mvc;
using RankTracker.API.Models.Websites;
using RankTracker.Core.Repositories;
using RankTracker.Core.Services;

namespace RankTracker.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WebsitesController : ControllerBase
{
    private ILogger<WebsitesController> logger;
    
    public WebsitesController(ILogger<WebsitesController> logger)
    {
        this.logger = logger;
    }

    [HttpGet()]
    public async Task<ActionResult<WebsiteModel>> Get([FromServices] IWebsiteRepository websiteRepository)
    {
        try
        {
            var model = new WebsiteModel();

            var websites = await websiteRepository.GetAllAsync();

            // Currently only one website is supported
            // but our system is designed to support multiple websites in future
            // so we have this logic in place to get the first website
            if (websites.Any())
            {
                var website = websites.First();
                model.Domain = website.Domain;

                return Ok(model);
            }
            else
            {
                return NotFound();
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while getting the website.");
            return StatusCode(500);
        }
    }

    [HttpPost()]
    public async Task<IActionResult> Post(WebsiteModel model, [FromServices] IWebsiteService websiteService)
    {
        try
        {
            if (string.IsNullOrEmpty(model.Domain))
            {
                throw new InvalidOperationException("Domain cannot be empty.");
            }
            else
            {
                await websiteService.Add(model.Domain);
            }

            // can return 201 with created with the new website and its URL
            return Ok(new { message = "Website added successfully." });
        }
        catch (InvalidOperationException ex)
        {
            // this should ideally not happen but currently we have not restricted the setup page
            // so user may directly go to the page and try to add the same website again
            logger.LogError(ex, "An error occurred while adding the website. Duplicate Website");
            return BadRequest($"Website already exists. {ex.Message}");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while adding the website.");
            return StatusCode(500);
        }
    }
}
